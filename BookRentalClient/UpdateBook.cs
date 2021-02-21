using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalClient
{
    public partial class UpdateBook : Form
    {
        int Id, Stock, Price;
        string BookName;

        ServiceReference2.BookServiceClient proxy = new ServiceReference2.BookServiceClient();
        public UpdateBook()
        {
            InitializeComponent();
            DataSet ds = null;
            ds = proxy.viewBookData();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }



        private void UpdateBook_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookStoreDataSet.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.bookStoreDataSet.Books);

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            this.dataGridView1.Rows[e.RowIndex].Selected = true;
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\Library\BookRentalClient\BookStore.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            
            SqlCommand cmd1 = new SqlCommand("update Books set bname= @bname, stock= @stock, price= @price Where bid = @bid", con1);
            cmd1.Parameters.AddWithValue("@bid", Id);
            cmd1.Parameters.AddWithValue("@stock", textBox2.Text);
            cmd1.Parameters.AddWithValue("@bname", textBox1.Text);
            cmd1.Parameters.AddWithValue("@price", textBox3.Text);
            cmd1.ExecuteNonQuery();
            con1.Close();
            DisplayData();
            clearData();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\Library\BookRentalClient\BookStore.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("delete Books where bid=@bid", con1);
            cmd1.Parameters.AddWithValue("@bid", Id);
            cmd1.ExecuteNonQuery();
            con1.Close();
            DisplayData();
            clearData();
        }

        public void clearData()
        {
            Id = 0;
            Stock = 0;
            Price = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void DisplayData()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\Library\BookRentalClient\BookStore.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            SqlCommand cmd = new SqlCommand("Select * from Books", con1);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            cmd.ExecuteNonQuery();
            con1.Close();
        }

    }
}
