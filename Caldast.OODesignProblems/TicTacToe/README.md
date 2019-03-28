<h3>Basic TicTacToe Game</h3>

<p>ITicTacToeService serves as a design contract for Restful API. 
<br/> Following operations are supported. </p>

<ul>
  <li>void SetPlayer1(Player player1); </li>
  <li>void SetPlayer2(Player player2);</li>
  <li>Board Board { get; }</li>
  <li>Player CurrentPlayer { get; }</li>
  <li>bool HasWon();</li>
  <li>Player Winner { get; }</li>
  <li>bool IsGameOver();</li>
  <li>void SetCurrentPlayer(Player player);</li>
  <li>void TogglePlayer();</li>
</ul>
<p>
The solution is structured into Controller, Model and View layers, each layer organized by folders with associated files within.
The starting point is Program.cs and has some helpful code that demonstrates the code path. 
It also has some tests. 
</p>

<span><b>Limitations:</b></span><br/>
There are lots of limitations. <br/>
<ul>
<li>Computer is not intelligent about the moves. Mini-Max algorithm would be preferred. Link here, https://en.wikipedia.org/wiki/Minimax </li>
  <li>State of game is not saved or recovered if lost.</li>
  <li> No proper exception handling or logging </li>
  <li>No UI to show progress of game</li>
  <li>Limited player functionalities such as being able to choose own symbol, customize name etc</li>
</ul>

<p><b>Time spent: </b><br/>
I spent almost 7 hours to build this. Started with design diagram around observer pattern 
but didn't feel like the assignment needed all the complexity. 
</p>
