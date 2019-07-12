using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var matrix = new int[size, size];
        for (var col = 0; col < size; col++) {
            for (var row = 0; row < size; row++) {
                matrix[row, col] = 1;
            }
        }

        return matrix;
    }
}
