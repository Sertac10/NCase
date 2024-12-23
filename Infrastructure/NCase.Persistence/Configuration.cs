﻿using Microsoft.Extensions.Configuration;

namespace NCase.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/NCase.API"));
                configurationManager.SetBasePath(AppContext.BaseDirectory);
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SQLServer");

                //   ConfigurationManager configurationManager = new();
                //    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "/../../Presentation/NCase.API"));
                ////     configurationManager.SetBasePath(AppContext.BaseDirectory);
                //   //   configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "/Presentation/NCase.API"));
                //   // configurationManager.SetBasePath("app/Presentation/NCase.API");
                //   //  var basePath = AppContext.BaseDirectory; // Bu, uygulamanın çalıştığı dizini alır

                //   // configurationManager.SetBasePath(basePath);

                //   configurationManager.AddJsonFile("appsettings.json");
                //   return configurationManager.GetConnectionString("SQLServer");

                //var configurationBuilder = new ConfigurationBuilder()
                //    .SetBasePath(Directory.GetCurrentDirectory())  // Genellikle /app dizininde çalışır
                //    .AddJsonFile("appsettings.json");

                //var configuration = configurationBuilder.Build();
                //return configuration.GetConnectionString("SQLServer");

            }
        }
    }
}
