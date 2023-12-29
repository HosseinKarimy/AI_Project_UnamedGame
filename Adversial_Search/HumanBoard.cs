namespace Adversarial_Search;

public class HumanBoard : Board
{
    public HumanBoard(Player?[,] state , (int x , int y) selectedPos , Player turn) : base(state)
    {
        State = state.Play(turn, selectedPos);
    }
}
