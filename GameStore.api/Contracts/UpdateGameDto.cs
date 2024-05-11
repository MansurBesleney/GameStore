﻿using System.ComponentModel.DataAnnotations;

namespace GameStore.api.Contracts
{
    public record class UpdateGameDto(
        [Required][StringLength(50)] String Name,
        int GenreId,
        [Range(1,200)] decimal Price,
        DateOnly ReleaseDate
    );
}
