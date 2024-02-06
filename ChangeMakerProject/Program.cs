// Find minumum amount of coins to make change

// Name of coin with respective value
string[,] coins = { { "penny", "1" }, { "nickle", "5" }, { "dime", "10" }, { "quarter", "25" } };

// Test amount 
double changeNeeded = .79;
Console.WriteLine(ChangeMaker(changeNeeded));

// ChangeMaker
string ChangeMaker(double changeAmount)
{
  // This array goes from smallest to largest
  int[] coinsNeeded = [0, 0, 0, 0];
  int changeAmountCents = (int)(changeAmount * 100);

  // Starts from quarter and tries to fit as many respective coins in change amount as possible until moving down
  for (int i = coins.GetLength(0) - 1; i >= 0; i--)
  {
    int.TryParse(coins[i, 1], out int coinAmount);

    // Ensures coin fits without going negative
    bool coinFits = true;
    while (coinFits)
    {
      if ((changeAmountCents - coinAmount) >= 0)
      {
        changeAmountCents -= coinAmount;
        coinsNeeded[i]++;
        continue;
      }
      else
      {
        coinFits = false;
      }
    }
  }
  return $"Pennies:\t{coinsNeeded[0]}\nNickles:\t{coinsNeeded[1]}\nDimes:\t\t{coinsNeeded[2]}\nQuarters:\t{coinsNeeded[3]}";
}