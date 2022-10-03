using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//Add
// -------DataBase---------
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
//---backup----
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;

//-------------------
using Mahsoulat_Farhangi;

namespace mainform
{

    public partial class mainSystemForm : Form
    {
        String restoreFilePath = "";
        String backupFilePath = "";
        public Dictionary<String, String> simpleSearchRequest = new Dictionary<String, String>();
        public Dictionary<String, String> AdvancedSearchRequest = new Dictionary<String, String>();
        public Dictionary<String, String> AddRequest = new Dictionary<String, String>();
        public Dictionary<String, String> EditRequest = new Dictionary<String, String>();
        public Dictionary<String, String> DeleteRequest = new Dictionary<String, String>();


        //public List<String> advancedSearchResult = new List<string>();
        Dictionary<String, Panel> alleditLayerPanels = new Dictionary<string, Panel>();
        Dictionary<String, Panel> allDeleteLayerPanels = new Dictionary<string, Panel>();
        Dictionary<String, Panel> allAddLayerPanels = new Dictionary<string, Panel>();
        Dictionary<String, Panel> allAdvSearchLayerPanels = new Dictionary<string, Panel>();
        Panel selectedAdvSearchLayerPanel;
        Panel selectedEditLayerPanel;
        Panel selectedAddLayerPanel;
        Panel selectedDeleteLayerPanel;
//ADD
        SqlDataAdapter sqlDA;
        SqlConnection connection;
        String strCon;
        DataSet dts;
        DataTable dt;
//-ADD

        public mainSystemForm()
        {
            InitializeComponent();
            strCon = "Data Source=localhost;Initial Catalog=محصولات فرهنگی خانگی ;Integrated Security=True";
            
        }

        private void mainSystemForm_Load(object sender, EventArgs e)
        {
            alleditLayerPanels.Add("کتاب", layerEditBookPanel);
            alleditLayerPanels.Add("روزنامه", layerEditNewspaperPanel);
            alleditLayerPanels.Add("مجله", layerEditMagazinePanel);
            alleditLayerPanels.Add("مقاله", layerEditPaperPanel);
            alleditLayerPanels.Add("لوح فشرده و نرم افزار", layerEditCDPanel);
            alleditLayerPanels.Add("آلبوم عکس", layerEditAlbumPanel);
            alleditLayerPanels.Add("نوار ویدئویی", layerEditVideoTapePanel);
            alleditLayerPanels.Add("مدارک", layerEditDocPanel);
            alleditLayerPanels.Add("کاست", layerEditCassettePanel);

            allDeleteLayerPanels.Add("نوار ویدئویی", layerDeleteVideoTapePanel);
            allDeleteLayerPanels.Add("آلبوم عکس", layerDeleteAlbumPanel);
            allDeleteLayerPanels.Add("کتاب", layerDeleteBookPanel);
            allDeleteLayerPanels.Add("روزنامه", layerDeleteNewspaperPanel);
            allDeleteLayerPanels.Add("مجله", layerDeleteMagazinePanel);
            allDeleteLayerPanels.Add("مقاله", layerDeletePaperPanel);
            allDeleteLayerPanels.Add("لوح فشرده و نرم افزار", layerDeleteCDPanel);
            allDeleteLayerPanels.Add("کاست", layerDeleteCassettePanel);
            allDeleteLayerPanels.Add("مدارک", layerDeleteDocumentsPanel);

            allAddLayerPanels.Add("نوار ویدئویی", layerAddVideoTapePanel);
            allAddLayerPanels.Add("آلبوم عکس", layerAddAlbumPanel);
            allAddLayerPanels.Add("کتاب", layerAddBookPanel);
            allAddLayerPanels.Add("روزنامه", layerAddNewspaperPanel);
            allAddLayerPanels.Add("مجله", layerAddMagazinePanel);
            allAddLayerPanels.Add("مقاله", layerAddPaperPanel);
            allAddLayerPanels.Add("لوح فشرده و نرم افزار", layerAddCDPanel);
            allAddLayerPanels.Add("کاست", layerAddCassettePanel);
            allAddLayerPanels.Add("مدارک", layerAddDocumentsPanel);


            allAdvSearchLayerPanels.Add("نوار ویدئویی", layerAdvSearchVideoTapePanel);
            allAdvSearchLayerPanels.Add("آلبوم عکس", layerAdvSearchAlbumPanel);
            allAdvSearchLayerPanels.Add("کتاب", layerAdvSearchBookPanel);
            allAdvSearchLayerPanels.Add("روزنامه", LayerAdvSearchNewspaperPanel);
            allAdvSearchLayerPanels.Add("مجله", layerAdvSearchMagazinePanel);
            allAdvSearchLayerPanels.Add("مقاله", layerAdvSearchPaperPanel);
            allAdvSearchLayerPanels.Add("لوح فشرده و نرم افزار", layerAdvSearchCDPanel);
            allAdvSearchLayerPanels.Add("کاست", layerAdvSearchCassettePanel);
            allAdvSearchLayerPanels.Add("مدارک", layerAdvSearchDocumentsPanel);


            for (int i = 0; i < alleditLayerPanels.Count; i++)
                (alleditLayerPanels.Values.ElementAt(i)).Visible = false;
            for (int i = 0; i < allDeleteLayerPanels.Count; i++)
                (allDeleteLayerPanels.Values.ElementAt(i)).Visible = false;
            for (int i = 0; i < allAddLayerPanels.Count; i++)
                (allAddLayerPanels.Values.ElementAt(i)).Visible = false;
            for (int i = 0; i < allAdvSearchLayerPanels.Count; i++)
                (allAdvSearchLayerPanels.Values.ElementAt(i)).Visible = false;
            otherEditPanel.Visible = false;
            otherAddPanel.Visible = false;
        }

        private void confirmSearchButton_Click(object sender, EventArgs e)
        {
            SimpleSearchDataGridView.Visible = true;
            label22.Visible = true;
            validSearch.Visible = true;

            //Add
            string Type = simpleSearchObjectType.Text;
            if (Type != null && Type != "" && Type != "انتخاب کنید")
            {
                string Message;
                //MessageBox.Show(Type);
                SimpleSearchInTheTable(Type);

                //MessageBox.Show(Message);
                Message = ShowingDataInSimpleSearchDataGridView();
                if (Message[0] == '1')
                {
                    validSearch.Text = " بار شدن جدول " + Type;
                }
                else
                {
                    validSearch.Text = "خطا در بار شدن";
                }
            }
            //-Add
            validSearch.Text = "جستجو با موفقیت انجام شد";
            collectSimpleSearchRequest();

            string Mahsoual_Type = simpleSearchRequest["نوع محصول"];
            string Name = simpleSearchRequest["نام محصول"];
            string Place = simpleSearchRequest["مکان فیزیکی"];
            string LoanStatus = simpleSearchRequest["وضعیت امانت"];

            string message = "1 Successfully Shows in Viewing Table.";
            //MessageBox.Show(Mahsoual_Type);
            switch (Mahsoual_Type)                                                           //Showing Entire Table Process
            {
                case "کتاب":

                    Book Book_Obj = new Book();
                    message = Book_Obj.SimpleBookSearch(Name, Place, LoanStatus);
                    break;

                case "روزنامه":
                    NewsPaper new_obj = new NewsPaper();
                    new_obj.SimpleNewspaperSearch(Name, Place, LoanStatus);
                    break;

                case "مجله":
                    Magazine mag_Obj = new Magazine();
                    mag_Obj.SimpleMajaleSearch(Name, Place, LoanStatus);
                    break;

                case "مقاله":
                    Paper Paper_Obj = new Paper();
                    message = Paper_Obj.SimplePaperSearch(Name, Place, LoanStatus);
                    break;

                case "لوح فشرده و نرم افزار":
                    CD cd_obj = new CD();
                    cd_obj.SimpleCDSearch(Name, Place, LoanStatus);
                    break;

                case "آلبوم عکس":
                    Gallery Gallery_Obj = new Gallery();
                    //Gallery_Obj.SetSimpleSearchDataGrid(SimpleSearchDataGrid);
                    message = Gallery_Obj.SimpleGallerySearch(Name, Place, LoanStatus);
                    // MessageBox.Show(Message);
                    break;

                case "کاست":
                      Cossette Cossette_Obj = new Cossette();
                      message = Cossette_Obj.SimpleCossetteSearch(Name, Place, LoanStatus);
                      
                    break;

                case "نوار ویدئویی":
                     Video Video_Obj = new Video();
                     message = Video_Obj.SimpleVideoSearch(Name, Place, LoanStatus);
                   
                    break;

                case "مدارک":
                    Document Document_Obj = new Document();
                    message = Document_Obj.SimpleDocumentSearch(Name, Place, LoanStatus);

                    break;
                case "":
                    message = "نوع محصول را انتخاب کنین";
                    break;
                case null:
                    message = "نوع محصول را انتخاب کنین";
                    break;
            }

            ShowingDataInSimpleSearchDataGridView();
            //SimpleSearchDataGrid.he
            //Add
 
        }


        private void backupSavePath_Click_1(object sender, EventArgs e)
        {


            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            string[] files = Directory.GetFiles(fbd.SelectedPath);
            browseBackupTextBox.Text = fbd.SelectedPath;
        }


