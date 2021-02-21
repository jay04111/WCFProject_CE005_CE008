using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalClient
{
    public partial class AddBook : Form
    {
        ServiceReference2.BookServiceClient proxy = new ServiceReference2.BookServiceClient();
        public AddBook()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ServiceReference2.Book m = new ServiceReference2.Book();
            m.BookName = textBox1.Text;
            m.Stock = Convert.ToInt32(textBox2.Text);
            m.Price = Convert.ToInt32(textBox3.Text);

            string msg = proxy.addBookData(m);
            label5.Visible = true;
            label5.Text = msg;
        }
    }
}
