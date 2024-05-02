namespace GameStore.api.Contracts
{
    public record class UpdateGameDto(
        String Name,
        String Genre,
        decimal Price,
        DateOnly ReleaseDate
    );
}
