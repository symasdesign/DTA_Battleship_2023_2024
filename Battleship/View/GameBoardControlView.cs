﻿using Battleship.Controller;
using Battleship.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.View {
    public partial class GameBoardControlView : UserControl, IGameView {
        public BattleshipGameController Controller { get; set; }
        public GameBoardControlView() {
            InitializeComponent();
        }

        public void Update(BattleshipGame game) {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e) {
            var pos = this.tableLayoutPanel1.GetCellPosition((Panel)sender);
            Console.WriteLine($"Shoot at ({pos.Column}/{pos.Row})");

            this.Controller.HandlePlayerInput(new Coordinate(pos.Column, pos.Row));

        }
    }
}
