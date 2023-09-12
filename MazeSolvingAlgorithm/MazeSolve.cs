using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolvingAlgorithm
{
    public class MazeSolve
    {
        private string filePath;
        private int numRows = 0;
        private int numCols = 0;
        private Point startingPos;
        private Point endPos;
        private string[,] mazeMatrix;
        private string[,] mazeMatrixOutput;
        private Point currentPos;
        private int maxRowSoFar;
        private int maxColSoFar;
        bool visualOutputOfSolution;

        public MazeSolve(string filePath)
        {
            this.filePath = filePath;
            visualOutputOfSolution = true;
            new MazeDisplay(filePath);
            mazeMatrix = ReadData();
            GetStartingAndEndPos();
            CalculateSolution();
            mazeMatrixOutput = ReadData();
            Backtracking();
            VisualOutput();
        }


        public MazeSolve(string filePath, bool visualOutputOfSolution)
        {
            this.filePath = filePath;
            this.visualOutputOfSolution = visualOutputOfSolution;
            new MazeDisplay(filePath);
            mazeMatrix = ReadData();
            GetStartingAndEndPos();
            CalculateSolution();
            mazeMatrixOutput = ReadData();
            Backtracking();
            VisualOutput();
        }

        private string[,] ReadData()
        {
            // Calculate all the rows and the columns of the given maze
            numRows = File.ReadLines(filePath).Count();
            numCols = File.ReadAllLines(filePath)[0].Length;

            //Creating a matrix with the size of the maze
            string[,] mazeMatrix = new string[numRows, numCols];

            using (StreamReader sr = new StreamReader(filePath))
            {
                for (int row = 0; row < numRows; row++)
                {
                    string? line = sr.ReadLine();

                    for (int col = 0; col < numCols; col++)
                    {
                        // Fill the matrix with the values (' ' or '#') of the maze
                        mazeMatrix[row, col] = line[col].ToString();
                    }
                }
            }

            return mazeMatrix;
        }
        private void GetStartingAndEndPos()
        {
            //Initializing the starting and end position
            startingPos = new Point(numRows - 2, 1);
            endPos = new Point(1, numCols - 2);
        }

        private void CalculateSolution()
        {
            currentPos = startingPos;
            CheckPosition(currentPos.X, currentPos.Y, 0);

        }

        private void CheckPosition(int x, int y, int iterationValue)
        {
            //Return if the position is not empty
            if (x < 1 || x >= numRows || y < 1 || y >= numCols || mazeMatrix[x, y] != " ")
            {
                return;
            }

            //Return if the position is the final position
            else if (x == endPos.X && y == endPos.Y)
            {
                mazeMatrix[x, y] = iterationValue.ToString();
                return;
            }

            //Otherwise fill the position with the iterationValue
            else
            {
                mazeMatrix[x, y] = iterationValue.ToString();
            }

            //Up
            CheckPosition(x - 1, y, iterationValue + 1);

            //Right
            CheckPosition(x, y + 1, iterationValue + 1);

            //Down
            CheckPosition(x + 1, y, iterationValue + 1);

            //Left
            CheckPosition(x, y - 1, iterationValue + 1);


        }

        //Backtracking the path through the maze with the given numbers to the positions
        private void Backtracking()
        {
            //Starting at the last position of the maze
            currentPos = endPos;

            //Initializing the first value to search for as one lower than the final position
            int valueToCheckFor = Convert.ToInt32(mazeMatrix[endPos.X, endPos.Y]) - 1;

            //Array to store the moves
            string[] moves = new string[valueToCheckFor + 1];
            int iteration = 0;
            while (currentPos != startingPos)
            {
                //Backpropagating to the previous position
                string move = SearchForPreviousStep(valueToCheckFor.ToString());

                //Storing the position of the previous position in the array
                moves[iteration] = move;

                //Decreasing the value to search for in the next iteration
                valueToCheckFor--;
                iteration++;
            }

            //Print the moves that solve the maze in the correct order
            Console.WriteLine("Moves to solve the maze:");
            for (int i = moves.Length - 1; i >= 0; i--)
            {
                Console.Write(moves[i]);
            }
        }


        private string SearchForPreviousStep(string valueToCheckFor)
        {
            //Coordinates of the positions surrounding the current position
            Point up = new Point(currentPos.X - 1, currentPos.Y);
            Point right = new Point(currentPos.X, currentPos.Y + 1);
            Point down = new Point(currentPos.X + 1, currentPos.Y);
            Point left = new Point(currentPos.X, currentPos.Y - 1);


            //Enabling UTF8 code
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Checking the surrounding positions for the wanted value
            //Writing the move in the maze that will be put out
            //Move to the previous position
            //returning the corresponding move

            if (mazeMatrix[up.X, up.Y].Equals(valueToCheckFor))
            {
                mazeMatrixOutput[up.X, up.Y] = "↓";
                currentPos = up;
                return "↓";
            }
            else if (mazeMatrix[right.X, right.Y].Equals(valueToCheckFor))
            {
                mazeMatrixOutput[right.X, right.Y] = "←";
                currentPos = right;
                return "←";
            }
            else if (mazeMatrix[down.X, down.Y].Equals(valueToCheckFor))
            {
                mazeMatrixOutput[down.X, down.Y] = "↑";
                currentPos = down;
                return "↑";
            }
            else if (mazeMatrix[left.X, left.Y].Equals(valueToCheckFor))
            {
                mazeMatrixOutput[left.X, left.Y] = "→";
                currentPos = left;
                return "→";
            }
            else
            {
                return "Error";
            }

        }

        private void VisualOutput()
        {
            if (visualOutputOfSolution)
            {
                Console.WriteLine("\n\nSolved Maze:");

                //Print the solved matrix with arrows
                for (int x = 0; x < numRows; x++)
                {
                    for (int y = 0; y < numCols; y++)
                    {
                        Console.Write(mazeMatrixOutput[x, y]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}