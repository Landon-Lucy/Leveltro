namespace Leveltro;

public class Spell
{
readonly string SpellName;
readonly int BaseDamage;
readonly string SpellDescription;
readonly bool HitsAll;
readonly int MoneyCost;
readonly int ManaCost;
readonly int Rarity;


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
    public static List<Spell> FullDeck = Generator.BuildInitialDeck();
    public static List<Spell> CurrentDeck = new();
    public static List<Spell> CurrentDiscard = new();
    public static List<Spell> CurrentHand = new();

    public static void Draw()
    {

    }

    public static void Discard()
    {

    }
}