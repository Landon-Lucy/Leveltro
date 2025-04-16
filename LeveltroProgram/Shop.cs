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
                    if (Generator.AllMobs[i].Rarity == 2)
                    {
                        if (raresFound == rareMobToChoose)
                        {
                            returnList.Add(Generator.AllMobs[i]);
                            break;
                        }
                        else
                            raresFound++;
                    }
                }
            }
            else if (rand % 6 == 0)
            {

            }
            else
            {

            }
        }
        return new();
    }
    public static List<Enchantment> GenerateEnchantments()
    {
        return new();
    }
    public static List<Spell> GenerateSpells()
    {
        return new();
    }
}