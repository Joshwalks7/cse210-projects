using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        JWBreathingActivity JWBreathingActivity = new JWBreathingActivity("Breathing", "relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing");
        JWReflectingActivity JWReflectingActivity = new JWReflectingActivity("Reflecting", "reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        JWListingActivity JWListingActivity = new JWListingActivity("Listing", "reflect on the good things in your life by having you list as any things as you can in a certain area");
        Console.Write("Menu Options:\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. Quit\nSelect a choice from the menu: ");
        string jwUserChoice = Console.ReadLine();
        while (jwUserChoice != "4")
        {
            if (jwUserChoice == "1")
        {
            Console.Clear();
            Console.Write(JWBreathingActivity.JWBegin());
            JWBreathingActivity.JWSetDuration(Console.ReadLine());
            JWBreathingActivity.JWGetReady();
            JWBreathingActivity.JWDisplayMiddle();
            JWBreathingActivity.JWFinishProgram();
        }
            if (jwUserChoice == "2")
        {
            Console.Clear();
            Console.Write(JWReflectingActivity.JWBegin());
            JWReflectingActivity.JWSetDuration(Console.ReadLine());
            JWReflectingActivity.JWGetReady();
            JWReflectingActivity.JWDisplayMiddle();
            JWReflectingActivity.JWFinishProgram();
        }
            else if (jwUserChoice == "3")
        {
            Console.Clear();
            Console.Write(JWListingActivity.JWBegin());
            JWListingActivity.JWSetDuration(Console.ReadLine());
            JWListingActivity.JWGetReady();
            JWListingActivity.JWDisplayMiddle();
            JWListingActivity.JWFinishProgram();
        }
            Console.Write("Menu Options:\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. Quit\nSelect a choice from the menu: ");
            jwUserChoice = Console.ReadLine();
        }
        

    }
}