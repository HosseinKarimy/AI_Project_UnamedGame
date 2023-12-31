namespace Adversarial_Search;

public class HumanBoard : Board
{
    public HumanBoard(Player?[,] state , Player turn , (int x, int y)[]? playerXPositions = null, (int x, int y)[]? playerOPositions = null) : base(state,turn , playerXPositions , playerOPositions)
    {        
    }

    public HumanBoard? Select((int x , int y) selectedPos)
    {
        return new HumanBoard(State.Play(Turn, selectedPos), Turn);
    }
}
