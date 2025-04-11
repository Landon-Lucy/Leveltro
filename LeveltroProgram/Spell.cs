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


    public Spell(string spellName, int baseDamage, string spellDescription, bool hitsAll, int moneyCost, int manaCost, int rarity)
    {
        SpellName = spellName;
        BaseDamage = baseDamage;
        SpellDescription = spellDescription;
        HitsAll = hitsAll;
        MoneyCost = moneyCost;
        ManaCost = manaCost;
        Rarity = rarity;
    }

    public void OnPlay(int currentMana)
    {

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
        CurrentHand.Add(CurrentDeck[0]);
        CurrentDeck.RemoveAt(0);
    }

    public static void Discard()
    {

    }
}