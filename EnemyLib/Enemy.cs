using OriginTablets.Types;

namespace EnemyLib
{
  /// <summary>
  /// Represents an enemy in Etrian Odyssey III R v2.
  /// </summary>
  public class Enemy
  {
    /// <summary>
    /// The enemy's index in the table. We use this for referencing, among other things, its name.
    /// </summary>
    private readonly int Index;

    /// <summary>
    /// The contents of enemynametable.tbl.
    /// </summary>
    private readonly Table EnemyNames;

    /// <summary>
    /// The enemy's name.
    /// </summary>
    public string Name => EnemyNames[Index];

    /// <summary>
    /// The enemy's level.
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// The amount of EXP the enemy gives when it is defeated.
    /// </summary>
    public int Experience { get; set; }

    /// <summary>
    /// The enemy's HP.
    /// </summary>
    public int HP { get; set; }

    /// <summary>
    /// The enemy's STR.
    /// </summary>
    public int STR { get; set; }

    /// <summary>
    /// The enemy's TEC.
    /// </summary>
    public int TEC { get; set; }

    /// <summary>
    /// The enemy's VIT.
    /// </summary>
    public int VIT { get; set; }

    /// <summary>
    /// The enemy's WIS.
    /// </summary>
    public int WIS { get; set; }

    /// <summary>
    /// The enemy's AGI.
    /// </summary>
    public int AGI { get; set; }

    /// <summary>
    /// The enemy's LUC.
    /// </summary>
    public int LUC { get; set; }

    /// <summary>
    /// What damage type the enemy uses when performing normal attacks.
    /// </summary>
    public DamageType DamageType { get; }

    /// <summary>
    /// The enemy's base accuracy when performing normal attacks.
    /// </summary>
    public int BaseAccuracy { get; }

    /// <summary>
    /// The drop in the enemy's first drop slot.
    /// </summary>
    public Drop FirstDrop { get; }

    /// <summary>
    /// The drop in the enemy's second drop slot.
    /// </summary>
    public Drop SecondDrop { get; }

    /// <summary>
    /// The enemy's conditional drop.
    /// </summary>
    public ConditionalDrop ConditionalDrop { get; }
  }

  /// <summary>
  /// Represents the different special flags an enemy can have.
  /// </summary>
  public class EnemyFlags
  {
    /// <summary>
    /// Is the enemy immune to having Execution instantly kill them?
    /// </summary>
    public bool ExecutionImmunity { get; set; }
  }

  /// <summary>
  /// An enemy's vulnerabilities to each damage type.
  /// </summary>
  public class DamageVulnerabilities
  {
    /// <summary>
    /// The enemy's vulnerability to cut damage.
    /// </summary>
    public int Cut { get; set; }

    /// <summary>
    /// The enemy's vulnerability to stab damage.
    /// </summary>
    public int Stab { get; set; }

    /// <summary>
    /// The enemy's vulnerability to bash damage.
    /// </summary>
    public int Bash { get; set; }

    /// <summary>
    /// The enemy's vulnerability to fire damage.
    /// </summary>
    public int Fire { get; set; }

    /// <summary>
    /// The enemy's vulnerability to ice damage.
    /// </summary>
    public int Ice { get; set; }

    /// <summary>
    /// The enemy's vulnerability to volt damage.
    /// </summary>
    public int Volt { get; set; }

    /// <summary>
    /// The enemy's vulnerability to almighty damage.
    /// </summary>
    public int Almighty { get; set; }

    /// <summary>
    /// For serialization.
    /// </summary>
    public DamageVulnerabilities() { }
  }

  /// <summary>
  /// An enemy's vulnerabilities to the various disables.
  /// </summary>
  public class DisableVulnerabilities
  {
    /// <summary>
    /// The enemy's vulnerability to being inflicted with blind.
    /// </summary>
    public int Blind { get; set; }

    /// <summary>
    /// The enemy's vulnerability to being inflicted with paralysis.
    /// </summary>
    public int Paralysis { get; set; }

    /// <summary>
    /// The enemy's vulnerability to being inflicted with berserk.
    /// </summary>
    public int Berserk { get; set; }

    /// <summary>
    /// The enemy's vulnerability to being inflicted with plague.
    /// </summary>
    public int Plague { get; set; }

    /// <summary>
    /// The enemy's vulnerability to being inflicted with sleep.
    /// </summary>
    public int Sleep { get; set; }

    /// <summary>
    /// The enemy's vulnerability to being inflicted with poison.
    /// </summary>
    public int Poison { get; set; }

    /// <summary>
    /// The enemy's vulnerability to being inflicted with curse.
    /// </summary>
    public int Curse { get; set; }

    /// <summary>
    /// The enemy's vulnerability to being inflicted with petrification.
    /// </summary>
    public int Petrification { get; set; }

