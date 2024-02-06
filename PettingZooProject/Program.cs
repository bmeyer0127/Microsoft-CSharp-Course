// You're developing an application for the Contoso Petting Zoo that coordinates school visits. 
// The Contoso Petting Zoo is home to 18 different species of animals. At the zoo, visiting 
// students are assigned to groups, and each group has a set of animals assigned to it. After visiting 
// their set of animals, the students will rotate groups until they've seen all the animals at the petting zoo.

// By default, the students are divided into 6 groups. However, there are some classes that have a small 
// or large number of students, so the number of groups must be adjusted accordingly. The animals should 
// also be randomly assigned to each group, so as to keep the experience unique.

// There are currently three visiting schools

// School A has six visiting groups (the default number)
// School B has three visiting groups
// School C has two visiting groups
// For each visiting school, perform the following tasks

// Randomize the animals
// Assign the animals to the correct number of groups
// Print the school name
// Print the animal groups

Random random = new Random();

string[] pettingZoo =
{
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
};

string[,] schools = { { "School A", "6" }, { "School B", "3" }, { "School C", "2" } };

DisplaySchedules();

// Displays each group for each school and their respective and unique schedule
void DisplaySchedules()
{
  for (int i = 0; i < schools.GetLength(0); i++)
  {
    int.TryParse(schools[i, 1], out int amountOfGroups);

    for (int j = 1; j <= amountOfGroups; j++)
    {
      Console.WriteLine($"{schools[i, 0]}\t{j}\t{AnimalSchedule()}");
    }
  }
}

// AnimalSchedule assigns a random string of animals to visit
string AnimalSchedule()
{
  // List to be returned and represents curated animal schedule
  string[] animalSchedule = new string[pettingZoo.Length];

  // Assigns random animal order to animalSchedule
  for (int i = 0; i < pettingZoo.Length; i++)
  {
    string newAnimal = "";
    do
    {
      newAnimal = randomAnimal();
    } while (!IsNewAnimal(newAnimal, animalSchedule));

    animalSchedule[i] = newAnimal;
  }

  // Adds the list of animals in a single organized string
  string returnedAnimalSchedule = "";
  foreach (string animal in animalSchedule)
  {
    returnedAnimalSchedule += animal;
    if (Array.IndexOf(animalSchedule, animal) != animalSchedule.Length - 1)
    {
      returnedAnimalSchedule += " -> ";
    }
  }

  return returnedAnimalSchedule;
}

// Returns a random animal from pettingZoo
string randomAnimal()
{
  return pettingZoo[random.Next(0, pettingZoo.Length)];
}

// Returns true if provided animal is not already in provided list
bool IsNewAnimal(string newAnimal, string[] animalList)
{
  foreach (string animal in animalList)
  {
    if (animal == newAnimal)
    {
      return false;
    }
  }
  return true;
}