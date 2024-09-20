using GameStore.api.Data;
using GameStore.api.Endpoints;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore"); // The conString is coming grom appsettings.json file.
                                                                        // Because of sqlLite there is no problem to store connection string at appsettings.json file
                                                                       // If you use any database providers that includes any credentials at connection string you should use
                                                                      // another way to store connection string like user secrets
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndpoints();

await app.MigrateDBAsync();

app.Run();
