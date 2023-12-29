using System;

namespace Adversarial_Search;

public class NPCBoard
{
    public int Value { get; private set; }
    public readonly Player?[,] State;
    private readonly Player Turn;
    private readonly bool IsEnemy;
    public List<NPCBoard>? Children { get; set; }

    public NPCBoard(Player?[,] state, Player turn, bool isEnemy)
    {
        State = state;
        Turn = turn;
        IsEnemy = isEnemy;
        Value = CalculateValue();
    }

    public NPCBoard Select()
    {
        return Children!.MaxBy(x => x.Value);
    }

    private int CalculateValue()
    {
        // get children
        Children = GetChildren()?.ToList();

        if (Children is null || Children.Count == 0)
        {
            //calculate value of this terminal
            Dictionary<Player,int> status = State.GetStatus();
            var thisCount = status[Turn];
            var otherCount = State.Length - thisCount;

            if (IsEnemy)
            {
                return otherCount - thisCount;
            } else
            {
                return thisCount - otherCount;
            }
        }

        if (IsEnemy)
        {
            var temp = Children!.MinBy(x => x.Value)!.Value;
            return temp;
        } else
        {
            var temp = Children!.MaxBy(x => x.Value)!.Value;
            return temp;
        }
    }

    private IEnumerable<NPCBoard>? GetChildren()
    {
        IEnumerable<(int x, int y)> availablePositions = GetAvailablePositions() ?? [];

        foreach (var pos in availablePositions)
        {
            yield return new NPCBoard(State.Play(Turn, pos), Turn.Flip(), !IsEnemy);
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
        Player?[,] newState = state.GetCopy();
        newState[selectedPosition.x , selectedPosition.y] = turn;
        return newState;
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

