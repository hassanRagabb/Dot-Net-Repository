using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data;
using System.Diagnostics;
namespace DataAccessLayerVid3
{
    public class DataBaseManager  // u donwload sqlClient her to just  deal with database as a data access layer
    {

        SqlConnection sqlCN;
        SqlCommand sqlCmd;
        SqlDataAdapter adapter;
        DataTable table;
        public DataBaseManager()
        {
            try
            {
                var cs = ConfigurationManager.ConnectionStrings["NorthWindCN"];
                if (cs == null)
                {

                    return;
                }

                sqlCN = new SqlConnection(cs.ConnectionString); // This should now work
                sqlCmd = new SqlCommand
                {
                    Connection = sqlCN,
                    CommandType = CommandType.StoredProcedure
                };

                adapter = new SqlDataAdapter(sqlCmd);
                table = new DataTable();
            /*8
            sqlCN = new SqlConnection();
            // Reads the connection string named "NorthWindCN" from App.config
            sqlCN.ConnectionString = ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString;


            sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCN;
            sqlCmd.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(sqlCmd);
            table = new DataTable();*/
            }
            catch
            {

            }
            
            /*
            catch (ConfigurationErrorsException ex)
            {
                // Handle configuration errors like missing connection string
                //MessageBox.Show("Configuration error: " + ex.Message);
            }
            catch (SqlException ex)
            {
                // Handle SQL Server related errors
               // MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other kind of error
                //MessageBox.Show("Unexpected error: " + ex.Message);
            }
            catch 
            {
                // log file exception
            }*/

        }







        #region 6 functions
        public int ExcuteNonQuery(string spName)//retrive number of effected rows spName is stored proc name 
        {
            int R = -1;
            try
            {
                if (sqlCN?.State == ConnectionState.Closed)
                {
                    sqlCN.Open();
                    sqlCmd.CommandText = spName;
                    sqlCmd.Parameters.Clear(); //if before do things 
                    R = sqlCmd.ExecuteNonQuery();
                    sqlCN.Close();

                }

            }
            catch
            {

            }
            return R;//-1 in case problem happened
        }

        public object ExcuteScalar(string spName)
        {
            object R = new object();//not null coz may u send it again to another thing make problems latter
            try
            {
                if (sqlCN?.State == ConnectionState.Closed)
                {
                    sqlCN.Open();
                    sqlCmd.CommandText = spName;
                    sqlCmd.Parameters.Clear(); //if before do things 
                    R = sqlCmd.ExecuteScalar();
                    sqlCN.Close();

                }

            }
            catch
            {

            }
            return R;//empty obj in case problem happened
        }
		public DataTable ExcuteDataTable(string spName)
		{
			table.Clear();
			try
			{
				sqlCmd.Parameters.Clear();
				sqlCmd.CommandText = spName;

				if (sqlCN.State == ConnectionState.Closed)
					sqlCN.Open();  // ✅ REQUIRED

				adapter.Fill(table);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"ExcuteDataTable Error: {ex.Message}");
			}
			finally
			{
				if (sqlCN.State == ConnectionState.Open)
					sqlCN.Close();
			}

			return table;
		}

		//public DataTable ExcuteDataTable(string spName)
  //      {

  //          table.Clear();
  //          try
  //          {
  //              sqlCmd.Parameters.Clear(); //if before do things 
  //              sqlCmd.CommandText = spName;//stored oricudure
  //              adapter.Fill(table);
  //          }
  //          catch
  //          {
  //              //log excp type , message ,time  , stack trace...
  //          }
  //          return table;
  //      }
        public int ExcuteNonQuery(string spName, Dictionary<string, object> PrameterLLst)
        {
            int R = -1;
            try
            {
                if (sqlCN?.State == ConnectionState.Closed && PrameterLLst?.Count > 0)
                {
                    sqlCN.Open();
                    sqlCmd.CommandText = spName;
                    sqlCmd.Parameters.Clear(); //if before do things 
                    foreach (KeyValuePair<string, object> item in PrameterLLst)
                    {
                        sqlCmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    R = sqlCmd.ExecuteNonQuery();
                    sqlCN.Close();

                }

            }
            catch
            {

            }
            return R;//-1 in case problem happened
        }

        public object ExcuteScalar(string spName, Dictionary<string, object> PrameterLLst)
        {
            object R = new object();//not null coz may u send it again to another thing make problems latter
            try
            {
                if (sqlCN?.State == ConnectionState.Closed && PrameterLLst?.Count > 0)
                {
                    sqlCN.Open();
                    sqlCmd.CommandText = spName;
                    sqlCmd.Parameters.Clear(); //if before do things 
                    foreach (var param in PrameterLLst)
                    {
                        sqlCmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    R = sqlCmd.ExecuteScalar();
                    sqlCN.Close();

                }

            }
            catch
            {

            }
            finally
            {
                if (sqlCN.State == ConnectionState.Open)
                    sqlCN.Close();
            }
            return R;//empty obj in case problem happened
        }

        public DataTable ExcuteDataTable(string spName, Dictionary<string, object> PrameterLLst)
        {

            table.Clear();
            try
            {
                sqlCmd.Parameters.Clear(); //if before do things 
                sqlCmd.CommandText = spName;//stored oricudure
                foreach (var param in PrameterLLst)
                {
                    sqlCmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();
                adapter.Fill(table);
            }
            catch
            {
                //log excp type , message ,time  , stack trace...
            }
            finally
            {
                if (sqlCN.State == ConnectionState.Open)
                    sqlCN.Close();
            }
            return table;
        }


        #endregion




        /*
        public DataTable GetAllProducts()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", cn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        
        public void Insert(Product p)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductName, UnitsInStock) VALUES (@name, @stock)", cn);
            cmd.Parameters.AddWithValue("@name", p.ProductName);
            cmd.Parameters.AddWithValue("@stock", p.UnitsInStock);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }   

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @id", cn);
            cmd.Parameters.AddWithValue("@id", id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }*/
    }
}