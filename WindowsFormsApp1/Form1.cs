/*******************************************************************
 * Coding sample                                                   *
 * Created for Laavu Solutions                                     *
 * Coded by Sari Alila                                             *
 * Date: 27.4.2017                                                 *
 *******************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        //Limiting the amount of stiches and row to keep the program small
        //Can be easily changed here for the entire program
        int maxStiches = 30;
        int maxRows = 25;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void create_button_Click(object sender, EventArgs e)
        {
            //Test to see if reading user input works
            //MessageBox.Show(this.userInputForStiches.Text + " and " + this.userInputForRows.Text);

            //int variables for the stiches and rows, which are acquired from the user
            //set to zero
            int userDefinedStiches = 0;
            int userDefinedRows = 0;

            //Try parsing the text from the two TextBoxes to int
            //If the input is not a number, show message prompting to enter a number (int)

            /************* FOR TESTING*********************
            String silmukat = userInputForStiches.Text;
            MessageBox.Show("silmukat:" + silmukat);
            bool IsStichesANumber = Int32.TryParse(silmukat, out userDefinedStiches);
            MessageBox.Show("bool:" + IsStichesANumber);
            ************ FOR TESTING**********************/


            //Checking if the given number is valid.
            //The number cannot be negative, nor zero. The number cannot be too large either
            //Show message prompting to check the number with some instructions
            if (!(Int32.TryParse(userInputForStiches.Text, out userDefinedStiches)) || userDefinedStiches <= 0 || userDefinedStiches > maxStiches)
            {
                MessageBox.Show("Please, check the STICH count. It needs to be a number below " + maxStiches + ", not negative, nor zero.");
            }

            else if (!(Int32.TryParse(userInputForRows.Text, out userDefinedRows)) || userDefinedRows <= 0 || userDefinedRows > maxRows)
            {
                MessageBox.Show("Please, check the ROW count. It needs to be a number below " + maxRows + ", not negative, nor zero.");
            }

            //If everything is OK with the user input (numbers), continue program
            else
            {
                //User's stitches = colums
                //and user's rows = rows
                dataGridView1.ColumnCount = userDefinedStiches;
                dataGridView1.RowCount = userDefinedRows;

                //Set the column header names (in this case numbers).
                for (int y = 0; y < dataGridView1.ColumnCount; ++y)
                {
                    dataGridView1.Columns[y].Name = (y + 1).ToString();
                }


                // Set the row header width.
                //Header width can be larger than normal cell's width without distrupting knitting grid ratio [4:5]
                dataGridView1.RowHeadersWidth = 70;

                // Set the row header names (in this case numbers).
                for (int y = 0; y < dataGridView1.RowCount; ++y)
                {
                    dataGridView1.Rows[y].HeaderCell.Value = (y + 1).ToString();

                }

                // Set the column width.
                for (int y = 0; y < dataGridView1.ColumnCount; ++y)
                {
                    dataGridView1.Columns[y].Width = 40;
                }

                // Set the row height.
                for (int y = 0; y < dataGridView1.RowCount; ++y)
                {
                    dataGridView1.Rows[y].Height = 32;
                }

                //Set the background colour of the cells white at first
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        dataGridView1.Rows[row.Index].Cells[col.Index].Style.BackColor = Color.White;
                    }
                }
            }
        }

        //When a cell is clicked
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Checking if the clicked cell is row or column header
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            { }

            //continue checking the colour
            else
            {
                //Checking if the clicked cell is black or white.
                //When it's black, reset it to white and vice versa
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.Black)
                {
                    //For testing to see if the colour changes work
                    //MessageBox.Show("on musta, maalataan valkoiseksi");

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                }

                else
                {
                    //For testing to see if the colour changes work
                    //MessageBox.Show("On valkoinen, maalataan mustaksi");
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Black;
                }
            }

        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            //Clear button which empties the grid
            dataGridView1.ColumnCount = 0;
            dataGridView1.RowCount = 0;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            dataGridView1.Dispose();
            
        }
        //Show info about the max value when the mouse is hovering over the textbox (for stiches)
        private void textBoxStiches_MouseHover(object sender, EventArgs e)
        {

            System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
            myToolTip.ToolTipIcon = ToolTipIcon.Info;
            myToolTip.ShowAlways = true;
            myToolTip.SetToolTip(textBoxStiches, "The maximum is " + maxStiches);
            
        }

        //Show info about the max value when the mouse is hovering over the textbox (for rows)
        private void textBoxRows_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
            myToolTip.ToolTipIcon = ToolTipIcon.Info;
            myToolTip.ShowAlways = true;
            myToolTip.SetToolTip(textBoxRows, "The maximum is " + maxRows);
        }
    }
}
