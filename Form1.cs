using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing.Imaging;
using System.Data.OleDb;
namespace BinaryFormReader
{
	///	<summary>
	///	Summary	description	for	MainForm.
	///	</summary>
	public class MainForm : System.Windows.Forms.Form
	{
		#region OLEDB Variables
		OleDbCommandBuilder cmdBuilder;
		OleDbCommand command;
		OleDbConnection conn;
		OleDbDataAdapter da;
		DataSet ds;
		OleDbCommandBuilder cmdBuilder2;
		
		OleDbDataAdapter da2;
		public DataSet ds2;
		#endregion
		#region Variables

		DisplayForm	frmDisplayForm;
		int formCounter;
		int nAzmunCounter;
		int nStudentCounter;
		public bool	[,]FinalResults;
		public bool	[,]TempResults;
		bool bReadColorized;
		bool bTestOmit;
		bool bAzmunNumber;
		bool bTeacherNumber;
		bool bStudentNumber;
		int nDarkPointThr;
		byte [,]pixeles;	
		int	[,]arrDistance;
		int		[,]startPoints;
		int	cellSize;
		int	pageSize;
		float cellPad;
		int		startX;
		int	[,]Results;
		string strFinalResults;
		string strTempResults;
		string	StudentCode;
		Bitmap	bmp;
		string	dirPath;
		int	bmpWidth;
		int	bmpHeight;
		public Color boundColor;
		IntPtr rgbPtr;

		int	nNumberOfLeftLayout;
		int	nNumberOfTopLayout;

		int	nNumber1Col;
		int	nNumber1Row;
		int	nNumber1Digits;
		int	nNumber2Digits;
		int	nNumber2Row;
		int	nNumber2Col;
		int	nNumber3Row;
		int	nNumber3Col;
		int	nNumber4Row;
		int	nNumber4Col;
		int	nNumber5Row;
		int	nNumber5Col;
		int	nNumber2Cases;
		int	nNumber3Digits;
		int	nNumber4Digits;
		int	nNumber5Digits;
		int	nNumber1Cases;
		int	nNumber3Cases;
		int	nNumber4Cases;
		int	nNumber5Cases;
		int	nNumberColDistance;
		int	nNumberClassDistance;
		int	nNumberHorDistance;
		int	nNumberVerDistance;
		int	nNumberFirstCol;
		int	nNumberFirstRow;
		int	nNumberCasesNumber;
		int	nNumberQuestionNumber;
		int	nNumberclassNumber;
		int	nNumberColNumber;
		int	nNumberStudentNumber;
		int	nNumberAzmunNumber;
		//int	nNumberColQuestionNumber;
		int	nNumberTeacherNumber;
		int nNumberOfTotalQuestions;
		string strOutputPath;	
		string str1VarName;
		string str2VarName;
		string str3VarName;
		string str4VarName;
		string str5VarName;				
		string strVar1Code;
		string strVar2Code;
		string strVar3Code;
		string strVar4Code;
		string strVar5Code;	
		//bool STEPlikeDir;
		bool QuestionsDir;
		bool CasesDir;
		private	System.Windows.Forms.MainMenu mainMenu1;
		private	System.Windows.Forms.MenuItem menuItem1;
		private	System.Windows.Forms.MenuItem menuItem2;
		private	System.Windows.Forms.MenuItem menuItem3;
		private	System.Windows.Forms.MenuItem menuItem4;
		private	System.Windows.Forms.MenuItem menuItem5;
		private	System.Windows.Forms.MenuItem menuItem6;
		///	<summary>
		///	Required designer variable.
		///	</summary>
		private	System.Windows.Forms.TabControl	tabControl1;
		private	System.Windows.Forms.Label label1;
		private	System.Windows.Forms.Label label2;
		private	System.Windows.Forms.GroupBox groupBox2;
		private	System.Windows.Forms.GroupBox groupBox15;
		private	System.Windows.Forms.GroupBox groupBox5;
		private	System.Windows.Forms.PictureBox	pictureBox6;
		private	System.Windows.Forms.PictureBox	pictureBox9;
		private	System.Windows.Forms.GroupBox groupBox6;
		private	System.Windows.Forms.PictureBox	pictureBox8;
		private	System.Windows.Forms.PictureBox	pictureBox7;
		private	System.Windows.Forms.Label label7;
		private	System.Windows.Forms.RadioButton radioStudent;
		private	System.Windows.Forms.RadioButton radioTeacher;
		private	System.Windows.Forms.RadioButton radioTestOmit;
		private	System.Windows.Forms.RadioButton radioTest;
		private	System.Windows.Forms.GroupBox groupBox8;
		private	System.Windows.Forms.GroupBox groupBox9;
		private	System.Windows.Forms.GroupBox groupBox10;
		private	System.Windows.Forms.GroupBox groupBox11;
		private	System.Windows.Forms.GroupBox groupBox12;
		private	System.Windows.Forms.GroupBox groupBox13;
		private	System.Windows.Forms.Label label9;
		private	System.Windows.Forms.Label label10;
		private	System.Windows.Forms.Label label8;
		private	System.Windows.Forms.Label label11;
		private	System.Windows.Forms.Label label12;
		private	System.Windows.Forms.Label label13;
		private	System.Windows.Forms.Label label14;
		private	System.Windows.Forms.Label label15;
		private	System.Windows.Forms.Label label16;
		private	System.Windows.Forms.Label label17;
		private	System.Windows.Forms.Label label18;
		private	System.Windows.Forms.Label label19;
		private	System.Windows.Forms.Label label20;
		private	System.Windows.Forms.Label label21;
		private	System.Windows.Forms.Label label22;
		private	System.Windows.Forms.Label label23;
		private	System.Windows.Forms.Label label24;
		private	System.Windows.Forms.Label label25;
		private	System.Windows.Forms.Label label26;
		private	System.Windows.Forms.Label label27;
		private	System.Windows.Forms.Label label28;
		private	System.Windows.Forms.Label label29;
		private	System.Windows.Forms.Label label30;
		private	System.Windows.Forms.Label label31;
		private	System.Windows.Forms.Label label32;
		private	System.Windows.Forms.TextBox txt1Col;
		private	System.Windows.Forms.TextBox txt1Row;
		private	System.Windows.Forms.TextBox txt1Digits;
		private	System.Windows.Forms.TextBox txt2Digits;
		private	System.Windows.Forms.TextBox txt2Row;
		private	System.Windows.Forms.TextBox txt2Col;
		private	System.Windows.Forms.TextBox txt3Row;
		private	System.Windows.Forms.TextBox txt3Col;
		private	System.Windows.Forms.TextBox txt4Row;
		private	System.Windows.Forms.TextBox txt4Col;
		private	System.Windows.Forms.TextBox txt5Row;
		private	System.Windows.Forms.TextBox txt5Col;
		private	System.Windows.Forms.TextBox txt2Cases;
		private	System.Windows.Forms.TextBox txt3Digits;
		private	System.Windows.Forms.TextBox txt4Digits;
		private	System.Windows.Forms.TextBox txt5Digits;
		private	System.Windows.Forms.TextBox txt1Cases;
		private	System.Windows.Forms.TextBox txt3Cases;
		private	System.Windows.Forms.TextBox txt4Cases;
		private	System.Windows.Forms.TextBox txt5Cases;
		private	System.Windows.Forms.TextBox txt1VarName;
		private	System.Windows.Forms.TextBox txt2VarName;
		private	System.Windows.Forms.TextBox txt3VarName;
		private	System.Windows.Forms.TextBox txt4VarName;
		private	System.Windows.Forms.TextBox txt5VarName;
		private	System.Windows.Forms.GroupBox groupBox14;
		private	System.Windows.Forms.Label label33;
		
		private	System.Windows.Forms.GroupBox groupBox16;
		private	System.Windows.Forms.Label label34;
		private	System.Windows.Forms.Label label35;
		private	System.Windows.Forms.Label label36;
		private	System.Windows.Forms.Label label37;
		private	System.Windows.Forms.Label label38;
		private	System.Windows.Forms.Label label39;
		private	System.Windows.Forms.Label label40;
		private	System.Windows.Forms.Label label41;
		private	System.Windows.Forms.Label label42;
		private	System.Windows.Forms.Label label43;
		private	System.Windows.Forms.Label label44;
		private	System.Windows.Forms.Label label45;
		private	System.Windows.Forms.PictureBox	pictureBox1;
		private	System.Windows.Forms.PictureBox	pictureBox11;
		private	System.Windows.Forms.PictureBox	pictureBox14;
		private	System.Windows.Forms.PictureBox	pictureBox15;
		private	System.Windows.Forms.PictureBox	picTick;
		private	System.Windows.Forms.RadioButton radioNCSFormat;
		private	System.Windows.Forms.RadioButton radioKonkurSim;
		private	System.Windows.Forms.RadioButton radioPatoNik;
		private	System.Windows.Forms.RadioButton radioRazmane;
		private	System.Windows.Forms.RadioButton radioSTD;
		private	System.Windows.Forms.TextBox txtStudentNumber;
		private	System.Windows.Forms.Label lblAzmunNumber;
		private	System.Windows.Forms.TextBox txtAzmunNumber;
		private	System.Windows.Forms.Label lblTeacherNumber;
		private	System.Windows.Forms.TextBox txtTeacherNumber;
		private	System.Windows.Forms.Label lblStudentNumber;
		private	System.Windows.Forms.TextBox txtPath;
		private	System.Windows.Forms.RadioButton radioSaveInFile;
		private	System.Windows.Forms.RadioButton radioColInRecord;
		private	System.Windows.Forms.RadioButton radioComposite;
		private	System.Windows.Forms.Label lblSence;
		private	System.Windows.Forms.TrackBar trkSence;
		private	System.Windows.Forms.ComboBox comboreadMethod;
		private	System.Windows.Forms.PictureBox	picPathButton;
		private	System.Windows.Forms.PictureBox	pictSaveInFile;
		private	System.Windows.Forms.PictureBox	picColInRecord;
		private	System.Windows.Forms.PictureBox	picComposite;
		private	System.Windows.Forms.GroupBox groupPath;
		private	System.Windows.Forms.GroupBox groupUotputFormat;
		private	System.Windows.Forms.GroupBox groupSavingMethod;
		private	System.Windows.Forms.GroupBox groupReadMethod;
		private	System.Windows.Forms.RadioButton radioCRightToLeft;
		private	System.Windows.Forms.RadioButton radioCLeftToRight;
		private	System.Windows.Forms.RadioButton radioQRightToLeft;
		private	System.Windows.Forms.RadioButton radioQLeftToRight;
		private	System.Windows.Forms.TextBox txtColDistance;
		private	System.Windows.Forms.TextBox txtClassDistance;
		private	System.Windows.Forms.TextBox txtHorDistance;
		private	System.Windows.Forms.TextBox txtVerDistance;
		private	System.Windows.Forms.TextBox txtFirstCol;
		private	System.Windows.Forms.TextBox txtFirstRow;
		private	System.Windows.Forms.TextBox txtCasesNumber;
		private	System.Windows.Forms.TextBox txtQuestionNumber;
		private	System.Windows.Forms.TextBox txtclassNumber;
		private	System.Windows.Forms.TextBox txtColNumber;
		private	System.Windows.Forms.Label lblColorSence;
		private	System.Windows.Forms.TextBox txtTopLayoutNumber;
		private	System.Windows.Forms.TextBox txtLeftLayoutNumber;
		private	System.Windows.Forms.Label label3;
		private	System.Windows.Forms.Label label4;
		private	System.Windows.Forms.TabPage pageReadMethodSettings;
		private	System.Windows.Forms.TabPage pageCodeSettings;
		private	System.Windows.Forms.TabPage pageTestSettings;
		private	System.Windows.Forms.TabPage pageView;
		private	System.Windows.Forms.Button	button1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNumberOfTotalQuestions;
		private System.Windows.Forms.Label lblThr;
		private System.Windows.Forms.TrackBar trkThr;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Button btnSaveTemplate;
		private System.Windows.Forms.TextBox txtFormName;
		private System.Windows.Forms.ComboBox comboFormName;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGrid dataGrid;
		private System.Windows.Forms.MenuItem menuItemDelete;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.PictureBox picSelect1;
		private System.Windows.Forms.Label lblDarkPointThr;
		private	System.ComponentModel.Container	components;
		#endregion
		public MainForm()
		{
			//
			// Required	for	Windows	Form Designer support
			//
			components=null;
			InitializeComponent();
			boundColor = Color.Empty;
			//
			// TODO: Add any constructor code after	InitializeComponent	call
			//
		}

		///	<summary>
		///	Clean up any resources being used.
		///	</summary>
		protected override void	Dispose( bool disposing	)
		{
			if(	disposing )
			{
				if (components != null)	
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing	);
		}

