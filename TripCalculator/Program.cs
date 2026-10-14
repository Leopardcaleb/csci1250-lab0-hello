using System.Diagnostics.Tracing;
using System.Net.NetworkInformation;
using System.Transactions;
/*
*Name: Caleb Leopard
*Course: CSCI 1250, Section 001
*Assignment: Lab 04, The Group Trip
*Date: October 13, 2026
*Description: Calculates trup costs and reports pay calculations
*for a group of four people.
*/

const int slices = 8;
const double taxRate = 0.18;


//Part 1: The Trip
Console.Write ("Enter round trip miles:");
int roundTrip=Convert.ToInt32(Console.ReadLine());

Console.Write ("Enter miles per gallon:");
int milesPerGallon = Convert.ToInt32(Console.ReadLine());

Console.Write ("Enter price per gallon:");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("How many pizzas?");
int pizzas = Convert. ToInt32(Console.ReadLine());

Console.WriteLine ("Price per pizza:");
double costPerPizza = Convert.ToDouble(Console.ReadLine());

double fuelCost = FuelCost (roundTrip, milesPerGallon, pricePerGallon);

double pizzaCost = pizzas * costPerPizza;
double tripTotal = fuelCost + pizzaCost;




Console.WriteLine("Fuel cost " + fuelCost.ToString("C"));


Console.WriteLine("Part 1: The Trip");
Console.WriteLine("Fuel cost: " + fuelCost.ToString("C"));
Console.WriteLine("Pizza cost: " + pizzaCost.ToString("C"));
Console.WriteLine("Trip total: " + tripTotal.ToString("C"));

//Part 2: The Group
string[] names = {"Ada", "Grace","Alan","Katherine"};
double[] hoursWorked = {22,15,30,18};
double[] hourlyRates = {13.50, 16.00, 11.20, 14.80};

int people=names.Length;
int totalSlices = pizzas*slices;
double slicesPerPerson = (double)(pizzas*totalSlices) / people;
double costPerPerson = tripTotal/people;


Console.WriteLine("Part 2: The Group");
Console.WriteLine("Slices each: " + slicesPerPerson.ToString("F1"));
Console.WriteLine("Cost per person: " + costPerPerson.ToString("C"));

//Part 3: Who Works How Long
Console.WriteLine(" Part 3: Who Works How Long? ");

Double totalHours = 0;
double totalTakeHomePay = 0;
double longest = 0;

for(int i = 0; i <names.Length; i++)
{
    double takeHome = takeHomePay(hoursWorked[i], hourlyRates[i], taxRate);
    double takeHomePerHour = takeHome / hoursWorked [i];
    double hoursNeeded = hourstoCover(costPerPerson,takeHomePerHour);
    Console.WriteLine($"{names[i]}:takes home {takeHome:C} for " + $"{hoursWorked[i]:F0} hours, {takeHomePerHour:C}" + 
    $"per hour, must work {hoursNeeded:F2} hours");
    totalHours += hoursWorked[i];
    totalTakeHomePay += takeHome;
    longest = Math.Max(longest, hoursNeeded);
}
Console.WriteLine("Total hours worked: " + totalHours.ToString("F0"));
Console.WriteLine("Total take home pay: " +totalTakeHomePay.ToString("C"));
Console.WriteLine("Longest anyone must work: " + longest.ToString("F2"));


//Calculates and returns fuel cost.
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{double gallons = miles / milesPerGallon; return gallons * pricePerGallon; }

//Calculates and returns take home pay after taxes. 
static double takeHomePay(double hours, double hourlyRate, double taxRate)
{double grossPay = hours * hourlyRate; double taxes = grossPay * taxRate; return grossPay - taxes;}
//Calculates and returns the hours needed to cover amount owed.
static double hourstoCover(double amountOwed, double takeHomePerHour)
{return amountOwed / takeHomePerHour;}

