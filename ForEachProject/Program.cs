using System;

// I did not follow along with how they performed the extra credit portion
// How they did it seemed needlessly complicated and would make it more difficult
// to update upon adding more exams and extra credit opportunities. Not to mention
// the fact that they did not update their sum to include decimals which
// rounds down the score before it is finally calculated as their final grade.
// 
// I simply added another array per student to include their extra credit scores,
// and added another foreach block after calculating the sum for their ordinary scores.

// initialize variables - graded assignments 
int currentAssignments = 5;

int[] sophiaScores = [90, 86, 87, 98, 100];
int[] andrewScores = [92, 89, 81, 96, 90];
int[] emmaScores = [90, 85, 87, 98, 68];
int[] loganScores = [90, 95, 87, 88, 96];
int[] beckyScores = [92, 91, 90, 91, 92];
int[] chrisScores = [84, 86, 88, 90, 92];
int[] ericScores = [80, 90, 100, 80, 90];
int[] gregorScores = [91, 91, 91, 91, 91];

// Extra credit arrays
int[] sophiaExtraCredit = [94, 90];
int[] andrewExtraCredit = [89];
int[] emmaExtraCredit = [89, 89, 89];
int[] loganExtraCredit = [96];
int[] beckyExtraCredit = [92, 92];
int[] chrisExtraCredit = [94, 96, 98];
int[] ericExtraCredit = [100, 80, 90];
int[] gregorExtraCredit = [91, 91];

// Adds students to an array and loops through each student 
string[] studentNames = ["Sophia", "Andrew", "Emma", "Logan", "Becky", "Chris", "Eric", "Gregor"];
int[] studentScores = new int[10];
int[] studentExtraCredit = new int[5];
string currentStudentLetterGrade = "";
int currentStudentExtraCreditAssignments;

Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit\n");
foreach (string student in studentNames)
{
  string currentStudent = student;

  if (currentStudent == "Sophia")
  {
    studentScores = sophiaScores;
    studentExtraCredit = sophiaExtraCredit;
    currentStudentExtraCreditAssignments = studentExtraCredit.Length;
  }

  else if (currentStudent == "Andrew")
  {
    studentScores = andrewScores;
    studentExtraCredit = andrewExtraCredit;
    currentStudentExtraCreditAssignments = studentExtraCredit.Length;
  }

  else if (currentStudent == "Emma")
  {
    studentScores = emmaScores;
    studentExtraCredit = emmaExtraCredit;
    currentStudentExtraCreditAssignments = studentExtraCredit.Length;
  }

  else if (currentStudent == "Logan")
  {
    studentScores = loganScores;
    studentExtraCredit = loganExtraCredit;
    currentStudentExtraCreditAssignments = studentExtraCredit.Length;
  }

  else if (currentStudent == "Becky")
  {
    studentScores = beckyScores;
    studentExtraCredit = beckyExtraCredit;
    currentStudentExtraCreditAssignments = studentExtraCredit.Length;
  }

  else if (currentStudent == "Chris")
  {
    studentScores = chrisScores;
    studentExtraCredit = chrisExtraCredit;
    currentStudentExtraCreditAssignments = studentExtraCredit.Length;
  }

  else if (currentStudent == "Eric")
  {
    studentScores = ericScores;
    studentExtraCredit = ericExtraCredit;
    currentStudentExtraCreditAssignments = studentExtraCredit.Length;
  }
  else if (currentStudent == "Gregor")
  {
    studentScores = gregorScores;
    studentExtraCredit = gregorExtraCredit;
    currentStudentExtraCreditAssignments = studentExtraCredit.Length;
  }
  else
    continue;
  // Initialize sum of current student
  decimal studentSum = 0;
  int currentStudentExamSum = 0;
  int currentStudentExtraCreditPoints = 0;
  decimal currentStudentExtraCreditScore = 0;

  // Calculates sum for each student
  foreach (int score in studentScores)
  {
    currentStudentExamSum += score;
    studentSum += score;
  }
  foreach (int score in studentExtraCredit)
  {
    studentSum += (decimal)score / 10;
    currentStudentExtraCreditPoints += score;
    currentStudentExtraCreditScore += (decimal)score / 10;
  }

  // Calculate extra credit points based on how many assignments were completed by student
  currentStudentExtraCreditPoints = currentStudentExtraCreditPoints / currentStudentExtraCreditAssignments;

  // Initialize and calculate current student's final score
  decimal studentScore = (decimal)studentSum / currentAssignments;
  decimal currentStudentExamScore = (decimal)currentStudentExamSum / currentAssignments;

  // Calculate student's letter grade
  if (studentScore >= 97)
    currentStudentLetterGrade = "A+";

  else if (studentScore >= 93)
    currentStudentLetterGrade = "A";

  else if (studentScore >= 90)
    currentStudentLetterGrade = "A-";

  else if (studentScore >= 87)
    currentStudentLetterGrade = "B+";

  else if (studentScore >= 83)
    currentStudentLetterGrade = "B";

  else if (studentScore >= 80)
    currentStudentLetterGrade = "B-";

  else if (studentScore >= 77)
    currentStudentLetterGrade = "C+";

  else if (studentScore >= 73)
    currentStudentLetterGrade = "C";

  else if (studentScore >= 70)
    currentStudentLetterGrade = "C-";

  else if (studentScore >= 67)
    currentStudentLetterGrade = "D+";

  else if (studentScore >= 63)
    currentStudentLetterGrade = "D";

  else if (studentScore >= 60)
    currentStudentLetterGrade = "D-";

  else
    currentStudentLetterGrade = "F";

  Console.WriteLine($"{currentStudent}:\t\t{currentStudentExamScore}\t\t{studentScore}\t{currentStudentLetterGrade}\t{currentStudentExtraCreditPoints} ({studentScore - currentStudentExamScore} pts)");
}

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();