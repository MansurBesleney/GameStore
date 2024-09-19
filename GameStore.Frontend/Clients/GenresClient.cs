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
                new(){
                    Id = 6,
                    Name = "Souls-like"
                },
                new(){
                    Id= 7,
                    Name="Action-adventure"
                }
        ];

        public Genre[] GetGenres() => genres;

        public Genre GetGenreById(int id)
        {
            return genres[id - 1];
        }
    }
}
