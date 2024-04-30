using GameStore.api.Contracts;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id));


app.Run();
