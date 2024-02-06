string[] myStrings = ["I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices"];
int periodLocation = 0;

for (int i = 0; i < myStrings.Length; i++)
{
  string myString = myStrings[i];

  do
  {
    periodLocation = myString.IndexOf(". ");

    if (periodLocation == -1)
    {
      Console.WriteLine(myString);
      continue;
    }
    Console.WriteLine(myString.Substring(0, periodLocation));
    myString = myString.Remove(0, periodLocation + 1).Trim();
  } while (periodLocation != -1);
}