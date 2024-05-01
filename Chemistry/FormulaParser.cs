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

        Subformula parsedFragments = new Subformula();
        foreach (var stringFragment in stringFragments)
            parsedFragments.Add(new FragmentParser(stringFragment).Parse());

        return parsedFragments.ToString();
    }

    private IEnumerable<string> GetFragments() 
    {
        return new Regex(@"([A-Z][a-z]*\d*)").Matches(formula)
                        .Cast<Match>()
                        .Select(match => match.Value)
                        .ToArray();
    }
}