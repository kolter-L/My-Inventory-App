using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar;

// Kolter Leisy 03-03-2024

namespace MyInventoryApp
{
    public partial class Form1 : Form
    {
        List<Inventory> myInventory = new List<Inventory>();

        List<int> myIndex = new List<int>();

        private string txtFile = "";

        public Form1()
        {

            InitializeComponent();

            // adding columns to data Grid

            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns.Add("Weight", "Weight");
            dataGridView1.Columns.Add("Description", "Description");
            dataGridView1.Columns.Add("Quantity", "Quantity");

            // settings for openFileDialog1

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            this.openFileDialog1.RestoreDirectory = true;

        }


       // Button OnClick method that displays inventory
        private void btnDisplayInventory_Click(object sender, EventArgs e)
        {
            myInventory.Clear();
            ReadFile(txtFile);
            dataGridView1.Rows.Clear();

            dataGridView1.Refresh();
            dataGridView1.Invalidate();

            for (int i = 0; i < myInventory.Count; i++)
            {
                dataGridView1.Rows.Add(myInventory[i].getName(), myInventory[i].getPrice(), myInventory[i].getWeight(), myInventory[i].getDescription(), myInventory[i].getQuantity());
            }
        }

        // Method that reads file and returns array of lines 

        private string[] ReadToLines(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            return lines;
        }

        // Method that Reads Inventory from the TextFile

        private void ReadFile(string fileName)
        {
            string[] lines = ReadToLines(fileName);

            foreach (string line in lines)
            {
                string[] inventoryList = line.Split(',');

                string itemName = inventoryList[0];
                double itemPrice = double.Parse(inventoryList[1]);
                double weight = double.Parse(inventoryList[2]);
                string description = inventoryList[3];
                int quantity = int.Parse(inventoryList[4]);

                Inventory item = new Inventory(itemName, itemPrice, weight, description, quantity);
                myInventory.Add(item);

            }
        }

        // Method to Increment the quantity of an item on click
        private void IncDisplayQty(int invRowToUpdate, int qty, string txtFile)
        {
            string updateLine = "";

            qty++;

            string[] lines = ReadToLines(txtFile);

            string[] invRow = lines[invRowToUpdate].Split(',');

            invRow[4] = qty.ToString();

            updateLine = invRow[0].Trim() + ", " + invRow[1].Trim() + ", " + invRow[2].Trim() + ", " + invRow[3].Trim() + ", " + invRow[4].Trim();

            lines[invRowToUpdate] = updateLine;

            File.WriteAllLines(txtFile, lines);
        }


        // Method to open dialog and impenting ReadFile 
        private void btnReadFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile = this.openFileDialog1.FileName;  
            }
        }

        // Event Handlers that are not being presently used
        // I am just keeping these since I may want to use them later
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 4)
            {
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                int cellQT = Convert.ToInt32(cellValue);
                int cellROW = e.RowIndex;
                label1.Text = e.RowIndex.ToString();
                IncDisplayQty(cellROW, cellQT, txtFile); 

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
