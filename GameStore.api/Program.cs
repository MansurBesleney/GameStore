using GameStore.api.Contracts;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const String GetGameEndpointName = "GetGame";

List<GameDto> games = [
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

// GET /games
app.MapGet("games", () => games);

// GET /game/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
    .WithName(GetGameEndpointName);

//POST /games
app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(
    games.Count + 1,
    newGame.Name,
    newGame.Genre,
    newGame.Price,
    newGame.ReleaseDate
    );

    games.Add( game );

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

//PUT games/1
app.MapPut("games/{id}", (int id,UpdateGameDto updatedGame) =>
{
    int index = games.FindIndex(game => game.Id == id);

    games[index] = new GameDto(
            id,
            updatedGame.Name,
            updatedGame.Genre,
            updatedGame.Price,
            updatedGame.ReleaseDate
        );
    Results.NoContent();
});

//DELETE games/1
app.MapDelete("games/{id}", (int id) => 
{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});


app.Run();
