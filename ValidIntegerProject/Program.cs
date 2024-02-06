// Prompt user for valid integer input
Console.Write("Please input a number between 5 and 10: ");

// Acceptable parameters initialization
bool validInteger = false;
int potentialInteger;

// Iteration block that confirms or reiterates the request
do
{
  string? userInput = Console.ReadLine();
  Console.WriteLine();

  if (int.TryParse(userInput, out potentialInteger) && (potentialInteger > 4) && (potentialInteger < 11))
  {
    validInteger = true;
    continue;
  }

  Console.WriteLine("Looks like that's not what we're looking for, idiot.\n");
  Console.Write("Try again?: ");
} while (validInteger == false);

Console.WriteLine("Amazing. Thank you");