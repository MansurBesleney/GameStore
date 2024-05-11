namespace GameStore.api.Contracts;

public record class GameSummaryDto(
    int Id,
    String Name,
    String Genre,
    decimal Price,
    DateOnly ReleaseDate
    );
