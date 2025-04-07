namespace Leveltro;

public class Mob
{
    readonly string Type;
    readonly string MobName;
    readonly int BaseXPPerUnit;
    readonly int BaseQuantity;
    readonly int BaseHP;
    readonly int MoneyCost;
    readonly string MobDescription;

    public Mob(string type, string mobName, int baseXPPerUnit, int baseQuantity, int baseHP, int moneyCost, string mobDescription)
    {
        Type = type;
        MobName = mobName;
        BaseXPPerUnit = baseXPPerUnit;
        BaseQuantity = baseQuantity;
        BaseHP = baseHP;
        MoneyCost = moneyCost;
        MobDescription = mobDescription;
    }

    public (int quantity, int xpPerUnit) CalcTotals(EnchantmentBoard enchBoard)
    {
        return (-1, -1);
    }

    public void OnDeath(int TotalXP)
    {

    }
}

public class MobBoard
{
 public List<Mob> Mobs;
 public int TotalMobs => Mobs.Count;
 public int CurrentMobMax;

  public MobBoard()
  {
    Mobs = new();
    CurrentMobMax = 5;
  }

  public void AddMob(Mob mob)
  {

  }

  public void SwapMobPositions(int mobSlot1, int mobSlot2)
  {

  }
}