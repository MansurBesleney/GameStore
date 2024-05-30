using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class GenresClient
    {
        private readonly Genre[] genres =
        [
                new(){
                    Id = 1,
                    Name = "FPS"
                },
                new(){
                    Id = 2,
                    Name = "RPG"
                },
                new(){
                    Id = 3,
                    Name = "Sports"
                },
                new(){
                    Id = 4,
                    Name = "Fighting"
                },
                new(){
                    Id = 5,
                    Name = "Racing"
                },
        ];

        public Genre[] GetGenres() => genres;
    }
}
