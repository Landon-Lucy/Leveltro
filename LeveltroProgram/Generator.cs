namespace Leveltro;

public static class Generator
{
    public static List<Mob> AllMobs;
    public static List<Enchantment> AllEnchantments;
    public static List<Spell> AllSpells;

    public static void CreateAll()
    {
        CreateAllMobs();
        CreateAllEnchantments();
        CreateAllSpells();
    }
    public static List<Spell> BuildInitialDeck()
    {
        List<Spell> deck = new();
        for (int i = 0; i < 10; i++)
        {
            deck.Add(AllSpells[0]);
        }
        return deck;
    }

    public static void CreateAllMobs()
    {
        AllMobs.Add(new Mob("Basic", "Slime", 5, 1, 5, 1, "The most basic of all monsters, the humble slime", 0));
    }

    public static void CreateAllEnchantments()
    {
        AllEnchantments.Add(new Enchantment("Ambient Absorbtion", "A simple enchantment that grants you [+5 XP] at the end of your turn.", 1, false, false, true, false, false, 0));
    }

    public static void CreateAllSpells()
    {
        AllSpells.Add(new Spell("Spark", 5, "Deals [5 Damage] to the front monster", false, 1, 1, -1));
    }
}