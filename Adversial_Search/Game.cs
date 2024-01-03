namespace Adversarial_Search;

public class Game
{
    private Player?[,] CurrentState;
    private Player CurrentTurn = Player.O;
    private readonly PlayerType PlayerXType = PlayerType.NPC;
    private readonly PlayerType PlayerOType = PlayerType.Human;
    private readonly double DeadTime = 5;
    private readonly int BoardSize = 5;
    private readonly int? Depth = null;

    private EventHandler<ShowResultEventArgs> ShowResultEvent { get; set; }
    private EventHandler<PlayerTurnEventArgs> PlayerTurnEvent { get; set; }
    private bool XDone = false;
    private bool ODone = false;

    private ManualResetEvent manualResetEvent = new(false);

    public Game(EventHandler<ShowResultEventArgs> ShowResultEvent, EventHandler<PlayerTurnEventArgs> PlayerTurnEvent)
    {
        this.ShowResultEvent = ShowResultEvent;
        this.PlayerTurnEvent = PlayerTurnEvent;

            CurrentState = new Player?[BoardSize, BoardSize];
        if (BoardSize % 2 == 0 )
        {
            CurrentState[BoardSize / 2 - 1, BoardSize / 2] = Player.X;
            CurrentState[BoardSize / 2, BoardSize / 2 - 1] = Player.O;
        } else
        {
            CurrentState[0, 0] = Player.X;
            CurrentState[BoardSize-1, BoardSize - 1] = Player.O;
        }
        
    }

    public void Play()
    {
        while (!XDone || !ODone)
        {
            ShowResultEvent.Invoke(this, new ShowResultEventArgs() { State = CurrentState });
            IEnumerable<(int, int)>? availablePositions = new Board(CurrentState, CurrentTurn).GetAvailablePositions();
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
                        CancellationTokenSource cts = new();
                        Task task = Task.Run(() =>
                        {
                            CurrentState = new NPCBoard(CurrentState, CurrentTurn, false, null, null, Depth).Select()!.State;
                        }, cts.Token);

                        if (!task.Wait(TimeSpan.FromSeconds(DeadTime)))
                        {
                            cts.Cancel();
                            CurrentState = NPCBoard.RandomSelect(CurrentState, CurrentTurn)!.State;
                        }
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
                        CancellationTokenSource cts = new();
                        Task task = Task.Run(() =>
                        {
                            CurrentState = new NPCBoard(CurrentState, CurrentTurn, false, null, null, Depth).Select()!.State;
                        }, cts.Token);

                        if (!task.Wait(TimeSpan.FromSeconds(DeadTime)))
                        {
                            cts.Cancel();
                            CurrentState = NPCBoard.RandomSelect(CurrentState, CurrentTurn)!.State;
                        }
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
