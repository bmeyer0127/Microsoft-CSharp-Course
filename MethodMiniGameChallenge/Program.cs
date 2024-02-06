// In this module, you'll develop the following features of a mini-game application:

// A feature to determine if the player consumed the food
// A feature that updates player status depending on the food consumed
// A feature that pauses movement speed depending on the food consumed
// A feature to regenerate food in a new location
// An option to terminate the game if an unsupported character is pressed
// A feature to terminate the game if the Terminal window was resized

// - The code declares the following variables:
// - Variables to determine the size of the Terminal window.
// - Variables to track the locations of the player and food.
// - Arrays `states` and `foods` to provide available player and food appearances
// - Variables to track the current player and food appearance

// - The code provides the following methods:
// - A method to determine if the Terminal window was resized.
// - A method to display a random food appearance at a random location.
// - A method that changes the player appearance to match the food consumed.
// - A method that temporarily freezes the player movement.
// - A method that moves the player according to directional input.
// - A method that sets up the initial game state.

// - The code doesn't call the methods correctly to make the game playable. The following features are missing:
// - Code to determine if the player has consumed the food displayed.
// - Code to determine if the food consumed should freeze player movement.
// - Code to determine if the food consumed should increase player movement.
// - Code to increase movement speed.
// - Code to redisplay the food after it's consumed by the player.
// - Code to terminate execution if an unsupported key is entered.
// - Code to terminate execution if the terminal was resized.

using System;

Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;

// Waiting Icons
string[] waitingIcons = [". ", ".. ", "..."];

// Array that determines if each section of food has been eaten. 
//  True indicates cooresponding food piece has been eaten
bool[] hasBeenEaten = [false, false, false, false, false];

InitializeGame();
while (!shouldExit)
{
  // Checks if terminal resized
  // PROBLEM: The character must move before the app 
  //          realizes that the terminal was resized
  if (TerminalResized())
  {
    Console.Clear();
    foreach (string icon in waitingIcons)
    {
      Console.Write($"Console was resized. Program Exiting{icon}\r");
      System.Threading.Thread.Sleep(750);
    }
    shouldExit = true;
    continue;
  }

  if (IsPlayerHappy())
  {
    Move(movementSpeed: 3);
  }

  Move();

  if (AteFood())
  {
    ChangePlayer();
    ShowFood();
  }
}

// USED METHODS

// Returns true if the Terminal was resized 
bool TerminalResized()
{
  return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

// Displays random food at a random location
void ShowFood()
{
  // Resets food array after first one was eaten
  hasBeenEaten = [false, false, false, false, false];

  // Update food to a random index
  food = random.Next(0, foods.Length);

  // Update food position to a random location
  foodX = random.Next(0, width - player.Length);
  foodY = random.Next(0, height - 1);

  // Display the food at the location
  Console.SetCursorPosition(foodX, foodY);
  Console.Write(foods[food]);
}

// Changes the player to match the food consumed
void ChangePlayer()
{
  player = states[food];
  Console.SetCursorPosition(playerX, playerY);
  Console.Write(player);
}

// Temporarily stops the player from moving
void FreezePlayer()
{
  System.Threading.Thread.Sleep(3000);
  player = states[0];
}

// Reads directional input from the Console and moves the player
void Move(bool endOnNonDirectional = false, int movementSpeed = 1)
{
  int lastX = playerX;
  int lastY = playerY;

  // Freezes player if necessary
  // PROBLEM: Console is still reading and updating player movement. Visuals are just paused
  if (IsPlayerFrozen())
  {
    int savedXCoordinate = playerX;
    int savedYCoordinate = playerY;
    FreezePlayer();
    Console.SetCursorPosition(savedXCoordinate, savedYCoordinate);
  }

  switch (Console.ReadKey(true).Key)
  {
    case ConsoleKey.UpArrow:
      playerY--;
      break;
    case ConsoleKey.DownArrow:
      playerY++;
      break;
    case ConsoleKey.LeftArrow:
      playerX -= movementSpeed;
      break;
    case ConsoleKey.RightArrow:
      playerX += movementSpeed;
      break;
    case ConsoleKey.Escape:
      Console.Clear();
      foreach (string icon in waitingIcons)
      {
        Console.Write($"Esc key was pressed. Program Exiting{icon}\r");
        System.Threading.Thread.Sleep(750);
      }
      shouldExit = true;
      return;
    default:
      if (endOnNonDirectional)
      {
        Console.Clear();
        foreach (string icon in waitingIcons)
        {
          Console.Write($"Non-directional key was pressed. Program Exiting{icon}\r");
          System.Threading.Thread.Sleep(750);
        }
        shouldExit = true;
        return;
      }
      break;
  }

  // Clear the characters at the previous position
  Console.SetCursorPosition(lastX, lastY);
  for (int i = 0; i < player.Length; i++)
  {
    Console.Write(" ");
  }

  // Keep player position within the bounds of the Terminal window
  playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
  playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

  // Draw the player at the new location
  Console.SetCursorPosition(playerX, playerY);
  Console.Write(player);
}

// Determines if player consumed food
bool AteFood()
{
  // Arrays cooresponding to the space that food takes up
  int[] foodXCoordinates = [foodX, foodX + 1, foodX + 2, foodX + 3, foodX + 4];

  // Arrays cooresponding to the space that player takes up
  int[] playerXCoordinates = [playerX, playerX + 1, playerX + 2, playerX + 3, playerX + 4];

  // Changes hasBeenEaten Array for cooresponding index in array
  foreach (int foodXCoordinate in foodXCoordinates)
  {
    foreach (int playerXCoordinate in playerXCoordinates)
    {
      if ((playerXCoordinate == foodXCoordinate) && (playerY == foodY))
      {
        hasBeenEaten[Array.IndexOf(foodXCoordinates, foodXCoordinate)] = true;
      }
    }
  }

  // Returns false if all food has not been eaten. True if it has all been eaten
  if (hasBeenEaten[0] && hasBeenEaten[1] && hasBeenEaten[2] && hasBeenEaten[3] && hasBeenEaten[4])
  {
    return true;
  }
  else
  {
    return false;
  }

}

// Returns true if player is in (X_X) state. This means they should be frozen
bool IsPlayerFrozen()
{
  if (player == states[2])
  {
    return true;
  }
  else
  {
    return false;
  }
}

bool IsPlayerHappy()
{
  if (player == states[1])
  {
    return true;
  }
  else
  {
    return false;
  }
}

// Clears the console, displays the food and player
void InitializeGame()
{
  Console.Clear();
  ShowFood();
  Console.SetCursorPosition(0, 0);
  Console.Write(player);
}

