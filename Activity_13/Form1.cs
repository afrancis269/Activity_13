using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity_13
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        public int win_check(int[,] arg)
        {
            bool Oplayer = false, Xplayer = false;
            //check column
            for (int i = 0; i < 3; i++)
            {
                if ((arg[0, i] == arg[1, i]) && (arg[1, i] == arg[2, i]))
                {
                    if (arg[2, i] == 0)
                    {
                        Oplayer = true;
                    }
                    else
                    {
                        Xplayer = true;
                    }
                }
            }

            //check row
            for (int j = 0; j < 3; j++)
            {
                if ((arg[j, 0] == arg[j , 1]) && (arg[j, 1]== arg[j, 2]))
                {
                    if (arg[j, 2] == 0)
                    {
                        Oplayer = true;
                    }
                    else
                    {
                        Xplayer = true;
                    }
                }
            }

            //check diag
            if ((arg[0,0] == arg[1,1]) && (arg[1,1] == arg[2, 2]))
            {
                if (arg[0,0] == 0)
                {
                    Oplayer = true;
                }
                else
                {
                    Xplayer = true;
                }
            }

            if ((Oplayer == true) & (Xplayer==true))
            {
                return 2;
            }else if (Oplayer)
            {
                return 0; //Player O winds
            }
            else
            {
                return 1; //Player X wins
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] arr = new int[3, 3];
            int countX = 0;
            int countO = 0;
            Label[,] display_res = { {Lbx1,Lbx2, Lbx3},
                                       {Lbx4,Lbx5, Lbx6 },
                                       {Lbx7,Lbx8, Lbx9 } };
            
  
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    int seed = new Random().Next(); //more randomness

                    arr[i,j] = new Random(i+j+seed).Next(0,2); //value is between 0 and 1

                    if (arr[i,j] == 1) // 1 means player X
                    {   if (countX >= 4) // 9 / 2 == 4.5
                        {
                            display_res[i, j].Text = "O";
                            countO++;
                        }
                        else
                        {
                            display_res[i, j].Text = "X";
                            countX++;
                        }

                    }
                    else if (arr[i,j] == 0)//0 means player O
                    {
                        if (countO >= 4) // 9 / 2 = 4.5
                        {
                            display_res[i, j].Text = "X";
                            countX++;
                        }
                        else
                        {
                            display_res[i, j].Text = "O";
                            countO++;
                        }

                    }

                }
            }

            if (win_check(arr) == 2)
            {
                ResTxb.Text = "The game is draw";
            }else if (win_check(arr) == 0)
            {
                ResTxb.Text = "Player O wins";
            }
            else
            {
                ResTxb.Text = "Player X wins";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
