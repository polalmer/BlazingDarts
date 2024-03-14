using BlazingDarts.Pages;
using System.Net.Http.Json;

namespace Classes;

public class Api()
{
    readonly string URL = "192.168.88.37:3001";

    public async Task SendMatch(Darts game)
    {
        HttpClient client = new()
        {
            BaseAddress = new Uri(URL)
        };
        var result = await client.PostAsJsonAsync<RequestGame>("/api/insertGame", new(game));
    }

    class RequestGame(Darts game)
    {
        public string spieler1 = game.players[0].name;
        public string spieler2 = game.players[1].name;
        public int spieler1legs = game.players[0].legsWon;
        public int spieler2legs = game.players[1].legsWon;
    }
}
