using System;
using Challenges;
using PlayerHelpers;

TicTacToe playerOne = new TicTacToe("X");
TicTacToe playerTwo = new TicTacToe("O");

TicTacToe.RunGame(playerOne, playerTwo);

Console.ReadLine();