namespace AI_Lab2;

public class Stats
{
    private float Art { get; set; }
    private float People { get; set; }
    private float Technology { get; set; }

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

    public Dictionary<string, float> GetFinalModifiers() 
    {
        Normalize();

        return new Dictionary<string, float>
        {
            { "Art" , Art},
            { "People" , People},
            { "Technology" , Technology},
        };
    }

    private void Normalize()
    {
        float sum = Art + People + Technology;

        float artActual = Art;
        float peopleActual = People;
        float technologyActual = Technology;

        Art = GetPercentage(artActual, sum);
        People = GetPercentage(peopleActual, sum);
        Technology = GetPercentage(technologyActual, sum);
    }

    private static float GetPercentage(float actualNumber, float sum) => (actualNumber / sum * 100);
}
