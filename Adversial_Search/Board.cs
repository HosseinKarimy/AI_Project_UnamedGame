﻿namespace Adversarial_Search;

public class Board(Player?[,] state, Player turn, (int x, int y)[]? playerXPositions = null, (int x, int y)[]? playerOPositions = null)
{
    public Player?[,] State { get; set; } = state;
    protected readonly Player Turn = turn;
    public (int x, int y)[]? PlayerXPositions { get; set; } = playerXPositions;
    public (int x, int y)[]? PlayerOPositions { get; set; } = playerOPositions;

    public IEnumerable<(int x, int y)>? GetAvailablePositions() //O(nm)
    {
        if (PlayerXPositions is null || PlayerOPositions is null)
        {
        for (int i = 0; i < State.GetLength(0); i++)
        {
            for (int j = 0; j < State.GetLength(1); j++)
            {
                    if (State[i, j] == Player.X)
                {
                        PlayerXPositions = (PlayerXPositions ??= []).Append((i, j)).ToArray();
                    } else if (State[i, j] == Player.O)
                    {
                        PlayerOPositions = (PlayerOPositions ??= []).Append((i, j)).ToArray();
                    }
                }
            }
        }        

        if (Turn == Player.X)
        {
            foreach (var xPos in PlayerXPositions!)
            {
                foreach (var pos in AllowedNeighborOfPos(xPos) ?? [])
                {
                        yield return pos;
                    };
                }
        } else
        {
            foreach (var xPos in PlayerOPositions!)
            {
                foreach (var pos in AllowedNeighborOfPos(xPos) ?? [])
                {
                    yield return pos;
                };
            }
        }

    }

    private IEnumerable<(int x, int y)>? AllowedNeighborOfPos((int x, int y) pos) //O(1)
    {
        IEnumerable<(int x, int y)> neighbors = pos.GetNeighborsOfPos(State.GetLength(0), State.GetLength(1));
        foreach (var neighbor in neighbors)
        {
            if (State[neighbor.x, neighbor.y] is null)
            {
                yield return neighbor;
            }
        }
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

    public static IEnumerable<(int x, int y)> GetNeighborsOfPos(this (int x, int y) pos, int rows, int columns) //O(1)
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
