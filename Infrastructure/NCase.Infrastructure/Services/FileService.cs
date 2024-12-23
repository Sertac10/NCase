﻿using NCase.Application.Common.Extensions;
using NCase.Application.Services;
using NCase.Infrastructure.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace NCase.Infrastructure.Services;
public class FileService : IFileService
{
    readonly IWebHostEnvironment _webHostEnvironment;

    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<bool> CopyFileAsync(string path, IFormFile file)
    {
        return await ExceptionHandler.HandleAsync(async () =>
        {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, false);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;

        });
    }
    public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
    {
        string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        List<(string fileName, string path)> datas = new();
        List<bool> results = new();
        foreach (IFormFile file in files)
        {
            string fileNewName = await FileRenameAsync(uploadPath, file.FileName);

            bool result = await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
            datas.Add((fileNewName, $"{path}\\{fileNewName}"));
            results.Add(result);
        }

        if (results.TrueForAll(a => a.Equals(true)))
            return datas;

        //todo eğer ki yukarıdaki if geçerli değilse burada dosyaların sunucuya yüklenirken hata alındığına dair uyarıcı bir exception oluşturup fırlatılması gereklidir.
        return null;
    }

    private async Task<string> FileRenameAsync(string path, string fileName, bool first = true)
    {
        string newFileName = await Task.Run<string>(async () =>
        {
            string extension = Path.GetExtension(fileName);

            string newFileName = string.Empty;
            if (first)
            {
                string oldName = Path.GetFileNameWithoutExtension(fileName);
                newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";
            }
            else
            {
                newFileName = fileName;
                int indexNo1 = newFileName.IndexOf("-");
                if (indexNo1 == -1)
                {
                    newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
                }
                else
                {
                    int lastIndex = 0;
                    while (true)
                    {
                        lastIndex = indexNo1;
                        indexNo1 = newFileName.IndexOf("-", indexNo1 + 1);
                        if (indexNo1 == -1)
                        {
                            indexNo1 = lastIndex;
                            break;
                        }
                    }

                    int indexNo2 = newFileName.IndexOf(".");
                    string fileNo = newFileName.Substring(indexNo1 + 1, indexNo2 - indexNo1 - 1);

                    if (int.TryParse(fileNo, out int _fileNo))
                    {
                        _fileNo++;
                        newFileName = newFileName.Remove(indexNo1 + 1, indexNo2 - indexNo1 - 1).Insert(indexNo1 + 1, _fileNo.ToString());
                    }
                    else
                    {
                        newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
                    }
                }
            }

            if (File.Exists($"{path}\\{newFileName}"))
                return await FileRenameAsync(path, newFileName, false);
            else
                return newFileName;
        });

        return newFileName;
    }
}
