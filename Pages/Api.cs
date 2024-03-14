using BlazingDarts.Pages;
using System.Text;
using System.Text.Json;

namespace Classes;

public class Api()
{
    readonly string URL = "http://192.168.88.37:3001";

    public async Task SendMatch(Darts game)
    {
        HttpClient client = new()
        {
            BaseAddress = new Uri(URL)
        };
        var requestData = new RequestGame(game);
        var json = JsonSerializer.Serialize(requestData);

        // Post the serialized data to the API endpoint
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var result = await client.PostAsync("api/insertGame", content);
    }

    class RequestGame(Darts game)
    {
        public string spieler1 = game.players[0].name;
        public string spieler2 = game.players[1].name;
        public int spieler1legs = game.players[0].legsWon;
        public int spieler2legs = game.players[1].legsWon;
    }
}
