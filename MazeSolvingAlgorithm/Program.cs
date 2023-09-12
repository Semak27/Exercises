// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.IO;
using MazeSolvingAlgorithm;
MazeSolve mazeSolve = new MazeSolve(@"C:\Users\sebas\source\repos\Exercises\ohne Lösung\labyrinth_10_13.txt");
//MazeSolve mazeSolve = new MazeSolve(@"C:\Users\sebas\source\repos\Exercises\ohne Lösung\labyrinth_20_22.txt");
//MazeSolve mazeSolve = new MazeSolve(@"C:\Users\sebas\source\repos\Exercises\ohne Lösung\labyrinth_40_22.txt");
//MazeSolve mazeSolve = new MazeSolve(@"C:\Users\sebas\source\repos\Exercises\ohne Lösung\labyrinth_80_89.txt");
//MazeSolve mazeSolve = new MazeSolve(@"C:\Users\sebas\source\repos\Exercises\ohne Lösung\labyrinth_160_113.txt");
//MazeSolve mazeSolve = new MazeSolve(@"C:\Users\sebas\source\repos\Exercises\ohne Lösung\labyrinth_320_242.txt");
//MazeSolve mazeSolve = new MazeSolve(@"C:\Users\sebas\source\repos\Exercises\ohne Lösung\labyrinth_640_542.txt");
mazeSolve.SolveMaze(true);