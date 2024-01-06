using Adversarial_Search;

namespace WinFormUI;

public partial class Form1 : Form
{
    private static Game? Game;

    public Form1()
    {
        InitializeComponent();
        InitialForm();
    }

    private void InitialForm()
    {
        foreach (var item in Enum.GetValues(typeof(Player)))
        {
            ComboBox_StarterPlayer.Items.Add(item);
        }
        foreach (var item in Enum.GetValues(typeof(PlayerType)))
        {
            ComboBox_PlayerBlueType.Items.Add(item);
            ComboBox_PlayerRedType.Items.Add(item);
        }
        ComboBox_StarterPlayer.SelectedIndex = 1;
    }

    private void PlayerTurnEvent(object? sender, PlayerTurnEventArgs e)
    {
        Print(e.State, e.AvailablePositions);
    }

    private void PrintEvent(object? sender, ShowResultEventArgs e)
    {
        Print(e.State, null);
    }

    void Print(Player?[,] State , IEnumerable<(int x, int y)>? availablePositions)
    {
        if (Panel_Main.InvokeRequired)
        {
            Panel_Game.Invoke(new Action(() => Print(State, availablePositions ?? [])));
        } else
        {
            Panel_Game.Controls.Clear();
            TableLayoutPanel matrix = DrawMatrix(State, availablePositions ?? []);
            Panel_Game.Controls.Add(matrix);
           // UpdateStatus(State);
        }
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

    private void Button_Save_Click(object sender, EventArgs e)
    {
        if (Game is null)
        {
            Game = new(ShowResultEvent: PrintEvent, PlayerTurnEvent: PlayerTurnEvent);
            SetSetting();
            Task.Run(() => Game.Play());
        } else
        {
            SetSetting();
        }
    }

    private void SetSetting()
    {
        PlayerType RedType = (PlayerType?)ComboBox_PlayerRedType.SelectedItem ?? PlayerType.NPC;
        PlayerType BlueType = (PlayerType?)ComboBox_PlayerBlueType.SelectedItem ?? PlayerType.Human;
        Player Starter = (Player?)ComboBox_StarterPlayer.SelectedItem ?? Player.O;
        double DeadTime = (double)NumericUpDown_PlayerTime.Value;
        int BoardSize = (int)NemuricUpDown_BoardSize.Value;


        Game!.SetSetting(RedType, BlueType, Starter, DeadTime, BoardSize);
        NemuricUpDown_BoardSize.Enabled = false;
        ComboBox_StarterPlayer.Enabled = false;
    }

    private void Button_Reset_Click(object sender, EventArgs e)
    {

    }
}