        private void editObjectTypeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String input = (String)editObjectTypeComboBox.SelectedItem;
            for (int i = 0; i < alleditLayerPanels.Count; i++)
                (alleditLayerPanels.Values.ElementAt(i)).Visible = false;
            if (input != null && input != "" && input != " " && input != "\n")
            {
                clearPanel(alleditLayerPanels[input]);
                alleditLayerPanels[input].Visible = true;
            }
            editCommentsRichTextBox.Text = "";
            editPositionRichTextBox.Text = "";
            otherEditPanel.Visible = true;
            selectedEditLayerPanel = alleditLayerPanels[input];

 
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            try
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                browseBackupTextBox.Text = fbd.SelectedPath;
                backupFilePath = fbd.SelectedPath;
            }
            catch (Exception exc)
            {
                MessageBox.Show("پوشه مورد نظر به صورت صحیح انتخاب نشده است");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {

            string text = "";
            string file = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                text = File.ReadAllText(file);

            }

            restoreFilePath = file;
            browseRestoreTextBox.Text = file;
        }

        private void passwordChangeButton_Click(object sender, EventArgs e)
        {
            if (Program.f1.PassWord == oldPasswordBox.Text)
                if (confirmPasswordBox.Text == newPasswordBox.Text)
                {
                    Program.f1.PassWord = newPasswordBox.Text;
                    validLabelPassword.Text = "تغییر رمز با موفقیت انجام شد";
                    Program.savePasswordTofile(Program.f1.PassWord);
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("تکرار رمز عبور با رمز عبور جدید مطابقت ندارد");
                    validLabelPassword.Text = "";
                }
            else
            {
                System.Windows.Forms.MessageBox.Show("رمز عبور اولیه صحیح نیست");
            }

        }


        private void button32_Click(object sender, EventArgs e)
        {
            validLabelPishrafte.Text = "جستجو با موفقیت انجام شد";

        }

