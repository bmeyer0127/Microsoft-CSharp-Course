Console.WriteLine("Which of the following are you logging in as?\n");
Console.WriteLine("-\tAdministrator\n-\tManager\n-\tUser\n");
Console.Write("Please type your answer here: ");

bool validInput = false;
string[] validInputs = ["administrator", "manager", "user"];
string? userInput;

// String validation loop
do
{
  userInput = Console.ReadLine();
  string? polishedInput = userInput.Trim().ToLower();

  foreach (string input in validInputs)
  {
    if (polishedInput == input)
      validInput = true;
    continue;
  }
  if (validInput)
    continue;

  // Response for failed login attempt
  Console.WriteLine("Looks like that didn't work for us. What are you logging in as?\n");
  Console.WriteLine("-\tAdministrator\n-\tManager\n-\tUser\n");
  Console.Write("Please type your answer here: ");
} while (!validInput);

// Response for valid login attempt
Console.WriteLine($"Neat! Welcome in {userInput}!");