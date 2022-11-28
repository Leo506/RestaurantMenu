namespace ArbusTestTask.UnitTests;

public partial class MenuMasterTests
{
    private const int DishesPerPage = 2;

    private static IEnumerable<string> MakeDishesCollection(int dishesCount = 3)
    {
        var dishes = new List<string>();
        for (var i = 0; i < dishesCount; i++)
        {
            dishes.Add($"Dish_{i}");
        }

        return dishes;
    }
}