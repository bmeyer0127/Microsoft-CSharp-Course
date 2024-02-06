// the ourAnimals array will store the following: 

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";
string[] searchingCountdown = ["3", "2", "1"];
string[] searchingIcons = ["|", "/", "-", "\\"];

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
char[] removableCharacters = ['.', '-', ' ', '_', '/'];

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
  switch (i)
  {
    case 0:
      animalSpecies = "dog";
      animalID = "d1";
      animalAge = "2";
      animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
      animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
      animalNickname = "lola";
      suggestedDonation = "85.00";
      break;
    case 1:

      animalSpecies = "dog";
      animalID = "d2";
      animalAge = "9";
      animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
      animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
      animalNickname = "loki";
      suggestedDonation = "49.99";
      break;
    case 2:

      animalSpecies = "cat";
      animalID = "c3";
      animalAge = "1";
      animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
      animalPersonalityDescription = "friendly";
      animalNickname = "Puss";
      suggestedDonation = "40.00";
      break;
    case 3:

      animalSpecies = "cat";
      animalID = "c4";
      animalAge = "?";
      animalPhysicalDescription = "";
      animalPersonalityDescription = "";
      animalNickname = "";
      suggestedDonation = "";
      break;
    default:

      animalSpecies = "";
      animalID = "";
      animalAge = "";
      animalPhysicalDescription = "";
      animalPersonalityDescription = "";
      animalNickname = "";
      suggestedDonation = "";
      break;
  }

  ourAnimals[i, 0] = "ID #: " + animalID;
  ourAnimals[i, 1] = "Species: " + animalSpecies;
  ourAnimals[i, 2] = "Age: " + animalAge;
  ourAnimals[i, 3] = "Nickname: " + animalNickname;
  ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
  ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
  if (decimal.TryParse(suggestedDonation, out decimal decimalSuggestedDonation))
  {
    ourAnimals[i, 6] = $"Suggested donation: {decimalSuggestedDonation:C}";
  }
  else
  {
    // Defaults to $45.00
    ourAnimals[i, 6] = $"Suggested donation: {45:C}";
  }
}

