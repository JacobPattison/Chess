using Chess.Pieces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Chess : Form
    {
        private Game_Manager game_manager;

        private bool isClicked = false;
        private PictureBox previousPictureBox;
        private Color previousPictureBoxColor;
        public Chess()
        {
            InitializeComponent();
        }

        private void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    PictureBox pictureBox = new PictureBox();
                    if((column + row) % 2 == 0)
                    {
                        pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(217)))), ((int)(((byte)(183)))));
                        //pictureBox.BackColor = Color.Pink;
                    }
                    else
                    {
                        pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(137)))), ((int)(((byte)(101)))));
                        //pictureBox.BackColor = Color.Yellow;
                    }
                    pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
                    pictureBox.Location = new System.Drawing.Point(0, 0);
                    pictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    pictureBox.Padding = new System.Windows.Forms.Padding(10);
                    pictureBox.Name = column.ToString() + "," + row.ToString();
                    pictureBox.Size = new System.Drawing.Size(68, 68);
                    pictureBox.TabIndex = 0;
                    pictureBox.TabStop = false;
                    pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pictureBox.Click += new System.EventHandler(this.PictureBox_Click);
                    Board.Controls.Add(pictureBox, column, row);
                }
            }
            showOnMonitor(1);
            game_manager = new Game_Manager();
            UpdateTurnOnForm();
            StartGame();
        }

        private void StartGame()
        {
            game_manager.Pieces = game_manager.CreatePieces();
            UpdatePictureBox();
        }

        private void UpdateTurnOnForm() 
        {
            if (game_manager.SideToMove == 0)
                this.Text = "White To Move";
            if (game_manager.SideToMove == 1)
                this.Text = "Black To Move";
        }

        private void UpdatePictureBox()
        {
            for (int column = 0; column < 8; column++)
            { 
                for (int row = 0; row < 8; row++)
                {
                    if (game_manager.Pieces[column, row] != null)
                    {
                        Control[] controlArray = Board.Controls.Find(column + "," + row, true);
                        PictureBox pictureBox = controlArray[0] as PictureBox;
                        pictureBox.Image = game_manager.Pieces[column, row].Image;
                    }
                }
            }
        }

        public void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

            if (isClicked)
            {
                string[] previousPictureBoxName = previousPictureBox.Name.Split(',');
                int previousPictureBoxColumn = int.Parse(previousPictureBoxName[0]);
                int previousPictureBoxRow = int.Parse(previousPictureBoxName[1]);

                string[] pictureBoxName = pictureBox.Name.Split(',');
                int pictureBoxColumn = int.Parse(pictureBoxName[0]);
                int pictureBoxRow = int.Parse(pictureBoxName[1]);

                var piece = game_manager.Pieces[previousPictureBoxColumn, previousPictureBoxRow];
                if (piece == null) // If it cant find a piece on the square
                {
                    isClicked = false;
                    previousPictureBox.BackColor = previousPictureBoxColor; // Reset the previous colour
                    return;
                }

                if (piece.Move(pictureBoxColumn, pictureBoxRow, game_manager))
                {
                    piece.Row = pictureBoxRow;
                    piece.Column = pictureBoxColumn;
                    game_manager.Pieces[pictureBoxColumn, pictureBoxRow] = game_manager.Pieces[previousPictureBoxColumn, previousPictureBoxRow];
                    game_manager.Pieces[previousPictureBoxColumn, previousPictureBoxRow] = null;
                    //if(game_manager.SideToMove == 0) { game_manager.SideToMove = 1; }
                    //else if (game_manager.SideToMove == 1) { game_manager.SideToMove = 0; }
                    UpdatePictureBox();
                    previousPictureBox.Image = null;
                }

                previousPictureBox.BackColor = previousPictureBoxColor; // Reset the previous colour
                isClicked = false;
            }
            else
            {
                previousPictureBoxColor = pictureBox.BackColor; // Stores the previous square colour
                pictureBox.BackColor = Color.LightYellow; // Sets to the select colour
                previousPictureBox = pictureBox; // Stores the previous picture box
                isClicked = true;
            }
            UpdateTurnOnForm();
        }
    }
}
