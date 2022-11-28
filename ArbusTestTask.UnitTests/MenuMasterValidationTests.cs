using ArbusTestsTask;
using FluentAssertions;

namespace ArbusTestTask.UnitTests;

public partial class MenuMasterTests
{
    [Fact]
    public void MenuMaster_ProvideDishesCollectionAndItemsCountPerPage_Success()
    {
        // act
        var sut = new MenuMaster(MakeDishesCollection(), DishesPerPage);

        // assert
        sut.Should().NotBeNull();
    }

    [Fact]
    public void MenuMaster_DishesCollectionIsNull_ThrowException()
    {
        // act and assert
        Assert.Throws<ArgumentNullException>(() => new MenuMaster(null!, DishesPerPage));  // TODO replace by fluent assertion
    }

    [Fact]
    public void MenuMaster_ProvideEmptyDishesCollection_ThrowException()
    {
        // act and assert
        Assert.Throws<ArgumentException>(() => new MenuMaster(MakeDishesCollection(0), DishesPerPage));  // TODO replace by fluent assertion
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void MenuMaster_ItemsPerPageLessThanOne_ThrowException(int itemsPerPage)
    {
        // act and assert
        Assert.Throws<ArgumentException>(() => new MenuMaster(MakeDishesCollection(), itemsPerPage));  // TODO replace by fluent assertion
    }
}