using Leveltro;

Generator.CreateAll();
Generator.BuildInitialDeck();
Generator.BuildInitialMobAndEnchant();

int combat1Score = 20;
int round = 1;

try { Console.Clear(); }
catch { }

Console.WriteLine("Welcome to Leveltro");
Console.WriteLine("Press any key to start");
try { Console.ReadKey(); }
catch { }

while (true)
{

    try { Console.Clear(); }
    catch { }

    CombatRunner.StartCombat(combat1Score + ((round - 1) * 5));
    round++;

    ShopRunner.GenerateShop();
}