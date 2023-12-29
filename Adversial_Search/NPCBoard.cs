using System;

namespace Adversarial_Search;

public class NPCBoard : Board
{
    public int Value { get; private set; }
    private readonly bool IsEnemy;
    public NPCBoard? SelectedChild { get; set; }

    public NPCBoard(Player?[,] state, Player turn, bool isEnemy) : base(state,turn)
    {
        IsEnemy = isEnemy;
        Value = CalculateValue();
    }

    public NPCBoard? Select()
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
}
