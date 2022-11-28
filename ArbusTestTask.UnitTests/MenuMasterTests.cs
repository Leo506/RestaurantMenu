using ArbusTestsTask;
using FluentAssertions;

namespace ArbusTestTask.UnitTests;

public class MenuMasterTests
{
    [Fact]
    public void MenuMaster_ProvideDishesCollectionAndItemsCountPerPage_Success()
    {
        // arrange
        var dishes = new List<string>()
        {
            "Dish_1",
            "Dish_2",
            "Dish_3"
        };

        var itemsPerPage = 2;
        
        // act
        var sut = new MenuMaster(dishes, itemsPerPage);
        
        // assert
        sut.Should().NotBeNull();
    }

    [Fact]
    public void MenuMaster_DishesCollectionIsNull_ThrowException()
    {
        // arrange
        const int itemsPerPage = 2;

        // act and assert
        Assert.Throws<ArgumentNullException>(() => new MenuMaster(null!, itemsPerPage));

    }

    [Fact]
    public void MenuMaster_ProvideEmptyDishesCollection_ThrowException()
    {
        // arrange
        var dishes = new List<string>();
        const int itemsPerPage = 2;

        // act and assert
        Assert.Throws<ArgumentException>(() => new MenuMaster(dishes, itemsPerPage));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void MenuMaster_ItemsPerPageLessThanOne_ThrowException(int itemsPerPage)
    {
        // arrange
        var dishes = new List<string>()
        {
            "Dish_1",
            "Dish_2",
            "Dish_3"
        };

        // act and assert
        Assert.Throws<ArgumentException>(() => new MenuMaster(dishes, itemsPerPage));
    }

    [Fact]
    public void Count_ReturnsTotalDishesCount()
    {
        // arrange
        var dishes = new List<string>()
        {
            "Dish_1",
            "Dish_2",
            "Dish_3"
        };
        var expectedResult = dishes.Count;

        var sut = new MenuMaster(dishes, 2);

        // act
        var result = sut.Count;
        
        // assert
        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(5, 2, 3)]
    [InlineData(4, 2, 2)]
    [InlineData(1, 2, 1)]
    public void PagesCount_ReturnsTotalPagesAmount(int dishesCount, int dishesPerPage, int expectedPagesCount)
    {
        // arrange
        var dishes = new List<string>();
        for (var i = 0; i < dishesCount; i++)
        {
            dishes.Add($"Dish_{i}");
        }

        var sut = new MenuMaster(dishes, dishesPerPage);

        // act
        var result = sut.PagesCount;

        // assert
        result.Should().Be(expectedPagesCount);
    }
}