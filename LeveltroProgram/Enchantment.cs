namespace Leveltro;

public class Enchantment
{
    readonly string Name;
    readonly string EffectDescription;
    readonly int MoneyCost;
    readonly bool AffectsSpells;
    readonly bool AffectsMobs;
    readonly bool AffectsScore;
    readonly bool GivesMoney;

    public Enchantment(string name, string effectDescription, int moneyCost, bool affectsSpells, bool affectsMobs, bool affectsScore, bool givesMoney)
    {
        Name = name;
        EffectDescription = effectDescription;
        MoneyCost = moneyCost;
        AffectsSpells = affectsSpells;
        AffectsMobs = affectsMobs;
        AffectsScore = affectsScore;
        GivesMoney = givesMoney;
    }
}

public class EnchantmentBoard
{
 public List<Enchantment> Enchantments;
 public int TotalEnchantments => Enchantments.Count;
 public int CurrentEnchantmentMax;

  public EnchantmentBoard()
  {
    Enchantments = new();
    CurrentEnchantmentMax = 5;
  }

  public void AddEnchantment(Mob mob)
  {

  }

  public void SwapEnchantmentPositions(int mobSlot1, int mobSlot2)
  {

  }
}