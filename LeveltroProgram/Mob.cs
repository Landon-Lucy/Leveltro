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
    readonly int Rarity;

    public Mob(string type, string mobName, int baseXPPerUnit, int baseQuantity, int baseHP, int moneyCost, string mobDescription, int rarity)
    {
        Type = type;
        MobName = mobName;
        BaseXPPerUnit = baseXPPerUnit;
        BaseQuantity = baseQuantity;
        BaseHP = baseHP;
        MoneyCost = moneyCost;
        MobDescription = mobDescription;
        Rarity = rarity;
    }

    public (int quantity, int xpPerUnit) CalcTotals()
    {
        return (-1, -1);
    }

    public void OnDeath(int TotalXP)
    {

    }
}

public static class MobBoard
{
 public static List<Mob> Mobs = new();
 public static int TotalMobs => Mobs.Count;
 public static int CurrentMobMax = 5;


  public static void AddMob(Mob mob)
  {

  }

  public static void SwapMobPositions(int mobSlot1, int mobSlot2)
  {

  }
}