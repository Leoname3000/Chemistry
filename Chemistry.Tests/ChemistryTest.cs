namespace Chemistry.Tests;

using Chemistry;

public class ChemistryParserUnitTest
{
    [Fact]
    public void ShouldSingleElement()
    {
        Assert.Equal("H:1", FormulaParser.Parse("H"));
        Assert.Equal("C:1", FormulaParser.Parse("C"));
    }

    [Fact]
    public void ShouldSingleElementWithCount()
    {
        Assert.Equal("O:3", FormulaParser.Parse("O3"));
    }

    [Fact]
    public void ShouldSingleElementWithTwoLetters()
    {
        Assert.Equal("He:1", FormulaParser.Parse("He"));
    }

    [Fact]
    public void ShouldSingleElementWithTwoLettersWithMultiNumberCount()
    {
        Assert.Equal("He:20", FormulaParser.Parse("He20"));
    }

    [Fact]
    public void ShouldWater()
    {
        Assert.Equal("H:2,O:1", FormulaParser.Parse("H2O"));
    }

    [Fact]
    public void ShouldParseEthanol()
    {
        Assert.Equal("C:2,H:6,O:1", FormulaParser.Parse("C2H5OH"));
    }

    [Fact(Skip="MakePreviousBefore")]
    public void ShouldParseCopperHydroxide() 
    {
        Assert.Equal("Cu:1,H:2,O:2", FormulaParser.Parse("Cu(OH)2"));
    }
}
