using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using PagedList;
using System.Windows.Forms;

namespace Madhur_Inventory
{
    public partial class Form1 : Form
    {
        string connection = (@"Data Source = LAPTOP-IJ602TJS\SQLSERVER; Initial Catalog = MADHUR; Integrated Security = True");
        int selectbtn = 1;
        StringBuilder build = new StringBuilder();
        string str;
        string total;
        int calender = 1;
       
        public Form1()
        {
            InitializeComponent();
           
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            monthCalendar1.Hide();
           
            List<string> combo = new List<string>
            {
                "slno", "partyName", "sarees", "invoice", "dop", "design", "LRnumber", "transport", "givenTo", "onDate"
            };
            comboBox1.DataSource = combo;

            List<string> filter = new List<string>()
            {
                "Date of Purchase", "On Date", "Sl no"
            };
            comboBox2.DataSource = filter;
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from test where slno = " + textBox1.Text + "", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from test where partyName = '" + textBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }

                    if (comboBox1.SelectedIndex == 2)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from test where sarees = " + textBox1.Text + "", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }

                    if (comboBox1.SelectedIndex == 3)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from test where invoice = " + textBox1.Text + "", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }

                    if (comboBox1.SelectedIndex == 4)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from test where dop = '" + textBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    if (comboBox1.SelectedIndex == 5)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from test where design = '" + textBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }

                    if (comboBox1.SelectedIndex == 6)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from test where LRNumber = '" + textBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }

                    if (comboBox1.SelectedIndex == 7)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from test where transport = '" + textBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }

                    if (comboBox1.SelectedIndex == 8)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from test where givenTo = '" + textBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }

