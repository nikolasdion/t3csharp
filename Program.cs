// See https://aka.ms/new-console-template for more information
using Classes;

Console.WriteLine("Let's play Tic-Tac-Toe!");

Game game = new Game();
Player? winner = null;


while (winner == null)
{
    PrintGame(game);

    var currentTurn = game.GetNextTurn();
    Console.WriteLine($"Current turn is: {currentTurn}!");

    (int, int)? inputRowCol = null;

    while (inputRowCol == null)
    {
        Console.WriteLine("Please enter row,col of the next move:");
        string? inputRaw = Console.ReadLine();

        if (inputRaw != null)
        {
            var inputSplit = inputRaw.Split(",");
            if (inputSplit.Length == 2)
            {
                try
                {
                    inputRowCol = (int.Parse(inputSplit[0]), int.Parse(inputSplit[1]));
                }
                catch
                {
                    // TODO handle error
                    Console.WriteLine("ERROR, try again");
                }
            }

            if (inputRowCol != null)
            {
                game.SubmitTurn(int.Parse(inputSplit[0]), int.Parse(inputSplit[1]), currentTurn);

            }
        }



    }



    winner = game.GetWinner();
}

PrintGame(game);
// There is a winner, end the game.
Console.WriteLine($"The winner is {winner}!");


static void PrintGame(Game game)
{
    var state = game.State;

    for (int i = 0; i < state.GetLength(0); i++)
    {
        for (int j = 0; j < state.GetLength(1); j++)
        {
            switch (state[i, j])
            {

                case Player.O:
                    Console.Write("O");
                    break;
                case Player.X:
                    Console.Write("X");
                    break;
                case null:
                    Console.Write("-");
                    break;
            }
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}