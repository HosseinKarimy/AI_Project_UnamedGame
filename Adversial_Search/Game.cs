namespace Adversarial_Search;

public class Game
{
    private Player?[,] CurrentState;
    private Player CurrentTurn = Player.O;
    private readonly double DeadTime = 10;
    private EventHandler<ShowResultEventArgs> ShowResultEvent { get; set; }
    private EventHandler<PlayerTurnEventArgs> PlayerTurnEvent { get; set; }

    private readonly PlayerType PlayerXType = PlayerType.NPC;
    private readonly PlayerType PlayerOType = PlayerType.Human;

    private bool XDone = false;
    private bool ODone = false;

    private ManualResetEvent manualResetEvent = new(false);

    public Game(EventHandler<ShowResultEventArgs> ShowResultEvent, EventHandler<PlayerTurnEventArgs> PlayerTurnEvent)
    {
        this.ShowResultEvent = ShowResultEvent;
        this.PlayerTurnEvent = PlayerTurnEvent;

        int n = 4;
        CurrentState = new Player?[n, n];
        CurrentState[n / 2 - 1, n / 2] = Player.X;
        CurrentState[n / 2, n / 2 - 1] = Player.O;
    }

    public async Task Play()
    {
        while (!XDone || !ODone)
        {
            IEnumerable<(int,int)>? availablePositions = new Board(CurrentState,CurrentTurn).GetAvailablePositions();
            if (CurrentTurn == Player.X)
            {
                if (availablePositions == null || !availablePositions.Any())
                {
                    XDone = true;
                    CurrentTurn = CurrentTurn.Flip();
                } else
                {

                    if (PlayerXType == PlayerType.Human)
                    {
                        PlayerTurnEvent.Invoke(this, new PlayerTurnEventArgs() { AvailablePositions = availablePositions, State = CurrentState });
                        //wait until player select
                        manualResetEvent.Reset();
                        manualResetEvent.WaitOne();
                    } else
                    {
                        CurrentState = new NPCBoard(CurrentState, CurrentTurn,false,null,null,10).Select()!.State;
                        CurrentTurn = CurrentTurn.Flip();
                    }
                }
            } else
            {
                if (availablePositions == null || !availablePositions.Any())
                {
                    ODone = true;
                    CurrentTurn = CurrentTurn.Flip();
                } else
                {
                    if (PlayerOType == PlayerType.Human)
                    {
                        PlayerTurnEvent.Invoke(this, new PlayerTurnEventArgs() { AvailablePositions = availablePositions, State = CurrentState });
                        //wait until player select
                        manualResetEvent.Reset();
                        manualResetEvent.WaitOne();
                    } else
                    {
                        CurrentState = new NPCBoard(CurrentState, CurrentTurn, false, null, null, null).Select()!.State;
                        CurrentTurn = CurrentTurn.Flip();
                    }
                }
            }
        }
        ShowResultEvent.Invoke(this, new ShowResultEventArgs() { State = CurrentState });
    }

    public void OnPlayerSelected((int x, int y) selectedPos)
    {
        var availablePositions = new Board(CurrentState, CurrentTurn).GetAvailablePositions();
        if (availablePositions!.Contains(selectedPos))
        {
            CurrentState = new HumanBoard(CurrentState, CurrentTurn).Select(selectedPos).State;
            CurrentTurn = CurrentTurn.Flip();
        }
        manualResetEvent.Set();
    }

}
