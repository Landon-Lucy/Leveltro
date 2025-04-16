namespace Leveltro;

public static class Generator
{
    public static List<Mob> AllMobs = new();
    public static List<Enchantment> AllEnchantments = new();
    public static List<Spell> AllSpells = new();
    public static int TotalCommonMobs;
    public static int TotalUncommonMobs;
    public static int TotalRareMobs;

    public static void CreateAll()
    {
        CreateAllMobs();
        CreateAllEnchantments();
        CreateAllSpells();
    }
    public static void BuildInitialDeck()
    {
        List<Spell> deck = new();
        for (int i = 0; i < 10; i++)
        {
            deck?.Add(AllSpells[0]);
        }
        Deck.FullDeck = deck;
    }

    public static void BuildInitialMobAndEnchant()
    {
        MobBoard.Mobs.Add(AllMobs[0]);
        MobBoard.Mobs.Add(AllMobs[0]);
        EnchantmentBoard.Enchantments.Add(AllEnchantments[0]);
    }

    public static void CreateAllMobs()
    {
        AllMobs.Add(new Mob("Basic", "Slime", 5, 1, 5, 1, "The most basic of all monsters, the humble slime", 0));
        AllMobs.Add(new Mob("Basic", "Bat Swarm", 3, 5, 5, 4, "A swarm of annoying bats", 1));
        AllMobs.Add(new Mob("Basic", "Troll", 30, 1, 15, 6, "A massive, lumbering troll. Tough and dumb as dirt.", 2));


        TotalCommonMobs = CountCommonMobs();
        TotalUncommonMobs = CountUncommonMobs();
        TotalRareMobs = CountRareMobs();
    }

    public static int CountCommonMobs()
    {
        int returnInt = 0;
        foreach(Mob mob in AllMobs)
        {
            if (mob.Rarity == 0)
            {
                returnInt++;
            }
        }
        return returnInt;
    }
    public static int CountUncommonMobs()
    {
        int returnInt = 0;
        foreach(Mob mob in AllMobs)
        {
            if (mob.Rarity == 1)
            {
                returnInt++;
            }
        }
        return returnInt;
    }
    public static int CountRareMobs()
    {
        int returnInt = 0;
        foreach(Mob mob in AllMobs)
        {
            if (mob.Rarity == 2)
            {
                returnInt++;
            }
        }
        return returnInt;
    }

    public static void CreateAllEnchantments()
    {
        AllEnchantments.Add(new Enchantment("Ambient Absorbtion", "[+5 XP] at the end of your turn.", 1, false, false, true, false, false, false, true, 0, () => CombatRunner.CurrentScore += 5));
    }

    public static void CreateAllSpells()
    {
        AllSpells.Add(new Spell("Spark", 5, "Deals [5 Damage] to the front monster", false, 1, 1, -1, null));
    }
}