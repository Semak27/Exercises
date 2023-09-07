using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolvingAlgorithm
{
    internal class MazeDisplay
    {

        private string filePath;
        private string? content;
        public MazeDisplay(string filePath)
        {
            this.filePath = filePath;
            DrawMaze();
        }
        public void DrawMaze()
        {
            try
            {
                content = File.ReadAllText(filePath);
                //content = content.Replace("#", "■");
                Console.Write("Maze from input:\n");
                Console.WriteLine(content);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while tying to read the file: {e.Message}");
                throw new ArgumentException("Couldn't continue with the programme. Insert a valid file path.");
            }
        }
    }
}
