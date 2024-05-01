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
        var subformulasDatas = GetSubformulas(formula);
        Subformula result = new Subformula();
        foreach (var subformulaData in subformulasDatas)
        {
            var fragments = GetFragments(subformulaData.fragments);
            Subformula subformula = new Subformula(subformulaData.coeff);
            
            foreach (var fragment in fragments)
            {
                subformula.Add(new FragmentParser(fragment).Parse());
            }

            result = result.Join(subformula);
        }

        return result.ToString();
    }

    private IEnumerable<string> GetFragments(string rawFormula) 
    {
        return new Regex(@"([A-Z][a-z]*\d*)").Matches(rawFormula)
                        .Cast<Match>()
                        .Select(match => match.Value)
                        .ToArray();
    }

    private List<(string fragments, int coeff)> GetSubformulas(string rawFormula)
    {
        List<(string fragments, int coeff)> result = new Regex(@"(\(\w*\))\d*").Matches(rawFormula)
            .Cast<Match>()
            .Select(match => new SubformulaParser(match.Value).Parse())
            .ToList();
        result.Add((Regex.Replace(rawFormula, @"(\(\w*\))\d*", ""), 1));
        return result;
    }
}