using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Classes;

public class Api()
{
    readonly string URL = "http://192.168.88.37:3001";

    public async Task SendMatch(List<Player> players)
    {
        using HttpClient httpClient = new()
        {
            BaseAddress = new Uri(URL)
        };

        RequestGame request = new(players);

        // Send the POST request
        var response = await httpClient.PostAsJsonAsync("api/insertGame", request);
        await response.Content.ReadAsStringAsync();
    }

    class RequestGame(List<Player> players)
    {
        [JsonPropertyName("spieler1")]
        public string Spieler1 { get; set; } = players.First().name;

        [JsonPropertyName("spieler2")]
        public string Spieler2 { get; set; } = players.Last().name;

        [JsonPropertyName("spieler1legs")]
        public int Spieler1legs { get; set; } = players.First().legsWon;

        [JsonPropertyName("spieler2legs")]
        public int Spieler2legs { get; set; } = players.Last().legsWon;
    }
}
