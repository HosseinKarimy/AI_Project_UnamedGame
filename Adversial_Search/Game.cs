namespace Adversarial_Search;

public class Game
{
    public Board CurrentBoard { get; private set; }
    public Player CurrentTurn { get; private set; } = Player.O;
    public EventHandler Print { get; set; }
    public EventHandler OTurn { get; set; }
    public EventHandler XTurn { get; set; }

    public Game(EventHandler Print, EventHandler OTurn, EventHandler XTurn)           
    {
        this.Print = Print;
        this.OTurn = OTurn;
        this.XTurn = XTurn;
        
        var state = new Player?[4, 4];
        state[2, 1] = Player.X;
        state[1, 2] = Player.O;

        state[1, 1] = Player.X;
        state[1, 3] = Player.O;

        //state[2, 2] = Player.X;
        //state[0, 3] = Player.O;
        CurrentBoard = new Board(state);

    }

    public void Play()
    {
        while (true)
        {
            Print.Invoke(CurrentBoard, new EventArgs());
            if (CurrentTurn == Player.O)
            {
                OTurn.Invoke(this, new EventArgs());
            } else
            {
                XTurn.Invoke(this, new EventArgs());
            }
            CurrentTurn = CurrentTurn.Flip();
        }
    }

    public void SetBoard(Board board)
    {
        CurrentBoard = board;
    }

}
