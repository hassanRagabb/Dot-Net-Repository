using businessLogicLayer.Entities;
using businessLogicLayer.EntityList;
using DataAccessLayerVid3;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogicLayer.EntityManagers
{
    public class ProductManager //speqak with data access layer and the data access will speak with data base
    {
        static DataBaseManager dbManager = new DataBaseManager();

        public ProductManager() { } 
        public static ProductList SelectAllProducts() //return product list is list from product 
        {
            try
            {
                return DataTableToProductList(
                dbManager.ExcuteDataTable("SelectAllProducts"));//table need to retrive it as product how

            }catch
            {

            }
            return new ProductList();
        }
        //other functions like delete product by id ..
        public static bool  DeleteProductById(int ProductID)//is it returen > 0 yes so return true
        {
            try
            {
                Dictionary<string, object> parametListsDictionary = new Dictionary<string, object>()
                { ["ProductID"]= ProductID }; //key is ProductID and value is the sented prameter



                if (dbManager.ExcuteNonQuery("DeleteProductById", parametListsDictionary)>0)
                        return true;

            }
            catch 
            {
                
            }
            return false;//is it returen < 0 yes so return false 
        }


        //help for SelectAllProducts procedure 
        #region mapping function from table to product list this mapping funciton for each entity not good solved in EF 
        internal static ProductList DataTableToProductList(DataTable tbl) //internal no one can access it from outside
        {
            ProductList prodlist = new ProductList();
            if (tbl?.Rows?.Count > 0)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    prodlist.Add(DataRowToProduct(row));

                }
            }//end if

            return prodlist;


        }


        
        
        internal static Product DataRowToProduct(DataRow DataaRow)//DataRow return object so need to cast
        {
            int tempInt;
            short tempShort;
            Product prd = new Product();
            try
            {
                prd.ProductID = DataaRow.Field<int>("ProductID"); //my happen exception in another field because u strict it to be integer
                prd.ProductName1 = DataaRow["ProductName"]?.ToString() ?? "NA";
                prd.CategoryID = int.TryParse(DataaRow["SupplierID"]?.ToString(), out tempInt) ? tempInt : 0;
                prd.CategoryID = int.TryParse(DataaRow["CategoryID"]?.ToString(), out tempInt) ? tempInt : 0;
                prd.QuantityPerUnit = DataaRow["QuantityPerUnit"]?.ToString() ?? "NA";

                prd.UnitPrice = decimal.TryParse(DataaRow["SupplierID"]?.ToString(), out decimal tempdecimal) ? tempInt : 0;

                prd.ReorderLevel = short.TryParse(DataaRow["UnitsInStock"]?.ToString(), out tempShort) ? tempShort : (short)0;
                prd.ReorderLevel = short.TryParse(DataaRow["ReorderLevel"]?.ToString(), out tempShort) ? tempShort : (short)0;
                prd.ReorderLevel = short.TryParse(DataaRow["UnitsOnOrder"]?.ToString(), out tempShort) ? tempShort : (short)0;
                prd.Discontinued = bool.TryParse(DataaRow["Discontinued"]?.ToString(), out bool tempBool) && tempBool;
                prd.state = EntityState.Unchanged;//u just get the value but if u update manually the set in product will call it to be modified
            }
            catch
            {
                // Handle exceptions if necessary
            }
            return prd;


            /* Product prd = new Product(); //vid 4 at min 34
             try
             {
                 Product p = new Product
                 {
                     ProductID = Convert.ToInt32(DataaRow["ProductID"]),
                     ProductName = DataaRow["ProductName"].ToString(),
                     SupplierID = DataaRow["SupplierID"] != DBNull.Value ? Convert.ToInt32(DataaRow["SupplierID"]) : null,
                     CategoryID = DataaRow["CategoryID"] != DBNull.Value ? Convert.ToInt32(DataaRow["CategoryID"]) : null,
                     QuantityPerUnit = DataaRow["QuantityPerUnit"]?.ToString(),
                     UnitPrice = DataaRow["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(DataaRow["UnitPrice"]) : null,
                     UnitsInStock = DataaRow["UnitsInStock"] != DBNull.Value ? Convert.ToInt16(DataaRow["UnitsInStock"]) : null,
                     UnitsOnOrder = DataaRow["UnitsOnOrder"] != DBNull.Value ? Convert.ToInt16(DataaRow["UnitsOnOrder"]) : null,
                     ReorderLevel = DataaRow["ReorderLevel"] != DBNull.Value ? Convert.ToInt16(DataaRow["ReorderLevel"]) : null,
                     Discontinued = DataaRow["Discontinued"] != DBNull.Value && Convert.ToBoolean(DataaRow["Discontinued"])
                 };

                 return p;
             }
             catch
             {

             }*/

        }

    }
    #endregion
}

