using ArbusTestsTask;
using FluentAssertions;

namespace ArbusTestTask.UnitTests;

public partial class MenuMasterTests
{
    [Fact]
    public void DishesCount_ReturnsTotalDishesCount()
    {
        // arrange
        var dishes = MakeDishesCollection().ToList();
        var expectedResult = dishes.Count;

        var sut = new MenuMaster<string>(dishes, DishesPerPage);

        // act
        var result = sut.DishesCount;

        // assert
        result.Should().Be(expectedResult);
    }
}