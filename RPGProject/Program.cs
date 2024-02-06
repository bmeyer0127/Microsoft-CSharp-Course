int heroHealth = 10;
int monsterHealth = 10;

Random diceRoll = new Random();
int attack;

do
{
  // hero attacks
  attack = diceRoll.Next(1, 11);
  monsterHealth -= attack;
  Console.WriteLine($"The monster was attacked for {attack} hit points. Current health: {monsterHealth}");
  if (monsterHealth <= 0)
    continue;

  // monster attacks
  attack = diceRoll.Next(1, 11);
  heroHealth -= attack;
  Console.WriteLine($"The hero was attacked for {attack} hit points. Current health: {heroHealth}");

  Console.WriteLine();

} while (heroHealth > 0 && monsterHealth > 0);  // health is evaluated to check if either are dead

// Ending message
if (monsterHealth <= 0)
  Console.WriteLine("The hero wins!");
else if (heroHealth <= 0)
  Console.WriteLine("The hero got absolutely fucked");