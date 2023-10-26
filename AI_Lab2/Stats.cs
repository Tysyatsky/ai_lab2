namespace AI_Lab2;

public class Stats
{
    private int Art { get; set; }
    private int People { get; set; }
    private int Technology { get; set; }

    public string Name { get; set; }

    public Stats() 
    { 
        Art = 0;
        People = 0;
        Technology = 0;
        Name = string.Empty;
    }
    
    public Stats Modify(int art, int people, int technology)
    {
        Art += art;
        People += people;
        Technology += technology;

        Art = Math.Max(0, Art);
        People = Math.Max(0, People);
        Technology = Math.Max(0, Technology);

        return this;
    }

    public Dictionary<string, int> GetFinalModifiers() 
    {
        Normalize();

        return new Dictionary<string, int>
        {
            { "Art" , Art},
            { "People" , People},
            { "Technology" , Technology},
        };
    }

    private void Normalize()
    {
        int sum = Art + People + Technology;

        int artActual = Art;
        int peopleActual = People;
        int technologyActual = Technology;

        Art = GetPercentage(artActual, sum);
        People = GetPercentage(peopleActual, sum);
        Technology = GetPercentage(technologyActual, sum);
    }

    private static int GetPercentage(int actualNumber, int sum) => (int)((float)actualNumber / sum * 100);
}
