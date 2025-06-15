using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows.Forms;
using WinFormEF_App.Models;

namespace WinFormEF_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthWindContext context =new NorthWindContext();

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //   context = new NorthWindContext();
        //    //gridViewProducts.DataSource = context.Products;//defred cant show data
        //    //var res = from P from context.Products
        //    //          where P.UnitsInStock > 0
        //    //          select p; //also defred 

        //    //  context.Products.Load();//fetch all records as (objects) from database into local 
        //    //   gridViewProducts.DataSource = context.Products.Local.ToBindingList();//2 way binding in forms
        //    //but the fk will be empty coz its lazy loading







            


        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            //after using database ef

            // Query discontinued products (assuming Discontinued 
            //   List<Product> discontinuedProducts = context.Products
            //   .FromSqlRaw("EXEC GetDiscontinuedProducts")
            //   .ToList();

            //List<Product> discontinuedProducts = context.Products
            //.FromSqlRaw("EXEC GetProductsByCategory @CategoryID = {0}", new SqlParameter("@CategoryID",3))
            //.ToList();
            //gridViewProducts.DataSource = discontinuedProducts;





            // usign  stored procudre with key less send prameter also 
            SqlParameter topParam = new SqlParameter(){ ParameterName = "@Top", SqlDbType=SqlDbType.Int, Value=5};//return top 5
            SqlParameter outputParam = new SqlParameter()
            {
                ParameterName = "@overallCount",
                SqlDbType =SqlDbType.Int,
                Direction = ParameterDirection.Output //WILL RECIVE IN IT DATA NO SEND LIKE TOP
            };
            var results = context.Set<TopCustIdKeyLess>()
                                 .FromSqlRaw("EXEC GetTopCustIDsp @Top, @overallCount OUTPUT", topParam, outputParam)
                                 .ToList();
            // Bind to DataGridView
            gridViewProducts.DataSource = results;
            this.Text = outputParam.Value.ToString();


           // this.gridViewProducts.DataSource = context.classViewTableKeyLess.ToList(); //has DB<set> 


        }
        private void btnSave_Click(object sender, EventArgs e)
        { //if u make updates in grid like change in the table manually 
          //   gridViewProducts.EndEdit();
          //   context.SaveChanges();
          // context.SaveChangesAsync(); //if it take to much time in this context.SaveChanges(); use multithreading




            //after using database ef
            this.gridViewProducts.EndEdit(); //for changes
            context.SaveChanges();
        }

      
    }
}