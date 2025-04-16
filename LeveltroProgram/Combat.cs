namespace Leveltro;

public static class CombatRunner
{
    public static int CurrentMana = 0;
    public static int CurrentScore = 0;
    public static int TotalTurns = 3;
    public static int CurrentTurn = 1;
    public static int MaxMana = 3;
    public static int[] damageToEachSlot = [0, 0, 0, 0, 0];
    public static int ScoreBenchmark;
    public static int HandSize = 5;
    public static void StartCombat(int scoreBenchmark, int handSize = 5)
    {
        ScoreBenchmark = scoreBenchmark;
        HandSize = handSize;
        Deck.CurrentDeck = new List<Spell>(Deck.FullDeck);

        for (int i = 0; i < handSize; i++)
        {
            Deck.Draw();
            CurrentMana = MaxMana;
        }

        foreach (Enchantment enchantment in EnchantmentBoard.Enchantments)
        {
            if (enchantment.StartOfCombat == true)
            {
                enchantment.Effect();
            }
        }

        UpdateScreen();

        PlayerTurn();
    }


    public static void PlayerTurn()
    {
        foreach (Enchantment enchantment in EnchantmentBoard.Enchantments)
        {
            if (enchantment.StartOfTurn == true)
            {
                enchantment.Effect();
            }
        }

        CurrentMana = MaxMana;


        int currentHandSize = Deck.CurrentHand.Count();
        for (int i = 0; i < HandSize - currentHandSize; i++)
        {
            Deck.Draw();
            CurrentMana = MaxMana;
        }

        UpdateScreen();


        bool turnEnded = false;
        while (!turnEnded)
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
                    if (playerChoice > 0 && playerChoice <= Deck.CurrentHand.Count())
                    {
                        if (CurrentMana >= Deck.CurrentHand[playerChoice - 1].ManaCost)
                        {
                            validChoice = true;
                            break;
                        }
                    }
                }
                catch { continue; }
            }

            if (playerChoice == 0)
            {
                turnEnded = true;
                EndTurn();
            }
            else
            {
                playerChoice--;

                Spell playedCard = Deck.CurrentHand[playerChoice];

                if (playedCard.HitsAll)
                {
                    for (int i = 0; i < MobBoard.Mobs.Count(); i++)
                    {
                        if (damageToEachSlot[i] < int.MaxValue)
                            damageToEachSlot[i] += playedCard.BaseDamage;

                        DetectAndRewardKill(i);
                    }
                }
                else
                {
                    for (int i = 0; i < MobBoard.Mobs.Count(); i++)
                    {
                        if (damageToEachSlot[i] < MobBoard.Mobs[i].BaseHP)
                        {
                            damageToEachSlot[i] += playedCard.BaseDamage;

                            DetectAndRewardKill(i);

                            break;
                        }
                    }
                }

                if (playedCard.Effect != null)
                {
                    playedCard.Effect();
                }

                CurrentMana -= playedCard.ManaCost;

                Deck.Discard(playerChoice);

                UpdateScreen();
            }


        }
    }

    public static void DetectAndRewardKill(int slotToCheck)
    {
        if (damageToEachSlot[slotToCheck] >= MobBoard.Mobs[slotToCheck].BaseHP && damageToEachSlot[slotToCheck] < int.MaxValue)
        {
            CurrentScore += MobBoard.Mobs[slotToCheck].BaseXPPerUnit * MobBoard.Mobs[slotToCheck].BaseQuantity;
            damageToEachSlot[slotToCheck] = int.MaxValue;
        }
    }

    public static void EndTurn()
    {
        foreach (Enchantment enchantment in EnchantmentBoard.Enchantments)
        {
            if (enchantment.EndOfTurn == true)
            {
                enchantment.Effect();
            }
        }

        CurrentTurn++;

        if (CurrentScore >= ScoreBenchmark)
            EndCombat();
        else if (CurrentTurn <= TotalTurns)
            PlayerTurn();
        else
            EndCombat();
    }

    public static void UpdateScreen()
    {
        try { Console.Clear(); } catch { }
        Console.WriteLine($"XP: {CurrentScore} / {ScoreBenchmark}");
        Console.WriteLine($"Mana: {CurrentMana} / {MaxMana}");
        Console.WriteLine($"Current Turn: {CurrentTurn} / {TotalTurns}");
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
                Console.Write($"{mob.MobName}(HP: {mob.BaseHP - damageToEachSlot[slot]}/{mob.BaseHP} #: {mob.BaseQuantity} XP: {mob.BaseXPPerUnit * mob.BaseQuantity})  ");

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

    public static void EndCombat()
    {
        if (CurrentScore < ScoreBenchmark)
        {
            try { Console.Clear(); }
            catch { }

            Console.WriteLine($"XP: {CurrentScore} / {ScoreBenchmark}");
            Console.WriteLine("Insufficient XP gained - GAME OVER");
            Environment.Exit(0);
        }
        else
        {
            try { Console.Clear(); }
            catch { }

            
        }
    }
}