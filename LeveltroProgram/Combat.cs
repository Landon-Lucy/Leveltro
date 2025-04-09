namespace Leveltro;

public static class CombatRunner
{
    public static int CurrentMana = 0;
    public static void StartCombat(int maxMana)
    {
        for (int i = 0; i < 5; i++)
        {
            Deck.Draw();
            CurrentMana = maxMana;
        }

        foreach(Enchantment enchantment in EnchantmentBoard.Enchantments)
        {
            if (enchantment.StartOfCombat == true)
            {
                
            }
        }
    }
}