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

        var sut = new MenuMaster(dishes, dishesPerPage);

        // act
        var result = sut.PagesCount;

        // assert
        result.Should().Be(expectedPagesCount);
    }


    [Theory]
    [InlineData(0, 2, 3, 2)]
    [InlineData(1, 1, 3, 2)]
    [InlineData(1, 2, 4, 2)]
    public void GetDishesCountOnPage_ReturnsDishesOnPage(int page, int expectedDishes, int totalDishes,
        int dishesPerPage)
    {
        // arrange
        var sut = new MenuMaster(MakeDishesCollection(totalDishes), dishesPerPage);

        // act
        var result = sut.GetDishesCountOnPage(page);

        // assert
        result.Should().Be(expectedDishes);
    }

    [Fact]
    public void GetDishesCountOnPage_PageIndexLessThanZero_ThrowException()
    {
        // arrange
        var sut = new MenuMaster(MakeDishesCollection(), DishesPerPage);

        // act
        var action = () => sut.GetDishesCountOnPage(-1);

        // assert
        action.Should().Throw<IndexOutOfRangeException>();
    }

    [Fact]
    public void GetDishesCountOnPage_PageIndexMoreThanPageCount_ThrowException()
    {
        // arrange
        var sut = new MenuMaster(MakeDishesCollection(), DishesPerPage);

        // act
        var action = () => sut.GetDishesCountOnPage(int.MaxValue);

        // assert
        action.Should().Throw<IndexOutOfRangeException>();
    }
}