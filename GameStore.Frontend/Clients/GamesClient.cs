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
                    Genre = "Action-adventure",
                    Price = 59.99M,
                    ReleaseDate = new DateOnly(2019, 11, 9)
                },
                new(){
                    Id = 2,
                    Name = "IRacing",
                    Genre = "Racing",
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

        private readonly Genre[] genres = new GenresClient().GetGenres();
        public void InsertGame(GameDetails game)
        {
            Genre genre = GetGenreById(game.GenreId);

            var gameSummary = new GameSummary
            {
                Id = games.Count + 1,
                Name = game.Name,
                Genre = genre.Name,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
            };

            games.Add(gameSummary);
        }



        public GameDetails GetGameDetails(int id)
        {
            GameSummary game = GetGameSummaryById(id);

            var genre = genres.Single(genre => string.Equals(
                genre.Name,
                game.Genre,
                StringComparison.OrdinalIgnoreCase));

            return new GameDetails
            {
                Id = game.Id,
                Name = game.Name,
                GenreId = genre.Id.ToString(),
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
            };
        }

        public void UpdateGame(GameDetails game)
        {
            var genre = GetGenreById(game.GenreId);

            GameSummary existingGame = GetGameSummaryById(game.Id);

            existingGame.Name = game.Name;
            existingGame.Price = game.Price;
            existingGame.Genre = genre.Name;
            existingGame.ReleaseDate = game.ReleaseDate;

        }

        private GameSummary GetGameSummaryById(int id)
        {
            GameSummary? game = games.Find(game => game.Id == id);
            ArgumentNullException.ThrowIfNull(game);
            return game;
        }

        private Genre GetGenreById(String? id)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(id);
            return genres.Single(genre => genre.Id == int.Parse(id));
        }

    }
}
