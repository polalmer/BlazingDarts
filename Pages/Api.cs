using BlazingDarts.Pages;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Classes;

public class Api()
{
    readonly string URL = "http://192.168.88.37:3001";

    public async Task SendMatch(List<Player> players)
    {
        // Serialize the data to JSON
        var request = new RequestGame(players);

        using HttpClient httpClient = new()
        {
            BaseAddress = new Uri(URL)
        };

        // Send the POST request
        var response = await httpClient.PostAsJsonAsync("api/insertGame", request);
        await response.Content.ReadAsStringAsync();
    }

    class RequestGame(List<Player> players)
    {
        [JsonPropertyName("spieler1")]
        public string spieler1 = players[0].name;
        [JsonPropertyName("spieler2")]
        public string spieler2 = players[1].name;
        [JsonPropertyName("spieler1legs")]
        public int spieler1legs = players[0].legsWon;
        [JsonPropertyName("spieler2legs")]
        public int spieler2legs = players[1].legsWon;
    }
}
