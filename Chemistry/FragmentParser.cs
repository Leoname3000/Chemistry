namespace Chemistry;

public class FragmentParser 
{
    private readonly string elementWithCount;
    public FragmentParser(string elementWithCount) 
    {
        this.elementWithCount = elementWithCount;
    }
    
    public string Parse() 
    {  
        return $"{ReadElement()}:{ReadCount()}";
    }

    private string ReadElement()
    {
        return elementWithCount.Substring(0, ElementLength());
    }

    private string ReadCount()
    {
        return ElementLength() < elementWithCount.Length ? elementWithCount.Substring(ElementLength()) : "1";
    }

    private int ElementLength()
    {
        int result = 0;
        while (result < elementWithCount.Length)
        {
            if (char.IsDigit(elementWithCount[result]))
            {
                break;
            }
            result++;
        }

        return result;
    }    
}