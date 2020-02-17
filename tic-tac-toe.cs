using System;

namespace tic_tac_toe
{
    class Program
    {   
        static int MATRIX_SIZE = 3;
        //y, x
        //static char[,] matrix = new char[3, 3] {{'1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'}};
        /// <summary>
        /// Matrix array [y, x]
        /// </summary>
        /// <value>Empty matrix</value>
        static char[,] matrix = new char[3, 3] {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '}};
        
        /// <summary>
        /// Prints the matrix.
        /// </summary>
        static void PrintMatrix() 
        {
            for (int y = 0; y < MATRIX_SIZE; y++)
            {
                string line = "";
                for (int x = 0; x < MATRIX_SIZE; x++)
                {
                    //Interpolate string
                    //Console.WriteLine($"[y, x] = {y}, {x}");
                    //Console.Write(matrix[y,x]);
                    line += matrix [y,x] + "|";
                }
                line = line.Substring(0, line.Length - 1);
                Console.WriteLine(line);
                Console.WriteLine("------");
            }
        }
        //Documentacion de un metodo
        /// <summary>
        /// Adds a value to the matrix in the specified position.
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <param name="y">Y position</param>
        /// <param name="x">X Position</param>
        static void AddValue(char value, int y, int x)
        {
            //Necesitamos y, x
            //Necesitamos el valor agregar ("X", "O")
            matrix[y, x] = value;
        }
        static void Main(string[] args)
        {
            PrintMatrix();
            AddValue('X', 0, 0);
            PrintMatrix();
            
        }
    }
}
