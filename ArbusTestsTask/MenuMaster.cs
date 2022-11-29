using ArbusTestsTask.Exceptions;
using System;

namespace ArbusTestsTask;

public class MenuMaster<T>
{
    public int Count => _dishes.Count;

    public int PagesCount
    {
        get
        {
            var count = _dishes.Count;
            var result = count / _dishesPerPage;
            if (result * _dishesPerPage < count)
                return result + 1;
            return result;
        }
    }

    private readonly IList<T> _dishes;
    private readonly int _dishesPerPage;

    public MenuMaster(IEnumerable<T> dishes, int dishesPerPage)
    {
        var dishList = dishes.ToList();
        if (!dishList.Any())
            throw new EmptyArgumentException(nameof(dishes));

        if (dishesPerPage < 1)
            throw new ArgumentLessThanMinValueException<int>(nameof(dishesPerPage), 1);

        _dishes = dishList;
        _dishesPerPage = dishesPerPage;
    }

    public int GetDishesCountOnPage(int pageIndex)
    {
        if (pageIndex < 0 || pageIndex > PagesCount - 1)
            throw new ArgumentOutOfRangeException(nameof(pageIndex));

        if (pageIndex != PagesCount - 1) 
            return _dishesPerPage;
        
        var result = Count % _dishesPerPage;
        return result == 0 ? _dishesPerPage : result;
    }

    public IEnumerable<T> GetDishesOnPage(int pageIndex)
    {
        if (pageIndex < 0 || pageIndex > PagesCount - 1)
            throw new ArgumentOutOfRangeException(nameof(pageIndex));
        
        return _dishes.Skip(pageIndex * _dishesPerPage).Take(_dishesPerPage);
    }
}