using GameStore.api.Contracts;
using GameStore.api.Data;
using GameStore.api.Entities;
using GameStore.api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Endpoints
{
    public static class GameStoreEndpoints
    {
        const String GetGameEndpointName = "GetGame";
        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {

            var group = app.MapGroup("games")
                .WithParameterValidation(); // This method comes from MinimalApis.Extensions nuget package
                                            // it helps with validation of the parameters using the annotations I wrote at the Dtos
                                            // With this type of usage we actually apply this method to all the requests that we use in this RouteGroup
                                            // GET /games
            group.MapGet("/",  async (GameStoreContext dbContext) =>
            (
                await dbContext.Games
                            .Include(game => game.Genre)
                            .Select(game => game.ToGameSummaryDto())
                            .AsNoTracking()
                            .ToListAsync()
            ));

            // GET /game/1
            group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
            {
                Game? game = await dbContext.Games.FindAsync(id);

                if (game == null)
                {
                    return Results.NotFound();
                }
                else
                { 
                    return Results.Ok(game.ToGameDetailsDto());
                }
            }).WithName(GetGameEndpointName);

            //POST /games
            group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbcontext) =>
            {
                Game game = newGame.ToEntity();

                dbcontext.Games.Add(game);
                await dbcontext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    GetGameEndpointName, 
                    new { id = game.Id }, 
                    game.ToGameDetailsDto());
            });

            //PUT games/1
            group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
            {
                var existingGame = await dbContext.Games.FindAsync(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingGame)
                        .CurrentValues
                        .SetValues(updatedGame.ToEntity(id));

                await dbContext.SaveChangesAsync();
                return Results.NoContent();

            });

            //DELETE games/1
            group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
            {
                await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
