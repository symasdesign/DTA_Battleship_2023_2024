using Battleship.Controller;
using Battleship.Model;
using Battleship.View;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Battleship {
    internal static class Program {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AllocConsole();

            var game = new BattleshipGame();
            var controller = new BattleshipGameController(game);

            var player1GameBoardView = new GameBoardView(controller);
            //var player2GameBoardView = new GameBoardView(controller);
            var player2GameBoardView = new RemotePlayerView(controller);    
            var gameStatusView = new GameStatusView(controller);

            controller.RegisterView(player1GameBoardView);
            controller.RegisterView(player2GameBoardView);
            controller.RegisterView(gameStatusView);
            var form = new Form1(controller);
            controller.RegisterView(form);

            controller.InitializeGame();


            Application.Run(form);


            do {

                Console.Write("X-Koordinate: ");
                var x = int.Parse(Console.ReadLine());

                Console.Write("Y-Koordinate: ");
                var y = int.Parse( Console.ReadLine());

                controller.HandlePlayerInput(new Coordinate(x,y));
            } while (true);

        }
    }
}