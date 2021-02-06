using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SportsData.Infrastructure.Repositories.Nba;
using SportsData.NbaDataLoaders;
using SportsData.NbaDataLoaders.Shared.Mappers.Nba;
using SportsData.NbaDataLoaders.Shared.Repositories.Db;
using SportsData.NbaDataLoaders.Shared.Repositories.Odds;
using SportsData.NbaDataLoaders.Shared.Services;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace SportsData.NbaDataLoaders
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // var services = builder.Services;
            builder.Services.AddSingleton(s => {
                var connectionString = Environment.GetEnvironmentVariable("CosmosDBConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException(
                        "Please specify a valid CosmosDBConnection in the appSettings.json file or your Azure Functions Settings.");
                }

                return new CosmosClientBuilder(connectionString)
                    .Build();
           });
            builder.Services.AddHttpClient();
            builder.Services.AddLogging();
            builder.Services.AddSingleton<INbaApiService, NbaApiService>();
            builder.Services.AddSingleton<INbaUpdateService, NbaUpdateService>();
            builder.Services.AddSingleton<INbaOddsService, NbaOddsService>();
            builder.Services.AddSingleton<INbaOddsRepository, NbaOddsRepository>();
            builder.Services.AddSingleton<INbaApiRepository, NbaApiRepository>();
            builder.Services.AddSingleton<INbaDbRepository, NbaDbRepository>();
            builder.Services.AddSingleton<IGetGamesByDateResponseMapper, GetGamesByDateResponseMapper>();
            builder.Services.AddTransient<IOddsRequestToDbDtoMapper, OddsRequestToDbDtoMapper>();
        }
    }
}
