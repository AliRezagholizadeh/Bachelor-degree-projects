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
    class Magazine
    {

        
        string[] LoanStatus;
        Verifications verify;
        int MaxNumber_Def;
        int MinNumber_Def;
        int MaxYear;
        int MinYear;
        int MaxLength;
        //Add
        DataGridView SimpleSearchDataGridView;
        DataGridView InsertionDataGridView;
        
        DataGridView DeleteDataGridView;
        DataGridView LoanDeleteDataGridView;
        DataGridView EditDataGridView;
        DataGridView CompleteSearchDataGridView;
        String strCon;
        SqlDataAdapter sqlDA;
        SqlConnection connection;
        DataSet dts;
        //-Add          
        private readonly List<bool> per;

        public Magazine()
        {
            //Add
            strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
            SimpleSearchDataGridView = null;
            InsertionDataGridView = null;
            EditDataGridView = null;
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
            MaxLength = 12;
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
        //Add		
        public void SetDeleteDataGridView(DataGridView Deleting_DataGridView)
        {

            DeleteDataGridView = Deleting_DataGridView;

        }
        public void SetEditDataGridView(DataGridView Editting_DataGridView)
        {
            EditDataGridView = Editting_DataGridView;
        }
        public void SetCompleteSearchDataGridView(DataGridView Complete_SearchDataGridView)
        {
            CompleteSearchDataGridView = Complete_SearchDataGridView;
        }
       	
        public void SetDeleteLoanDataGridView(DataGridView LoanDeleting_DataGridView)		
        {		
            LoanDeleteDataGridView = LoanDeleting_DataGridView;		
        }		
        
        //-Add



        //######################################################################################################################################################################################//
        //                                                                     Simple Majale Search
        //######################################################################################################################################################################################//
        public string SimpleMajaleSearch(string Naam = null, string Place = null, string LoanStatus = null)
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
            if (Naam == "")
            {
                Naam = null;
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
                    Conditions = "[ مجله].[شناسه مجله]= N'" + Identification + "'";
                    AndStatuse = true;
                }
                 */
                //--------------------------------------
                if (Naam != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    Message = verify.IsValidCharacter(Naam, 20, false);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }
                    Conditions += "[مجله].[نام]= N'" + Naam + "'";
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
                    Conditions += "[مجله].[مکان]= N'" + Place + "'";                               //Add 'N' and 
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
                    Conditions = "[مجله].[شناسه مجله]= N'" + Identification + "'";
                    AndStatuse = true;
                }
                 */
                //-----------------------------------------------------------------------------------------
                if (Naam != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    Message = verify.IsValidCharacter(Naam, 20, false);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }
                    Conditions += "[مجله].[نام]= N'" + Naam + "'";
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
                    Conditions += "[مجله].[مکان]= N'" + Place + "'";
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
                    Conditions += " [امانت مجله].[وضعیت امانت] = N'" + LoanStatus + "'";                                            //Add 'N' and 
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
            OnCondition += " on [مجله].[شناسه مجله]=" + "[امانت مجله].[شناسه مجله]";      //Add
            //******************************************************************//
            //                 OutPut of part 1 is    Conditions                //
            //******************************************************************//
            //------------------------------------------------------------------
            // Part 2                  gaining Tables_Name
            //------------------------------------------------------------------
            Table_Name_1 = "[محصولات فرهنگی خانگی].[dbo].[مجله]";
            Table_Name_2 = "[محصولات فرهنگی خانگی].[dbo].[امانت مجله]";
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

            Columns = "[مجله].* , [امانت مجله].[وضعیت امانت]";                  // incomplete**

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
            try
            {
                //Query = "SELECT " + Columns +" into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] "+ "FROM" + Tables_Name + "WHERE" + Conditions;		
                Query = "SELECT " + Columns + " into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] " + "FROM" + Table_Name_1 + "Full join" + Table_Name_2 + OnCondition + WhereCondition;

                connection = new SqlConnection(strCon);
                connection.Open();
                cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch
            {
                Message = "0 Error in Simple Search.";
            }

            //-----------------------------------------------------------------------------
            //END of           Execute select Query and showing it in [جدول نمایش]
            //-----------------------------------------------------------------------------
            return Message;
        }
        //ADDDD		
        public string MajaleLoanSearch(string Id_Mahsoul, string Id_Karbar, string Vazeat)
        {
            string Message = "1 Search in loan is Done.";
            string LoanTableName = null;
            string WhereCondition = null;
            string SearchQuery = null;
            bool AndStatus = false;

            LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت مجله]";
            //WhereCondition = "where ";		
            if (Id_Mahsoul != null && Id_Mahsoul != "")
            {
                Message = verify.IsValidNumber(Id_Mahsoul, MaxNumber_Def, MinNumber_Def, true);
                if (Message[0] == '0')
                {
                    Message = "0 Id is not valid.";
                    return Message;
                }

                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[شناسه مجله] = N'" + Id_Mahsoul + "' ";
                AndStatus = true;
            }


            if (Id_Karbar != null && Id_Karbar != "")
            {
                Message = verify.IsValidNumber(Id_Karbar, MaxNumber_Def, MinNumber_Def, true);
                if (Message[0] == '0')
                {
                    Message = "0 Id is not valid.";
                    return Message;
                }

                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[شناسه افراد] = N'" + Id_Karbar + "' ";
                AndStatus = true;
            }

            if (Vazeat != null && Vazeat != "")
            {
                Message = verify.IsValidLoan(Vazeat);
                if (Message[0] == '0')
                {
                    Message = "0 vazeat amanat is not valid.";
                    return Message;
                }

                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[وضعیت امانت] = N'" + Vazeat + "' ";
                AndStatus = true;
            }


            if (AndStatus)
            {
                WhereCondition = " WHERE " + WhereCondition;
            }
            SearchQuery = "SELECT * INTO [محصولات فرهنگی خانگی].[dbo].[جدول نمایش]  FROM " + LoanTableName + WhereCondition;
            //MessageBox.Show(SearchQuery);
            Message = AnyTypeSearch(SearchQuery);
            return Message;
        }
        //--ADDDDD		


        //######################################################################################################################################################################################//
        //       END Of                                                        Simple Majale Search
        //######################################################################################################################################################################################//
        //######################################################################################################################################################################################//
        //                                                                    Complete Majale Search
        //######################################################################################################################################################################################//
        public string CompleteMajaleSearch(string Name, string title,string Moon,string Year, string Number, string FavoriteDegree)
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


            TableName = "[محصولات فرهنگی خانگی].[dbo].[مجله]";
            LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت مجله]";

            if (Name != null && Name != "")
            {
                Message = verify.IsValidCharacter(Name, 20, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                }
                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[مجله].[نام]= N'" + Name + "'";
                AndStatus = true;
            }

            if (title != null && title != "")
            {
                Message = verify.IsValidCharacter(title, 20, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                }
                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[مجله].[موضوع]= N'" + title + "'";
                AndStatus = true;
            }
            if (Year != null && Year != "")
            {
                Message = verify.IsValidNumber(Year, 9999, 100, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                }
                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[مجله].[سال]= N'" + Moon + "'";
                AndStatus = true;
            }


            if (Moon != null && Moon != "")
            {
                Message = verify.IsValidNumber(Moon,12, 1, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                }
                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[مجله].[ماه]= N'" + Moon + "'";
                AndStatus = true;
            }
            if (Number != null && Number != "")
            {
                Message = verify.IsValidNumber(Number , MaxNumber_Def, MinNumber_Def, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                }
                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[مجله].[شماره]= N'" + Number + "'";
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
                WhereCondition += "[مجله].[درجه علاقه مندی]= N'" + FavoriteDegree + "'";
                AndStatus = true;
            }
            if (AndStatus)
            {
                WhereCondition = "where " + WhereCondition;
            }
            OnCondition += " on [مجله].[شناسه مجله]=" + "[امانت مجله].[شناسه مجله]";
            Columns = "[مجله].* , [امانت مجله].[وضعیت امانت]";

            SearchQuery = "SELECT " + Columns + " into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] " + "FROM" + TableName + "Full join" + LoanTableName + OnCondition + WhereCondition;
            //MessageBox.Show(SearchQuery);
            AnyTypeSearch(SearchQuery);

            return Message;
        }


        //######################################################################################################################################################################################//
        //          END Of                                                    Complete Majale Search
        //######################################################################################################################################################################################//
        //######################################################################################################################################################################################//
        //                                                                              Insertion
        //######################################################################################################################################################################################//

        public string InsertMajale(string nam, string mozo, string sal, string mah, string shomare, string gheymat, string darajealaghemandi, string makan, string tozihat, string idkarbar, string vazeat)
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
            if (nam == "" || nam == null)
            {
                Message = "0 Data is't correct. Data have to gain value.";
                return Message;
            }
            if (mozo == "")
            {

                mozo = null;
            }
            if (sal == "" || sal == null)
            {
                sal = null;
                Message = "0 Data is't correct. Data have to gain value.";
                return Message;
            }
            if (mah == "" || mah == null)
            {
                mah = null;
                Message = "0 Data is't correct. Data have to gain value.";
                return Message;
            }
            if (shomare == "" || shomare == null)
            {
                shomare = null;
                Message = "0 Data is't correct. Data have to gain value.";
                return Message;
            }
            if (gheymat == "")
            {
                gheymat = null;
            }
            if (darajealaghemandi == "")
            {
                darajealaghemandi = null;
            }
            if (makan == "")
            {
                makan = null;
            }
            if (tozihat == "")
            {
                tozihat = null;
            }
            if (idkarbar == "")
            {
                idkarbar = null;
            }
            if (vazeat == "")
            {
                vazeat = null;
            }



            //***********************************************************************************************//
            //                finding number of rows in Table and Gaining InsertQuery                         //
            //************************************************************************************************//
            Message = SimpleMajaleSearch(null, null, null);                                                      //Simple Search for Showing Entire ralated Table

            if (Message[0] == '1')
            {

                ShowingDataInInsertionDataGridView();                                                                   // Showing That table 

                Table_Name_1 = "[محصولات فرهنگی خانگی].[dbo].[مجله]";                                                                  //&&&&&&&&&&&&&
                Table_Name_2 = "[محصولات فرهنگی خانگی].[dbo].[امانت مجله]";                                                            //&&&&&&&&&&&&
                //-----------------------------------------------------------------------------
                //                Process on [جدول نمایش] after SimpleSearchView
                //-----------------------------------------------------------------------------

                int Number = NumberOfElementsInTable();                                                     //compute id from table rows number!
                if (Convert.ToInt32(id) <= Number)
                {
                    id = Convert.ToString(Number + 1);
                }

                InsertQuery = "INSERT INTO " + Table_Name_1 + "( [شناسه مجله]," + "[نام], " + "[موضوع], " + "[سال], " + "[ماه], " + "[شماره], " + "[قیمت], " + "[میزان علاقه مندی], " + "[مکان] , " + "[توضیحات]  " + ")VAlUES( N'" + id;


                if (nam != null)
                {

                    Message = verify.IsValidCharacter(nam, 20, false);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }
                }
                InsertQuery += "',N'" + nam;

                //-------------------------------------------------
                if (mozo != null)
                {

                    Message = verify.IsValidCharacter(mozo, 20, true);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }
                }
                InsertQuery += "',N'" + mozo;
                //-------------------------------------------------
                if (sal != null)
                {
                    Message = verify.IsValidNumber(sal, MaxYear, MinYear, false);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }

                }
                InsertQuery += "',N'" + sal;
                //-------------------------------------------------
                if (mah != null)
                {
                    // Message = verify.IsValidDate(mah);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }

                }
                InsertQuery += "',N'" + mah;
                //--------------------------------------------------------
                if (shomare != null)
                {
                    Message = verify.IsValidNumber(shomare, MaxNumber_Def, MinNumber_Def, false);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }

                }
                InsertQuery += "',N'" + shomare;
                //--------------------------------------------------------
                if (gheymat != null)
                {
                    Message = verify.IsValidNumber(gheymat, MaxNumber_Def, MinNumber_Def, true);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }

                }
                InsertQuery += "',N'" + gheymat;
                //-------------------------------------------------
                if (darajealaghemandi != null)
                {

                    Message = verify.IsValidFavoriteDegree(darajealaghemandi);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }


                }
                InsertQuery += "',N'" + darajealaghemandi;
                //-------------------------------------------------
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
                Message = SimpleMajaleSearch(nam, null, null);                                                          //&&&&&&&Majale , Naam

                if (Message[0] == '1')                                       // it's found
                {
                    //-----------------------------------------------------------------------------
                    //                      Showing Data in DataGridView
                    //-----------------------------------------------------------------------------
                    Message = ShowingDataInInsertionDataGridView();                                                             //Sowing that Same Rows


                    //-----------------------------------------------------------------------------
                    //END.                 Showing Data in DataGridView
                    //-----------------------------------------------------------------------------

                    int SameTableRow_Number = NumberOfElementsInTable();

                    if (SameTableRow_Number != 0)                                           //if record have been in table before
                    //then ask if user want to replace it or do nothing
                    //  عمل جایگزین کردن : حذف رکورد مد نظر (از طریق شناسه )(که شامل حذف در امانت وهم خود نوع محصول می شود
                    //و دیگر اضافه کردن ازطریق داشتن کل اطلاعات محصول (کل کوئری) مقدور است
                    {


                        string DeleteLoanQuery = "Delete From " + Table_Name_2;                     //actually not necesssry
                        string DeleteQuery = "Delete From " + Table_Name_1;                         //actually not necesssry 

                        InsertPermitionForm InsertPermition = new InsertPermitionForm(Table_Name_2, Table_Name_1, "[شناسه مجله]", InsertQuery, DeleteQuery, DeleteLoanQuery, "مجله");
                        InsertPermition.SetInsertionDataGridView(InsertionDataGridView);
                        //&&&&&&&&&&&& [شناسه مجله] bayad kelid bashad
                        InsertPermition.Show();
                    }
                    else                                                                                       //if there is no same row
                    {

                        ExecuteQuery execute = new ExecuteQuery();                  //Adding Process 
                        Message = execute.InsertQuery(InsertQuery);

                        SimpleMajaleSearch(null, null, null);                     //Shoing Table after Addition action
                        ShowingDataInInsertionDataGridView();
                        // Message = InsertQuery;
                    }
                    //int num=dts.Tables.Count;





                }
                else
                {
                    Message = "0 Error in simple searchin in Majale to find same in Naam";                                                    //&&&&&Naam 
                }

                //***********************************************************************************************//
                // END.       Search in [مجله] with SimpleMajaleSearch for finding same row               //
                //***********************************************************************************************//

            }
            else
            {
                Message = "0 Error in simple searchin in Majale";
            }

            return Message;
        }


        //######################################################################################################################################################################################//
        //          END Of                                                              Insertion
        //######################################################################################################################################################################################//
        //######################################################################################################################################################################################//		
        //                                                                              Deletting		
        //######################################################################################################################################################################################//		

        public string DeleteMajale(string[] Id)
        {

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//		
            //                                                                                    Deffinition		
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//		

            string Message = "1 Successful";
            string DeleteQuery = null;
            string WhereCondition = null;

            string DeleteLoanQuery = null;
            string LoanWhereCondition = null;

            string TableName = null;
            string LoanTableName = null;
            string Query = null;
            DataSet dts = new DataSet();

            TableName = "[محصولات فرهنگی خانگی].[dbo].[مجله]";                                                                  //&&&&&&&&&&&&&		
            LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت مجله]";                                                            //&&&&&&&&&&&&		

            if (Id.Length == 0)
            {
                Message = "0 Error.Nothing entered as id!";
                return Message;
            }

            //Id_Prev[0]		
            WhereCondition = " where " + "( [مجله].[شناسه مجله] = N'" + Id[0] + "' ";
            LoanWhereCondition = " where " + "( [امانت مجله].[شناسه مجله] = N'" + Id[0] + "' ";
            for (int i = 1; i < Id.Length; i++)
            {
                if (Id[i] != null)
                {
                    WhereCondition += "or [مجله].[شناسه مجله] = N'" + Id[i] + "' ";
                    LoanWhereCondition += "or [امانت مجله].[شناسه مجله] = N'" + Id[i] + "' ";
                }
            }
            LoanWhereCondition += " )";
            WhereCondition += " )";

            SimpleMajaleSearch(null, null, null);
            ShowingDataInDeleteDataGridView();

            DeleteQuery = "Delete From" + TableName + WhereCondition;
            DeleteLoanQuery = "Delete From" + LoanTableName + LoanWhereCondition;



            Query = "select * " + " into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] " + " From " + LoanTableName + LoanWhereCondition;       //same row in loan table		
            Message = AnyTypeSearch(Query);                                                                                                 //gaining Same row		

            //MessageBox.Show(Message);

            if (Message[0] == '1')
            {
                int SameLoanRow = NumberOfElementsInTable();
                if (SameLoanRow > 0)
                {
                    LoanDeletingPermition LDP = new LoanDeletingPermition(DeleteQuery, DeleteLoanQuery, "مجله", "امانت مجله", TableName, LoanTableName);
                    LDP.SetDeleteDataGridView(DeleteDataGridView);
                    LDP.Show();

                    SimpleMajaleSearch(null, null, null);
                    ShowingDataInDeleteDataGridView();

                }
                else
                {
                    ExecuteQuery execute = new ExecuteQuery();
                    execute.DeleteQuery(DeleteQuery);
                    SimpleMajaleSearch(null, null, null);
                    ShowingDataInDeleteDataGridView();

                }

            }
            else
            {
                Message = "0 Error in Searching in Loan Table. ";
            }


            return Message;
        }


        //######################################################################################################################################################################################//		
        //          END Of                                                              Deleting		
        //######################################################################################################################################################################################//		
        //######################################################################################################################################################################################//		
        //                                                                              Editting		
        //######################################################################################################################################################################################//		

        public string EditMajale(string nam_New, string mozo_New, string sal_New, string mah_New, string shomare_New, string gheymat_New, string darajealaghemandi_New, string makan_New, string tozihat_New, string Id_Prev)
        {

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//		
            //                                                                                    Deffinition		
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//		

            string Message = "1 Successful";
            string DeleteQuery = null;
            string WhereCondition = null;
            string SetCondition = null;
            bool AndStatus = false;

            string DeleteLoanQuery = null;
            string LoanWhereCondition = null;

            string TableName = null;
            string LoanTableName = null;
            string UpdateQuery = null;
            DataSet dts = new DataSet();
            verify = new Verifications();

            TableName = "[محصولات فرهنگی خانگی].[dbo].[مجله]";                                                                  //&&&&&&&&&&&&&		
            //LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت مجله]";                                                            //&&&&&&&&&&&&		
            if (nam_New == "")
            {
                nam_New = null;
            }

            if(mozo_New == "" )
            {
                mozo_New = null;
            }
            if (sal_New == "")
            {
                sal_New = null;
            }
            if (mah_New == "")
            {
                mah_New = null;
            }
            if (shomare_New == "")
            {
                shomare_New = null;
            }
            if (gheymat_New == "")
            {
                gheymat_New = null;
            }
            if (darajealaghemandi_New == "")
            {
                darajealaghemandi_New = null;
            }
            if (makan_New == "")
            {
                makan_New = null;
            }
            if (tozihat_New == "")
            {
                tozihat_New = null;
            }



            //----------------------------------------------------------------------------------------------------------------------------------------
            if (Id_Prev == "" || Id_Prev == null)
            {
                Message = "0 Error.Nothing entered as id!";
                return Message;
            }

            WhereCondition = " where " + "( [مجله].[شناسه مجله] = N'" + Id_Prev + "' ";
            //LoanWhereCondition = " where " + "( [امانت مجله].[شناسه مجله] = N'" + Id_Prev + "' ";		

            // LoanWhereCondition += " )";		
            WhereCondition += " )";
            //===================================Achievig Set Condition==============================		
            if (nam_New != null)
            {

                Message = verify.IsValidCharacter(nam_New, 20, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[نام] = N'" + nam_New + "' ";
                AndStatus = true;
            }
            //-------------------------------------------------		
            if (mozo_New != null)
            {

                Message = verify.IsValidCharacter(mozo_New, 20, false);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[موضوع] = N'" + mozo_New + "' ";
                AndStatus = true;
            }
            //-------------------------------------------------		
            if (sal_New != null)
            {
                Message = verify.IsValidNumber(sal_New, MaxYear, MinYear, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[سال] = N'" + sal_New + "' ";
                AndStatus = true;
            }
            //-------------------------------------------------		
            if (mah_New != null)
            {
                Message = verify.IsValidDate(mah_New);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[ماه] = N'" + mah_New + "' ";
                AndStatus = true;
            }
            //-------------------------------------------------		
            if (shomare_New != null)
            {
                Message = verify.IsValidNumber(shomare_New, MaxNumber_Def, MinNumber_Def, false);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[شماره] = N'" + shomare_New + "' ";
                AndStatus = true;
            }
            //-------------------------------------------------		
            if (gheymat_New != null)
            {
                Message = verify.IsValidNumber(gheymat_New, MaxNumber_Def, MinNumber_Def, false);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[قیمت] = N'" + gheymat_New + "' ";
                AndStatus = true;
            }
            //-------------------------------------------------		
            //-------------------------------------------------		
            if (darajealaghemandi_New != null)
            {

                Message = verify.IsValidFavoriteDegree(darajealaghemandi_New);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[میزان علاقه مندی] = N'" + darajealaghemandi_New + "' ";
                AndStatus = true;
            }

            //-------------------------------------------------		
            if (makan_New != null)
            {
                Message = verify.IsValidCharacter(makan_New, 50, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }

                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[مکان] = N'" + makan_New + "' ";
                AndStatus = true;
            }


            //----------------------------------------------------  		
            if (tozihat_New != null)
            {
                Message = verify.IsValidCharacter(tozihat_New, 500, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }

                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[توضیحات] = N'" + tozihat_New + "' ";
                AndStatus = true;
            }
            if (AndStatus)
            {
                SetCondition = " set " + SetCondition;
            }
            //===================End of==========Achievig Set Condition==============================		
            //===================================Achievig Update Query===============================		
            try
            {

                UpdateQuery = "Update " + TableName + SetCondition + WhereCondition;
                //MessageBox.Show(UpdateQuery);
                ExecuteQuery execute = new ExecuteQuery();
                Message = execute.EditeQuery(UpdateQuery);
            }
            catch
            {
                Message = "0 Error in Loan Editting .";
            }
            if (Message[0] == '1')
            {
                SimpleMajaleSearch(null, null, null);
                ShowingDataInEditDataGridView();

            }

            return Message;

        }

        public string EditLoanMajale(string Id_Prev, string Idkarbar_Prev, string Vazeat_Prev, string Id_New, string Idkarbar_New, string Vazeat_New)
        {

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//		
            //                                                                                    Deffinition		
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//		

            string Message = "1 Successfully Edited.";
            string DeleteQuery = null;
            string WhereCondition = null;
            string SetCondition = null;
            bool AndStatus = false;

            string DeleteLoanQuery = null;
            string LoanWhereCondition = null;

            string TableName = null;
            string LoanTableName = null;
            string UpdateQuery = null;
            DataSet dts = new DataSet();
            verify = new Verifications();

            //TableName = "[محصولات فرهنگی خانگی].[dbo].[مجله]";                                                                  //&&&&&&&&&&&&&		
            LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت مجله]";                                                            //&&&&&&&&&&&&		

            if (Id_Prev == "" || Id_Prev == null)
            {
                Message = "0 Error.Nothing entered as id!";
                return Message;
            }

            if (Idkarbar_Prev == "" || Idkarbar_Prev == null)
            {
                Message = "0 Error.Nothing entered as id!";
                return Message;
            }

            if (Vazeat_Prev == "" || Vazeat_Prev == null)
            {
                Message = "0 Error.Nothing entered as id!";
                return Message;
            }
            LoanWhereCondition = " where " + " [امانت مجله].[شناسه مجله] = N'" + Id_Prev + "' " + "and [امانت مجله].[شناسه افراد] = N'" + Idkarbar_Prev + "' " + "and [امانت مجله].[وضعیت امانت] = N'" + Vazeat_Prev + "'";

            // WhereCondition += " )";		
            //===================================Achievig Set Condition==============================		
            //SetCondition = "Set ";		
            // subject_New,  afrad_New,  sal_New,  mahalegereftaneax_New,  makan_New,  tozihat_New		

            if (Id_New != null && Id_New != "")
            {

                Message = verify.IsValidNumber(Id_New, MaxNumber_Def, MinNumber_Def, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                if (AndStatus)
                {
                    SetCondition += ", ";
                }
                SetCondition += "[شناسه مجله] = N'" + Id_New + "' ";
                AndStatus = true;
            }


            if (Idkarbar_New != null && Idkarbar_New != "")
            {
                Message = verify.IsValidNumber(Idkarbar_New, MaxNumber_Def, MinNumber_Def, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }

                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[شناسه افراد] = N'" + Idkarbar_New + "' ";
                AndStatus = true;
            }


            if (Vazeat_New != null)
            {
                Message = verify.IsValidLoan(Vazeat_New);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }

                if (AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[وضعیت امانت] = N'" + Vazeat_New + "' ";
                AndStatus = true;
            }

            if (AndStatus)
            {
                SetCondition = "set " + SetCondition;
            }
            else
            {
                Message = "0 Enter some enteries to update.";
                return Message;
            }

            //===================End of==========Achievig Set Condition==============================		
            //===================================Achievig Update Query===============================		

            try
            {
                UpdateQuery = "Update " + LoanTableName + SetCondition + WhereCondition;
                ExecuteQuery execute = new ExecuteQuery();
                Message = execute.EditeQuery(UpdateQuery);
            }
            catch
            {
                Message = "0 Error in Loan Editting .";
            }
            if (Message[0] == '1')
            {
                MajaleLoanSearch(null, null, null);
                ShowingDataInEditDataGridView();

            }

            return Message;

        }

        //######################################################################################################################################################################################//	
        //          END Of                                                              Editting		
        //######################################################################################################################################################################################//		
        //######################################################################################################################################################################################//		
        //                                                                           Inside Functions		
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


        //Add
        //*********************************************************************************************************************************************************************************************//
        //  End of                                                                               Showing Table
        //*********************************************************************************************************************************************************************************************//
        /*
        public string ShowingDataInSimpleSearchDataGrid()
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
                SimpleSearchDataGrid.DataBindings.Clear();
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
                    Message = "1 : " + "جستجو با موفقیت انجام شد و " + Convert.ToString(ViewTableRow_Number) + " مقدار یافت شد ";
                }
                //int num=dts.Tables.Count;
                SimpleSearchDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing ViewTable";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------
            return Message;

        }
        */
        public string ShowingDataInSimpleSearchDataGridView()
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
                SimpleSearchDataGridView.DataBindings.Clear();

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
                    Message = "1 : " + "جستجو با موفقیت انجام شد و " + Convert.ToString(ViewTableRow_Number) + " مقدار یافت شد ";
                }
                //int num=dts.Tables.Count;
                SimpleSearchDataGridView.DataSource = dts.Tables["[جدول نمایش]"];
                //SimpleSearchDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing ViewTable";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------
            return Message;

        }
        //Add
        /*
        public string ShowingDataInInsertionDataGrid()
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
                dts = new DataSet();
                InsertionDataGrid.DataBindings.Clear();
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
                    Message = "1 : " + "جستجو با موفقیت انجام شد و " + Convert.ToString(ViewTableRow_Number) + " مقدار یافت شد ";
                }
                //int num=dts.Tables.Count;
                InsertionDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing ViewTable";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------

            return Message;

        }
        */
        public string ShowingDataInInsertionDataGridView()
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
                    Message = "1 : " + "جستجو با موفقیت انجام شد و " + Convert.ToString(ViewTableRow_Number) + " مقدار یافت شد ";
                }
                //int num=dts.Tables.Count;
                InsertionDataGridView.DataSource = dts.Tables["[جدول نمایش]"];
                //SimpleSearchDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing ViewTable";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------
            return Message;

        }
        /*
        public string ShowingDataInDeleteDataGrid()
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
                DeleteDataGrid.DataBindings.Clear();
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

                    Message = "0 There is nothing found in Viewing Table";
                }
                else
                {
                    Message = "1 : " + "جستجو با موفقیت انجام شد و " + Convert.ToString(ViewTableRow_Number) + " مقدار یافت شد ";
                }
                //int num=dts.Tables.Count;
                DeleteDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing data in SimpleSearchDataGrid";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------

            return Message;

        }
        */
        public string ShowingDataInDeleteDataGridView()
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

                DeleteDataGridView.DataBindings.Clear();
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
                    Message = "1 : " + "جستجو با موفقیت انجام شد و " + Convert.ToString(ViewTableRow_Number) + " مقدار یافت شد ";
                }
                DeleteDataGridView.DataSource = dts.Tables["[جدول نمایش]"];
                //SimpleSearchDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing ViewTable";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------
            return Message;

        }
        /*
        public string ShowingDataInEditDataGrid()
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
                EditDataGrid.DataBindings.Clear();
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

                    Message = "0 There is nothing found in Viewing Table";
                }
                else
                {
                    Message = "1 : " + "جستجو با موفقیت انجام شد و " + Convert.ToString(ViewTableRow_Number) + " مقدار یافت شد ";
                }
                //int num=dts.Tables.Count;
                EditDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing data in SimpleSearchDataGrid";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------

            return Message;

        }
        */
        public string ShowingDataInEditDataGridView()
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

                EditDataGridView.DataBindings.Clear();
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
                    Message = "1 : " + "جستجو با موفقیت انجام شد و " + Convert.ToString(ViewTableRow_Number) + " مقدار یافت شد ";
                }
                EditDataGridView.DataSource = dts.Tables["[جدول نمایش]"];
                //SimpleSearchDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing ViewTable";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------
            return Message;

        }
        /*
        public string ShowingDataInCompleteSearchDataGrid()
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
                CompleteSearchDataGrid.DataBindings.Clear();
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

                    Message = "0 There is nothing found in Viewing Table";
                }
                else
                {
                    Message = "1 " + "مقدار یافت شد " + Convert.ToString(ViewTableRow_Number) + "جستجو با موفقیت انجام شد و ";
                }
                //int num=dts.Tables.Count;
                CompleteSearchDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing data in SimpleSearchDataGrid";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------

            return Message;

        }
         */
        public string ShowingDataInCompleteSearchDataGridView()
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

                CompleteSearchDataGridView.DataBindings.Clear();
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
                    Message = "1 : " + "جستجو با موفقیت انجام شد و " + Convert.ToString(ViewTableRow_Number) + " مقدار یافت شد ";
                }
                CompleteSearchDataGridView.DataSource = dts.Tables["[جدول نمایش]"];
                //SimpleSearchDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing ViewTable";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------
            return Message;

        }

        //*********************************************************************************************************************************************************************************************//
        //  End of                                                                               Showing Table
        //*********************************************************************************************************************************************************************************************//
    


    }
}
