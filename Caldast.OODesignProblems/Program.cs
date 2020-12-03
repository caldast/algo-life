using Caldast.OODesignProblems.TicTacToe;
using Caldast.OODesignProblems.TicTacToe.Controller;
using Caldast.OODesignProblems.TicTacToe.Model.BoardMembers;
using Caldast.OODesignProblems.TicTacToe.Model.Player;
using Caldast.OODesignProblems.TicTacToe.Service;
using Caldast.OODesignProblems.TicTacToe.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Caldast.OODesignProblems
{
    class Program
    {     
       
        public static void Main()
        {
            try
            {
                RunTests();
                SimulateHumanVsMachine(3);
                SimulateMachineVsMachine(3);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void SimulateHumanVsMachine(int size)
        {
            // Initialize service 
            ITicTacToeService ticTacToeService = new TicTacToeService(3);
            
            // Initialize view
            IView consoleView = new ConsoleView();

            // Initialize Controller
            var ticTacToeController = new TicTacToeController(ticTacToeService, consoleView);
            
            // Set up players
            HumanPlayer humanPlayer = new HumanPlayer(ticTacToeService.Board, Symbol.Cross);
            MachinePlayer machinePlayer = new MachinePlayer(ticTacToeService.Board, Symbol.Zero);

            ticTacToeController.SetPlayer1(humanPlayer);
            ticTacToeController.SetPlayer2(machinePlayer);

            // Get input
            Console.WriteLine("Would you like to have a first turn? <Y/N>");
            string s = Console.ReadLine();

            if (s.ToUpper() == "Y")
            {
                ticTacToeController.SetCurrentPlayer(humanPlayer);
            }
            else
            {
                ticTacToeController.SetCurrentPlayer(machinePlayer);
            }
       
            // Start play
            ticTacToeController.Play();

            // Print board
            ticTacToeController.DisplayBoard();         

        }

        public static void SimulateMachineVsMachine(int size)
        {
            ITicTacToeService ticTacToeService = new TicTacToeService(size);
            IView consoleView = new ConsoleView();
            var ticTacToeController = new TicTacToeController(ticTacToeService, consoleView);

            Player machinePlayer1 = new MachinePlayer(ticTacToeService.Board, Symbol.Cross);
            Player machinePlayer2 = new MachinePlayer(ticTacToeService.Board, Symbol.Zero);

            ticTacToeController.SetPlayer1(machinePlayer1);
            ticTacToeController.SetPlayer2(machinePlayer2);

            ticTacToeController.SetCurrentPlayer(machinePlayer1);
         
            ticTacToeController.Play();

            ticTacToeController.DisplayBoard();


        }

        public static void RunTests()
        {
            Test_Human_Player_Wins();
            Test_Machine_Player_Wins();
            Test_GameOver();

        }

        public static void Test_Human_Player_Wins()
        {

            ITicTacToeService ticTacToeService = new TicTacToeService(3);

            HumanPlayer humanPlayer = new HumanPlayer(ticTacToeService.Board, Symbol.Cross);
            MachinePlayer machinePlayer = new MachinePlayer(ticTacToeService.Board, Symbol.Zero);

            ticTacToeService.SetPlayer1(humanPlayer);
            ticTacToeService.SetPlayer2(machinePlayer);

            ticTacToeService.SetCurrentPlayer(humanPlayer);

            // human (0,0)
            ticTacToeService.CurrentPlayer.SetMove(0, 0);

            ticTacToeService.TogglePlayer();

            // machine (1,1)
            ticTacToeService.CurrentPlayer.SetMove(1, 1);

            ticTacToeService.TogglePlayer();

            // human (0,1)
            ticTacToeService.CurrentPlayer.SetMove(0,1);

            ticTacToeService.TogglePlayer();

            // machine (2,1)
            ticTacToeService.CurrentPlayer.SetMove(2, 2);

            ticTacToeService.TogglePlayer();

            // human (0,2)
            ticTacToeService.CurrentPlayer.SetMove(0, 2);

            Assert.AreEqual(true, ticTacToeService.HasWon());
            Assert.AreEqual(humanPlayer, ticTacToeService.Winner);
        }

        public static void Test_Machine_Player_Wins()
        {

            ITicTacToeService ticTacToeService = new TicTacToeService(3);

            HumanPlayer humanPlayer = new HumanPlayer(ticTacToeService.Board, Symbol.Cross);
            MachinePlayer machinePlayer = new MachinePlayer(ticTacToeService.Board, Symbol.Zero);

            ticTacToeService.SetPlayer1(humanPlayer);
            ticTacToeService.SetPlayer2(machinePlayer);

            ticTacToeService.SetCurrentPlayer(humanPlayer);

            // human (0,0)
            ticTacToeService.CurrentPlayer.SetMove(0, 0);

            ticTacToeService.TogglePlayer();

            // machine (0,2)
            ticTacToeService.CurrentPlayer.SetMove(0, 2);

            ticTacToeService.TogglePlayer();

            // human (1,0)
            ticTacToeService.CurrentPlayer.SetMove(1, 0);

            ticTacToeService.TogglePlayer();

            // machine (2,0)
            ticTacToeService.CurrentPlayer.SetMove(2, 0);

            ticTacToeService.TogglePlayer();

            // human (2,1)
            ticTacToeService.CurrentPlayer.SetMove(2, 1);

            ticTacToeService.TogglePlayer();
            
            // machine (1,1)
            ticTacToeService.CurrentPlayer.SetMove(1,1);

            Assert.AreEqual(true, ticTacToeService.HasWon());
            Assert.AreEqual(machinePlayer, ticTacToeService.Winner);
        }


        public static void Test_GameOver()
        {

            ITicTacToeService ticTacToeService = new TicTacToeService(3);

            HumanPlayer humanPlayer = new HumanPlayer(ticTacToeService.Board, Symbol.Cross);
            MachinePlayer machinePlayer = new MachinePlayer(ticTacToeService.Board, Symbol.Zero);

            ticTacToeService.SetPlayer1(humanPlayer);
            ticTacToeService.SetPlayer2(machinePlayer);

            // set current to be machine player
            ticTacToeService.SetCurrentPlayer(humanPlayer);

            // human (0,0)
            ticTacToeService.CurrentPlayer.SetMove(0, 0);

            ticTacToeService.TogglePlayer();

            // machine (0,1)
            ticTacToeService.CurrentPlayer.SetMove(0, 1);

            ticTacToeService.TogglePlayer();

            // human (0,2)
            ticTacToeService.CurrentPlayer.SetMove(0, 2);

            ticTacToeService.TogglePlayer();

            // machine (1,0)
            ticTacToeService.CurrentPlayer.SetMove(1, 0);

            ticTacToeService.TogglePlayer();

            // human (1,1)
            ticTacToeService.CurrentPlayer.SetMove(1, 1);

            ticTacToeService.TogglePlayer();

            // machine (1,2)
            ticTacToeService.CurrentPlayer.SetMove(1, 2);

            ticTacToeService.TogglePlayer();

            // human (2,0)
            ticTacToeService.CurrentPlayer.SetMove(2, 0);

            ticTacToeService.TogglePlayer();

            // machine (2,1)
            ticTacToeService.CurrentPlayer.SetMove(2, 2);

            ticTacToeService.TogglePlayer();

            // machine (2,1)
            ticTacToeService.CurrentPlayer.SetMove(2, 1);

            Assert.AreEqual(false, ticTacToeService.HasWon());
            Assert.AreEqual(null, ticTacToeService.Winner);
            Assert.AreEqual(true, ticTacToeService.IsGameOver());
        }


    }

   


}
