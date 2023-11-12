public class Board
{
    private int[,] grid = new int[8, 8];
    public int this[int row, int column]
    {
        get => grid[row, column];
    }
}