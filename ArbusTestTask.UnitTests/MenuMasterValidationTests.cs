using ArbusTestsTask;
using FluentAssertions;

namespace ArbusTestTask.UnitTests;

public partial class MenuMasterTests
{
    [Fact]
    public void MenuMaster_ProvideDishesCollectionAndItemsCountPerPage_Success()
    {
        // act
        var sut = new MenuMaster<string>(MakeDishesCollection(), DishesPerPage);

        // assert
        sut.Should().NotBeNull();
    }

    [Fact]
    public void MenuMaster_DishesCollectionIsNull_ThrowException()
    {
        // act
        var action = () => new MenuMaster<string>(null!, DishesPerPage);
        
        // assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void MenuMaster_ProvideEmptyDishesCollection_ThrowException()
    {
        // act
        var action = () => new MenuMaster<string>(MakeDishesCollection(0), DishesPerPage);
        
        // assert
        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void MenuMaster_ItemsPerPageLessThanOne_ThrowException(int itemsPerPage)
    {
        // act
        var action = () => new MenuMaster<string>(MakeDishesCollection(), itemsPerPage);
        
        // assert
        action.Should().Throw<ArgumentException>();
    }
}