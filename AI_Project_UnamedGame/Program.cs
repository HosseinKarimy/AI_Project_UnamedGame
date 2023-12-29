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

    var board = new NPCBoard((sender as Game)!.CurrentBoard.State, Player.X, false).Select();
    (sender as Game)!.SetBoard(board);
}

void OEvent(object? sender, EventArgs e)
{
    Console.WriteLine("Player O Turn: ");
    Console.Write("     Row: ");
    var playerChose = Console.ReadLine();
    var x = int.Parse(playerChose);
    Console.Write("     Column: ");
    playerChose = Console.ReadLine();
    var y = int.Parse(playerChose);

    var board = new HumanBoard((sender as Game)!.CurrentBoard.State, (x, y), Player.O);
    (sender as Game)!.SetBoard(board);
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