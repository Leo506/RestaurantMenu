using ArbusTestsTask;
using FluentAssertions;

namespace ArbusTestTask.UnitTests;

public partial class MenuMasterTests
{
    [Theory]
    [InlineData(5, 2, 3)]
    [InlineData(4, 2, 2)]
    [InlineData(1, 2, 1)]
    public void PagesCount_ReturnsTotalPagesAmount(int dishesCount, int dishesPerPage, int expectedPagesCount)
    {
        // arrange
        var dishes = MakeDishesCollection(dishesCount);

        var sut = new MenuMaster<string>(dishes, dishesPerPage);

        // act
        var result = sut.PagesCount;

        // assert
        result.Should().Be(expectedPagesCount);
    }

    [Fact]
    public void GetFirstDishesOnPages_AllGood_ReturnsFirstDishes()
    {
        // arrange
        var expectedDishesCollection = new List<string>()
        {
            "Dish_0",
            "Dish_2"
        };
        
        var sut = new MenuMaster<string>(MakeDishesCollection(), DishesPerPage);

        // act
        var result = sut.GetFirstDishesOnPages();

        // assert
        result.Should().ContainInOrder(expectedDishesCollection);
    }
}