namespace GameStore.api.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; } // In Entity Framework we need to define two properties if we need to apply one to one relation between our data models
        public decimal Price { get; set; }
        public DateOnly ReleaseDate { get; set; } 
    }
}
