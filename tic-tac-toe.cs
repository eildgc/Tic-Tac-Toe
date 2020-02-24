﻿using System;

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
                if (y == 0){
                    Console.WriteLine("-----");
                } else if(y == 1) {
                    Console.WriteLine("-----");

                }
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

        
        static void InputRequest()
        {
            Console.WriteLine("Escribe las coordenadas de la forma [y, x] donde quieres hacer tu movimiento");
            Console.WriteLine("Y presiona Enter");
            string userInputCoordinates = Console.ReadLine();

            //Quitar espacios
            userInputCoordinates = userInputCoordinates.Replace(" ", "");

            //Separar en un arreglo de valores con ","
            string[] coordinates = userInputCoordinates.Split(",");

            //Convertir en coordenadas tipo entero
            int y = Convert.ToInt32(coordinates[0]);
            int x = Convert.ToInt32(coordinates[1]);

            AddValue('X', y, x);
        }
        /// <summary>
        /// Este método revisa si los valores X o '0' son 3 en las filas, columnas o diagonales
        /// </summary>
        /// <returns>Regresa un bool que indica si se ha completado una fila, columna o diagonal
        /// con el valor X o '0'</returns>
        static bool CheckThreeLines()
        {
            //Rows
            //matrix [0, 0]
            //matrix [0, 1]
            //matrix [0, 2]
            char value = ' ';
            bool sameValue = true;
            for (int y = 0; y < 3; y++) {    
                value = ' ';
                sameValue = true;
                for (int x = 0; x < 3; x++){
                    if (x == 0)
                    {
                    value = matrix[y,x];
                    }
                    else {
                        sameValue = sameValue && (value == matrix[y,x]);
                   }
                }
                //sameVale determina si son iguales o no
                if (sameValue && value != ' ')
                {
                    return true;
                }
            }

            //Columns
            for (int x = 0; x < 3; x++) {
                value = ' ';
                sameValue = true;
                for (int y = 0; y < 3; y++){
                    if (y == 0)
                    {
                    value = matrix[y,x];
                    }
                    else {
                        sameValue = sameValue && (value == matrix[y,x]);
                   }
                }
                //sameVale determina si son iguales o no
                if (sameValue && value != ' ')
                {
                    return true;
                }
            }

            //Diagoals
            // [0,0] [1,1] [2,2]
            value = ' ';
            sameValue = true;
            for (int i = 0; i < 3; i++){

                if (i == 0){
                    value = matrix[i,i];

                }else {
                    sameValue = sameValue && (value == matrix[i,i]);
                }

                if(i == 2 && sameValue && value !=' '){
                    return true;
                }
             }
            
            // [0,2] [1,1] [2,0]
            value = ' ';
            sameValue = true;
            for (int y = 0; y < 3; y++){
                int x = 2 - y;
                if (y == 0){ //primer iteracion, manejo especial
                    value = matrix[y,x];

                }else {
                    sameValue = sameValue && (value == matrix[y, x]);
                }

                if(y == 2 && sameValue && value !=' '){
                    return true;
                }
             }

            return false;
        }
        static bool IsValueInMatrix(int y, int x)
        {
            bool isEmpty = matrix[y,x] == ' ';
            return !isEmpty;
        }
        static void AIRequest()
        {
            Random r = new Random();
            //Numero entre 0 y 2, va a ser un entero
            //El int entre parentesis transforma un coso a otro
            
            bool validPositionSelected = false;

            int y = 0;
            int x = 0;

            while(!validPositionSelected)
            {
                y = (int)Math.Floor(r.NextDouble() * 3);
                x = Convert.ToInt32(Math.Floor(r.NextDouble() * 3));
                bool isValueDefined = IsValueInMatrix(y,x);

                validPositionSelected = !isValueDefined;    
            }
            
            AddValue ('O', y, x);
        }
        static void Main(string[] args)
        {
            bool gameEnded = false;
            int turns = 0;

            while(!gameEnded)
            {
                InputRequest();
                turns++;
                //Check if user won
                gameEnded = CheckThreeLines();    

                //End after 9 turns
                if (turns >= 9)
                {
                    gameEnded = true;    
                }

                if (!gameEnded) {
                    AIRequest();
                    turns++;
                    
                    //Check if AI won
                    gameEnded = CheckThreeLines();    
                }
                PrintMatrix();                 
            }
            Console.WriteLine("Game over");
            PrintMatrix();
        }
    }
}


