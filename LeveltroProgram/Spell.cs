namespace Leveltro;

public class Spell
{
    public string SpellName;
    public int BaseDamage;
    public string SpellDescription;
    public bool HitsAll;
    public int MoneyCost;
    public int ManaCost;
    public int Rarity;
    public Action Effect;


    public Spell(string spellName, int baseDamage, string spellDescription, bool hitsAll, int moneyCost, int manaCost, int rarity, Action effect)
    {
        SpellName = spellName;
        BaseDamage = baseDamage;
        SpellDescription = spellDescription;
        HitsAll = hitsAll;
        MoneyCost = moneyCost;
        ManaCost = manaCost;
        Rarity = rarity;
        Effect = effect;
    }

    public void OnPlay()
    {
        Effect();
    }
}

public static class Deck
{
    public static List<Spell> FullDeck = new();
    public static List<Spell> CurrentDeck = new();
    public static List<Spell> CurrentDiscard = new();
    public static List<Spell> CurrentHand = new();

    public static void Draw()
    {
        if (CurrentDeck.Count() <= 0)
        {
            ReshuffleDiscardIn();
        }

        CurrentHand.Add(CurrentDeck.ElementAt(0));
        CurrentDeck.RemoveAt(0);
    }

    public static void Discard(int spellChoice)
    {
        CurrentDiscard.Add(CurrentHand.ElementAt(spellChoice));
        CurrentHand.RemoveAt(spellChoice);
    }

    public static void ReshuffleDiscardIn()
    {
        int discardSize = CurrentDiscard.Count();
        for (int i = 0; i < discardSize; i++)
        {
            CurrentDeck.Add(CurrentDiscard[0]);
            CurrentDiscard.RemoveAt(0);
        }
        ShuffleDeck();
    }

    public static void ShuffleDeck()
    {
        Random rng = new Random();
        CurrentDeck = CurrentDeck.OrderBy(_ => rng.Next()).ToList();
    }

    public static void AddSpell(Spell spell)
    {
        FullDeck.Add(spell);
    }

    public static void RemoveSpell(int indexToRemove)
    {
        FullDeck.RemoveAt(indexToRemove);
    }
}