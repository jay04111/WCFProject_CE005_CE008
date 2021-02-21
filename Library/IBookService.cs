using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [ServiceContract]
    interface IBookService
    {
        [OperationContract]
        DataSet viewBookData();

        [OperationContract]
        string addBookData(Book m);
    }

    [DataContract]
    public class Book
    {
        int bid;
        string bname;
        int stock;
        int price;

        [DataMember]
        public int Id
        {
            get { return bid; }
            set { bid = value; }
        }
        [DataMember]
        public string BookName
        {
            get { return bname; }
            set { bname = value; }
        }
        [DataMember]
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        [DataMember]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
