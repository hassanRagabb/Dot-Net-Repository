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
    public partial class frmProductsDetaildView : Form
    {
        public frmProductsDetaildView()
        {
            InitializeComponent();
        }
        SqlConnection sqlCn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
        SqlCommand sqlCmd;
        SqlDataAdapter Adaptor;
        DataTable table = new DataTable();
        private void frmProductsDetaildView_Load(object sender, EventArgs e)
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Products ", sqlCn);

            Adaptor = new SqlDataAdapter(sqlCmd);
            Adaptor.Fill(table);
            builder = new SqlCommandBuilder(Adaptor); //to automatically generate the Insert, Update, and Delete commands 
                                                      // Now you can update changes made to the DataTable back to the database like this:
                                                      // adaptor.Update(table);




            //simple data binding :single proprity at time from source //like text of contril just read mn database or color just read or background 
            //lblProductID.DataBindings.Add("Text", table, "ProductID");
            // txtProductName.DataBindings.Add("Text", table, "ProductName");
            // numUnitsInStock.DataBindings.Add("Value", table, "UnitsInStock");


            //binding source // to move through data source like u now see first rec need click to see another rec
            //BindingSource ProductBindingSource = new BindingSource(table,"");

            ProductBindingSource.DataSource = table;//for next and prev
            lblProductID.DataBindings.Add("Text", ProductBindingSource, "ProductID");
            txtProductName.DataBindings.Add("Text", ProductBindingSource, "ProductName");
            numUnitsInStock.DataBindings.Add("Value", ProductBindingSource, "UnitsInStock");
        }
        BindingSource ProductBindingSource = new BindingSource();

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            //ProductBindingSource HAVE FUNCTION LIKE Current and move_prev mov_last 
            if (ProductBindingSource.Position < ProductBindingSource.Count - 1)
                ProductBindingSource.MoveNext();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
           
            if (ProductBindingSource.Position > 0)
                ProductBindingSource.MovePrevious();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Adaptor.Update(table); //because u used SqlCommandBuilder builder  // Now you can update changes made to the DataTable back to the database like this:
                MessageBox.Show("Changes saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        SqlCommandBuilder builder;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ProductBindingSource.Current != null)
            {
                ProductBindingSource.RemoveCurrent();  // هذا يحذف السجل الحالي من الـ DataTable

                // بعد الحذف، يمكنك الحفظ لتحديث القاعدة:
                btnSave_Click(sender, e);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            DataRow newRow = table.NewRow();

            // يمكنك تعيين قيم مبدئية هنا مثلا
            newRow["ProductName"] = "New Product";
            newRow["UnitsInStock"] = 0;
            // تعيين باقي الأعمدة المطلوبة حسب الحاجة

            table.Rows.Add(newRow);

            ProductBindingSource.Position = ProductBindingSource.Count - 1;  // تحرك للسجل الجديد

            // يمكن حفظ التغييرات تلقائيا أو بالضغط على زر الحفظ
        }
    }
}



