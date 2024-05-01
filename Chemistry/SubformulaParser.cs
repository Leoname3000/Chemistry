namespace Chemistry;

public class SubformulaParser
{
    private readonly string _rawSubformula;
    public SubformulaParser(string rawSubformula)
    {
        _rawSubformula = rawSubformula;
    }

    public (string subformula, int coeff) Parse()
    {
        return (ReadSubstring(), ReadCoeff());
    }

    private string ReadSubstring()
    {
        return _rawSubformula.Substring(1, SubformulaLength());
    }

    private int ReadCoeff()
    {
        int result = 1;
        if (SubformulaLength() + 2 < _rawSubformula.Length)
            Int32.TryParse(_rawSubformula.Substring(SubformulaLength() + 2), out result);
        return result;
    }

    private int SubformulaLength()
    {
        int result = 1;
        while (result < _rawSubformula.Length)
        {
            if (!char.IsLetter(_rawSubformula[result]))
            {
                break;
            }
            result++;
        }

        return result - 1;
    }
}