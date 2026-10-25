using System.Runtime.CompilerServices;

/*
Name: Caleb Leopard
Course: CSCI 1250
Assingment: Lab 06 - Three Short Problems
Date: October 25, 2026
Description: A menu driven program with a grade checker, dice table, and score report. 
*/

const int FirstMenuOption = 1;
const int LastMenuOption = 5;
const int RandomSeed = 4000;
const int NumberOfScores = 5;
const int PassingGrade = 60;
const int QuitOption = 5;
Random rng = new Random(RandomSeed);
int choice;
do {

Console.WriteLine ("1. Grade Checker");
Console.WriteLine ("2. Dice Table");
Console.WriteLine("3. The Score Report");
Console.WriteLine("4. All Three");
Console.WriteLine("5. Quit");
Console.Write("Enter your choice: ");

choice = int.Parse (Console.ReadLine()??"0");
//Repeats until user enters a vlid menu option. 
while (choice < FirstMenuOption || choice > LastMenuOption)
    {
        Console.WriteLine("Invalid choice. Enter 1 through 5.");
        Console.Write("Enter your choice: ");
        choice = int.Parse(Console.ReadLine()?? "0");
    }

//Keep displaying the menu until the user chooses to quit.

if (choice == 1)
 {
    //Propmpts for a score, validates it, and displays the letter grade.
 RunGradeChecker();   
 }
else if (choice == 2)
{
    //Rolls two dice, reports the outcomes, and tracks rolls and wins. 
    runDiceTable(rng);
}
else if (choice == 3)
{
    //Collects five scores and reports total, average, highest and passing count. 
    runScoreReport();
}
else if (choice == 4)
    {
        RunGradeChecker();
        runDiceTable(rng);
        runScoreReport();
    }
else if (choice == 5)
    {
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine("Invalid choice. Enter 1 through 5.");
    }
}while (choice != QuitOption);
static void RunGradeChecker()
{
    Console.WriteLine ("=== The Grade Checker ===");
    Console.WriteLine("Score: ");
    int score = int.Parse(Console.ReadLine()??"0");
    //Repeats until the user enters a score between 0 and 100.
    while (score < 0 || score > 100)
    {
        Console.WriteLine("A score must be between 0 and 100.");
        Console.Write("Score: ");
        score = int.Parse(Console.ReadLine()?? "0");
    }
    if (score>= 90)
    {
        Console.WriteLine($"{score} earns an A.");
    }
    else if (score >= 80)
    {
        Console.WriteLine($"{score} earns an B.");
    }
    else if (score >= 70)
    {
        Console.WriteLine($"{score} earns an C.");
    }
    else if (score >= PassingGrade)
    {
        Console.WriteLine($"{score} earns an D.");
    }
    else
    {
        Console.WriteLine($"{score} earns an F.");
    }
}
    static void runDiceTable(Random rng)
    {
        Console.WriteLine("=== The Dice Table ===");
    int rolls = 0;
    int wins = 0;
    string keepRolling ="y";
    
    //Keep rolling while user enters y.
    while (keepRolling == "y")
    {
    int die1 = rng.Next(1, 7);
    int die2 = rng.Next(1, 7);
    int total = die1 + die2;

    rolls++;

    Console.WriteLine($"Die 1: {die1}");
    Console.WriteLine($"Die 2: {die2}");
    Console.WriteLine($"Total: {total}");
    if (die1 == 1 && die2 ==1)
    {
      Console.WriteLine("Snake eyes!");
    }
       else if (die1 == die2)
    {
            Console.WriteLine("Doubles!");
    }
   else if (total == 7 || total == 11)
    {
        Console.WriteLine("A Winner!");
        wins++;
    }
    Console.WriteLine("Roll again? (y/n:) ");
    keepRolling = Console.ReadLine() ?? "n";
    }
    Console.WriteLine($"Total rolls: {rolls}");
    Console.WriteLine($"Winning rolls: {wins}");
    }
    static void runScoreReport()
{
    Console.WriteLine("=== The Score Report ===");
    int[] scores = new int[NumberOfScores];
    //Ask the user for five scores and store each one.
    //Collects each score and stores it in the array.
    for (int i = 0; i < scores.Length; i++)
    {
        Console.Write($"Enter score {i + 1}: ");
        scores[i]= int.Parse(Console.ReadLine() ?? "0");
    }
    int total = 0;
    int highest = scores[0];
    int passing = 0;
    //Calculates the total, highest score, and number of passing scores. 
    foreach (int score in scores)
    {
        total += score;
        if (score > highest)
        {
            highest = score;
        }
        if (score >= 60)
        {
            passing ++;
        }
    }
    double average = (double)total / scores.Length;

    Console.WriteLine($"Total: {total}");
    Console.WriteLine($"Average: {average:F1}");
    Console.WriteLine($"Highest score: {highest}");
    Console.WriteLine($"Passing scores: {passing} out of {scores.Length}");
}
