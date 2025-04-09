namespace Leveltro;

public class Enchantment
{
    public string Name;
    public string EffectDescription;
    public int MoneyCost;
    public bool AffectsSpells;
    public bool AffectsMobs;
    public bool AffectsScore;
    public bool GivesMoney;
    public int Rarity;
    public bool StartOfCombat;

    public Enchantment(string name, string effectDescription, int moneyCost, bool affectsSpells, bool affectsMobs, bool affectsScore, bool givesMoney, bool startOfCombat, int rarity)
    {
        Name = name;
        EffectDescription = effectDescription;
        MoneyCost = moneyCost;
        AffectsSpells = affectsSpells;
        AffectsMobs = affectsMobs;
        AffectsScore = affectsScore;
        GivesMoney = givesMoney;
        StartOfCombat = startOfCombat;
        Rarity = rarity;
    }
}

public static class EnchantmentBoard
{
    public static List<Enchantment> Enchantments;
    public static int TotalEnchantments => Enchantments.Count;
    public static int CurrentEnchantmentMax = 5;


    public static void AddEnchantment(Mob mob)
    {

    }

    public static void SwapEnchantmentPositions(int mobSlot1, int mobSlot2)
    {

    }
}