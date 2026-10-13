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

    public CreatureLevel Level { get; }
    
    public HealthPoints HealthPoints { get; }

    public AbilityScore Abilities { get; }
    

    /// <summary>Experience the party earns for defeating it.</summary>
    public int ExperienceReward { get; }

    private Creature(string name, 
        CreatureLevel level, 
        HealthPoints HealthPoints, 
        AbilityScore Abilities,
        int experienceReward)
    {
        Name = name;
        Level = level;
        this.HealthPoints = HealthPoints;
        this.Abilities = Abilities;
        ExperienceReward = experienceReward;
    }

    /// <summary>
    /// Builds a creature, or refuses to.  Every creature in the program comes
    /// through here.
    /// </summary>
    public static Creature Create(string name,
        int strength, int dexterity, int constitution,
        int intelligence, int wisdom, int charisma,
        int experienceReward)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("A creature needs a name.", nameof(name));

        var level = CreatureLevel.Level;

        var healthPoints =
            Toolkit.HealthPoints.Create(40);

        var creaturestats = AbilityScore.Create(
                                strength, dexterity,
                                constitution, wisdom,
                                level)
                            ?? AbilityScore.Create(20, 20,
                                20, 20,
                                20, 02);
        var reward = ExperienceReward.Default;
        

        return new Creature(name,
            level, healthPoints,
            creaturestats,
            experienceReward);
    }
}
