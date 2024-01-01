using System;

namespace Adversarial_Search;

public class NPCBoard : Board
{
    private static readonly Dictionary<int,int> CachedStates = [];
    private readonly bool IsEnemy;
    private int? Alpha;
    private int? Beta;
    private readonly int? Depth;

    public NPCBoard(Player?[,] state, Player turn, bool isEnemy ,int? alpha ,int? beta , int? depth , (int x, int y)[]? playerXPositions = null, (int x, int y)[]? playerOPositions = null) : base(state,turn , playerXPositions , playerOPositions)
    {
        IsEnemy = isEnemy;
        Alpha = alpha;
        Beta = beta;
        Depth = depth;        
    }

    public static NPCBoard Play(NPCBoard current, (int x , int y) selectedPosition , (int x, int y)[]? PlayerXPositions , (int x, int y)[]? PlayerOPositions)
    {
        var newState = current.State.Play(current.Turn, selectedPosition);
        if (current.Turn == Player.X)
        {
            PlayerXPositions = PlayerXPositions?.Append(selectedPosition).ToArray();
        } else
        {
            PlayerOPositions = PlayerOPositions?.Append(selectedPosition).ToArray();
        }
        return new NPCBoard(newState, current.Turn.Flip(), !current.IsEnemy, current.Alpha, current.Beta, current.Depth - 1, PlayerXPositions, PlayerOPositions);
    }

    public NPCBoard? Select()
    {
        return CalculateValue().selected;
    }

    public int GetValue()
    {
        bool isCached = CachedStates.TryGetValue(State.ToHash(), out int value);
        if (isCached)
        {
            return value;
        } else
        {
            return CalculateValue().value;
        }
    }

    private (NPCBoard? selected , int value) CalculateValue()
    {
        int value;
        NPCBoard? selectedChild = null;

        //reach Max Depth
        if (Depth == 0)
        {
            //Guess value of this State
            Dictionary<Player, int> status = State.GetStatus();
            var thisCount = status[Turn] + new Board(State , Turn).GetAvailablePositions()?.Count() ?? 0;
            var otherCount = status[Turn.Flip()] + new Board(State, Turn.Flip()).GetAvailablePositions()?.Count() ?? 0;

            if (IsEnemy)
            {
                value = otherCount - thisCount;
            } else
            {
                value = thisCount - otherCount;
            }
            CachedStates.TryAdd(State.ToHash(), value);
        } else
        {
            // get children
            var Children = GetChildren()?.ToList();

            //no children = terminal
            if (Children is null || Children.Count == 0)
            {
                //calculate value of this terminal
                Dictionary<Player, int> status = State.GetStatus();
                var thisCount = status[Turn];
                var otherCount = State.Length - thisCount;

                if (IsEnemy)
                {
                    value = otherCount - thisCount;
                } else
                {
                    value = thisCount - otherCount;
                }
                CachedStates.TryAdd(State.ToHash(), value);
            } else
            {
                selectedChild = SelectChild(Children);
                value = selectedChild.GetValue();
                CachedStates.TryAdd(State.ToHash(), value);
            }
        }
        return (selectedChild , value);
    }

    private NPCBoard SelectChild(List<NPCBoard> children)
    {
        if (IsEnemy)
        {
            return children!.MinBy(x => x.GetValue())!;

        } else
        {
            return children!.MaxBy(x => x.GetValue())!;            
        }
    }

    private IEnumerable<NPCBoard>? GetChildren()
    {
        IEnumerable<(int x, int y)> availablePositions = GetAvailablePositions() ?? [];
        foreach (var pos in availablePositions)
        {
            if (Beta is not null && Alpha is not null && Beta <= Alpha)
                break;         
            //var child = new NPCBoard(State.Play(Turn, pos), Turn.Flip(), !IsEnemy , Alpha , Beta, Depth - 1);
            var child = NPCBoard.Play(this, pos , PlayerXPositions,PlayerOPositions);
            if (IsEnemy)
            {
                Beta = Math.Min(child.GetValue(), Beta ?? child.GetValue() + 1);
            } else
            {
                Alpha = Math.Max(child.GetValue(), Alpha ?? child.GetValue() - 1);
            }
            yield return child;
        }
    }    
}

