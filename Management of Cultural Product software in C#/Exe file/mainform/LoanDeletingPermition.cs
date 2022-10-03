using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// -------DataBase---------
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using Mahsoulat_Farhangi;
using mainform;

namespace mainform
{

    public partial class LoanDeletingPermition : Form
    {
        DataGridView DeleteDataGridView;
        string DeleteLoanQuery;
        string DeleteQuery;
        string MahsoulatType;
        string LoanMahsoulatType;
        string TableName;
        string LoanTableName;
        Verifications verify;
        //Add
        String strCon;
        SqlDataAdapter sqlDA;
        SqlConnection connection;
        DataSet dts;
        bool Cancel;
        public LoanDeletingPermition(string Delete_Query,string Loan_DeleteQuery,string Mahsoulat_Type,string LoanMahsoulat_Type,string Table_Name, string Loan_TableName)
        {
            strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
            TableName = Table_Name;
            LoanTableName = Loan_TableName;
            dts = null;
            connection = null;
            sqlDA = null;
            verify = new Verifications();
           
            Cancel = false;
            DeleteLoanQuery = Loan_DeleteQuery;
            DeleteQuery = Delete_Query;
            MahsoulatType = Mahsoulat_Type;
            LoanMahsoulatType = LoanMahsoulat_Type;
            InitializeComponent();
        }


        public void SetDeleteDataGridView(DataGridView Delete_DataGridView)
        {

            DeleteDataGridView = Delete_DataGridView;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Cancel = true;
            LoanDeletingPermition.ActiveForm.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            string Message = "1 Successfully Deleted.";
            ExecuteQuery execute = new ExecuteQuery();
            Message= execute.DeleteQuery(DeleteLoanQuery);

            //Sowing Entire Loan Table
            string Query = "select * " + " into [محصولات فرهنگی خانگی].[dbo].[جدول نمایش] " + " From " + LoanTableName;
            AnyTypeSearch(Query);
            ShowingDataInLoanDeleteDataGrid();
            //-Sowing Entire Loan Table

            if(Message[0]=='1')
            {
                MessageBox.Show(" سطر های مزبور از جدول امانت محصول مربوطه حذف شدند");
                DeletionStatus.Text = " سطر های مزبور از جدول امانت محصول مربوطه حذف شدند";
            }

            //Sowing Entire Table
            Message = execute.DeleteQuery(DeleteQuery);
            SimpleSearch(MahsoulatType);
            ShowingDataInDeleteDataGridView();
            //-Sowing Entire Table           
                            
            if (Message[0] == '1')
            {
                MessageBox.Show(" سطر های مزبور از جدول محصول مربوطه نیز حذف شدند");
                DeletionStatus.Text = " سطر های مزبور از جدول محصول مربوطه نیز حذف شدند";
            }
            LoanDeletingPermition.ActiveForm.Close();

           
        }
        public bool GetCancelStatus()
        {
            return Cancel;
        }

        private void LoanDeletingPermition_Load(object sender, EventArgs e)
        {
            ShowingDataInLoanDeleteDataGrid();

        }
        public string ShowingDataInLoanDeleteDataGrid()
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
                LoanDeleteDataGrid.DataBindings.Clear();
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
                
                LoanDeleteDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));

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

        public string SimpleSearch(string MahsoulatType)
        {
            string Message = "1 Successfully Shows in Viewing Table.";
              switch(MahsoulatType)                                                           //Showing Entire Table Process
            {
                case "کتاب":

                    /*   Book Book_Obj = new Book();
                       Message = Book_Obj.SimpleBookSearch(null,null,null);*/
                   break;

                case "روزنامه":

                    break;

                case "مجله":

                    break;

                case "مقاله":

                    break;

                case "لوح فشرده و نرم افزار":

                    break;

                case "آلبوم عکس":
                        Gallery Gallery_Obj = new Gallery();
                        Message = Gallery_Obj.SimpleGallerySearch(null,null,null);
                       // MessageBox.Show(Message);
                    break;

                case "کاست":
                    /*  Cossette Cossette_Obj = new Cossette();
                      Message = Cossette_Obj.SimpleCossetteSearch(null,null,null);
                      */
                    break;

                case "نوار ویدئویی":
                    /* Video Video_Obj = new Video();
                     Message = Video_Obj.SimplevideoSearch(null,null,null);
                   */
                   break;

                case "مدارک":
                   Document Document_Obj = new Document();
                    Message = Document_Obj.SimpleDocumentSearch(null,null,null);
                   
                    break;
                case "":
                    Message = "نوع محصول را انتخاب کنین";
                    break;
                case null:
                    Message = "نوع محصول را انتخاب کنین";
                    break;
            }
            return Message;
        }
 

        public string ShowingDataInDeleteDataGridView()
        {

            //-----------------------------------------------------------------------------
            //                               Deffinition
            //-----------------------------------------------------------------------------
            string Message = "1 Successfully shown in Data Gride.";
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

        //######################################################################################################################################################################################//
        //                                                                     Loan Gallery Search
        //######################################################################################################################################################################################//
        public string AnyTypeSearch(string Query)
        //LoanStatus Can be one of this three : "امانت داده","امانت گرفته",null
        //string Identification = null,
        {
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            //                                                                                    Deffinition
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
            string Message = "1 Successful";
            string DropQuery = null;



            // strCon = "Data Source=localhost;Initial Catalog=&quot;محصولات فرهنگی خانگی&quot;;Integrated Security=True";
            //strCon="Data Source=localhost;AttachDbFilename=|DataDirectory|\[محصولات فرهنگی خانگی].mdf;Integrated Security=True";
            DataSet dts = new DataSet();
            SqlCommand cmd;

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
                MessageBox.Show(Query);
                connection = new SqlConnection(strCon);
                connection.Open();
                cmd = new SqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch
            {
                Message = "0 Error in Searching into Loan Table. 00";
                MessageBox.Show("** " + Query);
            }

            //-----------------------------------------------------------------------------
            //END of           Execute select Query and showing it in [جدول نمایش]
            //-----------------------------------------------------------------------------
            return Message;
        }

        private void LoanDeletingPermition_Load_1(object sender, EventArgs e)
        {

        }

    }
}