// display the top-level menu options
do
{
  Console.Clear();

  Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
  Console.WriteLine(" 1. List all of our current pet information");
  Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");   // Must implement
  Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
  Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
  Console.WriteLine(" 5. Edit an animal`s age");
  Console.WriteLine(" 6. Edit an animal`s personality description");
  Console.WriteLine(" 7. Display all cats with a specified characteristic");
  Console.WriteLine(" 8. Display all dogs with a specified characteristic");
  Console.WriteLine();
  Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

  // Accepts and interprets user dialogue
  readResult = Console.ReadLine();
  if (readResult != null)
  {
    menuSelection = readResult.ToLower();
  }

  Console.WriteLine($"You selected menu option {menuSelection}.");
  Console.WriteLine("Press the Enter key to continue");

  // pause code execution
  readResult = Console.ReadLine();
  Console.Clear();

  switch (menuSelection)
  {
    case "1":
      // List all of our current pet information
      for (int i = 0; i < maxPets; i++)
      {
        if (ourAnimals[i, 0] != "ID #: ")
        {
          for (int j = 0; j < 7; j++)
          {
            Console.WriteLine(ourAnimals[i, j]);
          }
          Console.WriteLine();
        }
      }

      Console.WriteLine();
      Console.Write("Press Enter to return home");
      readResult = Console.ReadLine();
      break;

    // Add a new animal friend to the ourAnimals array
    case "2":
      // variable determines if loop should run again
      string? anotherPet = "y";

      do
      {
        // Find count of current pets
        int petCount = 0;
        for (int i = 0; i < maxPets; i++)
        {
          if (ourAnimals[i, 0] != "ID #: ")
          {
            petCount += 1;
          }
        }


        // If there is room for more pets
        if (petCount < maxPets)
        {
          Console.WriteLine($"We are currently housing {petCount} babies. We can manage {maxPets - petCount} more!");

          // Variable initialization
          string? species = "";

          // Pet information prompt
          Console.WriteLine("Is our new little baby a \"dog\" or \"cat\"?");
          species = Console.ReadLine();

          // Formats user dialogue
          if (species != null)
          {
            species = species.ToLower().Trim();
          }

          // Checks if user dialogue is accurate to prompt
          if (species != "dog" && species != "cat")
          {
            Console.Clear();
            Console.WriteLine("Whoop. Didn't catch that. Let's try again");
          }
          else
          {
            Console.Clear();
            Console.WriteLine($"Amazing! Let's get your {species} registered.");

            // ID and species assignment
            ourAnimals[petCount, 0] = $"ID #: {species[..1]}{petCount + 1}";
            ourAnimals[petCount, 1] = $"Species: {species}";

            // Age assignment
            bool validAge = false;
            do
            {
              Console.Write("What is their age? (Leave blank if unsure): ");
              string? age = Console.ReadLine();

              // Checks if null. Trims if not
              if (age != null)
              {
                age = age.Trim();

                if (age == "")
                {
                  age = "?";
                  ourAnimals[petCount, 2] = $"Age: {age}";
                  validAge = true;
                }
                else if (int.TryParse(age, out int petAge))
                {
                  ourAnimals[petCount, 2] = $"Age: {petAge}";
                  validAge = true;
                }
                else
                {
                  Console.Write("Looks like that didn't work for us. Hit Enter to try again.");
                  Console.ReadLine();
                  Console.Clear();
                }
              }
            } while (!validAge);

            // Nickname assignment
            Console.Write("Do they have a nickname? (Leave blank if unsure): ");
            string? nickname = Console.ReadLine();

            // Checks if null. Trims if not
            if (nickname != null)
            {
              nickname = nickname.Trim();

              // Checks and reassigns if blank
              if (nickname == "")
              {
                nickname = "tbd";
              }
              ourAnimals[petCount, 3] = $"Nickname: {nickname}";
            }

            // Physical Description assignment
            Console.Write("How would you describe what they look like? (Leave blank if unsure): ");
            string? physicalDescription = Console.ReadLine();

            // Checks if null. Trims if not
            if (physicalDescription != null)
            {
              physicalDescription = physicalDescription.Trim();

              // Checks and reassigns if blank
              if (physicalDescription == "")
              {
                physicalDescription = "tbd";
              }
              ourAnimals[petCount, 4] = $"Physical description: {physicalDescription}";
            }

            // Personality assignment
            Console.Write("How would you describe their personality? (Leave blank if unsure): ");
            string? personality = Console.ReadLine();

            // Checks if null. Trims if not
            if (personality != null)
            {
              personality = personality.Trim();

              // Checks and reassigns if blank
              if (personality == "")
              {
                personality = "tbd";
              }
              ourAnimals[petCount, 5] = $"Personality: {personality}";
            }

            // Display all the info for new pet
            Console.WriteLine();
            Console.WriteLine("Here they are!");
            for (int i = 0; i < 6; i++)
            {
              Console.WriteLine(ourAnimals[petCount, i]);
            }

            Console.WriteLine();
            Console.WriteLine("Hit Enter to continue");
            Console.ReadLine();
          }
        }
        else
        {
          Console.WriteLine("We are not currently accepting new pets.");
          // Breaks loop because there is no room to add another pet
          anotherPet = "n";
          continue;
        }

        // Prompts user if there is another animal to be registered
        Console.Clear();
        Console.Write("Would you like to register another animal? (y/n): ");
        anotherPet = Console.ReadLine();
      } while (anotherPet == "y");

      Console.Write("Press Enter to return home");
      Console.ReadLine();
      break;

    // Ensure animal ages and physical descriptions are complete
    case "3":
      // Iterate through ourAnimals
      for (int i = 0; i < maxPets; i++)
      {
        // Ensures animals have valid ID
        if (ourAnimals[i, 0] != "ID #: ")
        {
          // Checks if animal has a valid age
          if (ourAnimals[i, 2] == "Age: ?")
          {
            bool validEntry = false;
            do
            {
              Console.WriteLine($"Animal with {ourAnimals[i, 0]} does not have a valid age.");
              Console.Write("Please input a valid age: ");

              string? userInput = Console.ReadLine();

              // Checks if not null and an int. Assigns if returns true
              if (int.TryParse(userInput, out int potentialAge) && userInput != null)
              {
                ourAnimals[i, 2] = $"Age: {potentialAge}";
                validEntry = true;

                Console.WriteLine("Hit Enter to continue");
                Console.ReadLine();
                Console.Clear();
                continue;
              }
              // Loop if was not valid
              else
              {
                Console.WriteLine("That didn't seem to work. Press Enter to try again");
                Console.ReadLine();
                Console.Clear();
              }
            } while (!validEntry);
          }
          // Checks if animal has a valid physical description
          if (ourAnimals[i, 4] == "Physical description: tbd" || ourAnimals[i, 4] == "Physical description: ")
          {
            bool validEntry = false;
            do
            {
              Console.WriteLine($"Animal with {ourAnimals[i, 0]} does not have a valid physical description.");
              Console.Write("Please input a valid physical description: ");

              string? userInput = Console.ReadLine();

              // Checks if not null. Assigns if returns true
              if (userInput != null && userInput.Trim() != "")
              {
                ourAnimals[i, 4] = $"Physical Description: {userInput}";
                validEntry = true;

                Console.WriteLine("Hit Enter to continue");
                Console.ReadLine();
                Console.Clear();
                continue;
              }
              // Loop if was not valid
              else
              {
                Console.WriteLine("That didn't seem to work. Press Enter to try again");
                Console.ReadLine();
                Console.Clear();
              }
            } while (!validEntry);
          }
        }
      }

      Console.WriteLine("All the necessary information seems to be here!");
      Console.WriteLine("Press the Enter key to continue.");
      readResult = Console.ReadLine();
      break;

    // Ensure animal nicknames and personality descriptions are complete
    case "4":
      // Loop through animals who have "tbd" or blank as nickname  
      Console.WriteLine("case 4");
      for (int i = 0; i < maxPets; i++)
      {
        // Checks for valid ID first
        bool validNickname = false;
        if (ourAnimals[i, 0] != "ID #: ")
        {
          // if nickname space is empty or is "tbd"
          if (ourAnimals[i, 3] == "Nickname: " || ourAnimals[i, 3] == "Nickname: tbd")
          {
            do
            {
              Console.WriteLine($"Looks like we are missing a nickname for {ourAnimals[i, 0]}");
              Console.Write("Put one here for the poor baby: ");
              string? userInput = Console.ReadLine();

              // Checks for not null input
              if (userInput != null && userInput.Trim() != "")
              {
                ourAnimals[i, 3] = $"Nickname: {userInput}";
                Console.WriteLine($"Cute! {userInput} will be very happy!");
                validNickname = true;

                Console.WriteLine("Hit Enter to continue");
                Console.ReadLine();
                Console.Clear();
                continue;
              }
              else
              {
                Console.WriteLine("We will need a little more than \" \"");
                Console.WriteLine("Press Enter to try again");
                Console.ReadLine();
                Console.Clear();
              }
            } while (!validNickname);
          }
        }
      }

      // Loop through animals that have "tbd" or blank as personality
      for (int i = 0; i < maxPets; i++)
      {
        // Ensures valid ID
        bool validPersonality = false;
        if (ourAnimals[i, 0] != "ID #: ")
        {
          if (ourAnimals[i, 5] == "Personality: tbd" || ourAnimals[i, 5] == "Personality: ")
          {
            do
            {
              Console.WriteLine("Describe the personality for animal with:");
              Console.WriteLine(ourAnimals[i, 0]);
              Console.WriteLine(ourAnimals[i, 3]);
              Console.Write("Write it here: ");
              string? userInput = Console.ReadLine();

              if (userInput != null && userInput.Trim() != "")
              {
                ourAnimals[i, 5] = $"Personality: {userInput}";
                Console.WriteLine("Thank you!");
                validPersonality = true;

                Console.WriteLine("Hit Enter to continue");
                Console.ReadLine();
                Console.Clear();
                continue;
              }
              else
              {
                Console.WriteLine("We need more than nothing.");
                Console.WriteLine("Press Enter to try again");
                Console.ReadLine();
                Console.Clear();
              }
            } while (!validPersonality);
          }
        }
      }

      Console.WriteLine("Looks like we have what we need!");
      Console.WriteLine("Press the Enter key to continue.");
      readResult = Console.ReadLine();
      break;

    case "5":
      // Edit an animal`s age
      Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
      Console.WriteLine("Press the Enter key to continue.");
      readResult = Console.ReadLine();
      break;

    case "6":
      // Edit an animal`s personality description
      Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
      Console.WriteLine("Press the Enter key to continue.");
      readResult = Console.ReadLine();
      break;

    case "7":
      // Display all cats with a specified characteristic

      string? catCharacteristicInput;
      string catParsedInput;
      string[] catMatches = new string[maxPets];
      bool isFinishedCat = false;

      do
      {
        // Resets search array and place counter
        Array.Clear(catMatches);
        int catMatchesPlace = 0;
        Console.WriteLine("What are you looking for in a cat?");
        Console.Write("Input here: ");
        catCharacteristicInput = Console.ReadLine();

        if (catCharacteristicInput != null)
        {
          if (catCharacteristicInput.Trim(removableCharacters) == "")
          {
            Console.WriteLine("Looks like we may need more to go off of.");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Console.Clear();
            continue;
          }
          else
          {
            catParsedInput = catCharacteristicInput.ToLower();
            for (int i = 0; i < maxPets; i++)
            {
              if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 0][6] == 'c')
              {
                if (ourAnimals[i, 4].ToLower().IndexOf(catParsedInput) != -1 || ourAnimals[i, 5].ToLower().IndexOf(catParsedInput) != -1)
                {
                  catMatches[catMatchesPlace] = ourAnimals[i, 0];
                  catMatchesPlace++;
                }
              }
            }
          }
        }

        // Handles no matches. Option to try again or exit
        if (catMatchesPlace == 0)
        {
          Console.WriteLine("Sorry, we didn't find any matches");
          Console.Write("Press Enter to try again. Or type Exit to go home: ");
          string? searchAgain = Console.ReadLine();
          if (searchAgain != null)
          {
            if (searchAgain.ToLower().Trim() == "exit")
            {
              isFinishedCat = true;
              continue;
            }
            else
            {
              Console.Clear();
              continue;
            }
          }
        }
        // Displays matches
        else
        {
          Console.WriteLine("Here are your matches!\n");
          foreach (string match in catMatches)
          {
            for (int i = 0; i < maxPets; i++)
            {
              if (ourAnimals[i, 0] == match)
              {
                for (int j = 0; j < 7; j++)
                {
                  Console.WriteLine(ourAnimals[i, j]);
                }
                Console.WriteLine();
              }
            }
          }
          Console.Write("Press Enter to search again or Exit to go home: ");
          string? searchAgain = Console.ReadLine();
          if (searchAgain != null)
          {
            if (searchAgain.ToLower().Trim() == "exit")
            {
              isFinishedCat = true;
              continue;
            }
            else
            {
              Console.Clear();
              continue;
            }
          }
        }
      } while (!isFinishedCat);

      Console.WriteLine("Press the Enter key to continue.");
      readResult = Console.ReadLine();
      break;

    case "8":
      // Display all dogs with a specified characteristic
      string dogParsedInput;
      string[] dogMatches = new string[maxPets];
      bool isFinishedDog = false;


      do
      {
        // Resets search array and place counter
        Array.Clear(dogMatches);
        int dogMatchesPlace = 0;
        Console.WriteLine("What are you looking for in a dog? Feel free to separate attributes by commas!");
        Console.Write("Input here: ");
        string? dogCharacteristicInput = Console.ReadLine();

        if (dogCharacteristicInput != null)
        {
          if (dogCharacteristicInput.Trim(removableCharacters) == "")
          {
            Console.WriteLine("Looks like we may need more to go off of.");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Console.Clear();
            continue;
          }
          else
          {
            dogParsedInput = dogCharacteristicInput.ToLower();
            string[] multipleDogInputs = dogParsedInput.Split(',');
            Array.Sort(multipleDogInputs);

            // Checks for valid ID for each dog
            for (int i = 0; i < maxPets; i++)
            {
              if (ourAnimals[i, 0] != "ID #: " && ourAnimals[i, 0][6] == 'd')
              {
                // Iterates for each input separated by comma
                foreach (string input in multipleDogInputs)
                {
                  // Loading animation
                  foreach (string number in searchingCountdown)
                  {
                    foreach (string icon in searchingIcons)
                    {
                      Console.Write($"\rSearching...{input.Trim()} {icon}\t{number}");
                      System.Threading.Thread.Sleep(200); // .333 second
                    }
                  }
                }
                foreach (string input in multipleDogInputs)
                {
                  Console.WriteLine();
                  if (ourAnimals[i, 4].ToLower().IndexOf(input) != -1 || ourAnimals[i, 5].ToLower().IndexOf(input) != -1)
                  {
                    dogMatches[dogMatchesPlace] = ourAnimals[i, 0];
                    dogMatchesPlace++;
                    Console.WriteLine($"Our dog {ourAnimals[i, 3].Substring(10)} is a match for your search for {input.Trim()}");
                    Console.WriteLine();
                    Console.WriteLine(ourAnimals[i, 3]);
                    Console.WriteLine(ourAnimals[i, 4]);
                    Console.WriteLine(ourAnimals[i, 5]);
                    Console.WriteLine();
                  }
                }
              }
            }
          }
        }

        // Handles no matches. Option to try again or exit
        if (dogMatchesPlace == 0)
        {
          Console.WriteLine("Sorry, we didn't find any matches");
          Console.Write("Press Enter to try again. Or type Exit to go home: ");
          string? searchAgain = Console.ReadLine();
          if (searchAgain != null)
          {
            if (searchAgain.ToLower().Trim() == "exit")
            {
              isFinishedDog = true;
              continue;
            }
            else
            {
              Console.Clear();
              continue;
            }
          }
        }
        // Displays matches
        else
        {
          // foreach (string match in dogMatches)
          // {
          //   for (int i = 0; i < maxPets; i++)
          //   {
          //     if (ourAnimals[i, 0] == match)
          //     {
          //       Console.WriteLine(ourAnimals[i, 3]);
          //       Console.WriteLine(ourAnimals[i, 4]);
          //       Console.WriteLine(ourAnimals[i, 5]);
          //       Console.WriteLine();
          //     }
          //   }
          // }
          Console.Write("Press Enter to search again or Exit to go home: ");
          string? searchAgain = Console.ReadLine();
          if (searchAgain != null)
          {
            if (searchAgain.ToLower().Trim() == "exit")
            {
              isFinishedDog = true;
              continue;
            }
            else
            {
              Console.Clear();
              continue;
            }
          }
        }
      } while (!isFinishedDog);

      Console.WriteLine("Press the Enter key to continue.");
      readResult = Console.ReadLine();
      break;

    case "exit":
      // Exits application
      break;

    default:
      Console.WriteLine("Misunderstood prompt. Try again?");
      Console.Write("Press Enter to try again.");
      Console.ReadLine();
      break;
  }
} while (menuSelection != "exit");