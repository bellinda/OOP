using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Matrix
{
    class MatrixTesting
    {
        static void Main()
        {
            Matrix<int> myMatrix = new Matrix<int>(2, 2);
            Console.WriteLine(myMatrix[0, 1]);
            myMatrix[0, 0] = 1;
            myMatrix[0, 1] = 2;
            myMatrix[1, 0] = 3;
            myMatrix[1, 1] = -1;
            Matrix<int> myMatrix2 = new Matrix<int>(2, 2);
            myMatrix2[0, 0] = 3;
            myMatrix2[0, 1] = 5;
            myMatrix2[1, 0] = -3;
            myMatrix2[1, 1] = 4;
            Matrix<int> productMatrix = myMatrix + myMatrix2;
            productMatrix = myMatrix - myMatrix2;
            productMatrix = myMatrix * myMatrix2;
            Matrix<int> copyMatrix = productMatrix;
            Console.WriteLine(productMatrix.Equals(myMatrix));
            Console.WriteLine(productMatrix.Equals(productMatrix));
        }
    }
}
