using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


using System.IO;
// -------DataBase---------
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using Mahsoulat_Farhangi;
using mainform;
namespace mainform
{
    class ExecuteQuery
    {

        String strCon;
                
        public ExecuteQuery()
        {
            strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
        }
        //######################################################################################################################################################################################//
        //                                                                                     Inserting Query
        //######################################################################################################################################################################################//
  
        public string InsertQuery(string Query)
        {
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                                    Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

            string Message = "1 Successfully inserted";
            string Conditions = null;
            string Table_Name_1 = null;
            string Table_Name_2 = null;
            string Tables_Name = null;
            string Columns = null;
            string WhereCondition = null;
            string OnCondition = null;
            //string Query = null;

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //   END.                                                                             Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
 
            
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                               Sql Connection And Query
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


            try
            {
                SqlDataAdapter sqlDA;
                SqlConnection connection;
                String strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
                // strCon = "Data Source=localhost;Initial Catalog=&quot;محصولات فرهنگی خانگی&quot;;Integrated Security=True";
                //strCon="Data Source=localhost;AttachDbFilename=|DataDirectory|\[محصولات فرهنگی خانگی].mdf;Integrated Security=True";
                DataSet dts = new DataSet();
                SqlCommand cmd;


                connection = new SqlConnection(strCon);
                connection.Open();
                cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                Message = "0 Error in Execution Query";
            }
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //END.                                                                         Sql Connection And Query
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

            return Message;
        }
        //######################################################################################################################################################################################//
        // END.                                                                              Inserting Query
        //######################################################################################################################################################################################//
  

        //######################################################################################################################################################################################//
        //                                                                                     Deleting Query
        //######################################################################################################################################################################################//
       
        public string DeleteQuery(string Query)
        {
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                                    Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

            string Message = "1 Successfully deleted.";
            string Conditions = null;
            string Table_Name_1 = null;
            string Table_Name_2 = null;
            string Tables_Name = null;
            string Columns = null;
            string WhereCondition = null;
            string OnCondition = null;
            //string Query = null;

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //   END.                                                                             Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

            try
            {
                SqlDataAdapter sqlDA;
                SqlConnection connection;
                String strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
                // strCon = "Data Source=localhost;Initial Catalog=&quot;محصولات فرهنگی خانگی&quot;;Integrated Security=True";
                //strCon="Data Source=localhost;AttachDbFilename=|DataDirectory|\[محصولات فرهنگی خانگی].mdf;Integrated Security=True";
                DataSet dts = new DataSet();
                SqlCommand cmd;


                connection = new SqlConnection(strCon);
                connection.Open();
                cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                Message = "0 Error in Executing Deleting Query";
            }
            
            return Message;
        }
        //######################################################################################################################################################################################//
        //END.                                                                                Deleting Query
        //######################################################################################################################################################################################//


        //######################################################################################################################################################################################//
        //                                                                                   Update Query
        //######################################################################################################################################################################################//
        public string EditeQuery(string Query)
        {
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                                    Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

            string Message = "1 Successfully Edited.";
      
            //string Query = null;

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //   END.                                                                             Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

            try
            {
                //SqlDataAdapter sqlDA;
                SqlConnection connection;
                // strCon = "Data Source=localhost;Initial Catalog=&quot;محصولات فرهنگی خانگی&quot;;Integrated Security=True";
                //strCon="Data Source=localhost;AttachDbFilename=|DataDirectory|\[محصولات فرهنگی خانگی].mdf;Integrated Security=True";
                //DataSet dts = new DataSet();
                SqlCommand cmd;


                connection = new SqlConnection(strCon);
                connection.Open();
                cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                Message = "0 Error in Executing Editing Query";
            }

            return Message;
        }
        //######################################################################################################################################################################################//
        //END.                                                                                Update Query
        //######################################################################################################################################################################################//
  
    }
}
