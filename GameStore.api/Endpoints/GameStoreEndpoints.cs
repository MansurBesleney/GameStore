using GameStore.api.Contracts;
using GameStore.api.Data;
using GameStore.api.Entities;
using GameStore.api.Mapping;

namespace GameStore.api.Endpoints
{
    public static class GameStoreEndpoints
    {
        const String GetGameEndpointName = "GetGame";


        private static readonly List<GameDto> games = [
            new (
                1,
                "Red Dead Redemption 2",
                "Masterpiece",
                249.99M,
                new DateOnly(2010, 10, 10)
                ),

            new (
                2,
                "God Of War",
                "Action",
                199.99M,
                new DateOnly(2011, 11, 11)
                ),

            new (
                3,
                "Sekiro: Shadows Die Twice",
                "Souls-Like",
                149.99M,
                new DateOnly(2012, 12, 12)
                ),

            new (
                4,
                "Titanfall 2",
                "FPS Shooter",
                49.99M,
                new DateOnly(2013, 01, 01)
                )

            ];

        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {

            var group = app.MapGroup("games")
                .WithParameterValidation(); // This method comes from MinimalApis.Extensions nuget package
                                            // it helps with validation of the parameters using the annotations I wrote at the Dtos
                                            // With this type of usage we actually apply this method to all the requests that we use in this RouteGroup
                                            // GET /games
            group.MapGet("/", () => games);

            // GET /game/1
            group.MapGet("/{id}", (int id) =>
            {
                GameDto? game = games.Find(game => game.Id == id);

                if (game == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(game);
                }
            }).WithName(GetGameEndpointName);

            //POST /games
            group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbcontext) =>
            {
                Game game = newGame.ToEntity();
                game.Genre = dbcontext.Genres.Find(newGame.GenreId);

                dbcontext.Games.Add(game);
                dbcontext.SaveChanges();

                return Results.CreatedAtRoute(
                    GetGameEndpointName, 
                    new { id = game.Id }, 
                    game.ToDto());
            });

            //PUT games/1
            group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
            {
                int index = games.FindIndex(game => game.Id == id);

                if (index == -1)
                {
                    return Results.NotFound();
                }

                games[index] = new GameDto(
                        id,
                        updatedGame.Name,
                        updatedGame.Genre,
                        updatedGame.Price,
                        updatedGame.ReleaseDate
                    );
                return Results.NoContent();

            });

            //DELETE games/1
            group.MapDelete("/{id}", (int id) =>
            {
                games.RemoveAll(game => game.Id == id);

                return Results.NoContent();
            });

            return group;
        }
    }
}
