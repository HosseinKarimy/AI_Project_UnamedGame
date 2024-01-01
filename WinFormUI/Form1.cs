using Adversarial_Search;
using System.ComponentModel;
using static System.Windows.Forms.AxHost;

namespace WinFormUI;

public partial class Form1 : Form
{
    private static Game Game { get; set; }

    public Form1()
    {
        InitializeComponent();

        Game = new(ShowResultEvent: PrintEvent, PlayerTurnEvent: PlayerTurnEvent);
        Task.Run(() => Game.Play());

        //int n = 6;
        //var state = new Player?[n, n];
        //state[n / 2 - 1, n / 2] = Player.X;
        //state[n / 2, n / 2 - 1] = Player.O;

        //PrintForSelect(state, []);


    }

    private void PlayerTurnEvent(object? sender, PlayerTurnEventArgs e)
    {
        PrintForSelect(e.State, e.AvailablePositions);
    }

    private void PrintEvent(object? sender, ShowResultEventArgs e)
    {        
        Print(e.State);
    }


    private void PrintForSelect(Player?[,] state, IEnumerable<(int x, int y)> availablePositions)
    {
        if (Panel_Main.InvokeRequired)
        {
            Panel_Main.Invoke(new Action(() => PrintForSelect(state, availablePositions)));
        } else
        {
            Panel_Main.Controls.Clear();
            TableLayoutPanel matrix = DrawMatrix(state, availablePositions);
            Panel_Main.Controls.Add(matrix);
        }
    }


    void Print(Player?[,] State)
    {
        
    }

    private static TableLayoutPanel DrawMatrix(Player?[,] state, IEnumerable<(int x, int y)> availablePositions)
    {
        int rows = state.GetLength(0);
        int columns = state.GetLength(1);
        var table = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = rows,
            ColumnCount = columns
        };

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var item = new Panel
                {
                    BackColor = state[i, j] == null ? availablePositions.Contains((i, j)) ? Color.Yellow : Color.Gray : state[i, j] == Player.X ? Color.Red : Color.Blue,
                    Tag = (i, j),
                    Size = new Size(30, 30)
                };
                item.Click += ItemClicked;
                table.Controls.Add(item, i, j);
            }
        }

        return table;
    }

    private static void ItemClicked(object? sender, EventArgs e)
    {
        var selectedPos = ((int x, int y))(sender as Control)!.Tag!;        
        Game.OnPlayerSelected(selectedPos);
    }
}
