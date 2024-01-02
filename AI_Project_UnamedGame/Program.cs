using Adversarial_Search;

Game Game = new(ShowResultEvent: PrintEvent, PlayerTurnEvent: PlayerTurnEvent);
await Task.Run(() => Game.Play());

return 0;


void PlayerTurnEvent(object? sender, PlayerTurnEventArgs e)
{
    Task.Run(() => Select(e.State, e.AvailablePositions , (sender as Game)!));    
}

void PrintEvent(object? sender, ShowResultEventArgs e)
{
    Console.Clear();
    Print(e.State);    
}


void Select(Player?[,] state, IEnumerable<(int x, int y)> availablePositions, Game game)
{
    Console.Clear();
    Print(state);

    int x, y;
    do
    {
        x = -1;
        y = -1;
        try
        {
            Console.Write("  Row: ");
            var playerChose = Console.ReadLine();
            x = int.Parse(playerChose);
            Console.Write("  Column: ");
            playerChose = Console.ReadLine();
            y = int.Parse(playerChose);
        }
        catch (Exception)
        {
            continue;
        }

    } while (!availablePositions.Contains((x, y)));

    game.OnPlayerSelected((x, y));
}


void Print(Player?[,] State)
{
    for (int i = 0; i < State.GetLength(0); i++)
    {
        for (int j = 0; j < State.GetLength(1); j++)
        {
            if (State[i, j] is null)
                Console.Write("- ");
            else
                Console.Write($"{State[i, j]} ");
        }
        Console.WriteLine();
    }
}
