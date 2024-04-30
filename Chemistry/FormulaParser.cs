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
        var fragments = GetFragments();

        return string.Join(',', fragments
        .Select(fragment => new FragmentParser(fragment).Parse())
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