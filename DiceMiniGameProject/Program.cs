// Your challenge is to design a mini-game. The game should select a target number that 
// is a random number between one and five (inclusive). The player must roll a six-sided dice. 
// To win, the player must roll a number greater than the target number. At the end of each round, 
// the player should be asked if they would like to play again, and the game should continue or terminate accordingly.

// In this challenge, you're given some starting code. You must determine what methods to 
// create, their parameters, and their return types.

Random random = new Random();

Console.WriteLine("Would you like to play? (Y/N)");

if (ShouldPlay())
{
  PlayGame();
}

void PlayGame()
{
  var play = true;

  while (play)
  {
    Console.WriteLine(WinOrLose());
    Console.WriteLine("\nPlay again? (Y/N)");

    play = ShouldPlay();
  }
}

// uses RollTarget and UserRoll to determine winner
string WinOrLose()
{
  int userRollResult = UserRoll();
  int targetRollResult = RollTarget();

  Console.WriteLine("You\t|\tUr Enemy");
  Console.WriteLine($"{userRollResult}\t|\t{targetRollResult}");

  if (userRollResult > targetRollResult)
  {
    return "Nice cock!";
  }
  else if (userRollResult < targetRollResult)
  {
    return "Literally never talk to me again. You suck so bad";
  }
  else
  {
    return "Could you please have just one unique thing about you?";
  }
}

// Users dice roll
int UserRoll()
{
  return random.Next(1, 7);
}

// Dice roll to beat
int RollTarget()
{
  return random.Next(1, 6);
}

// Return true to play again. False to exit
bool ShouldPlay()
{
  bool validInput = false;
  string userResponse = "";

  // Repeats as long as there is not a valid input
  do
  {
    // Validates answer
    string? potentialUserResponse = Console.ReadLine();
    if (potentialUserResponse != null && (potentialUserResponse.ToLower() == "y" || potentialUserResponse.ToLower() == "n"))
    {
      userResponse = potentialUserResponse.ToLower();
      validInput = true;
      continue;
    }
    else
    {
      Console.WriteLine("Didn't catch that. Mmm play again?? (Y/N)");
    }
  } while (!validInput);

  if (userResponse == "y")
  {
    return true;
  }
  else
  {
    return false;
  }
}