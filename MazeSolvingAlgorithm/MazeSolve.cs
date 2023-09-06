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
        Point startingPos;
        Point endPos;
        private string[,] labyrinthMatrix;
        Point currentPos;
        string iterationValue;

        public MazeSolve(string filePath)
        {
            this.filePath = filePath;
            new MazeDisplay(filePath);
            labyrinthMatrix = ReadData();
            GetStartingAndEndPos();
            CalculateRoute();
        }

        private string[,] ReadData()
        {
            // Zuerst die Anzahl der Zeilen und Spalten im Labyrinth ermitteln
            numRows = File.ReadLines(filePath).Count();
            numCols = File.ReadAllLines(filePath)[0].Length;

            labyrinthMatrix = new string[numRows, numCols];

            using (StreamReader sr = new StreamReader(filePath))
            {
                for (int row = 0; row < numRows; row++)
                {
                    string? line = sr.ReadLine();

                    for (int col = 0; col < numCols; col++)
                    {
                        // Fülle die Matrix mit den Zeichen aus der Zeile der Textdatei
                        labyrinthMatrix[row, col] = line[col].ToString();
                    }
                }
            }

            return labyrinthMatrix;
        }
        private void GetStartingAndEndPos()
        {
            startingPos = new Point(numRows - 2, 1);
            endPos = new Point(1, numCols - 2);
            labyrinthMatrix[startingPos.X, startingPos.Y] = "0";
            iterationValue = "0";
        }

        private void CalculateRoute()
        {
            while (currentPos != endPos)
            {
                ArrayList possiblePositions = GetPositionOfValue(labyrinthMatrix, iterationValue);
                foreach (Point position in possiblePositions)
                {
                    currentPos = position;
                    if (currentPos == endPos)
                    {
                        break;
                    }
                    CheckSurrounding(currentPos);
                }
                int intIterationValue = Convert.ToInt32(iterationValue);
                intIterationValue++;
                iterationValue = intIterationValue.ToString();
                //PrintOut();
            }
        }

        public void CheckSurrounding(Point currentPos)
        {
            Point up = new Point(currentPos.X - 1, currentPos.Y);
            string valueUp = labyrinthMatrix[up.X, up.Y];
            Point right = new Point(currentPos.X, currentPos.Y + 1);
            string valueRight = labyrinthMatrix[right.X, right.Y];
            Point down = new Point(currentPos.X + 1, currentPos.Y);
            string valueDown = labyrinthMatrix[down.X, down.Y];
            Point left = new Point(currentPos.X, currentPos.Y - 1);
            string valueLeft = labyrinthMatrix[left.X, left.Y];
            List<Point> options = new List<Point>() { up, right, down, left };

            int intIterationValue = Convert.ToInt32(iterationValue);

            foreach (Point point in options)
            {
                if (labyrinthMatrix[point.X, point.Y].Equals(" "))
                {
                    labyrinthMatrix[point.X, point.Y] = (intIterationValue + 1).ToString();
                }
            }
        }

        public ArrayList GetPositionOfValue(string[,] labyrinthMatrix, string value)
        {
            ArrayList nextSteps = new ArrayList();

            for (int x = 0; x < numRows - 1; x++)
            {
                for (int y = 0; y < numCols - 1; y++)
                {
                    if (labyrinthMatrix[x, y].Equals(value))
                    {
                        nextSteps.Add(new Point(x, y));
                    }
                }
            }

            return nextSteps;
        }

        public void PrintOut()
        {
            for (int x = 0; x < numRows; x++)
            {
                for (int y = 0; y < numCols; y++)
                {
                    Console.Write(labyrinthMatrix[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
