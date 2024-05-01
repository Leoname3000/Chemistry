namespace Chemistry;

public class Fragment
{
    private readonly string _element;
    private readonly int _count;

    public Fragment(string element, int count)
    {
        _element = element;
        _count = count;
    }

    public string Element => _element;
    public int Count => _count;
}