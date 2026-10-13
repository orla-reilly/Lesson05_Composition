namespace Toolkit;

public record PlayerLevel
{
    public static PlayerLevel Level1 = new(0);
    public int Experience { get; }

    /// <summary>
    /// TODO: Calculate this in a future lesson
    /// </summary>
    public int Level { get; }

    private PlayerLevel(int Experience)
    {
        this.Experience = Experience;
        //TODO THIS OS BAD
        this.Level = 1 + Experience / 100;
    }
}