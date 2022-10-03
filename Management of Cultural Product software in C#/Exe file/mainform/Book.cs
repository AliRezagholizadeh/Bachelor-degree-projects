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
    class Book
    {



        string[] LoanStatus;
        Verifications verify;
        int MaxNumber_Def;
        int MinNumber_Def;
        int MaxYear;
        int MinYear;
        int Maxmoney;
        int Minmoney;
        int Maxnumber;
        int Minnumber;
        int Maxteadad;
        int Minteadad;
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

        public Book()
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
            Maxmoney = 999999;
            Minmoney = 1;
            Maxnumber = 999;
            Minnumber = 1;
            Maxteadad = 999;
            Minteadad = 1;
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

        //######################################################################################################################################################################################//
        //                                                                              Simple Search
        //######################################################################################################################################################################################//


        public string SimpleBookSearch(string Title = null, string Place = null, string LoanStatus = null)
       //string Identification=null , 
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

           SqlDataAdapter sqlDA;
           SqlConnection connection;
           String strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
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
           if (Title == "")
           {
               Title = null;
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
               /*if(Identification != null)
                 {
                     if (AndStatuse)
                     {
                         Conditions += " and ";
                     }
                     Message=verify.IsValidNumber(Identification,MaxNumber_Def,MinNumber_Def,false);                                         //Add
                     if(Message[0] == '0')
                     {
                         return Message;
                     } //Add
                     Conditions = "[کتاب].[شناسه کتاب]= N'" + Identification + "'";
                     AndStatuse = true;
                 }*/
               //--------------------------------------
               if (Title != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidCharacter(Title, 20, false);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }
                   Conditions += "[کتاب].[عنوان]= N'" + Title + "'";
                   AndStatuse = true;
               }
               //--------------------------------------
               if (Place != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidCharacter(Title, 50, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }
                   Conditions += "[کتاب].[مکان]= N'" + Place + "'";
                   AndStatuse = true;
               }

               //--------------------------------------

           }     // End of if(LoanStatus == null ) 
           //------------------------------------------------------------------------------------------
           else   // if Loanstatus != null
           {
               

               /* if(Identification != null)
                {
                    if (AndStatuse)
                    {
                        Conditions += " and ";
                    }
                    Message = verify.IsValidNumber(Identification, MaxNumber_Def, MinNumber_Def, false);                                         //Add
                    if (Message[0] == '0')
                    {
                        return Message;
                    } //Add
                    Conditions = "[نوار ویدئویی].[شناسه نوار ویدئویی]= N'" + Identification + "'";
                    AndStatuse = true;
                }*/
               //-------------------------------------------------------
               if (Title != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidCharacter(Title, 20, false);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }
                   Conditions += "[کتاب].[عنوان]= N'" + Title + "'";
                   AndStatuse = true;
               }
               //-------------------------------------------------------
               if (Place != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidCharacter(Title, 50, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }
                   Conditions += "[کتاب].[مکان]= N'" + Place + "'";
                   AndStatuse = true;
               }
               //-------------------------------------------------------
               //           adding LoanStatus in condition
               //-------------------------------------------------------

               //Conditions += "[کتاب].[شناسه کتاب]= " + "[امانت کتاب].[شناسه کتاب]";

               if (LoanStatus == this.LoanStatus[0] || LoanStatus == this.LoanStatus[1])
               {
                   if (AndStatuse)
                   {
                       Conditions += "and";
                   }

                   Conditions += " [امانت کتاب].[وضعیت امانت] = N'" + LoanStatus + "'";
                   AndStatuse = true;
               }
               else                                                                                                         //Add
               {
                   Message = "0 LoanStatus is invalide";
                   return Message;
               }


           }


           if (AndStatuse)
           {
               WhereCondition = " Where " + Conditions;
           }
           OnCondition = " on [کتاب].[شناسه کتاب]= " + "[امانت کتاب].[شناسه کتاب]";//Add 
           //**************************************************************************************//
           //                 OutPut of part 1 is    OnConditions and WhereCondition               //
           //**************************************************************************************//
           //------------------------------------------------------------------
           // Part 2                  gaining Tables_Name
           //------------------------------------------------------------------
           Table_Name_1 = "[محصولات فرهنگی خانگی].[dbo].[کتاب]";
           Table_Name_2 = "[محصولات فرهنگی خانگی].[dbo].[امانت کتاب]";

           Tables_Name = Table_Name_1;

           if (Table_Name_2 != null)
           {
               Tables_Name += ',';
               Tables_Name += Table_Name_2;
           }
           //******************************************************************//
           //                 OutPut of part 2 is    Tables_Name               //
           //******************************************************************//
           //------------------------------------------------------------------
           // Part 3                  gaining Columns
           //------------------------------------------------------------------

           Columns = "[کتاب].* , [امانت کتاب].[وضعیت امانت]";
           //"[کتاب].[شناسه کتاب],[کتاب].[عنوان],[کتاب].[موضوع],[کتاب].[نویسندگان] , [کتاب].[مترجمان] , [کتاب].[ناشر] , [کتاب].[تعداد نسخه] , [کتاب].[سال انتشار] , [کتاب].[شماره ی چاپ], [کتاب].[تاریخ خرید] , [کتاب].[قیمت]  , [کتاب].[میزان علاقه مندی] , [کتاب].[مکان] , [امانت کتاب].[وضعیت امانت] , [کتاب].[توضیحات]";                


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
               Message = "0 problem with connecting to database"; 
               MessageBox.Show("There is problem with connecting to database to selecting into ViwTable"); 
           }
           
            //-----------------------------------------------------------------------------
            //END of           Execute select Query and showing it in [جدول نمایش]
            //-----------------------------------------------------------------------------

           return Message;
        }
        public string BookLoanSearch(string Id_Mahsoul, string Id_Karbar, string Vazeat)
        {
            string Message = "1 Search in loan is Done.";
            string LoanTableName = null;
            string WhereCondition = null;
            string SearchQuery = null;
            bool AndStatus = false;

            LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت کتاب]";
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
                WhereCondition += "[شناسه کتاب] = N'" + Id_Mahsoul + "' ";
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



       

       //######################################################################################################################################################################################//
       //          END Of                                                               Simple Search
       //######################################################################################################################################################################################//



         //######################################################################################################################################################################################//
        //                                                                              Complete Search
        //######################################################################################################################################################################################//

       public string CompleteBookSearch(string Title=null , string Authors=null , string Translators=null , string Publisher=null , string PublicationYear=null , string Price=null  , string FavoriteDegree=null)
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
           string WhereCondition=null;
           string OnCondition=null;
           string Query = null;
           SqlDataAdapter sqlDA;
           SqlConnection connection;
           String strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
           DataSet dts = new DataSet();

           bool AndStatuse = false;    // for controlling And in condition

           if (Title == "")
           {
               Title = null;
           }
           if (Authors == "")
           {
               Authors = null;
           }
           if (Translators == "")
           {
               Translators = null;
           }
           if (Publisher == "")
           {
               Publisher = null;
           }
           if (PublicationYear == "")
           {
               PublicationYear = null;
           }
           if (Price == "")
           {
               Price = null;
           }
           if (FavoriteDegree == "")
           {
               FavoriteDegree = null;
           }
           //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
           //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
           //                                                                                    Analysis of Input
           //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
           //------------------------------------------------------------------
           // Part 1                  gaining Condition
           //------------------------------------------------------------------
           Table_Name_1 = "[محصولات فرهنگی خانگی].[dbo].[کتاب]";
           //----------------------------------------------------------//
           
              
               //--------------------------------------
               if (Title != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidCharacter(Title, 20, false);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }
                   Conditions += "[کتاب].[عنوان]= N'" + Title + "'";                                 
                   AndStatuse = true;
               }

               //----------------------------------------------------  
               if (Authors != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidCharacter(Authors, 50, true);                                           //Add
                   if (Message[0] == '0')
                   {
                       return Message;
                   }                    //Add
                   Conditions = "[کتاب].[نویسندگان]= N'" + Authors + "'";
                   AndStatuse = true;
               }
               //----------------------------------------------------  
               if (Translators != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidCharacter(Translators, 50, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }
                   Conditions = "[کتاب].[مترجمان]= N'" + Translators + "'";
                   AndStatuse = true;
               }

               //----------------------------------------------------  
               if (Publisher != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidCharacter(Publisher, 20, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }
                   Conditions = "[کتاب].[ناشر]= N'" + Publisher + "'";
                   AndStatuse = true;
               }
               //----------------------------------------------------  
               if (PublicationYear != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidNumber(PublicationYear,MaxYear,MinYear, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }
                   Conditions = "[کتاب].[سال انتشار]= N'" + PublicationYear + "'";
                   AndStatuse = true;
               }
               //----------------------------------------------------  
               if (Price != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidNumber(Price, MaxNumber_Def, MinNumber_Def, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }
                   Conditions = "[کتاب].[قیمت]= N'" + Price + "'";
                   AndStatuse = true;
               }
               //--------------------------------------
               if (FavoriteDegree != null)
               {
                   if (AndStatuse)
                   {
                       Conditions += " and ";
                   }
                   Message = verify.IsValidFavoriteDegree(FavoriteDegree);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }
                   Conditions += "[کتاب].[میزان علاقه مندی]= N'" + FavoriteDegree + "'";                                              
                   AndStatuse = true;
               }
               //-------------------------------------------------------
               //           adding LoanStatus in condition
               //-------------------------------------------------------
                if(AndStatuse)
                {
                    WhereCondition=" Where "+ Conditions;
                }

               Table_Name_2 = "[محصولات فرهنگی خانگی].[dbo].[امانت کتاب]";
               OnCondition = " on [کتاب].[شناسه کتاب]= " + "[امانت کتاب].[شناسه کتاب]";                                                      //Add
               
               
                
               //--------------------------------------

            
           
           //******************************************************************/
           //                 OutPut of part 1 is    Conditions                /
           //******************************************************************/
           
           //------------------------------------------------------------------
           // Part 2                 gaining Columns
           //------------------------------------------------------------------
           
               Columns = "[کتاب].* , [امانت کتاب].[وضعیت امانت]";
               //"[کتاب].[شناسه کتاب],[کتاب].[عنوان],[کتاب].[موضوع],[کتاب].[نویسندگان] , [کتاب].[مترجمان] , [کتاب].[ناشر] , [کتاب].[تعداد نسخه] , [کتاب].[سال انتشار] , [کتاب].[شماره ی چاپ], [کتاب].[تاریخ خرید] , [کتاب].[قیمت]  , [کتاب].[میزان علاقه مندی] , [کتاب].[مکان] , [امانت کتاب].[وضعیت امانت] , [کتاب].[توضیحات]";                
          
           //******************************************************************//
           // End.               OutPut of part 2 is    Columns                //
           //******************************************************************//

           Query = "SELECT " + Columns + " into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] " + "FROM" + Table_Name_1 + "Full join" + Table_Name_2 + OnCondition + WhereCondition;

           connection = new SqlConnection(strCon);
           connection.Open();
           sqlDA = new SqlDataAdapter(Query, connection);
           sqlDA.Fill(dts);


           return Message;
       }

        //######################################################################################################################################################################################//
        //          END Of                                                               Complete Search
        //######################################################################################################################################################################################//
       //######################################################################################################################################################################################//
       //                                                                              Insertion
       //######################################################################################################################################################################################//

       public string InsertBook(string onvan, string mozo, string namenevisandegan, string motarjem, string nasher, string teadad, string sal, string shomarechap, string date, string ghaemat, string favoritedegree, string makan, string tozihat, string idkarbar, string vazeat)
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

           if (onvan == "")
           {
               Message = "0 Data is't correct. Data have to gain value.";
               return Message;
           }
           if (mozo == "")
           {
               mozo = null;
           }
           if (namenevisandegan == "")
           {
               namenevisandegan = null;
           }
           if (motarjem == "")
           {
               motarjem = null;
           }
           if (nasher == "")
           {
               nasher = null;
           }
           if (teadad == "")
           {
               teadad = null;
           }

           if (sal == "")
           {
               sal = null;
           }

           if (shomarechap == "")
           {
               shomarechap = null;
           }
           if (date == "")
           {
               date = null;
           }
           if (ghaemat == "")
           {
               ghaemat = null;
           }
           if (favoritedegree == "")
           {
               favoritedegree = null;
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
           Message = SimpleBookSearch(null, null, null);                                                      //Simple Search for Showing Entire ralated Table

           if (Message[0] == '1')                                       // it's found
           {

               ShowingDataInInsertionDataGridView();                                                                   // Showing That table 

               Table_Name_1 = "[محصولات فرهنگی خانگی].[dbo].[کتاب]";                                                                  //&&&&&&&&&&&&&
               Table_Name_2 = "[محصولات فرهنگی خانگی].[dbo].[امانت کتاب]";                                                            //&&&&&&&&&&&&
               //-----------------------------------------------------------------------------
               //                Process on [جدول نمایش] after SimpleSearchView
               //-----------------------------------------------------------------------------

               int Number = NumberOfElementsInTable();                                                     //compute id from table rows number!
               if (Convert.ToInt32(id) <= Number)
               {
                   id = Convert.ToString(Number + 1);
               }

               InsertQuery = "INSERT INTO " + Table_Name_1 + "( [شناسه کتاب]," + "[عنوان کتاب], " + "[موضوع], " + "[نویسندگان], " + "[مترجمان],  " + "[ناشر], " + "[تعداد نسخه]," + "[سال انتشار]," + "[شماره ی چاپ] , " + "[تاریخ خرید]," + "[قیمت]," + "[میزان علاقه مندی]," + "[مکان] , " + "[توضیحات]  " + " )VAlUES( N'" + id;

               if (onvan != null)
               {

                   Message = verify.IsValidCharacter(onvan, 20, false);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + onvan;
               //------------------------------
               if (mozo != null)
               {

                   Message = verify.IsValidCharacter(mozo, 20, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + mozo;

               //----------------------------------------------------------------
               if (namenevisandegan != null)
               {

                   Message = verify.IsValidCharacter(namenevisandegan, 50, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + namenevisandegan;
               //-------------------------------------------------------------
               //----------------------------------------------------------------
               if (motarjem != null)
               {

                   Message = verify.IsValidCharacter(motarjem, 50, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + motarjem;
               //-------------------------------------------------
               if (nasher != null)
               {

                   Message = verify.IsValidCharacter(nasher, 20, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + nasher;
               //-----------------------------------------------------------------
               if (teadad != null)
               {

                   Message = verify.IsValidNumber(teadad, Maxteadad, Minteadad, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + teadad;
               //--------------------------------------------------------
               if (sal != null)
               {

                   Message = verify.IsValidNumber(sal, MaxYear, MinYear, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + sal;
               //------------------------------------


               if (shomarechap != null)
               {

                   Message = verify.IsValidNumber(shomarechap, Maxnumber, Minnumber, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + shomarechap;
               //---------------------------------------
               if (date != null)
               {

                   Message = verify.IsValidDate(date);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + date;
               //----------------------------------
               if (ghaemat != null)
               {

                   Message = verify.IsValidNumber(ghaemat, Maxmoney, Minmoney, true);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + ghaemat;
               //--------------------------------


               //------------------------------------
               if (favoritedegree != null)
               {

                   Message = verify.IsValidFavoriteDegree(favoritedegree);
                   if (Message[0] == '0')
                   {
                       return Message;
                   }


               }
               InsertQuery += "',N'" + favoritedegree;
               //-----------------------------------------------
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
               Message = SimpleBookSearch(onvan, null, null);                                                          //&&&&&&&Book , Title

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

                       InsertPermitionForm InsertPermition = new InsertPermitionForm(Table_Name_2, Table_Name_1, "[شناسه کتاب]", InsertQuery, DeleteQuery, DeleteLoanQuery, "کتاب");
                       InsertPermition.SetInsertionDataGridView(InsertionDataGridView);
                       //&&&&&&&&&&&& [شناسه کتاب] bayad kelid bashad
                       InsertPermition.Show();
                   }
                   else                                                                                       //if there is no same row
                   {

                       ExecuteQuery execute = new ExecuteQuery();                  //Adding Process 
                       Message = execute.InsertQuery(InsertQuery);

                       SimpleBookSearch(null, null, null);                     //Shoing Table after Addition action
                       ShowingDataInInsertionDataGridView();
                       // Message = InsertQuery;
                   }
                   //int num=dts.Tables.Count;





               }
               else
               {
                   Message = "0 Error in simple searchin in Book to find same in Title";                                                    //&&&&&Title 
               }

               //***********************************************************************************************//
               // END.       Search in [کتاب] with SimpleBookSearch for finding same row               //
               //***********************************************************************************************//

           }
           else
           {
               Message = "0 Error in simple searchin in Book";
           }

           return Message;
       }
       public string EditBook(string mohtava_New, string nevisandegan_New, string motargem_New, string nasher_New, string salenteshar_New, string ghaemat_New, string Id_Prev)
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
           //MessageBox.Show("jk");
           TableName = "[محصولات فرهنگی خانگی].[dbo].[کتاب]";                                                                  //&&&&&&&&&&&&&
           //LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت کتاب]";                                                            //&&&&&&&&&&&&

           if (Id_Prev == "" || Id_Prev == null)
           {
               Message = "0 Error.Nothing entered as id!";
               return Message;
           }

           WhereCondition = " where " + "( [کتاب].[شناسه کتاب] = N'" + Id_Prev + "' ";
           //LoanWhereCondition = " where " + "( [امانت کتاب].[شناسه کتاب] = N'" + Id_Prev + "' ";

           //LoanWhereCondition += " )";
           WhereCondition += " )";
           //===================================Achievig Set Condition==============================

           // subject_New,  afrad_New,  sal_New,  mahalegereftaneax_New,  makan_New,  tozihat_New

           //-------------------
           if (mohtava_New != null)
           {
               Message = verify.IsValidCharacter(mohtava_New, 20, false);
               if (Message[0] == '0')
               {
                   Message = "0 Invalid input";
                   return Message;
               }

               if (AndStatus)
               {
                   SetCondition += ",";
               }
               SetCondition += "[عنوان] = N'" + mohtava_New + "' ";
               AndStatus = true;
           }
           //---------------------------------------------------
           if (nevisandegan_New != null)
           {
               Message = verify.IsValidCharacter(nevisandegan_New, 50, true);
               if (Message[0] == '0')
               {
                   Message = "0 Invalid input";
                   return Message;
               }

               if (AndStatus)
               {
                   SetCondition += ",";
               }
               SetCondition += "[نویسندگان] = N'" + nevisandegan_New + "' ";
               AndStatus = true;
           }
           //-------------------------------------
           if (motargem_New != null)
           {
               Message = verify.IsValidCharacter(motargem_New, 50, true);
               if (Message[0] == '0')
               {
                   Message = "0 Invalid input";
                   return Message;
               }

               if (AndStatus)
               {
                   SetCondition += ",";
               }
               SetCondition += "[مترجم] = N'" + motargem_New + "' ";
               AndStatus = true;
           }

           if (nasher_New != null)
           {
               Message = verify.IsValidCharacter(nasher_New, 20, true);
               if (Message[0] == '0')
               {
                   Message = "0 Invalid input";
                   return Message;
               }

               if (AndStatus)
               {
                   SetCondition += ",";
               }
               SetCondition += "[ناشر] = N'" + nasher_New + "' ";
               AndStatus = true;
           }


           //------------------------------------
           if (salenteshar_New != null)
           {
               Message = verify.IsValidNumber(salenteshar_New, MaxYear, MinYear, true);
               if (Message[0] == '0')
               {
                   Message = "0 Invalid input";
                   return Message;
               }

               if (AndStatus)
               {
                   SetCondition += ",";
               }
               SetCondition += "[سال انتشار] = N'" + salenteshar_New + "' ";
               AndStatus = true;
           }
           //---------------------------------------------------
           //-------------------------------------

           if (ghaemat_New != null)
           {
               Message = verify.IsValidNumber(ghaemat_New, Maxmoney, Minmoney, true);
               if (Message[0] == '0')
               {
                   Message = "0 Invalid input";
                   return Message;
               }

               if (AndStatus)
               {
                   SetCondition += ",";
               }
               SetCondition += "[قیمت] = N'" + ghaemat_New + "' ";
               AndStatus = true;
           }
           //--------------------------------------------------
           //-------------------------------------



           if (AndStatus)
           {
               SetCondition = " set " + SetCondition;
           }
           else
           {
               Message = "0 Enter some enteries to update.";
               return Message;
           }
           //===================End of==========Achievig Set Condition==============================
           //===================================Achievig Update Query===============================
           UpdateQuery = "Update " + TableName + SetCondition + WhereCondition;
           //MessageBox.Show(UpdateQuery);
           try
           {

               ExecuteQuery execute = new ExecuteQuery();
               Message = execute.EditeQuery(UpdateQuery);
           }
           catch
           {
               Message = "0 Error in Loan Editting .";
           }
           if (Message[0] == '1')
           {
               SimpleBookSearch(null, null, null);
               ShowingDataInEditDataGridView();
              // MessageBox.Show("jk");
           }

           return Message;

       }

       public string EditLoanBook(string Id_Prev, string Idkarbar_Prev, string Vazeat_Prev, string Id_New, string Idkarbar_New, string Vazeat_New)
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

           //TableName = "[محصولات فرهنگی خانگی].[dbo].[کتاب]";                                                                  //&&&&&&&&&&&&&
           LoanTableName = "[محصولات فرهنگی خانگی].[dbo].[امانت کتاب]";                                                            //&&&&&&&&&&&&

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
           LoanWhereCondition = " where " + " [امانت کتاب].[شناسه کتاب] = N'" + Id_Prev + "' " + "and [امانت کتاب].[شناسه افراد] = N'" + Idkarbar_Prev + "' " + "and [امانت کتاب].[وضعیت امانت] = N'" + Vazeat_Prev + "'";

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
               SetCondition += "[شناسه کتاب] = N'" + Id_New + "' ";
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
               BookLoanSearch(null, null, null);
               ShowingDataInEditDataGridView();

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


        //Add
       //*********************************************************************************************************************************************************************************************//
       //  End of                                                                               Showing Table
       //*********************************************************************************************************************************************************************************************//
       /*
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
                               SimpleSearchDataGridView.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

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
        * */
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