        private void addObjectTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String input = (String)addObjectTypeComboBox.SelectedItem;
            for (int i = 0; i < allAddLayerPanels.Count; i++)
                (allAddLayerPanels.Values.ElementAt(i)).Visible = false;
            if (input != null && input != "" && input != " " && input != "\n")
                allAddLayerPanels[input].Visible = true;

        }
        private void showArray(String[] array)
        {
            String res = "";
            for (int i = 0; i < array.Length; i++)
                res += (array[i] + "\n");
            MessageBox.Show(res);
        }
        private void showList(List<String> list)
        {
            String res = "";
            for (int i = 0; i < list.Count; i++)
                res += (list[i] + "\n");
            MessageBox.Show(res);
        }
        private void showDictionary(Dictionary<String, String> dictionary)
        {
            String result = "";
            for (int i = 0; i < dictionary.Count; i++)
            {
                result += (dictionary.Keys.ElementAt(i) + " " + dictionary.Values.ElementAt(i) + "\n");
            }
            MessageBox.Show(result);
        }

        private void collectSimpleSearchRequest()
        {
            simpleSearchRequest.Clear();
            simpleSearchRequest.Add("نوع محصول", (String)simpleSearchObjectType.SelectedItem);
            simpleSearchRequest.Add("نام محصول", (String)simpleSearchObjectID.Text);
            simpleSearchRequest.Add("مکان فیزیکی", simpleSearchObjectPosition.Text);
            simpleSearchRequest.Add("وضعیت امانت", (String)simpleSearchBorrowStatus.SelectedItem);
        }

        private void collectAdvancedSearchRequest()
        {

            AdvancedSearchRequest.Clear();
            switch (selectedAdvSearchLayerPanel.Name)
            {
                case "layerAdvSearchVideoTapePanel":
                    collectAdvSearchVideoTapeRequest();
                    break;
                case "layerAdvSearchAlbumPanel":
                    collectAdvSearchAlbumRequest();
                    break;
                case "layerAdvSearchBookPanel":
                    collectAdvSearchBookRequest();
                    break;
                case "LayerAdvSearchNewspaperPanel":
                    collectAdvSearchNewspaperRequest();
                    break;
                case "layerAdvSearchMagazinePanel":
                    collectAdvSearchMagazineRequest();
                    break;
                case "layerAdvSearchPaperPanel":
                    collectAdvSearchPaperRequest();
                    break;
                case "layerAdvSearchCDPanel":
                    collectAdvSearchCDRequest();
                    break;
                case "layerAdvSearchCassettePanel":
                    collectAdvSearchCassetteRequest();
                    break;
                case "layerAdvSearchDocumentsPanel":
                    collectAdvSearchDocumentsRequest();
                    break;
                default:
                    break;
            }
        }
        void collectAdvSearchVideoTapeRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAdvSearchLayerPanel);
            AdvancedSearchRequest.Clear();
            String[] titles = { "درجه علاقه مندی", "جوایز", "سال انتشار", "بازیگران", "کارگردان", "موضوع" };
            for (int i = 0; i < request.Count; i++)
            {
                AdvancedSearchRequest.Add(titles[i], request[i]);
            }
        }
        void collectAdvSearchAlbumRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAdvSearchLayerPanel);
            AdvancedSearchRequest.Clear();
            String[] titles = { "سال", "نام آلبوم", "موضوع", "محل گرفتن عکس", "افراد" };
            for (int i = 0; i < request.Count; i++)
            {
                AdvancedSearchRequest.Add(titles[i], request[i]);
            }
        }

        void collectAdvSearchBookRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAdvSearchLayerPanel);
            AdvancedSearchRequest.Clear();
            String[] titles = { "سال انتشار", "نام نویسندگان", "قیمت", "ناشر", "نام مترجم", "عنوان کتاب", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                AdvancedSearchRequest.Add(titles[i], request[i]);
            }


        }
        void collectAdvSearchNewspaperRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAdvSearchLayerPanel);
            AdvancedSearchRequest.Clear();
            String[] titles = { "ماه", "سال", "روز", "موضوع", "نام روزنامه" };
            for (int i = 0; i < request.Count; i++)
            {
                AdvancedSearchRequest.Add(titles[i], request[i]);
            }
        }

        void collectAdvSearchMagazineRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAdvSearchLayerPanel);
            AdvancedSearchRequest.Clear();
            String[] titles = { "درجه علاقه مندی", "ماه", "سال", "روز", "شماره", "موضوع", "نام مجله" };
            for (int i = 0; i < request.Count; i++)
            {
                AdvancedSearchRequest.Add(titles[i], request[i]);
            }
        }


        void collectAdvSearchPaperRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAdvSearchLayerPanel);
            AdvancedSearchRequest.Clear();
            String[] titles = { "سال انتشار", "نام نویسندگان", "ژورنال", "عنوان مقاله", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                AdvancedSearchRequest.Add(titles[i], request[i]);
            }
        }

        void collectAdvSearchCDRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAdvSearchLayerPanel);
            AdvancedSearchRequest.Clear();
            String[] titles = { "قیمت", "نام", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                if (i > 2)
                    AdvancedSearchRequest.Add("محتوا" + (i - 3), request[i]);
                else
                    AdvancedSearchRequest.Add(titles[i], request[i]);

            }
        }
        void collectAdvSearchCassetteRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAdvSearchLayerPanel);
            AdvancedSearchRequest.Clear();
            String[] titles = { "سال", "سخنران/خواننده/نوازنده", "موضوع", "نام کاست" };
            for (int i = 0; i < request.Count; i++)
            {
                AdvancedSearchRequest.Add(titles[i], request[i]);

            }
        }
        void collectAdvSearchDocumentsRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAdvSearchLayerPanel);
            AdvancedSearchRequest.Clear();
            String[] titles = { "نوع مدرک", "نام شخص" };
            for (int i = 0; i < request.Count; i++)
            {
                AdvancedSearchRequest.Add(titles[i], request[i]);

            }
        }

        private void collectEditRequest()
        {
            //EditResult = getPanelComponentsContent(selectedEditLayerPanel);
            EditRequest.Clear();
            switch (selectedEditLayerPanel.Name)
            {
                case "layerEditVideoTapePanel":
                    collectEditVideoTapeRequest();
                    break;
                case "layerEditAlbumPanel":
                    collectEditAlbumRequest();
                    break;
                case "layerEditBookPanel":
                    collectEditBookRequest();
                    break;
                case "layerEditNewspaperPanel":
                    collectEditNewspaperRequest();
                    break;
                case "layerEditMagazinePanel":
                    collectEditMagazineRequest();
                    break;
                case "layerEditPaperPanel":
                    collectEditPaperRequest();
                    break;
                case "layerEditCDPanel":
                    collectEditCDRequest();
                    break;
                case "layerEditCassettePanel":
                    collectEditCassetteRequest();
                    break;
                case "layerEditDocPanel":
                    collectEditDocumentsRequest();
                    break;
                default:
                    break;
            }
        }
        void collectEditVideoTapeRequest()
        {
            List<String> request = getPanelComponentsContent(selectedEditLayerPanel);
            EditRequest.Clear();
            String[] titles = { "درجه علاقه مندی", "جوایز", "سال انتشار", "بازیگران", "کارگردان", "موضوع" };
            for (int i = 0; i < request.Count; i++)
            {
                EditRequest.Add(titles[i], request[i]);
            }
            EditRequest.Add("مکان فیزیکی محصول", editPositionRichTextBox.Text);
            EditRequest.Add("توضیحات", editCommentsRichTextBox.Text);
        }
        void collectEditAlbumRequest()
        {
            List<String> request = getPanelComponentsContent(selectedEditLayerPanel);
            EditRequest.Clear();
            String[] titles = { "سال", "نام آلبوم", "موضوع", "محل گرفتن عکس", "افراد" };
            for (int i = 0; i < request.Count; i++)
            {
                EditRequest.Add(titles[i], request[i]);
            }
            EditRequest.Add("مکان فیزیکی محصول", editPositionRichTextBox.Text);
            EditRequest.Add("توضیحات", editCommentsRichTextBox.Text);

        }

        void collectEditBookRequest()
        {
            List<String> request = getPanelComponentsContent(selectedEditLayerPanel);
            EditRequest.Clear();
            String[] titles = { "سال انتشار", "نام نویسندگان", "قیمت", "ناشر", "نام مترجم", "عنوان کتاب", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                EditRequest.Add(titles[i], request[i]);
            }
            EditRequest.Add("مکان فیزیکی محصول", editPositionRichTextBox.Text);
            EditRequest.Add("توضیحات", editCommentsRichTextBox.Text);


        }
        void collectEditNewspaperRequest()
        {
            MessageBox.Show("req is " + selectedEditLayerPanel.Name);
            List<String> request = getPanelComponentsContent(selectedEditLayerPanel);
            EditRequest.Clear();
            String[] titles = { "ماه", "سال", "روز", "موضوع", "نام روزنامه" };
            for (int i = 0; i < request.Count; i++)
            {
                EditRequest.Add(titles[i], request[i]);
            }
            EditRequest.Add("مکان فیزیکی محصول", editPositionRichTextBox.Text);
            EditRequest.Add("توضیحات", editCommentsRichTextBox.Text);

        }

        void collectEditMagazineRequest()
        {
            List<String> request = getPanelComponentsContent(selectedEditLayerPanel);
            EditRequest.Clear();
            String[] titles = { "درجه علاقه مندی", "ماه", "سال", "روز", "شماره", "موضوع", "نام مجله" };
            for (int i = 0; i < request.Count; i++)
            {
                EditRequest.Add(titles[i], request[i]);
            }
            EditRequest.Add("مکان فیزیکی محصول", editPositionRichTextBox.Text);
            EditRequest.Add("توضیحات", editCommentsRichTextBox.Text);

        }


        void collectEditPaperRequest()
        {
            List<String> request = getPanelComponentsContent(selectedEditLayerPanel);
            EditRequest.Clear();
            String[] titles = { "سال انتشار", "نام نویسندگان", "ژورنال", "عنوان مقاله", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                EditRequest.Add(titles[i], request[i]);
            }
            EditRequest.Add("مکان فیزیکی محصول", editPositionRichTextBox.Text);
            EditRequest.Add("توضیحات", editCommentsRichTextBox.Text);

        }

        void collectEditCDRequest()
        {
            List<String> request = getPanelComponentsContent(selectedEditLayerPanel);
            EditRequest.Clear();
            String[] titles = { "قیمت", "نام", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                if (i > 2)
                    EditRequest.Add("محتوا" + (i - 3), request[i]);
                else
                    EditRequest.Add(titles[i], request[i]);

            }
            EditRequest.Add("مکان فیزیکی محصول", editPositionRichTextBox.Text);
            EditRequest.Add("توضیحات", editCommentsRichTextBox.Text);

        }
        void collectEditCassetteRequest()
        {
            List<String> request = getPanelComponentsContent(selectedEditLayerPanel);
            EditRequest.Clear();
            String[] titles = { "سال", "سخنران/خواننده/نوازنده", "موضوع", "نام کاست" };
            for (int i = 0; i < request.Count; i++)
            {
                EditRequest.Add(titles[i], request[i]);

            }
            EditRequest.Add("مکان فیزیکی محصول", editPositionRichTextBox.Text);
            EditRequest.Add("توضیحات", editCommentsRichTextBox.Text);

        }
        void collectEditDocumentsRequest()
        {
            //MessageBox.Show("hi ");
            List<String> request = getPanelComponentsContent(selectedEditLayerPanel);
            showList(request);
            EditRequest.Clear();
            String[] titles = { "نام شخص", "نوع مدرک" };
            for (int i = 0; i < request.Count; i++)
            {
                EditRequest.Add(titles[i], request[i]);

            }
            EditRequest.Add("مکان فیزیکی محصول", editPositionRichTextBox.Text);
            EditRequest.Add("توضیحات", editCommentsRichTextBox.Text);
        }

        private void collectAddRequest()
        {

            AddRequest.Clear();
            switch (selectedAddLayerPanel.Name)
            {
                case "layerAddVideoTapePanel":
                    collectAddVideoTapeRequest();
                    break;
                case "layerAddAlbumPanel":
                    collectAddAlbumRequest();
                    break;
                case "layerAddBookPanel":
                    collectAddBookRequest();
                    break;
                case "layerAddNewspaperPanel":
                    collectAddNewspaperRequest();
                    break;
                case "layerAddMagazinePanel":
                    collectAddMagazineRequest();
                    break;
                case "layerAddPaperPanel":
                    collectAddPaperRequest();
                    break;
                case "layerAddCDPanel":
                    collectAddCDRequest();
                    break;
                case "layerAddCassettePanel":
                    collectAddCassetteRequest();
                    break;
                case "layerAddDocumentsPanel":
                    collectAddDocumentsRequest();
                    break;
                default:
                    break;
            }
        }
        void collectAddVideoTapeRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAddLayerPanel);
            AddRequest.Clear();
            String[] titles = { "درجه علاقه مندی", "جوایز", "سال انتشار", "بازیگران", "کارگردان", "موضوع" };
            for (int i = 0; i < request.Count; i++)
            {
                AddRequest.Add(titles[i], request[i]);
            }
            AddRequest.Add("مکان فیزیکی محصول", addPositionRichTextBox.Text);
            AddRequest.Add("توضیحات", addCommentsRichTextBox.Text);
        }
        void collectAddAlbumRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAddLayerPanel);
            AddRequest.Clear();
            String[] titles = { "سال", "نام آلبوم", "موضوع", "محل گرفتن عکس", "افراد" };
            for (int i = 0; i < request.Count; i++)
            {
                AddRequest.Add(titles[i], request[i]);
            }
            AddRequest.Add("مکان فیزیکی محصول", addPositionRichTextBox.Text);
            AddRequest.Add("توضیحات", addCommentsRichTextBox.Text);

        }

        void collectAddBookRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAddLayerPanel);
            AddRequest.Clear();
            String[] titles = { "سال انتشار", "نام نویسندگان", "قیمت", "ناشر", "نام مترجم", "عنوان کتاب", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                AddRequest.Add(titles[i], request[i]);
            }
            AddRequest.Add("مکان فیزیکی محصول", addPositionRichTextBox.Text);
            AddRequest.Add("توضیحات", addCommentsRichTextBox.Text);


        }
        void collectAddNewspaperRequest()
        {
            MessageBox.Show("req is " + selectedAddLayerPanel.Name);
            List<String> request = getPanelComponentsContent(selectedAddLayerPanel);
            AddRequest.Clear();
            String[] titles = { "ماه", "سال", "روز", "موضوع", "نام روزنامه" };
            for (int i = 0; i < request.Count; i++)
            {
                AddRequest.Add(titles[i], request[i]);
            }
            AddRequest.Add("مکان فیزیکی محصول", addPositionRichTextBox.Text);
            AddRequest.Add("توضیحات", addCommentsRichTextBox.Text);

        }

        void collectAddMagazineRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAddLayerPanel);
            AddRequest.Clear();
            String[] titles = { "درجه علاقه مندی", "ماه", "سال", "روز", "شماره", "موضوع", "نام مجله" };
            for (int i = 0; i < request.Count; i++)
            {
                AddRequest.Add(titles[i], request[i]);
            }
            AddRequest.Add("مکان فیزیکی محصول", addPositionRichTextBox.Text);
            AddRequest.Add("توضیحات", addCommentsRichTextBox.Text);

        }


        void collectAddPaperRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAddLayerPanel);
            AddRequest.Clear();
            String[] titles = { "سال انتشار", "نام نویسندگان", "ژورنال", "عنوان مقاله", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                AddRequest.Add(titles[i], request[i]);
            }
            AddRequest.Add("مکان فیزیکی محصول", addPositionRichTextBox.Text);
            AddRequest.Add("توضیحات", addCommentsRichTextBox.Text);

        }

        void collectAddCDRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAddLayerPanel);
            AddRequest.Clear();
            String[] titles = { "قیمت", "نام", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                if (i > 2)
                    AddRequest.Add("محتوا" + (i - 3), request[i]);
                else
                    AddRequest.Add(titles[i], request[i]);

            }
            AddRequest.Add("مکان فیزیکی محصول", addPositionRichTextBox.Text);
            AddRequest.Add("توضیحات", addCommentsRichTextBox.Text);

        }
        void collectAddCassetteRequest()
        {
            List<String> request = getPanelComponentsContent(selectedAddLayerPanel);
            AddRequest.Clear();
            String[] titles = { "سال", "سخنران/خواننده/نوازنده", "موضوع", "نام کاست" };
            for (int i = 0; i < request.Count; i++)
            {
                AddRequest.Add(titles[i], request[i]);

            }
            AddRequest.Add("مکان فیزیکی محصول", addPositionRichTextBox.Text);
            AddRequest.Add("توضیحات", addCommentsRichTextBox.Text);

        }
        void collectAddDocumentsRequest()
        {
            //MessageBox.Show("hi ");
            List<String> request = getPanelComponentsContent(selectedAddLayerPanel);
            showList(request);
            AddRequest.Clear();
            String[] titles = { "نوع مدرک", "نام شخص" };
            for (int i = 0; i < request.Count; i++)
            {
                AddRequest.Add(titles[i], request[i]);

            }
            AddRequest.Add("مکان فیزیکی محصول", addPositionRichTextBox.Text);
            AddRequest.Add("توضیحات", addCommentsRichTextBox.Text);
        }
        private void collectDeleteRequest()
        {
            DeleteRequest.Clear();
            switch (selectedDeleteLayerPanel.Name)
            {
                case "layerDeleteVideoTapePanel":
                    collectDeleteVideoTapeRequest();
                    break;
                case "layerDeleteAlbumPanel":
                    collectDeleteAlbumRequest();
                    break;
                case "layerDeleteBookPanel":
                    collectDeleteBookRequest();
                    break;
                case "layerDeleteNewspaperPanel":
                    collectDeleteNewspaperRequest();
                    break;
                case "layerDeleteMagazinePanel":
                    collectDeleteMagazineRequest();
                    break;
                case "layerDeletePaperPanel":
                    collectDeletePaperRequest();
                    break;
                case "layerDeleteCDPanel":
                    collectDeleteCDRequest();
                    break;
                case "layerDeleteCassettePanel":
                    collectDeleteCassetteRequest();
                    break;
                case "layerDeleteDocumentsPanel":
                    collectDeleteDocumentsRequest();
                    break;
                default:
                    break;
            }
        }
        void collectDeleteVideoTapeRequest()
        {
            List<String> request = getPanelComponentsContent(selectedDeleteLayerPanel);
            DeleteRequest.Clear();
            String[] titles = { "درجه علاقه مندی", "جوایز", "سال انتشار", "بازیگران", "کارگردان", "موضوع" };
            for (int i = 0; i < request.Count; i++)
            {
                DeleteRequest.Add(titles[i], request[i]);
            }
        }
        void collectDeleteAlbumRequest()
        {
            List<String> request = getPanelComponentsContent(selectedDeleteLayerPanel);
            DeleteRequest.Clear();
            String[] titles = { "سال", "نام آلبوم", "موضوع", "محل گرفتن عکس", "افراد" };
            for (int i = 0; i < request.Count; i++)
            {
                DeleteRequest.Add(titles[i], request[i]);
            }

        }

        void collectDeleteBookRequest()
        {
            List<String> request = getPanelComponentsContent(selectedDeleteLayerPanel);
            DeleteRequest.Clear();
            String[] titles = { "سال انتشار", "نام نویسندگان", "قیمت", "ناشر", "نام مترجم", "عنوان کتاب", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                DeleteRequest.Add(titles[i], request[i]);
            }

        }
        void collectDeleteNewspaperRequest()
        {
            MessageBox.Show("req is " + selectedDeleteLayerPanel.Name);
            List<String> request = getPanelComponentsContent(selectedDeleteLayerPanel);
            DeleteRequest.Clear();
            String[] titles = { "ماه", "سال", "روز", "موضوع", "نام روزنامه" };
            for (int i = 0; i < request.Count; i++)
            {
                DeleteRequest.Add(titles[i], request[i]);
            }

        }

        void collectDeleteMagazineRequest()
        {
            List<String> request = getPanelComponentsContent(selectedDeleteLayerPanel);
            DeleteRequest.Clear();
            String[] titles = { "درجه علاقه مندی", "ماه", "سال", "روز", "شماره", "موضوع", "نام مجله" };
            for (int i = 0; i < request.Count; i++)
            {
                DeleteRequest.Add(titles[i], request[i]);
            }

        }


        void collectDeletePaperRequest()
        {
            List<String> request = getPanelComponentsContent(selectedDeleteLayerPanel);
            DeleteRequest.Clear();
            String[] titles = { "سال انتشار", "نام نویسندگان", "ژورنال", "عنوان مقاله", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                DeleteRequest.Add(titles[i], request[i]);
            }

        }

        void collectDeleteCDRequest()
        {
            List<String> request = getPanelComponentsContent(selectedDeleteLayerPanel);
            DeleteRequest.Clear();
            String[] titles = { "قیمت", "نام", "درجه علاقه مندی" };
            for (int i = 0; i < request.Count; i++)
            {
                if (i > 2)
                    DeleteRequest.Add("محتوا" + (i - 3), request[i]);
                else
                    DeleteRequest.Add(titles[i], request[i]);

            }

        }
        void collectDeleteCassetteRequest()
        {
            List<String> request = getPanelComponentsContent(selectedDeleteLayerPanel);
            DeleteRequest.Clear();
            String[] titles = { "سال", "سخنران/خواننده/نوازنده", "موضوع", "نام کاست" };
            for (int i = 0; i < request.Count; i++)
            {
                DeleteRequest.Add(titles[i], request[i]);

            }

        }
        void collectDeleteDocumentsRequest()
        {
            //MessageBox.Show("hi ");
            List<String> request = getPanelComponentsContent(selectedDeleteLayerPanel);
            showList(request);
            DeleteRequest.Clear();
            String[] titles = { "نوع مدرک", "نام شخص" };
            for (int i = 0; i < request.Count; i++)
            {
                DeleteRequest.Add(titles[i], request[i]);

            }
        }



        private void AdvSearchObjectTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String input = (String)AdvSearchObjectTypeComboBox.SelectedItem;
            for (int i = 0; i < allAdvSearchLayerPanels.Count; i++)
                (allAdvSearchLayerPanels.Values.ElementAt(i)).Visible = false;
            if (input != null && input != "" && input != " " && input != "\n")
            {
                clearPanel(allAdvSearchLayerPanels[input]);
                allAdvSearchLayerPanels[input].Visible = true;
            }
            selectedAdvSearchLayerPanel = allAdvSearchLayerPanels[input];
            collectAdvancedSearchRequest();


        }

        private void deleteObjectTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String input = (String)deleteObjectTypeComboBox.SelectedItem;
            for (int i = 0; i < allDeleteLayerPanels.Count; i++)
                (allDeleteLayerPanels.Values.ElementAt(i)).Visible = false;
            if (input != null && input != "" && input != " " && input != "\n")
            {
                clearPanel(allDeleteLayerPanels[input]);
                allDeleteLayerPanels[input].Visible = true;
            }

            selectedDeleteLayerPanel = allDeleteLayerPanels[input];




        }

        private List<String> getPanelComponentsContent(Panel panel)
        {
            List<String> result = new List<String>();

            foreach (Control c in panel.Controls)
            {
                if (c is TextBox)
                    result.Add(((TextBox)c).Text);
                if (c is ComboBox)
                    result.Add((String)((ComboBox)c).SelectedItem);
                if (c is RichTextBox)
                    result.Add(((RichTextBox)c).Text);
                if (c is MaskedTextBox)
                    result.Add(((MaskedTextBox)c).Text);

            }
            foreach (Control c in panel.Controls)
            {
                if (c is CheckBox && ((CheckBox)c).Checked)
                    result.Add(((CheckBox)c).Text);
            }

            return result;
        }


        private void addObjectTypeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            String input = (String)addObjectTypeComboBox.SelectedItem;
            for (int i = 0; i < allAddLayerPanels.Count; i++)
                (allAddLayerPanels.Values.ElementAt(i)).Visible = false;
            if (input != null && input != "" && input != " " && input != "\n")
            {
                clearPanel(allAddLayerPanels[input]);
                allAddLayerPanels[input].Visible = true;
            }
            addCommentsRichTextBox.Text = "";
            addPositionRichTextBox.Text = "";
            otherAddPanel.Visible = true;
            selectedAddLayerPanel = allAddLayerPanels[input];



        }
        private void clearPanel(Panel panel)
        {
            if (!(panel == null))
            {
                foreach (Control c in panel.Controls)
                {
                    if (c is TextBox)
                        ((TextBox)c).Text = "";
                    if (c is ComboBox)
                        ((ComboBox)c).SelectedItem = "";
                    if (c is RichTextBox)
                        ((RichTextBox)c).Text = "";
                    if (c is MaskedTextBox)
                        ((MaskedTextBox)c).Text = "";
                    if (c is CheckBox)
                        ((CheckBox)c).Checked = false;

                }
                panel.Visible = false;
            }
        }


        private void buttonapplyEdit_Click_1(object sender, EventArgs e)
        {
            InsertionDataGridView.Visible = true;
            label213.Visible = true;
            label212.Visible = true;
            //Add
            string Type;
            Type = TypeOfSelected(selectedAddLayerPanel.Name);


            if (Type != null && Type != "" && Type != "انتخاب کنید")
            {
                string Message;

                SimpleSearchInTheTable(Type);

                Message = ShowingDataInInsertionDataGridView();
                if (Message[0] == '1')
                {
                    label212.Text = " بار شدن جدول " + Type;
                }
                else
                {
                    label212.Text = "خطا در بار شدن";
                }


            }
           
            try
            {
                collectAddRequest();
//                showDictionary(AddRequest);

                string Message = "1";
                //ADDDD
             
               // MessageBox.Show(Type);
                switch (Type)                                                           //Showing Entire Table Process
                {
                    case "layerAdvSearchBookPanel":

                        /*
                        Book Book_Obj = new Book();
                        Message = Book_Obj.CompleteBookSearch;
                         */
                        break;

                    case "روزنامه":

                        break;

                    case "مجله":
                        // "درجه علاقه مندی", "ماه", "سال", "روز", "شماره", "موضوع", "نام مجله"

                        Magazine mag_obj = new Magazine();
                        mag_obj.SetInsertionDataGridView(InsertionDataGridView);

                        mag_obj.InsertMajale(AddRequest["نام مجله"], AddRequest["موضوع"], AddRequest["سال"], AddRequest["ماه"], AddRequest["شماره"], null, AddRequest["درجه علاقه مندی"], null, null, null, null);


                        break;

                    case "مقاله":
                        //mag_obj.EditMajale(EditRequest["نام مجله"], EditRequest["موضوع"], EditRequest["سال"], EditRequest["ماه"], EditRequest["شماره"], null, EditRequest["درجه علاقه مندی"], null, null, Id);
                        break;

                    case "لوح فشرده و نرم افزار":
                        string[] Mohtava;
                        List<string> Mohtava_L = new List<string>();
                        CD cd_obj = new CD();
                        if (checkBox18.Checked)
                        {
                            Mohtava_L.Add("فیلم");
                        }
                        if (checkBox17.Checked)
                        {
                            Mohtava_L.Add("عکس");
                        }
                        if (checkBox16.Checked)
                        {
                            Mohtava_L.Add("موسیقی");
                        }
                        if (checkBox15.Checked)
                        {
                            Mohtava_L.Add("فایل متنی");
                        }
                        if (checkBox14.Checked)
                        {
                            Mohtava_L.Add("نرم افزار");
                        }
                        if (checkBox13.Checked)
                        {
                            Mohtava_L.Add("سایر");
                        }
                        Mohtava = Mohtava_L.ToArray();

                        // "قیمت", "نام", "درجه علاقه مندی"
                        cd_obj.CompleteCDSearch(AdvancedSearchRequest["نام"], Mohtava, AdvancedSearchRequest["قیمت"], AdvancedSearchRequest["درجه علاقه مندی"]);
                        break;

                    case "آلبوم عکس":
                        /*
                        Gallery Gallery_Obj = new Gallery();
                        Message = Gallery_Obj.SimpleGallerySearch(Name, Place, LoanStatus);
                        // MessageBox.Show(Message);
                         */
                        break;

                    case "کاست":
                        /*  Cossette Cossette_Obj = new Cossette();
                          Message = Cossette_Obj.SimpleCossetteSearch(Name, Place, LoanStatus);
                          */
                        break;

                    case "نوار ویدئویی":
                        /* Video Video_Obj = new Video();
                         Message = Video_Obj.SimplevideoSearch(Name, Place, LoanStatus));
                       */
                        break;

                    case "مدارک":
                        //"نوع مدرک", "نام شخص"
                        //["نام شخص"], EditRequest["نوع مدرک"], EditRequest["مکان فیزیکی محصول"], EditRequest["توضیحات"],
                        Document Doc_Obj = new Document();
                        Doc_Obj.SetInsertionDataGridView(InsertionDataGridView);
                        Message= Doc_Obj.InsertDocument(AddRequest["نام شخص"], AddRequest["نوع مدرک"], AddRequest["مکان فیزیکی محصول"], AddRequest["توضیحات"], null, null);
                        //Message = Doc_Obj.InsertDocument("dar", "مدرک شناسایی", null, null, null, null);

                        break;
                    case "":
                        Message = "نوع محصول را انتخاب کنین";
                        break;
                    case null:
                        Message = "نوع محصول را انتخاب کنین";
                        break;
                }

                if (Message[0] == '1')
                {
                    ShowingDataInInsertionDataGridView();
                    //DataGridViewEditingControlShowingEventArgs;
                    Message = "اضافه کردن با موفقیت انجام شد ";
                }
                else
                {
                    Message = "اضافه کردن ناموفق بود";
                }
                label212.Text = Message;
                // ShowingDataInCompleteSearchDataGridView();
            
        
            }
        catch
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditDataGridView.Visible = true;
            label206.Visible = true;
            label207.Visible = true;
            int c = selectedEditLayerPanel.Controls.Count;
            //MessageBox.Show(c.ToString());
            collectEditRequest();
            showDictionary(EditRequest);
            //Add
            string Type;
            Type = TypeOfSelected(selectedEditLayerPanel.Name);
            // MessageBox.Show(selectedEditLayerPanel.Name);

            if (Type != null && Type != "" && Type != "انتخاب کنید")
            {
                string Message;

                SimpleSearchInTheTable(Type);
                Message = ShowingDataInEditDataGridView();

                ShowingDataInEditDataGridView();
                if (Message[0] == '1')
                {
                    label208.Text = " بار شدن جدول " + Type;
                }
                else
                {
                    label208.Text = "خطا در بار شدن";
                }


            }
            //-Add

        }

        private void confirmDeleteButton_Click(object sender, EventArgs e)
        {


            collectDeleteRequest();
            showDictionary(DeleteRequest);
            string Type;
            Type = TypeOfSelected(selectedDeleteLayerPanel.Name);
            string Message = "1 Successfully Deleted.";
           // MessageBox.Show(Type);

            switch (Type)                                                           //Showing Entire Table Process
            {
                case "کتاب":

                    /*
                    Book Book_Obj = new Book();
                    Message = Book_Obj.CompleteBookSearch;
                     */
                    break;

                case "روزنامه":

                    break;

                case "مجله":
                    // "درجه علاقه مندی", "ماه", "سال", "روز", "شماره", "موضوع", "نام مجله"

                    Magazine mag_obj = new Magazine();

                    string Id_Mag = Convert.ToString(DeleteDataGridView.CurrentRow.Cells["شناسه مجله"].Value);
                    label207.Text = Id_Mag;
                    //MessageBox.Show(Id);
                    //MessageBox.Show(EditRequest["نام مجله"]);
                    string[] Id_Mag_A = { Id_Mag };
                    mag_obj.SetDeleteDataGridView(DeleteDataGridView);
                    mag_obj.DeleteMajale(Id_Mag_A);
                    ShowingDataInDeleteDataGridView();
                     break;

                case "مقاله":
                    /*
                    Paper Paper_Obj = new Paper();
                    Message = Paper_Obj.SimplePaperSearch(Name, Place, LoanStatus);
                     */
                    break;

                case "لوح فشرده و نرم افزار":
                    string[] Mohtava;
                    List<string> Mohtava_L = new List<string>();
                    CD cd_obj = new CD();
                    if (checkBox6.Checked)
                    {
                        Mohtava_L.Add("فیلم");
                    }
                    if (checkBox5.Checked)
                    {
                        Mohtava_L.Add("عکس");
                    }
                    if (checkBox4.Checked)
                    {
                        Mohtava_L.Add("موسیقی");
                    }
                    if (checkBox3.Checked)
                    {
                        Mohtava_L.Add("فایل متنی");
                    }
                    if (checkBox2.Checked)
                    {
                        Mohtava_L.Add("نرم افزار");
                    }
                    if (checkBox1.Checked)
                    {
                        Mohtava_L.Add("سایر");
                    }
                    Mohtava = Mohtava_L.ToArray();

                    // "قیمت", "نام", "درجه علاقه مندی"
                    cd_obj.CompleteCDSearch(AdvancedSearchRequest["نام"], Mohtava, AdvancedSearchRequest["قیمت"], AdvancedSearchRequest["درجه علاقه مندی"]);
                    break;

                case "آلبوم عکس":
                    /*
                    Gallery Gallery_Obj = new Gallery();
                    Message = Gallery_Obj.SimpleGallerySearch(Name, Place, LoanStatus);
                    // MessageBox.Show(Message);
                     */
                    break;

                case "کاست":
                    /*  Cossette Cossette_Obj = new Cossette();
                      Message = Cossette_Obj.SimpleCossetteSearch(Name, Place, LoanStatus);
                      */
                    break;

                case "نوار ویدئویی":
                    /* Video Video_Obj = new Video();
                     Message = Video_Obj.SimplevideoSearch(Name, Place, LoanStatus));
                   */
                    break;

                case "مدارک":
                    //"نوع مدرک", "نام شخص"
                    string Id_Doc=null;
                    try
                    {
                        Id_Doc = Convert.ToString(DeleteDataGridView.CurrentRow.Cells["شناسه مدارک"].Value);
                   
                    }
                    catch
                    {

                    }
                    label207.Text = Id_Doc;
                    //MessageBox.Show(Id_Doc);
                    //MessageBox.Show(EditRequest["نام مجله"]);
                    string[] Id_Doc_A = { Id_Doc };
                    Document Document_Obj = new Document();
                    Document_Obj.SetDeleteDataGridView(DeleteDataGridView);
                    Message = Document_Obj.DeleteDocument(Id_Doc_A);
                    ShowingDataInDeleteDataGridView();

                    break;
                case "":
                    Message = "نوع محصول را انتخاب کنین";
                    break;
                case null:
                    Message = "نوع محصول را انتخاب کنین";
                    break;
            }

            if (Message[0] == '1')
            {
                ShowingDataInDeleteDataGridView();
                Message = " حذف با موفقیت انجام شد ";
            }
            else
            {
                Message = "حذف ناموفق بود";
            }

            label28.Text = Message;


         

        }

        private void search_Leave(object sender, EventArgs e)
        {
            foreach (Control c in search.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Text = "";
                if (c is ComboBox)
                    ((ComboBox)c).SelectedItem = "";
                if (c is RichTextBox)
                    ((RichTextBox)c).Text = "";
                if (c is MaskedTextBox)
                    ((MaskedTextBox)c).Text = "";
                if (c is CheckBox)
                    ((CheckBox)c).Checked = false;

            }
        }

        private void panel1_Leave(object sender, EventArgs e)
        {
            clearPanel(selectedAdvSearchLayerPanel);

        }


        private void removeObjectTab_Leave(object sender, EventArgs e)
        {
            clearPanel(selectedDeleteLayerPanel);
        }


        private void tabPage1_Leave(object sender, EventArgs e)
        {
            browseBackupTextBox.Text = "";
            backupFilePath = "";

        }

        private void tabPage2_Leave(object sender, EventArgs e)
        {
            browseRestoreTextBox.Text = "";
            restoreFilePath = "";
        }
        // void addCheckBoxToDataV
        void addCheckBoxToDataGridView(DataGridView dataGridView)
        {
            System.Windows.Forms.DataGridViewCheckBoxColumn markColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { markColumn });
            markColumn.HeaderText = "??????";
            markColumn.Name = "markColumn";

        }


        //******************************************************************************************************************************************************************//
        //                                                                      Inside Functions
        //******************************************************************************************************************************************************************//

        public string TypeOfSelected(string selected)
        {

            switch (selected)
            {
                case "layerAdvSearchVideoTapePanel" :
                    return "نوار ویدئویی";
                    break;
                case "layerAdvSearchAlbumPanel":
                    return "آلبوم عکس";
                    break;
                case "layerAdvSearchBookPanel":
                    return "کتاب";
                    break;
                case "LayerAdvSearchNewspaperPanel":
                    return "روزنامه";
                    break;
                case "layerAdvSearchMagazinePanel":
                    return "مجله";
                    break;
                case "layerAdvSearchPaperPanel":
                    return "مقاله";
                case "layerAdvSearchCDPanel":
                    return "لوح فشرده و نرم افزار";
                    break;
                case "layerAdvSearchCassettePanel":
                    return "کاست";
                    break;
                case "layerAdvSearchDocumentsPanel":
                    return "مدارک";
                    break;
                
                case "layerEditVideoTapePanel":
                    return "نوار ویدئویی";
                    break;
                case "layerEditAlbumPanel":
                    return "آلبوم عکس";
                    break;
                case "layerEditBookPanel":
                    return "کتاب";
                    break;
                case "layerEditNewspaperPanel":
                    return "روزنامه";
                    break;
                case "layerEditMagazinePanel":
                    return "مجله";
                    break;
                case "layerEditPaperPanel":
                    return "مقاله";
                    break;
                case "layerEditCDPanel":
                    return "لوح فشرده و نرم افزار";
                    break;
                case "layerEditCassettePanel":
                    return "کاست";
                    break;
                case "layerEditDocPanel":
                    return "مدارک";
                    break;

               case "layerAddVideoTapePanel":
                    return "نوار ویدئویی";
                    break;
                case "layerAddAlbumPanel":
                    return "آلبوم عکس";
                    break;
                case "layerAddBookPanel":
                    return "کتاب";
                    break;
                case "layerAddNewspaperPanel":
                    return "روزنامه";
                    break;
                case "layerAddMagazinePanel":
                    return "مجله";
                    break;
                case "layerAddPaperPanel":
                    return "مقاله";
                    break;
                case "layerAddCDPanel":
                    return "لوح فشرده و نرم افزار";
                    break;
                case "layerAddCassettePanel":
                    return "کاست";
                    break;
                case "layerAddDocumentsPanel":
                    return "مدارک";
                    break;

               case "layerDeleteVideoTapePanel":
                    return "نوار ویدئویی";
                    break;
                case "layerDeleteAlbumPanel":
                    return "آلبوم عکس";
                    break;
                case "layerDeleteBookPanel":
                    return "کتاب";
                    break;
                case "layerDeleteNewspaperPanel":
                    return "روزنامه";
                    break;
                case "layerDeleteMagazinePanel":
                    return "مجله";
                    break;
                case "layerDeletePaperPanel":
                    return "مقاله";
                    break;
                case "layerDeleteCDPanel":
                    return "لوح فشرده و نرم افزار";
                    break;
                case "layerDeleteCassettePanel":
                    return "کاست";
                    break;
                case "layerDeleteDocumentsPanel":
                    return "مدارک";
                    break;

                default:
                    break;              
                   
            }
        
            return "0 Error in LayerToType";

        }

        public string SimpleSearchInTheTable(string TableType)
        {
            string Message = "1 Successfully Shows in Viewing Table.";
            switch (TableType)                                                           //Showing Entire Table Process
            {
                case "کتاب":
                
                   Book Book_Obj = new Book();
                   Message = Book_Obj.SimpleBookSearch(null, null, null);
                   break;
                
                case "روزنامه":

                    break;

                case "مجله":
                    Magazine mag_Obj = new Magazine();
                    mag_Obj.SimpleMajaleSearch(null,null,null);
                    break;

                case "مقاله":

                    Paper Paper_Obj = new Paper();
                    Message = Paper_Obj.SimplePaperSearch(null, null, null);
                      
                    break;

                case "لوح فشرده و نرم افزار":

                    break;

                case "آلبوم عکس":
                    Gallery Gallery_Obj = new Gallery();
                     Message = Gallery_Obj.SimpleGallerySearch(null, null, null);
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
                    Message = Document_Obj.SimpleDocumentSearch(null, null, null);
   
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


        //******************************************************************************************************************************************************************//
        //                                                                      Inside Functions
        //******************************************************************************************************************************************************************//



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
        public string[] GainingIdFromViewingTable(string Id_Name)
        {

            //-----------------------------------------------------------------------------
            //                               Deffinition
            //-----------------------------------------------------------------------------
            string Message = "1 Successfull.";
            //-----------------------------------------------------------------------------
            //                Viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------
            //DataRow dr = new DataRow();
            List<string> Id_L = new List<string>();
            string[] Id=null;
            try
            {
                //dataGridView2.DataBindings.Clear();
                //CompleteSearchDataGrid.DataBindings.Clear();
                dts = new DataSet();
                string Query = "SELECT * FROM [محصولات فرهنگی خانگی].[dbo].[جدول نمایش]";
                connection = new SqlConnection(strCon);
                connection.Open();
                dts.Clear();
                sqlDA = new SqlDataAdapter(Query, connection);
                sqlDA.Fill(dts, "[جدول نمایش]");
                DataTable dt = new DataTable();
                dt = dts.Tables["[جدول نمایش]"];
                int RowsNumber=0;
                RowsNumber = dt.Rows.Count;
               // int ViewTableRow_Number = 0;

                //ViewTableRow_Number = dts.Tables["[جدول نمایش]"].Rows.Count;

                if (RowsNumber == 0)
                {

                    Message = "0 There is nothing found in Viewing Table";
                    return Id;
                }
                else
                {
                   // Message = "1 " + "مقدار یافت شد " + Convert.ToString(ViewTableRow_Number) + "جستجو با موفقیت انجام شد و ";
                    for(int i=0 ; i<RowsNumber ; i++)
                    {
                     //   dr = dts.Tables["[جدول نمایش]"].Rows;
                      //  Id_L.Add(dts.Tables["[جدول نمایش]"].Columns[Id_Name].ToString);
                    }
                }
                //int num=dts.Tables.Count;
                // CompleteSearchDataGrid.DataBindings.Add(new Binding("DataSource", dts, "[جدول نمایش]"));
                DeleteDataGridView.DataSource = dt;
                connection.Close();
            }
            catch
            {
                Message = "0 Problem with viewing data in SimpleSearchDataGrid";
            }

            //-----------------------------------------------------------------------------
            //   END Of      viewing [جدول نمایش] in SimpleSearchView
            //-----------------------------------------------------------------------------

            return Id;

        }

        private void confirmAdvSearchButton_Click(object sender, EventArgs e)
        {
            //Add
            string Type;
            Type = TypeOfSelected(selectedAdvSearchLayerPanel.Name);
            if (Type != null && Type != "" && Type != "انتخاب کنید")
            {
                string Message;

                SimpleSearchInTheTable(Type);

                Message = ShowingDataInCompleteSearchDataGridView();
                if (Message[0] == '1')
                {
                    validLabelPishrafte.Text = " بار شدن جدول " + Type;
                }
                else
                {
                    validLabelPishrafte.Text = "خطا در بار شدن";
                }
            }
            //-Add


            collectAdvancedSearchRequest();
           // collectAdvSearchCDRequest();
            //collectAddMagazineRequest();
           
            string message = "1 Successfully Shows in Viewing Table.";
            //ADDDD
            
            //messageBox.Show(Type);
            switch (Type)                                                           //Showing Entire Table Process
            {
                case "کتاب":

                    /*
                    Book Book_Obj = new Book();
                    message = Book_Obj.CompleteBookSearch;
                     */
                    break;

                case "روزنامه":

                    break;

                case "مجله":
                    string FavoriteDegree=comboBox22.Text;
                    string Number = textBox74.Text;
                    string Year = textBox72.Text;
                    string Moon = textBox71.Text;
                    string Title = textBox75.Text;
                    string Name = textBox76.Text;
                    if(FavoriteDegree == "" || FavoriteDegree == "انتخاب کنید")
                    {
                        FavoriteDegree = null;
                    }
                    // "درجه علاقه مندی", "ماه", "سال", "روز", "شماره", "موضوع", "نام مجله"
                    Magazine mag_Obj = new Magazine();
                    mag_Obj.CompleteMajaleSearch(Name,Title, Moon, Year , Number , FavoriteDegree);
                   
                    break;

                case "مقاله":
                    /*
                    Paper Paper_Obj = new Paper();
                    message = Paper_Obj.SimplePaperSearch(Name, Place, LoanStatus);
                     */
                    break;
                //layerAdvSearchCDPanel
                case "لوح فشرده و نرم افزار":
                    string[] Mohtava;
                    List<string> Mohtava_L = new List<string>();
                    CD cd_obj = new CD();
                    if (checkBox18.Checked)
                    {
                        Mohtava_L.Add("فیلم");
                    }
                    if (checkBox17.Checked)
                    {
                        Mohtava_L.Add("عکس");
                    }
                    if (checkBox16.Checked)
                    {
                        Mohtava_L.Add("موسیقی");
                    }
                    if (checkBox15.Checked)
                    {
                        Mohtava_L.Add("فایل متنی");
                    }
                    if (checkBox14.Checked)
                    {
                        Mohtava_L.Add("نرم افزار");
                    }
                    if (checkBox13.Checked)
                    {
                        Mohtava_L.Add("سایر");
                    }
                    Mohtava = Mohtava_L.ToArray();

                    // "قیمت", "نام", "درجه علاقه مندی"
                    cd_obj.CompleteCDSearch(AdvancedSearchRequest["نام"], Mohtava, AdvancedSearchRequest["قیمت"], AdvancedSearchRequest["درجه علاقه مندی"]);
                    break;

                case "آلبوم عکس":
                    /*
                    Gallery Gallery_Obj = new Gallery();
                    message = Gallery_Obj.SimpleGallerySearch(Name, Place, LoanStatus);
                    // messageBox.Show(message);
                     */
                    break;

                case "کاست":
                    /*  Cossette Cossette_Obj = new Cossette();
                      message = Cossette_Obj.SimpleCossetteSearch(Name, Place, LoanStatus);
                      */
                    break;

                case "نوار ویدئویی":
                    /* Video Video_Obj = new Video();
                     message = Video_Obj.SimplevideoSearch(Name, Place, LoanStatus));
                   */
                    break;

                case "مدارک":
                    //"نوع مدرک", "نام شخص"
                    
                    Document Document_Obj = new Document();
                    message = Document_Obj.CompleteDocumentSearch(AdvancedSearchRequest["نام شخص"], AdvancedSearchRequest["نوع مدرک"]);
                    ShowingDataInCompleteSearchDataGridView();
                    break;
                case "":
                    message = "نوع محصول را انتخاب کنین";
                    break;
                case null:
                    message = "نوع محصول را انتخاب کنین";
                    break;
            }

            if (message[0] == '1')
            {
                ShowingDataInCompleteSearchDataGridView();
                message = " جستجو با موفقیت انجام شد ";
            }
            else
            {
                message = "جستجو ناموفق بود";
            }

            validLabelPishrafte.Text = message;
            
            //Add

        }

        private void editItemButton_Click(object sender, EventArgs e)
        {
            collectEditRequest();

            //string Mahsoual_Type = AdvancedSearchRequest["نوع محصول"];

            string Message = "1";
            //ADDDD
            String Type;
            Type = TypeOfSelected(selectedEditLayerPanel.Name);

            //MessageBox.Show(type);
            switch (Type)                                                           //Showing Entire Table Process
            {
                case "کتاب":

                    /*
                    Book Book_Obj = new Book();
                    Message = Book_Obj.CompleteBookSearch;
                     */
                    break;

                case "روزنامه":

                    break;

                case "مجله":
                    // "درجه علاقه مندی", "ماه", "سال", "روز", "شماره", "موضوع", "نام مجله"
                    string LoanStatus = comboBox33.Text;
                    Magazine mag_obj = new Magazine();

                    string Id = null;
                    try
                    {
                        Id = Convert.ToString(CompleteSearchDataGridView.CurrentRow.Cells["شناسه مجله"].Value);

                    }
                    catch
                    {

                    }
                    label207.Text = Id;
                    //MessageBox.Show(Id);
                    //MessageBox.Show(EditRequest["نام مجله"]);
                    mag_obj.SetEditDataGridView(CompleteSearchDataGridView);
                    mag_obj.EditMajale(AddRequest["نام مجله"], AddRequest["موضوع"], AddRequest["سال"], AddRequest["ماه"], AddRequest["شماره"], null, AddRequest["درجه علاقه مندی"], null, null, Id);
                    mag_obj.EditLoanMajale(Id, null, null, Id, null, LoanStatus);
                    //mag_obj.EditMajale(EditRequest["نام مجله"], EditRequest["موضوع"], null, null, null, null, null, null, null, Id);
                    break;

                case "مقاله":
                    /*
                    Paper Paper_Obj = new Paper();
                    Message = Paper_Obj.SimplePaperSearch(Name, Place, LoanStatus);
                     */
                    break;

                case "layerAdvSearchCDPanel":
                    string[] Mohtava;
                    List<string> Mohtava_L = new List<string>();
                    CD cd_obj = new CD();
                    if (checkBox18.Checked)
                    {
                        Mohtava_L.Add("فیلم");
                    }
                    if (checkBox17.Checked)
                    {
                        Mohtava_L.Add("عکس");
                    }
                    if (checkBox16.Checked)
                    {
                        Mohtava_L.Add("موسیقی");
                    }
                    if (checkBox15.Checked)
                    {
                        Mohtava_L.Add("فایل متنی");
                    }
                    if (checkBox14.Checked)
                    {
                        Mohtava_L.Add("نرم افزار");
                    }
                    if (checkBox13.Checked)
                    {
                        Mohtava_L.Add("سایر");
                    }
                    Mohtava = Mohtava_L.ToArray();

                    // "قیمت", "نام", "درجه علاقه مندی"
                    cd_obj.CompleteCDSearch(AdvancedSearchRequest["نام"], Mohtava, AdvancedSearchRequest["قیمت"], AdvancedSearchRequest["درجه علاقه مندی"]);
                    break;

                case "آلبوم عکس":
                    /*
                    Gallery Gallery_Obj = new Gallery();
                    Message = Gallery_Obj.SimpleGallerySearch(Name, Place, LoanStatus);
                    // MessageBox.Show(Message);
                     */
                    break;

                case "کاست":
                    /*  Cossette Cossette_Obj = new Cossette();
                      Message = Cossette_Obj.SimpleCossetteSearch(Name, Place, LoanStatus);
                      */
                    break;

                case "نوار ویدئویی":
                    /* Video Video_Obj = new Video();
                     Message = Video_Obj.SimplevideoSearch(Name, Place, LoanStatus));
                   */
                    break;

                case "مدارک":
                    //"نوع مدرک", "نام شخص"
                    string LoanStatus_Doc = comboBox33.Text;
                    Document Doc_Obj = new Document();

                    string Id_Doc = null;
                    try
                    {
                        Id_Doc = Convert.ToString(CompleteSearchDataGridView.CurrentRow.Cells["شناسه مدارک"].Value);

                    }
                    catch
                    {

                    }
                    validLabelPishrafte.Text = Id_Doc;
                    //MessageBox.Show(Id_Doc);
                    //MessageBox.Show(EditRequest["نام مجله"]);
                    Doc_Obj.SetEditDataGridView(CompleteSearchDataGridView);
                    Doc_Obj.EditDocument(AddRequest["نام شخص"], AddRequest["نوع مدرک"], AddRequest["مکان فیزیکی محصول"], AddRequest["توضیحات"], Id_Doc);
                    Doc_Obj.EditLoanDocument(Id_Doc, null, null, Id_Doc, null, LoanStatus_Doc);

                    break;
                case "":
                    Message = "نوع محصول را انتخاب کنین";
                    break;
                case null:
                    Message = "نوع محصول را انتخاب کنین";
                    break;
            }

      
            if(Message[0]=='1')
            {

                ShowingDataInCompleteSearchDataGridView();
                Message=" ویرایش با موفقیت انجام شد ";
            }
            else
            {
                Message = "ویرایش ناموفق بود";
            }
            validLabelPishrafte.Text = Message;
            // ShowingDataInCompleteSearchDataGridView();
            
        

        }

        private void button3_Click(object sender, EventArgs e)
        {
             collectEditRequest();

            //string Mahsoual_Type = AdvancedSearchRequest["نوع محصول"];

            string Message = "1" ;
 //ADDDD
            String Type;
            Type = TypeOfSelected(selectedEditLayerPanel.Name);

            //MessageBox.Show(type);
            switch (Type)                                                           //Showing Entire Table Process
            {
                case "کتاب":

                    /*
                    Book Book_Obj = new Book();
                    Message = Book_Obj.CompleteBookSearch;
                     */
                    break;

                case "روزنامه":

                    break;

                case "مجله":
                    // "درجه علاقه مندی", "ماه", "سال", "روز", "شماره", "موضوع", "نام مجله"
                   string LoanStatus= comboBox33.Text;
                    Magazine mag_obj=new Magazine();
                   
                    string Id=null;
                   try
                   {
                       Id = Convert.ToString(EditDataGridView.CurrentRow.Cells["شناسه مجله"].Value);
                   
                   }
                    catch
                   {

                   }
                    label207.Text = Id;
                    //MessageBox.Show(Id);
                    //MessageBox.Show(EditRequest["نام مجله"]);
                    mag_obj.SetEditDataGridView(EditDataGridView);
                    mag_obj.EditMajale(EditRequest["نام مجله"], EditRequest["موضوع"], EditRequest["سال"], EditRequest["ماه"], EditRequest["شماره"], null, EditRequest["درجه علاقه مندی"], null, null, Id);
                   mag_obj.EditLoanMajale(Id,null,null,Id,null,LoanStatus);
                //mag_obj.EditMajale(EditRequest["نام مجله"], EditRequest["موضوع"], null, null, null, null, null, null, null, Id);
                    break;

                case "مقاله":
                    /*
                    Paper Paper_Obj = new Paper();
                    Message = Paper_Obj.SimplePaperSearch(Name, Place, LoanStatus);
                     */
                    break;

                case "layerAdvSearchCDPanel":
                    string[] Mohtava;
                    List<string> Mohtava_L = new List<string>();
                    CD cd_obj = new CD();
                    if (checkBox18.Checked)
                    {
                        Mohtava_L.Add("فیلم");
                    }
                    if (checkBox17.Checked)
                    {
                        Mohtava_L.Add("عکس");
                    }
                    if (checkBox16.Checked)
                    {
                        Mohtava_L.Add("موسیقی");
                    }
                    if (checkBox15.Checked)
                    {
                        Mohtava_L.Add("فایل متنی");
                    }
                    if (checkBox14.Checked)
                    {
                        Mohtava_L.Add("نرم افزار");
                    }
                    if (checkBox13.Checked)
                    {
                        Mohtava_L.Add("سایر");
                    }
                    Mohtava = Mohtava_L.ToArray();

                    // "قیمت", "نام", "درجه علاقه مندی"
                    cd_obj.CompleteCDSearch(AdvancedSearchRequest["نام"], Mohtava, AdvancedSearchRequest["قیمت"], AdvancedSearchRequest["درجه علاقه مندی"]);
                    break;

                case "آلبوم عکس":
                    /*
                    Gallery Gallery_Obj = new Gallery();
                    Message = Gallery_Obj.SimpleGallerySearch(Name, Place, LoanStatus);
                    // MessageBox.Show(Message);
                     */
                    break;

                case "کاست":
                    /*  Cossette Cossette_Obj = new Cossette();
                      Message = Cossette_Obj.SimpleCossetteSearch(Name, Place, LoanStatus);
                      */
                    break;

                case "نوار ویدئویی":
                    /* Video Video_Obj = new Video();
                     Message = Video_Obj.SimplevideoSearch(Name, Place, LoanStatus));
                   */
                    break;

                case "مدارک":
                    //"نوع مدرک", "نام شخص"
                    string LoanStatus_Doc= comboBox33.Text;
                    Document Doc_Obj = new Document();
                   
                    string Id_Doc=null;
                   try
                   {
                       Id_Doc = Convert.ToString(EditDataGridView.CurrentRow.Cells["شناسه مدارک"].Value);
                   
                   }
                    catch
                   {

                   }
                    label207.Text = Id_Doc;
                    //MessageBox.Show(Id_Doc);
                    //MessageBox.Show(EditRequest["نام مجله"]);
                    Doc_Obj.SetEditDataGridView(EditDataGridView);
                    Doc_Obj.EditDocument(EditRequest["نام شخص"], EditRequest["نوع مدرک"], EditRequest["مکان فیزیکی محصول"], EditRequest["توضیحات"], Id_Doc);
                    Doc_Obj.EditLoanDocument(Id_Doc,null,null,Id_Doc,null,LoanStatus_Doc);
                
                    break;
                case "":
                    Message = "نوع محصول را انتخاب کنین";
                    break;
                case null:
                    Message = "نوع محصول را انتخاب کنین";
                    break;
            }

            if(Message[0]=='1')
            {

                ShowingDataInEditDataGridView();
                Message=" ویرایش با موفقیت انجام شد ";
            }
            else
            {
                Message = "ویرایش ناموفق بود";
            }
            label207.Text = Message;
            // ShowingDataInCompleteSearchDataGridView();
            
        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {


            collectDeleteRequest();
            showDictionary(DeleteRequest);
            string Type;
            Type = TypeOfSelected(selectedDeleteLayerPanel.Name);
            string Message = "1 Successfully Deleted.";
            // MessageBox.Show(Type);

            switch (Type)                                                           //Showing Entire Table Process
            {
                case "کتاب":

                    /*
                    Book Book_Obj = new Book();
                    Message = Book_Obj.CompleteBookSearch;
                     */
                    break;

                case "روزنامه":

                    break;

                case "مجله":
                    // "درجه علاقه مندی", "ماه", "سال", "روز", "شماره", "موضوع", "نام مجله"

                    Magazine mag_obj = new Magazine();

                    string Id_Mag = Convert.ToString(CompleteSearchDataGridView.CurrentRow.Cells["شناسه مجله"].Value);
                    validLabelPishrafte.Text = Id_Mag;
                    //MessageBox.Show(Id);
                    //MessageBox.Show(EditRequest["نام مجله"]);
                    string[] Id_Mag_A = { Id_Mag };
                    mag_obj.SetDeleteDataGridView(CompleteSearchDataGridView);
                    mag_obj.DeleteMajale(Id_Mag_A);
                    ShowingDataInCompleteSearchDataGridView();
                    break;

                case "مقاله":
                    /*
                    Paper Paper_Obj = new Paper();
                    Message = Paper_Obj.SimplePaperSearch(Name, Place, LoanStatus);
                     */
                    break;

                case "لوح فشرده و نرم افزار":
                    string[] Mohtava;
                    List<string> Mohtava_L = new List<string>();
                    CD cd_obj = new CD();
                    if (checkBox6.Checked)
                    {
                        Mohtava_L.Add("فیلم");
                    }
                    if (checkBox5.Checked)
                    {
                        Mohtava_L.Add("عکس");
                    }
                    if (checkBox4.Checked)
                    {
                        Mohtava_L.Add("موسیقی");
                    }
                    if (checkBox3.Checked)
                    {
                        Mohtava_L.Add("فایل متنی");
                    }
                    if (checkBox2.Checked)
                    {
                        Mohtava_L.Add("نرم افزار");
                    }
                    if (checkBox1.Checked)
                    {
                        Mohtava_L.Add("سایر");
                    }
                    Mohtava = Mohtava_L.ToArray();

                    // "قیمت", "نام", "درجه علاقه مندی"
                    cd_obj.CompleteCDSearch(AdvancedSearchRequest["نام"], Mohtava, AdvancedSearchRequest["قیمت"], AdvancedSearchRequest["درجه علاقه مندی"]);
                    break;

                case "آلبوم عکس":
                    /*
                    Gallery Gallery_Obj = new Gallery();
                    Message = Gallery_Obj.SimpleGallerySearch(Name, Place, LoanStatus);
                    // MessageBox.Show(Message);
                     */
                    break;

                case "کاست":
                    /*  Cossette Cossette_Obj = new Cossette();
                      Message = Cossette_Obj.SimpleCossetteSearch(Name, Place, LoanStatus);
                      */
                    break;

                case "نوار ویدئویی":
                    /* Video Video_Obj = new Video();
                     Message = Video_Obj.SimplevideoSearch(Name, Place, LoanStatus));
                   */
                    break;

                case "مدارک":
                    //"نوع مدرک", "نام شخص"
                    string Id_Doc = null;
                    try
                    {
                        Id_Doc = Convert.ToString(CompleteSearchDataGridView.CurrentRow.Cells["شناسه مدارک"].Value);

                    }
                    catch
                    {

                    }
                    validLabelPishrafte.Text = Id_Doc;
                    //MessageBox.Show(Id_Doc);
                    //MessageBox.Show(EditRequest["نام مجله"]);
                    string[] Id_Doc_A = { Id_Doc };
                    Document Document_Obj = new Document();
                    Document_Obj.SetDeleteDataGridView(CompleteSearchDataGridView);
                    Message = Document_Obj.DeleteDocument(Id_Doc_A);
                    ShowingDataInCompleteSearchDataGridView();

                    break;
                case "":
                    Message = "نوع محصول را انتخاب کنین";
                    break;
                case null:
                    Message = "نوع محصول را انتخاب کنین";
                    break;
            }

            if (Message[0] == '1')
            {
                ShowingDataInCompleteSearchDataGridView();
                Message = " حذف با موفقیت انجام شد ";
            }
            else
            {
                Message = "حذف ناموفق بود";
            }

            validLabelPishrafte.Text = Message;


         


        }

        private void simpleSearchObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CompleteSearchDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void validSearch_Click(object sender, EventArgs e)
        {

        }

        private void editPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteDataGridView.Visible = true;
            label29.Visible = true;
            label28.Visible = true;
            //Add
            string Type;
            Type = TypeOfSelected(selectedDeleteLayerPanel.Name);
            //MessageBox.Show(Type);
            if (Type != null && Type != "" && Type != "انتخاب کنید")
            {
                string Message;

                SimpleSearchInTheTable(Type);

                Message = ShowingDataInDeleteDataGridView();
                if (Message[0] == '1')
                {
                    label28.Text = " بار شدن جدول " + Type;
                }
                else
                {
                    label28.Text = "خطا در بار شدن";
                }
            }
            //-Add

        }

    }

}
