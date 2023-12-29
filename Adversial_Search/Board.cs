namespace Adversarial_Search;

public class Board
{
    public int Value { get; private set; }
    private readonly Player?[,] State;
    private readonly Player Turn;
    private readonly bool IsEnemy;

    public Board(Player?[,] state, Player turn, bool isEnemy)
    {
        State = state;
        Turn = turn;
        IsEnemy = isEnemy;
        Value = CalculateValue();
    }

    private int CalculateValue()
    {
        // get children
        IEnumerable<Board>? children = GetChildren();

        if (children is null)
        {
            //calculate value of this terminal
            Dictionary<Player,int> status = State.GetStatus();
        }

        if (IsEnemy)
        {
            return children.MinBy(x => x.Value).Value;
        } else
        {
            return children.MaxBy(x => x.Value).Value;
        }
    }

    private IEnumerable<Board>? GetChildren()
    {
        IEnumerable<(int x, int y)> availablePositions = GetAvailablePositions() ?? [];

        foreach (var pos in availablePositions)
        {
            yield return new Board(State.Play(Turn, pos), Turn.Flip(), !IsEnemy);
        }
    }

    private IEnumerable<(int x, int y)>? GetAvailablePositions()
    {
        for (int i = 0; i < State.GetLength(0); i++)
        {
            for (int j = 0; j < State.GetLength(1); j++)
            {
                if (State[i, j] == Turn)
                {
                    foreach (var pos in AllowedNeighborOfPos((i,j)) ?? [])
                    {
                        yield return pos;
                    };
                }
            }
        }
    }

    public IEnumerable<(int x, int y)>? AllowedNeighborOfPos((int x, int y) pos)
    {
        IEnumerable<(int x, int y)> neighbors = pos.GetNeighborsOfPos(State.GetLength(0), State.GetLength(1));
        foreach (var neighbor in neighbors)
        {
            if (State[neighbor.x , neighbor.y] is null)
            {
                yield return neighbor;
            }
        }
    }
}

public static class Extensions
{
    public static Player?[,] Play(this Player?[,] state, Player turn, (int x, int y) selectedPosition)
    {
        throw new NotImplementedException();
    }

    public static Player Flip(this Player current)
    {
        return current == Player.X ? Player.O : Player.X;
    }

    public static IEnumerable<(int x, int y)> GetNeighborsOfPos(this (int x, int y) pos, int rows, int columns)
    {
        //Up
        if (pos.x - 1 >= 0)
        {
            yield return (pos.x - 1, pos.y);
        }

        //Down
        if (pos.x + 1 < rows)
        {
            yield return (pos.x + 1, pos.y);
        }

        //Right
        if (pos.y - 1 >= 0)
        {
            yield return (pos.x, pos.y - 1);
        }

        //Left
        if (pos.y + 1 < columns)
        {
            yield return (pos.x, pos.y + 1);
        }
    }

    public static Dictionary<Player,int> GetStatus(this Player?[,] state)
    {
        var status = new Dictionary<Player, int>();
        foreach (var pos in state)
        {
            if (pos is not null)
            {
                status[(Player)pos]++;
            }
        }
        return status;
    }
}

