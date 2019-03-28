Basic TicTacToe Game

ITicTacToeService serves as a design contract for Restful API. The following operations are supported.

void SetPlayer1(Player player1);
void SetPlayer2(Player player2);
Board Board { get; }
Player CurrentPlayer { get; }
bool HasWon();
Player Winner { get; }
bool IsGameOver();
void SetCurrentPlayer(Player player);
void TogglePlayer();

The solution is structured into Controller, Model and View layers, each layer organized by folders with associated files within.
The starting point is Program.cs and has some helpful code that demonstrates the code path. 
It also has some tests. 


Limitations:
There are lots of limitations. 
a) Computer is not intelligent about the moves. Mini-Max algorithm would be preferred. Link here, https://en.wikipedia.org/wiki/Minimax
b) State of game is not saved or recovered if lost.
c) No proper exception handling or logging 
d) No UI to show progress of game
e) Limited player functionalities such as being able to choose own symbol, customize name etc

Time spent: 
I spent almost 7 hours to build this. Started with design diagram around observer pattern 
but didn't feel like the assignment needed all the complexity. 