namespace Leveltro;
public class Shop
{
    public List<Mob> MobsOnSale;
    public List<Enchantment> EnchantmentsOnSale;
    public List<Spell> SpellsOnSale;

    public Shop()
    {
        MobsOnSale = GenerateMobs();
        EnchantmentsOnSale = GenerateEnchantments();
        SpellsOnSale = GenerateSpells();
    }

    public List<Mob> GenerateMobs()
    {
        return new();
    }
    public List<Enchantment> GenerateEnchantments()
    {
        return new();
    }
    public List<Spell> GenerateSpells()
    {
        return new();
    }
}