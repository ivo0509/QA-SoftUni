using System;
using System.Collections.Generic;

namespace TestApp;

public class Matrix
{
    public static List<List<int>> MatrixAddition(List<List<int>> matrixA, List<List<int>> matrixB)
    {
        if (matrixA.Count == 0 || matrixB.Count == 0)
        {
            return new();
        }

        if (matrixA.Count != matrixB.Count || matrixA[0].Count != matrixB[0].Count)
        {
            throw new ArgumentException("Matrices must have the same dimensions for addition.");
        }

        List<List<int>> result = new();

        for (int i = 0; i < matrixA.Count; i++)
        {
            List<int> row = new();

            for (int j = 0; j < matrixA[0].Count; j++)
            {
                row.Add(matrixA[i][j] + matrixB[i][j]);
            }

            result.Add(row);
        }

        return result;
    }
}
