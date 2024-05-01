using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Chemistry;

public class FormulaParser 
{
    public static string Parse(string formula)
    {
        return new FormulaParser(formula).Parse();
    }

    private readonly string formula;
    private FormulaParser(string formula) 
    {
        this.formula = formula;
    }
    
    private string Parse() 
    {
        var stringFragments = GetFragments();

        Dictionary<string, int> parsedFragments = new Dictionary<string, int>();
        foreach (var stringFragment in stringFragments)
        {
            Fragment parsedFragment = new FragmentParser(stringFragment).Parse();
            if (parsedFragments.ContainsKey(parsedFragment.Element))
                parsedFragments[parsedFragment.Element] += parsedFragment.Count;
            else
                parsedFragments.Add(parsedFragment.Element, parsedFragment.Count);
        }

        return string.Join(',', parsedFragments
        .Select(entry => $"{entry.Key}:{entry.Value}")
        .Order());
    }

    private IEnumerable<string> GetFragments() 
    {
        return new Regex(@"([A-Z][a-z]*\d*)").Matches(formula)
                        .Cast<Match>()
                        .Select(match => match.Value)
                        .ToArray();
    }
}