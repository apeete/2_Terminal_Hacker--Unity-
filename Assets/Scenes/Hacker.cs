using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    //Global Var
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password1;
    string password2;
    string password3;

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
        if (input == "1")
        {
            LevelSet(1);
            password1 = "hi";
        }
        else if (input == "2")
        {
            LevelSet(2);
            password1 = "hey";
        }
        else if (input == "3")
        {
            LevelSet(3);
            password1 = "hello";
        }
        else if (input == "1234")
        {
            Terminal.WriteLine("Loading Declared Thumb War...");
        }
        else
        {
            Terminal.WriteLine("Please provide sufficient user input.");
        }
    }

    void LevelSet(int newLevel) {
        level = newLevel;
        currentScreen = Screen.Password;
        StartGame();
    }

    void StartGame()
    {
        Terminal.WriteLine("You've selected Level " + level);
        Terminal.WriteLine("Please enter your password ▽");
    }

    void CheckPassword (string input)
    {
        if (level == 1 && input == password1) 
        {
            Terminal.WriteLine("Congratulations! Password input correctly.");
        }
        else if (level == 2 && input == password2)
        {
            Terminal.WriteLine("Congratulations! Password input correctly.");
        }
        else if (level == 3 && input == password3)
        {
            Terminal.WriteLine("Congratulations! Password input correctly.");
        }
        else
        {
            Terminal.WriteLine("Incorrect Password. Please try again.");
        }

    }
}
