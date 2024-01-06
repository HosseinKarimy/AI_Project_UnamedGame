namespace WinFormUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Panel_Main = new Panel();
            GroupBox_Status = new GroupBox();
            Label_PlayerBlueItems = new Label();
            Label_RemainingTime = new Label();
            Label_PlayerRedItems = new Label();
            Label_PlayerTurn = new Label();
            label11 = new Label();
            label10 = new Label();
            label8 = new Label();
            label4 = new Label();
            Panel_Game = new Panel();
            GroupBox_Setting = new GroupBox();
            NumericUpDown_PlayerTime = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            ComboBox_StarterPlayer = new ComboBox();
            Button_Reset = new Button();
            label2 = new Label();
            ComboBox_PlayerRedType = new ComboBox();
            Button_Save = new Button();
            NemuricUpDown_BoardSize = new NumericUpDown();
            ComboBox_PlayerBlueType = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            Panel_Main.SuspendLayout();
            GroupBox_Status.SuspendLayout();
            GroupBox_Setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown_PlayerTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NemuricUpDown_BoardSize).BeginInit();
            SuspendLayout();
            // 
            // Panel_Main
            // 
            Panel_Main.Controls.Add(GroupBox_Status);
            Panel_Main.Controls.Add(Panel_Game);
            Panel_Main.Controls.Add(GroupBox_Setting);
            Panel_Main.Location = new Point(12, 12);
            Panel_Main.Name = "Panel_Main";
            Panel_Main.Size = new Size(776, 426);
            Panel_Main.TabIndex = 0;
            // 
            // GroupBox_Status
            // 
            GroupBox_Status.Controls.Add(Label_PlayerBlueItems);
            GroupBox_Status.Controls.Add(Label_RemainingTime);
            GroupBox_Status.Controls.Add(Label_PlayerRedItems);
            GroupBox_Status.Controls.Add(Label_PlayerTurn);
            GroupBox_Status.Controls.Add(label11);
            GroupBox_Status.Controls.Add(label10);
            GroupBox_Status.Controls.Add(label8);
            GroupBox_Status.Controls.Add(label4);
            GroupBox_Status.Location = new Point(3, 290);
            GroupBox_Status.Name = "GroupBox_Status";
            GroupBox_Status.Size = new Size(142, 133);
            GroupBox_Status.TabIndex = 2;
            GroupBox_Status.TabStop = false;
            GroupBox_Status.Text = "Status";
            // 
            // Label_PlayerBlueItems
            // 
            Label_PlayerBlueItems.AutoSize = true;
            Label_PlayerBlueItems.Location = new Point(98, 89);
            Label_PlayerBlueItems.Name = "Label_PlayerBlueItems";
            Label_PlayerBlueItems.Size = new Size(40, 15);
            Label_PlayerBlueItems.TabIndex = 0;
            Label_PlayerBlueItems.Text = "<NA>";
            // 
            // Label_RemainingTime
            // 
            Label_RemainingTime.AutoSize = true;
            Label_RemainingTime.Location = new Point(98, 42);
            Label_RemainingTime.Name = "Label_RemainingTime";
            Label_RemainingTime.Size = new Size(40, 15);
            Label_RemainingTime.TabIndex = 0;
            Label_RemainingTime.Text = "<NA>";
            // 
            // Label_PlayerRedItems
            // 
            Label_PlayerRedItems.AutoSize = true;
            Label_PlayerRedItems.Location = new Point(98, 65);
            Label_PlayerRedItems.Name = "Label_PlayerRedItems";
            Label_PlayerRedItems.Size = new Size(40, 15);
            Label_PlayerRedItems.TabIndex = 0;
            Label_PlayerRedItems.Text = "<NA>";
            // 
            // Label_PlayerTurn
            // 
            Label_PlayerTurn.AutoSize = true;
            Label_PlayerTurn.Location = new Point(98, 18);
            Label_PlayerTurn.Name = "Label_PlayerTurn";
            Label_PlayerTurn.Size = new Size(40, 15);
            Label_PlayerTurn.TabIndex = 0;
            Label_PlayerTurn.Text = "<NA>";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(3, 88);
            label11.Name = "label11";
            label11.Size = new Size(100, 15);
            label11.TabIndex = 0;
            label11.Text = "Player Blue Items:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 65);
            label10.Name = "label10";
            label10.Size = new Size(97, 15);
            label10.TabIndex = 0;
            label10.Text = "Player Red Items:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 42);
            label8.Name = "label8";
            label8.Size = new Size(96, 15);
            label8.TabIndex = 0;
            label8.Text = "Remaining Time:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 19);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 0;
            label4.Text = "Player Turn:";
            // 
            // Panel_Game
            // 
            Panel_Game.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Panel_Game.AutoScroll = true;
            Panel_Game.Location = new Point(151, 3);
            Panel_Game.Name = "Panel_Game";
            Panel_Game.Size = new Size(622, 420);
            Panel_Game.TabIndex = 1;
            // 
            // GroupBox_Setting
            // 
            GroupBox_Setting.Controls.Add(NumericUpDown_PlayerTime);
            GroupBox_Setting.Controls.Add(label6);
            GroupBox_Setting.Controls.Add(label5);
            GroupBox_Setting.Controls.Add(ComboBox_StarterPlayer);
            GroupBox_Setting.Controls.Add(Button_Reset);
            GroupBox_Setting.Controls.Add(label2);
            GroupBox_Setting.Controls.Add(ComboBox_PlayerRedType);
            GroupBox_Setting.Controls.Add(Button_Save);
            GroupBox_Setting.Controls.Add(NemuricUpDown_BoardSize);
            GroupBox_Setting.Controls.Add(ComboBox_PlayerBlueType);
            GroupBox_Setting.Controls.Add(label3);
            GroupBox_Setting.Controls.Add(label1);
            GroupBox_Setting.Location = new Point(3, 3);
            GroupBox_Setting.Name = "GroupBox_Setting";
            GroupBox_Setting.Size = new Size(142, 281);
            GroupBox_Setting.TabIndex = 0;
            GroupBox_Setting.TabStop = false;
            GroupBox_Setting.Text = "Setting";
            // 
            // NumericUpDown_PlayerTime
            // 
            NumericUpDown_PlayerTime.Location = new Point(9, 127);
            NumericUpDown_PlayerTime.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            NumericUpDown_PlayerTime.Name = "NumericUpDown_PlayerTime";
            NumericUpDown_PlayerTime.Size = new Size(121, 23);
            NumericUpDown_PlayerTime.TabIndex = 2;
            NumericUpDown_PlayerTime.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 109);
            label6.Name = "label6";
            label6.Size = new Size(97, 15);
            label6.TabIndex = 0;
            label6.Text = "Player Time(Sec):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 64);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 0;
            label5.Text = "Starter Player:";
            // 
            // ComboBox_StarterPlayer
            // 
            ComboBox_StarterPlayer.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_StarterPlayer.FormattingEnabled = true;
            ComboBox_StarterPlayer.Location = new Point(9, 82);
            ComboBox_StarterPlayer.Name = "ComboBox_StarterPlayer";
            ComboBox_StarterPlayer.Size = new Size(121, 23);
            ComboBox_StarterPlayer.TabIndex = 1;
            // 
            // Button_Reset
            // 
            Button_Reset.Location = new Point(72, 246);
            Button_Reset.Name = "Button_Reset";
            Button_Reset.Size = new Size(60, 23);
            Button_Reset.TabIndex = 3;
            Button_Reset.Text = "Reset";
            Button_Reset.UseVisualStyleBackColor = true;
            Button_Reset.Click += Button_Reset_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 154);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 0;
            label2.Text = "Player Red Type:";
            // 
            // ComboBox_PlayerRedType
            // 
            ComboBox_PlayerRedType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_PlayerRedType.FormattingEnabled = true;
            ComboBox_PlayerRedType.Location = new Point(9, 172);
            ComboBox_PlayerRedType.Name = "ComboBox_PlayerRedType";
            ComboBox_PlayerRedType.Size = new Size(121, 23);
            ComboBox_PlayerRedType.TabIndex = 1;
            // 
            // Button_Save
            // 
            Button_Save.Location = new Point(6, 246);
            Button_Save.Name = "Button_Save";
            Button_Save.Size = new Size(60, 23);
            Button_Save.TabIndex = 3;
            Button_Save.Text = "Save";
            Button_Save.UseVisualStyleBackColor = true;
            Button_Save.Click += Button_Save_Click;
            // 
            // NemuricUpDown_BoardSize
            // 
            NemuricUpDown_BoardSize.Location = new Point(9, 37);
            NemuricUpDown_BoardSize.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            NemuricUpDown_BoardSize.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            NemuricUpDown_BoardSize.Name = "NemuricUpDown_BoardSize";
            NemuricUpDown_BoardSize.Size = new Size(121, 23);
            NemuricUpDown_BoardSize.TabIndex = 2;
            NemuricUpDown_BoardSize.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // ComboBox_PlayerBlueType
            // 
            ComboBox_PlayerBlueType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_PlayerBlueType.FormattingEnabled = true;
            ComboBox_PlayerBlueType.Location = new Point(9, 217);
            ComboBox_PlayerBlueType.Name = "ComboBox_PlayerBlueType";
            ComboBox_PlayerBlueType.Size = new Size(121, 23);
            ComboBox_PlayerBlueType.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 0;
            label3.Text = "Board Size:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 199);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 0;
            label1.Text = "Player Blue Type:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Panel_Main);
            Name = "Form1";
            Text = "Form1";
            Panel_Main.ResumeLayout(false);
            GroupBox_Status.ResumeLayout(false);
            GroupBox_Status.PerformLayout();
            GroupBox_Setting.ResumeLayout(false);
            GroupBox_Setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown_PlayerTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)NemuricUpDown_BoardSize).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel Panel_Main;
        private Panel Panel_Game;
        private GroupBox GroupBox_Setting;
        private NumericUpDown NemuricUpDown_BoardSize;
        private ComboBox ComboBox_PlayerRedType;
        private Label label2;
        private ComboBox ComboBox_PlayerBlueType;
        private Label label3;
        private Label label1;
        private Button Button_Reset;
        private Button Button_Save;
        private GroupBox GroupBox_Status;
        private ComboBox ComboBox_StarterPlayer;
        private Label label5;
        private NumericUpDown NumericUpDown_PlayerTime;
        private Label label6;
        private Label Label_PlayerBlueItems;
        private Label Label_RemainingTime;
        private Label Label_PlayerRedItems;
        private Label Label_PlayerTurn;
        private Label label11;
        private Label label10;
        private Label label8;
        private Label label4;
    }
}
