namespace Adversarial_Search;

public class Board
{
    public Player?[,] State;

    public Board(Player?[,] state)
    {
        State = state;
    }
}

public static class BoardExtensions
{
    public static Player?[,] Play(this Player?[,] state, Player turn, (int x, int y) selectedPosition)
    {
        Player?[,] newState = state.GetCopy();
        newState[selectedPosition.x, selectedPosition.y] = turn;
        return newState;
    }

    public static Player Flip(this Player current)
    {
        return current == Player.X ? Player.O : Player.X;
    }

    public static Dictionary<Player, int> GetStatus(this Player?[,] state)
    {
        var status = new Dictionary<Player, int>();

        foreach (Player value in Enum.GetValues(typeof(Player)))
        {
            status.Add(value, 0);
        }

        foreach (var pos in state)
        {
            if (pos is not null)
            {
                status[(Player)pos]++;
            }
        }
        return status;
    }

    public static Player?[,] GetCopy(this Player?[,] originalState)
    {
        Player?[,] copiedState = new Player?[originalState.GetLength(0), originalState.GetLength(1)];

        for (int i = 0; i < originalState.GetLength(0); i++)
        {
            for (int j = 0; j < originalState.GetLength(1); j++)
            {
                copiedState[i, j] = originalState[i, j];
            }
        }

        return copiedState;
    }
}
