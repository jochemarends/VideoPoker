using System.Net.Http.Json;
using VideoPoker.Models;

namespace VideoPoker.Services
{
    public class DeckOfCardsService
    {
        private readonly HttpClient httpClient = new();

        public async Task<Deck> GetDeckAsync()
        {
            var response = await httpClient.GetAsync("https://deckofcardsapi.com/api/deck/new/draw/?count=52");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to create a deck of cards.");
            }

            return await response.Content.ReadFromJsonAsync<Deck>();
        }
    }
}
