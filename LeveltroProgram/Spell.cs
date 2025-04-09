namespace Leveltro;

public class Spell
{
readonly string SpellName;
readonly int BaseDamage;
readonly string SpellDescription;
readonly bool HitsAll;
readonly int MoneyCost;
readonly int ManaCost;


    public Spell(string spellName, int baseDamage, string spellDescription, bool hitsAll, int moneyCost, int manaCost)
    {
        SpellName = spellName;
        BaseDamage = baseDamage;
        SpellDescription = spellDescription;
        HitsAll = hitsAll;
        MoneyCost = moneyCost;
        ManaCost = manaCost;
    }

    public void OnPlay(MobBoard mobs, EnchantmentBoard enchantments, int currentMana)
    {

    }
}

public class Deck
{
    public List<Spell> FullDeck;
    public List<Spell> CurrentDeck;
    public List<Spell> CurrentDiscard;
    public List<Spell> CurrentHand;

    public Deck(List<Spell> fullDeck)
    {
        FullDeck = fullDeck;
        CurrentDeck = fullDeck;
        CurrentDiscard = new();
        CurrentHand = new();
    }

    public void Draw()
    {

    }

    public void Discard()
    {
        
    }
}