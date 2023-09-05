using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolvingAlgorithm
{
    public class MazeDisplay
    {
        string filePath;
        string content;
        int numRows = 0;
        int numCols = 0;
        StreamReader sr;
        char[,] labyrinthMatrix;
        public MazeDisplay(string filePath)
        {
            this.filePath = filePath;
        }

        public char[,]? ReadData()
        {

            try
            {
                //Ausgabe der txt-Datei in der Konsole
                content = File.ReadAllText(filePath);
                content = content.Replace("#", "■");
                Console.WriteLine(content);


                // Zuerst die Anzahl der Zeilen und Spalten im Labyrinth ermitteln
                numRows = File.ReadLines(filePath).Count();
                numCols = File.ReadAllLines(filePath)[0].Length;

                labyrinthMatrix = new char[numRows, numCols];

                using (sr = new StreamReader(filePath))
                {
                    for (int row = 0; row < numRows; row++)
                    {
                        string line = sr.ReadLine();

                        for (int col = 0; col < numCols; col++)
                        {
                            // Fülle die Matrix mit den Zeichen aus der Zeile der Textdatei
                            labyrinthMatrix[row, col] = line[col];
                        }
                    }
                }

                return labyrinthMatrix;

                // Jetzt haben Sie das Labyrinth in einer 2D-Matrix gespeichert
                // Sie können darauf zugreifen, indem Sie labyrinthMatrix[row, col] verwenden
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {e.Message}");
                return null;
            }
        }
    }
}