		#region	Windows	Form Designer generated	code
		///	<summary>
		///	Required method	for	Designer support - do not modify
		///	the	contents of	this method	with the code editor.
		///	</summary>
		private	void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItemDelete = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.pageReadMethodSettings = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupPath = new System.Windows.Forms.GroupBox();
			this.picPathButton = new System.Windows.Forms.PictureBox();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.groupUotputFormat = new System.Windows.Forms.GroupBox();
			this.picTick = new System.Windows.Forms.PictureBox();
			this.radioRazmane = new System.Windows.Forms.RadioButton();
			this.radioSTD = new System.Windows.Forms.RadioButton();
			this.radioPatoNik = new System.Windows.Forms.RadioButton();
			this.radioKonkurSim = new System.Windows.Forms.RadioButton();
			this.radioNCSFormat = new System.Windows.Forms.RadioButton();
			this.groupSavingMethod = new System.Windows.Forms.GroupBox();
			this.pictSaveInFile = new System.Windows.Forms.PictureBox();
			this.picColInRecord = new System.Windows.Forms.PictureBox();
			this.picComposite = new System.Windows.Forms.PictureBox();
			this.radioSaveInFile = new System.Windows.Forms.RadioButton();
			this.radioColInRecord = new System.Windows.Forms.RadioButton();
			this.radioComposite = new System.Windows.Forms.RadioButton();
			this.groupReadMethod = new System.Windows.Forms.GroupBox();
			this.lblThr = new System.Windows.Forms.Label();
			this.trkThr = new System.Windows.Forms.TrackBar();
			this.lblColorSence = new System.Windows.Forms.Label();
			this.lblSence = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.trkSence = new System.Windows.Forms.TrackBar();
			this.comboreadMethod = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblDarkPointThr = new System.Windows.Forms.Label();
			this.pageTestSettings = new System.Windows.Forms.TabPage();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.txtFormName = new System.Windows.Forms.TextBox();
			this.btnSaveTemplate = new System.Windows.Forms.Button();
			this.comboFormName = new System.Windows.Forms.ComboBox();
			this.label46 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.label35 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.groupBox16 = new System.Windows.Forms.GroupBox();
			this.pictureBox14 = new System.Windows.Forms.PictureBox();
			this.radioCRightToLeft = new System.Windows.Forms.RadioButton();
			this.radioCLeftToRight = new System.Windows.Forms.RadioButton();
			this.pictureBox15 = new System.Windows.Forms.PictureBox();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.pictureBox11 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.radioQRightToLeft = new System.Windows.Forms.RadioButton();
			this.radioQLeftToRight = new System.Windows.Forms.RadioButton();
			this.label33 = new System.Windows.Forms.Label();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.txtNumberOfTotalQuestions = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtTopLayoutNumber = new System.Windows.Forms.TextBox();
			this.txtLeftLayoutNumber = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtColDistance = new System.Windows.Forms.TextBox();
			this.txtClassDistance = new System.Windows.Forms.TextBox();
			this.txtHorDistance = new System.Windows.Forms.TextBox();
			this.txtVerDistance = new System.Windows.Forms.TextBox();
			this.txtFirstCol = new System.Windows.Forms.TextBox();
			this.txtFirstRow = new System.Windows.Forms.TextBox();
			this.txtCasesNumber = new System.Windows.Forms.TextBox();
			this.txtQuestionNumber = new System.Windows.Forms.TextBox();
			this.txtclassNumber = new System.Windows.Forms.TextBox();
			this.txtColNumber = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.txt5VarName = new System.Windows.Forms.TextBox();
			this.txt5Digits = new System.Windows.Forms.TextBox();
			this.txt5Cases = new System.Windows.Forms.TextBox();
			this.txt5Row = new System.Windows.Forms.TextBox();
			this.txt5Col = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.txt4VarName = new System.Windows.Forms.TextBox();
			this.txt4Digits = new System.Windows.Forms.TextBox();
			this.txt4Cases = new System.Windows.Forms.TextBox();
			this.txt4Row = new System.Windows.Forms.TextBox();
			this.txt4Col = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.txt3VarName = new System.Windows.Forms.TextBox();
			this.txt3Digits = new System.Windows.Forms.TextBox();
			this.txt3Cases = new System.Windows.Forms.TextBox();
			this.txt3Row = new System.Windows.Forms.TextBox();
			this.txt3Col = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.txt2VarName = new System.Windows.Forms.TextBox();
			this.txt2Digits = new System.Windows.Forms.TextBox();
			this.txt2Cases = new System.Windows.Forms.TextBox();
			this.txt2Row = new System.Windows.Forms.TextBox();
			this.txt2Col = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.txt1VarName = new System.Windows.Forms.TextBox();
			this.txt1Digits = new System.Windows.Forms.TextBox();
			this.txt1Cases = new System.Windows.Forms.TextBox();
			this.txt1Row = new System.Windows.Forms.TextBox();
			this.txt1Col = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.pageCodeSettings = new System.Windows.Forms.TabPage();
			this.picSelect1 = new System.Windows.Forms.PictureBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.pictureBox8 = new System.Windows.Forms.PictureBox();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.radioTestOmit = new System.Windows.Forms.RadioButton();
			this.lblAzmunNumber = new System.Windows.Forms.Label();
			this.radioTest = new System.Windows.Forms.RadioButton();
			this.txtAzmunNumber = new System.Windows.Forms.TextBox();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.lblTeacherNumber = new System.Windows.Forms.Label();
			this.txtTeacherNumber = new System.Windows.Forms.TextBox();
			this.radioTeacher = new System.Windows.Forms.RadioButton();
			this.lblStudentNumber = new System.Windows.Forms.Label();
			this.txtStudentNumber = new System.Windows.Forms.TextBox();
			this.radioStudent = new System.Windows.Forms.RadioButton();
			this.pageView = new System.Windows.Forms.TabPage();
			this.button4 = new System.Windows.Forms.Button();
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.tabControl1.SuspendLayout();
			this.pageReadMethodSettings.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupPath.SuspendLayout();
			this.groupUotputFormat.SuspendLayout();
			this.groupSavingMethod.SuspendLayout();
			this.groupReadMethod.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkThr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkSence)).BeginInit();
			this.pageTestSettings.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox16.SuspendLayout();
			this.groupBox15.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.pageCodeSettings.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.pageView.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem1});
			this.mainMenu1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem6,
																					  this.menuItemDelete});
			this.menuItem5.Text = "& ‰ŸÌ„« ";
			// 
			// menuItem6
			// 
			this.menuItem6.Checked = true;
			this.menuItem6.Index = 0;
			this.menuItem6.Text = "’«› ò—œ‰ ⁄ò”";
			this.menuItem6.Click += new System.EventHandler(this.menuItemX_Click);
			// 
			// menuItemDelete
			// 
			this.menuItemDelete.Index = 1;
			this.menuItemDelete.Text = "&Õ–› ‰ «ÌÃ ﬁ»·Ì «“ »«‰ò";
			this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem7});
			this.menuItem1.Text = "&›«Ì·";
			this.menuItem1.Select += new System.EventHandler(this.menuItem1_Select);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem4});
			this.menuItem2.Text = "&ê‘Êœ‰";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "»’Ê—  ”—Ì«·";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "»’Ê—   òÌ";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 1;
			this.menuItem7.Text = "&–ŒÌ—Â";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click_1);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.pageReadMethodSettings);
			this.tabControl1.Controls.Add(this.pageTestSettings);
			this.tabControl1.Controls.Add(this.pageCodeSettings);
			this.tabControl1.Controls.Add(this.pageView);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.HotTrack = true;
			this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(720, 699);
			this.tabControl1.TabIndex = 7;
			// 
			// pageReadMethodSettings
			// 
			this.pageReadMethodSettings.Controls.Add(this.groupBox2);
			this.pageReadMethodSettings.Controls.Add(this.groupReadMethod);
			this.pageReadMethodSettings.Location = new System.Drawing.Point(4, 22);
			this.pageReadMethodSettings.Name = "pageReadMethodSettings";
			this.pageReadMethodSettings.Size = new System.Drawing.Size(712, 673);
			this.pageReadMethodSettings.TabIndex = 0;
			this.pageReadMethodSettings.Text = " ‰ŸÌ„«  ‘ÌÊÂ ŒÊ«‰œ‰ Ê –ŒÌ—Â";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupPath);
			this.groupBox2.Controls.Add(this.groupUotputFormat);
			this.groupBox2.Controls.Add(this.groupSavingMethod);
			this.groupBox2.Location = new System.Drawing.Point(56, 200);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.groupBox2.Size = new System.Drawing.Size(592, 296);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "‰ÕÊÂ –ŒÌ—Â ‰ «ÌÃ";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// groupPath
			// 
			this.groupPath.Controls.Add(this.picPathButton);
			this.groupPath.Controls.Add(this.txtPath);
			this.groupPath.Location = new System.Drawing.Point(16, 216);
			this.groupPath.Name = "groupPath";
			this.groupPath.Size = new System.Drawing.Size(552, 72);
			this.groupPath.TabIndex = 24;
			this.groupPath.TabStop = false;
			this.groupPath.Text = "„”Ì— Œ—ÊÃÌ";
			// 
			// picPathButton
			// 
			this.picPathButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picPathButton.Image = ((System.Drawing.Image)(resources.GetObject("picPathButton.Image")));
			this.picPathButton.Location = new System.Drawing.Point(472, 16);
			this.picPathButton.Name = "picPathButton";
			this.picPathButton.Size = new System.Drawing.Size(56, 48);
			this.picPathButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPathButton.TabIndex = 2;
			this.picPathButton.TabStop = false;
			this.picPathButton.Click += new System.EventHandler(this.picPathButton_Click);
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(16, 32);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(440, 20);
			this.txtPath.TabIndex = 1;
			this.txtPath.Text = "";
			// 
			// groupUotputFormat
			// 
			this.groupUotputFormat.Controls.Add(this.picTick);
			this.groupUotputFormat.Controls.Add(this.radioRazmane);
			this.groupUotputFormat.Controls.Add(this.radioSTD);
			this.groupUotputFormat.Controls.Add(this.radioPatoNik);
			this.groupUotputFormat.Controls.Add(this.radioKonkurSim);
			this.groupUotputFormat.Controls.Add(this.radioNCSFormat);
			this.groupUotputFormat.Location = new System.Drawing.Point(16, 24);
			this.groupUotputFormat.Name = "groupUotputFormat";
			this.groupUotputFormat.Size = new System.Drawing.Size(288, 192);
			this.groupUotputFormat.TabIndex = 23;
			this.groupUotputFormat.TabStop = false;
			this.groupUotputFormat.Text = "›—„  ›«Ì· Œ—ÊÃÌ";
			// 
			// picTick
			// 
			this.picTick.Image = ((System.Drawing.Image)(resources.GetObject("picTick.Image")));
			this.picTick.Location = new System.Drawing.Point(256, 112);
			this.picTick.Name = "picTick";
			this.picTick.Size = new System.Drawing.Size(24, 32);
			this.picTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picTick.TabIndex = 30;
			this.picTick.TabStop = false;
			// 
			// radioRazmane
			// 
			this.radioRazmane.Location = new System.Drawing.Point(56, 160);
			this.radioRazmane.Name = "radioRazmane";
			this.radioRazmane.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioRazmane.Size = new System.Drawing.Size(192, 16);
			this.radioRazmane.TabIndex = 29;
			this.radioRazmane.Text = "›—„  —“„‰œê«‰";
			this.radioRazmane.Click += new System.EventHandler(this.radioOutPut_Click);
			// 
			// radioSTD
			// 
			this.radioSTD.Checked = true;
			this.radioSTD.Location = new System.Drawing.Point(56, 128);
			this.radioSTD.Name = "radioSTD";
			this.radioSTD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioSTD.Size = new System.Drawing.Size(192, 16);
			this.radioSTD.TabIndex = 28;
			this.radioSTD.TabStop = true;
			this.radioSTD.Text = "1234*(«” «‰œ«—œ Ê ⁄„Ê„Ì)";
			this.radioSTD.Click += new System.EventHandler(this.radioOutPut_Click);
			// 
			// radioPatoNik
			// 
			this.radioPatoNik.Location = new System.Drawing.Point(56, 96);
			this.radioPatoNik.Name = "radioPatoNik";
			this.radioPatoNik.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioPatoNik.Size = new System.Drawing.Size(192, 16);
			this.radioPatoNik.TabIndex = 27;
			this.radioPatoNik.Text = "›—„  ÃœÌœ Å— Ê ‰Ìò ";
			this.radioPatoNik.Click += new System.EventHandler(this.radioOutPut_Click);
			// 
			// radioKonkurSim
			// 
			this.radioKonkurSim.Location = new System.Drawing.Point(56, 64);
			this.radioKonkurSim.Name = "radioKonkurSim";
			this.radioKonkurSim.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioKonkurSim.Size = new System.Drawing.Size(192, 16);
			this.radioKonkurSim.TabIndex = 24;
			this.radioKonkurSim.Text = "8421*(”Ì„Ê·« Ê— ò‰òÊ—)";
			this.radioKonkurSim.Click += new System.EventHandler(this.radioOutPut_Click);
			// 
			// radioNCSFormat
			// 
			this.radioNCSFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.radioNCSFormat.Location = new System.Drawing.Point(56, 32);
			this.radioNCSFormat.Name = "radioNCSFormat";
			this.radioNCSFormat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioNCSFormat.Size = new System.Drawing.Size(192, 16);
			this.radioNCSFormat.TabIndex = 21;
			this.radioNCSFormat.Text = "NCS(ﬁ·„ çÌ)";
			this.radioNCSFormat.Click += new System.EventHandler(this.radioOutPut_Click);
			// 
			// groupSavingMethod
			// 
			this.groupSavingMethod.Controls.Add(this.pictSaveInFile);
			this.groupSavingMethod.Controls.Add(this.picColInRecord);
			this.groupSavingMethod.Controls.Add(this.picComposite);
			this.groupSavingMethod.Controls.Add(this.radioSaveInFile);
			this.groupSavingMethod.Controls.Add(this.radioColInRecord);
			this.groupSavingMethod.Controls.Add(this.radioComposite);
			this.groupSavingMethod.Enabled = false;
			this.groupSavingMethod.Location = new System.Drawing.Point(320, 24);
			this.groupSavingMethod.Name = "groupSavingMethod";
			this.groupSavingMethod.Size = new System.Drawing.Size(256, 192);
			this.groupSavingMethod.TabIndex = 21;
			this.groupSavingMethod.TabStop = false;
			this.groupSavingMethod.Text = "‘ÌÊÂ –ŒÌ—Â ”«“Ì";
			// 
			// pictSaveInFile
			// 
			this.pictSaveInFile.Image = ((System.Drawing.Image)(resources.GetObject("pictSaveInFile.Image")));
			this.pictSaveInFile.Location = new System.Drawing.Point(192, 128);
			this.pictSaveInFile.Name = "pictSaveInFile";
			this.pictSaveInFile.Size = new System.Drawing.Size(56, 56);
			this.pictSaveInFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictSaveInFile.TabIndex = 5;
			this.pictSaveInFile.TabStop = false;
			// 
			// picColInRecord
			// 
			this.picColInRecord.Image = ((System.Drawing.Image)(resources.GetObject("picColInRecord.Image")));
			this.picColInRecord.Location = new System.Drawing.Point(192, 72);
			this.picColInRecord.Name = "picColInRecord";
			this.picColInRecord.Size = new System.Drawing.Size(56, 56);
			this.picColInRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picColInRecord.TabIndex = 4;
			this.picColInRecord.TabStop = false;
			// 
			// picComposite
			// 
			this.picComposite.Image = ((System.Drawing.Image)(resources.GetObject("picComposite.Image")));
			this.picComposite.Location = new System.Drawing.Point(192, 16);
			this.picComposite.Name = "picComposite";
			this.picComposite.Size = new System.Drawing.Size(56, 56);
			this.picComposite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picComposite.TabIndex = 3;
			this.picComposite.TabStop = false;
			// 
			// radioSaveInFile
			// 
			this.radioSaveInFile.Checked = true;
			this.radioSaveInFile.Location = new System.Drawing.Point(32, 152);
			this.radioSaveInFile.Name = "radioSaveInFile";
			this.radioSaveInFile.Size = new System.Drawing.Size(152, 16);
			this.radioSaveInFile.TabIndex = 2;
			this.radioSaveInFile.TabStop = true;
			this.radioSaveInFile.Text = "–ŒÌ—Â  „«„ Å«”ŒÂ« œ— Ìò ›«Ì·";
			// 
			// radioColInRecord
			// 
			this.radioColInRecord.Location = new System.Drawing.Point(32, 96);
			this.radioColInRecord.Name = "radioColInRecord";
			this.radioColInRecord.Size = new System.Drawing.Size(152, 16);
			this.radioColInRecord.TabIndex = 1;
			this.radioColInRecord.Text = "–ŒÌ—Â Â— ” Ê‰ œ— Ìò —òÊ—œ";
			// 
			// radioComposite
			// 
			this.radioComposite.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.radioComposite.Location = new System.Drawing.Point(8, 40);
			this.radioComposite.Name = "radioComposite";
			this.radioComposite.Size = new System.Drawing.Size(176, 24);
			this.radioComposite.TabIndex = 0;
			this.radioComposite.Text = " —òÌ» Å«”Œ»—êÂ«Ì ç‰œ »—êÌ œ— Ìò ›«Ì·";
			// 
			// groupReadMethod
			// 
			this.groupReadMethod.Controls.Add(this.lblThr);
			this.groupReadMethod.Controls.Add(this.trkThr);
			this.groupReadMethod.Controls.Add(this.lblColorSence);
			this.groupReadMethod.Controls.Add(this.lblSence);
			this.groupReadMethod.Controls.Add(this.label2);
			this.groupReadMethod.Controls.Add(this.trkSence);
			this.groupReadMethod.Controls.Add(this.comboreadMethod);
			this.groupReadMethod.Controls.Add(this.label1);
			this.groupReadMethod.Controls.Add(this.lblDarkPointThr);
			this.groupReadMethod.Location = new System.Drawing.Point(56, 16);
			this.groupReadMethod.Name = "groupReadMethod";
			this.groupReadMethod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.groupReadMethod.Size = new System.Drawing.Size(592, 168);
			this.groupReadMethod.TabIndex = 2;
			this.groupReadMethod.TabStop = false;
			this.groupReadMethod.Text = "‰ÕÊÂ ŒÊ«‰œ‰ ⁄·«„ ";
			// 
			// lblThr
			// 
			this.lblThr.Location = new System.Drawing.Point(440, 78);
			this.lblThr.Name = "lblThr";
			this.lblThr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblThr.Size = new System.Drawing.Size(96, 24);
			this.lblThr.TabIndex = 14;
			this.lblThr.Text = " ‰ŸÌ„ Õœ ¬” «‰Â";
			this.lblThr.Visible = false;
			// 
			// trkThr
			// 
			this.trkThr.Location = new System.Drawing.Point(216, 62);
			this.trkThr.Maximum = 64;
			this.trkThr.Name = "trkThr";
			this.trkThr.Size = new System.Drawing.Size(216, 45);
			this.trkThr.TabIndex = 13;
			this.trkThr.Value = 30;
			this.trkThr.Scroll += new System.EventHandler(this.trkThr_Scroll);
			// 
			// lblColorSence
			// 
			this.lblColorSence.BackColor = System.Drawing.SystemColors.InfoText;
			this.lblColorSence.Location = new System.Drawing.Point(32, 88);
			this.lblColorSence.Name = "lblColorSence";
			this.lblColorSence.Size = new System.Drawing.Size(88, 64);
			this.lblColorSence.TabIndex = 12;
			// 
			// lblSence
			// 
			this.lblSence.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.lblSence.Location = new System.Drawing.Point(144, 136);
			this.lblSence.Name = "lblSence";
			this.lblSence.Size = new System.Drawing.Size(64, 16);
			this.lblSence.TabIndex = 11;
			this.lblSence.Text = "102 (40 %)";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(440, 128);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label2.Size = new System.Drawing.Size(96, 24);
			this.label2.TabIndex = 10;
			this.label2.Text = " ‰ŸÌ„ Õ”«”Ì ";
			// 
			// trkSence
			// 
			this.trkSence.Location = new System.Drawing.Point(216, 112);
			this.trkSence.Maximum = 255;
			this.trkSence.Name = "trkSence";
			this.trkSence.Size = new System.Drawing.Size(216, 45);
			this.trkSence.TabIndex = 9;
			this.trkSence.Value = 102;
			this.trkSence.Scroll += new System.EventHandler(this.trackBar2_Scroll);
			// 
			// comboreadMethod
			// 
			this.comboreadMethod.Items.AddRange(new object[] {
																 "Å——‰ê  —Ì‰ ⁄·«„ ",
																 "ê“Ì‰Â Â«Ì Å——‰ê",
																 " „«„ ⁄·«„  Â«"});
			this.comboreadMethod.Location = new System.Drawing.Point(224, 32);
			this.comboreadMethod.Name = "comboreadMethod";
			this.comboreadMethod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.comboreadMethod.Size = new System.Drawing.Size(200, 21);
			this.comboreadMethod.TabIndex = 1;
			this.comboreadMethod.Text = "Å——‰ê  —Ì‰ ⁄·«„ ";
			this.comboreadMethod.SelectedValueChanged += new System.EventHandler(this.comboreadMethod_SelectedValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(440, 32);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "‘ÌÊÂ «‰ Œ«» ⁄·«„ ";
			// 
			// lblDarkPointThr
			// 
			this.lblDarkPointThr.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.lblDarkPointThr.Location = new System.Drawing.Point(144, 80);
			this.lblDarkPointThr.Name = "lblDarkPointThr";
			this.lblDarkPointThr.Size = new System.Drawing.Size(64, 16);
			this.lblDarkPointThr.TabIndex = 11;
			this.lblDarkPointThr.Text = "30";
			// 
			// pageTestSettings
			// 
			this.pageTestSettings.AutoScroll = true;
			this.pageTestSettings.Controls.Add(this.label6);
			this.pageTestSettings.Controls.Add(this.groupBox1);
			this.pageTestSettings.Controls.Add(this.label35);
			this.pageTestSettings.Controls.Add(this.label34);
			this.pageTestSettings.Controls.Add(this.groupBox16);
			this.pageTestSettings.Controls.Add(this.groupBox15);
			this.pageTestSettings.Controls.Add(this.label33);
			this.pageTestSettings.Controls.Add(this.groupBox14);
			this.pageTestSettings.Controls.Add(this.groupBox8);
			this.pageTestSettings.Location = new System.Drawing.Point(4, 22);
			this.pageTestSettings.Name = "pageTestSettings";
			this.pageTestSettings.Size = new System.Drawing.Size(712, 673);
			this.pageTestSettings.TabIndex = 2;
			this.pageTestSettings.Text = " ‰ŸÌ„«  ’›ÕÂ ¬“„Ê‰";
			this.pageTestSettings.Validated += new System.EventHandler(this.pageTestSettings_Validated);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(448, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 8;
			this.label6.Text = "«·êÊÂ«Ì „ÊÃÊœ";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.txtFormName);
			this.groupBox1.Controls.Add(this.btnSaveTemplate);
			this.groupBox1.Controls.Add(this.comboFormName);
			this.groupBox1.Controls.Add(this.label46);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Location = new System.Drawing.Point(312, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(360, 144);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// button2
			// 
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(24, 64);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 64);
			this.button2.TabIndex = 13;
			this.button2.Text = "–ŒÌ—Â  €ÌÌ—« ";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtFormName
			// 
			this.txtFormName.Location = new System.Drawing.Point(96, 64);
			this.txtFormName.Name = "txtFormName";
			this.txtFormName.Size = new System.Drawing.Size(96, 20);
			this.txtFormName.TabIndex = 12;
			this.txtFormName.Text = "";
			// 
			// btnSaveTemplate
			// 
			this.btnSaveTemplate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.btnSaveTemplate.Location = new System.Drawing.Point(104, 96);
			this.btnSaveTemplate.Name = "btnSaveTemplate";
			this.btnSaveTemplate.Size = new System.Drawing.Size(88, 24);
			this.btnSaveTemplate.TabIndex = 11;
			this.btnSaveTemplate.Text = "–ŒÌ—Â  «·êÊÌ ÃœÌœ";
			this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
			// 
			// comboFormName
			// 
			this.comboFormName.Location = new System.Drawing.Point(16, 32);
			this.comboFormName.Name = "comboFormName";
			this.comboFormName.Size = new System.Drawing.Size(272, 21);
			this.comboFormName.TabIndex = 10;
			this.comboFormName.SelectedIndexChanged += new System.EventHandler(this.comboFormName_SelectedIndexChanged);
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(304, 32);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(32, 16);
			this.label46.TabIndex = 9;
			this.label46.Text = "‰«„ ›—„";
			// 
			// button5
			// 
			this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
			this.button5.Location = new System.Drawing.Point(208, 64);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(72, 64);
			this.button5.TabIndex = 13;
			this.button5.Text = "Õ–› « ·êÊ";
			this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(464, 576);
			this.label35.Name = "label35";
			this.label35.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label35.Size = new System.Drawing.Size(56, 16);
			this.label35.TabIndex = 6;
			this.label35.Text = "ÃÂ  ê“Ì‰Â Â«";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(456, 392);
			this.label34.Name = "label34";
			this.label34.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label34.Size = new System.Drawing.Size(56, 16);
			this.label34.TabIndex = 5;
			this.label34.Text = "ÃÂ  ”Ê«·« ";
			// 
			// groupBox16
			// 
			this.groupBox16.Controls.Add(this.pictureBox14);
			this.groupBox16.Controls.Add(this.radioCRightToLeft);
			this.groupBox16.Controls.Add(this.radioCLeftToRight);
			this.groupBox16.Controls.Add(this.pictureBox15);
			this.groupBox16.Location = new System.Drawing.Point(312, 576);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new System.Drawing.Size(352, 160);
			this.groupBox16.TabIndex = 4;
			this.groupBox16.TabStop = false;
			// 
			// pictureBox14
			// 
			this.pictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox14.Image")));
			this.pictureBox14.Location = new System.Drawing.Point(240, 32);
			this.pictureBox14.Name = "pictureBox14";
			this.pictureBox14.Size = new System.Drawing.Size(64, 56);
			this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox14.TabIndex = 4;
			this.pictureBox14.TabStop = false;
			// 
			// radioCRightToLeft
			// 
			this.radioCRightToLeft.Location = new System.Drawing.Point(128, 56);
			this.radioCRightToLeft.Name = "radioCRightToLeft";
			this.radioCRightToLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioCRightToLeft.Size = new System.Drawing.Size(88, 16);
			this.radioCRightToLeft.TabIndex = 2;
			this.radioCRightToLeft.Text = "—«”  »Â çÅ";
			// 
			// radioCLeftToRight
			// 
			this.radioCLeftToRight.Checked = true;
			this.radioCLeftToRight.Location = new System.Drawing.Point(128, 112);
			this.radioCLeftToRight.Name = "radioCLeftToRight";
			this.radioCLeftToRight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioCLeftToRight.Size = new System.Drawing.Size(88, 16);
			this.radioCLeftToRight.TabIndex = 1;
			this.radioCLeftToRight.TabStop = true;
			this.radioCLeftToRight.Text = "çÅ »Â —«” ";
			// 
			// pictureBox15
			// 
			this.pictureBox15.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox15.Image")));
			this.pictureBox15.Location = new System.Drawing.Point(240, 96);
			this.pictureBox15.Name = "pictureBox15";
			this.pictureBox15.Size = new System.Drawing.Size(64, 56);
			this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox15.TabIndex = 4;
			this.pictureBox15.TabStop = false;
			// 
			// groupBox15
			// 
			this.groupBox15.Controls.Add(this.pictureBox11);
			this.groupBox15.Controls.Add(this.pictureBox1);
			this.groupBox15.Controls.Add(this.radioQRightToLeft);
			this.groupBox15.Controls.Add(this.radioQLeftToRight);
			this.groupBox15.Location = new System.Drawing.Point(312, 392);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(352, 168);
			this.groupBox15.TabIndex = 3;
			this.groupBox15.TabStop = false;
			// 
			// pictureBox11
			// 
			this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
			this.pictureBox11.Location = new System.Drawing.Point(248, 24);
			this.pictureBox11.Name = "pictureBox11";
			this.pictureBox11.Size = new System.Drawing.Size(64, 56);
			this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox11.TabIndex = 4;
			this.pictureBox11.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(248, 96);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 56);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// radioQRightToLeft
			// 
			this.radioQRightToLeft.Location = new System.Drawing.Point(128, 40);
			this.radioQRightToLeft.Name = "radioQRightToLeft";
			this.radioQRightToLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioQRightToLeft.Size = new System.Drawing.Size(96, 16);
			this.radioQRightToLeft.TabIndex = 2;
			this.radioQRightToLeft.Text = "—«”  »Â çÅ";
			// 
			// radioQLeftToRight
			// 
			this.radioQLeftToRight.Checked = true;
			this.radioQLeftToRight.Location = new System.Drawing.Point(128, 112);
			this.radioQLeftToRight.Name = "radioQLeftToRight";
			this.radioQLeftToRight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioQLeftToRight.Size = new System.Drawing.Size(96, 16);
			this.radioQLeftToRight.TabIndex = 1;
			this.radioQLeftToRight.TabStop = true;
			this.radioQLeftToRight.Text = "çÅ »Â —«” ";
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(424, 176);
			this.label33.Name = "label33";
			this.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label33.Size = new System.Drawing.Size(128, 16);
			this.label33.TabIndex = 2;
			this.label33.Text = "„‘Œ’«  „Õ· ”Ê«·«  œ— ›—„";
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.txtNumberOfTotalQuestions);
			this.groupBox14.Controls.Add(this.label5);
			this.groupBox14.Controls.Add(this.txtTopLayoutNumber);
			this.groupBox14.Controls.Add(this.txtLeftLayoutNumber);
			this.groupBox14.Controls.Add(this.label3);
			this.groupBox14.Controls.Add(this.label4);
			this.groupBox14.Controls.Add(this.txtColDistance);
			this.groupBox14.Controls.Add(this.txtClassDistance);
			this.groupBox14.Controls.Add(this.txtHorDistance);
			this.groupBox14.Controls.Add(this.txtVerDistance);
			this.groupBox14.Controls.Add(this.txtFirstCol);
			this.groupBox14.Controls.Add(this.txtFirstRow);
			this.groupBox14.Controls.Add(this.txtCasesNumber);
			this.groupBox14.Controls.Add(this.txtQuestionNumber);
			this.groupBox14.Controls.Add(this.txtclassNumber);
			this.groupBox14.Controls.Add(this.txtColNumber);
			this.groupBox14.Controls.Add(this.label36);
			this.groupBox14.Controls.Add(this.label37);
			this.groupBox14.Controls.Add(this.label38);
			this.groupBox14.Controls.Add(this.label39);
			this.groupBox14.Controls.Add(this.label40);
			this.groupBox14.Controls.Add(this.label41);
			this.groupBox14.Controls.Add(this.label42);
			this.groupBox14.Controls.Add(this.label43);
			this.groupBox14.Controls.Add(this.label44);
			this.groupBox14.Controls.Add(this.label45);
			this.groupBox14.Location = new System.Drawing.Point(312, 176);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(360, 208);
			this.groupBox14.TabIndex = 1;
			this.groupBox14.TabStop = false;
			// 
			// txtNumberOfTotalQuestions
			// 
			this.txtNumberOfTotalQuestions.Location = new System.Drawing.Point(96, 16);
			this.txtNumberOfTotalQuestions.Name = "txtNumberOfTotalQuestions";
			this.txtNumberOfTotalQuestions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtNumberOfTotalQuestions.Size = new System.Drawing.Size(96, 20);
			this.txtNumberOfTotalQuestions.TabIndex = 27;
			this.txtNumberOfTotalQuestions.Text = "85";
			this.txtNumberOfTotalQuestions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(208, 16);
			this.label5.Name = "label5";
			this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 26;
			this.label5.Text = " ⁄œ«œ ò· ”Ê«·« ";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTopLayoutNumber
			// 
			this.txtTopLayoutNumber.Location = new System.Drawing.Point(200, 168);
			this.txtTopLayoutNumber.Name = "txtTopLayoutNumber";
			this.txtTopLayoutNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtTopLayoutNumber.Size = new System.Drawing.Size(32, 20);
			this.txtTopLayoutNumber.TabIndex = 25;
			this.txtTopLayoutNumber.Text = "10";
			this.txtTopLayoutNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txtLeftLayoutNumber
			// 
			this.txtLeftLayoutNumber.Location = new System.Drawing.Point(200, 144);
			this.txtLeftLayoutNumber.Name = "txtLeftLayoutNumber";
			this.txtLeftLayoutNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtLeftLayoutNumber.Size = new System.Drawing.Size(32, 20);
			this.txtLeftLayoutNumber.TabIndex = 24;
			this.txtLeftLayoutNumber.Text = "30";
			this.txtLeftLayoutNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(248, 152);
			this.label3.Name = "label3";
			this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 22;
			this.label3.Text = " ⁄œ«œ Õ«‘ÌÂ Â«Ì çÅ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(248, 176);
			this.label4.Name = "label4";
			this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 23;
			this.label4.Text = " ⁄œ«œ Õ«‘ÌÂ Â«Ì »«·«";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtColDistance
			// 
			this.txtColDistance.Location = new System.Drawing.Point(200, 120);
			this.txtColDistance.Name = "txtColDistance";
			this.txtColDistance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtColDistance.Size = new System.Drawing.Size(32, 20);
			this.txtColDistance.TabIndex = 19;
			this.txtColDistance.Text = "04";
			this.txtColDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txtClassDistance
			// 
			this.txtClassDistance.Location = new System.Drawing.Point(200, 96);
			this.txtClassDistance.Name = "txtClassDistance";
			this.txtClassDistance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtClassDistance.Size = new System.Drawing.Size(32, 20);
			this.txtClassDistance.TabIndex = 18;
			this.txtClassDistance.Text = "03";
			this.txtClassDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txtHorDistance
			// 
			this.txtHorDistance.Location = new System.Drawing.Point(200, 72);
			this.txtHorDistance.Name = "txtHorDistance";
			this.txtHorDistance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtHorDistance.Size = new System.Drawing.Size(32, 20);
			this.txtHorDistance.TabIndex = 17;
			this.txtHorDistance.Text = "00";
			this.txtHorDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txtVerDistance
			// 
			this.txtVerDistance.Location = new System.Drawing.Point(200, 48);
			this.txtVerDistance.Name = "txtVerDistance";
			this.txtVerDistance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtVerDistance.Size = new System.Drawing.Size(32, 20);
			this.txtVerDistance.TabIndex = 16;
			this.txtVerDistance.Text = "00";
			this.txtVerDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txtFirstCol
			// 
			this.txtFirstCol.Location = new System.Drawing.Point(32, 168);
			this.txtFirstCol.Name = "txtFirstCol";
			this.txtFirstCol.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtFirstCol.Size = new System.Drawing.Size(32, 20);
			this.txtFirstCol.TabIndex = 15;
			this.txtFirstCol.Text = "03";
			this.txtFirstCol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txtFirstRow
			// 
			this.txtFirstRow.Location = new System.Drawing.Point(32, 144);
			this.txtFirstRow.Name = "txtFirstRow";
			this.txtFirstRow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtFirstRow.Size = new System.Drawing.Size(32, 20);
			this.txtFirstRow.TabIndex = 14;
			this.txtFirstRow.Text = "00";
			this.txtFirstRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txtCasesNumber
			// 
			this.txtCasesNumber.Location = new System.Drawing.Point(32, 120);
			this.txtCasesNumber.Name = "txtCasesNumber";
			this.txtCasesNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtCasesNumber.Size = new System.Drawing.Size(32, 20);
			this.txtCasesNumber.TabIndex = 13;
			this.txtCasesNumber.Text = "04";
			this.txtCasesNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txtQuestionNumber
			// 
			this.txtQuestionNumber.Location = new System.Drawing.Point(32, 96);
			this.txtQuestionNumber.Name = "txtQuestionNumber";
			this.txtQuestionNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtQuestionNumber.Size = new System.Drawing.Size(32, 20);
			this.txtQuestionNumber.TabIndex = 12;
			this.txtQuestionNumber.Text = "10";
			this.txtQuestionNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txtclassNumber
			// 
			this.txtclassNumber.Location = new System.Drawing.Point(32, 72);
			this.txtclassNumber.Name = "txtclassNumber";
			this.txtclassNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtclassNumber.Size = new System.Drawing.Size(32, 20);
			this.txtclassNumber.TabIndex = 11;
			this.txtclassNumber.Text = "03";
			this.txtclassNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txtColNumber
			// 
			this.txtColNumber.Location = new System.Drawing.Point(32, 48);
			this.txtColNumber.Name = "txtColNumber";
			this.txtColNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtColNumber.Size = new System.Drawing.Size(32, 20);
			this.txtColNumber.TabIndex = 10;
			this.txtColNumber.Text = "04";
			this.txtColNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(72, 72);
			this.label36.Name = "label36";
			this.label36.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label36.Size = new System.Drawing.Size(104, 16);
			this.label36.TabIndex = 0;
			this.label36.Text = " ⁄œ«œ œ” Â Â«Ì Â— ” Ê‰";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(72, 96);
			this.label37.Name = "label37";
			this.label37.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label37.Size = new System.Drawing.Size(96, 16);
			this.label37.TabIndex = 0;
			this.label37.Text = " ⁄œ«œ ”Ê«·«  Â— œ” Â";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(72, 120);
			this.label38.Name = "label38";
			this.label38.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label38.Size = new System.Drawing.Size(120, 16);
			this.label38.TabIndex = 0;
			this.label38.Text = " ⁄œ«œ ê“Ì‰Â Â«Ì Â— ”Ê«·";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(72, 152);
			this.label39.Name = "label39";
			this.label39.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label39.Size = new System.Drawing.Size(120, 16);
			this.label39.TabIndex = 0;
			this.label39.Text = "«Ê·Ì‰ ê“Ì‰Â ”Ê«·(”ÿ—)";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(72, 176);
			this.label40.Name = "label40";
			this.label40.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label40.Size = new System.Drawing.Size(104, 16);
			this.label40.TabIndex = 0;
			this.label40.Text = "«Ê·Ì‰ ê“Ì‰Â ”Ê«·(” Ê‰)";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(248, 48);
			this.label41.Name = "label41";
			this.label41.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label41.Size = new System.Drawing.Size(120, 16);
			this.label41.TabIndex = 0;
			this.label41.Text = "›«’·Â »Ì‰ ê“Ì‰Â Â«(⁄„ÊœÌ)";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(248, 72);
			this.label42.Name = "label42";
			this.label42.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label42.Size = new System.Drawing.Size(112, 16);
			this.label42.TabIndex = 0;
			this.label42.Text = "›«’·Â »Ì‰ ê“Ì‰Â Â«(«›ﬁÌ)";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(248, 120);
			this.label43.Name = "label43";
			this.label43.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label43.Size = new System.Drawing.Size(104, 16);
			this.label43.TabIndex = 0;
			this.label43.Text = "›«’·Â »Ì‰ œ” Â Â«";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(248, 96);
			this.label44.Name = "label44";
			this.label44.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label44.Size = new System.Drawing.Size(104, 16);
			this.label44.TabIndex = 0;
			this.label44.Text = "›«’·Â »Ì‰ ” Ê‰Â«";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(72, 48);
			this.label45.Name = "label45";
			this.label45.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label45.Size = new System.Drawing.Size(72, 16);
			this.label45.TabIndex = 0;
			this.label45.Text = " ⁄œ«œ ” Ê‰Â«";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.groupBox13);
			this.groupBox8.Controls.Add(this.groupBox12);
			this.groupBox8.Controls.Add(this.groupBox11);
			this.groupBox8.Controls.Add(this.groupBox10);
			this.groupBox8.Controls.Add(this.groupBox9);
			this.groupBox8.Location = new System.Drawing.Point(16, 16);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.groupBox8.Size = new System.Drawing.Size(288, 744);
			this.groupBox8.TabIndex = 0;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "„ €Ì—Â«Ì ’›ÕÂ ¬“„Ê‰";
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.txt5VarName);
			this.groupBox13.Controls.Add(this.txt5Digits);
			this.groupBox13.Controls.Add(this.txt5Cases);
			this.groupBox13.Controls.Add(this.txt5Row);
			this.groupBox13.Controls.Add(this.txt5Col);
			this.groupBox13.Controls.Add(this.label28);
			this.groupBox13.Controls.Add(this.label29);
			this.groupBox13.Controls.Add(this.label30);
			this.groupBox13.Controls.Add(this.label31);
			this.groupBox13.Controls.Add(this.label32);
			this.groupBox13.Location = new System.Drawing.Point(16, 600);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(264, 136);
			this.groupBox13.TabIndex = 4;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "„ €Ì— Å‰Ã„   (Õœ«òÀ— 1 —ﬁ„)";
			// 
			// txt5VarName
			// 
			this.txt5VarName.Location = new System.Drawing.Point(8, 96);
			this.txt5VarName.Name = "txt5VarName";
			this.txt5VarName.Size = new System.Drawing.Size(200, 20);
			this.txt5VarName.TabIndex = 22;
			this.txt5VarName.Text = "";
			// 
			// txt5Digits
			// 
			this.txt5Digits.Location = new System.Drawing.Point(144, 56);
			this.txt5Digits.Name = "txt5Digits";
			this.txt5Digits.Size = new System.Drawing.Size(56, 20);
			this.txt5Digits.TabIndex = 21;
			this.txt5Digits.Text = "01";
			this.txt5Digits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt5Cases
			// 
			this.txt5Cases.Location = new System.Drawing.Point(8, 56);
			this.txt5Cases.Name = "txt5Cases";
			this.txt5Cases.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txt5Cases.Size = new System.Drawing.Size(56, 20);
			this.txt5Cases.TabIndex = 20;
			this.txt5Cases.Text = "10";
			this.txt5Cases.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt5Row
			// 
			this.txt5Row.Location = new System.Drawing.Point(144, 16);
			this.txt5Row.Name = "txt5Row";
			this.txt5Row.Size = new System.Drawing.Size(56, 20);
			this.txt5Row.TabIndex = 19;
			this.txt5Row.Text = "01";
			this.txt5Row.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt5Col
			// 
			this.txt5Col.Location = new System.Drawing.Point(8, 16);
			this.txt5Col.Name = "txt5Col";
			this.txt5Col.Size = new System.Drawing.Size(56, 20);
			this.txt5Col.TabIndex = 18;
			this.txt5Col.Text = "16";
			this.txt5Col.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(208, 104);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(48, 16);
			this.label28.TabIndex = 17;
			this.label28.Text = "‰«„ „ €Ì— :";
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(72, 64);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(64, 16);
			this.label29.TabIndex = 16;
			this.label29.Text = " ⁄œ«œ ê“Ì‰Â Â« :";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(200, 64);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(56, 16);
			this.label30.TabIndex = 15;
			this.label30.Text = " ⁄œ«œ «—ﬁ«„ :";
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(72, 16);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(32, 16);
			this.label31.TabIndex = 14;
			this.label31.Text = "” Ê‰:";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(224, 16);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(32, 16);
			this.label32.TabIndex = 13;
			this.label32.Text = "”ÿ—:";
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.txt4VarName);
			this.groupBox12.Controls.Add(this.txt4Digits);
			this.groupBox12.Controls.Add(this.txt4Cases);
			this.groupBox12.Controls.Add(this.txt4Row);
			this.groupBox12.Controls.Add(this.txt4Col);
			this.groupBox12.Controls.Add(this.label23);
			this.groupBox12.Controls.Add(this.label24);
			this.groupBox12.Controls.Add(this.label25);
			this.groupBox12.Controls.Add(this.label26);
			this.groupBox12.Controls.Add(this.label27);
			this.groupBox12.Location = new System.Drawing.Point(16, 456);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(264, 136);
			this.groupBox12.TabIndex = 3;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "„ €Ì— çÂ«—„   (Õœ«òÀ— 2 —ﬁ„)";
			// 
			// txt4VarName
			// 
			this.txt4VarName.Location = new System.Drawing.Point(8, 96);
			this.txt4VarName.Name = "txt4VarName";
			this.txt4VarName.Size = new System.Drawing.Size(200, 20);
			this.txt4VarName.TabIndex = 22;
			this.txt4VarName.Text = "";
			// 
			// txt4Digits
			// 
			this.txt4Digits.Location = new System.Drawing.Point(144, 56);
			this.txt4Digits.Name = "txt4Digits";
			this.txt4Digits.Size = new System.Drawing.Size(56, 20);
			this.txt4Digits.TabIndex = 21;
			this.txt4Digits.Text = "2";
			this.txt4Digits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt4Cases
			// 
			this.txt4Cases.Location = new System.Drawing.Point(8, 56);
			this.txt4Cases.Name = "txt4Cases";
			this.txt4Cases.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txt4Cases.Size = new System.Drawing.Size(56, 20);
			this.txt4Cases.TabIndex = 20;
			this.txt4Cases.Text = "10";
			this.txt4Cases.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt4Row
			// 
			this.txt4Row.Location = new System.Drawing.Point(144, 16);
			this.txt4Row.Name = "txt4Row";
			this.txt4Row.Size = new System.Drawing.Size(56, 20);
			this.txt4Row.TabIndex = 19;
			this.txt4Row.Text = "01";
			this.txt4Row.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt4Col
			// 
			this.txt4Col.Location = new System.Drawing.Point(8, 16);
			this.txt4Col.Name = "txt4Col";
			this.txt4Col.Size = new System.Drawing.Size(56, 20);
			this.txt4Col.TabIndex = 18;
			this.txt4Col.Text = "13";
			this.txt4Col.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(208, 104);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(48, 16);
			this.label23.TabIndex = 17;
			this.label23.Text = "‰«„ „ €Ì— :";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(72, 64);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(64, 16);
			this.label24.TabIndex = 16;
			this.label24.Text = " ⁄œ«œ ê“Ì‰Â Â« :";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(200, 64);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(56, 16);
			this.label25.TabIndex = 15;
			this.label25.Text = " ⁄œ«œ «—ﬁ«„ :";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(72, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(32, 16);
			this.label26.TabIndex = 14;
			this.label26.Text = "” Ê‰:";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(224, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(32, 16);
			this.label27.TabIndex = 13;
			this.label27.Text = "”ÿ—:";
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.txt3VarName);
			this.groupBox11.Controls.Add(this.txt3Digits);
			this.groupBox11.Controls.Add(this.txt3Cases);
			this.groupBox11.Controls.Add(this.txt3Row);
			this.groupBox11.Controls.Add(this.txt3Col);
			this.groupBox11.Controls.Add(this.label18);
			this.groupBox11.Controls.Add(this.label19);
			this.groupBox11.Controls.Add(this.label20);
			this.groupBox11.Controls.Add(this.label21);
			this.groupBox11.Controls.Add(this.label22);
			this.groupBox11.Location = new System.Drawing.Point(16, 312);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(264, 136);
			this.groupBox11.TabIndex = 2;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "„ €Ì— ”Ê„   (Õœ«òÀ— 3 —ﬁ„)";
			// 
			// txt3VarName
			// 
			this.txt3VarName.Location = new System.Drawing.Point(8, 96);
			this.txt3VarName.Name = "txt3VarName";
			this.txt3VarName.Size = new System.Drawing.Size(200, 20);
			this.txt3VarName.TabIndex = 22;
			this.txt3VarName.Text = "";
			// 
			// txt3Digits
			// 
			this.txt3Digits.Location = new System.Drawing.Point(144, 56);
			this.txt3Digits.Name = "txt3Digits";
			this.txt3Digits.Size = new System.Drawing.Size(56, 20);
			this.txt3Digits.TabIndex = 21;
			this.txt3Digits.Text = "03";
			this.txt3Digits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt3Cases
			// 
			this.txt3Cases.Location = new System.Drawing.Point(8, 56);
			this.txt3Cases.Name = "txt3Cases";
			this.txt3Cases.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txt3Cases.Size = new System.Drawing.Size(56, 20);
			this.txt3Cases.TabIndex = 20;
			this.txt3Cases.Text = "10";
			this.txt3Cases.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt3Row
			// 
			this.txt3Row.Location = new System.Drawing.Point(144, 16);
			this.txt3Row.Name = "txt3Row";
			this.txt3Row.Size = new System.Drawing.Size(56, 20);
			this.txt3Row.TabIndex = 19;
			this.txt3Row.Text = "01";
			this.txt3Row.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt3Col
			// 
			this.txt3Col.Location = new System.Drawing.Point(8, 16);
			this.txt3Col.Name = "txt3Col";
			this.txt3Col.Size = new System.Drawing.Size(56, 20);
			this.txt3Col.TabIndex = 18;
			this.txt3Col.Text = "09";
			this.txt3Col.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(208, 104);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(48, 16);
			this.label18.TabIndex = 17;
			this.label18.Text = "‰«„ „ €Ì— :";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(72, 64);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(64, 16);
			this.label19.TabIndex = 16;
			this.label19.Text = " ⁄œ«œ ê“Ì‰Â Â« :";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(200, 64);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(56, 16);
			this.label20.TabIndex = 15;
			this.label20.Text = " ⁄œ«œ «—ﬁ«„ :";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(72, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(32, 16);
			this.label21.TabIndex = 14;
			this.label21.Text = "” Ê‰:";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(224, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(32, 16);
			this.label22.TabIndex = 13;
			this.label22.Text = "”ÿ—:";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.txt2VarName);
			this.groupBox10.Controls.Add(this.txt2Digits);
			this.groupBox10.Controls.Add(this.txt2Cases);
			this.groupBox10.Controls.Add(this.txt2Row);
			this.groupBox10.Controls.Add(this.txt2Col);
			this.groupBox10.Controls.Add(this.label13);
			this.groupBox10.Controls.Add(this.label14);
			this.groupBox10.Controls.Add(this.label15);
			this.groupBox10.Controls.Add(this.label16);
			this.groupBox10.Controls.Add(this.label17);
			this.groupBox10.Location = new System.Drawing.Point(16, 168);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(264, 136);
			this.groupBox10.TabIndex = 1;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "„ €Ì— œÊ„  (Õœ«òÀ—  5 —ﬁ„)";
			// 
			// txt2VarName
			// 
			this.txt2VarName.Location = new System.Drawing.Point(8, 96);
			this.txt2VarName.Name = "txt2VarName";
			this.txt2VarName.Size = new System.Drawing.Size(200, 20);
			this.txt2VarName.TabIndex = 22;
			this.txt2VarName.Text = "";
			// 
			// txt2Digits
			// 
			this.txt2Digits.Location = new System.Drawing.Point(144, 56);
			this.txt2Digits.Name = "txt2Digits";
			this.txt2Digits.Size = new System.Drawing.Size(56, 20);
			this.txt2Digits.TabIndex = 21;
			this.txt2Digits.Text = "05";
			this.txt2Digits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt2Cases
			// 
			this.txt2Cases.Location = new System.Drawing.Point(8, 56);
			this.txt2Cases.Name = "txt2Cases";
			this.txt2Cases.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txt2Cases.Size = new System.Drawing.Size(56, 20);
			this.txt2Cases.TabIndex = 20;
			this.txt2Cases.Text = "10";
			this.txt2Cases.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt2Row
			// 
			this.txt2Row.Location = new System.Drawing.Point(144, 16);
			this.txt2Row.Name = "txt2Row";
			this.txt2Row.Size = new System.Drawing.Size(56, 20);
			this.txt2Row.TabIndex = 19;
			this.txt2Row.Text = "01";
			this.txt2Row.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt2Col
			// 
			this.txt2Col.Location = new System.Drawing.Point(8, 16);
			this.txt2Col.Name = "txt2Col";
			this.txt2Col.Size = new System.Drawing.Size(56, 20);
			this.txt2Col.TabIndex = 18;
			this.txt2Col.Text = "02";
			this.txt2Col.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(208, 104);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(48, 16);
			this.label13.TabIndex = 17;
			this.label13.Text = "‰«„ „ €Ì— :";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(72, 64);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 16);
			this.label14.TabIndex = 16;
			this.label14.Text = " ⁄œ«œ ê“Ì‰Â Â« :";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(200, 64);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 16);
			this.label15.TabIndex = 15;
			this.label15.Text = " ⁄œ«œ «—ﬁ«„ :";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(72, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 16);
			this.label16.TabIndex = 14;
			this.label16.Text = "” Ê‰:";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(224, 16);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(32, 16);
			this.label17.TabIndex = 13;
			this.label17.Text = "”ÿ—:";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.txt1VarName);
			this.groupBox9.Controls.Add(this.txt1Digits);
			this.groupBox9.Controls.Add(this.txt1Cases);
			this.groupBox9.Controls.Add(this.txt1Row);
			this.groupBox9.Controls.Add(this.txt1Col);
			this.groupBox9.Controls.Add(this.label12);
			this.groupBox9.Controls.Add(this.label8);
			this.groupBox9.Controls.Add(this.label11);
			this.groupBox9.Controls.Add(this.label10);
			this.groupBox9.Controls.Add(this.label9);
			this.groupBox9.Location = new System.Drawing.Point(16, 16);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(264, 144);
			this.groupBox9.TabIndex = 0;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "„ €Ì— «Ê·   (Õœ«òÀ— 12 —ﬁ„)";
			// 
			// txt1VarName
			// 
			this.txt1VarName.Location = new System.Drawing.Point(8, 104);
			this.txt1VarName.Name = "txt1VarName";
			this.txt1VarName.Size = new System.Drawing.Size(200, 20);
			this.txt1VarName.TabIndex = 12;
			this.txt1VarName.Text = "òœ œ«Êÿ·»";
			// 
			// txt1Digits
			// 
			this.txt1Digits.Location = new System.Drawing.Point(144, 64);
			this.txt1Digits.Name = "txt1Digits";
			this.txt1Digits.Size = new System.Drawing.Size(56, 20);
			this.txt1Digits.TabIndex = 11;
			this.txt1Digits.Text = "09";
			this.txt1Digits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt1Cases
			// 
			this.txt1Cases.Location = new System.Drawing.Point(8, 64);
			this.txt1Cases.Name = "txt1Cases";
			this.txt1Cases.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txt1Cases.Size = new System.Drawing.Size(56, 20);
			this.txt1Cases.TabIndex = 10;
			this.txt1Cases.Text = "10";
			this.txt1Cases.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt1Row
			// 
			this.txt1Row.Location = new System.Drawing.Point(144, 24);
			this.txt1Row.Name = "txt1Row";
			this.txt1Row.Size = new System.Drawing.Size(56, 20);
			this.txt1Row.TabIndex = 9;
			this.txt1Row.Text = "00";
			this.txt1Row.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// txt1Col
			// 
			this.txt1Col.Location = new System.Drawing.Point(8, 24);
			this.txt1Col.Name = "txt1Col";
			this.txt1Col.Size = new System.Drawing.Size(56, 20);
			this.txt1Col.TabIndex = 8;
			this.txt1Col.Text = "18";
			this.txt1Col.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(208, 112);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 16);
			this.label12.TabIndex = 7;
			this.label12.Text = "‰«„ „ €Ì— :";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(72, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 6;
			this.label8.Text = " ⁄œ«œ ê“Ì‰Â Â« :";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(200, 72);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 16);
			this.label11.TabIndex = 5;
			this.label11.Text = " ⁄œ«œ «—ﬁ«„ :";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(72, 24);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(32, 16);
			this.label10.TabIndex = 2;
			this.label10.Text = "” Ê‰:";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(224, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 16);
			this.label9.TabIndex = 1;
			this.label9.Text = "”ÿ—:";
			// 
			// pageCodeSettings
			// 
			this.pageCodeSettings.Controls.Add(this.picSelect1);
			this.pageCodeSettings.Controls.Add(this.groupBox5);
			this.pageCodeSettings.Location = new System.Drawing.Point(4, 22);
			this.pageCodeSettings.Name = "pageCodeSettings";
			this.pageCodeSettings.Size = new System.Drawing.Size(712, 673);
			this.pageCodeSettings.TabIndex = 1;
			this.pageCodeSettings.Text = " ‰ŸÌ„«  òœÂ«";
			this.pageCodeSettings.Validated += new System.EventHandler(this.pageCodeSettings_Validated);
			// 
			// picSelect1
			// 
			this.picSelect1.Image = ((System.Drawing.Image)(resources.GetObject("picSelect1.Image")));
			this.picSelect1.Location = new System.Drawing.Point(72, 312);
			this.picSelect1.Name = "picSelect1";
			this.picSelect1.Size = new System.Drawing.Size(48, 48);
			this.picSelect1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSelect1.TabIndex = 33;
			this.picSelect1.TabStop = false;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label7);
			this.groupBox5.Controls.Add(this.groupBox6);
			this.groupBox5.Controls.Add(this.pictureBox9);
			this.groupBox5.Controls.Add(this.pictureBox6);
			this.groupBox5.Controls.Add(this.lblTeacherNumber);
			this.groupBox5.Controls.Add(this.txtTeacherNumber);
			this.groupBox5.Controls.Add(this.radioTeacher);
			this.groupBox5.Controls.Add(this.lblStudentNumber);
			this.groupBox5.Controls.Add(this.txtStudentNumber);
			this.groupBox5.Controls.Add(this.radioStudent);
			this.groupBox5.Location = new System.Drawing.Point(56, 16);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.groupBox5.Size = new System.Drawing.Size(592, 368);
			this.groupBox5.TabIndex = 11;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = " ‰ŸÌ„«  òœÂ«";
			// 
			// label7
			// 
			this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label7.ForeColor = System.Drawing.Color.Blue;
			this.label7.Location = new System.Drawing.Point(528, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 16);
			this.label7.TabIndex = 26;
			this.label7.Text = "ÅÌ‘ ›—÷";
			this.label7.Click += new System.EventHandler(this.label7_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.pictureBox8);
			this.groupBox6.Controls.Add(this.pictureBox7);
			this.groupBox6.Controls.Add(this.radioTestOmit);
			this.groupBox6.Controls.Add(this.lblAzmunNumber);
			this.groupBox6.Controls.Add(this.radioTest);
			this.groupBox6.Controls.Add(this.txtAzmunNumber);
			this.groupBox6.Location = new System.Drawing.Point(24, 192);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(552, 160);
			this.groupBox6.TabIndex = 25;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "òœ ¬“„Ê‰";
			// 
			// pictureBox8
			// 
			this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
			this.pictureBox8.Location = new System.Drawing.Point(464, 104);
			this.pictureBox8.Name = "pictureBox8";
			this.pictureBox8.Size = new System.Drawing.Size(64, 64);
			this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox8.TabIndex = 29;
			this.pictureBox8.TabStop = false;
			// 
			// pictureBox7
			// 
			this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
			this.pictureBox7.Location = new System.Drawing.Point(464, 16);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(64, 88);
			this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox7.TabIndex = 28;
			this.pictureBox7.TabStop = false;
			// 
			// radioTestOmit
			// 
			this.radioTestOmit.Checked = true;
			this.radioTestOmit.Location = new System.Drawing.Point(256, 128);
			this.radioTestOmit.Name = "radioTestOmit";
			this.radioTestOmit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioTestOmit.Size = new System.Drawing.Size(192, 16);
			this.radioTestOmit.TabIndex = 27;
			this.radioTestOmit.TabStop = true;
			this.radioTestOmit.Text = "Õ–› òœ ¬“„Ê‰  »’Ê—  ò«„·";
			this.radioTestOmit.Click += new System.EventHandler(this.radioCodes_Click);
			this.radioTestOmit.CheckedChanged += new System.EventHandler(this.radioCodes_CheckedChanged);
			// 
			// lblAzmunNumber
			// 
			this.lblAzmunNumber.Enabled = false;
			this.lblAzmunNumber.Location = new System.Drawing.Point(192, 56);
			this.lblAzmunNumber.Name = "lblAzmunNumber";
			this.lblAzmunNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblAzmunNumber.Size = new System.Drawing.Size(48, 24);
			this.lblAzmunNumber.TabIndex = 26;
			this.lblAzmunNumber.Text = "«“ ‘„«—Â :";
			// 
			// radioTest
			// 
			this.radioTest.Location = new System.Drawing.Point(256, 56);
			this.radioTest.Name = "radioTest";
			this.radioTest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioTest.Size = new System.Drawing.Size(192, 16);
			this.radioTest.TabIndex = 25;
			this.radioTest.Text = " ŒÊ«‰œ‰ òœ ¬“„Ê‰  »’Ê—  œ” Ì (‘„«—‰œÂ)";
			this.radioTest.Click += new System.EventHandler(this.radioCodes_Click);
			this.radioTest.CheckedChanged += new System.EventHandler(this.radioTest_CheckedChanged);
			// 
			// txtAzmunNumber
			// 
			this.txtAzmunNumber.Enabled = false;
			this.txtAzmunNumber.Location = new System.Drawing.Point(56, 56);
			this.txtAzmunNumber.Name = "txtAzmunNumber";
			this.txtAzmunNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtAzmunNumber.Size = new System.Drawing.Size(128, 20);
			this.txtAzmunNumber.TabIndex = 24;
			this.txtAzmunNumber.Text = "00";
			this.txtAzmunNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumbers_KeyPress);
			this.txtAzmunNumber.Enter += new System.EventHandler(this.txtTeacherNumber_Enter);
			// 
			// pictureBox9
			// 
			this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
			this.pictureBox9.Location = new System.Drawing.Point(488, 112);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(56, 56);
			this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox9.TabIndex = 24;
			this.pictureBox9.TabStop = false;
			// 
			// pictureBox6
			// 
			this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
			this.pictureBox6.Location = new System.Drawing.Point(480, 32);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(72, 72);
			this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox6.TabIndex = 21;
			this.pictureBox6.TabStop = false;
			// 
			// lblTeacherNumber
			// 
			this.lblTeacherNumber.Enabled = false;
			this.lblTeacherNumber.Location = new System.Drawing.Point(216, 128);
			this.lblTeacherNumber.Name = "lblTeacherNumber";
			this.lblTeacherNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblTeacherNumber.Size = new System.Drawing.Size(40, 24);
			this.lblTeacherNumber.TabIndex = 20;
			this.lblTeacherNumber.Text = " ‘„«—Â :";
			// 
			// txtTeacherNumber
			// 
			this.txtTeacherNumber.Enabled = false;
			this.txtTeacherNumber.Location = new System.Drawing.Point(72, 128);
			this.txtTeacherNumber.Name = "txtTeacherNumber";
			this.txtTeacherNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtTeacherNumber.Size = new System.Drawing.Size(136, 20);
			this.txtTeacherNumber.TabIndex = 19;
			this.txtTeacherNumber.Text = "00";
			this.txtTeacherNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumbers_KeyPress);
			this.txtTeacherNumber.Enter += new System.EventHandler(this.txtTeacherNumber_Enter);
			// 
			// radioTeacher
			// 
			this.radioTeacher.Location = new System.Drawing.Point(272, 128);
			this.radioTeacher.Name = "radioTeacher";
			this.radioTeacher.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioTeacher.Size = new System.Drawing.Size(192, 16);
			this.radioTeacher.TabIndex = 18;
			this.radioTeacher.Text = " ⁄ÌÌ‰ òœ «” «œ »’Ê—  À«» ";
			this.radioTeacher.Click += new System.EventHandler(this.radioCodes_Click);
			this.radioTeacher.CheckedChanged += new System.EventHandler(this.radioTeacher_CheckedChanged);
			// 
			// lblStudentNumber
			// 
			this.lblStudentNumber.Enabled = false;
			this.lblStudentNumber.Location = new System.Drawing.Point(216, 64);
			this.lblStudentNumber.Name = "lblStudentNumber";
			this.lblStudentNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblStudentNumber.Size = new System.Drawing.Size(48, 24);
			this.lblStudentNumber.TabIndex = 15;
			this.lblStudentNumber.Text = "«“ ‘„«—Â :";
			// 
			// txtStudentNumber
			// 
			this.txtStudentNumber.Enabled = false;
			this.txtStudentNumber.Location = new System.Drawing.Point(72, 64);
			this.txtStudentNumber.Name = "txtStudentNumber";
			this.txtStudentNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtStudentNumber.Size = new System.Drawing.Size(136, 20);
			this.txtStudentNumber.TabIndex = 12;
			this.txtStudentNumber.Text = "00";
			this.txtStudentNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumbers_KeyPress);
			this.txtStudentNumber.Enter += new System.EventHandler(this.txtTeacherNumber_Enter);
			// 
			// radioStudent
			// 
			this.radioStudent.Location = new System.Drawing.Point(272, 64);
			this.radioStudent.Name = "radioStudent";
			this.radioStudent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioStudent.Size = new System.Drawing.Size(192, 16);
			this.radioStudent.TabIndex = 11;
			this.radioStudent.Text = " ŒÊ«‰œ‰ òœ œ«Êÿ·» »’Ê—  œ” Ì (‘„«—‰œÂ)";
			this.radioStudent.Click += new System.EventHandler(this.radioCodes_Click);
			this.radioStudent.CheckedChanged += new System.EventHandler(this.radioStudent_CheckedChanged);
			// 
			// pageView
			// 
			this.pageView.Controls.Add(this.button4);
			this.pageView.Controls.Add(this.dataGrid);
			this.pageView.Controls.Add(this.button3);
			this.pageView.Controls.Add(this.button1);
			this.pageView.Location = new System.Drawing.Point(4, 22);
			this.pageView.Name = "pageView";
			this.pageView.Size = new System.Drawing.Size(712, 673);
			this.pageView.TabIndex = 3;
			this.pageView.Text = "«’·«Õ Ê ÊÌ—«Ì‘ ‰ «ÌÃ";
			// 
			// button4
			// 
			this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
			this.button4.Location = new System.Drawing.Point(544, 312);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(128, 128);
			this.button4.TabIndex = 3;
			this.button4.Text = "–ŒÌ—Â ‰ «ÌÃ œ— Å« Ìê«Â œ«œÂ ";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// dataGrid
			// 
			this.dataGrid.AllowSorting = false;
			this.dataGrid.DataMember = "";
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(16, 8);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.Size = new System.Drawing.Size(472, 624);
			this.dataGrid.TabIndex = 2;
			this.dataGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGrid_CurrentCellChanged);
			// 
			// button3
			// 
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(544, 168);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(128, 128);
			this.button3.TabIndex = 1;
			this.button3.Text = "·Êœ ‰ «ÌÃ « “ Å« Ìê«Â œ«œÂ ";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(544, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 128);
			this.button1.TabIndex = 0;
			this.button1.Text = "‰„«Ì‘ Ê «’·«Õ ‰ «ÌÃ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 677);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(720, 22);
			this.statusBar.TabIndex = 8;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(720, 699);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.tabControl1);
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "”Ì” „  ‘ŒÌ’ ’›ÕÂ Â«Ì  ” Ì";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.pageReadMethodSettings.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupPath.ResumeLayout(false);
			this.groupUotputFormat.ResumeLayout(false);
			this.groupSavingMethod.ResumeLayout(false);
			this.groupReadMethod.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trkThr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkSence)).EndInit();
			this.pageTestSettings.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox16.ResumeLayout(false);
			this.groupBox15.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.pageCodeSettings.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.pageView.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		///	<summary>
		///	The	main entry point for the application.
		///	</summary>
		
		private	void LoadBmpInArray()
		{
			//min(r,g,b) = (r<g)?(r<b)?r:b:(g<b)?g:b;
			//max(r,g,b) = (r>g)?(r>b)?r:b:(g>b)?g:b;
			//bright = 0.5 *( max +	min)
			//sat =if (max==min) then sat=0	 
			//		else if	(br	< 0.5 )then	sat=(max-min)/(max+min)	
			//		else sat = (max	- min) / 510 - (max+min)
			
			//heue =if (max==min) then hue=	0 
			//		else if( max ==	r) hue = ((60 *	(g-b) /	(max - min )+ 360 )) mod 360 
			//		else if( max ==	g) hue = ((60 *	(b-r) /	(max - min )+ 120 )) 
			//		else if( max ==	b) hue = ((60 *	(r-g) /	(max - min )+ 240 )) 
			//
			BitmapData bmpData=	bmp.LockBits(new Rectangle(0,0,bmpWidth,bmpHeight),ImageLockMode.ReadWrite,PixelFormat.Format24bppRgb);
								
			pixeles=new	byte[bmpWidth,bmpHeight];
			unsafe
			{
				/*string str=DateTime.Now.Second .ToString ()+":"+DateTime.Now.Millisecond .ToString ();*/
				rgbPtr=bmpData.Scan0 ;
				int	nOffset	 =bmpData.Stride - bmpWidth	*3;
				/*for(int nRowIndex	= 0	; nRowIndex	< bmpWidth ; nRowIndex ++)
				{
					for(int	nColumnIndex = 0 ; nColumnIndex	< bmpHeight	; nColumnIndex ++ )
					{	
						pixeles[nRowIndex,nColumnIndex]= (byte)(0.299*rgbPtr [2]+0.587*	rgbPtr [1]+0.114*rgbPtr	[0]);
						rgbPtr += 3;						
					}
					rgbPtr += nOffset;
				}*/
				/*str+="\n"+DateTime.Now.Second.ToString()+":"+DateTime.Now.Millisecond	.ToString ();
				MessageBox.Show(str);*/

			}
		}
		private	float GetBright(int	j,int i)
		{
			unsafe
			{
				byte *bmpPtr=(byte*)rgbPtr;
				//bmpPtr=bmpPtr+3*i*(bmpWidth+nOffset)+j*3;				
				return	(float)(0.299* bmpPtr[2]+0.587*	 bmpPtr[1]+0.114* bmpPtr[0])/255;
			}
		}
		private	void menuItem4_Click(object	sender,	System.EventArgs e)
		{
			try
			{
				nAzmunCounter=nNumberAzmunNumber;
				nStudentCounter=(bStudentNumber)?nNumberStudentNumber:(bTeacherNumber)?nNumberTeacherNumber:0;
				formCounter=0;
				OpenFileDialog op=new OpenFileDialog();
				DialogResult res=op.ShowDialog();
			
				if(res == DialogResult.OK && op.FileName !=	"")
				{

					dirPath=op.FileName	;
					dirPath=dirPath.Substring(0,dirPath.LastIndexOf("\\"));				
					Directory.CreateDirectory(dirPath+"\\Results");
					/**/string str=DateTime.Now.Second .ToString ()+":"+DateTime.Now.Millisecond .ToString ();
				
					if (op.FileName.LastIndexOf(".jpg")	!= -1 || op.FileName.LastIndexOf(".bmp") !=	-1 || op.FileName.LastIndexOf(".jpeg") != -1 )
					{
						ComputeResults(op.FileName );
						//PrintResults(dirPath+"\\Results\\Results.txt");
					}
				
					/**/str+="\n"+DateTime.Now.Second.ToString()+":"+DateTime.Now.Millisecond .ToString	();
					MessageBox.Show(str);
				

				}
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		void ComputeDistanceArray()
		{
			int	[,]arrTemp={
							   {(int)(cellSize * 0.1),(int)(cellSize * 0.05)},
							   {(int)(cellSize * 0.1),(int)(cellSize * 0.1)},
							   {(int)(cellSize * 0.1),(int)(cellSize * 0.15)},
							   {(int)(cellSize * 0.1),(int)(cellSize * 0.2)},
							   {(int)(cellSize * -0.1),(int)(cellSize *	0.05)},
							   {(int)(cellSize * -0.1),(int)(cellSize *	0.1)},
							   {(int)(cellSize * -0.1),(int)(cellSize *	0.15)},
							   {(int)(cellSize * -0.1),(int)(cellSize *	0.2)},

							   {(int)(cellSize * 0.1),(int)(cellSize * -0.05)},
							   {(int)(cellSize * 0.1),(int)(cellSize * -0.1)},
							   {(int)(cellSize * 0.1),(int)(cellSize * -0.15)},
							   {(int)(cellSize * 0.1),(int)(cellSize * -0.2)},
							   {(int)(cellSize * -0.1),(int)(cellSize *	-0.05)},
							   {(int)(cellSize * -0.1),(int)(cellSize *	-0.1)},
							   {(int)(cellSize * -0.1),(int)(cellSize *	-0.15)},
							   {(int)(cellSize * -0.1),(int)(cellSize *	-0.2)},


							   {(int)(cellSize * 0.2),(int)(cellSize * 0.05)},
							   {(int)(cellSize * 0.2),(int)(cellSize * 0.1)},
							   {(int)(cellSize * 0.2),(int)(cellSize * 0.15)},
							   {(int)(cellSize * 0.2),(int)(cellSize * 0.2)},
							   {(int)(cellSize * -0.2),(int)(cellSize *	0.05)},
							   {(int)(cellSize * -0.2),(int)(cellSize *	0.1)},
							   {(int)(cellSize * -0.2),(int)(cellSize *	0.15)},
							   {(int)(cellSize * -0.2),(int)(cellSize *	0.2)},
							   
							   {(int)(cellSize * 0.2),(int)(cellSize * -0.05)},
							   {(int)(cellSize * 0.2),(int)(cellSize * -0.1)},
							   {(int)(cellSize * 0.2),(int)(cellSize * -0.15)},
							   {(int)(cellSize * 0.2),(int)(cellSize * -0.2)},
							   {(int)(cellSize * -0.2),(int)(cellSize *	-0.05)},
							   {(int)(cellSize * -0.2),(int)(cellSize *	-0.1)},
							   {(int)(cellSize * -0.2),(int)(cellSize *	-0.15)},
							   {(int)(cellSize * -0.2),(int)(cellSize *	-0.2)},
								

							   {(int)(cellSize * 0.3),(int)(cellSize * 0.05)},
							   {(int)(cellSize * 0.3),(int)(cellSize * 0.1)},
							   {(int)(cellSize * 0.3),(int)(cellSize * 0.15)},
							   {(int)(cellSize * 0.3),(int)(cellSize * 0.2)},
							   {(int)(cellSize * -0.3),(int)(cellSize *	0.05)},
							   {(int)(cellSize * -0.3),(int)(cellSize *	0.1)},
							   {(int)(cellSize * -0.3),(int)(cellSize *	0.15)},
							   {(int)(cellSize * -0.3),(int)(cellSize *	0.2)},

							   {(int)(cellSize * 0.3),(int)(cellSize * 0.05)},
							   {(int)(cellSize * 0.3),(int)(cellSize * 0.1)},
							   {(int)(cellSize * 0.3),(int)(cellSize * 0.15)},
							   {(int)(cellSize * 0.3),(int)(cellSize * 0.2)},
							   {(int)(cellSize * -0.3),(int)(cellSize *	0.05)},
							   {(int)(cellSize * -0.3),(int)(cellSize *	0.1)},
							   {(int)(cellSize * -0.3),(int)(cellSize *	0.15)},
							   {(int)(cellSize * -0.3),(int)(cellSize *	0.2)},


							   {(int)(cellSize * 0.4),(int)(cellSize * 0.05)},
							   {(int)(cellSize * 0.4),(int)(cellSize * 0.1)},							 
							   {(int)(cellSize * 0.4),(int)(cellSize * 0.15)},
							   {(int)(cellSize * 0.4),(int)(cellSize * 0.2)},
							   {(int)(cellSize * -0.4),(int)(cellSize *	0.05)},
							   {(int)(cellSize * -0.4),(int)(cellSize *	0.1)},
							   {(int)(cellSize * -0.4),(int)(cellSize *	0.15)},
							   {(int)(cellSize * -0.4),(int)(cellSize *	0.2)},

							   {(int)(cellSize * 0.4),(int)(cellSize * -0.05)},
							   {(int)(cellSize * 0.4),(int)(cellSize * -0.1)},							 
							   {(int)(cellSize * 0.4),(int)(cellSize * -0.15)},
							   {(int)(cellSize * 0.4),(int)(cellSize * -0.2)},
							   {(int)(cellSize * -0.4),(int)(cellSize *	-0.05)},
							   {(int)(cellSize * -0.4),(int)(cellSize *	-0.1)},
							   {(int)(cellSize * -0.4),(int)(cellSize *	-0.15)},
							   {(int)(cellSize * -0.4),(int)(cellSize *	-0.2)}
						   };
			//arrDistance=new int[64,2];
			arrDistance=(int[,])arrTemp.Clone();
			//arrTemp.CopyTo(arrDistance,0);
		}
		int	 ComputeResults(string path)
		{
			try
			{
				int	errCode=0;
				Results=new	int[100,31];		
				FinalResults =new bool[61,31];;
				startPoints=new	int[3,2];
				StudentCode="";
				//string str=DateTime.Now.Second .ToString ()+":"+DateTime.Now.Millisecond .ToString ();
				Image img= Image.FromFile(path);			
				bmp=new	Bitmap(img);	
				bmpWidth = bmp.Width ;
				bmpHeight =	bmp.Height;
		
				//LoadBmpInArray();
				//make direct the form
				if(menuItem6.Checked )
				{
				
					double degree=FindStartLayoutAndDifDegree ();	
					if(Math.Abs( degree) > 0.1 && degree< 360 )
					{
						Graphics g=Graphics.FromImage( bmp );
						g.FillRectangle(Brushes.White,0,0,bmp.Width, bmp.Height);
						g.RotateTransform((float)degree);					
						g.DrawImage(img,0,0, img.Width,	img.Height );	
					}
					else if	(degree== 360){bmp.Save("c:\\1.jpg");return	1;}
					if((errCode= ProcessRows())!=0){bmp.Save("c:\\1.jpg");return errCode ;}
				}
				bmp.Save("c:\\1.jpg");
				img.Dispose();
				return 0;
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
			return 0;
		}
		double FindStartLayoutAndDifDegree()
		{						
			try
			{
				bool founded=false;
				int	lastFounded=0,lastFoundedDiag=0;			
				float Bright=0;
				int	nWhiteCounter=0;
				int	xTopSearch=(int)(bmpWidth*0.09);
				int	yTopSearch=(int)(bmpHeight*0.2);
				int	xDownSearch=(int)(bmpWidth*0.125);
				int	yDownSearch=bmpHeight-(int)(bmpHeight*0.2);
				Color color;
				int	nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.005));
				int	pixelCount1=1,pixelCount2=1,pixelCount3=1 ,counter=0;
				for(int	j=(int)(yTopSearch*0.25);j<yTopSearch;j++)
				{
					for(int	i=0;i<xTopSearch;i++)
					{
						color=bmp.GetPixel(i,j);				
						Bright=color.GetBrightness();
						if(Bright <0.4)
						{
							counter=0;
							lastFounded=j;
							pixelCount1=1;
							while((counter++)< (nCounterTHR+5))
							{
								color=bmp.GetPixel(i,++lastFounded);				
								Bright=color.GetBrightness();
								if(Bright <0.5)
								{
									pixelCount1++;							
									nWhiteCounter=0;
								}	
								else
								{
									if(nWhiteCounter>=2)break;
									nWhiteCounter++;
								}						
							}
							if(pixelCount1 >=nCounterTHR)
							{
								counter=0;
								lastFounded=i;
								pixelCount2=1;
								while((counter++)< (nCounterTHR+5))
								{
									color=bmp.GetPixel(++lastFounded,j);				
									Bright=color.GetBrightness();
									if(Bright <0.5)
									{
										pixelCount2++;								
										nWhiteCounter=0;						
									}
									else
									{
										if(nWhiteCounter>=2)break;
										nWhiteCounter++;
									}							
								}
							}	
							if(pixelCount1 >=nCounterTHR &&	pixelCount2	>=nCounterTHR)
							{
								counter=0;
								lastFounded=i;
								lastFoundedDiag=j;
								pixelCount3=1;
								while((counter++)< (nCounterTHR+5))
								{
									++lastFounded;
									color=bmp.GetPixel(++lastFounded,++lastFoundedDiag);				
									Bright=color.GetBrightness();
									if(Bright <0.5)
									{
										pixelCount3++;							
										nWhiteCounter=0;							
									}
									else
									{
										if(nWhiteCounter>=2)break;
										nWhiteCounter++;
									}							
								}
							}
							if(pixelCount1 >=nCounterTHR &&	pixelCount2	>=nCounterTHR &&  pixelCount3 >=nCounterTHR)
							{
								//possibility of dent
								for(int	index=i;index>=0;index--)
								{
									color=bmp.GetPixel(index,j+1);				
									Bright=color.GetBrightness();
									if(Bright >0.3)
									{
										startPoints[0,0]=index+1;
										if(index==i-1)
											startPoints[0,1]=j;
										else
											startPoints[0,1]=j+1;
										founded=true;
										break;
									}
								}
								if(founded)break;
							}						
						}
					}
					if(founded)break;

				}	
				Bright=0;
				if(founded==false)return 360;
				founded=false;			
				for(int	i=0;i<xDownSearch;i++)
				{
					for(int	j=bmpHeight-1;j>yDownSearch;j--)
					{
						color=bmp.GetPixel(i,j);				
						Bright=color.GetBrightness();
						if(Bright <0.4)
						{
							counter=0;
							lastFounded=j;
							pixelCount1=1;
							while((counter++)< (nCounterTHR+5))
							{
								color=bmp.GetPixel(i,--lastFounded);				
								Bright=color.GetBrightness();
								if(Bright <0.5)
								{							
									nWhiteCounter=0;
									pixelCount1++;							
								}	
								else
								{
									if(nWhiteCounter>=2)break;
									nWhiteCounter++;
								}						
							}
							if(pixelCount1	>=nCounterTHR)
							{
								counter=0;
								lastFounded=i;
								pixelCount2=1;
								while((counter++)< (nCounterTHR+5))
								{
									color=bmp.GetPixel(++lastFounded,j);				
									Bright=color.GetBrightness();
									if(Bright <0.5)
									{
										pixelCount2++;							
										nWhiteCounter=0;							
									}
									else
									{
										if(nWhiteCounter>=2)break;
										nWhiteCounter++;
									}							
								}
							}
							if(pixelCount1 >=nCounterTHR &&pixelCount2 >=nCounterTHR)
							{
								counter=0;
								lastFounded=i;
								lastFoundedDiag=j;
								pixelCount3=1;
								while((counter++)< (nCounterTHR+5))
								{
									++lastFounded;
									color=bmp.GetPixel(++lastFounded,--lastFoundedDiag);				
									Bright=color.GetBrightness();
									if(Bright <0.5)
									{
										pixelCount3++;							
										nWhiteCounter=0;							
									}
									else
									{
										if(nWhiteCounter>=2)break;
										nWhiteCounter++;
									}							
								}
							}
							if(pixelCount1 >=nCounterTHR &&	pixelCount2	>=nCounterTHR &&  pixelCount3 >=nCounterTHR)
							{
							
								//possibility of dent
								for(int	index=i;index>=0;index--)
								{
									color=bmp.GetPixel(index,j-1);				
									Bright=color.GetBrightness();
									if(Bright >0.3)
									{
										startPoints[1,0]=index+1;
										if(index==i-1)
											startPoints[1,1]=j;
										else
											startPoints[1,1]=j-1;
										founded=true;
										break;
									}
								}
								if(founded)break;
							}
						}
						if(founded)
							break;
					}
				}
			
				if(founded==false)return 360;
				int	len=startPoints[1,1] -startPoints[0,1] ;
				Double	radius=Math.Sqrt( /*y^2*/(len*len)+	/*x^2*/Math.Pow((startPoints[1,0] -startPoints[0,0]	),2));
		
				if (startPoints[0,0] <startPoints[1,0])
					return (180/Math.PI)*Math.Acos(len/radius);
				else
					return -(180/Math.PI)*Math.Acos(len/radius);
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );return 360;}	
			
		}

		double GetDiffDegree()
		{
			try
			{

				bool funded=false;
				int	xTopCor=0,xBelowCor=0,lastFounded=0;			
				float Bright=0;
				int	firstEndPoint=(int)(bmpHeight/2.5);
				int	lastEndPoint=firstEndPoint*2;
				for(int	i=0;i<300;i++)
				{
					Color color=bmp.GetPixel(i,firstEndPoint);				
					Bright=color.GetBrightness();
					if(Bright <0.7 && Bright>0.4)
					{
						int	pixelCount=1;
						lastFounded=i;
						while(pixelCount<10)
						{
							color=bmp.GetPixel(++i,firstEndPoint);				
							Bright=color.GetBrightness();
							if(Bright <0.7)
							{
								pixelCount++;
							
							}
							else
							{
								int	j=lastFounded;
								while(pixelCount<10)
								{
									color=bmp.GetPixel(--j,firstEndPoint);				
									Bright=color.GetBrightness();
									if(Bright <0.7 )
									{
										pixelCount++;
							
									}
									else break;
								}
								break;
							}
						}
						if(pixelCount >	7)continue;
						xTopCor=lastFounded;
						funded=true;
						break;
					}
				}	
				Bright=0;
				if(funded==false)return	360;
				funded=false;
				for(int	i=xTopCor/3;i<300;i++)
				{
					Color color=bmp.GetPixel(i,lastEndPoint);				
					Bright=color.GetBrightness();				
					if(Bright <0.7 && Bright>0.4)
					{
						int	pixelCount=1;
						lastFounded=i;
						while(pixelCount<10)
						{
							color=bmp.GetPixel(++i,lastEndPoint);				
							Bright=color.GetBrightness();
							if(Bright <0.7)
							{
								pixelCount++;							
							}
							else
							{
								int	j=lastFounded;
								while(pixelCount<10)
								{
									color=bmp.GetPixel(--j,lastEndPoint);				
									Bright=color.GetBrightness();
									if(Bright <0.7)
									{
										pixelCount++;
							
									}
									else break;
								}
								break;
							}
						}
						if(pixelCount >	7)continue;
						xBelowCor=lastFounded;
						funded=true;
						break;
					}
			
				}
				if(funded==false)return	360;
				int	len=lastEndPoint - firstEndPoint;
				Double	radius=Math.Sqrt( /*y^2*/(len*len)+	/*x^2*/Math.Pow((xBelowCor-	xTopCor),2));
				startX=xTopCor;
				if (xTopCor	<xBelowCor)
					return (180/Math.PI)*Math.Acos(len/radius);
				else
					return -(180/Math.PI)*Math.Acos(len/radius);
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );return 360;}
		}

		
		void GetTestCode(int xCor,int yCor)
		{


		}
		void GetSudentCode(int xCor,int	yCor)
		{

		}
		bool FindTopLeftRightLayout()
		{
			try
			{
				bool founded=false;
				int	lastFounded=0,lastFoundedDiag=0;			
				float Bright=0;
				int	xTopSearch=(int)(bmpWidth*0.09);
				int	yTopSearch=(int)(bmpHeight*0.2);

				Color color;
				int	nWhiteCounter=0;
				int	nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.005));
				int	pixelCount1=1,pixelCount2=1,pixelCount3=1 ,counter=0;
				for(int	j=(int)(yTopSearch*0.25);j<yTopSearch;j++)
				{
					for(int	i=0;i<xTopSearch;i++)
					{
						color=bmp.GetPixel(i,j);				
						Bright=color.GetBrightness();
						if(Bright <0.4)
						{
							counter=0;
							lastFounded=j;
							pixelCount1=1;
							while((counter++)< (nCounterTHR+5))
							{
								color=bmp.GetPixel(i,++lastFounded);				
								Bright=color.GetBrightness();
								if(Bright <0.5)
								{
									nWhiteCounter=0;
									pixelCount1++;							
								}	
								else
								{
									if(nWhiteCounter>=2)break;
									nWhiteCounter++;
								}
							}
							if(pixelCount1 >=nCounterTHR)
							{
								counter=0;
								lastFounded=i;
								pixelCount2=1;
								while((counter++)< (nCounterTHR+5))
								{
									color=bmp.GetPixel(++lastFounded,j);				
									Bright=color.GetBrightness();
									if(Bright <0.5)
									{
										nWhiteCounter=0;
										pixelCount2++;							
									}
									else
									{
										if(nWhiteCounter>=2)break;
										nWhiteCounter++;
									}
								}
							}	
							if(pixelCount1 >=nCounterTHR &&	pixelCount2	>=nCounterTHR)
							{
								counter=0;
								lastFounded=i;
								lastFoundedDiag=j;
								pixelCount3=1;
								while((counter++)< (nCounterTHR+5))
								{
									++lastFounded;
									color=bmp.GetPixel(++lastFounded,++lastFoundedDiag);				
									Bright=color.GetBrightness();
									if(Bright <0.5)
									{
										nWhiteCounter=0;
										pixelCount3++;							
									}	
									else
									{
										if(nWhiteCounter>=2)break;
										nWhiteCounter++;
									}
								}
							}
							if(pixelCount1 >=nCounterTHR &&	pixelCount2	>=nCounterTHR &&  pixelCount3 >=nCounterTHR)
							{
								//possibility of dent
								for(int	index=i;index>=0;index--)
								{
									color=bmp.GetPixel(index,j+1);				
									Bright=color.GetBrightness();
									if(Bright >0.3)
									{
										startPoints[0,0]=index+1;
										if(index==i-1)
											startPoints[0,1]=j;
										else
											startPoints[0,1]=j+1;
										founded=true;
										break;
									}
								}
								if(founded)break;
							}						
						}
					}
					if(founded)break;

				}	
				if(founded)
				{
					int	prev=0;
					for(int	i=startPoints[0,0];i<bmpWidth;i++)
					{				
						prev=i;						
						if(!(bmp.GetPixel(i,startPoints[0,1]).GetBrightness()<0.4))
						{
							startPoints[1,0]=i-1;
							startPoints[1,1]=startPoints[0,1];
							break;
						}											
					}
				}
				if(founded)
				{
					founded=false;
					xTopSearch=(int)(bmpWidth-bmpWidth*0.075);
					for(int	j=(int)(yTopSearch*0.25);j<yTopSearch;j++)
					{
						for(int	i=bmpWidth-1;i>xTopSearch;i--)
						{
					
					
					
							color=bmp.GetPixel(i,j);				
							Bright=color.GetBrightness();
							if(Bright <0.4)
							{
								counter=0;
								lastFounded=i;
								pixelCount1=1;
								while((counter++)< (nCounterTHR+5)&&(lastFounded>0))
								{
									color=bmp.GetPixel(--lastFounded,j);				
									Bright=color.GetBrightness();
									if(Bright <0.5)
									{
										pixelCount1++;	
										nWhiteCounter=0;
									}		
									else
									{
										if(nWhiteCounter>=2)break;
										nWhiteCounter++;
									}
								}
								if(pixelCount1 >=nCounterTHR)
								{
									counter=0;
									lastFounded=j;
									pixelCount2=1;
									while((counter++)< (nCounterTHR+5))
									{
										color=bmp.GetPixel(i,++lastFounded);				
										Bright=color.GetBrightness();
										if(Bright <0.5)
										{
											pixelCount2++;	
											nWhiteCounter=0;
										}
										else
										{
											if(nWhiteCounter>=2)break;
											nWhiteCounter++;
										}
									}
								}	
								if(pixelCount1 >=nCounterTHR &&	pixelCount2	>=nCounterTHR)
								{
									counter=0;
									lastFounded=i;
									lastFoundedDiag=j;
									pixelCount3=1;
									while((counter++)< (nCounterTHR+5))
									{
										--lastFounded;
										color=bmp.GetPixel(--lastFounded,++lastFoundedDiag);				
										Bright=color.GetBrightness();
										if(Bright <0.5)
										{
											nWhiteCounter=0;
											pixelCount3++;							
										}
										else
										{
											if(nWhiteCounter>=2)break;
											nWhiteCounter++;
										}
									}
								}
								if(pixelCount1 >=nCounterTHR &&	pixelCount2	>=nCounterTHR &&  pixelCount3 >=nCounterTHR)
								{
									//possibility of dent
									for(int	index=i;index>=0;index++)
									{
										color=bmp.GetPixel(index,j+1);				
										Bright=color.GetBrightness();
										if(Bright >0.3)
										{
											startPoints[2,0]=index-1;
											if(index==i+1)
												startPoints[2,1]=j;
											else
												startPoints[2,1]=j+1;
											founded=true;
											break;
										}
									}
									if(founded)break;
								}						
							}
						}
						if(founded)break;

					}
				}
				if(founded)return true;
				else
					return false;
			}
			catch(Exception ex)
			{
				MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message ); return false;}
		}
		int	ProcessRows()
		{						
			try
			{
				int	prev=0,xLeftVerMiddlePoint=0,xRightVerMiddlePoint=0;
				int	nLayOutCounter=-1;
				int	nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.005));
				if (!FindTopLeftRightLayout())return 1;
				//if(Math.Abs(startPoints[0,1]-startPoints[2,1])>nCounterTHR)return	2;
				pageSize = startPoints[2,0]-startPoints[0,0];
				int	xHorMiddlePoint=startPoints[0,0]+(startPoints[1,0]-startPoints[0,0])/2;
				int	xRightHorMiddlePoint=startPoints[2,0]-nCounterTHR;
				cellSize = (int)Math.Round(pageSize/39.5);
				cellPad	= (float)((pageSize+2)/33.57);
				ComputeDistanceArray();
				int	j=startPoints[2,1];
				int	control=0;
				for(int	i=startPoints[0,1];i<bmpHeight && j	< bmpHeight;i++,j++)
				{
					if(control==0)
					{
						if(bmp.GetPixel(xHorMiddlePoint,i).GetBrightness()<0.4)
						{
							prev=i;
							while(true)
							{
								if(!(bmp.GetPixel(xHorMiddlePoint,++i).GetBrightness()<0.4))
								{
									xLeftVerMiddlePoint=prev+(i-prev)/2;							
									nLayOutCounter++;
									control=1;
									break;
								}
							}
					
						}
					
					}
					else
					{
						if(bmp.GetPixel(xRightHorMiddlePoint,j).GetBrightness()<0.4)
						{
							prev=j;
							while(true)
							{
								if(!(bmp.GetPixel(xRightHorMiddlePoint,++j).GetBrightness()<0.4))
								{
									xRightVerMiddlePoint =prev+(j-prev)/2;							
									ReadRow(xHorMiddlePoint,xLeftVerMiddlePoint,xRightVerMiddlePoint,nLayOutCounter);
									control=0;
									break;
								}
							}
					
						}
					}
				


				}
				ProcessResults();
				CreateResultsString();
				SaveResultsInDatabase();
				formCounter++;
				statusBar.Text=formCounter.ToString();
				return 0;
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );return 5;}
		}
		void CreateResultsString()
		{
			try
			{
				strTempResults="";
				strFinalResults="";
				for(int  i=0;i<61;i++)
				{
					for(int j=0;j<31;j++)
					{
						strTempResults+=(TempResults[i,j])?"1":"0";
					}
				}

				for(int  i=0;i<nNumberOfTotalQuestions;i++)
				{
					for(int j=0;j<4;j++)
					{
						strFinalResults+=(FinalResults[i,j])?"1":"0";
					}
				}
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		void ReadResultsString()
		{
			try
			{
				if(TempResults == null)
				{
					TempResults = new bool[61 ,31];
				}
				if(FinalResults == null)
				{
					FinalResults=new bool[nNumberOfTotalQuestions ,4];
				}

				char chr;
				int counter = 0;
				for(int  i=0;i<61;i++)
				{
					for(int j=0;j<31;j++)
					{
						chr=strTempResults[counter++];
						switch(chr)
						{
							case '1':TempResults[i,j]=true;break;
							case '0':TempResults[i,j]=false;break;
						}					
					}
				}
				counter=0;
				for(int  i=0;i<nNumberOfTotalQuestions;i++)
				{
					for(int j=0;j<4;j++)
					{
						chr=strFinalResults[counter++];
						switch(chr)
						{
							case '1':FinalResults[i,j]=true;break;
							case '0':FinalResults[i,j]=false;break;
						}	
					}
				}
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		void DeleteTotalRowsFromDB()
		{
			try
			{
				conn.Open();
				command.CommandText="delete from results";
				command.ExecuteNonQuery();
				conn.Close();
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}

		}
		void SaveResultsInDatabase()
		{
			try
			{
				ReadResultsFromDB();
				AddNewDataRowToResults();
				conn.Open();
				da2.Update(ds2,"results");
				conn.Close();
			}
			catch(Exception ex){MessageBox.Show(ex.Message );}
		}
		void AddNewDataRowToResults()
		{
			try
			{
				CreateResultsString();
				System.Data.DataRow dr=ds2.Tables["results"].NewRow();
				dr["strVar1Code"]=strVar1Code;
				dr["strVar2Code"]=strVar2Code;
				dr["strVar3Code"]=strVar3Code;		
				dr["strVar4Code"]=strVar4Code;
				dr["strVar5Code"]=strVar5Code;
				dr["FinalResults"]=strFinalResults ;
				dr["TempResults"]=strTempResults ;
				ds2.Tables["results"].Rows.Add(dr);
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		void ReadResultsFromDB()
		{
			try
			{
				if(ds2.Tables.Contains("results"))
					ds2.Tables["results"].Rows.Clear();
				conn.Open();
				da2.SelectCommand.CommandText="select * from Results";
				da2.Fill(ds2,"results");
				conn.Close();
			}
			catch(Exception ex){MessageBox.Show(ex.Message );}
		}
		void ReadRow(int xCor,int yCor,int yRightCor,int nLayOutCounter)
		{
			float  gradient	 = (yRightCor -	yCor)/(float)pageSize;
			int	Y0=Math.Abs(yRightCor -	yCor);
			int	X,Y;
			for(int	i= 1;i <= 31 ;i++)
			{
				X=(int)(xCor+i*cellPad);
				Y=(int)(gradient*X);//((gradient>0)?gradient*X-Y0:gradient*X);
				Results[nLayOutCounter,i-1]=ReadCell(X,yCor+Y);					
			}
		}
		void ProcessResults()
		{
			try
			{
				int max=0;
				int [,]tempCount=new int[nNumberOfTotalQuestions ,4];
				TempResults = new bool[61 ,31];
				FinalResults=new bool[nNumberOfTotalQuestions ,4];
				int nNumberOfClassDistance=0;
				int classCounter=0,caseCounter=0,QCounter=0;
				if(!QuestionsDir )
				{
					for(int	i=0;i<61;i++)
					{
						for(int	j=0;j<31;j++)
						{
							TempResults[i,j]=(Results[i,j]>=nDarkPointThr)?true:false;
						}
					}
					for(int rowIndex=0;rowIndex <nNumberOfLeftLayout ;rowIndex++)
					{
						if(QCounter==nNumberQuestionNumber  )
						{
							QCounter=0;										
						}
				
						caseCounter=0;
						QCounter++;
				
						classCounter=0;
						nNumberOfClassDistance=0;
						for(int colIndex=nNumberColNumber  *nNumberCasesNumber;colIndex>=0;colIndex--)
						{
							if(caseCounter==nNumberCasesNumber)
							{							
								caseCounter=0;
								classCounter++;
							}
										
							nNumberOfClassDistance=classCounter* nNumberClassDistance;
							caseCounter++;
							if((rowIndex+nNumberOfLeftLayout*classCounter)< nNumberOfTotalQuestions)
							{
								if(TempResults[rowIndex+nNumberOfTopLayout+nNumberFirstRow,colIndex+nNumberFirstCol+nNumberOfClassDistance+colIndex* nNumberHorDistance ])
								{
									FinalResults[rowIndex+nNumberOfLeftLayout*classCounter,caseCounter-1]=true;
								}
								else
								{
									FinalResults[rowIndex+nNumberOfLeftLayout*classCounter,caseCounter-1]=false;
								}
							}
						}
					}

				}
				if(bReadColorized)
				{
					for(int	i=0;i<61;i++)
					{
						for(int	j=0;j<31;j++)
						{
							TempResults[i,j]=(Results[i,j]>=nDarkPointThr)?true:false;
						}
					}
			
					for(int rowIndex=0;rowIndex <nNumberOfLeftLayout ;rowIndex++)
					{
						if(QCounter==nNumberQuestionNumber  )
						{
							QCounter=0;										
						}
				
						caseCounter=0;
						QCounter++;
				
						classCounter=0;
						nNumberOfClassDistance=0;
						for(int colIndex=0;colIndex<nNumberColNumber  *nNumberCasesNumber ;colIndex++)
						{
							if(caseCounter==nNumberCasesNumber)
							{							
								caseCounter=0;
								classCounter++;
							}
										
							nNumberOfClassDistance=classCounter* nNumberClassDistance;
							caseCounter++;
							if((rowIndex+nNumberOfLeftLayout*classCounter)< nNumberOfTotalQuestions)
							{
								if(TempResults[rowIndex+nNumberOfTopLayout+nNumberFirstRow,colIndex+nNumberFirstCol+nNumberOfClassDistance+colIndex* nNumberHorDistance ])
								{
									FinalResults[rowIndex+nNumberOfLeftLayout*classCounter,caseCounter-1]=true;
								}
								else
								{
									FinalResults[rowIndex+nNumberOfLeftLayout*classCounter,caseCounter-1]=false;
								}
							}
						}
					}
				}
				else
				{
					for(int	i=0;i<61;i++)
					{
						for(int	j=0;j<31;j++)
						{
							TempResults[i,j]=(Results[i,j]>=nDarkPointThr)?true:false;
						}
					}
			
					for(int rowIndex=0;rowIndex <nNumberOfLeftLayout ;rowIndex++)
					{
						if(QCounter==nNumberQuestionNumber  )
						{
							QCounter=0;										
						}
				
						caseCounter=0;
						QCounter++;
				
						classCounter=0;
						nNumberOfClassDistance=0;
						for(int colIndex=0;colIndex<nNumberColNumber  *nNumberCasesNumber ;colIndex++)
						{
							if(caseCounter==nNumberCasesNumber)
							{	
								caseCounter=0;
								classCounter++;
							}
										
							nNumberOfClassDistance=classCounter* nNumberClassDistance;
						
							if((rowIndex+nNumberOfLeftLayout*classCounter)< nNumberOfTotalQuestions)
							{
								tempCount[rowIndex+nNumberOfLeftLayout*classCounter,caseCounter]
									=Results[rowIndex+nNumberOfTopLayout+nNumberFirstRow,
									colIndex+nNumberFirstCol+nNumberOfClassDistance+colIndex* nNumberHorDistance ];							
							}
							caseCounter++;
						}
					}
					for(int i=0;i<nNumberOfTotalQuestions ;i++)
					{
						max=0;
						int greatestIndex=0;
						for(int j=0;j<nNumberCasesNumber;j++)
						{
							if(tempCount[i,j]>max && tempCount[i,j]>=nDarkPointThr)
							{
								max=tempCount[i,j];
								FinalResults[i,j]=true;
								if(j>0)FinalResults[i,greatestIndex]=false;
								greatestIndex=j;
							}
							else
								FinalResults[i,j]=false;
						}
					}
				}
				ProcessFormVariables();
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		void ProcessFormVariables()
		{
			try
			{	char []strTemp=new char[12];
				string strNumber="";
				if(bStudentNumber || bTeacherNumber)
				{
					strVar1Code= nStudentCounter.ToString();nStudentCounter++;
					strNumber=new string(' ',12-strVar1Code.Length);
					strVar1Code+=strNumber;
				}
				else
				{
									
					(new String(' ',12)).CopyTo(0,strTemp,0,12);
					for(int rowIndex=0;rowIndex <nNumber1Cases ;rowIndex++)
					{
						for(int colIndex=0;colIndex<nNumber1Digits;colIndex++)
						{										
							if(TempResults[rowIndex+nNumber1Row ,colIndex+nNumber1Col  ])
							{
						
								strTemp[colIndex]=(char)(rowIndex+48);								
							}					
						}
					}
					strVar1Code=new string(strTemp,0,12);
				}
				strTemp=new char[5];
				(new String(' ',5)).CopyTo(0,strTemp,0,5);
				for(int rowIndex=0;rowIndex <nNumber2Cases ;rowIndex++)
				{
					for(int colIndex=0;colIndex<nNumber2Digits;colIndex++)
					{
						if(TempResults[rowIndex+nNumber2Row ,colIndex+nNumber2Col  ])
						{
							strTemp[colIndex]=(char)(rowIndex+48);
						}	
					}
				}
				strVar2Code=new string(strTemp,0,5);
				if(bAzmunNumber)
				{
					strVar3Code= nAzmunCounter.ToString();nAzmunCounter++;
					strNumber=new string(' ',12-strVar3Code.Length);
					strVar3Code+=strNumber;
				}
				else
				{
					strTemp=new char[3];
					(new String(' ',3)).CopyTo(0,strTemp,0,3);
					for(int rowIndex=0;rowIndex <nNumber3Cases ;rowIndex++)
					{
						for(int colIndex=0;colIndex<nNumber3Digits;colIndex++)
						{
							if(TempResults[rowIndex+nNumber3Row ,colIndex+nNumber3Col  ])
							{
								strTemp[colIndex]=(char)(rowIndex+48);
							}	
						}
					}			
					strVar3Code=new string(strTemp,0,3);
				}
				strTemp=new char[2];
				(new String(' ',2)).CopyTo(0,strTemp,0,2);
				for(int rowIndex=0;rowIndex <nNumber4Cases ;rowIndex++)
				{
					for(int colIndex=0;colIndex<nNumber4Digits;colIndex++)
					{
						if(TempResults[rowIndex+nNumber4Row ,colIndex+nNumber4Col  ])
						{
							strTemp[colIndex]=(char)(rowIndex+48);
						}	
					}
				}
				strVar4Code=new string(strTemp,0,2);
				strTemp=new char[1];
				(new String(' ',1)).CopyTo(0,strTemp,0,1);
				for(int rowIndex=0;rowIndex <nNumber5Cases ;rowIndex++)
				{
					for(int colIndex=0;colIndex<nNumber5Digits;colIndex++)
					{
						if(TempResults[rowIndex+nNumber5Row ,colIndex+nNumber5Col  ])
						{
							strTemp[colIndex]=(char)(rowIndex+48);
						}	
					}
				}
				strVar5Code=new string(strTemp,0,1);
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		int	ReadCell(int xCor,int yCor)
		{
			
			int	darkPointsCount= 0;
			int	[,]arrPoints=new int[64,2];
			for(int	i=0;i<64;i++)
			{
				arrPoints[i,0]=xCor+arrDistance[i,0];
				arrPoints[i,1]=yCor+arrDistance[i,1];
			}
			float brightThreshold=(float)(trkSence.Value/255.0);
			float brightness = 0  ;	
			for	( int i= 0 ;i <	64 ;i++)
			{
				brightness	= bmp.GetPixel(arrPoints[i,0],arrPoints[i,1]).GetBrightness();				
			
							
				if ( brightness	>=brightThreshold  )
				{					
					continue;
				}
				if ( brightness	< brightThreshold)
				{				 
						darkPointsCount++;
				}								
			}						
			return darkPointsCount;
		}

		void PrintResults(string path)
		{
			System.IO.TextWriter t=new StreamWriter(path,true);

			
			t.WriteLine("Student Code:"+StudentCode);
			
			for(int	i=0;i<300;i++)
			{
				t.Write((i+1).ToString ()+"	: ");
				for	(int j=0;j<4;j++)
				{
					if (FinalResults[i,j])
						t.Write((j+1).ToString ()+"	- ");
				}
				t.WriteLine();
			}
			t.Close();
		}

		private	void menuItem3_Click(object	sender,	System.EventArgs e)
		{
			try
			{
				nAzmunCounter=nNumberAzmunNumber;
				nStudentCounter=(bStudentNumber)?nNumberStudentNumber:(bTeacherNumber)?nNumberTeacherNumber:0;
				formCounter=0;
				OpenFileDialog op=new OpenFileDialog();
				DialogResult res=op.ShowDialog();
			
				if(res == DialogResult.OK && op.FileName !=	"")
				{

					dirPath=op.FileName	;
					dirPath=dirPath.Substring(0,dirPath.LastIndexOf("\\"));
					string []filesPath=Directory.GetFiles(dirPath);
					Directory.CreateDirectory(dirPath+"\\Results");
					/**/string str=DateTime.Now.Second .ToString ()+":"+DateTime.Now.Millisecond .ToString ();
					for(int	i =0;i<filesPath.Length	;i++)
					{
						if (filesPath[i].LastIndexOf(".jpg") !=	-1 || filesPath[i].LastIndexOf(".bmp") != -1 ||	filesPath[i].LastIndexOf(".jpeg") != -1	)
						{
							ComputeResults(filesPath[i]);
							//PrintResults(dirPath+"\\Results\\Results.txt");
						}
					}
					/**/str+="\n"+DateTime.Now.Second.ToString()+":"+DateTime.Now.Millisecond .ToString	();
					MessageBox.Show(str);
				

				}
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}

		private	void menuItem7_Click(object	sender,	System.EventArgs e)
		{
			MessageBox.Show("·ÿ›« œﬁÌﬁ« Ê”ÿ ê“Ì‰Â Â«Ì «Ê· Ê ¬Œ— œÊ ” Ê‰ „Ã«Ê— ò·Ìò ‰„«ÌÌœ.");         
			
		}
	
		private	void menuItem9_Click(object	sender,	System.EventArgs e)
		
		{
			try
			{
				formCounter=0;
				OpenFileDialog op=new OpenFileDialog();
				DialogResult res=op.ShowDialog();
				cellSize=20;
				ComputeDistanceArray();
				if(res == DialogResult.OK && op.FileName !=	"")
				{												
					if (op.FileName.LastIndexOf(".jpg")	!= -1 || op.FileName.LastIndexOf(".bmp") !=	-1 || op.FileName.LastIndexOf(".jpeg") != -1 )
					{
						Image img= Image.FromFile(op.FileName );			
						bmp=new	Bitmap(img);	
						bmpWidth = bmp.Width ;
						bmpHeight =	bmp.Height;
						
					}				
				}
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		

		private	void trackBar2_Scroll(object sender, System.EventArgs e)
		{
			lblSence.Text=trkSence.Value.ToString()+"  ("+((trkSence.Value/255.0)*100).ToString("00")+"%)";
						
			lblColorSence.BackColor=Color.FromArgb(trkSence.Value,trkSence.Value,trkSence.Value);
		
		}
		Point prevPoint;
		private	void label7_Click(object sender, System.EventArgs e)
		{
			radioTeacher.Checked=false;
			radioTest.Checked=false;
			radioTestOmit.Checked=true;
			radioStudent.Checked=false;
			picSelect1.Location=prevPoint;
		}



		private	void radioOutPut_Click(object sender, System.EventArgs e)
		{
			picTick.Location=new Point(	picTick.Location.X,((RadioButton)sender).Location.Y-picTick.Height/2);
		}

		private	void radioTestOmit_Click(object	sender,	System.EventArgs e)
		{
			MessageBox.Show("«Ì‰ ê“Ì‰Â »’Ê—  ŒÊœò«—  Ê”ÿ ﬁ”„  „ €Ì—Â« «‰Ã«„ „Ì ‘Êœ.");
		}

		private	void radioTest_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioTest.Checked )
			{
				bAzmunNumber=true;
				lblAzmunNumber.Enabled=true;
				txtAzmunNumber.Enabled=true;
				
			}
			else
			{
				bAzmunNumber=false;
				lblAzmunNumber.Enabled=false;
				txtAzmunNumber.Enabled=false;
				
			}
		}

		private	void radioTeacher_CheckedChanged(object	sender,	System.EventArgs e)
		{
			if(radioTeacher.Checked	)
			{
				bTeacherNumber=true;
				lblTeacherNumber.Enabled=true;
				txtTeacherNumber.Enabled=true;
			}
			else
			{
				bTeacherNumber=false;
				lblTeacherNumber.Enabled=false;
				txtTeacherNumber.Enabled=false;
			}		
		}

		private	void radioStudent_CheckedChanged(object	sender,	System.EventArgs e)
		{
			if(radioStudent.Checked	)
			{
				bStudentNumber=true;
				lblStudentNumber.Enabled=true;
				txtStudentNumber.Enabled=true;
			}
			else
			{
				bStudentNumber=false;
				lblStudentNumber.Enabled=false;
				txtStudentNumber.Enabled=false;
			}		
		}

		private	void checkSTEPlike_CheckedChanged(object sender, System.EventArgs e)
		{
			/*if(checkSTEPlike.Checked )
			{
				lblColQuestionNumber.Enabled=true;
				lblComment.Enabled=true;
				radioTopDown.Enabled=true;
				radioDownUp.Enabled=true;
				txtColQuestionNumber.Enabled=true;
			}
			else
			{
				lblColQuestionNumber.Enabled=false;
				lblComment.Enabled=false;
				radioTopDown.Enabled=false;
				radioDownUp.Enabled=false;
				txtColQuestionNumber.Enabled=false;
				
			}*/
		}

		private	void txtHorDistance_KeyPress(object	sender,	System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=8	)
			{
				if(e.KeyChar<'0' ||	e.KeyChar>'9')e.Handled=true;
				if(sender.Equals(txtNumberOfTotalQuestions))
				{
					if(	((TextBox)sender).Text.Length>2	&& ((TextBox)sender).SelectionLength<2)e.Handled=true;
				}else
				if(	((TextBox)sender).Text.Length>1	&& ((TextBox)sender).SelectionLength<1)e.Handled=true;
			}
		}

		private	void txtNumbers_KeyPress(object	sender,	System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar!=8	)
			{
				if(e.KeyChar<'0' ||	e.KeyChar>'9')e.Handled=true;
				if(	((TextBox)sender).Text.Length>12 &&	((TextBox)sender).SelectionLength<1)e.Handled=true;
			}
		}

		private	void menuItemX_Click(object	sender,	System.EventArgs e)
		{
			((MenuItem)sender).Checked=!((MenuItem)sender).Checked;

		}

		private	void radioCodes_Click(object sender, System.EventArgs e)
		{
			GroupBox prnt=(GroupBox)((RadioButton)sender).Parent;
			picSelect1.Location=new	Point( picSelect1.Location.X,((RadioButton)sender).Location.Y+prnt.Location.Y -((RadioButton)sender).Height/2);
			
		}

		private	void Form1_Load(object sender, System.EventArgs	e)
		{
			try
			{
				prevPoint=picSelect1.Location;	
				lblColorSence.BackColor=Color.FromArgb(102,102,102);
				nNumberOfLeftLayout=0;
				nNumberOfTopLayout=0;
				ApplyChanges();
				string strMDBPath=Application.StartupPath ;
				strMDBPath+="\\FormReader.mdb";
				conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+strMDBPath+";Persist Security Info=False");
				command = new OleDbCommand();
				command.Connection=conn;
				da=new OleDbDataAdapter("select * from templates",conn);
				cmdBuilder=new OleDbCommandBuilder(da);
				ds=new DataSet();
				//conn2 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=FormReader.mdb;Persist Security Info=False");
				da2=new OleDbDataAdapter("select * from results",conn);
				cmdBuilder2=new OleDbCommandBuilder(da2);
				ds2=new DataSet();
				ReadFromDataset();
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}

		void ReadDataRow(System.Data.DataRow dr)
		{
			try
			{
				txt1Col.Text =dr["nNumber1Col"].ToString();
				txt1Row.Text =dr["nNumber1Row"].ToString();			
				txt2Row.Text =dr["nNumber2Row"].ToString();
				txt2Col.Text =dr["nNumber2Col"].ToString();
				txt3Row.Text =dr["nNumber3Row"].ToString();
				txt3Col.Text =dr["nNumber3Col"].ToString();
				txt4Row.Text =dr["nNumber4Row"].ToString();
				txt4Col.Text =dr["nNumber4Col"].ToString();
				txt5Row.Text =dr["nNumber5Row"].ToString();
				txt5Col.Text =dr["nNumber5Col"].ToString();
				txt1Digits.Text =dr["nNumber1Digits"].ToString();
				txt2Digits.Text =dr["nNumber2Digits"].ToString();
				txt3Digits.Text =dr["nNumber3Digits"].ToString();
				txt4Digits.Text =dr["nNumber4Digits"].ToString();
				txt5Digits.Text =dr["nNumber5Digits"].ToString();
				txt1Cases.Text =dr["nNumber1Cases"].ToString();
				txt2Cases.Text =dr["nNumber2Cases"].ToString();
				txt3Cases.Text =dr["nNumber3Cases"].ToString();
				txt4Cases.Text =dr["nNumber4Cases"].ToString();
				txt5Cases.Text =dr["nNumber5Cases"].ToString();
				txtColDistance.Text =dr["nNumberColDistance"].ToString();
				txtClassDistance.Text =dr["nNumberClassDistance"].ToString();
				txtHorDistance.Text =dr["nNumberHorDistance"].ToString();
				txtVerDistance.Text =dr["nNumberVerDistance"].ToString();
				txtFirstCol.Text =dr["nNumberFirstCol"].ToString();
				txtFirstRow.Text =dr["nNumberFirstRow"].ToString();
				txtCasesNumber.Text =dr["nNumberCasesNumber"].ToString();
				txtQuestionNumber.Text =dr["nNumberQuestionNumber"].ToString();
				txtclassNumber.Text =dr["nNumberclassNumber"].ToString();
				txtColNumber.Text =dr["nNumberColNumber"].ToString();
				txtStudentNumber.Text =dr["nNumberStudentNumber"].ToString();
				txtAzmunNumber.Text =dr["nNumberAzmunNumber"].ToString();
			
				txtTeacherNumber.Text =dr["nNumberTeacherNumber"].ToString();
				txtNumberOfTotalQuestions.Text =dr["nNumberOfTotalQuestions"].ToString();
				txt1VarName.Text =dr["str1VarName"].ToString();
				txt2VarName.Text =dr["str2VarName"].ToString();
				txt3VarName.Text =dr["str3VarName"].ToString();
				txt4VarName.Text =dr["str4VarName"].ToString();
				txt5VarName.Text =dr["str5VarName"].ToString();				
				txtTopLayoutNumber.Text=dr["nNumberOfTopLayout"].ToString();	
				txtLeftLayoutNumber.Text=dr["nNumberOfLeftLayout"].ToString();	
				QuestionsDir=(bool)dr["QuestionsDir"];
				CasesDir=(bool)dr["CasesDir"];
				radioQLeftToRight.Checked=QuestionsDir;
				radioCLeftToRight.Checked=CasesDir;
				ApplyChanges();
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		void UpdateDataRow(System.Data.DataRow dr)
		{
			try
			{
				//dr["templateName"]=;
				dr["nNumber1Col"]=txt1Col.Text;;
				dr["nNumber1Row"]=txt1Row.Text;			
				dr["nNumber2Row"]=txt2Row.Text;
				dr["nNumber2Col"]=txt2Col.Text;
				dr["nNumber3Row"]=txt3Row.Text;
				dr["nNumber3Col"]=txt3Col.Text;
				dr["nNumber4Row"]=txt4Row.Text;
				dr["nNumber4Col"]=txt4Col.Text;
				dr["nNumber5Row"]=txt5Row.Text;
				dr["nNumber5Col"]=txt5Col.Text;
				dr["nNumber1Digits"]=txt1Digits.Text;
				dr["nNumber2Digits"]=txt2Digits.Text; 
				dr["nNumber3Digits"]=txt3Digits.Text;
				dr["nNumber4Digits"]=txt4Digits.Text;
				dr["nNumber5Digits"]=txt5Digits.Text;
				dr["nNumber1Cases"]=txt1Cases.Text; 
				dr["nNumber2Cases"]=txt2Cases.Text;
				dr["nNumber3Cases"]=txt3Cases.Text;
				dr["nNumber4Cases"]=txt4Cases.Text;
				dr["nNumber5Cases"]=txt5Cases.Text;
				dr["nNumberColDistance"]=txtColDistance.Text;
				dr["nNumberClassDistance"]=txtClassDistance.Text;
				dr["nNumberHorDistance"]=txtHorDistance.Text; 
				dr["nNumberVerDistance"]=txtVerDistance.Text;
				dr["nNumberFirstCol"]=txtFirstCol.Text;
				dr["nNumberFirstRow"]=txtFirstRow.Text; 
				dr["nNumberCasesNumber"]=txtCasesNumber.Text;
				dr["nNumberQuestionNumber"]=txtQuestionNumber.Text;
				dr["nNumberclassNumber"]=txtclassNumber.Text;
				dr["nNumberColNumber"]=txtColNumber.Text;
				dr["nNumberStudentNumber"]=txtStudentNumber.Text;
				dr["nNumberAzmunNumber"]=txtAzmunNumber.Text;
			
				dr["nNumberTeacherNumber"]=txtTeacherNumber.Text;
				dr["nNumberOfTotalQuestions"]=txtNumberOfTotalQuestions.Text;
				dr["nNumberOfTopLayout"]=txtTopLayoutNumber.Text;	
				dr["nNumberOfLeftLayout"]=txtLeftLayoutNumber.Text;
				dr["str1VarName"]=txt1VarName.Text;
				dr["str2VarName"]=txt2VarName.Text; 
				dr["str3VarName"]=txt3VarName.Text;
				dr["str4VarName"]=txt4VarName.Text;
				dr["str5VarName"]=txt5VarName.Text;				
				dr["QuestionsDir"]=radioQLeftToRight.Checked;
				dr["CasesDir"]=radioCLeftToRight.Checked;
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		void AddNewDataRowToTemplates()
		{
			try
			{
				System.Data.DataRow dr=ds.Tables["Tamplates"].NewRow();
				dr["templateName"]=txtFormName.Text;
				dr["nNumber1Col"]=txt1Col.Text;;
				dr["nNumber1Row"]=txt1Row.Text;			
				dr["nNumber2Row"]=txt2Row.Text;
				dr["nNumber2Col"]=txt2Col.Text;
				dr["nNumber3Row"]=txt3Row.Text;
				dr["nNumber3Col"]=txt3Col.Text;
				dr["nNumber4Row"]=txt4Row.Text;
				dr["nNumber4Col"]=txt4Col.Text;
				dr["nNumber5Row"]=txt5Row.Text;
				dr["nNumber5Col"]=txt5Col.Text;
				dr["nNumber1Digits"]=txt1Digits.Text;
				dr["nNumber2Digits"]=txt2Digits.Text; 
				dr["nNumber3Digits"]=txt3Digits.Text;
				dr["nNumber4Digits"]=txt4Digits.Text;
				dr["nNumber5Digits"]=txt5Digits.Text;
				dr["nNumber1Cases"]=txt1Cases.Text; 
				dr["nNumber2Cases"]=txt2Cases.Text;
				dr["nNumber3Cases"]=txt3Cases.Text;
				dr["nNumber4Cases"]=txt4Cases.Text;
				dr["nNumber5Cases"]=txt5Cases.Text;
				dr["nNumberColDistance"]=txtColDistance.Text;
				dr["nNumberClassDistance"]=txtClassDistance.Text;
				dr["nNumberHorDistance"]=txtHorDistance.Text; 
				dr["nNumberVerDistance"]=txtVerDistance.Text;
				dr["nNumberFirstCol"]=txtFirstCol.Text;
				dr["nNumberFirstRow"]=txtFirstRow.Text; 
				dr["nNumberCasesNumber"]=txtCasesNumber.Text;
				dr["nNumberQuestionNumber"]=txtQuestionNumber.Text;
				dr["nNumberclassNumber"]=txtclassNumber.Text;
				dr["nNumberColNumber"]=txtColNumber.Text;
				dr["nNumberStudentNumber"]=txtStudentNumber.Text;
				dr["nNumberAzmunNumber"]=txtAzmunNumber.Text;
			
				dr["nNumberTeacherNumber"]=txtTeacherNumber.Text;
				dr["nNumberOfTotalQuestions"]=txtNumberOfTotalQuestions.Text;
				dr["nNumberOfTopLayout"]=txtTopLayoutNumber.Text;	
				dr["nNumberOfLeftLayout"]=txtLeftLayoutNumber.Text;
				dr["str1VarName"]=txt1VarName.Text;
				dr["str2VarName"]=txt2VarName.Text; 
				dr["str3VarName"]=txt3VarName.Text;
				dr["str4VarName"]=txt4VarName.Text;
				dr["str5VarName"]=txt5VarName.Text;				
				dr["QuestionsDir"]=radioQLeftToRight.Checked;
				dr["CasesDir"]=radioCLeftToRight.Checked;
				ds.Tables["Tamplates"].Rows.Add(dr);
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		private	void txtTeacherNumber_Enter(object sender, System.EventArgs	e)
		{
			GroupBox prnt=(GroupBox)((TextBox)sender).Parent;
			picSelect1.Location=new	Point( picSelect1.Location.X,((TextBox )sender).Location.Y+prnt.Location.Y -((TextBox )sender).Height/2);
			
		}


		void ApplyChanges()
		{
			try
			{
				nNumber1Cases	=int.Parse(txt1Cases.Text );
				nNumber1Col		=int.Parse(txt1Col.Text	);
				nNumber1Digits	=int.Parse(txt1Digits.Text );
				nNumber1Row		=int.Parse(txt1Row.Text	);
				nNumber2Cases	=int.Parse(txt2Cases.Text );
				nNumber2Col		=int.Parse(txt2Col.Text	);
				nNumber2Digits	=int.Parse(txt2Digits.Text );
				nNumber2Row		=int.Parse(txt2Row.Text	);
				nNumber3Cases	=int.Parse(txt3Cases.Text );
				nNumber3Col		=int.Parse(txt3Col.Text	);
				nNumber3Digits	=int.Parse(txt3Digits.Text );
				nNumber3Row		=int.Parse(txt3Row.Text	);
				nNumber4Cases	=int.Parse(txt4Cases.Text );
				nNumber4Col		=int.Parse(txt4Col.Text	);
				nNumber4Digits	=int.Parse(txt4Digits.Text );
				nNumber4Row		=int.Parse(txt4Row.Text	);
				nNumber5Cases	=int.Parse(txt5Cases.Text );
				nNumber5Col		=int.Parse(txt5Col.Text	);			
				nNumber5Digits	=int.Parse(txt5Digits.Text );
				nNumber5Row		=int.Parse(txt5Row.Text	);

			
				nNumberCasesNumber		=int.Parse(txtCasesNumber.Text );
				nNumberClassDistance	=int.Parse(txtClassDistance.Text );
				nNumberclassNumber		=int.Parse(txtclassNumber.Text );
				nNumberColNumber		=int.Parse(txtColNumber.Text );
				nNumberColDistance		=int.Parse(txtColDistance.Text );
				//nNumberColQuestionNumber=int.Parse(txtColQuestionNumber.Text );
				nNumberFirstCol			=int.Parse(txtFirstCol.Text	);
				nNumberFirstRow			=int.Parse(txtFirstRow.Text	);
				nNumberHorDistance		=int.Parse(txtHorDistance.Text );
				nNumberOfLeftLayout		=int.Parse(txtLeftLayoutNumber.Text	);
				nNumberOfTopLayout		=int.Parse(txtTopLayoutNumber.Text );
				nNumberQuestionNumber	=int.Parse(txtQuestionNumber.Text );
				nNumberOfTotalQuestions =int.Parse(txtNumberOfTotalQuestions.Text );
				nNumberVerDistance		=int.Parse(txtVerDistance.Text );
				str1VarName=txt1VarName.Text;
				str2VarName=txt2VarName.Text;
				str3VarName=txt3VarName.Text;
				str4VarName=txt4VarName.Text;
				str5VarName=txt5VarName.Text;
				//validating of	DisplayForm's Static Members
				
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		private	void pageTestSettings_Validated(object sender, System.EventArgs	e)
		{
			ApplyChanges();
			//MessageBox.Show("  €ÌÌ—«  œ—  ‰ŸÌ„«  ’›ÕÂ ¬“„Ê‰ «⁄„«· ŒÊ«Âœ ‘œ");
		}



		private	void menuItem1_Select(object sender, System.EventArgs e)
		{
			ApplyChanges();
			ApplyCodeSettings();
		}
		void ApplyCodeSettings()
		{
			try
			{
				nNumberAzmunNumber		=int.Parse(txtAzmunNumber.Text );
				nNumberStudentNumber	=int.Parse(txtStudentNumber.Text );
				nNumberTeacherNumber	=int.Parse(txtTeacherNumber.Text );
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		private	void pageCodeSettings_Validated(object sender, System.EventArgs	e)
		{
			ApplyCodeSettings();
		}

		private	void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(ds2.Tables.Contains("results"))
				{
					int row=dataGrid.CurrentCell.RowNumber ;
					int col=dataGrid.CurrentCell.ColumnNumber;
					strTempResults=ds2.Tables["results"].Rows[row]["TempResults"].ToString();
					strFinalResults=ds2.Tables["results"].Rows[row]["FinalResults"].ToString();
					if(strFinalResults!="" && strTempResults != "")
					{
						ReadResultsString();
						frmDisplayForm = new DisplayForm();
						//frmDisplayForm.frmPaernt=this;
						
						frmDisplayForm.Show();
					}				
				
				}
				else
				{
					MessageBox.Show("·ÿ›« ﬁ»· «“ ‰„«Ì‘° Õœ«ﬁ· Ìò ›—„ —«  Ê”ÿ »—‰«„Â Å—œ«“‘ ‰„«ÌÌœ");
				}
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}


		private void comboreadMethod_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if(comboreadMethod.SelectedIndex == 1 )
			{
				bReadColorized = true;
				lblThr.Visible=true;
				trkThr.Visible=true;
			}
			else
			{
				bReadColorized = false;
				lblThr.Visible=false;
				trkThr.Visible=false;
			}
		}

		private void trkThr_Scroll(object sender, System.EventArgs e)
		{
			nDarkPointThr = trkThr.Value;
			lblDarkPointThr.Text=nDarkPointThr.ToString();
		}

		private void btnSaveTemplate_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(txtFormName.Text=="")
				{
					MessageBox.Show(" ·ÿ›« ‰«„ ›—„ —« Ê«—œ ‰„«ÌÌœ");
					return;
				}
				AddNewDataRowToTemplates();
				da.Update(ds,"Tamplates");
				ReadFromDataset();
				MessageBox.Show(" –ŒÌ—Â ¬Ì „ ÃœÌœ «‰Ã«„ ‘œ");
			}
			catch(Exception ex){MessageBox.Show("‰«„ ›—„  ò—«—Ì” °·ÿ›« Ìò ‰«„ ÃœÌœ Ê«—œ ‰„«ÌÌœ" +ex.Message );}
		}

		private void comboFormName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ReadDataRow(ds.Tables["Tamplates"].Rows[comboFormName.SelectedIndex]);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				/*if(txtFormName.Text=="")
				{
					MessageBox.Show(" ·ÿ›« ‰«„ ›—„ —« Ê«—œ ‰„«ÌÌœ");
					return;
				}*/
				int selIndex=comboFormName.SelectedIndex;
				UpdateDataRow(ds.Tables["Tamplates"].Rows[selIndex]);
				da.Update(ds,"Tamplates");
				ReadFromDataset();
				comboFormName.SelectedIndex=selIndex;
				txtFormName.Text="";
				MessageBox.Show("  €ÌÌ—«  «‰Ã«„ ‘œ");
			}
			catch(Exception ex){MessageBox.Show(" €ÌÌ—«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}


		private void button3_Click(object sender, System.EventArgs e)
		{
			ReadResultsFromDB();
			dataGrid.DataSource=ds2.Tables["results"];

			
		}



		private void menuItemDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				DeleteTotalRowsFromDB();
				ds2.Tables["results"].Rows.Clear();
				dataGrid.Refresh();
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}

		private void picPathButton_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog of=new OpenFileDialog();
			if(of.ShowDialog()==DialogResult.OK )
			{
				strOutputPath = of.FileName;
				txtPath.Text =strOutputPath;
			}
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.Open();
				if(ds2.Tables.Contains("results"))da2.Update(ds2,"results");
				conn.Close();
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}

		private void dataGrid_CurrentCellChanged(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar==13)
			{

			}
		}

		private void menuItem7_Click_1(object sender, System.EventArgs e)
		{
			if(ds2.Tables.Contains("results"))
			{
				string strOut="";
				DataTable tbl= ds2.Tables["results"];
				int rowCount=ds2.Tables["results"].Rows.Count;
				if(strOutputPath!=null && strOutputPath !="" )
				{
					try
					{
						TextWriter tw=new StreamWriter(strOutputPath);
						for(int i=0;i<rowCount;i++)
						{
							strOut =tbl.Rows[i][1].ToString()+tbl.Rows[i]["FinalResults"].ToString()+"\n";
							tw.WriteLine(strOut);
						}						
						tw.Close();
						MessageBox.Show("⁄„·Ì«  »« „ÊﬁÌ  «‰Ã«„ ‘œ");
					}
					catch(Exception ex){MessageBox.Show("⁄„·Ì«  »« „ÊﬁÌ  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ"+ex.Message );}
				}
				else
					MessageBox.Show("·ÿ›« œ— ’›ÕÂ  ‰ŸÌ„«  ‘ÌÊÂ ŒÊ«‰œ‰ Ê –ŒÌ—Â Ìò „”Ì— Œ—ÊÃÌ «‰ Œ«» ‰„«ÌÌœ");
			}
			else
					MessageBox.Show("·ÿ›« «ÿ·«⁄«  —« «“ Å«Ìê«Â œ«œÂ ·Êœ ‰„«ÌÌœ");
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				int selIndex=comboFormName.SelectedIndex;
				ds.Tables["Tamplates"].Rows[selIndex].Delete();
				da.Update(ds,"Tamplates");
				ReadFromDataset();
				comboFormName.SelectedIndex=selIndex;
				txtFormName.Text="";
				MessageBox.Show(" Õ–› «‰Ã«„ ‘œ");
			}
			catch(Exception ex){MessageBox.Show(" €ÌÌ—«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}

		}

		private void radioCodes_CheckedChanged(object sender, System.EventArgs e)
		{
			bAzmunNumber=radioTest.Checked;
			bTeacherNumber =radioTeacher.Checked;
			bStudentNumber=radioStudent.Checked;
			bTestOmit=radioTestOmit.Checked;
		}
		void ReadFromDataset()
		{
			try
			{
				comboFormName.Items.Clear();
				if(ds.Tables.Contains("Tamplates"))
					ds.Tables["Tamplates"].Rows.Clear ();
				conn.Open();
				da.Fill(ds,"Tamplates");
				conn.Close();
				if(ds.Tables["Tamplates"].Rows.Count>0)
				{
					System.Data.DataRow dr= ds.Tables["Tamplates"].Rows[0];
					ReadDataRow	(dr);
					for(int i = 0 ; i<ds.Tables["Tamplates"].Rows.Count ;i++)
					{
						comboFormName.Items.Add(ds.Tables["Tamplates"].Rows[i][0].ToString());
					}
					comboFormName.Text=ds.Tables["Tamplates"].Rows[0][0].ToString();
				}			
			}
			catch(Exception ex){MessageBox.Show("⁄„·Ì«  «‰Ã«„ ‰‘œ°·ÿ›« »« ê—ÊÂ Å‘ Ì»«‰Ì  „«” »êÌ—Ìœ" );MessageBox.Show(ex.Message );}
		}
		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
		
		}





	












	}
}

