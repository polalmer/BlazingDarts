namespace Classes;

using Throws = (int?, int?, int?);

public class Player(string Name)
{
    public List<Throws> throws = [];
    public string name = Name;
    public int score = 501;
    public Throws lastThree = (null, null, null);
}


