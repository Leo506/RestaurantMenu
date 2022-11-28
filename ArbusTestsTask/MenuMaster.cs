namespace ArbusTestsTask;

public class MenuMaster
{
    public MenuMaster(IEnumerable<string> dishes, int itemsPerPage)
    {
        if (!dishes.Any())
            throw new ArgumentException($"The {nameof(dishes)} parameter can not be empty");

        if (itemsPerPage < 1)
            throw new ArgumentException($"The {nameof(itemsPerPage)} parameter can not be less than 1");
    }
}