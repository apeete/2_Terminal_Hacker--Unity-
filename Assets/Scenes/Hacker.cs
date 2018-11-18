using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    //Game Data Structures
    string[] level1Passwords = { "couch", "table", "window", "shelter", "gutter" };
    string[] level2Passwords = { "papaya", "guava", "tomato", "avocado", "pomegranate" };
    string[] level3Passwords = { "airplane", "passport", "international", "security", "destination" };

    //Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;
    static System.Random rnd = new System.Random();
    const string menuHint = "Type 'menu' to return to Main Screen.";


    // Use this for initialization
    void Start () 
    {
        ShowMainMenu();
    }

    void ShowMainMenu () 
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;

        Terminal.WriteLine("Boot sequence initiated...");
        Terminal.WriteLine("Loading BIOS: Hacknagram [Hacker Class] Version 2.0.1");
        Terminal.WriteLine("");
        Terminal.WriteLine("Please select a proper destintation ▽");
        Terminal.WriteLine("[1] The Neighbor's House");
        Terminal.WriteLine("[2] Grocery Store Produce");
        Terminal.WriteLine("[3] Hax International Airport");
        Terminal.WriteLine("");
        Terminal.WriteLine("Input Your Selection: ");
    }
	
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        } 
        else if (currentScreen == Screen.MainMenu) 
        {
            RunMainMenu(input);
        } 
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            Int32.TryParse(input, out level);
            AskForPassword();
        }
        else if (input == "1234")   //easter egg
        {
            Terminal.WriteLine("Loading Declared Thumb War...");
        }
        else
        {
            Terminal.WriteLine("Please provide sufficient user input.");
        }
    }

    //LevelSet(1);
    //int r = rnd.Next(level1Password.Length);
    //password1 = level1Password[r];
            //print(r + ", " + password1);


    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[rnd.Next(level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[rnd.Next(level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[rnd.Next(level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Sorry, invalid level input.");
                Terminal.WriteLine(menuHint);
                break;
        }

    }

    void CheckPassword (string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You got into the neighbor's.");
                Terminal.WriteLine(@"
      ':.
         []_____
        /\      \
    ___/  \__/\__\__
   ||'''| |''||''|''|
   ``'''`'`''))''`''`
"
        );
                break;
            case 2:
                Terminal.WriteLine("You produced some delicious results ;)");
                Terminal.WriteLine(@"
 ,(.
(   )
 `''
"
        );
                break;
            case 3:
                Terminal.WriteLine("Time for a proper getaway.");
                Terminal.WriteLine(@"
,--.                        
|  ,---.  ,--,--.,--.  ,--. 
|  .-.  |' ,-.  | \  `'  /  
|  | |  |\ '-'  | /  /.  \  
`--' `--' `--`--''--'  '--'  
"
        );
                break;
            default:
                Debug.LogError("Error: Invalid level reached.");
                break;
        }

    }
}
