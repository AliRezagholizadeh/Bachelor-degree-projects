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
    class Gallery
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
        DataGridView DeleteDataGridView;
        DataGridView LoanDeleteDataGridView;
        DataGridView CompleteSearchDataGridView;
        DataGridView EditDataGridView;
        String strCon;
        SqlDataAdapter sqlDA;
        SqlConnection connection;
        DataSet dts;
        //-Add          
        private readonly List<bool> per;

        public Gallery()
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
        /*
        public void SetDeleteLoanDataGridView(DataGridView LoanDeleting_DataGridView)
        {


            LoanDeleteDataGridView = LoanDeleting_DataGridView;
        }
         * */
        //-Add

        //######################################################################################################################################################################################//
        //                                                                     Simple Gallery Search
        //######################################################################################################################################################################################//
        public string SimpleGallerySearch(string Subject = null, string Place = null, string LoanStatus = null)
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
            if (Subject == "")
            {
                Subject = null;
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
                    Conditions = "[ آلبوم عکس].[شناسه آلبوم عکس]= N'" + Identification + "'";
                    AndStatuse = true;
                }
                 */
                //--------------------------------------
                if (Subject != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    Message = verify.IsValidCharacter(Subject, 20, false);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }
                    Conditions += "[آلبوم عکس].[موضوع]= N'" + Subject + "'";                               //Add 'N' and '
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
                    Conditions += "[آلبوم عکس].[مکان]= N'" + Place + "'";                               //Add 'N' and 
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
                    Conditions = "[آلبوم عکس].[شناسه آلبوم عکس]= N'" + Identification + "'";
                    AndStatuse = true;
                }
                 */
                //-----------------------------------------------------------------------------------------
                if (Subject != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    Message = verify.IsValidCharacter(Subject, 20, false);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }
                    Conditions += "[آلبوم عکس].[موضوع]= N'" + Subject + "'";
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
                    Conditions += "[آلبوم عکس].[مکان]= N'" + Place + "'";
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
                    Conditions += " [امانت آلبوم عکس].[وضعیت امانت] = N'" + LoanStatus + "'";                                            //Add 'N' and 
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
            OnCondition += " on [آلبوم عکس].[شناسه آلبوم عکس]=" + "[امانت آلبوم عکس].[شناسه آلبوم عکس]";      //Add
            //******************************************************************//
            //                 OutPut of part 1 is    Conditions                //
            //******************************************************************//
            //------------------------------------------------------------------
            // Part 2                  gaining Tables_Name
            //------------------------------------------------------------------
            Table_Name_1 = "[محصولات فرهنگی خانگی].[dbo].[آلبوم عکس]";
            Table_Name_2 = "[محصولات فرهنگی خانگی].[dbo].[امانت آلبوم عکس]";
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

            Columns = "[آلبوم عکس].* , [امانت آلبوم عکس].[وضعیت امانت]";                  // incomplete**

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
        public string GalleryLoanSearch(string Id_Mahsoul , string Id_Karbar , string Vazeat)
        {
            string Message = "1 Search in loan is Done.";
            string LoanTableName=null;
            string WhereCondition=null;
            string SearchQuery = null;
            bool AndStatus = false;

            LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت آلبوم عکس]";
            //WhereCondition = "where ";
            if(Id_Mahsoul != null && Id_Mahsoul != "")
            {
                Message = verify.IsValidNumber(Id_Mahsoul, MaxNumber_Def, MinNumber_Def, true);
                if(Message[0] == '0')
                {
                    Message = "0 Id is not valid.";
                    return Message;
                }

                if (AndStatus)
                {
                    WhereCondition += " and ";
                }
                WhereCondition += "[شناسه آلبوم عکس] = N'" + Id_Mahsoul + "' ";
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
            Message= AnyTypeSearch(SearchQuery);
            return Message;
        }
