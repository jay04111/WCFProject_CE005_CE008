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
    public partial class Form1 : Form
    {
        ServiceReference2.BookServiceClient proxy = new ServiceReference2.BookServiceClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateBook l = new UpdateBook();
            l.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBook am = new AddBook();
            am.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBook l = new UpdateBook();
            l.Show();
        }
    }
}
