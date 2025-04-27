namespace Leveltro;

public static class Generator
{
    public static List<Mob> AllMobs = new();
    public static List<Enchantment> AllEnchantments = new();
    public static List<Spell> AllSpells = new();
    public static int TotalCommonMobs;
    public static int TotalUncommonMobs;
    public static int TotalRareMobs;
    public static int TotalCommonEnchantments;
    public static int TotalUncommonEnchantments;
    public static int TotalRareEnchantments;
    public static int TotalCommonSpells;
    public static int TotalUncommonSpells;
    public static int TotalRareSpells;

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
            // deck?.Add(AllSpells[1]);
        }
        Deck.FullDeck = deck;
    }

    public static void BuildInitialMobAndEnchant()
    {
        MobBoard.AddMob(AllMobs[0]);
        MobBoard.AddMob(AllMobs[0]);
        // MobBoard.AddMob(AllMobs[0]);
        EnchantmentBoard.AddEnchantment(AllEnchantments[0]);
        // EnchantmentBoard.AddEnchantment(AllEnchantments[1]);
    }

    public static void CreateAllMobs()
    {
        AllMobs.Add(new Mob("Basic", "Slime", 5, 1, 5, 1, "The most basic of all monsters, the humble slime.", 0));
        AllMobs.Add(new Mob("Basic", "Bat Swarm", 3, 5, 5, 4, "A swarm of annoying bats.", 1));
        AllMobs.Add(new Mob("Basic", "Troll", 30, 1, 15, 6, "A massive, lumbering troll. Tough and dumb as dirt.", 2));


        TotalCommonMobs = CountCommonMobs();
        TotalUncommonMobs = CountUncommonMobs();
        TotalRareMobs = CountRareMobs();
    }


    public static void CreateAllEnchantments()
    {
        AllEnchantments.Add(new Enchantment("Ambient Absorbtion", "[+5 XP] at the end of your turn.", 1, false, false, true, false, false, false, true, 0, () => CombatRunner.CurrentScore += 5));
        AllEnchantments.Add(new Enchantment("Bolstering Backline", "Start of Combat: [+5 Permanent Quantity] and [+2 Permanent HP] to furthest right enemy", 5, false, true, false, false, true, false, false, 1, () =>
        {
            Mob mobToChange = MobBoard.Mobs[MobBoard.Mobs.Count() - 1];
            mobToChange.BaseQuantity += 5;
            mobToChange.BaseHP += 2;
        }
        ));
        AllEnchantments.Add(new Enchantment("XP Xealotry", "[+5 XP per Unit] to all enemies", 8, false, true, false, false, false, true, false, 2, () => 
        {
            foreach(Mob mob in MobBoard.Mobs)
            {
                mob.BaseXPPerUnit += 5;
            }
        }));

        TotalCommonEnchantments = CountCommonEnchantments();
        TotalUncommonEnchantments = CountUncommonEnchantments();
        TotalRareEnchantments = CountRareEnchantments();
    }


    public static void CreateAllSpells()
    {
        AllSpells.Add(new Spell("Spark", 5, "Deals [5 Damage] to the front monster", false, 1, 1, -1, null));
        AllSpells.Add(new Spell("Flare", 10, "Deals [10 Damage] to the front enemy", false, 2, 1, 0, null));
        AllSpells.Add(new Spell("Firestorm", 7, "Deals [7 Damage] to all enemies", true, 6, 2, 1, null));
        AllSpells.Add(new Spell("Gold Rush", 5, "Deals [5 Damage] to the front enemy, then [Gain 2 Gold]", false, 10, 1, 2, () => { PlayerInfo.CurrentMoney += 2; }));

        TotalCommonSpells = CountCommonSpells();
        TotalUncommonSpells = CountUncommonSpells();
        TotalRareSpells = CountRareSpells();
    }


    //All Counting Methods
    public static int CountCommonMobs()
    {
        int returnInt = 0;
        foreach (Mob mob in AllMobs)
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
        foreach (Mob mob in AllMobs)
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
        foreach (Mob mob in AllMobs)
        {
            if (mob.Rarity == 2)
            {
                returnInt++;
            }
        }
        return returnInt;
    }
    public static int CountCommonEnchantments()
    {
        int returnInt = 0;
        foreach (Enchantment enchantment in AllEnchantments)
        {
            if (enchantment.Rarity == 0)
            {
                returnInt++;
            }
        }
        return returnInt;
    }
    public static int CountUncommonEnchantments()
    {
        int returnInt = 0;
        foreach (Enchantment enchantment in AllEnchantments)
        {
            if (enchantment.Rarity == 1)
            {
                returnInt++;
            }
        }
        return returnInt;
    }
    public static int CountRareEnchantments()
    {
        int returnInt = 0;
        foreach (Enchantment enchantment in AllEnchantments)
        {
            if (enchantment.Rarity == 2)
            {
                returnInt++;
            }
        }
        return returnInt;
    }
    public static int CountCommonSpells()
    {
        int returnInt = 0;
        foreach (Spell spell in AllSpells)
        {
            if (spell.Rarity == 0)
            {
                returnInt++;
            }
        }
        return returnInt;
    }
    public static int CountUncommonSpells()
    {
        int returnInt = 0;
        foreach (Spell spell in AllSpells)
        {
            if (spell.Rarity == 1)
            {
                returnInt++;
            }
        }
        return returnInt;
    }
    public static int CountRareSpells()
    {
        int returnInt = 0;
        foreach (Spell spell in AllSpells)
        {
            if (spell.Rarity == 2)
            {
                returnInt++;
            }
        }
        return returnInt;
    }
}