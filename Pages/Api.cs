using BlazingDarts.Pages;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Classes;

public class Api()
{
    readonly string URL = "http://192.168.88.37:3001";

    public async Task SendMatch(Darts game)
    {
        // Serialize the data to JSON
        var request = new RequestGame(game);

        var json = JsonSerializer.Serialize(request);

        // Create the HttpContent for the request
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using HttpClient httpClient = new()
        {
            BaseAddress = new Uri(URL)
        };

        // Send the POST request
        var response = await httpClient.PostAsync("api/insertGame", content);
        await response.Content.ReadAsStringAsync();
    }

    class RequestGame(Darts game)
    {
        [JsonPropertyName("spieler1")]
        public string spieler1 = game.players[0].name;
        [JsonPropertyName("spieler2")]
        public string spieler2 = game.players[1].name;
        [JsonPropertyName("spieler1legs")]
        public int spieler1legs = game.players[0].legsWon;
        [JsonPropertyName("spieler2legs")]
        public int spieler2legs = game.players[1].legsWon;
    }
}
