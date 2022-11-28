using ArbusTestsTask;
using FluentAssertions;

namespace ArbusTestTask.UnitTests;

public partial class MenuMasterTests
{
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
}