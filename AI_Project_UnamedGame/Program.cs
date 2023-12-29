using Adversarial_Search;

Game game = new(PrintEvent, OEvent, XEvent);
game.Play();

return 0;


void PrintEvent(object? sender, EventArgs e)
{
    Console.Clear();
    Board board = (sender as Board)!;
    Print(board.State);
}

void XEvent(object? sender, EventArgs e)
{
    Console.WriteLine("Player X Turn: ");

    var game = (sender as Game)!;
    var board = ComputerTurn(Player.X , game.CurrentBoard.State);
    //var board = HumanTurn(Player.X, game.CurrentBoard.State);
    game.SetState(board?.State);
}

void OEvent(object? sender, EventArgs e)
{
    Console.WriteLine("Player O Turn: ");

    var game = (sender as Game)!;
    var board = HumanTurn(Player.O, game.CurrentBoard.State);
    //var board = ComputerTurn(Player.O, game.CurrentBoard.State);
    game.SetState(board?.State);
}

Board? HumanTurn(Player Turn, Player?[,] state)
{
    var board = new Board(state , Turn);
    var Positions = board.GetAvailablePositions();

    if (Positions is null || !Positions.Any())
        return null;

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

    } while (!Positions.Contains((x, y)));

    return new HumanBoard(state, (x, y), Turn);
}

Board? ComputerTurn(Player Turn, Player?[,] state)
{
    return new NPCBoard(state, Turn, false).Select();
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