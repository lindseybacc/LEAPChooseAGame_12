using Word_Search;

namespace Word_SearchTests;

[TestClass]
public class testInputValidation
{
    [TestMethod]
    public void testUserCoordinatesValid()
    {
        // arrange
        var gameManager = new GameManager();
        string input = "A1";

        // act
        bool result = gameManager.IsValidCoordinate(input);

        // assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void testUserCoordinateInvalid()
    {
        // arrange
        var gameManager = new GameManager();
        string input = "AA";
        string input2 = "1A";   

        // act
        bool result = gameManager.IsValidCoordinate(input);
        bool result2 = gameManager.IsValidCoordinate(input2);

        // assert
        Assert.IsFalse(result);
        Assert.IsFalse(result2);
    }
}
