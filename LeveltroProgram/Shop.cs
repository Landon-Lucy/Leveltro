namespace Leveltro;
public static class ShopRunner
{
    // public static List<Mob> MobsOnSale;
    // public static List<Enchantment> EnchantmentsOnSale;
    // public static List<Spell> SpellsOnSale;

    public static void DisplayShop()
    {
        try { Console.Clear(); }
        catch { }

        Console.WriteLine("Welcome to the shop!");
        Console.WriteLine();
        Console.WriteLine($"Current Cash: {PlayerInfo.CurrentMoney}");
        Console.WriteLine();
        foreach (Mob mob in MobBoard.Mobs)
        {
            Console.Write($"{mob.MobName}  ");
        }

        Console.WriteLine();
        Console.WriteLine();

        foreach(Enchantment enchantment in EnchantmentBoard.Enchantments)
        {
            Console.Write($"{enchantment.Name}  ");
        }

        Console.WriteLine();
        Console.WriteLine();

        List<Mob> shopMobs = GenerateMobs();

        int numberIndicator = 1;
        string rarity = "";

        foreach (Mob mob in shopMobs)
        {
            if (mob.Rarity == 0)
                rarity = "Common";
            else if (mob.Rarity == 1)
                rarity = "Uncommon";
            else
                rarity = "Rare";


            Console.WriteLine($"{numberIndicator} ({rarity}) -- ${mob.MoneyCost}: {mob.MobName} - {mob.MobDescription} (Base Quantity: {mob.BaseQuantity} -  Base HP: {mob.BaseHP} -  Base XP per Unit: {mob.BaseXPPerUnit})");
            numberIndicator++;
        }

        Console.WriteLine();

        List<Enchantment> shopEnchantments = GenerateEnchantments();

        foreach (Enchantment enchantment in shopEnchantments)
        {
            if (enchantment.Rarity == 0)
                rarity = "Common";
            else if (enchantment.Rarity == 1)
                rarity = "Uncommon";
            else
                rarity = "Rare";

            Console.WriteLine($"{numberIndicator} ({rarity}) -- ${enchantment.MoneyCost}: {enchantment.Name} - {enchantment.EffectDescription}");
            numberIndicator++;
        }

        Console.WriteLine();

        List<Spell> shopSpells = GenerateSpells();

        foreach (Spell spell in shopSpells)
        {
            if (spell.Rarity == 0)
                rarity = "Common";
            else if (spell.Rarity == 1)
                rarity = "Uncommon";
            else
                rarity = "Rare";

            Console.WriteLine($"{numberIndicator} ({rarity}) -- ${spell.MoneyCost}: {spell.SpellName} - {spell.SpellDescription}");
            numberIndicator++;
        }
    }

    public static List<Mob> GenerateMobs()
    {
        List<Mob> returnList = new();
        int maxValue = int.MaxValue;
        Random random = new();



        for (int i = 0; i < 2; i++)
        {
            int rand = random.Next(maxValue);

            if (rand % 16 == 0)
            {
                int rareMobToChoose = rand % Generator.TotalRareMobs;

                int raresFound = 0;
                for (int j = 0; j < Generator.AllMobs.Count(); j++)
                {
                    if (Generator.AllMobs[j].Rarity == 2)
                    {
                        if (raresFound == rareMobToChoose)
                        {
                            returnList.Add(Generator.AllMobs[j]);
                            break;
                        }
                        else
                            raresFound++;
                    }
                }
            }
            else if (rand % 6 == 0)
            {
                int uncommonMobToChoose = rand % Generator.TotalUncommonMobs;

                int uncommonsFound = 0;
                for (int j = 0; j < Generator.AllMobs.Count(); j++)
                {
                    if (Generator.AllMobs[j].Rarity == 1)
                    {
                        if (uncommonsFound == uncommonMobToChoose)
                        {
                            returnList.Add(Generator.AllMobs[j]);
                            break;
                        }
                        else
                            uncommonsFound++;
                    }
                }
            }
            else
            {
                int commonMobToChoose = rand % Generator.TotalCommonMobs;

                int commonsFound = 0;
                for (int j = 0; j < Generator.AllMobs.Count(); j++)
                {
                    if (Generator.AllMobs[j].Rarity == 0)
                    {
                        if (commonsFound == commonMobToChoose)
                        {
                            returnList.Add(Generator.AllMobs[j]);
                            break;
                        }
                        else
                            commonsFound++;
                    }
                }
            }
        }
        return returnList;
    }


