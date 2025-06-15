using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormEF_App
{
    public partial class frm2LazyLoading : Form
    {
        public frm2LazyLoading()
        {
            InitializeComponent();
        }

        private void frm2LazyLoading_Load(object sender, EventArgs e)
        {
            /*     using(NorthWindContext ctn = new NorthWindContext())
                 {
                     //var res = from P from context.Products
                     //                 where P.UnitsInStock > 0
                     //                 select p; //also defred 
                     var res = (from P from context.Products
                                      where P.UnitsInStock > 0
                                      //select p //BUT fk will have null like suppliers
                                      select new {P.ProductName ,P.suppliers.supplierName } // will happen joins between 2 tables and show result
                                      ).ToList();//immediatly fast to database with values 

                     //or 
                     var res = (from P from context.Products.include(p => p.suppliers) // include like left join means when selecting from products table join it with category table and get the fk
                                       where P.UnitsInStock > 0
                                       select p // here u just select product but u include also get the fk :( to use category in futre like print it   
                     foreach (var product in res)
                     {
                        //Trace.WriteLine($"{product.ProductName}  {product.Category?.CategoryName??"NA"}");//Trace like  dubeg mode
                     }
                 }*/
        }
    }
}
