namespace Leveltro;
public static class ShopRunner
{
    // public static List<Mob> MobsOnSale;
    // public static List<Enchantment> EnchantmentsOnSale;
    // public static List<Spell> SpellsOnSale;

    public static List<int> shopSlotsPurchased = new();
    public static List<Mob> shopMobs = new();
    public static List<Enchantment> shopEnchantments = new();
    public static List<Spell> shopSpells = new();

    public static void GenerateShop()
    {
        shopMobs = GenerateMobs();
        shopEnchantments = GenerateEnchantments();
        shopSpells = GenerateSpells();

        DisplayShop();
    }

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

        foreach (Enchantment enchantment in EnchantmentBoard.Enchantments)
        {
            Console.Write($"{enchantment.Name}  ");
        }

        Console.WriteLine();
        Console.WriteLine();

        int numberIndicator = 1;
        string rarity = "";

        foreach (Mob mob in shopMobs)
        {
            if (shopSlotsPurchased.Contains(numberIndicator))
            {
                Console.WriteLine($"{numberIndicator} - PURCHASED");
                numberIndicator++;
                continue;
            }
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


        foreach (Enchantment enchantment in shopEnchantments)
        {
            if (shopSlotsPurchased.Contains(numberIndicator))
            {
                Console.WriteLine($"{numberIndicator} - PURCHASED");
                numberIndicator++;
                continue;
            }
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


        foreach (Spell spell in shopSpells)
        {
            if (shopSlotsPurchased.Contains(numberIndicator))
            {
                Console.WriteLine($"{numberIndicator} - PURCHASED");
                numberIndicator++;
                continue;
            }
            if (spell.Rarity == 0)
                rarity = "Common";
            else if (spell.Rarity == 1)
                rarity = "Uncommon";
            else
                rarity = "Rare";

            Console.WriteLine($"{numberIndicator} ({rarity}) -- ${spell.MoneyCost}: {spell.SpellName} - {spell.SpellDescription}");
            numberIndicator++;
        }

        playerPurchaseStep(numberIndicator - 1, shopMobs, shopEnchantments, shopSpells);
    }

    public static void playerPurchaseStep(int shopSize, List<Mob> shopMobs, List<Enchantment> shopEnchantments, List<Spell> shopSpells)
    {
        bool validChoice = false;
        int playerChoice = -1;
        while (!validChoice)
        {
            ConsoleKeyInfo playerChoiceObj = new();
            char playerChoiceChar;
            try
            {
                playerChoiceObj = Console.ReadKey(true);
                playerChoiceChar = playerChoiceObj.KeyChar;
            }
            catch { playerChoiceChar = '0'; }
            string playerChoiceString = playerChoiceChar.ToString();

            try
            {
                playerChoice = Convert.ToInt32(playerChoiceString);
                if (playerChoice == 0)
                {
                    validChoice = true;
                    break;
                }
                if (playerChoice > 0 && playerChoice <= shopSize)
                {
                    if (playerChoice == 0)
                    {
                        validChoice = true;
                        break;
                    }
                    else
                    {
                        if (playerChoice <= shopMobs.Count())
                        {
                            if (PlayerInfo.CurrentMoney >= shopMobs[playerChoice - 1].MoneyCost && MobBoard.Mobs.Count() < MobBoard.CurrentMobMax)
                            {
                                validChoice = true;
                                break;
                            }
                        }
                        else if (playerChoice <= shopMobs.Count() + shopEnchantments.Count())
                        {
                            if (PlayerInfo.CurrentMoney >= shopEnchantments[playerChoice - shopMobs.Count() - 1].MoneyCost && EnchantmentBoard.Enchantments.Count() < EnchantmentBoard.CurrentEnchantmentMax)
                            {
                                validChoice = true;
                                break;
                            }
                        }
                        else
                        {
                            if (PlayerInfo.CurrentMoney >= shopSpells[playerChoice - shopMobs.Count() - shopEnchantments.Count() - 1].MoneyCost)
                            {
                                validChoice = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch { continue; }
        }

        if (playerChoice == 0)
        {
            shopSlotsPurchased = new();
            return;
        }
        else
        {
            if (playerChoice <= shopMobs.Count())
            {
                PlayerInfo.CurrentMoney -= shopMobs[playerChoice - 1].MoneyCost;
                MobBoard.AddMob(shopMobs[playerChoice - 1]);
                shopSlotsPurchased.Add(playerChoice);
            }
            else if (playerChoice <= shopMobs.Count() + shopEnchantments.Count())
            {
                PlayerInfo.CurrentMoney -= shopEnchantments[playerChoice - shopMobs.Count() - 1].MoneyCost;
                EnchantmentBoard.AddEnchantment(shopEnchantments[playerChoice - shopMobs.Count() - 1]);
                shopSlotsPurchased.Add(playerChoice);
            }
            else
            {
                PlayerInfo.CurrentMoney -= shopSpells[playerChoice - shopMobs.Count() - shopEnchantments.Count() - 1].MoneyCost;
                Deck.AddSpell(shopSpells[playerChoice - shopMobs.Count() - shopEnchantments.Count() - 1]);
                shopSlotsPurchased.Add(playerChoice);
            }
            DisplayShop();
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