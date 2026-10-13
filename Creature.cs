namespace Toolkit;

/// <summary>
/// Anything the players fight.  A goblin, a wolf, a dragon.
///
/// Same rules as <see cref="Player"/>:  a private constructor, and one door in
/// that checks every number.
/// </summary>
public record Creature
{
    public string Name { get; }
    
    public HealthPoints HealthPoints { get; }

    public AbilityScore Abilities { get; }
    

    /// <summary>Experience the party earns for defeating it.</summary>
    public int ExperienceReward { get; }

    private Creature(string name, 
        HealthPoints healthPoints, 
        AbilityScore abilityScore,
        int experienceReward)
    {
        Name = name; 
        this.HealthPoints = HealthPoints;
        this.Abilities = Abilities;
        ExperienceReward = experienceReward;
    }

    /// <summary>
    /// Builds a creature, or refuses to.  Every creature in the program comes
    /// through here.
    /// </summary>
    public static Creature Create(string name, int currentHealth, int maxHealth,
        int strength, int dexterity, int constitution,
        int intelligence, int wisdom, int charisma,
        int experienceReward)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("A creature needs a name.", nameof(name));
        

        var healthPoints =
            Toolkit.HealthPoints.Create(maxHealth);
        

        var creaturestats = AbilityScore.Create(
                                strength, dexterity,
                                constitution, intelligence, wisdom, charisma)
                            ?? AbilityScore.Create(10, 10,
                                10, 10,
                                10, 1);
        if (experienceReward <= 0)
            throw new ArgumentException("Experience reward must be positive.", 
                nameof(experienceReward));
        

        return new Creature(name, healthPoints,
            creaturestats,
            experienceReward);
    }
}