                    if (comboBox1.SelectedIndex == 9)
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("select * from test where onDate = '" + textBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Height = 200;
                    }
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.Width = 200;
                    }
                    DataGridViewImageColumn image = new DataGridViewImageColumn();
                    image = (DataGridViewImageColumn)dataGridView1.Columns[10];
                    image.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    //sda.Dispose();
                }

               
            }
            catch
            {
                MessageBox.Show("Search filter does not metch. Please select proper filter or click 'Show all data' button to see all the data");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SortByRange.Hide();
            label5.Show();
            button10.Hide();
            textBox2.Show();
            panel2.Hide();
            panel1.Show();
            button6.Hide();
            label3.Show();
            button4.Show();
            label17.Hide();
            textBox14.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                                    openFileDialog1.ShowDialog();
                    string name = openFileDialog1.FileName;

                    SqlConnection con = new SqlConnection(connection);
                    con.Open();
                    byte[] array = null;
                    FileStream file = new FileStream(name, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(file);
                    array = binaryReader.ReadBytes((int)file.Length);
                MessageBox.Show(file.Length.ToString());

                    DateTime date = new DateTime();
                    date = DateTime.Parse(textBox5.Text);

                    DateTime date2 = new DateTime();
                    date2 = DateTime.Parse(textBox5.Text);

                    SqlCommand sda = new SqlCommand("insert into test values(" + textBox2.Text + ",'" + textBox3.Text + "'," + textBox4.Text + "," + textBox11.Text + ",'" + date + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + textBox10.Text + "','" + date2 + "',@array)", con);
                    sda.Parameters.Add("@array", array);
                    int s = sda.ExecuteNonQuery();
                    MessageBox.Show(s + " afftected rows");
                
            }
            catch
            {
                MessageBox.Show("Upload Unsuccessful. Please fill all the fields and upload with an image");
            }
                                   

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            SortByRange.Show();
            button6.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
               
                    
                    SqlDataAdapter sqlData = new SqlDataAdapter("select * from test", connection);
                    DataTable table = new DataTable();
                    sqlData.Fill(table);
                    DataGridView.CheckForIllegalCrossThreadCalls = false;
                    dataGridView1.DataSource = table;
                    DataGridViewImageColumn dgvI = new DataGridViewImageColumn();
                    dgvI = (DataGridViewImageColumn)dataGridView1.Columns[10];
                    dgvI.ImageLayout = DataGridViewImageCellLayout.Stretch;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Height = 150;
                    }
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.Width = 150;
                    }
                              

            }
            catch
            {
                MessageBox.Show("Something went wrong, Please ensure the server is running.");
            }
        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void SortByRange_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            button6.Show();
        }

        private void Button7_Click(object sender, EventArgs e)
        {


            try
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    //monthCalendar1.Show();
                        SqlDataAdapter sqlData = new SqlDataAdapter("select * from test where dop between '" + textBox12.Text + "' and '" + textBox13.Text + "'", connection);
                        DataTable data = new DataTable();
                        sqlData.Fill(data);
                        dataGridView1.DataSource = data;                   

                }

                if (comboBox2.SelectedIndex == 1)
                {

                   // monthCalendar1.Show();
                        SqlDataAdapter sqlData = new SqlDataAdapter("select * from test where onDate between '" + textBox12.Text + "' and '" + textBox13.Text + "'", connection);
                        DataTable data = new DataTable();
                        sqlData.Fill(data);
                        dataGridView1.DataSource = data;
                    
                }

                if (comboBox2.SelectedIndex == 2)
                {
                    
                        SqlDataAdapter sqlData = new SqlDataAdapter("select * from test where slno between " + textBox12.Text + " and " + textBox13.Text + "", connection);
                        DataTable data = new DataTable();
                        sqlData.Fill(data);
                        dataGridView1.DataSource = data;
                    
                }
            }               
            catch
            {
                MessageBox.Show("Fill in the fields according to the selection and try again");
            }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = 200;
                }
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.Width = 200;
                }
                DataGridViewImageColumn image = new DataGridViewImageColumn();
                image = (DataGridViewImageColumn)dataGridView1.Columns[10];
                image.ImageLayout = DataGridViewImageCellLayout.Stretch;

            
        }
            

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            Bitmap bitmap = new Bitmap(this.dataGridView1.Height, this.dataGridView1.Width);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0,0,dataGridView1.Width,dataGridView1.Height));
            e.Graphics.DrawImage(bitmap, 100, 10);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if(selectbtn % 2 == 0)
            {
                panel3.Hide();                
            }
            
            else
            {
                panel3.Show();
            }
            selectbtn++;                                      
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            total = null;
            if(checkedListBox1.CheckedIndices.Contains(0))
            {
                total = total + "slno,";
            }
            if(checkedListBox1.CheckedIndices.Contains(1))
            {
                total = total + "partyName,";
            }
            if (checkedListBox1.CheckedIndices.Contains(2))
            {
                total = total + "sarees,";
            }
            if (checkedListBox1.CheckedIndices.Contains(3))
            {
                total = total + "invoice,";
            }
            if (checkedListBox1.CheckedIndices.Contains(4))
            {
                total = total + "dop,";
            }
            if (checkedListBox1.CheckedIndices.Contains(5))
            {
                total = total + "design,";
            }
            if (checkedListBox1.CheckedIndices.Contains(6))
            {
                total = total + "LRNumber,";
            }
            if (checkedListBox1.CheckedIndices.Contains(7))
            {
                total = total + "transport,";
            }
            if (checkedListBox1.CheckedIndices.Contains(8))
            {
                total = total + "givenTo,";
            }
            if (checkedListBox1.CheckedIndices.Contains(9))
            {
                total = total + "onDate,";
            }
            string filter = total.Remove(total.Length - 1);

            if (comboBox1.SelectedIndex == 0)
            {
                SqlDataAdapter sql = new SqlDataAdapter("select " + filter + " from test where slno = "+textBox1.Text+" ", connection);
                DataTable data = new DataTable();
                sql.Fill(data);
                dataGridView1.DataSource = data;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select "+filter+" from test where partyName = '" + textBox1.Text + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 2)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select "+filter+" from test where sarees = " + textBox1.Text + "", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 3)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select "+filter+" from test where invoice = " + textBox1.Text + "", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 4)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select "+filter+" from test where dop = '" + textBox1.Text + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox1.SelectedIndex == 5)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select "+filter+" from test where design = '" + textBox1.Text + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 6)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select "+filter+" from test where LRNumber = '" + textBox1.Text + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 7)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select "+filter+" from test where transport = '" + textBox1.Text + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 8)
            {
               
                SqlDataAdapter sda = new SqlDataAdapter("select "+filter+" from test where givenTo = '" + textBox1.Text + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 9)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select "+filter+" from test where onDate = '" + textBox1.Text + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 100;
            }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();            
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            panel1.Show();
            SortByRange.Hide();
            label5.Hide();
            textBox2.Hide();
            panel2.Hide();
            label3.Hide();
            button4.Hide();
            button10.Show();
            label17.Show();
            textBox14.Show();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcom = new SqlConnection(connection))
            {
                SqlCommand sqlData = new SqlCommand("update test set partyName = '" + textBox3.Text + "', sarees ='" + textBox4.Text + "', invoice = '" + textBox11.Text + "'," +
                    "dop = '" + textBox5.Text + "', design = '" + textBox8.Text + "', LRNumber = '" + textBox7.Text + "', transport = '" + textBox6.Text + "', givenTo = '" + textBox10.Text + "', onDate = '" + textBox9.Text + "' where slno = " + textBox14.Text + "",sqlcom);
                sqlcom.Open();
                sqlData.ExecuteNonQuery();
                sqlcom.Close();
            }
            MessageBox.Show("Updation successful, Click search to view");
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            
            //calender++;   
            //if (calender % 2 == 0)
            //{
            //    textBox12.Text = monthCalendar1.SelectionStart.ToShortDateString();
            //    //monthCalendar1.Hide();
            //}
            ////++;
            //if(calender % 2 != 0)
            //{
            //    textBox13.Text = monthCalendar1.SelectionStart.ToShortDateString();
            //}
        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {
            calender++;
        }
    }
}