    public static List<Enchantment> GenerateEnchantments()
    {
        List<Enchantment> returnList = new();
        int maxValue = int.MaxValue;
        Random random = new();



        for (int i = 0; i < 2; i++)
        {
            int rand = random.Next(maxValue);

            if (rand % 16 == 0)
            {
                int rareEnchantmentToChoose = rand % Generator.TotalRareEnchantments;

                int raresFound = 0;
                for (int j = 0; j < Generator.AllEnchantments.Count(); j++)
                {
                    if (Generator.AllEnchantments[j].Rarity == 2)
                    {
                        if (raresFound == rareEnchantmentToChoose)
                        {
                            returnList.Add(Generator.AllEnchantments[j]);
                            break;
                        }
                        else
                            raresFound++;
                    }
                }
            }
            else if (rand % 6 == 0)
            {
                int uncommonEnchantmentToChoose = rand % Generator.TotalUncommonEnchantments;

                int uncommonsFound = 0;
                for (int j = 0; j < Generator.AllEnchantments.Count(); j++)
                {
                    if (Generator.AllEnchantments[j].Rarity == 1)
                    {
                        if (uncommonsFound == uncommonEnchantmentToChoose)
                        {
                            returnList.Add(Generator.AllEnchantments[j]);
                            break;
                        }
                        else
                            uncommonsFound++;
                    }
                }
            }
            else
            {
                int commonEnchantmentToChoose = rand % Generator.TotalCommonEnchantments;

                int commonsFound = 0;
                for (int j = 0; j < Generator.AllEnchantments.Count(); j++)
                {
                    if (Generator.AllEnchantments[j].Rarity == 0)
                    {
                        if (commonsFound == commonEnchantmentToChoose)
                        {
                            returnList.Add(Generator.AllEnchantments[j]);
                            break;
                        }
                        else
                            commonsFound++;
                    }
                }
            }
        }
        return returnList;
    }
    public static List<Spell> GenerateSpells()
    {
        List<Spell> returnList = new();
        int maxValue = int.MaxValue;
        Random random = new();



        for (int i = 0; i < 2; i++)
        {
            int rand = random.Next(maxValue);

            if (rand % 16 == 0)
            {
                int rareSpellToChoose = rand % Generator.TotalRareSpells;

                int raresFound = 0;
                for (int j = 0; j < Generator.AllSpells.Count(); j++)
                {
                    if (Generator.AllSpells[j].Rarity == 2)
                    {
                        if (raresFound == rareSpellToChoose)
                        {
                            returnList.Add(Generator.AllSpells[j]);
                            break;
                        }
                        else
                            raresFound++;
                    }
                }
            }
            else if (rand % 6 == 0)
            {
                int uncommonSpellToChoose = rand % Generator.TotalUncommonSpells;

                int uncommonsFound = 0;
                for (int j = 0; j < Generator.AllSpells.Count(); j++)
                {
                    if (Generator.AllSpells[j].Rarity == 1)
                    {
                        if (uncommonsFound == uncommonSpellToChoose)
                        {
                            returnList.Add(Generator.AllSpells[j]);
                            break;
                        }
                        else
                            uncommonsFound++;
                    }
                }
            }
            else
            {
                int commonSpellToChoose = rand % Generator.TotalCommonSpells;

                int commonsFound = 0;
                for (int j = 0; j < Generator.AllSpells.Count(); j++)
                {
                    if (Generator.AllSpells[j].Rarity == 0)
                    {
                        if (commonsFound == commonSpellToChoose)
                        {
                            returnList.Add(Generator.AllSpells[j]);
                            break;
                        }
                        else
                            commonsFound++;
                    }
                }
            }
        }
        return returnList;
    }
}