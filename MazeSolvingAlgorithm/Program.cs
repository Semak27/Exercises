﻿// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.IO;
using MazeSolvingAlgorithm;
MazeSolve mazeSolve = new MazeSolve(@"C:\Users\sebas\source\repos\Exercises\ohne Lösung\labyrinth_10_13.txt");
//MazeSolve mazeSolve = new MazeSolve(@"C:\Users\sebas\source\repos\Exercises\ohne Lösung\labyrinth_20_22.txt");
mazeSolve.PrintOut();