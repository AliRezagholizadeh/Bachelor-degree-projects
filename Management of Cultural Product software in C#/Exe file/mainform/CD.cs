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
namespace Mahsoulat_Farhangi
{
    class CD
    {



        string[] LoanStatus;
        Verifications verify;
        int MaxNumber_Def;
        int MinNumber_Def;
        int MaxYear;
        int MinYear;
        //Add
        DataGridView SimpleSearchDataGridView;
        DataGridView InsertionDataGridView;
        String strCon;
        SqlDataAdapter sqlDA;
        SqlConnection connection;
        DataSet dts;
        //-Add          
        private readonly List<bool> per;

        public CD()
        {
            //Add
            strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
            SimpleSearchDataGridView = null;
            InsertionDataGridView = null;

            dts = null;
            connection = null;
            sqlDA = null;
            //-Add
            per = new List<bool>(1);
            LoanStatus = new string[2] { "امانت داده شده", "امانت گرفته شده" };
            verify = new Verifications();
            MaxNumber_Def = 2147483647;
            MinNumber_Def = 1;
            MaxYear = 9999;
            MinYear = 100;
        }
        //Add
        public void SetInsertionDataGridView(DataGridView Insertion_DataGridView)
        {

            InsertionDataGridView = Insertion_DataGridView;
        }
        //-Add
        //Add
        public void SetSimpleSearchDataGridView(DataGridView SimpleSearch_DataGridView)
        {

            SimpleSearchDataGridView = SimpleSearch_DataGridView;
        }
        //-Add


        //######################################################################################################################################################################################//
        //                                                                     Simple CD Search
        //######################################################################################################################################################################################//
        public string SimpleCDSearch(string mohtava = null, string Place = null, string LoanStatus = null)
        //LoanStatus Can be one of this three : "امانت داده","امانت گرفته",null
        //string Identification = null,
        {
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                                    Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            string Message = "1 Successful";
            string Conditions = null;
            string Table_Name_1 = null;
            string Table_Name_2 = null;
            string Tables_Name = null;
            string Columns = null;
            string WhereCondition = null;
            string OnCondition = null;
            string Query = null;



            // strCon = "Data Source=localhost;Initial Catalog=&quot;محصولات فرهنگی خانگی&quot;;Integrated Security=True";
            //strCon="Data Source=localhost;AttachDbFilename=|DataDirectory|\[محصولات فرهنگی خانگی].mdf;Integrated Security=True";
            DataSet dts = new DataSet();
            SqlCommand cmd;
            bool AndStatuse = false;    // for controlling And in condition
            /*
            if (Identification == "")
            {
                Identification = null;
            }
             * */
            if (mohtava == "")
            {
                mohtava = null;
            }
            if (Place == "")
            {
                Place = null;
            }
            if (LoanStatus == "")
            {
                LoanStatus = null;
            }
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                                    Analysis of Input
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //------------------------------------------------------------------
            // Part 1                  gaining Condition
            //------------------------------------------------------------------

            //----------------------------------------------------------//
            if (LoanStatus == null)
            {
                //----------------------------------------------------  
                //if (Identification == null)
                //{
                /*
                if (Identification != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    Conditions = "[ لوح فشرده و نرم افزار].[شناسه لوح فشرده و نرم افزار]= N'" + Identification + "'";
                    AndStatuse = true;
                }
                 */
                //--------------------------------------
                if (mohtava != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                  //  Message = verify.IsValidmohtava(mohtava);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }
                    Conditions += "[لوح فشرده و نرم افزار].[محتوا]= N'" + mohtava + "'";                               //Add 'N' and '
                    AndStatuse = true;
                }
                //--------------------------------------
                if (Place != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    Message = verify.IsValidCharacter(Place, 50, true);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }
                    Conditions += "[لوح فشرده و نرم افزار].[مکان]= N'" + Place + "'";                               //Add 'N' and 
                    AndStatuse = true;
                }
                //--------------------------------------




            } //End if (loanStatus == null)


