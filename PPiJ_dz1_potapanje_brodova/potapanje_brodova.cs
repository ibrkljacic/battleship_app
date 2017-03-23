using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPiJ_dz1_potapanje_brodova
{
    public partial class battleship : Form
    {
        public List<int> takenIndexesUser = new List<int>();
        public List<int> takenIndexesPC = new List<int>();
        Button[] arrayPC = new Button[100];
        Button[] arrayUser = new Button[100];

        public int userBeenHit = 0;
        public int pcBeenHit = 0;
        public int takes = 0;

        public battleship()
        {
            InitializeComponent();
            organizeButtons();
            setTheBoats();
        }

        public void organizeButtons() {
            txtUserName.Text = ">>> Enter Name <<<";
            //Buttons getting indexes
            List<Button> buttonList = new List<Button>();
            foreach (Control c in Controls)
                if (c is Button)
                    buttonList.Add(c as Button);
            buttonList.Reverse(); //Reversing indexes on buttons
            for (int i = 0; i < 200; i++) //Splitting list of Buttons in half (PC vs. USER)
            {
                buttonList.ElementAt(i).BackColor = SystemColors.Control;
                if (i < 100)
                    arrayPC[i] = buttonList.ElementAt(i);
                else
                    arrayUser[i - 100] = buttonList.ElementAt(i);
            }
        }

        public void setTheBoats() {

            Random rand = new Random();
            txtBox.Text = "Game in progress...";
            string[] fleet = { "borbeni", "krstarica", "krstarica", "razarac", "razarac", "razarac", "podmornica", "podmornica", "podmornica", "podmornica" }; //Putting 1x4, 2x3, 3x2, 4x1 boats in each field (10 boats)
            string currentBoat = "";
            int currentPositionUser = 0;
            int currentPositionPC = 0;
            int orientation = 0;

            for (int i = 0; i < 10; i++)
            {
                currentBoat = fleet.ElementAt(i); 
                orientation = rand.Next(0, 2); //0-vertically, 1-horizontally

                switch (currentBoat)
                {
                    case "borbeni":
                        if (orientation == 0)  
                        {
                            currentPositionUser = rand.Next(0, 70);
                            currentPositionPC = rand.Next(0, 70);
                            for (int len = 0; len < 4; len++)
                            {
                                arrayUser[currentPositionUser].BackColor = Color.DarkGray;
                                takenIndexesUser.Add(currentPositionUser);
                                currentPositionUser += 10;
                                takenIndexesPC.Add(currentPositionPC);
                                currentPositionPC += 10;
                            }
                        }
                        else 
                        { 
                            currentPositionUser = rand.Next(0, 100);
                            while (currentPositionUser % 10 > 6 )
                                currentPositionUser = rand.Next(0, 100);
                            currentPositionPC = rand.Next(0, 100);
                            while (currentPositionPC % 10 > 6)
                                currentPositionPC = rand.Next(0, 100);
                            for (int len = 0; len < 4; len++)
                            {
                                arrayUser[currentPositionUser].BackColor = Color.DarkGray;
                                takenIndexesUser.Add(currentPositionUser);
                                currentPositionUser++;
                                takenIndexesPC.Add(currentPositionPC);
                                currentPositionPC++;
                            }
                        }
                        break;

                    case "krstarica":
                        if(orientation == 0) 
                        {
                            currentPositionUser = rand.Next(0, 80);
                            while (takenIndexesUser.Contains(currentPositionUser) || takenIndexesUser.Contains(currentPositionUser + 10) || takenIndexesUser.Contains(currentPositionUser + 20))
                                currentPositionUser = rand.Next(0, 80);
                            currentPositionPC = rand.Next(0, 80);
                            while (takenIndexesPC.Contains(currentPositionPC) || takenIndexesPC.Contains(currentPositionPC + 10) || takenIndexesPC.Contains(currentPositionPC + 20))
                                currentPositionPC = rand.Next(0, 80);
                            for (int len = 0; len < 3; len++)
                            {
                                arrayUser[currentPositionUser].BackColor = Color.DarkGray;
                                takenIndexesUser.Add(currentPositionUser);
                                currentPositionUser += 10;
                                takenIndexesPC.Add(currentPositionPC);
                                currentPositionPC += 10;
                            }
                        }
                        else 
                        {
                            currentPositionUser = rand.Next(0, 100);
                            while (currentPositionUser % 10 > 7 || takenIndexesUser.Contains(currentPositionUser) || takenIndexesUser.Contains(currentPositionUser + 1) || takenIndexesUser.Contains(currentPositionUser + 2))
                                currentPositionUser = rand.Next(0, 100);
                            currentPositionPC = rand.Next(0, 100);
                            while (currentPositionPC % 10 > 7 || takenIndexesPC.Contains(currentPositionPC) || takenIndexesPC.Contains(currentPositionPC + 1) || takenIndexesPC.Contains(currentPositionPC + 2))
                                currentPositionPC = rand.Next(0, 100);
                            for (int len = 0; len < 3; len++)
                            {
                                arrayUser[currentPositionUser].BackColor = Color.DarkGray;
                                takenIndexesUser.Add(currentPositionUser);
                                currentPositionUser++;
                                takenIndexesPC.Add(currentPositionPC);
                                currentPositionPC++;
                            }
                        }
                        break;

                    case "razarac":
                        if (orientation == 0) 
                        {
                            currentPositionUser = rand.Next(0, 90);
                            while (takenIndexesUser.Contains(currentPositionUser) || takenIndexesUser.Contains(currentPositionUser + 10))
                                currentPositionUser = rand.Next(0, 90);
                            currentPositionPC = rand.Next(0, 90);
                            while (takenIndexesPC.Contains(currentPositionPC) || takenIndexesPC.Contains(currentPositionPC + 10))
                                currentPositionPC = rand.Next(0, 90);
                            for (int len = 0; len < 2; len++)
                            {
                                arrayUser[currentPositionUser].BackColor = Color.DarkGray;
                                takenIndexesUser.Add(currentPositionUser);
                                currentPositionUser += 10;
                                takenIndexesPC.Add(currentPositionPC);
                                currentPositionPC += 10;
                            }
                        }
                        else //VODORAVNO
                        {
                            currentPositionUser = rand.Next(0, 100);
                            while (currentPositionUser % 10 > 8 || takenIndexesUser.Contains(currentPositionUser) || takenIndexesUser.Contains(currentPositionUser + 1))
                                currentPositionUser = rand.Next(0, 100);
                            currentPositionPC = rand.Next(0, 100);
                            while (currentPositionPC % 10 > 8 || takenIndexesPC.Contains(currentPositionPC) || takenIndexesPC.Contains(currentPositionPC + 1))
                                currentPositionPC = rand.Next(0, 100);
                            for (int len = 0; len < 2; len++)
                            {
                                arrayUser[currentPositionUser].BackColor = Color.DarkGray;
                                takenIndexesUser.Add(currentPositionUser);
                                currentPositionUser++;

                                takenIndexesPC.Add(currentPositionPC);
                                currentPositionPC++;
                            }
                        }
                        break;

                    case "podmornica":
                        currentPositionUser = rand.Next(0, 100);
                        while (takenIndexesUser.Contains(currentPositionUser))
                            currentPositionUser = rand.Next(0, 100);
                        arrayUser[currentPositionUser].BackColor = Color.DarkGray;
                        takenIndexesUser.Add(currentPositionUser);
                        currentPositionPC = rand.Next(0, 100);
                        while (takenIndexesPC.Contains(currentPositionPC))
                            currentPositionPC = rand.Next(0, 100);
                        takenIndexesPC.Add(currentPositionPC);
                        break;
                }
            }
        }

        public void playGame(object sender, EventArgs e)
        {
            while ((sender as Button).Text != "X") //User can't press twice the same button 
            {
                if (takenIndexesPC.Contains(Array.IndexOf(arrayPC, (sender as Button)))) //User hits PC's boat
                {
                    (sender as Button).BackColor = Color.Red;
                    (sender as Button).Text = "X";
                    (sender as Button).ForeColor = Color.White;
                    pcBeenHit++;
                    txtHitzPc.Text = pcBeenHit.ToString();
                }
                else
                    (sender as Button).Text = "X";
                takes++;
                if (pcBeenHit == takenIndexesPC.Count())    //checks if all boats were hit
                {
                    txtBox.Text = "YOU WON!! (in " +takes+ "  takes)";
                    txtUSERpoints.Text = ((Int32.Parse(txtUSERpoints.Text)) + 1).ToString();
                    for (int b = 0; b < 100; b++)   //locking buttons after victory (only newGame and resetAll available)
                    {
                        arrayPC.ElementAt(b).Enabled = false;
                        arrayUser.ElementAt(b).Enabled = false;
                    }
                    return;
                }
                //PC random guessing
                Random rand = new Random();
                int randIndex = rand.Next(0, 100);
                while (arrayUser.ElementAt(randIndex).Text == "X")
                    randIndex = rand.Next(0, 100);

                if (takenIndexesUser.Contains(randIndex))   //PC hits user's boat
                {
                    arrayUser.ElementAt(randIndex).BackColor = Color.Red;
                    arrayUser.ElementAt(randIndex).Text = "X";
                    arrayUser.ElementAt(randIndex).ForeColor = Color.White;
                    userBeenHit++;
                    txtHitzUser.Text = userBeenHit.ToString();
                }
                else
                    arrayUser.ElementAt(randIndex).Text = "X";

                if (userBeenHit == takenIndexesUser.Count())    //checks if all boats were hit
                {
                    txtBox.Text = "PC WON!!! (in " + takes + " takes)";
                    txtPCpoints.Text = ((Int32.Parse(txtPCpoints.Text))+1).ToString();
                    for( int b=0; b<100; b++)   //locking buttons after victory (only newGame and resetAll available)
                    {
                        arrayPC.ElementAt(b).Enabled = false;
                        arrayUser.ElementAt(b).Enabled = false;
                    }
                    return;
                }
            }
        }

        private void newGame(object sender, EventArgs e)
        {
            txtHitzPc.Text = "0";
            txtHitzUser.Text = "0";
            pcBeenHit = 0;
            userBeenHit = 0;
            takes = 0;
            takenIndexesPC.Clear();
            takenIndexesUser.Clear();

            for (int i = 0; i < 100; i++)
            {
                arrayPC.ElementAt(i).Enabled = true;
                arrayUser.ElementAt(i).Enabled = true;

                arrayPC.ElementAt(i).Text = "";
                arrayPC.ElementAt(i).BackColor = SystemColors.Control;
                arrayPC.ElementAt(i).ForeColor = Color.Black;
                arrayUser.ElementAt(i).Text = "";
                arrayUser.ElementAt(i).BackColor = SystemColors.Control;
                arrayUser.ElementAt(i).ForeColor = Color.Black;
            }
            setTheBoats();
        }

        private void resetAll(object sender, EventArgs e)
        {
            txtUserName.Text = ">>> Enter Name <<<";
            txtPCpoints.Text = "0";
            txtUSERpoints.Text = "0";
            newGame(sender, e);
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
        }
    }
}
