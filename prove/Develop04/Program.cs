/*
Author: Joshua Walker
Description: Write a mindfulness program that allows the user to relax with three different activities including breathing, reflecting, and listing. These programs continue for as long as the user specifies in seconds. Program ends when the user chooses 5 (quit).
Date: 6/12/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit04/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes

Creativity: I created a fourth option that a user can choose that allows them to open/view their statistics for how many times they completed each activity. I created this feature with the help of another class that handles the functionality of counting each activity after it's used.
*/

using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // create all the instances
        JWBreathingActivity JWBreathingActivity = new JWBreathingActivity("Breathing", "relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing");
        JWReflectingActivity JWReflectingActivity = new JWReflectingActivity("Reflecting", "reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        JWListingActivity JWListingActivity = new JWListingActivity("Listing", "reflect on the good things in your life by having you list as any things as you can in a certain area");
        JWActivityStats JWActivityStats = new JWActivityStats();
        //get user input
        Console.Write("Menu Options:\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. View Activity Stats\n   5. Quit\nSelect a choice from the menu: ");
        string jwUserChoice = Console.ReadLine();
        while (jwUserChoice != "5")
        {
            if (jwUserChoice == "1")
            {
                //breathing activity
                Console.Clear();
                Console.Write(JWBreathingActivity.JWBegin());
                JWBreathingActivity.JWSetDuration(Console.ReadLine());
                JWBreathingActivity.JWGetReady();
                JWBreathingActivity.JWDisplayMiddle();
                JWBreathingActivity.JWFinishProgram();
                JWActivityStats.JWAddCount(jwUserChoice);
            }
            else if (jwUserChoice == "2")
            {
                //refelcting activity
                Console.Clear();
                Console.Write(JWReflectingActivity.JWBegin());
                JWReflectingActivity.JWSetDuration(Console.ReadLine());
                JWReflectingActivity.JWGetReady();
                JWReflectingActivity.JWDisplayMiddle();
                JWReflectingActivity.JWFinishProgram();
                JWActivityStats.JWAddCount(jwUserChoice);
            }
            else if (jwUserChoice == "3")
            {
                //listing activity
                Console.Clear();
                Console.Write(JWListingActivity.JWBegin());
                JWListingActivity.JWSetDuration(Console.ReadLine());
                JWListingActivity.JWGetReady();
                JWListingActivity.JWDisplayMiddle();
                JWListingActivity.JWFinishProgram();
                JWActivityStats.JWAddCount(jwUserChoice);
            }
            else if (jwUserChoice == "4")
            {
                // display stats
                Console.Clear();
                Console.WriteLine("Let's take a look at your stats today!\n");
                Console.WriteLine(JWActivityStats.JWDisplayStats());
                JWListingActivity.JWDisplayAnimation(6);
                Console.Clear();
            }
            Console.Write("Menu Options:\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. View Activity Stats\n   5. Quit\nSelect a choice from the menu: ");
            jwUserChoice = Console.ReadLine();
        }
        Console.WriteLine("Goodbye!");
    }
}