    private int _InstantDeath;

    /// <summary>
    /// The enemy's vulnerability to being instantly killed.
    /// </summary>
    public int InstantDeath
    {
      get => _InstantDeath;
      set
      {
        // If the enemy has lethal resistance, just set it to 0%.
        if (value > 300) { _InstantDeath = 0; }
        else { _InstantDeath = value; }
      }
    }

    /// <summary>
    /// The enemy's vulnerability to being stunned.
    /// </summary>
    public int Stunned { get; set; }

    /// <summary>
    /// The enemy's vulnerability to having their head bound.
    /// </summary>
    public int HeadBind { get; set; }

    /// <summary>
    /// The enemy's vulnerability to having their arms bound.
    /// </summary>
    public int ArmBind { get; set; }

    /// <summary>
    /// The enemy's vulnerability to having their legs bound.
    /// </summary>
    public int LegBind { get; set; }

    /// <summary>
    /// For serialization.
    /// </summary>
    public DisableVulnerabilities() { }
  }

  /// <summary>
  /// A use item that the enemy can drop.
  /// </summary>
  public class Drop : UseItem
  {
    /// <summary>
    /// The chance for the item to drop when the enemy is killed.
    /// </summary>
    public int Chance { get; set; }

    public Drop(Table names, int index) : base(names, index)
    {
    }
  }

  /// <summary>
  /// A drop that requires a condition to be fulfilled before it can drop.
  /// </summary>
  public class ConditionalDrop : Drop
  {
    /// <summary>
    /// The condition that must be fulfilled to trigger the conditional drop.
    /// </summary>
    public ConditionalDropFlags Condition { get; set; }

    public ConditionalDrop(Table names, int index) : base(names, index)
    {
    }
  }

  /// <summary>
  /// Different types of conditions for conditional drops.
  /// </summary>
  public enum ConditionalDropFlags
  {
    /// <summary>
    /// The enemy must be killed by an attack whose damage type includes cut.
    /// </summary>
    CutDamage = 0x08,

    /// <summary>
    /// The enemy must be killed by an attack whose damage type includes stab.
    /// </summary>
    StabDamage = 0x0A,

    /// <summary>
    /// The enemy must be killed by an attack whose damage type includes bash.
    /// </summary>
    BashDamage = 0x0C,

    /// <summary>
    /// The enemy must be killed by an attack whose damage type includes fire.
    /// </summary>
    FireDamage = 0x0E,

    /// <summary>
    /// The enemy must be killed by an attack whose damage type includes ice.
    /// </summary>
    IceDamage = 0x10,

    /// <summary>
    /// The enemy must be killed by an attack whose damage type includes volt.
    /// </summary>
    VoltDamage = 0x12,

    /// <summary>
    /// The enemy must be killed by poison damage.
    /// </summary>
    PoisonDamage = 0x16,

    /// <summary>
    /// The enemy must be killed while they are afflicted with paralysis.
    /// </summary>
    Paralyzed = 0x18,

    /// <summary>
    /// The enemy must be killed while they are afflicted with blindness.
    /// </summary>
    Blind = 0x1A,

    /// <summary>
    /// The enemy must be killed while they are afflicted with berserk.
    /// </summary>
    Berserk = 0x1C,

    /// <summary>
    /// The enemy must be killed by backlash damage from curse. (UNUSED IN EO3Rv2.)
    /// </summary>
    CurseDamage = 0x20,

    /// <summary>
    /// The enemy must be killed while they are afflicted with sleep.
    /// </summary>
    Sleeping = 0x22,

    /// <summary>
    /// The enemy must be killed while they are afflicted with petrification.
    /// </summary>
    Petrified = 0x26,

    /// <summary>
    /// The enemy must be instantly killed.
    /// </summary>
    InstantDeath = 0x28,

    /// <summary>
    /// The enemy must be killed while their head is bound.
    /// </summary>
    HeadBound = 0x2A,

    /// <summary>
    /// The enemy must be killed while their arms are bound.
    /// </summary>
    ArmBound = 0x2C,

    /// <summary>
    /// The enemy must be killed while their legs are bound.
    /// </summary>
    LegBound = 0x2E,

    /// <summary>
    /// The enemy must be killed while their head, arms, and legs are bound.
    /// </summary>
    FullyBound = 0x30,

    /// <summary>
    /// The enemy must be killed on the first turn.
    /// </summary>
    FirstTurn = 0x32,

    /// <summary>
    /// The enemy must be killed with an attack whose damage type includes cut, stab, or bash.
    /// </summary>
    PhysicalDamage = 0x50,

    /// <summary>
    /// The enemy must be killed with an attack whose damage type includes fire, ice, or volt.
    /// </summary>
    ElementalDamage = 0x52,
  }
}