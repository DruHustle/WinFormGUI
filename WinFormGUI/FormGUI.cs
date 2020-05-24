using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinFormGUI
{
    public partial class FormGUI : Form
    {
        private Dictionary<int, string> columnTypes;
        private Dictionary<int, double> rowPriceDictionary;
        private double maxPrice = 0, minPrice = 0;
        int priceIndex = 0;

        public FormGUI()
        {
            InitializeComponent();
        }

        private void Load_CSV_Click(object sender, EventArgs e)
        {
            try
            {
                // Create filter to only allow selection of csv files
                openFileDialog.Filter = "CSV Files | *.csv";

                //Acquire file path
                openFileDialog.ShowDialog();
                string filePath = openFileDialog.FileName;

                //Set the text on the text filePath slot
                textFilePath.Text =  Path.GetFileName(filePath);
                textFilePath.Visible = true;
                File_Loaded_Label.Visible = true ;

                //Populate the datagridview
                BindData(filePath);
                Delete_Books.Enabled = true;

             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GUI Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }             

        private void BindData(string filePath)
        {
            // Read content from csv file
            string[] lines = File.ReadAllLines(filePath);
            columnTypes = new Dictionary<int, string>();
            rowPriceDictionary = new Dictionary<int, double>();
            myDataGridView.Columns.Clear();

            if (lines.Length > 0)
            {
                //Obtaining column headers
                string headerLine = lines[0];
                string[] headerLabels = headerLine.Split(';');

                int columnIndex = 0; //Custom ID         
                
                //Assigning headers to columns.
                foreach (string headerWord in headerLabels)
                {
                    string[] headerList = { "Title", "Author", "Year", "Price"  };
                    priceIndex = Array.IndexOf(headerList,"Price"); //Index required for color gradient calculations

                    if (headerList.Contains(headerWord))
                    {
                        DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
                        textBoxColumn.HeaderText = headerWord;
                        textBoxColumn.Name = headerWord;
                        textBoxColumn.ReadOnly = true;
                        textBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;   
                        myDataGridView.Columns.Add(textBoxColumn);
                        columnTypes.Add(columnIndex, "textbox");       
                    }
                    else
                    {
                        switch (headerWord)
                        {
                            case "In Stock":
                                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                                checkBoxColumn.HeaderText = "In Stock";
                                checkBoxColumn.Name = "In_Stock";
                                checkBoxColumn.ReadOnly = true;
                                checkBoxColumn.FlatStyle = FlatStyle.Standard;
                                checkBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                myDataGridView.Columns.Add(checkBoxColumn);
                                columnTypes.Add(columnIndex, "checkbox");
                                break;

                            case "Binding":
                                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                                comboBoxColumn.HeaderText = "Binding";
                                comboBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                comboBoxColumn.ReadOnly = false;
                                columnTypes.Add(columnIndex, "combobox");
                                myDataGridView.Columns.Add(comboBoxColumn);
                                break;

                            case "Description":
                                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                                buttonColumn.HeaderText = "Description";
                                buttonColumn.Name = "Description";
                                buttonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                buttonColumn.ReadOnly = true;
                                myDataGridView.Columns.Add(buttonColumn);
                                columnTypes.Add(columnIndex, "button");
                                break;
                        }
                    }

                    columnIndex++;
                }
                
                //Iterating through rows
                for (int i = 1; i < lines.Length; i++)
                {
                    //Obtaining string in cells of the row
                    string[] dataWords = lines[i].Split(';');

                    //Creating rows 
                    DataGridViewRow row = new DataGridViewRow();

                    //Populating row data                   
                    for (columnIndex = 0; columnIndex < headerLabels.Length; columnIndex++)
                    {
                        string dataWord = dataWords[columnIndex];
                        string[] list = { "Title", "Author", "Year", "Price"  };

                        switch (columnTypes[columnIndex])
                        {
                            case "button":
                                DataGridViewButtonCell buttonCell = new DataGridViewButtonCell { Value = "Click" };
                                buttonCell.Tag = dataWord.Trim('"');
                                row.Cells.Add(buttonCell);
                                break;

                            case "checkbox":
                                DataGridViewCheckBoxCell checkBoxCell = new DataGridViewCheckBoxCell();
                                if (dataWord == "yes")
                                    {
                                        checkBoxCell.Value = true;
                                    }
                                else
                                {
                                    checkBoxCell.Value = false;
                                }
                                row.Cells.Add(checkBoxCell);

                                break;

                            case "combobox":
                                DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                                comboBoxCell.Items.Add("Unknown");
                                comboBoxCell.Items.Add("Paperback");
                                comboBoxCell.Items.Add("Hardcover");
                                comboBoxCell.Items.Add("Coalwood");
                                comboBoxCell.Value = dataWord;
                                row.Cells.Add(comboBoxCell);
                                break;

                            default:
                                DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell { Value = dataWord };
                                row.Cells.Add(textBoxCell);
                                break;
                        }
                    }

                    myDataGridView.Rows.Add(row);

                    //Add the prices into a lookup dictionary
                    double price = double.Parse(dataWords[priceIndex].Replace(',', '.'));
                    if (price > maxPrice)
                    {
                        maxPrice = price;
                    }

                    if (price < minPrice)
                    {
                        minPrice = price; 
                    }

                    rowPriceDictionary.Add(i - 1, price);  
                }

                //Highlighting price text colour
                SetPriceColors();

                //Highlighting books not in stock
                HighlightOutOfStock();
            }
            else
            {
                MessageBox.Show("Please select a valid CSV file", "GUI Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void HighlightOutOfStock()
        {
            //Highlighting books not in stock
            foreach (DataGridViewRow row in myDataGridView.Rows)
            {
                
                if (Convert.ToBoolean(row.Cells["In_Stock"].Value.ToString()) == false)
                {
                    myDataGridView.Rows[row.Index].Selected = true;
                }
                else
                {
                    myDataGridView.Rows[row.Index].Selected = false;
                }
            }
        }

        private void SetPriceColors()
        {
            foreach (DataGridViewRow row in myDataGridView.Rows)
            {
                DataGridViewTextBoxCell textBoxCell = (DataGridViewTextBoxCell)myDataGridView.Rows[row.Index].Cells[priceIndex];

                try
                {
                    textBoxCell.Style.ForeColor = GetPriceColors(rowPriceDictionary[row.Index]);
                }
                    catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "GUI Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private Color GetPriceColors(double priceValue)
        {
            try
            {
                //Assume that max price is pure red (rgb of 255, 0, 0) and min price is pure green  (rgb of 0, 255, 0)
                double priceDiff = priceValue - minPrice, globalPriceDiff = maxPrice - minPrice;

                if (globalPriceDiff == 0)
                    return Color.Yellow;

                int intColorChange = (int)Math.Round(255 * priceDiff / globalPriceDiff);

                return Color.FromArgb(intColorChange, 255 - intColorChange, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GUI Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Color.Empty;
            }
        }

        //Form configurations
        private void FormGUI_Load(object sender, EventArgs e)
        {
            myDataGridView.AllowUserToAddRows = false;
            myDataGridView.AllowUserToResizeRows = false;
            Delete_Books.Enabled = false;
            File_Loaded_Label.Visible = false;
            textFilePath.Visible = false;
        }

        //Gid cell click event
        private void MyGridCell_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (columnTypes[e.ColumnIndex] == "button" && e.RowIndex >= 0)
                {
                    DataGridViewCell clickedCell = myDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    MessageBox.Show(clickedCell.Tag.ToString(), "GUI Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                      
                }
                else if (columnTypes[e.ColumnIndex] == "checkbox" && e.RowIndex >= 0)
                {
                    DataGridViewCell clickedCell = myDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    myDataGridView.Rows[e.RowIndex].Selected = clickedCell.Value == null || (Boolean)clickedCell.Value;
                }
                else if (columnTypes[e.ColumnIndex] == "textbox" && e.RowIndex >= 0)
                {
                    DataGridViewCell clickedCell = myDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    myDataGridView.Rows[e.RowIndex].Selected = clickedCell.Value == null || (Boolean)clickedCell.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GUI Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                HighlightOutOfStock(); //to return the highlighting of the previous out of stock default highlighting
            }
        }

        //Delete books click event
        private void Delete_Books_Click(object sender, EventArgs e)
        {   
            try
            {
                DialogResult ans = new DialogResult();
                ans = MessageBox.Show("Are you sure you want to delete rows?", "GUI Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ans == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in myDataGridView.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["In_Stock"].Value.ToString()) == false)
                        {
                           myDataGridView.Rows.RemoveAt(row.Index);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GUI Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Delete_Books.Enabled = false;
            }
        }

        //Exit from the GUI button click event
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            DialogResult ans = new DialogResult();
            ans = MessageBox.Show("Are you sure you want to exit?", "GUI Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                Application.Exit();
            }
        }        
    }          
}
