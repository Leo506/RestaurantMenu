using ArbusTestsTask;
using FluentAssertions;

namespace ArbusTestTask.UnitTests;

public partial class MenuMasterTests
{
    [Fact]
    public void GetDishesOnPage_FullFilledPage_ReturnsDishesOnPage()
    {
        // arrange
        var expectedDishesCollection = new List<string>()
        {
            "Dish_0",
            "Dish_1"
        };

        var sut = new MenuMaster<string>(MakeDishesCollection(), DishesPerPage);

        // act
        var result = sut.GetDishesOnPage(0);

        // assert
        result.Should().ContainInOrder(expectedDishesCollection);
    }

    [Fact]
    public void GetDishesOnPage_PageNotFilled_ReturnsDishesOnPage()
    {
        // arrange
        var expectedDishesCollection = new List<string>()
        {
            "Dish_2",
        };

        var sut = new MenuMaster<string>(MakeDishesCollection(), DishesPerPage);

        // act
        var result = sut.GetDishesOnPage(1);

        // assert
        result.Should().ContainInOrder(expectedDishesCollection);
    }

    [Fact]
    public void GetDishesOnPage_IndexLessThanZero_ThrowException()
    {
        // arrange
        var sut = new MenuMaster<string>(MakeDishesCollection(), DishesPerPage);

        // act
        var action = () => sut.GetDishesOnPage(-1);

        // assert
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GetDishesOnPage_IndexMoreThanMaxPageIndex_ThrowException()
    {
        // arrange
        var sut = new MenuMaster<string>(MakeDishesCollection(), DishesPerPage);

        // act
        var action = () => sut.GetDishesOnPage(int.MaxValue);

        // assert
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}