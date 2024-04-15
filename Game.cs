using System.Runtime.CompilerServices;

namespace Classes;

public class Game
{
    /** State of the game */
    public Player?[,] State { get; } = new Player?[3, 3] {
        { null, null, null },
        { null, null, null },
        { null, null, null }
    };

    /** */
    public Player GetNextTurn()
    {
        int countO = 0;
        int countX = 0;
        foreach(Player? player in State) {
            switch (player) {
                case Player.O:
                    countO++;
                    break;
                case Player.X:
                    countX++;
                    break;
            }
        }

        return countO <= countX ? Player.O : Player.X;
    }

    /** Check that a player has three-in-a-row; */
    public Player? GetWinner()
    {
        Player? prev = null;
        // Check rows
        for (int row = 0; row < State.GetLength(0); row++) {
            prev = State[row, 0];
            if  (prev == null) {
                continue;
            }
            for (int col = 1; col < State.GetLength(1); col++) {
                if (State[row,col] == null) {
                    break;
                }
            }
        }


        // Check columns

        // Check diagonals
    }

    public void SubmitTurn(int row, int column, Player player)
    {
        State[row,column] = player;
    }
}