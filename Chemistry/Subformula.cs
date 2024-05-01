namespace Chemistry;

public class Subformula
{
    private readonly Dictionary<string, int> _fragmentsData;
    private readonly int _formulaCoeff;

    public Subformula(int formulaCoeff = 1)
    {
        _fragmentsData = new Dictionary<string, int>();
        _formulaCoeff = formulaCoeff;
    }

    private Subformula(Dictionary<string, int> fragmentsData)
    {
        _fragmentsData = new Dictionary<string, int>(fragmentsData);
    }

    public void Add((string Element, int Count) newFragment)
    {
        if (_fragmentsData.ContainsKey(newFragment.Element))
            _fragmentsData[newFragment.Element] += newFragment.Count * _formulaCoeff;
        else
            _fragmentsData.Add(newFragment.Element, newFragment.Count * _formulaCoeff);
    }

    public Subformula Join(Subformula other)
    {
        var joinFragments = new Dictionary<string, int>(_fragmentsData);
        foreach (var entry in other._fragmentsData)
        {
            if (joinFragments.ContainsKey(entry.Key))
                joinFragments[entry.Key] += entry.Value;
            else
                joinFragments.Add(entry.Key, entry.Value);
        }
        return new Subformula(joinFragments);
    }

    public override string ToString()
    {
        return string.Join(',', _fragmentsData
        .Select(entry => $"{entry.Key}:{entry.Value}")
        .Order());
    }
}