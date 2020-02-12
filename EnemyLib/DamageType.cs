namespace EnemyLib
{
  /// <summary>
  /// Represents a weapon's damage type.
  /// </summary>
  public class DamageType
  {
    /// <summary>
    /// Does the weapon not have a damage type? This is true if none of the proper damage types are
    /// set. Untyped attacks are not reduced by any damage vulnerabilities, but cannot benefit from
    /// buffs either.
    /// </summary>
    public bool Untyped
    {
      get
      {
        return Cut == false
          && Bash == false
          && Stab == false
          && Fire == false
          && Ice == false
          && Volt == false
          && Almighty == false;
      }
    }

    /// <summary>
    /// Does the weapon deal cut damage?
    /// </summary>
    public bool Cut { get; set; }

    /// <summary>
    /// Does the weapon deal bash damage?
    /// </summary>
    public bool Bash { get; set; }

    /// <summary>
    /// Does the weapon deal stab damage?
    /// </summary>
    public bool Stab { get; set; }

    /// <summary>
    /// Does the weapon deal fire damage?
    /// </summary>
    public bool Fire { get; set; }

    /// <summary>
    /// Does the weapon deal ice damage?
    /// </summary>
    public bool Ice { get; set; }

    /// <summary>
    /// Does the weapon deal volt damage?
    /// </summary>
    public bool Volt { get; set; }

    /// <summary>
    /// Does the weapon deal almighty damage?
    /// </summary>
    public bool Almighty { get; set; }

    /// <summary>
    /// This isn't a proper damage type; rather, it's a flag that's used for HP Cannon in the
    /// vanilla game. Specifically, what it does is remove the penalty for melee attacks used from
    /// the back row, ignore the penalty to STR that arm binds incur, and make the attack not
    /// benefit from the damage bonus that attacking asleep targets gives.
    /// </summary>
    public bool NoPenalty { get; set; }

    /// <summary>
    /// The bitfield representation of a damage type.
    /// </summary>
    public ushort Bitfield
    {
      get
      {
        int result = 0;
        result += Cut == true ? 1 : 0;
        result += Bash == true ? 2 : 0;
        result += Stab == true ? 4 : 0;
        result += Fire == true ? 8 : 0;
        result += Ice == true ? 16 : 0;
        result += Volt == true ? 32 : 0;
        result += Almighty == true ? 64 : 0;
        result += NoPenalty == true ? 128 : 0;
        return (ushort)result;
      }
    }
  }
}