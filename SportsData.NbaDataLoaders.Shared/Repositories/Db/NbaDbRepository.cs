using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using SportsData.NbaDataLoaders.Shared.Entities.Nba.NbaDbDtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SportsData.NbaDataLoaders.Shared.Repositories.Db
{
    public class NbaDbRepository : INbaDbRepository
    {
        // The Azure Cosmos DB endpoint for running this sample.
        private static readonly string EndpointUri = Environment.GetEnvironmentVariable("NbaDatabaseUri");
        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey = Environment.GetEnvironmentVariable("NbaDatabasePrimaryKey");

        // The Cosmos client instance
        private CosmosClient CosmosClient;

        // The container we will create.
        private Container Container;

        // The name of the database and container we will create
        private string DatabaseName = Environment.GetEnvironmentVariable("NbaDatabaseName");
        private string TeamsContainerName = Environment.GetEnvironmentVariable("TeamsCollectionName");

        public NbaDbRepository()
        {
            // Create a new instance of the Cosmos Client in Gateway mode
            CosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions()
            {
                ConnectionMode = Microsoft.Azure.Cosmos.ConnectionMode.Gateway
            });
            Container = CosmosClient.GetContainer(DatabaseName, TeamsContainerName);
        }

        public async Task<NbaTeamPerformanceDbDto> UpdateTeamStatsAsync(NbaTeamPerformanceDbDto dto)
        {
            var partitionKey = new Microsoft.Azure.Cosmos.PartitionKey(dto.TeamKey);
            try
            {
                // Read the item to see if it exists.  
                ItemResponse<NbaTeamPerformanceDbDto> teamPerformanceResponse = await this.Container.ReadItemAsync<NbaTeamPerformanceDbDto>(dto.Id, partitionKey);
                Console.WriteLine("Item in database with id: {0} already exists\n", teamPerformanceResponse.Resource.Id);
                NbaTeamPerformanceDbDto updatedDto = UpdateTeamPerformances(dto, teamPerformanceResponse.Resource);
                ItemResponse<NbaTeamPerformanceDbDto> response = await Container.UpsertItemAsync(updatedDto, partitionKey);
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Create an item in the container representing the Team Performance. 
                ItemResponse<NbaTeamPerformanceDbDto> teamPerformanceResponse = await this.Container.CreateItemAsync<NbaTeamPerformanceDbDto>(dto, partitionKey);

                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
                Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", teamPerformanceResponse.Resource.Id, teamPerformanceResponse.RequestCharge);
                return teamPerformanceResponse.Resource;
            }
        }

        private NbaTeamPerformanceDbDto UpdateTeamPerformances(NbaTeamPerformanceDbDto newDto, NbaTeamPerformanceDbDto originalDto)
        {
            originalDto.Stats.Assists += newDto.Stats.Assists;
            originalDto.Stats.Blocks += newDto.Stats.Blocks;
            originalDto.Stats.DefReb += newDto.Stats.DefReb;
            originalDto.Stats.FastBreakPoints += newDto.Stats.FastBreakPoints;
            originalDto.Stats.FGA += newDto.Stats.FGA;
            originalDto.Stats.FGM += newDto.Stats.FGM;
            originalDto.Stats.FTA += newDto.Stats.FTA;
            originalDto.Stats.FTM += newDto.Stats.FTM;
            originalDto.Stats.OffReb += newDto.Stats.OffReb;
            originalDto.Stats.PFouls += newDto.Stats.PFouls; 
            originalDto.Stats.PlusMinus += newDto.Stats.PlusMinus;
            originalDto.Stats.PointsAgainst += newDto.Stats.PointsAgainst;
            originalDto.Stats.PointsFor += newDto.Stats.PointsFor;
            originalDto.Stats.PointsInPaint += newDto.Stats.PointsInPaint;
            originalDto.Stats.PointsOffTurnovers += newDto.Stats.PointsOffTurnovers;
            originalDto.Stats.SecondChancePoints += newDto.Stats.SecondChancePoints;
            originalDto.Stats.Steals += newDto.Stats.Steals;
            originalDto.Stats.TotReb += newDto.Stats.TotReb;
            originalDto.Stats.TPA += newDto.Stats.TPA;
            originalDto.Stats.TPM += newDto.Stats.TPM;
            originalDto.Stats.Turnovers += newDto.Stats.Turnovers;
            originalDto.GamesPlayed++;
            //originalDto.Stats.Min = TimeSpan.Parse(originalDto.Stats.Min).Add(TimeSpan.Parse(newDto.Stats.Min)).ToString();
            return originalDto;
        }
    }
}
