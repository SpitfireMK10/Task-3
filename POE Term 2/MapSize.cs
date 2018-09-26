using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POE_Term_2
{
    public partial class MapSize : Form
    {

        int choice;

        public MapSize()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e) //this will set the game size to 10
        {
            choice = 0;
            Size();
            Form1 game = new Form1();
            game.mapSize1 = this;
            game.Show();
            this.Hide();
        }

        
        private void button1_Click(object sender, EventArgs e) //this will set the game size to 20
        {
            choice = 1;
            Size();
            Form1 game = new Form1();
            game.mapSize1 = this;
            game.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //this will set the game size to 30
        {
            choice = 2;
            Size();
            Form1 game = new Form1();
            game.mapSize1 = this;
            game.Show();
            this.Hide();
        }

        public int Size() // this will determine which choice has been chosen and then assign a value to size 
        {
            int size;

            if (choice == 0)
            {
                return size = 10;
            }
            else if (choice == 1)
            {
                return size = 20;
            }
            else 
            {
                return size = 30;
            }           
        }

        private void MapSize_Load(object sender, EventArgs e)
        {

        }
    }
}
