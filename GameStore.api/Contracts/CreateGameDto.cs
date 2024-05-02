using System.ComponentModel.DataAnnotations;

namespace GameStore.api.Contracts
{
    public record class CreateGameDto(
        [Required][StringLength(50)] String Name,
        [Required][StringLength(25)] String Genre,
        [Range(1,200)] decimal Price,
        DateOnly ReleaseDate
    );
}
