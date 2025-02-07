using Word_Search;

namespace Word_SearchTests;

[TestClass]
public class GridTests
{
    [TestMethod]
    public void TestCreateGrid()
    {
        // arrange
        char[,] chars = {{'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }};

        // act
        Grid my_grid = new Grid(chars);

        // assert
        Assert.AreEqual(my_grid.getGrid(), chars);
    }

    [TestMethod]
    public void checkCalculatePositions()
    {
        // arrange
        char[,] chars = {{'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' },
                {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }};
        Grid my_grid = new Grid(chars);
        Word my_word = new Word("cat", "F5", "F7");
        (int, int)[] position;
        (int, int)[] expected = [(5, 4), (5, 5), (5, 6)];

        // act
        position = my_grid.calculatePositions(my_word);
        // assert
        Assert.IsTrue(TuplesAreEqual(position, expected));
    }

    private bool TuplesAreEqual((int, int)[] array1, (int, int)[] array2)
    {
        if (array1.Length != array2.Length)
        {
            return false;
        }

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
            {
                return false;
            }
        }

        return true;
    }
}