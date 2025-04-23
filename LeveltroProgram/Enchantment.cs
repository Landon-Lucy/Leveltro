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
    public bool StartOfTurn;
    public bool EndOfTurn;
    public Action Effect;

    public Enchantment(string name, string effectDescription, int moneyCost, bool affectsSpells, bool affectsMobs, bool affectsScore, bool givesMoney, bool startOfCombat, bool startOfTurn, bool endOfTurn, int rarity, Action effect)
    {
        Name = name;
        EffectDescription = effectDescription;
        MoneyCost = moneyCost;
        AffectsSpells = affectsSpells;
        AffectsMobs = affectsMobs;
        AffectsScore = affectsScore;
        GivesMoney = givesMoney;
        StartOfCombat = startOfCombat;
        StartOfTurn = startOfTurn;
        EndOfTurn = endOfTurn;
        Rarity = rarity;
        Effect = effect;
    }
}

public static class EnchantmentBoard
{
    public static List<Enchantment> Enchantments = new();
    public static int TotalEnchantments => Enchantments.Count;
    public static int CurrentEnchantmentMax = 5;


    public static void AddEnchantment(Enchantment enchantment)
    {
        EnchantmentBoard.Enchantments.Add(enchantment);
    }

    public static void SwapEnchantmentPositions(int enchantmentSlot1, int enchantmentSlot2)
    {

    }
}