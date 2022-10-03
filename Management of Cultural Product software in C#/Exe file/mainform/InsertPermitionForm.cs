using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Add
// -------DataBase---------
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
//---backup----
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;

namespace mainform
{
    public partial class InsertPermitionForm : Form
    {
        public string id;
        string InsertQuery;
        string DeleteQuery;
        string DeleteLoanQuery;
        string Id_Column;
        string LoanTable_Name;
        string Table_Name;
        ExecuteQuery execute;
        //Add
        DataGridView SimpleSearchDataGridView;
        DataGridView InsertionDataGridView;
        String strCon;
        SqlDataAdapter sqlDA;
        SqlConnection connection;
        DataSet dts;
        string MahsoulatType;
        // string LoanMahsoulatType;
        //-Add
        public InsertPermitionForm(string LoanTableName, string TableName, string IdColumn_str, string Insert_query, string Delete_query, string DeleteLoan_query, string Mahsoulat_Type)
        {
            InitializeComponent();

            //Add
            strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
            SimpleSearchDataGridView = null;
            InsertionDataGridView = null;
            dts = null;
            connection = null;
            sqlDA = null;
            MahsoulatType = Mahsoulat_Type;
            //LoanMahsoulatType = LoanMahsoulat_Type;
            //-Add

            id = null;
            execute = new ExecuteQuery();
            LoanTable_Name = LoanTableName;
            Table_Name = TableName;
            InsertQuery = Insert_query;
            DeleteQuery = Delete_query;
            DeleteLoanQuery = DeleteLoan_query;
            Id_Column = IdColumn_str;
        }

        public void SetInsertionDataGridView(DataGridView Insertion_DataGridView)
        {

            InsertionDataGridView = Insertion_DataGridView;
        }
        //-Add

        public void SetInsertQuery(string Insert_query_str)
        {
            InsertQuery = Insert_query_str;
        }
        public void SetDeleteQuery(string Delete_query_str)
        {
            DeleteQuery = Delete_query_str;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            InsertPermitionForm.ActiveForm.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //عمل جایگزین کردن : حذف رکورد مد نظر (از طریق شناسه )(که شامل حذف در امانت وهم خود نوع محصول می شود
            //و دیگر اضافه کردن ازطریق داشتن کل اطلاعات محصول (کل کوئری) مقدور است
            id = textBox1.Text;
            if (id != null)
            {
                string Message = "0 Deleting failed";

                Message = execute.DeleteQuery("Delete From " + LoanTable_Name + " where " + Id_Column + '=' + id);
                Message = execute.DeleteQuery("Delete From " + Table_Name + " where " + Id_Column + '=' + id);
                if (Message[0] == '1')
                {

                    mainSystemForm ShowingData = new mainSystemForm();
                    ShowingData.ShowingDataInInsertionDataGridView();
                    Status.Text = "Successfully deleted";
                    InsertPermitionForm.ActiveForm.Close();
                }


            }
        }

        private void insert_Click(object sender, EventArgs e)
        {

            string Message = "1 valid";
            Message = execute.InsertQuery(InsertQuery);
            if (Message[0] == '1')
            {

                mainSystemForm ShowingData = new mainSystemForm();
                ShowingData.ShowingDataInInsertionDataGridView();
                
                Status.Text = "Successfully inserted";
                InsertPermitionForm.ActiveForm.Close();
            }
            else
            {
                Status.Text = "inserted failed.";
            }

        }
    }
}
