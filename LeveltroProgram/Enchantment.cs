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
        Enchantments.Add(new Enchantment(enchantment.Name, enchantment.EffectDescription, enchantment.MoneyCost, enchantment.AffectsSpells, enchantment.AffectsMobs, enchantment.AffectsScore, enchantment.GivesMoney, enchantment.StartOfCombat, enchantment.StartOfTurn, enchantment.EndOfTurn, enchantment.Rarity, enchantment.Effect));
    }

    public static void SwapEnchantmentPositions(int enchantmentSlot1, int enchantmentSlot2)
    {
        Enchantment tempEnchantment = Enchantments[enchantmentSlot1];
        Enchantments[enchantmentSlot1] = Enchantments[enchantmentSlot2];
        Enchantments[enchantmentSlot2] = tempEnchantment;
    }

    public static void SellEnchantment(int enchantmentSlot)
    {
        PlayerInfo.CurrentMoney += (Enchantments[enchantmentSlot].MoneyCost + 1) / 2;
        Enchantments.RemoveAt(enchantmentSlot);
    }
}