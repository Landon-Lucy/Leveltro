namespace Leveltro;

public static class CombatRunner
{
    public static int CurrentMana = 0;
    public static int CurrentScore = 0;
    public static int TotalTurns = 3;
    public static int[] damageToEachSlot = [0, 0, 0, 0, 0];
    public static void StartCombat(int maxMana, int scoreBenchmark, int handSize = 5)
    {
        Deck.CurrentDeck = new List<Spell>(Deck.FullDeck);

        for (int i = 0; i < handSize; i++)
        {
            Deck.Draw();
            CurrentMana = maxMana;
        }

        foreach (Enchantment enchantment in EnchantmentBoard.Enchantments)
        {
            if (enchantment.StartOfCombat == true)
            {
                enchantment.Effect();
            }
        }

        UpdateScreen(scoreBenchmark, maxMana);
    }


    public static void PlayerTurn()
    {
        foreach(Enchantment enchantment in EnchantmentBoard.Enchantments)
        {
            if (enchantment.StartOfTurn == true)
            {
                enchantment.Effect();
            }
        }
    }

    public static void UpdateScreen(int scoreBenchmark, int maxMana)
    {
        Console.Clear();
        Console.WriteLine($"XP: {CurrentScore} / {scoreBenchmark}");
        Console.WriteLine($"Mana: {CurrentMana} / {maxMana}");
        Console.WriteLine();

        foreach (Enchantment enchantment in EnchantmentBoard.Enchantments)
        {
            Console.WriteLine($"{enchantment.Name}: {enchantment.EffectDescription}");
        }

        Console.WriteLine();
        Console.Write($"@   ");

        int slot = 0;
        foreach (Mob mob in MobBoard.Mobs)
        {
            if (mob.BaseHP - damageToEachSlot[slot] > 0)
                Console.Write($"{mob.MobName}(HP: {mob.BaseHP - damageToEachSlot[slot]}/{mob.BaseHP} #: {mob.BaseQuantity} XP: {mob.BaseXPPerUnit * mob.BaseQuantity})");

            slot++;
        }

        Console.WriteLine();
        Console.WriteLine();

        int cardPosition = 1;
        foreach (Spell card in Deck.CurrentHand)
        {
            Console.WriteLine($"{cardPosition}: {card.SpellName} ({card.ManaCost} Mana) - {card.SpellDescription}");
            cardPosition++;
        }
        Console.WriteLine("0: End Turn");

        Console.WriteLine();
        Console.WriteLine($"Deck: {Deck.CurrentDeck.Count()} / {Deck.FullDeck.Count()} | Discard: {Deck.CurrentDiscard.Count()}");
    }
}