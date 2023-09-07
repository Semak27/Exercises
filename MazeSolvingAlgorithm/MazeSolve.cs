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
        string iterationValue;
        private int maxRowSoFar;
        private int maxColSoFar;
        bool visualOutputOfSolution;

        public MazeSolve(string filePath)
        {
            this.filePath = filePath;
            new MazeDisplay(filePath);
            mazeMatrix = ReadData();
            GetStartingAndEndPos();
            CalculateRoute();
            mazeMatrixOutput = ReadData();
            Backtracking();
        }


        public MazeSolve(string filePath, bool visualOutputOfSolution)
        {
            this.filePath = filePath;
            this.visualOutputOfSolution = visualOutputOfSolution;
            new MazeDisplay(filePath);
            mazeMatrix = ReadData();
            GetStartingAndEndPos();
            CalculateRoute();
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

            //Initializing the starting position with the value 0
            mazeMatrix[startingPos.X, startingPos.Y] = "0";
            iterationValue = "0";

            //Initilizing the maximum row so far with the value of the starting position
            maxRowSoFar = startingPos.X;
            maxColSoFar = startingPos.Y;
        }

        private void CalculateRoute()
        {
            //Calculate a route through the maze with a line of increasing numbers
            int intIterationValue = 0;

            while (currentPos != endPos)
            {

                //Search for all the positions of my current iteration value and saving them in an ArrayList
                ArrayList possiblePositions = GetPositionOfValue(mazeMatrix, iterationValue);
                foreach (Point position in possiblePositions)
                {
                    currentPos = position;
                    if (currentPos == endPos)
                    {
                        break;
                    }

                    //Explore all the positions around my current position and setting the values around
                    CheckSurrounding(currentPos);
                }
                intIterationValue = Convert.ToInt32(iterationValue);
                intIterationValue++;
                iterationValue = intIterationValue.ToString();
            }
        }

        public void CheckSurrounding(Point currentPos)
        {
            Point up = new Point(currentPos.X - 1, currentPos.Y);
            if (up.X < maxRowSoFar)
            {
                maxRowSoFar = up.X;
            }

            Point right = new Point(currentPos.X, currentPos.Y + 1);
            if (right.Y > maxColSoFar)
            {
                maxColSoFar = right.Y;
            }
            Point down = new Point(currentPos.X + 1, currentPos.Y);
            Point left = new Point(currentPos.X, currentPos.Y - 1);
            List<Point> options = new List<Point>() { up, right, down, left };

            int intIterationValue = Convert.ToInt32(iterationValue);

            //Set the values for the positions around my current position if empty
            foreach (Point point in options)
            {
                if (mazeMatrix[point.X, point.Y].Equals(" "))
                {
                    mazeMatrix[point.X, point.Y] = (intIterationValue + 1).ToString();
                }
            }
        }

        public ArrayList GetPositionOfValue(string[,] labyrinthMatrix, string value)
        {
            ArrayList nextSteps = new ArrayList();

            //Search for the positions of the value of my iteration value

            for (int x = maxRowSoFar; x <= numRows - 2; x++)
            {
                for (int y = 1; y <= maxColSoFar; y++)
                {
                    if (mazeMatrix[x, y].Equals(value))
                    {
                        nextSteps.Add(new Point(x, y));
                    }
                }
            }

            return nextSteps;
        }


        //Print function for test purposes
        public void PrintOut(string[,] matrix)
        {
            for (int x = 0; x < numRows; x++)
            {
                for (int y = 0; y < numCols; y++)
                {
                    Console.Write(matrix[x, y]);
                }
                Console.WriteLine();
            }
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

            Console.WriteLine("Moves to solve the maze:");
            for(int i = moves.Length - 1; i >= 0; i--)
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
                return"←";
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
                PrintOut(mazeMatrixOutput);
            }
        }
    }
}
