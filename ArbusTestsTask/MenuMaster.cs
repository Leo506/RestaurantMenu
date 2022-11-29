using Microsoft.VisualBasic;

namespace ArbusTestsTask;

public class MenuMaster  // TODO make generic
{
    public int Count => _dishes.Count();

    public int PagesCount
    {
        get
        {
            var count = _dishes.Count();
            var result = count / _dishesPerPage;
            if (result * _dishesPerPage < count)
                return result + 1;
            return result;
        }
    }

    private readonly IEnumerable<string> _dishes;  // TODO replace by IList
    private readonly int _dishesPerPage;

    public MenuMaster(IEnumerable<string> dishes, int dishesPerPage)
    {
        var dishList = dishes.ToList();
        if (!dishList.Any())
            throw new ArgumentException(ExceptionMessages.EmptyArgument(nameof(dishes)), nameof(dishes));

        if (dishesPerPage < 1)
            throw new ArgumentException(ExceptionMessages.LessThanMinValue(nameof(dishesPerPage), 1),
                nameof(dishesPerPage));

        _dishes = dishList;
        _dishesPerPage = dishesPerPage;
    }

    public int GetDishesCountOnPage(int pageIndex)
    {
        if (pageIndex < 0)
            throw new IndexOutOfRangeException(ExceptionMessages.IncorrectIndex(nameof(pageIndex), PagesCount - 1));

        if (pageIndex > PagesCount - 1)
            throw new IndexOutOfRangeException(ExceptionMessages.IncorrectIndex(nameof(pageIndex), PagesCount - 1));
        
        if (pageIndex != PagesCount - 1) 
            return _dishesPerPage;
        
        var result = Count % _dishesPerPage;
        return result == 0 ? _dishesPerPage : result;
    }

    public IEnumerable<string> GetDishesOnPage(int pageIndex)
    {
        return _dishes.Skip(pageIndex * _dishesPerPage).Take(_dishesPerPage);
    }
}