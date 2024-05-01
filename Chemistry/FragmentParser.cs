namespace Chemistry;

public class FragmentParser 
{
    private readonly string elementWithCount;
    public FragmentParser(string elementWithCount) 
    {
        this.elementWithCount = elementWithCount;
    }
    
    public Fragment Parse() 
    {  
        return new Fragment(ReadElement(), ReadCount());
    }

    private string ReadElement()
    {
        return elementWithCount.Substring(0, ElementLength());
    }

    private int ReadCount()
    {
        int result = 1;
        if (ElementLength() < elementWithCount.Length)
            Int32.TryParse(elementWithCount.Substring(ElementLength()), out result);
        return result;
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