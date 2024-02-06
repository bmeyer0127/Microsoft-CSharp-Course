string tester = "There are snakes at the zoo";
Console.WriteLine(ReverseChactersInWordsOfSentence(tester));


// Write a method that reverses a string without using string.Reverse
string ReverseSingleWord(string toBeReversed)
{
  char[] toBeReversedCharArray = toBeReversed.ToCharArray();
  char[] reversedCharArray = new char[toBeReversedCharArray.Length];
  int reverseCounter = 0;
  string reversedString = "";

  for (int i = toBeReversedCharArray.Length - 1; i >= 0; i--)
  {
    reversedCharArray[reverseCounter] = toBeReversedCharArray[i];
    reverseCounter++;
  }

  foreach (char character in reversedCharArray)
  {
    reversedString += character;
  }

  return reversedString;
}

// Write a method to reverse words in a sentence
string ReverseCharactersInSentence(string toBeReversed)
{
  string[] sentenceString = toBeReversed.Trim([',', '.']).Split(' ');
  string[] reversedSentenceArray = new string[sentenceString.Length];
  string reversedSentence = "";
  int counter = 0;

  for (int i = sentenceString.Length - 1; i >= 0; i--)
  {
    reversedSentenceArray[counter] = sentenceString[i];
    counter++;
  }

  foreach (string word in reversedSentenceArray)
  {
    reversedSentence += word + " ";
  }

  return reversedSentence;
}

// Write a method to reverse the letters of each word in a given sentense while maintaining original position in sentence
string ReverseChactersInWordsOfSentence(string toBeReversed)
{
  string result = "";
  string[] wordArray = toBeReversed.Split(' ');
  foreach (string word in wordArray)
  {
    result += ReverseSingleWord(word) + " ";
  }
  return result;
}