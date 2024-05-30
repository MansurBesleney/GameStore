using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class GamesClient
    {
        private readonly List<GameSummary> games =
        [
                new(){
                    Id = 1,
                    Name = "Red Dead Redemption 2",
                    Genre = "Masterpiece",
                    Price = 59.99M,
                    ReleaseDate = new DateOnly(2019, 11, 9)
                },
                new(){
                    Id = 2,
                    Name = "IRacing",
                    Genre = "Simulation Racing",
                    Price = 29.99M,
                    ReleaseDate = new DateOnly(2018, 10, 8)
                },
                new(){
                    Id = 3,
                    Name = "Titanfall 2",
                    Genre = "FPS",
                    Price = 44.99M,
                    ReleaseDate = new DateOnly(2017, 10, 7)
                },
                new(){
                    Id = 4,
                    Name = "Street Fighter",
                    Genre = "Fighting",
                    Price = 69.99M,
                    ReleaseDate = new DateOnly(2016, 9, 6)
                },
                new(){
                    Id = 5,
                    Name = "Sekiro: Shadows Die Twice",
                    Genre = "Souls-like",
                    Price = 49.99M,
                    ReleaseDate = new DateOnly(2015, 8, 5)
                },
        ];

        public GameSummary[] GetGames() => [.. games]; // [.. games] = games.ToArray()

        public GenresClient genresClient = new();
        public void InsertGame(GameDetails game)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);

            var gameSummary = new GameSummary
            {
                Id = games.Count + 1,
                Name = game.Name,
                Genre = genresClient.GetGenreById(int.Parse(game.GenreId)).Name,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
            };

            games.Add(gameSummary);
        }
    }
}
