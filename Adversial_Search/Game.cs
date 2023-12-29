namespace Adversarial_Search;

public class Game
{
    public Board CurrentBoard { get; private set; }
    public Player CurrentTurn { get; private set; } = Player.O;
    public EventHandler Print { get; set; }
    public EventHandler OTurn { get; set; }
    public EventHandler XTurn { get; set; }
    private bool XDone = false;
    private bool ODone = false;

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

        state[2, 2] = Player.X;
        state[0, 3] = Player.O;
        CurrentBoard = new Board(state , CurrentTurn);
    }

    public void Play()
    {
        while (!XDone || !ODone)
        {
            Print.Invoke(CurrentBoard, new EventArgs());
            if (!ODone && CurrentTurn == Player.O)
            {
                OTurn.Invoke(this, new EventArgs());
            } else if(!XDone && CurrentTurn == Player.X)
            {
                XTurn.Invoke(this, new EventArgs());
            }
            CurrentTurn = CurrentTurn.Flip();
        }
        Print.Invoke(CurrentBoard, new EventArgs());
    }

    public void SetState(Player?[,]? State)
    {
        if (State is null)
        {
            if (CurrentTurn == Player.X)
            {
                XDone = true;
            } else
            {
                ODone = true;
            }
            return;
        }
        CurrentBoard = new Board(State,CurrentTurn);
    }

}