            //------------------------------------------------------------------------------------------
            else   // if Loanstatus have entity
            {

                //if (Identification == null)
                //{
                /*
                if (Identification != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    Conditions = "[لوح فشرده و نرم افزار].[شناسه لوح فشرده و نرم افزار]= N'" + Identification + "'";
                    AndStatuse = true;
                }
                 */
                //-----------------------------------------------------------------------------------------
                if (mohtava != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    //Message = verify.IsValidmohtava(mohtava);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }
                    Conditions += "[لوح فشرده و نرم افزار].[محتوا]= N'" + mohtava + "'";
                    AndStatuse = true;
                }
                //-----------------------------------------------------------------------------------------
                if (Place != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    Message = verify.IsValidCharacter(Place, 50, true);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }
                    Conditions += "[لوح فشرده و نرم افزار].[مکان]= N'" + Place + "'";
                    AndStatuse = true;
                }
                //-----------------------------------------------------------------------------------------
                //                           related to loanstatus
                //-----------------------------------------------------------------------------------------

                if (LoanStatus == this.LoanStatus[0] || LoanStatus == this.LoanStatus[1])                                          //Add
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    Conditions += " [امانت لوح فشرده و نرم افزار].[وضعیت امانت] = N'" + LoanStatus + "'";                                            //Add 'N' and 
                    AndStatuse = true;
                }                                                                                                               ////Add
                else
                {
                    Message = "0 LoanStatus is invalide";
                    return Message;
                }
            }
            if (AndStatuse)
            {
                WhereCondition = " Where " + Conditions;
            }
            OnCondition += " on [لوح فشرده و نرم افزار].[شناسه لوح فشرده و نرم افزار]=" + "[امانت لوح فشرده و نرم افزار].[شناسه لوح فشرده و نرم افزار]";      //Add
            //******************************************************************//
            //                 OutPut of part 1 is    Conditions                //
            //******************************************************************//
            //------------------------------------------------------------------
            // Part 2                  gaining Tables_Name
            //------------------------------------------------------------------
            Table_Name_1 = "[محصولات فرهنگی خانگی].[dbo].[لوح فشرده و نرم افزار]";
            Table_Name_2 = "[محصولات فرهنگی خانگی].[dbo].[امانت لوح فشرده و نرم افزار]";
            /*
            Tables_Name = Table_Name_1;
            if (Table_Name_2 != null)
            {
                Tables_Name += ',';
                Tables_Name += Table_Name_2;
            }
             */
            //******************************************************************//
            //                 OutPut of part 2 is    Tables_Name               //
            //******************************************************************//
            //------------------------------------------------------------------
            // Part 3                  gaining Columns
            //------------------------------------------------------------------

            Columns = "[لوح فشرده و نرم افزار].* , [امانت لوح فشرده و نرم افزار].[وضعیت امانت]";                  // incomplete**

            //******************************************************************//
            //                 OutPut of part 3 is    Columns                   //
            //******************************************************************//

            //-----------------------------------------------------------------------------
            //                              Deleting [جدول نمایش]
            //-----------------------------------------------------------------------------

            try
            {
                connection = new SqlConnection(strCon);
                connection.Open();
                Query = "drop Table" + " [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] ";

                cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }
            //-----------------------------------------------------------------------------
            //END                        Deleting [جدول نمایش]
            //-----------------------------------------------------------------------------

            //-----------------------------------------------------------------------------
            //                  Execute select Query and showing it in [جدول نمایش]
            //-----------------------------------------------------------------------------

            //Query = "SELECT " + Columns +" into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] "+ "FROM" + Tables_Name + "WHERE" + Conditions;
            Query = "SELECT " + Columns + " into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] " + "FROM" + Table_Name_1 + "Full join" + Table_Name_2 + OnCondition + WhereCondition;

            connection = new SqlConnection(strCon);
            connection.Open();
            cmd = new SqlCommand(Query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            //-----------------------------------------------------------------------------
            //END of           Execute select Query and showing it in [جدول نمایش]
            //-----------------------------------------------------------------------------
            return Message;
        }

        //######################################################################################################################################################################################//
        //       END Of                                                        Simple CD Search
        //######################################################################################################################################################################################//


        //######################################################################################################################################################################################//
        //                                                                    Complete CD Search
        //######################################################################################################################################################################################//
        public string CompleteCDSearch(string Name , string[] Mohtava ,string Price, string FavoriteDegree )
        {
            string Message = "Search completed.";
            string TableName = null;
            string LoanTableName = null;
            string SearchQuery = null;
            string Columns = null;
            string WhereCondition = null;
            string OnCondition = null;
            bool AndStatus = false;
            bool OrStatus = false;



            TableName = "[محصولات فرهنگی خانگی].[dbo].[لوح فشرده و نرم افزار]";
            LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت لوح فشرده و نرم افزار]";

            if(Name != null && Name != "")
            {
                Message = verify.IsValidCharacter(Name, 20, true);
                if(Message[0] == '0')
                {
                    Message = "0 Invalid input";
                }
                if(AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[لوح فشرده و نرم افزار].[نام]= N'" + Name + "'";
                AndStatus = true;
            }

            if(Mohtava != null)
            {
                if (Mohtava.Length != 0)
                {
                    if (AndStatus)
                    {
                        WhereCondition += " and ";
                    }

                    for (int i = 0; i < Mohtava.Length; i++)
                    {
                        Message = verify.IsValidCharacter(Mohtava[i], 20, true);
                        if (Message[0] == '0')
                        {
                            Message = "0 Invalid input";
                        }
                        if (i == 0)
                        {
                            WhereCondition += " ( ";
                        }

                        if (OrStatus)
                        {
                            WhereCondition += " or ";
                        }
                        WhereCondition += "[لوح فشرده و نرم افزار].[محتوا]= N'" + Mohtava[i] + "'";
                        if (i == Mohtava.Length - 1)
                        {
                            WhereCondition = WhereCondition + " ) ";
                        }
                        OrStatus = true;
                    }
                    AndStatus = true;
                }

            }

            if (Price != null && Price != "")
            {
                Message = verify.IsValidNumber(Price,MaxNumber_Def,MinNumber_Def, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                }
                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[لوح فشرده و نرم افزار].[قیمت]= N'" + Price + "'";
                AndStatus = true;
            }

            if (FavoriteDegree != null && FavoriteDegree != "")
            {
                Message = verify.IsValidFavoriteDegree(FavoriteDegree);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                }
                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[لوح فشرده و نرم افزار].[درجه علاقه مندی]= N'" + FavoriteDegree + "'";
                AndStatus = true;
            }
            if(AndStatus)
            {
                WhereCondition = "where " + WhereCondition;
            }
            OnCondition += " on [لوح فشرده و نرم افزار].[شناسه لوح فشرده و نرم افزار]=" + "[امانت لوح فشرده و نرم افزار].[شناسه لوح فشرده و نرم افزار]";
            Columns = "[لوح فشرده و نرم افزار].* , [امانت لوح فشرده و نرم افزار].[وضعیت امانت]";                  

            SearchQuery = "SELECT " + Columns + " into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] " + "FROM" + TableName + "Full join" + LoanTableName + OnCondition + WhereCondition;
            //MessageBox.Show(SearchQuery);
            AnyTypeSearch(SearchQuery);
            
            return Message;
        }

        //######################################################################################################################################################################################//
        //          END Of                                                    Complete CD Search
        //######################################################################################################################################################################################//
        //######################################################################################################################################################################################//
        //                                                                     Insides in Search
        //######################################################################################################################################################################################//
        public string AnyTypeSearch(string Query)
        //LoanStatus Can be one of this three : "امانت داده","امانت گرفته",null
        //string Identification = null,
        {
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                                    Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            string Message = "1 Successful";
            string Conditions = null;
            string LoanTableName = null;
            string Columns = null;
            string WhereCondition = null;
            string OnCondition = null;
            string DropQuery = null;
            //string Query = null;



            // strCon = "Data Source=localhost;Initial Catalog=&quot;محصولات فرهنگی خانگی&quot;;Integrated Security=True";
            //strCon="Data Source=localhost;AttachDbFilename=|DataDirectory|\[محصولات فرهنگی خانگی].mdf;Integrated Security=True";
            DataSet dts = new DataSet();
            SqlCommand cmd;
            bool AndStatuse = false;    // for controlling And in condition

            //-----------------------------------------------------------------------------
            //                              Deleting [جدول نمایش]
            //-----------------------------------------------------------------------------

            try
            {
                connection = new SqlConnection(strCon);
                connection.Open();
                DropQuery = "drop Table" + " [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] ";

                cmd = new SqlCommand(DropQuery, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }
            //-----------------------------------------------------------------------------
            //END                        Deleting [جدول نمایش]
            //-----------------------------------------------------------------------------

            //-----------------------------------------------------------------------------
            //                  Execute select Query and showing it in [جدول نمایش]
            //-----------------------------------------------------------------------------

            try
            {
                // Query = "SELECT " + Columns + " into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] " + "FROM" + LoanTableName + WhereCondition;
                //MessageBox.Show(Query);
                connection = new SqlConnection(strCon);
                connection.Open();
                cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch
            {
                Message = "0 Error in Searching into Loan Table. 00";
                MessageBox.Show("** Error in Searching into Loan Table whith this query :\n" + Query);
            }

            //-----------------------------------------------------------------------------
            //END of           Execute select Query and showing it in [جدول نمایش]
            //-----------------------------------------------------------------------------
            return Message;
        }

        //######################################################################################################################################################################################//
        //End of                                                              Insides in Search
        //######################################################################################################################################################################################//
 


        //######################################################################################################################################################################################//
        //                                                                              Insertion
        //######################################################################################################################################################################################//

        public string InsertCD(string name, string mohtava, string ghaymat, string makan, string tozihat, string idkarbar, string vazeat)
        {
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                                    Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            string id = null;
            string Message = "1 Successful";
            string InsertQuery = null;
            string Table_Name_1 = null;
            string Table_Name_2 = null;
            string Tables_Name = null;
            string Columns = null;
            string WhereCondition = null;
            string OnCondition = null;
            string Query = null;
            string InsertLoanCondition = null;

            // strCon = "Data Source=localhost;Initial Catalog=&quot;محصولات فرهنگی خانگی&quot;;Integrated Security=True";
            //strCon="Data Source=localhost;AttachDbFilename=|DataDirectory|\[محصولات فرهنگی خانگی].mdf;Integrated Security=True";
            DataSet dts = new DataSet();
            SqlCommand cmd;


            if (id == "" || id == null)                                               //   ******************   namealbum -> id 
            {
                id = "1";
            }
            if (name == "" || name == null)
            {
                Message = "0 Data is't correct. Data have to gain value.";
                return Message;
            }

            if (mohtava == "")
            {
                mohtava = null;
            }
            if (ghaymat == "")
            {
                ghaymat = null;
            }
            if (makan == "")
            {
                makan = null;
            }
            if (tozihat == "")
            {
                tozihat = null;
            }



            //***********************************************************************************************//
            //                finding number of rows in Table and Gaining InsertQuery                         //
            //************************************************************************************************//
            Message = SimpleCDSearch(null, null, null);                                                      //Simple Search for Showing Entire ralated Table

            if (Message[0] == '1')                                       // it's found
            {

                ShowingDataInInsertionDataGridView();                                                                   // Showing That table 

                Table_Name_1 = "[محصولات فرهنگی خانگی].[dbo].[لوح فشرده و نرم افزار]";                                                                  //&&&&&&&&&&&&&
                Table_Name_2 = "[محصولات فرهنگی خانگی].[dbo].[امانت لوح فشرده و نرم افزار]";                                                            //&&&&&&&&&&&&
                //-----------------------------------------------------------------------------
                //                Process on [جدول نمایش] after SimpleSearchView
                //-----------------------------------------------------------------------------

                int Number = NumberOfElementsInTable();                                                     //compute id from table rows number!
                if (Convert.ToInt32(id) <= Number)
                {
                    id = Convert.ToString(Number + 1);
                }

                InsertQuery = "INSERT INTO " + Table_Name_1 + "( [شناسه لوح فشرده و نرم افزار]," + "[نام], " + "[محتوا], " + "[قیمت], " + "[مکان] , " + "[توضیحات]  " + ")VAlUES( N'" + id;

                if (name != null)
                {

                    Message = verify.IsValidCharacter(name, 20, false);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }


                }
                InsertQuery += "',N'" + name;
                //-------------------------------------------------
                if (mohtava != null)
                {

                  //  Message = verify.IsValidnoemadrak(mohtava);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }


                }
                InsertQuery += "',N'" + mohtava;
                //-------------------------------------------------
                //-------------------------------------------------
                if (ghaymat != null)
                {

                    //  Message = verify.IsValidnoemadrak(mohtava);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }


                }
                InsertQuery += "',N'" + ghaymat;
                //--------------------------------------
                if (makan != null)
                {
                    Message = verify.IsValidCharacter(makan, 50, true);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }


                }
                InsertQuery += "',N'" + makan;
                //----------------------------------------------------  
                if (tozihat != null)
                {

                    Message = verify.IsValidCharacter(tozihat, 500, true);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }


                }
                InsertQuery += "',N'" + tozihat;
                InsertQuery += "')";




                //******************************************************************//
                // End.               OutPut of part 2 is    in    InsertQuery      //
                //******************************************************************//



                //******************************************************************//
                // End.               OutPut of part 2 is    in    InsertQuery           //
                //******************************************************************//

                //Showing row that is same with entered data by user
                Message = SimpleCDSearch(mohtava, null, null);                                                          //&&&&&&&CD , Title

                if (Message[0] == '1')                                       // it's found
                {
                    //-----------------------------------------------------------------------------
                    //                      Showing Data in DataGridView
                    //-----------------------------------------------------------------------------
                    Message = ShowingDataInInsertionDataGridView();                                                             //Sowing that Same Rows


                    //-----------------------------------------------------------------------------
                    //END.                 Showing Data in DataGridView
                    //-----------------------------------------------------------------------------

                    int SameTableRow_Number = NumberOfElementsInTable();                                                    //Number of Same Rows

                    if (SameTableRow_Number != 0)                                           //if record have been in table before
                    //then ask if user want to replace it or do nothing
                    //  عمل جایگزین کردن : حذف رکورد مد نظر (از طریق شناسه )(که شامل حذف در امانت وهم خود نوع محصول می شود
                    //و دیگر اضافه کردن ازطریق داشتن کل اطلاعات محصول (کل کوئری) مقدور است
                    {


                        string DeleteLoanQuery = "Delete From " + Table_Name_2;                     //actually not necesssry
                        string DeleteQuery = "Delete From " + Table_Name_1;                         //actually not necesssry 

                        InsertPermitionForm InsertPermition = new InsertPermitionForm(Table_Name_2, Table_Name_1, "[شناسه لوح فشرده و نرم افزار]", InsertQuery, DeleteQuery, DeleteLoanQuery, "لوح فشرده و نرم افزار");
                        InsertPermition.SetInsertionDataGridView(InsertionDataGridView);
                        //&&&&&&&&&&&& [شناسه لوح فشرده و نرم افزار] bayad kelid bashad
                        InsertPermition.Show();
                    }
                    else                                                                                       //if there is no same row
                    {

                        ExecuteQuery execute = new ExecuteQuery();                  //Adding Process 
                        Message = execute.InsertQuery(InsertQuery);

                        SimpleCDSearch(null, null, null);                     //Shoing Table after Addition action
                        ShowingDataInInsertionDataGridView();
                        // Message = InsertQuery;
                    }
                    //int num=dts.Tables.Count;





                }
                else
                {
                    Message = "0 Error in simple searchin in CD to find same in Title";                                                    //&&&&&Title 
                }

                //***********************************************************************************************//
                // END.       Search in [لوح فشرده و نرم افزار] with SimpleCDSearch for finding same row               //
                //***********************************************************************************************//

            }
            else
            {
                Message = "0 Error in simple searchin in CD";
            }

            return Message;
        }


        //######################################################################################################################################################################################//
        //          END Of                                                              Insertion
        //######################################################################################################################################################################################//


        private int NumberOfElementsInTable()
        {

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                                    Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

            string Message = "1 Successful";
            string Query = null;


            // String strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
            // strCon = "Data Source=localhost;Initial Catalog=&quot;محصولات فرهنگی خانگی&quot;;Integrated Security=True";
            //strCon="Data Source=localhost;AttachDbFilename=|DataDirectory|\[محصولات فرهنگی خانگی].mdf;Integrated Security=True";
            DataSet dts = new DataSet();
            SqlCommand cmd;


            //-----------------------------------------------------------------------------
            //                Process on [جدول نمایش] after SimpleSearchView
            //-----------------------------------------------------------------------------
            try
            {
                // DataRow dr = new DataRow();
                DataTable dt = new DataTable();

                int ViewTableRow_Number = 0;
                Query = "SELECT * FROM [محصولات فرهنگی خانگی].[dbo].[جدول نمایش]";
                connection = new SqlConnection(strCon);
                connection.Open();
                dts.Clear();
                sqlDA = new SqlDataAdapter(Query, connection);
                sqlDA.Fill(dts, "[جدول نمایش]");
                dt = dts.Tables["[جدول نمایش]"];
                ViewTableRow_Number = dt.Rows.Count;


                connection.Close();
                return ViewTableRow_Number;
            }
            catch
            {
                Message = "Error in Simple Serach before insertion.";
                return 0;
            }

            //-----------------------------------------------------------------------------
            //   END Of      Process on [جدول نمایش] after SimpleSearchView
            //-----------------------------------------------------------------------------
        }


        public string ShowingDataInSimpleSearchDataGridViewView()
        {

            //-----------------------------------------------------------------------------
            //                               Deffinition
            //-----------------------------------------------------------------------------
            string Message = "1 Successfull.";
            //-----------------------------------------------------------------------------
            //                Viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------
            try
            {
                //SimpleSearchView.DataBindings.Clear();
                string Query = "SELECT * FROM [محصولات فرهنگی خانگی].[dbo].[جدول نمایش]";
                connection = new SqlConnection(strCon);
                connection.Open();
                dts.Clear();
                sqlDA = new SqlDataAdapter(Query, connection);
                sqlDA.Fill(dts, "[جدول نمایش]");

                int ViewTableRow_Number = 0;
                ViewTableRow_Number = dts.Tables["[جدول نمایش]"].Rows.Count;
                if (ViewTableRow_Number == 0)
                {

                    Message = "0 There is nothing found";
                }
                else
                {
                    Message = "1 " + "مقدار یافت شد " + Convert.ToString(ViewTableRow_Number) + "جستجو با موفقیت انجام شد و ";
                }
                //int num=dts.Tables.Count;
                //SimpleSearchView.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing data in SimpleSearchDataGridView";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------
            return Message;

        }
        //Add
        public string ShowingDataInInsertionDataGridView()
        {

            //-----------------------------------------------------------------------------
            //                               Deffinition
            //-----------------------------------------------------------------------------
            string Message = "1 Successfull.";
            //SqlDataAdapter connection;
            //string strCon;
            //-----------------------------------------------------------------------------
            //                Viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------
            try
            {
                InsertionDataGridView.DataBindings.Clear();
                dts = new DataSet();
                string Query = "SELECT * FROM [محصولات فرهنگی خانگی].[dbo].[جدول نمایش]";
                connection = new SqlConnection(strCon);
                connection.Open();
                dts.Clear();
                sqlDA = new SqlDataAdapter(Query, connection);
                sqlDA.Fill(dts, "[جدول نمایش]");

                int ViewTableRow_Number = 0;
                ViewTableRow_Number = dts.Tables["[جدول نمایش]"].Rows.Count;
                if (ViewTableRow_Number == 0)
                {

                    Message = "0 There is nothing found";
                }
                else
                {
                    Message = "1 " + "مقدار یافت شد " + Convert.ToString(ViewTableRow_Number) + "جستجو با موفقیت انجام شد و ";
                }
                //int num=dts.Tables.Count;
                InsertionDataGridView.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing data in InsertionDataGridView";
            }
            return Message;
        }
    }


}













