namespace Adversarial_Search;

public class PlayerTurnEventArgs : EventArgs
{
    public required Player?[,] State { get; set; }
    public required IEnumerable<(int x, int y)> AvailablePositions { get; set; }
}

public class ShowResultEventArgs : EventArgs
{
    public required Player?[,] State { get; set; }
}
