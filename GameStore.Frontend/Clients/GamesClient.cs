using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class GamesClient(HttpClient httpClient)
    {
        public async Task<GameSummary[]> GetGamesAsync() 
            => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

        public async Task InsertGameAsync(GameDetails game)
            => await httpClient.PostAsJsonAsync("games", game);

        public async Task<GameDetails> GetGameDetailsAsync(int id)
            => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ??
            throw new Exception("Could Not Find Game");

        public async Task UpdateGameAsync(GameDetails game)
            => await httpClient.PutAsJsonAsync($"games/{game.Id}", game);

        public async Task DeleteGameAsync(int id)
            => await httpClient.DeleteAsync($"games/{id}");

    }
}
