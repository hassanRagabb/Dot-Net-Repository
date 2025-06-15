using businessLogicLayer.EntityList;
using businessLogicLayer.EntityManagers;
using System.Diagnostics;

namespace ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.toolStripMenuItem2Prev.Click += (sender, e) =>
            {
                currentPage = currentPage > 0 ? currentPage -1 : 0;
                Display();

            };
        }
        ProductList prods;
        private void toolStripMenuILoad_Click(object sender, EventArgs e)
        {
            try
            {
                //prods = ProductManager.SelectAllProducts(); //here is just business object not tables so u can make filter here like
                //this.dataGridView1.DataSource = prods;

                var prd=(from p  in ProductManager.SelectAllProducts() where p.UnitsInStock >0 select p).ToList(); //linq immediate excution
                this.dataGridView1.DataSource = prd;
                pageNum = (prods.Count / 10) + 1;
            }
            catch
            {

            }
           
        }
        int currentPage = 0;
        
        public void Display()=> this.dataGridView1.DataSource = prods.Skip(currentPage++ * 10).Take(10).ToList();
        int pageNum;
        private void toolStripMenuINext_Click(object sender, EventArgs e)
        {
            currentPage++;

            if (currentPage >= pageNum)  
                currentPage=0;
            Display();


        }

        private void toolStripMenuISave_Click(object sender, EventArgs e)
        {
            /*
                bool success = ProductManager.DeleteProductById(1);

                if (success)
                    MessageBox.Show("Product deleted successfully.");
                else
                    MessageBox.Show("Failed to delete the product. It may not exist or is linked to other records.");
            */
            foreach(var item in prods)
            {
                Trace.WriteLine($"{item.ProductID} {item.state}");
            }

        }
    }
}