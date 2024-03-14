namespace Classes;

using Throws = (int? first, int? second, int? third);

public class Player(string Name)
{
    public List<Throws> throws = [];
    public string name = Name;
    public int score = 501;
    public int legsWon = 0;
    public Throws lastThree = (null, null, null);

    public void AddThrow(int hit)
    {
        if (lastThree.first is null)
        {
            lastThree.first = hit;
        }
        else if (lastThree.second is null)
        {
            lastThree.second = hit;
        }
        else
        {
            lastThree.third = hit;
        }
    }

    public void ResetLastThree()
    {
        score += (lastThree.first ?? 0) + (lastThree.second ?? 0) + (lastThree.third ?? 0);
    }
}


