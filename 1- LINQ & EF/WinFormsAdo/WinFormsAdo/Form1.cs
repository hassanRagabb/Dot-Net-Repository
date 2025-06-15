using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WinFormsAdo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlcn;
        private void Form1_Load(object sender, EventArgs e)

        {
            sqlcn = new SqlConnection();

            // Read connection string from connectionStrings
            sqlcn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindCN"].ConnectionString;

            // Read BranchId from appSettings
            string branchId = ConfigurationManager.AppSettings["BranchId"];

            //Data source is server name and dot stands for local //true for windows authintication if false u use sql authintication 
            //sqlcn.ConnectionString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=True;";

            sqlcn.StateChange += (sender, e) =>this.Text= $"state was {e.OriginalState} and changed to {e.CurrentState}";//print like as name of form
            sqlcn.InfoMessage += (sender, e) => MessageBox.Show(e.Message);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcn.State == ConnectionState.Closed)//cant open already opened 
                {
                    sqlcn.Open();
                    MessageBox.Show("Connection Opened.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening connection: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlcn.State == ConnectionState.Open)
                {
                    sqlcn.Close();
                    MessageBox.Show("Connection Closed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing connection: " + ex.Message);
            }
        }

        private void btnChangeDb_Click(object sender, EventArgs e)
        {
            //must connection opened to change ur db
            if (sqlcn.State == ConnectionState.Open)
            {
                sqlcn.ChangeDatabase("AdventureWorks");
            }
            else
            {
                sqlcn.Open();
                sqlcn.ChangeDatabase("AdventureWorks");  

            }


            //try
            //{
            //    if (sqlcn.State == ConnectionState.Open)
            //        sqlcn.Close();

            //    // Prompt user for new database name
            //    string newDb = Microsoft.VisualBasic.Interaction.InputBox(
            //        "Enter the name of the database you want to connect to:",
            //        "Change Database",
            //        "AdventureWorks");

            //    if (!string.IsNullOrWhiteSpace(newDb))
            //    {
            //        // Change the database in the connection string
            //        sqlcn.ConnectionString = $"Data Source=.;Initial Catalog={newDb};Integrated Security=True;";
            //        sqlcn.Open();

            //        MessageBox.Show($"Connected to database: {newDb}", "Database Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show("Error switching database: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
