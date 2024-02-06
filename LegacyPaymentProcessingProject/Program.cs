// App to process payment in following format:
//  - paymentID in columns 1 - 6
//  - payeeName in columns 7 - 30
//  - paymentAmount in columns 31 - 40 (right aligned)

// Test variable assignment
string paymentID = "769C";
string payeeName = "Dick McButt";
string paymentAmount = "$5,000.00";

// Formatting lines
var formattedLine = paymentID.PadRight(6);
formattedLine += payeeName.PadRight(24);
formattedLine += paymentAmount.PadLeft(10);

Console.WriteLine("1234567890123456789012345678901234567890");
Console.WriteLine(formattedLine);