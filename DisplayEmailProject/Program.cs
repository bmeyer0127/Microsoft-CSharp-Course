// Your challenge is to create a method that displays the correct email address 
// for both internal and external employees. 
// You're given lists of internal and external employee names. 
// An employee's email address consists of their username and company domain name.

// The username format is the first two characters of the employee first name, 
// followed by their last name. For example, an employee named "Robert Bavin" would have 
// the username "robavin". The domain for internal employees is "contoso.com".

// In this challenge, you're given some starting code. You must decide how to create and 
// call a method to display email addresses.

string[,] corporate =
{
    {"Robert", "Bavin"}, {"Simon", "Bright"},
    {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
    {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
};

string[,] external =
{
    {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
    {"Shay", "Lawrence"}, {"Daren", "Valdes"}
};

string externalDomain = "@hayworth.com";

Console.WriteLine("Internal Emails:");
for (int i = 0; i < corporate.GetLength(0); i++)
{
  DisplayEmail(i, corporate);
}

Console.WriteLine("External Emails:");
for (int i = 0; i < external.GetLength(0); i++)
{
  DisplayEmail(i, external, externalDomain);
}

void DisplayEmail(int employee, string[,] type, string domain = "@contoso.com")
{
  string employeeEmail = type[employee, 0].Substring(0, 2).ToLower() + type[employee, 1].ToLower() + domain;
  Console.WriteLine($"Name: {type[employee, 0]} {type[employee, 1]} \t Email: {employeeEmail}");
}