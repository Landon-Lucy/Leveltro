using Leveltro;

Generator.CreateAll();
Generator.BuildInitialDeck();
Generator.BuildInitialMobAndEnchant();

int combat1Score = 20;

Console.Clear();

Console.WriteLine("Welcome to Leveltro");
Console.WriteLine("Press any key to start");

Console.ReadKey();

Console.Clear();

CombatRunner.StartCombat(3, combat1Score);