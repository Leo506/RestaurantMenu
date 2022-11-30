using ArbusTestsTask.Exceptions;
using System;

namespace ArbusTestsTask;

public class MenuMaster<T>
{
    public int DishesCount => _dishes.Count;

    public int PagesCount
    {
        get
        {
            var result = _dishes.Count / _dishesPerPage;
            if (result * _dishesPerPage < _dishes.Count)
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
        
        var dishesCount = DishesCount % _dishesPerPage;
        return dishesCount == 0 ? _dishesPerPage : dishesCount;
    }

    public IEnumerable<T> GetDishesOnPage(int pageIndex)
    {
        if (pageIndex < 0 || pageIndex > PagesCount - 1)
            throw new ArgumentOutOfRangeException(nameof(pageIndex));
        
        return _dishes.Skip(pageIndex * _dishesPerPage).Take(_dishesPerPage);
    }

    public IEnumerable<T> GetFirstDishesOnPages()
    {
        var dishes = new List<T>();
        for (var i = 0; i < PagesCount; i++)
        {
            dishes.Add(GetDishesOnPage(i).First());
        }

        return dishes;
    }
}