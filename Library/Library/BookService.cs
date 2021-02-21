using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class BookService : IBookService
    {
        public string addBookData(Book m)
        {
            string bname, Message;
            int stock, price;

            bname = m.BookName;
            stock = m.Stock;
            price = m.Price;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\Library\BookRentalClient\BookStore.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into Books(bname,stock,price) values(@bname,@stock,@price)", con);
                cmd.Parameters.AddWithValue("@bname", bname);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@price", price);

                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Message = "Book Inserted Successfully";
                }
                else
                {
                    Message = "Book Can't Inserted Successfully";
                }
                con.Close();
                return Message;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }


        DataSet IBookService.viewBookData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\Library\BookRentalClient\BookStore.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Books", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
    }
}
