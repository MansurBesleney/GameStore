namespace GameStore.api.Contracts
{
    public record class CreateGameDto(
        String Name,
        String Genre,
        decimal Price,
        DateOnly ReleaseDate
    );
}
