using OriginTablets.Types;

namespace EnemyLib
{
  /// <summary>
  /// Represents items in useitemtable, which are used for enemy drops.
  /// </summary>
  public class UseItem
  {
    /// <summary>
    /// The useitemnametable.tbl object.
    /// </summary>
    private readonly Table Names;

    /// <summary>
    /// The item's position in useitemtable.tbl.
    /// </summary>
    private readonly int Index = 0;

    /// <summary>
    /// The item's name.
    /// </summary>
    public string Name => Names[Index];

    public UseItem(Table names, int index)
    {
      Names = names;
      Index = index;
    }
  }
}