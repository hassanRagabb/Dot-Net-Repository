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

namespace WinFormsAdo
{
    public partial class frmCommand : Form
    {
        public frmCommand()
        {
            InitializeComponent();
            
            //create command
           // SqlCommand sqlcmd = new SqlCommand("SELECT ProductName FROM Products", sqlcn);

           // sqlcmd = new SqlCommand();
            //sqlcmd.CommandType = CommandType.Text; in case stored prod u change the type of text
            //sqlcmd.CommandType = CommandType.StoredProcedure;
          //  sqlcmd.Connection = sqlcn;
           // sqlcmd.CommandText = "SELECT COUNT(*) FROM Customers";
            // Execute command

            //here u add prameters for stored proc and in excute u take values from combo box and then send it to sql ide    




            // other work retrive all cols data 
            sqlGridView = new SqlCommand("SELECT * FROM Products", sqlcn);
            adaptor = new SqlDataAdapter(sqlGridView);
            tableGridView = new DataTable();




            // for supplier name column
            selectSuppliersName = new SqlCommand("SELECT SupplierID as SID , CompanyName FROM Suppliers", sqlcn);
            adaptorSupplier = new SqlDataAdapter(selectSuppliersName);
            tableSupplier = new DataTable();
        }
        private void frmCommand_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        SqlConnection sqlcn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
        SqlCommand sqlcmd;
        SqlCommand sqlGridView;
        DataTable table;
        DataTable tableGridView;
        SqlDataAdapter adaptor;

        
        SqlCommand selectSuppliersName;
        SqlDataAdapter adaptorSupplier;
        DataTable tableSupplier;
        private void btnExcute_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcn.Open();

                // إنشاء الأمر مع جملة SQL
                sqlcmd = new SqlCommand("SELECT COUNT(*) FROM Customers", sqlcn);

                // تنفيذ الأمر وجلب النتيجة
                int count = (int)sqlcmd.ExecuteScalar();

                MessageBox.Show("Customer count: " + count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                sqlcn.Close();
            }





            // try
            // {
            // sqlcn.Open();
            //here u add value to prameters   
            // Execute the command and show the result
            // int count = (int)sqlcmd.ExecuteScalar();  // Capital "E" and "S"
            // MessageBox.Show("Customer count: " + count);

            // Execute the SQL command and attempt to parse the result
            //if (int.TryParse(SqlCmd.ExecuteScalar()?.ToString() ?? "0", out productCount))
            //{
            //    this.Text = $"Product Count = {productCount}";
            //}
            // }
            //   catch (Exception ex)
            // {
            // MessageBox.Show("Error: " + ex.Message);
            // }
            // finally
            // {
            // sqlcn.Close();
            // }

        }
        //LoadProducts in text box 
        private void LoadProducts()
        {
            try
            {
                using (SqlConnection sqlcn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True"))
                {
                    sqlcn.Open();

                    SqlCommand getProdId = new SqlCommand("SELECT ProductName FROM Products", sqlcn);

                    using (SqlDataReader reader = getProdId.ExecuteReader())
                    {
                        cmbProductIDs.Items.Clear();

                        while (reader.Read())
                        {
                            cmbProductIDs.Items.Add(reader["ProductName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmbProductIDs_SelectedIndexChanged(object sender, EventArgs e)
        { //When u choose one item
            try
            {
                using (SqlConnection sqlcn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True"))
                {
                    sqlcn.Open();

                    SqlCommand getProdId = new SqlCommand("SELECT ProductName FROM Products", sqlcn);

                    using (SqlDataReader reader = getProdId.ExecuteReader())
                    {
                        cmbProductIDs.Items.Clear(); // Optional: clear old items before adding

                        while (reader.Read())
                        {
                            cmbProductIDs.Items.Add(reader["ProductName"].ToString());
                        }
                    }

                    // No need to call sqlcn.Close() explicitly when using 'using'
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        BindingSource prodBindingSource;
        private void btnLoadGrid_Click(object sender, EventArgs e)
        {
            adaptor.Fill(tableGridView);
            prodBindingSource = new BindingSource(tableGridView, "");//datset , table inside it but here u have data table so ""
            grdViewProducts.DataSource = prodBindingSource;


            // Read Only Attribute for id cant edit it
            grdViewProducts.Columns["ProductID"].ReadOnly = true;



            

            //add column have list from suplires replace for therire forignkey 
            DataGridViewComboBoxColumn datacol = new DataGridViewComboBoxColumn();
            datacol.HeaderText = "Supplier name";
            grdViewProducts.Columns.Add(datacol);
            adaptorSupplier.Fill(tableSupplier);  
            datacol.DataSource = tableSupplier;
            datacol.DisplayMember = "CompanyName";
            datacol.ValueMember = "SID";//new in elect as sid
            datacol.DataPropertyName = "SupplierID"; //source of selected value from the original data source for grid;SupplierID IS THE NUMBER IF COL 2 IN GRID
            // so u can hide the col2 that hold fk numbers because u got the value of it name
            grdViewProducts.Columns["SupplierID"].Visible = false;
        }

        private void btnSaveGrid_Click(object sender, EventArgs e)
        {
            grdViewProducts.EndEdit();
            // prodBindingSource.EndEdit();
            //adaptor.Update(tableGridView);// if u dont change okau but if u update the grid table manually will error need to make functions for delete insert and update
            //data table have enum know the state of record like vid 4 in min 1:18

            
           // foreach (DataRow dr in table.Rows)
            //{
            //    Debug.WriteLine(dr.RowState);
            //} 
            
        }
    }
}
