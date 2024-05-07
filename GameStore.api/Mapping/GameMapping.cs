using GameStore.api.Contracts;
using GameStore.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Mapping
{
    public static class GameMapping
    {
        public static Game ToEntity(this CreateGameDto game)
        {
            return new Game()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
            };
        }

        public static GameDto ToDto(this Game game)
        {
            return new
            (
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.ReleaseDate
            );
        }
    }
}