//--ADDDDD
        //######################################################################################################################################################################################//
        //       END Of                                                        Simple Gallery Search
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
        //       END Of                                                        Loan Gallery Search
        //######################################################################################################################################################################################//


        //######################################################################################################################################################################################//
        //                                                                    Complete Gallery Search
        //######################################################################################################################################################################################//
        public string CompleteGallerySearch(string Subject = null, string Place = null, string LoanStatus = null)
        //LoanStatus Can be one of this three : "امانت داده","امانت گرفته",null
        //string Identification = null,
        {
            return Subject;
        }

        //######################################################################################################################################################################################//
        //          END Of                                                    Complete Gallery Search
        //######################################################################################################################################################################################//


        //######################################################################################################################################################################################//
        //                                                                              Insertion
        //######################################################################################################################################################################################//

        public string InsertGallery(string subject, string afrad, string sal, string mahalegereftaneax, string makan, string tozihat, string idkarbar, string vazeat)
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
            if (subject == "" || subject == null)
            {
                Message = "0 Data is't correct. Data have to gain value.";
                return Message;
            }
            if (afrad == "")
            {
                afrad = null;
            }
            if (sal == "")
            {
                sal = null;
            }
            if (mahalegereftaneax == "")
            {
                mahalegereftaneax = null;
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
            Message = SimpleGallerySearch(null, null, null);                                                      //Simple Search

            if (Message[0] == '1')                                       // it's found
            {

                ShowingDataInInsertionDataGridView();

                Table_Name_1 = "[محصولات فرهنگی خانگی].[dbo].[آلبوم عکس]";                                                                  //&&&&&&&&&&&&&
                Table_Name_2 = "[محصولات فرهنگی خانگی].[dbo].[امانت آلبوم عکس]";                                                            //&&&&&&&&&&&&
                //-----------------------------------------------------------------------------
                //                Process on [جدول نمایش] after SimpleSearchView
                //-----------------------------------------------------------------------------
                /*Message = verify.IsValidNumber(id, MaxNumber_Def, MinNumber_Def, false);
                if(Message[0] == '0')
                {
                    id = "1";
                    Message = "1 Successful";
                }
                 */
                int Number = NumberOfElementsInTable();
                if (Convert.ToInt32(id) <= Number)
                {
                    id = Convert.ToString(Number + 1);
                }

                InsertQuery = "INSERT INTO " + Table_Name_1 + "( [شناسه آلبوم عکس]," + "[موضوع], " + "[افراد] , " + "[سال], " + "[محل عکس گرفتن] , " + "[مکان] , " + "[توضیحات]  " + ")VAlUES( N'" + id;






                //--------------------------------------
                if (subject != null)
                {

                    Message = verify.IsValidCharacter(subject, 20, false);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }

                }
                InsertQuery += "',N'" + subject;

                //----------------------------------------------------  
                if (afrad != null)
                {

                    Message = verify.IsValidCharacter(afrad, 50, true);                         //   ******************   20 ->50                             
                    if (Message[0] == '0')
                    {
                        return Message;
                    }

                }
                InsertQuery += "',N'" + afrad;
                //----------------------------------------------------  
                if (sal != null)
                {
                    /*
                    if(Convert.ToInt32(sal) < MinYear)
                    {
                        sal = Convert.ToString(MinYear);
                    }
                     */
                    Message = verify.IsValidNumber(sal, MaxYear, MinYear, true);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }

                }
                InsertQuery += "',N'" + sal;
                //----------------------------------------------------  
                if (mahalegereftaneax != null)
                {

                    Message = verify.IsValidCharacter(mahalegereftaneax, 20, true);
                    if (Message[0] == '0')
                    {
                        return Message;
                    }


                }
                InsertQuery += "',N'" + mahalegereftaneax;
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

                /*
            if (idkarbar != null)                                                                //   ******************   namealbum -> id  
            {

                Message = verify.IsValidNumber(idkarbar, MaxNumber_Def, MinNumber_Def, false);
                if (Message[0] == '0')
                {
                    return Message;
                }

            }
            if (vazeat != null)                                                                //   ******************   namealbum -> id  
            {

                Message = verify.IsValidLoan(vazeat);
                if (Message[0] == '0')
                {
                    return Message;
                }

            }



                 */



                //******************************************************************//
                // End.               OutPut of part 2 is    in    InsertQuery           //
                //******************************************************************//
                Message = SimpleGallerySearch(subject, null, null);                                                          //&&&&&&&Gallery , subject

                if (Message[0] == '1')                                       // it's found
                {
                    //-----------------------------------------------------------------------------
                    //                      Showing Data in DataGridView
                    
                    Message = ShowingDataInInsertionDataGridView();


                    //-----------------------------------------------------------------------------
                    //END.                 Showing Data in DataGridView
                    //-----------------------------------------------------------------------------

                    int SameTableRow_Number = NumberOfElementsInTable();

                    if (SameTableRow_Number != 0)                                           //if record have been in table before
                    //then ask if user want to replace it or do nothing
                    //  عمل جایگزین کردن : حذف رکورد مد نظر (از طریق شناسه )(که شامل حذف در امانت وهم خود نوع محصول می شود
                    //و دیگر اضافه کردن ازطریق داشتن کل اطلاعات محصول (کل کوئری) مقدور است
                    {
                        /*
                        if (idkarbar != null)
                        {
                            if (vazeat != null)
                            {
                                InsertLoanCondition = " INSERT INTO [امانت آلبوم عکس](" + "[شناسه امانت آلبوم عکس]," + "[شناسه کاربر], " + "[وضعیت امانت] , " + ")VAlUES(N'" + id + ",N'" + idkarbar + "',N'" + vazeat + "')";
                            }
                            else
                            {
                                Message = "0 " + "اطلاعات وضعیت امانت باید داده شود";
                                return Message;
                            }
                        }
                        else
                        {
                             if (vazeat != null)
                             {
                                  Message="0 "+"شناسه ی کاربر باید داده شود";
                                 return Message;
                             }
                                
                            
                        }
                    */

                        string DeleteLoanQuery = "Delete From " + Table_Name_2;
                        string DeleteQuery = "Delete From " + Table_Name_1;
                        InsertPermitionForm InsertPermition = new InsertPermitionForm(Table_Name_2, Table_Name_1, "[شناسه آلبوم عکس]", InsertQuery, DeleteQuery, DeleteLoanQuery, "آلبوم عکس");
                        InsertPermition.SetInsertionDataGridView(InsertionDataGridView);
                        //&&&&&&&&&&&& [شناسه آلبوم عکس] bayad kelid bashad
                        InsertPermition.Show();
                    }
                    else                                                                                       //if there is no same row
                    {

                        ExecuteQuery execute = new ExecuteQuery();
                        Message = execute.InsertQuery(InsertQuery);
                        SimpleGallerySearch(null, null, null);
                        ShowingDataInInsertionDataGridView();
                        // Message = InsertQuery;
                    }
                    //int num=dts.Tables.Count;





                }
                else
                {
                    Message = "0 Error in simple searchin in Gallery to find same in subject";                                                    //&&&&&Subject 
                }

                //***********************************************************************************************//
                // END.       Search in [آلبوم عکس] with SimpleGallerySearch for finding same row               //
                //***********************************************************************************************//

            }
            else
            {
                Message = "0 Error in simple searchin in Gallery";
            }

            return Message;
        }


        //######################################################################################################################################################################################//
        //          END Of                                                              Insertion
        //######################################################################################################################################################################################//

        //######################################################################################################################################################################################//
        //                                                                              Deletting
        //######################################################################################################################################################################################//

        public string DeleteGallery(string[] Id)
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
             
                TableName = "[محصولات فرهنگی خانگی].[dbo].[آلبوم عکس]";                                                                  //&&&&&&&&&&&&&
                LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت آلبوم عکس]";                                                            //&&&&&&&&&&&&

            if (Id.Length == 0)
            {
                Message = "0 Error.Nothing entered as id!";
                return Message;
            }

            //Id_Prev[0]
            WhereCondition = " where " + "( [آلبوم عکس].[شناسه آلبوم عکس] = N'" + Id[0] + "' ";
            LoanWhereCondition = " where " + "( [امانت آلبوم عکس].[شناسه آلبوم عکس] = N'" + Id[0] + "' ";
            for (int i = 1 ; i < Id.Length ; i++ )
            {
                if (Id[i] != null)
                {
                    WhereCondition += "or [آلبوم عکس].[شناسه آلبوم عکس] = N'" + Id[i] + "' ";
                    LoanWhereCondition += "or [امانت آلبوم عکس].[شناسه آلبوم عکس] = N'" + Id[i] + "' ";
                }
            }
            LoanWhereCondition += " )";
            WhereCondition += " )";

            SimpleGallerySearch(null, null, null);
            ShowingDataInDeleteDataGridView();

            DeleteQuery="Delete From" + TableName  + WhereCondition;
            DeleteLoanQuery = "Delete From" + LoanTableName  + LoanWhereCondition;
 


            Query = "select * " + " into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] " + " From " + LoanTableName + LoanWhereCondition;       //same row in loan table
            Message = AnyTypeSearch(Query);                                                                                                 //gaining Same row

            //MessageBox.Show(Message);
           
            if(Message[0]=='1')
            {
                int SameLoanRow = NumberOfElementsInTable();
                if (SameLoanRow > 0)
                {
                    LoanDeletingPermition LDP = new LoanDeletingPermition(DeleteQuery, DeleteLoanQuery, "آلبوم عکس", "امانت آلبوم عکس",TableName,LoanTableName);
                    LDP.SetDeleteDataGridView(DeleteDataGridView);
                    LDP.Show();

                    SimpleGallerySearch(null, null, null);
                    ShowingDataInDeleteDataGridView();

                }
                else
                {
                    ExecuteQuery execute = new ExecuteQuery();
                    execute.DeleteQuery(DeleteQuery);
                    SimpleGallerySearch(null, null, null);
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
        //                                                                              Editting
        //######################################################################################################################################################################################//

        public string EditGallery(string subject_New, string afrad_New, string sal_New, string mahalegereftaneax_New, string makan_New, string tozihat_New, string Id_Prev)
        {

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                                    Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

            string Message = "1 Successful";
            string DeleteQuery = null;
            string WhereCondition = null;
            string SetCondition = null;
            bool AndStatus=false;

            string DeleteLoanQuery = null;
            string LoanWhereCondition = null;

            string TableName = null;
            string LoanTableName = null;
            string UpdateQuery = null;
            DataSet dts = new DataSet();
            verify = new Verifications();

            TableName = "[محصولات فرهنگی خانگی].[dbo].[آلبوم عکس]";                                                                  //&&&&&&&&&&&&&
            //LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت آلبوم عکس]";                                                            //&&&&&&&&&&&&

            if (Id_Prev == "" || Id_Prev == null)
            {
                Message = "0 Error.Nothing entered as id!";
                return Message;
            }

            WhereCondition = " where " + "( [آلبوم عکس].[شناسه آلبوم عکس] = N'" + Id_Prev + "' ";
            //LoanWhereCondition = " where " + "( [امانت آلبوم عکس].[شناسه آلبوم عکس] = N'" + Id_Prev + "' ";
 
            LoanWhereCondition += " )";
            WhereCondition += " )";
            //===================================Achievig Set Condition==============================
            
            // subject_New,  afrad_New,  sal_New,  mahalegereftaneax_New,  makan_New,  tozihat_New
 
            if(subject_New!=null)
            {
                Message = verify.IsValidCharacter(subject_New,20, true);
                if(Message[0]=='0')
                {
                    Message="0 Invalid input";
                    return Message;
                }
                if(AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[موضوع] = N'" + subject_New + "' " ; 
                AndStatus=true;
            }

            if (afrad_New != null)
            {
                Message = verify.IsValidCharacter(afrad_New, 50, false);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                
                if(AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[افراد] = N'" + afrad_New + "' ";
                AndStatus=true;
            }

            if (sal_New != null)
            {
                Message = verify.IsValidNumber(sal_New,MaxYear,MinYear,true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                
                if(AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[سال] = N'" + sal_New + "' ";
                AndStatus=true;
            }

            if (mahalegereftaneax_New != null)
            {
                Message = verify.IsValidCharacter(mahalegereftaneax_New, 20, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                
                if(AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[محل عکس گرفتن] = N'" + mahalegereftaneax_New + "' ";
                AndStatus=true;
            }

            if (makan_New != null)
            {
                Message = verify.IsValidCharacter(makan_New , 50, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                
                if(AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[مکان]	 = N'" + makan_New + "' ";
                AndStatus=true;
            }


            if (tozihat_New != null)
            {
                Message = verify.IsValidCharacter(tozihat_New, 500, true);
                if (Message[0] == '0')
                {
                    Message = "0 Invalid input";
                    return Message;
                }
                
                if(AndStatus)
                {
                    SetCondition += ",";
                }
                SetCondition += "[توضیحات] = N'" + tozihat_New + "' ";
                AndStatus=true;
            }

            
                if(AndStatus)
                {
                    SetCondition = "set " + SetCondition;
                }
            else
                {
                    Message="0 Enter some enteries to update.";
                    return Message;
                }
            //===================End of==========Achievig Set Condition==============================
            //===================================Achievig Update Query===============================
            try
            {
                UpdateQuery = "Update " + TableName + SetCondition + WhereCondition;
                ExecuteQuery execute = new ExecuteQuery();
                Message = execute.EditeQuery(UpdateQuery);
            }
            catch  
            {
                Message = "0 Error in Loan Editting .";
            }
            if(Message[0]=='1')
            {
                SimpleGallerySearch(null, null, null);
                ShowingDataInEditDataGridView();

            }
            
            return Message;

        }

        public string EditLoanGallery(string Id_Prev, string Idkarbar_Prev , string Vazeat_Prev, string Id_New ,string Idkarbar_New, string Vazeat_New)
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

            //TableName = "[محصولات فرهنگی خانگی].[dbo].[آلبوم عکس]";                                                                  //&&&&&&&&&&&&&
            LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت آلبوم عکس]";                                                            //&&&&&&&&&&&&

            if (Id_Prev == "" || Id_Prev == null)
            {
                Message = "0 Error.Nothing entered as id!";
                return Message;
            }

            if (Idkarbar_Prev== "" || Idkarbar_Prev == null)
            {
                Message = "0 Error.Nothing entered as id!";
                return Message;
            }

            if (Vazeat_Prev == "" || Vazeat_Prev == null)
            {
                Message = "0 Error.Nothing entered as id!";
                return Message;
            }
            LoanWhereCondition = " where " + " [امانت آلبوم عکس].[شناسه آلبوم عکس] = N'" + Id_Prev + "' " + "and [امانت آلبوم عکس].[شناسه افراد] = N'" + Idkarbar_Prev + "' " + "and [امانت آلبوم عکس].[وضعیت امانت] = N'" + Vazeat_Prev + "'";

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
                if(AndStatus)
                {
                    SetCondition += ", ";
                }
                SetCondition += "[شناسه آلبوم عکس] = N'" + Id_New + "' ";
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
                GalleryLoanSearch(null, null, null);
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

                    Message = "0 There is nothing found in Viewing Table";
                }
                else
                {
                    Message = "1 " + "مقدار یافت شد " + Convert.ToString(ViewTableRow_Number) + "جستجو با موفقیت انجام شد و ";
                }
                //int num=dts.Tables.Count;
                DeleteDataGridView.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

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

                    Message = "0 There is nothing found in Viewing Table";
                }
                else
                {
                    Message = "1 " + "مقدار یافت شد " + Convert.ToString(ViewTableRow_Number) + "جستجو با موفقیت انجام شد و ";
                }
                //int num=dts.Tables.Count;
                EditDataGridView.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

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

                    Message = "0 There is nothing found in Viewing Table";
                }
                else
                {
                    Message = "1 " + "مقدار یافت شد " + Convert.ToString(ViewTableRow_Number) + "جستجو با موفقیت انجام شد و ";
                }
                //int num=dts.Tables.Count;
                CompleteSearchDataGridView.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

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
/*
        public string ShowingDataInLoanDeleteDataGridView()
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
                LoanDeleteDataGridView.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

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
 * */


        //######################################################################################################################################################################################//
        // End of                                                                   Inside Functions
        //######################################################################################################################################################################################//


    }


}










        


