// See https://aka.ms/new-console-template for more information

using ArbusTestsTask;

Console.WriteLine("Creating MenuMaster object with following food collection:");
var food = new List<string>()
{
    "Matcha", 
    "Latte", 
    "Smoothie", 
    "Gin", 
    "Popsicle"
};
Console.Write('\t');
foreach (var item in food)
{
    Console.Write(item + ' ');
}
Console.WriteLine();

var menuMaster = new MenuMaster<string>(food, 2);
Console.WriteLine($"MenuMaster count of dishes: {menuMaster.DishesCount}");

Console.WriteLine($"MenuMaster pages count: {menuMaster.PagesCount}");

Console.WriteLine("Count of food on every page:");
for (var i = 0; i < menuMaster.PagesCount; i++)
{
    Console.WriteLine($"Page {i} - food count: {menuMaster.GetDishesCountOnPage(i)}");
}

Console.WriteLine("Dishes on every page:");
for (var i = 0; i < menuMaster.PagesCount; i++)
{
    Console.Write($"\tPage {i}: ");
    foreach (var dish in menuMaster.GetDishesOnPage(i))
    {
        Console.Write(dish + ' ');
    }
    Console.WriteLine();
}

Console.WriteLine("First dishes on every page:");
foreach (var dish in menuMaster.GetFirstDishesOnPages())
{
    Console.Write(dish + ' ');
}