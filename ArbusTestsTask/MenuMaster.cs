namespace ArbusTestsTask;

public class MenuMaster
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

    private readonly IEnumerable<string> _dishes;
    private readonly int _dishesPerPage;

    public MenuMaster(IEnumerable<string> dishes, int dishesPerPage)
    {
        var dishList = dishes.ToList();
        if (!dishList.Any())
            throw new ArgumentException($"The {nameof(dishes)} parameter can not be empty");

        if (dishesPerPage < 1)
            throw new ArgumentException($"The {nameof(dishesPerPage)} parameter can not be less than 1");

        _dishes = dishList;
        _dishesPerPage = dishesPerPage;
    }

    public int GetDishesCountOnPage(int pageIndex)
    {
        if (pageIndex < 0)
            throw new IndexOutOfRangeException($"The {nameof(pageIndex)} parameter can not be less than 0");

        if (pageIndex > PagesCount - 1)
            throw new IndexOutOfRangeException(
                $"The {nameof(pageIndex)} parameter can not be more than max page index: {PagesCount - 1}");
        
        if (pageIndex != PagesCount - 1) 
            return _dishesPerPage;
        
        var result = Count % _dishesPerPage;
        return result == 0 ? _dishesPerPage : result;
    }
}