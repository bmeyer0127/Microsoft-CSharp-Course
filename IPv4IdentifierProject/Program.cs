// Write a program that checks whether an IPv4 address is valid or invalid. 
// Make sure the program follows these rules:
//  - A valid IPv4 address consists of four numbers separated by dots
//  - Each number must not contain leading zeros
//  - Each number must range from 0-255
// 1.1.1.1 and 255.255.255.255 are both valid IP addresses
// The IPv4 address is provided as a string. You can assume that it only consists of digits and dots


// Accept input of IPv4 address
string[] potentialIPv4Array = ["107.31.1.5", "255.0.0.255", "555..0.555", "255...255"];

foreach (string potentialIPv4 in potentialIPv4Array)
{
  if (ValidNumberOfDigits(potentialIPv4) && !ContainsLeadingZeros(potentialIPv4) && CorrectNumberRange(potentialIPv4))
  {
    ValidIP(potentialIPv4);
  }
  else
  {
    InvalidIP(potentialIPv4);
  }
}

// Methods Used

// Returns bool that discloses if potentialIPv4 has correct amount of numbers
bool ValidNumberOfDigits(string potentialIPv4)
{
  string[] separatedNumbers = potentialIPv4.Split('.');
  if (separatedNumbers.Length == 4)
  {
    return true;
  }
  else
  {
    return false;
  }
}

// Returns false if potentialIPv4 does not have any leading zeros or if double dots. E.g. ".."
bool ContainsLeadingZeros(string potentialIPv4)
{
  string[] separatedNumbers = potentialIPv4.Split('.');
  foreach (string number in separatedNumbers)
  {
    if (number != "")
    {
      if (number.Length > 1 && number.Substring(0, 1) == "0")
      {
        return true;
      }
    }
    else
    {
      return true;
    }
  }
  return false;
}

// Returns true if each number of IPv4 is within corrent range
bool CorrectNumberRange(string potentialIPv4)
{
  string[] separatedNumbers = potentialIPv4.Split('.');
  foreach (string number in separatedNumbers)
  {
    if (int.TryParse(number, out int integerNumber))
    {
      if (integerNumber >= 0 && integerNumber <= 255)
      {
        continue;
      }
      else
      {
        return false;
      }
    }
  }
  return true;
}

// Return IPv4 and discloses that it is invalid
void InvalidIP(string potentialIPv4)
{
  Console.WriteLine($"{potentialIPv4} is not a valid IPv4");
}

// Return IPv4 and discloses that it is valid
void ValidIP(string potentialIPv4)
{
  Console.WriteLine($"{potentialIPv4} is a valid IPv4");
}