public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var matrix = new int[size, size];
        Fill(matrix, size, 0, 0, 1);
        return matrix;
    }

    private static void Fill(int[,] matrix, int squareLength, int firstRow, int firstCol, int startValue) {
        if (squareLength <= 0) {
            return;
        }

        if (squareLength == 1) {
            matrix[firstRow, firstCol] = startValue;
            return;
        }

        var lastCol = firstCol + squareLength - 1;
        var lastRow = firstRow + squareLength - 1;
        var value = startValue;

        // top side
        for (var col = firstCol; col < lastCol; col += 1) {
            matrix[firstRow, col] = value;
            value += 1;
        }
        // right side
        for (var row = firstRow; row < lastRow; row += 1) {
            matrix[row, lastCol] = value;
            value += 1;
        }
        // bottom side
        for (var col = lastCol; col > firstCol; col -= 1) {
            matrix[lastRow, col] = value;
            value += 1;
        }
        // left side
        for (var row = lastRow; row > firstRow; row -= 1) {
            matrix[row, firstCol] = value;
            value += 1;
        }

        // recurse to the inner square
        Fill(matrix, squareLength - 2, firstRow + 1, firstCol + 1, value);
    }
}
