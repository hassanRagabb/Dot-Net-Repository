using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAdo
{
    public partial class frmSqlDataAdapter : Form
    {
        SqlConnection sqlCn= new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
        SqlCommand sqlCmd;
        SqlDataAdapter Adaptor;
        DataTable table;

        public frmSqlDataAdapter()
        {
            InitializeComponent();
        }

        private void frmSqlDataAdapter_Load(object sender, EventArgs e)
        {
            try
            {
                

                table = new DataTable(); // جدول مؤقت يحتفظ بالبيانات
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnExcute_Click(object sender, EventArgs e)

        {
            //send prameter
            sqlCmd = new SqlCommand("SELECT * FROM Products where UnitsInStock > @UnitsInStock", sqlCn);
            sqlCmd.Parameters.AddWithValue("@UnitsInStock", 5);//send prameter

            Adaptor = new SqlDataAdapter(sqlCmd); // ربط الكوماند بالـ Adapter // retrive all data not rec by rec and u may put it to table 


            //retrive column in a list
            Adaptor.Fill(table); // open connection and excute command and fetch data to table

            lstProducts.DataSource = table; // lstProducts is DataGridView and list is complext data binding no need to loop here //will print tostring of the object like data tybe of it
            //to print specifc things in list 
            lstProducts.DisplayMember = "ProductName";// string selectedProduct = lstProducts.SelectedItem.ToString();
            lstProducts.ValueMember = "ProductID";//u can send it to database in the commands like delete or update by  string selectedProduct = lstProducts.SelectedValue;




            //retrive all columns in a grid like excell sheet
            grdViewProducts.DataSource = table;


        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When u choose one item from items

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ///sql command builder generate these commands 
            //when u write or update name and need to send it to database
            Adaptor.Update(table);//excute insert command and update and delete command 

        }
    }
}
