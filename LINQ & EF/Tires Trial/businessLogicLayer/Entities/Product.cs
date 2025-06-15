using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogicLayer.Entities
{
    public class Product:EntityBase
    {
        /*
         [ProductID] [int] IDENTITY(1,1) NOT NULL,
	    [ProductName] [nvarchar](40) NOT NULL, //40 at setter
	    [SupplierID] [int] NULL,
	    [CategoryID] [int] NULL,
	    [QuantityPerUnit] [nvarchar](20) NULL,
	    [UnitPrice] [money] NULL,
	    [UnitsInStock] [smallint] NULL,
	    [UnitsOnOrder] [smallint] NULL,
	    [ReorderLevel] [smallint] NULL,
	    [Discontinued] [bit] NOT NULL,
            */
        public int ProductID { get; set; }//int cant have null okay so it can by id
                                          // public string ProductName { get; set; }
        string ProductName;
        public string ProductName1 
        { 
            get => ProductName;
            set { 
                    if (ProductName != value)
                    {
                         ProductName=value;
                        if (state != EntityState.Added)
                        {
                            this.state = EntityState.Modified; //min 1:33 vid 4
                        }
                    }
            } 
        } //for state
        public Nullable<int> SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
       
        // Add more properties as needed
    }
}
