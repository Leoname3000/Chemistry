namespace Chemistry;

public class Subformula
{
    private readonly Dictionary<string, int> _fragmentsData;

    public Subformula()
    {
        _fragmentsData = new Dictionary<string, int>();
    }

    public void Add(Fragment newFragment)
    {
        if (_fragmentsData.ContainsKey(newFragment.Element))
            _fragmentsData[newFragment.Element] += newFragment.Count;
        else
            _fragmentsData.Add(newFragment.Element, newFragment.Count);
    }
    
    public override string ToString()
    {
        return string.Join(',', _fragmentsData
        .Select(entry => $"{entry.Key}:{entry.Value}")
        .Order());
    }
}