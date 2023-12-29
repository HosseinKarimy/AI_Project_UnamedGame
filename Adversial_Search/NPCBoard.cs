using System;

namespace Adversarial_Search;

public class NPCBoard : Board
{
    public int Value { get; private set; }
    private readonly Player Turn;
    private readonly bool IsEnemy;
    public NPCBoard SelectedChild { get; set; }

    public NPCBoard(Player?[,] state, Player turn, bool isEnemy) : base(state)
    {
        Turn = turn;
        IsEnemy = isEnemy;
        Value = CalculateValue();
    }

    public NPCBoard Select()
    {
        return SelectedChild;
    }

    private int CalculateValue()
    {
        // get children
        var Children = GetChildren()?.ToList();

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

        SelectedChild = SelectChild(Children);
        return SelectedChild.Value;

    }

    private NPCBoard SelectChild(List<NPCBoard> children)
    {
        if (IsEnemy)
        {
            return children!.MinBy(x => x.Value)!;

        } else
        {
            return children!.MaxBy(x => x.Value)!;            
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

public static class NPCExtensions
{  
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
}

