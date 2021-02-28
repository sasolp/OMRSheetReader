using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing.Imaging;
using System.Data.OleDb;
using System.Runtime.InteropServices;
namespace BinaryFormReader
{
	/// <summary>
	/// Summary description for OrginalForm.
	/// </summary>
	
	public class OrginalForm : System.Windows.Forms.Form
	{
		[DllImport("user32.dll")]
		protected static extern int  CreateCaret(
			IntPtr hWnd, 
			IntPtr hBitmap, 
			int nWidth, 
			int nHeight
			); 
		[DllImport("user32.dll")]
		protected static extern int  ShowCaret(
			IntPtr  hWnd
			); 
		[DllImport("user32.dll")]
		protected static extern int  HideCaret(
			IntPtr  hWnd
			); 
		[DllImport("user32.dll")]
		protected static extern int   SetCaretPos(
			int X, 
			int Y
			);
		#region Variables
		private static string []arrErrorStrings={"بيش از حد بالا يا چرخش زياد",
													"بيش از حد پايين يا چرخش زياد",
													"بيش از حد چپ","بيش از حد راست",
													"بيش از حد داراي اعوجاج",
													"پيدا نشدن مارجين راست يا چپ در بالاي صفحه",
													"خطا در کد متغير اول",
													"تفاوت در نوع فرم با الگو",
													"خراب در حاشيه و داراي شکل نا فرم",
													"خطا در کد متغير دوم",
													"فرم تکراریست"};
		Image img;
		StatusBarPanel statusBarPanels4;
		string strPath;
		TempForm tf;
		private int nDownSectionY;
		private Rectangle  [,]arrCaseLables;
		private Rectangle  [,]arrQuestionSCases;
		private int			[,]arrCasesState;
		private ArrayList arrValPaths;
		private ArrayList arrErrPaths;
		private ArrayList arrValCodes;
		private ArrayList arrErrCodes;
		private ArrayList filesPaths;
		string strTemplateName;
		string strFinalResults;
		string strSavedResult;
		string strTopFormResults;
		string strStuderntsResultPath;
		string strChortsResultPath;
		string strAnswerPageResultPath;
		int    nWeakCellCount;
		string[] arrFilesPathes;
		float     nBrightThreshold;
		int		nFilesCount;
		int     nFormType;
		bool bContinue;
		bool bOrginalDispaly ;
		bool bDisplayInPaiont;
		bool bStartCorrection;
		bool bIsBusy;
		bool bStartFromMiddle;
		bool SaveFlag;
		bool bBottomLayout;
		bool bA5;
		bool bSubFolders;
		long nNumberFixNumber;
		bool bNoNumberIsOk;
		bool bPerformaneIsOk;
		bool bReachedResultsIsOk;

		bool	bVerdict	;					
		int panelCounter;
		string strTempResults;
		public int rowIndex;	
		DisplayForm	frmDisplayForm;
		int formCounter;
		long nAzmunCounter;
		long nStudentCounter;
		bool	[,]FinalResults;
		bool	[,]TempResults;
		int []arrNumbers;
		int [,]arrRowNumbers;
		bool bReadColorized;
		bool bTestOmit;
		bool bAzmunNumber;
		bool bTeacherNumber;
		bool bStudentNumber;
		int nDarkPointThr;
		int nCodeDarkPointThr;
		byte [,]pixeles;	
		int	[,]arrDistance;
		int		[,]startPoints;
		int	cellSize;
		int	pageSize;
		float cellPad;
		int		startX;
		int		startY;
		int		startXRight;
		int	[,]Results;
		int	[,]TopFormResults;

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
		long	nNumberStudentNumber;
		long	nNumberAzmunNumber;
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
		#endregion
		#region OLEDB Variables
		OleDbCommandBuilder cmdBuilder;
		OleDbCommand command;
		OleDbConnection conn;
		OleDbDataAdapter da;
		DataSet ds;
		OleDbCommandBuilder cmdBuilderResults;
		
		OleDbDataAdapter daResults;
		DataSet dsResults;
		OleDbCommandBuilder cmdBuilderPaths;
		OleDbDataAdapter daErrResult;
		DataSet dsErrResult;
		OleDbCommandBuilder cmdBuilderErrResult;
		OleDbDataAdapter daPaths;
		DataSet dsPaths;

		OleDbCommandBuilder cmdBuilderTempResults;
		OleDbDataAdapter daTempResults;
		DataSet dsTempResults;
		#endregion
		#region Form Variables
		private System.Windows.Forms.PictureBox pictureBox13;
		private System.Windows.Forms.ToolTip toolTipGlobal;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
		private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.ContextMenu conMnu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.GroupBox groupReadMethod;
		private System.Windows.Forms.Label lblThr;
		private System.Windows.Forms.TrackBar trkThr;
		private System.Windows.Forms.Label lblColorSence;
		private System.Windows.Forms.Label lblSence;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar trkSence;
		private System.Windows.Forms.ComboBox comboreadMethod;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblDarkPointThr;
		private System.Windows.Forms.PictureBox picColInRecord;
		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.ListBox listFiles;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnSaveTemplate;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.GroupBox groupBox16;
		private System.Windows.Forms.PictureBox pictureBox14;
		private System.Windows.Forms.RadioButton radioCRightToLeft;
		private System.Windows.Forms.RadioButton radioCLeftToRight;
		private System.Windows.Forms.PictureBox pictureBox15;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.PictureBox pictureBox11;
		private System.Windows.Forms.PictureBox pictureBox9;
		private System.Windows.Forms.RadioButton radioQRightToLeft;
		private System.Windows.Forms.RadioButton radioQLeftToRight;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.TextBox txtNumberOfTotalQuestions;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtTopLayoutNumber;
		private System.Windows.Forms.TextBox txtLeftLayoutNumber;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtColDistance;
		private System.Windows.Forms.TextBox txtClassDistance;
		private System.Windows.Forms.TextBox txtHorDistance;
		private System.Windows.Forms.TextBox txtVerDistance;
		private System.Windows.Forms.TextBox txtFirstCol;
		private System.Windows.Forms.TextBox txtFirstRow;
		private System.Windows.Forms.TextBox txtCasesNumber;
		private System.Windows.Forms.TextBox txtQuestionNumber;
		private System.Windows.Forms.TextBox txtclassNumber;
		private System.Windows.Forms.TextBox txtColNumber;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.TextBox txt5VarName;
		private System.Windows.Forms.TextBox txt5Digits;
		private System.Windows.Forms.TextBox txt5Cases;
		private System.Windows.Forms.TextBox txt5Row;
		private System.Windows.Forms.TextBox txt5Col;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.TextBox txt4VarName;
		private System.Windows.Forms.TextBox txt4Digits;
		private System.Windows.Forms.TextBox txt4Cases;
		private System.Windows.Forms.TextBox txt4Row;
		private System.Windows.Forms.TextBox txt4Col;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.TextBox txt3VarName;
		private System.Windows.Forms.TextBox txt3Digits;
		private System.Windows.Forms.TextBox txt3Cases;
		private System.Windows.Forms.TextBox txt3Row;
		private System.Windows.Forms.TextBox txt3Col;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox txt2VarName;
		private System.Windows.Forms.TextBox txt2Digits;
		private System.Windows.Forms.TextBox txt2Cases;
		private System.Windows.Forms.TextBox txt2Row;
		private System.Windows.Forms.TextBox txt2Col;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.TextBox txt1VarName;
		private System.Windows.Forms.TextBox txt1Digits;
		private System.Windows.Forms.TextBox txt1Cases;
		private System.Windows.Forms.TextBox txt1Row;
		private System.Windows.Forms.TextBox txt1Col;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Panel panelPageSettings;
		private System.Windows.Forms.GroupBox groupPath;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.TextBox txtOutPutFileName;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.Panel panelOutPutSettings;
		private System.Windows.Forms.Panel panelAnalyze;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGrid dataGrid;
		private System.Windows.Forms.Panel panelPaint;
		private System.Windows.Forms.TextBox txtTestFormName;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox groupMain;
		private System.Windows.Forms.Panel panelPerformanceStatus;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.DataGrid dataGridErrList;
		private System.Windows.Forms.PictureBox pictureBox12;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.TextBox txtFixNumber;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.PictureBox pic13;
		private System.Windows.Forms.CheckBox chkBottomLayout;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.ComboBox combSubjects;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.CheckBox chkStartFromMiddle;
		private System.Windows.Forms.TrackBar trkGreen;
		private System.Windows.Forms.TrackBar trkBlue;
		private System.Windows.Forms.TrackBar trkRed;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label lblRed;
		private System.Windows.Forms.Label lblGreen;
		private System.Windows.Forms.Label lblBlue;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Panel panelColorSettings;
		#endregion
		private System.Windows.Forms.ContextMenu contextMenu;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ComboBox comboPageType;
		private System.Windows.Forms.StatusBarPanel statusBarPanel5;
		private System.Windows.Forms.StatusBarPanel statusBarPanel6;
		private System.Windows.Forms.PictureBox pictureBox16;
		private System.Windows.Forms.PictureBox pictureBox17;
		private System.Windows.Forms.PictureBox pictureBox19;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.TextBox txtSearchParam;
		private System.Windows.Forms.Label lblWeakPoints;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.PictureBox pictureBox18;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ListBox listOutPutFiles;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.ComboBox comboFormType;
		private System.Windows.Forms.Panel panelNonCounterDisplay;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGrid dgCounter;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkDisplay;
		private System.Windows.Forms.CheckBox chkDisplayInPaint;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.Label lblCodeDarkPoints;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.TrackBar trkCodeDarkPoints;
		private System.Windows.Forms.PictureBox picNoNumbers;
		private System.Windows.Forms.Label lblNoNumbers;
		private System.Windows.Forms.PictureBox picReachedResults;
		private System.Windows.Forms.Label lblReachedResults;
		private System.Windows.Forms.PictureBox picPerformaneStatus;
		private System.Windows.Forms.Label lblPerformaneStatus;
		private System.Windows.Forms.CheckBox chkSubFolders;
		private System.Windows.Forms.Label lblNoNumbersO;
		private System.Windows.Forms.Label lblReachedResultsO;
		private System.Windows.Forms.Label lblPerformaneStatusO;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkPaint2;
		private System.Windows.Forms.CheckBox chkDisplay2;
		private System.Windows.Forms.Label lblNumberOfTotal;
		private System.Windows.Forms.PictureBox pictureBox7;

		private System.ComponentModel.IContainer components;

		public OrginalForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OrginalForm));
			this.groupMain = new System.Windows.Forms.GroupBox();
			this.lblNumberOfTotal = new System.Windows.Forms.Label();
			this.picNoNumbers = new System.Windows.Forms.PictureBox();
			this.lblNoNumbers = new System.Windows.Forms.Label();
			this.picReachedResults = new System.Windows.Forms.PictureBox();
			this.lblReachedResults = new System.Windows.Forms.Label();
			this.lblPerformaneStatus = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkDisplayInPaint = new System.Windows.Forms.CheckBox();
			this.chkDisplay = new System.Windows.Forms.CheckBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.lblNoNumbersO = new System.Windows.Forms.Label();
			this.comboFormType = new System.Windows.Forms.ComboBox();
			this.label53 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblPath = new System.Windows.Forms.Label();
			this.picColInRecord = new System.Windows.Forms.PictureBox();
			this.listFiles = new System.Windows.Forms.ListBox();
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
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
			this.lblCodeDarkPoints = new System.Windows.Forms.Label();
			this.label66 = new System.Windows.Forms.Label();
			this.trkCodeDarkPoints = new System.Windows.Forms.TrackBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lblReachedResultsO = new System.Windows.Forms.Label();
			this.lblPerformaneStatusO = new System.Windows.Forms.Label();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.conMnu = new System.Windows.Forms.ContextMenu();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.pictureBox12 = new System.Windows.Forms.PictureBox();
			this.label54 = new System.Windows.Forms.Label();
			this.pic13 = new System.Windows.Forms.PictureBox();
			this.label57 = new System.Windows.Forms.Label();
			this.pictureBox13 = new System.Windows.Forms.PictureBox();
			this.pictureBox16 = new System.Windows.Forms.PictureBox();
			this.chkSubFolders = new System.Windows.Forms.CheckBox();
			this.pictureBox7 = new System.Windows.Forms.PictureBox();
			this.picPerformaneStatus = new System.Windows.Forms.PictureBox();
			this.panelPageSettings = new System.Windows.Forms.Panel();
			this.comboPageType = new System.Windows.Forms.ComboBox();
			this.combSubjects = new System.Windows.Forms.ComboBox();
			this.label58 = new System.Windows.Forms.Label();
			this.txtFixNumber = new System.Windows.Forms.TextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtTestFormName = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.btnSaveTemplate = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.label34 = new System.Windows.Forms.Label();
			this.groupBox16 = new System.Windows.Forms.GroupBox();
			this.pictureBox14 = new System.Windows.Forms.PictureBox();
			this.radioCRightToLeft = new System.Windows.Forms.RadioButton();
			this.radioCLeftToRight = new System.Windows.Forms.RadioButton();
			this.pictureBox15 = new System.Windows.Forms.PictureBox();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.pictureBox11 = new System.Windows.Forms.PictureBox();
			this.pictureBox9 = new System.Windows.Forms.PictureBox();
			this.radioQRightToLeft = new System.Windows.Forms.RadioButton();
			this.radioQLeftToRight = new System.Windows.Forms.RadioButton();
			this.label33 = new System.Windows.Forms.Label();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.chkBottomLayout = new System.Windows.Forms.CheckBox();
			this.txtNumberOfTotalQuestions = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtTopLayoutNumber = new System.Windows.Forms.TextBox();
			this.txtLeftLayoutNumber = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
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
			this.chkStartFromMiddle = new System.Windows.Forms.CheckBox();
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
			this.label35 = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.label59 = new System.Windows.Forms.Label();
			this.panelOutPutSettings = new System.Windows.Forms.Panel();
			this.groupPath = new System.Windows.Forms.GroupBox();
			this.pictureBox17 = new System.Windows.Forms.PictureBox();
			this.label50 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.label51 = new System.Windows.Forms.Label();
			this.txtOutPutFileName = new System.Windows.Forms.TextBox();
			this.label52 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.listOutPutFiles = new System.Windows.Forms.ListBox();
			this.pictureBox18 = new System.Windows.Forms.PictureBox();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel5 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel6 = new System.Windows.Forms.StatusBarPanel();
			this.panelAnalyze = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkPaint2 = new System.Windows.Forms.CheckBox();
			this.chkDisplay2 = new System.Windows.Forms.CheckBox();
			this.lblWeakPoints = new System.Windows.Forms.Label();
			this.label63 = new System.Windows.Forms.Label();
			this.pictureBox19 = new System.Windows.Forms.PictureBox();
			this.txtSearchParam = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.lbl = new System.Windows.Forms.Label();
			this.dgCounter = new System.Windows.Forms.DataGrid();
			this.panelPaint = new System.Windows.Forms.Panel();
			this.label46 = new System.Windows.Forms.Label();
			this.panelPerformanceStatus = new System.Windows.Forms.Panel();
			this.button7 = new System.Windows.Forms.Button();
			this.dataGridErrList = new System.Windows.Forms.DataGrid();
			this.panelColorSettings = new System.Windows.Forms.Panel();
			this.label62 = new System.Windows.Forms.Label();
			this.lblRed = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.trkRed = new System.Windows.Forms.TrackBar();
			this.trkGreen = new System.Windows.Forms.TrackBar();
			this.trkBlue = new System.Windows.Forms.TrackBar();
			this.label60 = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.lblGreen = new System.Windows.Forms.Label();
			this.lblBlue = new System.Windows.Forms.Label();
			this.toolTipGlobal = new System.Windows.Forms.ToolTip(this.components);
			this.panelNonCounterDisplay = new System.Windows.Forms.Panel();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.groupMain.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupReadMethod.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkThr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkSence)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkCodeDarkPoints)).BeginInit();
			this.panelPageSettings.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox16.SuspendLayout();
			this.groupBox15.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.panelOutPutSettings.SuspendLayout();
			this.groupPath.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel6)).BeginInit();
			this.panelAnalyze.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgCounter)).BeginInit();
			this.panelPaint.SuspendLayout();
			this.panelPerformanceStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridErrList)).BeginInit();
			this.panelColorSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkRed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkBlue)).BeginInit();
			this.panelNonCounterDisplay.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupMain
			// 
			this.groupMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupMain.Controls.Add(this.lblNumberOfTotal);
			this.groupMain.Controls.Add(this.picNoNumbers);
			this.groupMain.Controls.Add(this.lblNoNumbers);
			this.groupMain.Controls.Add(this.picReachedResults);
			this.groupMain.Controls.Add(this.lblReachedResults);
			this.groupMain.Controls.Add(this.lblPerformaneStatus);
			this.groupMain.Controls.Add(this.groupBox1);
			this.groupMain.Controls.Add(this.pictureBox6);
			this.groupMain.Controls.Add(this.lblNoNumbersO);
			this.groupMain.Controls.Add(this.comboFormType);
			this.groupMain.Controls.Add(this.label53);
			this.groupMain.Controls.Add(this.label3);
			this.groupMain.Controls.Add(this.lblPath);
			this.groupMain.Controls.Add(this.picColInRecord);
			this.groupMain.Controls.Add(this.listFiles);
			this.groupMain.Controls.Add(this.groupReadMethod);
			this.groupMain.Controls.Add(this.pictureBox1);
			this.groupMain.Controls.Add(this.pictureBox2);
			this.groupMain.Controls.Add(this.pictureBox3);
			this.groupMain.Controls.Add(this.label4);
			this.groupMain.Controls.Add(this.lblReachedResultsO);
			this.groupMain.Controls.Add(this.lblPerformaneStatusO);
			this.groupMain.Controls.Add(this.pictureBox4);
			this.groupMain.Controls.Add(this.pictureBox5);
			this.groupMain.Controls.Add(this.pictureBox12);
			this.groupMain.Controls.Add(this.label54);
			this.groupMain.Controls.Add(this.pic13);
			this.groupMain.Controls.Add(this.label57);
			this.groupMain.Controls.Add(this.pictureBox13);
			this.groupMain.Controls.Add(this.pictureBox16);
			this.groupMain.Controls.Add(this.chkSubFolders);
			this.groupMain.Controls.Add(this.pictureBox7);
			this.groupMain.Controls.Add(this.picPerformaneStatus);
			this.groupMain.Location = new System.Drawing.Point(349, 0);
			this.groupMain.Name = "groupMain";
			this.groupMain.Size = new System.Drawing.Size(320, 1307);
			this.groupMain.TabIndex = 0;
			this.groupMain.TabStop = false;
			this.groupMain.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// lblNumberOfTotal
			// 
			this.lblNumberOfTotal.ForeColor = System.Drawing.Color.Navy;
			this.lblNumberOfTotal.Location = new System.Drawing.Point(216, 264);
			this.lblNumberOfTotal.Name = "lblNumberOfTotal";
			this.lblNumberOfTotal.Size = new System.Drawing.Size(48, 24);
			this.lblNumberOfTotal.TabIndex = 44;
			// 
			// picNoNumbers
			// 
			this.picNoNumbers.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picNoNumbers.Image = ((System.Drawing.Image)(resources.GetObject("picNoNumbers.Image")));
			this.picNoNumbers.Location = new System.Drawing.Point(144, 360);
			this.picNoNumbers.Name = "picNoNumbers";
			this.picNoNumbers.Size = new System.Drawing.Size(32, 40);
			this.picNoNumbers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picNoNumbers.TabIndex = 42;
			this.picNoNumbers.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.picNoNumbers, "دیدن فایلهای خطادار و توضیح مربوطه و به عبارت دیگر دیدن وضعیت عملکرد، روی این گزی" +
				"نه کلیک نمایید ");
			// 
			// lblNoNumbers
			// 
			this.lblNoNumbers.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblNoNumbers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.lblNoNumbers.ForeColor = System.Drawing.Color.DarkOliveGreen;
			this.lblNoNumbers.Location = new System.Drawing.Point(8, 376);
			this.lblNoNumbers.Name = "lblNoNumbers";
			this.lblNoNumbers.Size = new System.Drawing.Size(128, 16);
			this.lblNoNumbers.TabIndex = 43;
			this.lblNoNumbers.Text = "برگه های بدون شماره";
			this.toolTipGlobal.SetToolTip(this.lblNoNumbers, "دیدن فایلهای خطادار و توضیح مربوطه و به عبارت دیگر دیدن وضعیت عملکرد، روی این گزی" +
				"نه کلیک نمایید ");
			// 
			// picReachedResults
			// 
			this.picReachedResults.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picReachedResults.Image = ((System.Drawing.Image)(resources.GetObject("picReachedResults.Image")));
			this.picReachedResults.Location = new System.Drawing.Point(144, 288);
			this.picReachedResults.Name = "picReachedResults";
			this.picReachedResults.Size = new System.Drawing.Size(32, 40);
			this.picReachedResults.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picReachedResults.TabIndex = 38;
			this.picReachedResults.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.picReachedResults, "دیدن فایلهای خطادار و توضیح مربوطه و به عبارت دیگر دیدن وضعیت عملکرد، روی این گزی" +
				"نه کلیک نمایید ");
			// 
			// lblReachedResults
			// 
			this.lblReachedResults.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblReachedResults.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.lblReachedResults.ForeColor = System.Drawing.Color.DarkOliveGreen;
			this.lblReachedResults.Location = new System.Drawing.Point(8, 312);
			this.lblReachedResults.Name = "lblReachedResults";
			this.lblReachedResults.Size = new System.Drawing.Size(128, 16);
			this.lblReachedResults.TabIndex = 41;
			this.lblReachedResults.Text = "نتايج بدست آمده";
			this.toolTipGlobal.SetToolTip(this.lblReachedResults, "دیدن فایلهای خطادار و توضیح مربوطه و به عبارت دیگر دیدن وضعیت عملکرد، روی این گزی" +
				"نه کلیک نمایید ");
			// 
			// lblPerformaneStatus
			// 
			this.lblPerformaneStatus.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblPerformaneStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.lblPerformaneStatus.ForeColor = System.Drawing.Color.DarkOliveGreen;
			this.lblPerformaneStatus.Location = new System.Drawing.Point(8, 344);
			this.lblPerformaneStatus.Name = "lblPerformaneStatus";
			this.lblPerformaneStatus.Size = new System.Drawing.Size(128, 16);
			this.lblPerformaneStatus.TabIndex = 40;
			this.lblPerformaneStatus.Text = "وضعيت عملکرد";
			this.toolTipGlobal.SetToolTip(this.lblPerformaneStatus, "جهت ذخیره نتایج در یک فایل متنی روی این گزینه کلیک نمایید ");
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkDisplayInPaint);
			this.groupBox1.Controls.Add(this.chkDisplay);
			this.groupBox1.Location = new System.Drawing.Point(192, 320);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(112, 72);
			this.groupBox1.TabIndex = 37;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "نحوه نمایش ";
			// 
			// chkDisplayInPaint
			// 
			this.chkDisplayInPaint.Location = new System.Drawing.Point(8, 48);
			this.chkDisplayInPaint.Name = "chkDisplayInPaint";
			this.chkDisplayInPaint.Size = new System.Drawing.Size(96, 16);
			this.chkDisplayInPaint.TabIndex = 1;
			this.chkDisplayInPaint.Text = "ویرایش در Paint";
			this.chkDisplayInPaint.CheckedChanged += new System.EventHandler(this.chkDisplayInPaint_CheckedChanged);
			// 
			// chkDisplay
			// 
			this.chkDisplay.Location = new System.Drawing.Point(8, 24);
			this.chkDisplay.Name = "chkDisplay";
			this.chkDisplay.Size = new System.Drawing.Size(96, 16);
			this.chkDisplay.TabIndex = 0;
			this.chkDisplay.Text = "نمایش جداگانه";
			this.chkDisplay.CheckedChanged += new System.EventHandler(this.chkDisplay_CheckedChanged);
			// 
			// pictureBox6
			// 
			this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
			this.pictureBox6.Location = new System.Drawing.Point(144, 624);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(40, 32);
			this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox6.TabIndex = 35;
			this.pictureBox6.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox6, "دیدن فایلهای خطادار و توضیح مربوطه و به عبارت دیگر دیدن وضعیت عملکرد، روی این گزی" +
				"نه کلیک نمایید ");
			this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
			// 
			// lblNoNumbersO
			// 
			this.lblNoNumbersO.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblNoNumbersO.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.lblNoNumbersO.Location = new System.Drawing.Point(8, 632);
			this.lblNoNumbersO.Name = "lblNoNumbersO";
			this.lblNoNumbersO.Size = new System.Drawing.Size(128, 24);
			this.lblNoNumbersO.TabIndex = 36;
			this.lblNoNumbersO.Text = "مشاهده برگه های بدون شماره(0)";
			this.toolTipGlobal.SetToolTip(this.lblNoNumbersO, "دیدن فایلهای خطادار و توضیح مربوطه و به عبارت دیگر دیدن وضعیت عملکرد، روی این گزی" +
				"نه کلیک نمایید ");
			this.lblNoNumbersO.Click += new System.EventHandler(this.pictureBox6_Click);
			// 
			// comboFormType
			// 
			this.comboFormType.Items.AddRange(new object[] {
															   "360 سوالی",
															   "300 سوالی",
															   "210 سوالی"});
			this.comboFormType.Location = new System.Drawing.Point(16, 48);
			this.comboFormType.Name = "comboFormType";
			this.comboFormType.Size = new System.Drawing.Size(184, 21);
			this.comboFormType.TabIndex = 34;
			this.comboFormType.SelectedIndexChanged += new System.EventHandler(this.comboFormType_SelectedIndexChanged);
			// 
			// label53
			// 
			this.label53.Location = new System.Drawing.Point(208, 48);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(64, 24);
			this.label53.TabIndex = 33;
			this.label53.Text = "نوع فرم :";
			// 
			// label3
			// 
			this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label3.Location = new System.Drawing.Point(8, 456);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 16);
			this.label3.TabIndex = 32;
			this.label3.Text = "برگشت فايلهاي MER";
			this.toolTipGlobal.SetToolTip(this.label3, "جهت برگرداندن فایلهایی که خطادار بوده و پسوند آنها به .err تغییر  کرده روی این گز" +
				"ینه کلیک کرده تا پسوند آنها .jpg شود");
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// lblPath
			// 
			this.lblPath.Location = new System.Drawing.Point(16, 248);
			this.lblPath.Name = "lblPath";
			this.lblPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblPath.Size = new System.Drawing.Size(248, 40);
			this.lblPath.TabIndex = 31;
			this.lblPath.Text = "...";
			this.toolTipGlobal.SetToolTip(this.lblPath, "در این قسمت شما میتوانید پوشه مورد نظر خود را انتخاب و مسیر آن را مشاهده نمایید");
			// 
			// picColInRecord
			// 
			this.picColInRecord.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picColInRecord.Image = ((System.Drawing.Image)(resources.GetObject("picColInRecord.Image")));
			this.picColInRecord.Location = new System.Drawing.Point(264, 240);
			this.picColInRecord.Name = "picColInRecord";
			this.picColInRecord.Size = new System.Drawing.Size(40, 40);
			this.picColInRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picColInRecord.TabIndex = 30;
			this.picColInRecord.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.picColInRecord, "در این قسمت شما میتوانید پوشه مورد نظر خود را انتخاب و مسیر آن را مشاهده نمایید");
			this.picColInRecord.Click += new System.EventHandler(this.picColInRecord_DoubleClick);
			this.picColInRecord.MouseEnter += new System.EventHandler(this.picColInRecord_MouseEnter);
			this.picColInRecord.MouseLeave += new System.EventHandler(this.picColInRecord_MouseLeave);
			// 
			// listFiles
			// 
			this.listFiles.ContextMenu = this.contextMenu;
			this.listFiles.Location = new System.Drawing.Point(192, 400);
			this.listFiles.Name = "listFiles";
			this.listFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.listFiles.Size = new System.Drawing.Size(112, 251);
			this.listFiles.TabIndex = 29;
			this.toolTipGlobal.SetToolTip(this.listFiles, "در این قسمت فایلهای مسیر انتخاب شده نمایش داده میشود که این فایلها شامل فایلهای ت" +
				"صویری و فایهای خطادار و فایلهای درست تصحیح شده، میباشد");
			this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listFiles_SelectedIndexChanged);
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuItem6,
																						this.menuItem7,
																						this.menuItem8});
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 0;
			this.menuItem6.Text = "نمایش تصویر";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 1;
			this.menuItem7.Text = "برگشت تصویر";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click_2);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 2;
			this.menuItem8.Text = "Paint ویرایش در ";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
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
			this.groupReadMethod.Controls.Add(this.lblCodeDarkPoints);
			this.groupReadMethod.Controls.Add(this.label66);
			this.groupReadMethod.Controls.Add(this.trkCodeDarkPoints);
			this.groupReadMethod.Location = new System.Drawing.Point(8, 72);
			this.groupReadMethod.Name = "groupReadMethod";
			this.groupReadMethod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.groupReadMethod.Size = new System.Drawing.Size(296, 168);
			this.groupReadMethod.TabIndex = 27;
			this.groupReadMethod.TabStop = false;
			this.groupReadMethod.Text = "نحوه خواندن علامت";
			// 
			// lblThr
			// 
			this.lblThr.Location = new System.Drawing.Point(200, 48);
			this.lblThr.Name = "lblThr";
			this.lblThr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblThr.Size = new System.Drawing.Size(88, 24);
			this.lblThr.TabIndex = 14;
			this.lblThr.Text = "تنظيم حد آستانه";
			// 
			// trkThr
			// 
			this.trkThr.Location = new System.Drawing.Point(88, 40);
			this.trkThr.Maximum = 64;
			this.trkThr.Name = "trkThr";
			this.trkThr.Size = new System.Drawing.Size(112, 45);
			this.trkThr.TabIndex = 13;
			this.trkThr.TickStyle = System.Windows.Forms.TickStyle.None;
			this.toolTipGlobal.SetToolTip(this.trkThr, "در قسمت تععین آستانه شما می توانید مقدار پر بودن گزینه را تعیین نمایید و بدین ترت" +
				"یب حتی ضربدر ها یا تیکها تشخیص داده شوند و بالعکس.");
			this.trkThr.Value = 30;
			this.trkThr.Scroll += new System.EventHandler(this.trkThr_Scroll);
			// 
			// lblColorSence
			// 
			this.lblColorSence.BackColor = System.Drawing.SystemColors.InfoText;
			this.lblColorSence.Location = new System.Drawing.Point(8, 128);
			this.lblColorSence.Name = "lblColorSence";
			this.lblColorSence.Size = new System.Drawing.Size(24, 24);
			this.lblColorSence.TabIndex = 12;
			// 
			// lblSence
			// 
			this.lblSence.ForeColor = System.Drawing.Color.Red;
			this.lblSence.Location = new System.Drawing.Point(32, 136);
			this.lblSence.Name = "lblSence";
			this.lblSence.Size = new System.Drawing.Size(64, 16);
			this.lblSence.TabIndex = 11;
			this.lblSence.Text = "102 (40 %)";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(200, 128);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label2.Size = new System.Drawing.Size(88, 24);
			this.label2.TabIndex = 10;
			this.label2.Text = "تنظيم حساسيت";
			// 
			// trkSence
			// 
			this.trkSence.Location = new System.Drawing.Point(88, 120);
			this.trkSence.Maximum = 255;
			this.trkSence.Name = "trkSence";
			this.trkSence.Size = new System.Drawing.Size(112, 45);
			this.trkSence.TabIndex = 9;
			this.trkSence.TickStyle = System.Windows.Forms.TickStyle.None;
			this.toolTipGlobal.SetToolTip(this.trkSence, "در قسمت تنظیم حساسیت شما میتوانید حساسیت نرم افزار به شدت پررنگی یا کم رنگی گزینه" +
				" ها را تعیین نمایید");
			this.trkSence.Value = 102;
			this.trkSence.Scroll += new System.EventHandler(this.trackBar2_Scroll);
			// 
			// comboreadMethod
			// 
			this.comboreadMethod.Items.AddRange(new object[] {
																 "پررنگ ترين علامت",
																 "گزينه هاي پررنگ",
																 "تمام علامت ها"});
			this.comboreadMethod.Location = new System.Drawing.Point(8, 16);
			this.comboreadMethod.Name = "comboreadMethod";
			this.comboreadMethod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.comboreadMethod.Size = new System.Drawing.Size(184, 21);
			this.comboreadMethod.TabIndex = 1;
			this.comboreadMethod.Text = "پررنگ ترين علامت";
			this.toolTipGlobal.SetToolTip(this.comboreadMethod, "در این قسمت نحوه خواندن را مشخص میکنید،اگر گزینه اول را انتخاب کنید پر رنگ ترین \r" +
				"\nگزینه در میان گزینه های پر شده یک سؤال انتخاب و نمایش داده می شود و چنانچه گزین" +
				"ه \r\nدوم انتخاب شود گزینه های پر رنگی که از حد آستانه تعیین شده تبعیت کنند انتخاب" +
				" می شوند. ");
			this.comboreadMethod.SelectedValueChanged += new System.EventHandler(this.comboreadMethod_SelectedValueChanged);
			this.comboreadMethod.Click += new System.EventHandler(this.comboreadMethod_Click);
			this.comboreadMethod.SelectedIndexChanged += new System.EventHandler(this.comboreadMethod_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.label1.Location = new System.Drawing.Point(184, 16);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label1.Size = new System.Drawing.Size(104, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "شيوه انتخاب علامت";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDarkPointThr
			// 
			this.lblDarkPointThr.ForeColor = System.Drawing.Color.Red;
			this.lblDarkPointThr.Location = new System.Drawing.Point(16, 48);
			this.lblDarkPointThr.Name = "lblDarkPointThr";
			this.lblDarkPointThr.Size = new System.Drawing.Size(64, 16);
			this.lblDarkPointThr.TabIndex = 11;
			this.lblDarkPointThr.Text = "30";
			// 
			// lblCodeDarkPoints
			// 
			this.lblCodeDarkPoints.ForeColor = System.Drawing.Color.Red;
			this.lblCodeDarkPoints.Location = new System.Drawing.Point(16, 88);
			this.lblCodeDarkPoints.Name = "lblCodeDarkPoints";
			this.lblCodeDarkPoints.Size = new System.Drawing.Size(64, 16);
			this.lblCodeDarkPoints.TabIndex = 11;
			this.lblCodeDarkPoints.Text = "30";
			// 
			// label66
			// 
			this.label66.Location = new System.Drawing.Point(200, 80);
			this.label66.Name = "label66";
			this.label66.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label66.Size = new System.Drawing.Size(88, 24);
			this.label66.TabIndex = 14;
			this.label66.Text = "تنظيم حد آستانه قسمت كد";
			// 
			// trkCodeDarkPoints
			// 
			this.trkCodeDarkPoints.Location = new System.Drawing.Point(88, 80);
			this.trkCodeDarkPoints.Maximum = 64;
			this.trkCodeDarkPoints.Name = "trkCodeDarkPoints";
			this.trkCodeDarkPoints.Size = new System.Drawing.Size(112, 45);
			this.trkCodeDarkPoints.TabIndex = 13;
			this.trkCodeDarkPoints.TickStyle = System.Windows.Forms.TickStyle.None;
			this.toolTipGlobal.SetToolTip(this.trkCodeDarkPoints, "در قسمت تععین آستانه شما می توانید مقدار پر بودن گزینه را تعیین نمایید و بدین ترت" +
				"یب حتی ضربدر ها یا تیکها تشخیص داده شوند و بالعکس.");
			this.trkCodeDarkPoints.Value = 30;
			this.trkCodeDarkPoints.Scroll += new System.EventHandler(this.trkCodeDarkPoints_Scroll);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(144, 440);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(40, 40);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 30;
			this.pictureBox1.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox1, "جهت برگرداندن فایلهایی که خطادار بوده و پسوند آنها به .err تغییر  کرده روی این گز" +
				"ینه کلیک کرده تا پسوند آنها .jpg شود");
			this.pictureBox1.Click += new System.EventHandler(this.label3_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(144, 520);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(40, 40);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 30;
			this.pictureBox2.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox2, "روی این گزینه کلیک کنید تا نتایج تصحیح و خواندن برگه ها توسط  نرم افزار را مشاهده" +
				" نمایید ");
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// pictureBox3
			// 
			this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(144, 560);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(40, 32);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 30;
			this.pictureBox3.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox3, "دیدن فایلهای خطادار و توضیح مربوطه و به عبارت دیگر دیدن وضعیت عملکرد، روی این گزی" +
				"نه کلیک نمایید ");
			this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
			// 
			// label4
			// 
			this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.label4.Location = new System.Drawing.Point(8, 496);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 16);
			this.label4.TabIndex = 32;
			this.label4.Text = "برگشت فايلهاي Val";
			this.toolTipGlobal.SetToolTip(this.label4, "جهت برگرداندن فایلهایی که تصحیح و پسوند آنها به .val تغییر  کرده روی این گزینه کل" +
				"یک کرده تا پسوند آنها .jpg شود");
			this.label4.Click += new System.EventHandler(this.pictureBox4_Click);
			// 
			// lblReachedResultsO
			// 
			this.lblReachedResultsO.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblReachedResultsO.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.lblReachedResultsO.Location = new System.Drawing.Point(8, 528);
			this.lblReachedResultsO.Name = "lblReachedResultsO";
			this.lblReachedResultsO.Size = new System.Drawing.Size(136, 32);
			this.lblReachedResultsO.TabIndex = 32;
			this.lblReachedResultsO.Text = "مشاهده نتيجه آناليز برگه ها(0)";
			this.toolTipGlobal.SetToolTip(this.lblReachedResultsO, "روی این گزینه کلیک کنید تا نتایج تصحیح و خواندن برگه ها توسط  نرم افزار را مشاهده" +
				" نمایید ");
			this.lblReachedResultsO.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// lblPerformaneStatusO
			// 
			this.lblPerformaneStatusO.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblPerformaneStatusO.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.lblPerformaneStatusO.Location = new System.Drawing.Point(8, 568);
			this.lblPerformaneStatusO.Name = "lblPerformaneStatusO";
			this.lblPerformaneStatusO.Size = new System.Drawing.Size(128, 32);
			this.lblPerformaneStatusO.TabIndex = 32;
			this.lblPerformaneStatusO.Text = "مشاهده عملکرد          (0)";
			this.toolTipGlobal.SetToolTip(this.lblPerformaneStatusO, "دیدن فایلهای خطادار و توضیح مربوطه و به عبارت دیگر دیدن وضعیت عملکرد، روی این گزی" +
				"نه کلیک نمایید ");
			this.lblPerformaneStatusO.Click += new System.EventHandler(this.pictureBox3_Click);
			// 
			// pictureBox4
			// 
			this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(144, 480);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(32, 40);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 30;
			this.pictureBox4.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox4, "جهت برگرداندن فایلهایی که تصحیح و پسوند آنها به .val تغییر  کرده روی این گزینه کل" +
				"یک کرده تا پسوند آنها .jpg شود");
			this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
			// 
			// pictureBox5
			// 
			this.pictureBox5.ContextMenu = this.conMnu;
			this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
			this.pictureBox5.Location = new System.Drawing.Point(8, 8);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(40, 40);
			this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox5.TabIndex = 25;
			this.pictureBox5.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox5, "نرم افزار دارای 5 قسمت (صفحه) میباشد که برای حرکت بین آنها از این دکمه ،استفاده م" +
				"ی کنیم \nاز طرف دیگر برای راحتی بیشتر یک منو در نظر گرفته شده که در صورت راست کلی" +
				"ک\n کردن روی دکمه ها ظاهر می شود به وسیله این منو می توانید به صفحه مورد نظر مراج" +
				"ه نمایید");
			this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
			this.pictureBox5.MouseEnter += new System.EventHandler(this.pictureBox5_MouseEnter);
			this.pictureBox5.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
			// 
			// conMnu
			// 
			this.conMnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.menuItem5,
																				   this.menuItem1,
																				   this.menuItem2,
																				   this.menuItem3,
																				   this.menuItem4});
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Text = "صفحه نمایش";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "تنظیمات صفحه";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "تنضیمات مربوط به خروجی";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "تنظیم رنگ پس زمینه نرم افزار";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click_1);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.Text = "نمایش وضعیت عملکرد";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// pictureBox12
			// 
			this.pictureBox12.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
			this.pictureBox12.Location = new System.Drawing.Point(144, 400);
			this.pictureBox12.Name = "pictureBox12";
			this.pictureBox12.Size = new System.Drawing.Size(40, 40);
			this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox12.TabIndex = 30;
			this.pictureBox12.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox12, @"چنانچه روی گزینه مشخص شده کلیک نمایید ابتدا پیغامی مبنی بر پاک کردن نتایج قبلی یا رد آن و یا لغو خواندن برگه ها دریافت می نمایید اگر دکمه Yes  
را انتخاب نمایید کل فایلهای تصویری تصحیح و آنالیز خواهد شد
 در طول این مدت بهتر است کار دیگری روی فرم انجام ندهید تا وقتی که پیغام پایان پردازش را دریافت نمایید");
			this.pictureBox12.Click += new System.EventHandler(this.label54_Click);
			// 
			// label54
			// 
			this.label54.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label54.Location = new System.Drawing.Point(8, 416);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(128, 16);
			this.label54.TabIndex = 32;
			this.label54.Text = "تصحيح کل فرمهاي پوشه جاري";
			this.toolTipGlobal.SetToolTip(this.label54, @"چنانچه روی گزینه مشخص شده کلیک نمایید ابتدا پیغامی مبنی بر پاک کردن نتایج قبلی یا رد آن و یا لغو خواندن برگه ها دریافت می نمایید اگر دکمه Yes  
را انتخاب نمایید کل فایلهای تصویری تصحیح و آنالیز خواهد شد
 در طول این مدت بهتر است کار دیگری روی فرم انجام ندهید تا وقتی که پیغام پایان پردازش را دریافت نمایید");
			this.label54.Click += new System.EventHandler(this.label54_Click);
			// 
			// pic13
			// 
			this.pic13.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pic13.Image = ((System.Drawing.Image)(resources.GetObject("pic13.Image")));
			this.pic13.Location = new System.Drawing.Point(144, 584);
			this.pic13.Name = "pic13";
			this.pic13.Size = new System.Drawing.Size(40, 40);
			this.pic13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic13.TabIndex = 30;
			this.pic13.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pic13, "جهت ذخیره نتایج در یک فایل متنی روی این گزینه کلیک نمایید ");
			this.pic13.Click += new System.EventHandler(this.label57_Click);
			// 
			// label57
			// 
			this.label57.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label57.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.label57.Location = new System.Drawing.Point(8, 608);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(128, 16);
			this.label57.TabIndex = 32;
			this.label57.Text = "ذخيره نتايج";
			this.toolTipGlobal.SetToolTip(this.label57, "جهت ذخیره نتایج در یک فایل متنی روی این گزینه کلیک نمایید ");
			this.label57.Click += new System.EventHandler(this.label57_Click);
			// 
			// pictureBox13
			// 
			this.pictureBox13.ContextMenu = this.conMnu;
			this.pictureBox13.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
			this.pictureBox13.Location = new System.Drawing.Point(48, 8);
			this.pictureBox13.Name = "pictureBox13";
			this.pictureBox13.Size = new System.Drawing.Size(40, 40);
			this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox13.TabIndex = 25;
			this.pictureBox13.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox13, "نرم افزار دارای 5 قسمت (صفحه) میباشد که برای حرکت بین آنها از این دکمه ،استفاده م" +
				"ی کنیم \nاز طرف دیگر برای راحتی بیشتر یک منو در نظر گرفته شده که در صورت راست کلی" +
				"ک\n کردن روی دکمه ها ظاهر می شود به وسیله این منو می توانید به صفحه مورد نظر مراج" +
				"ه نمایید");
			this.pictureBox13.Click += new System.EventHandler(this.pictureBox13_Click);
			this.pictureBox13.MouseEnter += new System.EventHandler(this.pictureBox13_MouseEnter);
			this.pictureBox13.MouseLeave += new System.EventHandler(this.pictureBox13_MouseLeave);
			// 
			// pictureBox16
			// 
			this.pictureBox16.ContextMenu = this.conMnu;
			this.pictureBox16.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox16.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox16.Image")));
			this.pictureBox16.Location = new System.Drawing.Point(256, 8);
			this.pictureBox16.Name = "pictureBox16";
			this.pictureBox16.Size = new System.Drawing.Size(40, 40);
			this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox16.TabIndex = 25;
			this.pictureBox16.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox16, "برای خروج روی این دکمه کلیک نمایید");
			this.pictureBox16.Click += new System.EventHandler(this.pictureBox16_Click);
			this.pictureBox16.MouseEnter += new System.EventHandler(this.pictureBox16_MouseEnter);
			this.pictureBox16.MouseLeave += new System.EventHandler(this.pictureBox16_MouseLeave);
			// 
			// chkSubFolders
			// 
			this.chkSubFolders.Location = new System.Drawing.Point(192, 296);
			this.chkSubFolders.Name = "chkSubFolders";
			this.chkSubFolders.Size = new System.Drawing.Size(104, 16);
			this.chkSubFolders.TabIndex = 0;
			this.chkSubFolders.Text = "خواندن زير پوشه ها";
			this.chkSubFolders.CheckedChanged += new System.EventHandler(this.chkSubFolders_CheckedChanged);
			// 
			// pictureBox7
			// 
			this.pictureBox7.ContextMenu = this.conMnu;
			this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
			this.pictureBox7.Location = new System.Drawing.Point(224, 12);
			this.pictureBox7.Name = "pictureBox7";
			this.pictureBox7.Size = new System.Drawing.Size(24, 32);
			this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox7.TabIndex = 25;
			this.pictureBox7.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox7, "برای خروج روی این دکمه کلیک نمایید");
			this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
			this.pictureBox7.MouseEnter += new System.EventHandler(this.pictureBox7_MouseEnter);
			this.pictureBox7.MouseLeave += new System.EventHandler(this.pictureBox7_MouseLeave);
			// 
			// picPerformaneStatus
			// 
			this.picPerformaneStatus.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picPerformaneStatus.Image = ((System.Drawing.Image)(resources.GetObject("picPerformaneStatus.Image")));
			this.picPerformaneStatus.Location = new System.Drawing.Point(144, 320);
			this.picPerformaneStatus.Name = "picPerformaneStatus";
			this.picPerformaneStatus.Size = new System.Drawing.Size(32, 40);
			this.picPerformaneStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPerformaneStatus.TabIndex = 39;
			this.picPerformaneStatus.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.picPerformaneStatus, "جهت ذخیره نتایج در یک فایل متنی روی این گزینه کلیک نمایید ");
			// 
			// panelPageSettings
			// 
			this.panelPageSettings.Controls.Add(this.comboPageType);
			this.panelPageSettings.Controls.Add(this.combSubjects);
			this.panelPageSettings.Controls.Add(this.label58);
			this.panelPageSettings.Controls.Add(this.txtFixNumber);
			this.panelPageSettings.Controls.Add(this.label55);
			this.panelPageSettings.Controls.Add(this.label7);
			this.panelPageSettings.Controls.Add(this.groupBox4);
			this.panelPageSettings.Controls.Add(this.label34);
			this.panelPageSettings.Controls.Add(this.groupBox16);
			this.panelPageSettings.Controls.Add(this.groupBox15);
			this.panelPageSettings.Controls.Add(this.label33);
			this.panelPageSettings.Controls.Add(this.groupBox14);
			this.panelPageSettings.Controls.Add(this.groupBox8);
			this.panelPageSettings.Controls.Add(this.label59);
			this.panelPageSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.panelPageSettings.Location = new System.Drawing.Point(0, 0);
			this.panelPageSettings.Name = "panelPageSettings";
			this.panelPageSettings.Size = new System.Drawing.Size(664, 664);
			this.panelPageSettings.TabIndex = 1;
			this.toolTipGlobal.SetToolTip(this.panelPageSettings, "قسمت مربوط به تنظیمات مربوط به برگه تستی نمایش داده شده است ");
			this.panelPageSettings.Validated += new System.EventHandler(this.panelPageSettings_Validated);
			// 
			// comboPageType
			// 
			this.comboPageType.Items.AddRange(new object[] {
															   "از نوع A4",
															   "از نوع A5"});
			this.comboPageType.Location = new System.Drawing.Point(296, 360);
			this.comboPageType.Name = "comboPageType";
			this.comboPageType.Size = new System.Drawing.Size(104, 21);
			this.comboPageType.TabIndex = 27;
			this.comboPageType.SelectedIndexChanged += new System.EventHandler(this.comboPageType_SelectedIndexChanged);
			// 
			// combSubjects
			// 
			this.combSubjects.Items.AddRange(new object[] {
															  "پاسخبرگ",
															  "نظرخواهي از دانشجويان",
															  "نظرخواهي از همکاران"});
			this.combSubjects.Location = new System.Drawing.Point(456, 360);
			this.combSubjects.Name = "combSubjects";
			this.combSubjects.Size = new System.Drawing.Size(152, 21);
			this.combSubjects.TabIndex = 26;
			this.combSubjects.Text = "پاسخبرگ";
			this.toolTipGlobal.SetToolTip(this.combSubjects, @"در این قسمت در واقع نوع و موضوع برگه با فرم تعیین میگردد که در صورتی که گزینه اول
 انتخاب شود نوع فرم را پاسخبرگ تعریف کرده اید ،که به این معناست که برگه دارای سربرگ
 بوده و شامل کد داوطلب(یا هر نام دیگر) و کد آزمون(یا هر نام دیگر) میباشد.
چنانچه هر کدام از گزینه های بعدی انتخاب شود به این معناست که برگه دارای سربرگ نبوده
 و در این صورت یک کد ثابت باید  در قسمت  بالا و راست  برنامه که توسط کادر قرمز رنگ تعیین شده ،تعریف شود");
			this.combSubjects.SelectedIndexChanged += new System.EventHandler(this.combSubjects_SelectedIndexChanged);
			this.combSubjects.MouseEnter += new System.EventHandler(this.combSubjects_MouseEnter);
			this.combSubjects.Leave += new System.EventHandler(this.combSubjects_Leave);
			// 
			// label58
			// 
			this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.label58.Location = new System.Drawing.Point(400, 360);
			this.label58.Name = "label58";
			this.label58.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label58.Size = new System.Drawing.Size(48, 24);
			this.label58.TabIndex = 25;
			this.label58.Text = "نوع برگه :";
			// 
			// txtFixNumber
			// 
			this.txtFixNumber.Enabled = false;
			this.txtFixNumber.Location = new System.Drawing.Point(296, 360);
			this.txtFixNumber.Name = "txtFixNumber";
			this.txtFixNumber.Size = new System.Drawing.Size(104, 20);
			this.txtFixNumber.TabIndex = 19;
			this.txtFixNumber.Text = "00";
			this.txtFixNumber.Visible = false;
			this.txtFixNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			this.txtFixNumber.Validated += new System.EventHandler(this.txtFixNumber_Validated);
			this.txtFixNumber.TextChanged += new System.EventHandler(this.txtFixNumber_TextChanged);
			// 
			// label55
			// 
			this.label55.Location = new System.Drawing.Point(448, 504);
			this.label55.Name = "label55";
			this.label55.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label55.Size = new System.Drawing.Size(56, 16);
			this.label55.TabIndex = 17;
			this.label55.Text = "جهت گزينه ها";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(432, -24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 24);
			this.label7.TabIndex = 16;
			this.label7.Text = "الگوهاي موجود";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtTestFormName);
			this.groupBox4.Controls.Add(this.button2);
			this.groupBox4.Controls.Add(this.btnSaveTemplate);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.button5);
			this.groupBox4.Location = new System.Drawing.Point(296, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(360, 120);
			this.groupBox4.TabIndex = 15;
			this.groupBox4.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.groupBox4, @"در این قسمت نام الگو و به اصطلاح نام فرم را در جعبه متن بالای کادر مشاهده می کنید ،
حال چنانچه مایل به تعریف یک الگوی جدید باشید ابتدا باید در جعبه متن بالای این کادر نام الگو را مشخص نمایید
 و پس از تعیین سایر مشخصات روی دکمه ی ذخیره الگوی جدید کلیک نمایید.
ویا چنانچه مایل به حذف الگوی جاری باشید می توانید روی دکمه ی حذف الگو کلیک کنید.");
			// 
			// txtTestFormName
			// 
			this.txtTestFormName.Location = new System.Drawing.Point(16, 16);
			this.txtTestFormName.Name = "txtTestFormName";
			this.txtTestFormName.Size = new System.Drawing.Size(272, 20);
			this.txtTestFormName.TabIndex = 14;
			this.txtTestFormName.Text = "";
			this.toolTipGlobal.SetToolTip(this.txtTestFormName, "نام الگو یا نام  فرم");
			// 
			// button2
			// 
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(24, 48);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 64);
			this.button2.TabIndex = 13;
			this.button2.Text = "ذخيره تغييرات";
			// 
			// btnSaveTemplate
			// 
			this.btnSaveTemplate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.btnSaveTemplate.Location = new System.Drawing.Point(104, 80);
			this.btnSaveTemplate.Name = "btnSaveTemplate";
			this.btnSaveTemplate.Size = new System.Drawing.Size(88, 24);
			this.btnSaveTemplate.TabIndex = 11;
			this.btnSaveTemplate.Text = "ذخيره  الگوي جديد";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(304, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(32, 16);
			this.label8.TabIndex = 9;
			this.label8.Text = "نام فرم";
			// 
			// button5
			// 
			this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
			this.button5.Location = new System.Drawing.Point(208, 48);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(72, 64);
			this.button5.TabIndex = 13;
			this.button5.Text = "حذف ا لگو";
			this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(440, 392);
			this.label34.Name = "label34";
			this.label34.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label34.Size = new System.Drawing.Size(56, 16);
			this.label34.TabIndex = 14;
			this.label34.Text = "جهت سوالات";
			// 
			// groupBox16
			// 
			this.groupBox16.Controls.Add(this.pictureBox14);
			this.groupBox16.Controls.Add(this.radioCRightToLeft);
			this.groupBox16.Controls.Add(this.radioCLeftToRight);
			this.groupBox16.Controls.Add(this.pictureBox15);
			this.groupBox16.Location = new System.Drawing.Point(296, 504);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new System.Drawing.Size(352, 144);
			this.groupBox16.TabIndex = 13;
			this.groupBox16.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.groupBox16, "در قسمتهای \"جهت سوالات\"و\"جهت گزینه\" جهت هر کدام را با توجه به برگه تستی تعیین نما" +
				"یید");
			// 
			// pictureBox14
			// 
			this.pictureBox14.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox14.Image")));
			this.pictureBox14.Location = new System.Drawing.Point(256, 24);
			this.pictureBox14.Name = "pictureBox14";
			this.pictureBox14.Size = new System.Drawing.Size(40, 40);
			this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox14.TabIndex = 4;
			this.pictureBox14.TabStop = false;
			// 
			// radioCRightToLeft
			// 
			this.radioCRightToLeft.Location = new System.Drawing.Point(128, 40);
			this.radioCRightToLeft.Name = "radioCRightToLeft";
			this.radioCRightToLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioCRightToLeft.Size = new System.Drawing.Size(88, 16);
			this.radioCRightToLeft.TabIndex = 2;
			this.radioCRightToLeft.Text = "راست به چپ";
			// 
			// radioCLeftToRight
			// 
			this.radioCLeftToRight.Checked = true;
			this.radioCLeftToRight.Location = new System.Drawing.Point(128, 104);
			this.radioCLeftToRight.Name = "radioCLeftToRight";
			this.radioCLeftToRight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioCLeftToRight.Size = new System.Drawing.Size(88, 16);
			this.radioCLeftToRight.TabIndex = 1;
			this.radioCLeftToRight.TabStop = true;
			this.radioCLeftToRight.Text = "چپ به راست";
			this.radioCLeftToRight.CheckedChanged += new System.EventHandler(this.radioCLeftToRight_CheckedChanged);
			// 
			// pictureBox15
			// 
			this.pictureBox15.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox15.Image")));
			this.pictureBox15.Location = new System.Drawing.Point(256, 88);
			this.pictureBox15.Name = "pictureBox15";
			this.pictureBox15.Size = new System.Drawing.Size(40, 40);
			this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox15.TabIndex = 4;
			this.pictureBox15.TabStop = false;
			// 
			// groupBox15
			// 
			this.groupBox15.Controls.Add(this.pictureBox11);
			this.groupBox15.Controls.Add(this.pictureBox9);
			this.groupBox15.Controls.Add(this.radioQRightToLeft);
			this.groupBox15.Controls.Add(this.radioQLeftToRight);
			this.groupBox15.Location = new System.Drawing.Point(296, 392);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(352, 104);
			this.groupBox15.TabIndex = 12;
			this.groupBox15.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.groupBox15, "در قسمتهای \"جهت سوالات\"و\"جهت گزینه\" جهت هر کدام را با توجه به برگه تستی تعیین نما" +
				"یید");
			this.groupBox15.Enter += new System.EventHandler(this.groupBox15_Enter);
			// 
			// pictureBox11
			// 
			this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
			this.pictureBox11.Location = new System.Drawing.Point(248, 16);
			this.pictureBox11.Name = "pictureBox11";
			this.pictureBox11.Size = new System.Drawing.Size(40, 40);
			this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox11.TabIndex = 4;
			this.pictureBox11.TabStop = false;
			// 
			// pictureBox9
			// 
			this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
			this.pictureBox9.Location = new System.Drawing.Point(248, 48);
			this.pictureBox9.Name = "pictureBox9";
			this.pictureBox9.Size = new System.Drawing.Size(40, 40);
			this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox9.TabIndex = 3;
			this.pictureBox9.TabStop = false;
			// 
			// radioQRightToLeft
			// 
			this.radioQRightToLeft.Location = new System.Drawing.Point(128, 32);
			this.radioQRightToLeft.Name = "radioQRightToLeft";
			this.radioQRightToLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioQRightToLeft.Size = new System.Drawing.Size(96, 16);
			this.radioQRightToLeft.TabIndex = 2;
			this.radioQRightToLeft.Text = "راست به چپ";
			// 
			// radioQLeftToRight
			// 
			this.radioQLeftToRight.Checked = true;
			this.radioQLeftToRight.Location = new System.Drawing.Point(128, 72);
			this.radioQLeftToRight.Name = "radioQLeftToRight";
			this.radioQLeftToRight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioQLeftToRight.Size = new System.Drawing.Size(96, 16);
			this.radioQLeftToRight.TabIndex = 1;
			this.radioQLeftToRight.TabStop = true;
			this.radioQLeftToRight.Text = "چپ به راست";
			this.radioQLeftToRight.CheckedChanged += new System.EventHandler(this.radioQLeftToRight_CheckedChanged);
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(408, 128);
			this.label33.Name = "label33";
			this.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label33.Size = new System.Drawing.Size(128, 16);
			this.label33.TabIndex = 11;
			this.label33.Text = "مشخصات محل سوالات در فرم";
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.chkBottomLayout);
			this.groupBox14.Controls.Add(this.txtNumberOfTotalQuestions);
			this.groupBox14.Controls.Add(this.label9);
			this.groupBox14.Controls.Add(this.txtTopLayoutNumber);
			this.groupBox14.Controls.Add(this.txtLeftLayoutNumber);
			this.groupBox14.Controls.Add(this.label10);
			this.groupBox14.Controls.Add(this.label11);
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
			this.groupBox14.Controls.Add(this.chkStartFromMiddle);
			this.groupBox14.Location = new System.Drawing.Point(296, 128);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(360, 224);
			this.groupBox14.TabIndex = 10;
			this.groupBox14.TabStop = false;
			// 
			// chkBottomLayout
			// 
			this.chkBottomLayout.Location = new System.Drawing.Point(192, 200);
			this.chkBottomLayout.Name = "chkBottomLayout";
			this.chkBottomLayout.Size = new System.Drawing.Size(136, 16);
			this.chkBottomLayout.TabIndex = 28;
			this.chkBottomLayout.Text = "داراي خط در  پايين صفحه";
			this.toolTipGlobal.SetToolTip(this.chkBottomLayout, "چنانچه برگه دارای خطی در زیر قسمت سوالات باشد این گزینه را انتخاب کنید");
			// 
			// txtNumberOfTotalQuestions
			// 
			this.txtNumberOfTotalQuestions.Location = new System.Drawing.Point(96, 16);
			this.txtNumberOfTotalQuestions.Name = "txtNumberOfTotalQuestions";
			this.txtNumberOfTotalQuestions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtNumberOfTotalQuestions.Size = new System.Drawing.Size(96, 20);
			this.txtNumberOfTotalQuestions.TabIndex = 27;
			this.txtNumberOfTotalQuestions.Text = "85";
			this.toolTipGlobal.SetToolTip(this.txtNumberOfTotalQuestions, "تعدادکل سوالات");
			this.txtNumberOfTotalQuestions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(208, 16);
			this.label9.Name = "label9";
			this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label9.Size = new System.Drawing.Size(80, 16);
			this.label9.TabIndex = 26;
			this.label9.Text = "تعداد کل سوالات";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTopLayoutNumber
			// 
			this.txtTopLayoutNumber.Location = new System.Drawing.Point(200, 168);
			this.txtTopLayoutNumber.Name = "txtTopLayoutNumber";
			this.txtTopLayoutNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtTopLayoutNumber.Size = new System.Drawing.Size(32, 20);
			this.txtTopLayoutNumber.TabIndex = 25;
			this.txtTopLayoutNumber.Text = "10";
			this.toolTipGlobal.SetToolTip(this.txtTopLayoutNumber, "در این قسمت تعداد حاشیه های بالای برگه که مربوط به سربرگ میباشد را وارد نمایید");
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
			this.toolTipGlobal.SetToolTip(this.txtLeftLayoutNumber, "در این قسمت تعدادحاشیه های سمت چپ برگه را وارد کنید");
			this.txtLeftLayoutNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(248, 152);
			this.label10.Name = "label10";
			this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label10.Size = new System.Drawing.Size(104, 16);
			this.label10.TabIndex = 22;
			this.label10.Text = "تعداد حاشيه هاي چپ";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(248, 176);
			this.label11.Name = "label11";
			this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label11.Size = new System.Drawing.Size(104, 16);
			this.label11.TabIndex = 23;
			this.label11.Text = "تعداد حاشيه هاي بالا";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtColDistance
			// 
			this.txtColDistance.Location = new System.Drawing.Point(200, 120);
			this.txtColDistance.Name = "txtColDistance";
			this.txtColDistance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtColDistance.Size = new System.Drawing.Size(32, 20);
			this.txtColDistance.TabIndex = 19;
			this.txtColDistance.Text = "04";
			this.toolTipGlobal.SetToolTip(this.txtColDistance, "در این قسمت فاصله بین دسته ها ");
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
			this.toolTipGlobal.SetToolTip(this.txtClassDistance, "در این قسمت بر حسب اندازه ی گزینه ها فاصله ی بین ستونها را مشخص می نمایید.");
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
			this.toolTipGlobal.SetToolTip(this.txtHorDistance, "در این قسمت فاصله بین گزینه تعیین میشود اگر بین دو گزینه به اندازه یک گزینه فاصله" +
				" باشد در این قسمت عدد 1 را وارد نمایید و اصولا به هر اندازه که بر حسب اندازه گزی" +
				"نه میباشد،فاصله باشد باید تعیین گردد");
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
			this.toolTipGlobal.SetToolTip(this.txtVerDistance, "در این قسمت فاصله عمودی بین سوالات تعیین می شود که در اغلب موارد صفر می باشد");
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
			this.toolTipGlobal.SetToolTip(this.txtFirstCol, "در این قسمت شماره ستون اولین سوال مشخص می گردد که از 1 شروع و تا 31 میتواند باشد");
			this.txtFirstCol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			this.txtFirstCol.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// txtFirstRow
			// 
			this.txtFirstRow.Location = new System.Drawing.Point(32, 144);
			this.txtFirstRow.Name = "txtFirstRow";
			this.txtFirstRow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtFirstRow.Size = new System.Drawing.Size(32, 20);
			this.txtFirstRow.TabIndex = 14;
			this.txtFirstRow.Text = "00";
			this.toolTipGlobal.SetToolTip(this.txtFirstRow, "در این قسمت با توجه به حاشیه های سمت چپ سوالات ،مکان اولین سوال تعیین می گردد.مثل" +
				"ا اگر سوال اول دقیقا هم راستای  اولین حاشیه سمت چپ سوالات باشد در این قسمت عدد 1" +
				" را وارد نمایید");
			this.txtFirstRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			this.txtFirstRow.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// txtCasesNumber
			// 
			this.txtCasesNumber.Location = new System.Drawing.Point(32, 120);
			this.txtCasesNumber.Name = "txtCasesNumber";
			this.txtCasesNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtCasesNumber.Size = new System.Drawing.Size(32, 20);
			this.txtCasesNumber.TabIndex = 13;
			this.txtCasesNumber.Text = "04";
			this.toolTipGlobal.SetToolTip(this.txtCasesNumber, "در این قسمت تعداد گزینه های سوالات مشخص میشود");
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
			this.toolTipGlobal.SetToolTip(this.txtQuestionNumber, "در این قسمت تعداد سوالات هر دسته تعیین میگردد");
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
			this.toolTipGlobal.SetToolTip(this.txtclassNumber, "در این قسمت تعداد دسته های یرگه تعیین میگردد");
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
			this.toolTipGlobal.SetToolTip(this.txtColNumber, "در این قسمت تعداد ستونهای برگه مشخص می شود");
			this.txtColNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(72, 72);
			this.label36.Name = "label36";
			this.label36.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label36.Size = new System.Drawing.Size(104, 16);
			this.label36.TabIndex = 0;
			this.label36.Text = "تعداد دسته هاي هر ستون";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(72, 96);
			this.label37.Name = "label37";
			this.label37.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label37.Size = new System.Drawing.Size(96, 16);
			this.label37.TabIndex = 0;
			this.label37.Text = "تعداد سوالات هر دسته";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(72, 120);
			this.label38.Name = "label38";
			this.label38.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label38.Size = new System.Drawing.Size(120, 16);
			this.label38.TabIndex = 0;
			this.label38.Text = "تعداد گزينه هاي هر سوال";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(72, 152);
			this.label39.Name = "label39";
			this.label39.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label39.Size = new System.Drawing.Size(120, 16);
			this.label39.TabIndex = 0;
			this.label39.Text = "اولين گزينه سوال(سطر)";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(72, 176);
			this.label40.Name = "label40";
			this.label40.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label40.Size = new System.Drawing.Size(104, 16);
			this.label40.TabIndex = 0;
			this.label40.Text = "اولين گزينه سوال(ستون)";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(248, 48);
			this.label41.Name = "label41";
			this.label41.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label41.Size = new System.Drawing.Size(120, 16);
			this.label41.TabIndex = 0;
			this.label41.Text = "فاصله بين گزينه ها(عمودي)";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(248, 72);
			this.label42.Name = "label42";
			this.label42.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label42.Size = new System.Drawing.Size(112, 16);
			this.label42.TabIndex = 0;
			this.label42.Text = "فاصله بين گزينه ها(افقي)";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(248, 120);
			this.label43.Name = "label43";
			this.label43.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label43.Size = new System.Drawing.Size(104, 16);
			this.label43.TabIndex = 0;
			this.label43.Text = "فاصله بين دسته ها";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(248, 96);
			this.label44.Name = "label44";
			this.label44.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label44.Size = new System.Drawing.Size(104, 16);
			this.label44.TabIndex = 0;
			this.label44.Text = "فاصله بين ستونها";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(72, 48);
			this.label45.Name = "label45";
			this.label45.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label45.Size = new System.Drawing.Size(72, 16);
			this.label45.TabIndex = 0;
			this.label45.Text = "تعداد ستونها";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkStartFromMiddle
			// 
			this.chkStartFromMiddle.Location = new System.Drawing.Point(32, 200);
			this.chkStartFromMiddle.Name = "chkStartFromMiddle";
			this.chkStartFromMiddle.Size = new System.Drawing.Size(128, 16);
			this.chkStartFromMiddle.TabIndex = 28;
			this.chkStartFromMiddle.Text = "شروع حاشيه چپ از  وسط";
			this.toolTipGlobal.SetToolTip(this.chkStartFromMiddle, "چنانچه حاشیه های قسمت بالای برگه وجود نداشته باشند این تیک را انتخاب نمایید");
			this.chkStartFromMiddle.CheckedChanged += new System.EventHandler(this.chkStartFromMiddle_CheckedChanged);
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.groupBox13);
			this.groupBox8.Controls.Add(this.groupBox12);
			this.groupBox8.Controls.Add(this.groupBox11);
			this.groupBox8.Controls.Add(this.groupBox10);
			this.groupBox8.Controls.Add(this.groupBox9);
			this.groupBox8.Location = new System.Drawing.Point(0, 0);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.groupBox8.Size = new System.Drawing.Size(288, 648);
			this.groupBox8.TabIndex = 9;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "متغيرهاي صفحه آزمون";
			this.toolTipGlobal.SetToolTip(this.groupBox8, @"در این قسمت متغیرهایی که در برگه وجود دارد را مشخص می کنید،
منظور از سطر شماره حاشیه قسمت بالای برگه می باشد که اغلب 1 است.
ومنظور از ستون شماره ستون اولین رقم متغیرمیباشد که از 1 شروع و تا 31 میتواند باشد.
 و منظور از تعداد ارقام ،تعداد رقمهای آن متغیر میباشد و تعدادگزینه ها در واقع محدوده اعداد هر رقم می باشد
 که معمولا 10 میباشد که بدین معناست که هر رقم از 0 تا 9 متواند باشد.
 و در نهایت منظور از نام متغیر ،عنوان کد تععین شده توسط این متغیر میباشد مثلا میتوان نام متغیر اول را ""کد داوطلب"" تعریف نمود");
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
			this.groupBox13.Location = new System.Drawing.Point(8, 512);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(264, 120);
			this.groupBox13.TabIndex = 4;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "متغير پنجم   (حداکثر 1 رقم)";
			this.toolTipGlobal.SetToolTip(this.groupBox13, @"در این قسمت متغیرهایی که در برگه وجود دارد را مشخص می کنید،
منظور از سطر شماره حاشیه قسمت بالای برگه می باشد که اغلب 1 است.
ومنظور از ستون شماره ستون اولین رقم متغیرمیباشد که از 1 شروع و تا 31 میتواند باشد.
 و منظور از تعداد ارقام ،تعداد رقمهای آن متغیر میباشد و تعدادگزینه ها در واقع محدوده اعداد هر رقم می باشد
 که معمولا 10 میباشد که بدین معناست که هر رقم از 0 تا 9 متواند باشد.
 و در نهایت منظور از نام متغیر ،عنوان کد تععین شده توسط این متغیر میباشد مثلا میتوان نام متغیر اول را ""کد داوطلب"" تعریف نمود");
			// 
			// txt5VarName
			// 
			this.txt5VarName.Location = new System.Drawing.Point(8, 88);
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
			this.txt5Row.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// txt5Col
			// 
			this.txt5Col.Location = new System.Drawing.Point(8, 16);
			this.txt5Col.Name = "txt5Col";
			this.txt5Col.Size = new System.Drawing.Size(56, 20);
			this.txt5Col.TabIndex = 18;
			this.txt5Col.Text = "16";
			this.txt5Col.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			this.txt5Col.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(208, 96);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(48, 16);
			this.label28.TabIndex = 17;
			this.label28.Text = "نام متغير :";
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(72, 64);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(64, 16);
			this.label29.TabIndex = 16;
			this.label29.Text = "تعداد گزينه ها :";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(200, 64);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(56, 16);
			this.label30.TabIndex = 15;
			this.label30.Text = "تعداد ارقام :";
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(72, 16);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(32, 16);
			this.label31.TabIndex = 14;
			this.label31.Text = "ستون:";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(224, 16);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(32, 16);
			this.label32.TabIndex = 13;
			this.label32.Text = "سطر:";
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
			this.groupBox12.Location = new System.Drawing.Point(8, 384);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(264, 120);
			this.groupBox12.TabIndex = 3;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "متغير چهارم   (حداکثر 2 رقم)";
			this.toolTipGlobal.SetToolTip(this.groupBox12, @"در این قسمت متغیرهایی که در برگه وجود دارد را مشخص می کنید،
منظور از سطر شماره حاشیه قسمت بالای برگه می باشد که اغلب 1 است.
ومنظور از ستون شماره ستون اولین رقم متغیرمیباشد که از 1 شروع و تا 31 میتواند باشد.
 و منظور از تعداد ارقام ،تعداد رقمهای آن متغیر میباشد و تعدادگزینه ها در واقع محدوده اعداد هر رقم می باشد
 که معمولا 10 میباشد که بدین معناست که هر رقم از 0 تا 9 متواند باشد.
 و در نهایت منظور از نام متغیر ،عنوان کد تععین شده توسط این متغیر میباشد مثلا میتوان نام متغیر اول را ""کد داوطلب"" تعریف نمود");
			// 
			// txt4VarName
			// 
			this.txt4VarName.Location = new System.Drawing.Point(8, 88);
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
			this.txt4Row.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// txt4Col
			// 
			this.txt4Col.Location = new System.Drawing.Point(8, 16);
			this.txt4Col.Name = "txt4Col";
			this.txt4Col.Size = new System.Drawing.Size(56, 20);
			this.txt4Col.TabIndex = 18;
			this.txt4Col.Text = "13";
			this.txt4Col.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			this.txt4Col.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(208, 96);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(48, 16);
			this.label23.TabIndex = 17;
			this.label23.Text = "نام متغير :";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(72, 64);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(64, 16);
			this.label24.TabIndex = 16;
			this.label24.Text = "تعداد گزينه ها :";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(200, 64);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(56, 16);
			this.label25.TabIndex = 15;
			this.label25.Text = "تعداد ارقام :";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(72, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(32, 16);
			this.label26.TabIndex = 14;
			this.label26.Text = "ستون:";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(224, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(32, 16);
			this.label27.TabIndex = 13;
			this.label27.Text = "سطر:";
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
			this.groupBox11.Location = new System.Drawing.Point(8, 256);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(264, 120);
			this.groupBox11.TabIndex = 2;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "متغير سوم   (حداکثر 3 رقم)";
			this.toolTipGlobal.SetToolTip(this.groupBox11, @"در این قسمت متغیرهایی که در برگه وجود دارد را مشخص می کنید،
منظور از سطر شماره حاشیه قسمت بالای برگه می باشد که اغلب 1 است.
ومنظور از ستون شماره ستون اولین رقم متغیرمیباشد که از 1 شروع و تا 31 میتواند باشد.
 و منظور از تعداد ارقام ،تعداد رقمهای آن متغیر میباشد و تعدادگزینه ها در واقع محدوده اعداد هر رقم می باشد
 که معمولا 10 میباشد که بدین معناست که هر رقم از 0 تا 9 متواند باشد.
 و در نهایت منظور از نام متغیر ،عنوان کد تععین شده توسط این متغیر میباشد مثلا میتوان نام متغیر اول را ""کد داوطلب"" تعریف نمود");
			// 
			// txt3VarName
			// 
			this.txt3VarName.Location = new System.Drawing.Point(8, 88);
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
			this.txt3Row.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// txt3Col
			// 
			this.txt3Col.Location = new System.Drawing.Point(8, 16);
			this.txt3Col.Name = "txt3Col";
			this.txt3Col.Size = new System.Drawing.Size(56, 20);
			this.txt3Col.TabIndex = 18;
			this.txt3Col.Text = "09";
			this.txt3Col.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			this.txt3Col.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(208, 96);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(48, 16);
			this.label18.TabIndex = 17;
			this.label18.Text = "نام متغير :";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(72, 64);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(64, 16);
			this.label19.TabIndex = 16;
			this.label19.Text = "تعداد گزينه ها :";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(200, 64);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(56, 16);
			this.label20.TabIndex = 15;
			this.label20.Text = "تعداد ارقام :";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(72, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(32, 16);
			this.label21.TabIndex = 14;
			this.label21.Text = "ستون:";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(224, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(32, 16);
			this.label22.TabIndex = 13;
			this.label22.Text = "سطر:";
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
			this.groupBox10.Location = new System.Drawing.Point(8, 136);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(264, 120);
			this.groupBox10.TabIndex = 1;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "متغير دوم  (حداکثر  5 رقم)";
			this.toolTipGlobal.SetToolTip(this.groupBox10, @"در این قسمت متغیرهایی که در برگه وجود دارد را مشخص می کنید،
منظور از سطر شماره حاشیه قسمت بالای برگه می باشد که اغلب 1 است.
ومنظور از ستون شماره ستون اولین رقم متغیرمیباشد که از 1 شروع و تا 31 میتواند باشد.
 و منظور از تعداد ارقام ،تعداد رقمهای آن متغیر میباشد و تعدادگزینه ها در واقع محدوده اعداد هر رقم می باشد
 که معمولا 10 میباشد که بدین معناست که هر رقم از 0 تا 9 متواند باشد.
 و در نهایت منظور از نام متغیر ،عنوان کد تععین شده توسط این متغیر میباشد مثلا میتوان نام متغیر اول را ""کد داوطلب"" تعریف نمود");
			// 
			// txt2VarName
			// 
			this.txt2VarName.Location = new System.Drawing.Point(8, 88);
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
			this.txt2Digits.Validated += new System.EventHandler(this.txt2Digits_Validated);
			this.txt2Digits.MouseEnter += new System.EventHandler(this.txt2Digits_MouseEnter);
			this.txt2Digits.Leave += new System.EventHandler(this.txt2Digits_Leave);
			this.txt2Digits.MouseLeave += new System.EventHandler(this.txt2Digits_MouseLeave);
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
			this.txt2Row.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// txt2Col
			// 
			this.txt2Col.Location = new System.Drawing.Point(8, 16);
			this.txt2Col.Name = "txt2Col";
			this.txt2Col.Size = new System.Drawing.Size(56, 20);
			this.txt2Col.TabIndex = 18;
			this.txt2Col.Text = "02";
			this.txt2Col.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			this.txt2Col.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(208, 96);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(48, 16);
			this.label13.TabIndex = 17;
			this.label13.Text = "نام متغير :";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(72, 64);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 16);
			this.label14.TabIndex = 16;
			this.label14.Text = "تعداد گزينه ها :";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(200, 64);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 16);
			this.label15.TabIndex = 15;
			this.label15.Text = "تعداد ارقام :";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(72, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 16);
			this.label16.TabIndex = 14;
			this.label16.Text = "ستون:";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(224, 16);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(32, 16);
			this.label17.TabIndex = 13;
			this.label17.Text = "سطر:";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.txt1VarName);
			this.groupBox9.Controls.Add(this.txt1Digits);
			this.groupBox9.Controls.Add(this.txt1Cases);
			this.groupBox9.Controls.Add(this.txt1Row);
			this.groupBox9.Controls.Add(this.txt1Col);
			this.groupBox9.Controls.Add(this.label12);
			this.groupBox9.Controls.Add(this.label35);
			this.groupBox9.Controls.Add(this.label47);
			this.groupBox9.Controls.Add(this.label48);
			this.groupBox9.Controls.Add(this.label49);
			this.groupBox9.Location = new System.Drawing.Point(8, 16);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(264, 120);
			this.groupBox9.TabIndex = 0;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "متغير اول   (حداکثر 12 رقم)";
			this.toolTipGlobal.SetToolTip(this.groupBox9, @"در این قسمت متغیرهایی که در برگه وجود دارد را مشخص می کنید،
منظور از سطر شماره حاشیه قسمت بالای برگه می باشد که اغلب 1 است.
ومنظور از ستون شماره ستون اولین رقم متغیرمیباشد که از 1 شروع و تا 31 میتواند باشد.
 و منظور از تعداد ارقام ،تعداد رقمهای آن متغیر میباشد و تعدادگزینه ها در واقع محدوده اعداد هر رقم می باشد
 که معمولا 10 میباشد که بدین معناست که هر رقم از 0 تا 9 متواند باشد.
 و در نهایت منظور از نام متغیر ،عنوان کد تععین شده توسط این متغیر میباشد مثلا میتوان نام متغیر اول را ""کد داوطلب"" تعریف نمود");
			// 
			// txt1VarName
			// 
			this.txt1VarName.Location = new System.Drawing.Point(8, 88);
			this.txt1VarName.Name = "txt1VarName";
			this.txt1VarName.Size = new System.Drawing.Size(200, 20);
			this.txt1VarName.TabIndex = 12;
			this.txt1VarName.Text = "کد داوطلب";
			this.txt1VarName.Validated += new System.EventHandler(this.txt1VarName_Validated);
			// 
			// txt1Digits
			// 
			this.txt1Digits.Location = new System.Drawing.Point(144, 56);
			this.txt1Digits.Name = "txt1Digits";
			this.txt1Digits.Size = new System.Drawing.Size(56, 20);
			this.txt1Digits.TabIndex = 11;
			this.txt1Digits.Text = "09";
			this.txt1Digits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			this.txt1Digits.Validated += new System.EventHandler(this.txt1Digits_Validated);
			this.txt1Digits.MouseEnter += new System.EventHandler(this.txt1Digits_MouseEnter);
			this.txt1Digits.Leave += new System.EventHandler(this.txt1Digits_Leave);
			this.txt1Digits.MouseLeave += new System.EventHandler(this.txt1Digits_MouseLeave);
			// 
			// txt1Cases
			// 
			this.txt1Cases.Location = new System.Drawing.Point(8, 56);
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
			this.txt1Row.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// txt1Col
			// 
			this.txt1Col.Location = new System.Drawing.Point(8, 24);
			this.txt1Col.Name = "txt1Col";
			this.txt1Col.Size = new System.Drawing.Size(56, 20);
			this.txt1Col.TabIndex = 8;
			this.txt1Col.Text = "18";
			this.txt1Col.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHorDistance_KeyPress);
			this.txt1Col.Validated += new System.EventHandler(this.txt1Row_Validated);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(208, 96);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 16);
			this.label12.TabIndex = 7;
			this.label12.Text = "نام متغير :";
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(72, 64);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(64, 16);
			this.label35.TabIndex = 6;
			this.label35.Text = "تعداد گزينه ها :";
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(200, 64);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(56, 16);
			this.label47.TabIndex = 5;
			this.label47.Text = "تعداد ارقام :";
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(72, 24);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(32, 16);
			this.label48.TabIndex = 2;
			this.label48.Text = "ستون:";
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(224, 24);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(32, 16);
			this.label49.TabIndex = 1;
			this.label49.Text = "سطر:";
			// 
			// label59
			// 
			this.label59.Enabled = false;
			this.label59.Location = new System.Drawing.Point(608, 360);
			this.label59.Name = "label59";
			this.label59.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label59.Size = new System.Drawing.Size(40, 24);
			this.label59.TabIndex = 25;
			this.label59.Text = "موضوع :";
			// 
			// panelOutPutSettings
			// 
			this.panelOutPutSettings.Controls.Add(this.groupPath);
			this.panelOutPutSettings.Controls.Add(this.groupBox5);
			this.panelOutPutSettings.Location = new System.Drawing.Point(0, 0);
			this.panelOutPutSettings.Name = "panelOutPutSettings";
			this.panelOutPutSettings.Size = new System.Drawing.Size(664, 664);
			this.panelOutPutSettings.TabIndex = 2;
			this.toolTipGlobal.SetToolTip(this.panelOutPutSettings, "قسمت مربوط به خروجی و نحوه ذخیره آن را مشاهده می فرمایید ");
			this.panelOutPutSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOutPutSettings_Paint);
			// 
			// groupPath
			// 
			this.groupPath.Controls.Add(this.pictureBox17);
			this.groupPath.Controls.Add(this.label50);
			this.groupPath.Controls.Add(this.txtPath);
			this.groupPath.Controls.Add(this.label51);
			this.groupPath.Controls.Add(this.txtOutPutFileName);
			this.groupPath.Controls.Add(this.label52);
			this.groupPath.Location = new System.Drawing.Point(32, 32);
			this.groupPath.Name = "groupPath";
			this.groupPath.Size = new System.Drawing.Size(616, 80);
			this.groupPath.TabIndex = 25;
			this.groupPath.TabStop = false;
			this.groupPath.Text = "مسير خروجي";
			// 
			// pictureBox17
			// 
			this.pictureBox17.ContextMenu = this.conMnu;
			this.pictureBox17.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox17.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox17.Image")));
			this.pictureBox17.Location = new System.Drawing.Point(328, 8);
			this.pictureBox17.Name = "pictureBox17";
			this.pictureBox17.Size = new System.Drawing.Size(64, 64);
			this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox17.TabIndex = 26;
			this.pictureBox17.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox17, "نرم افزار دارای 5 قسمت (صفحه) میباشد که برای حرکت بین آنها از این دکمه ،استفاده م" +
				"ی کنیم \nاز طرف دیگر برای راحتی بیشتر یک منو در نظر گرفته شده که در صورت راست کلی" +
				"ک\n کردن روی دکمه ها ظاهر می شود به وسیله این منو می توانید به صفحه مورد نظر مراج" +
				"ه نمایید");
			this.pictureBox17.Click += new System.EventHandler(this.pictureBox17_Click);
			this.pictureBox17.MouseEnter += new System.EventHandler(this.pictureBox17_MouseEnter);
			this.pictureBox17.MouseLeave += new System.EventHandler(this.pictureBox17_MouseLeave);
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(8, 32);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(72, 24);
			this.label50.TabIndex = 3;
			this.label50.Text = "مسير خروجي";
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(80, 32);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(248, 21);
			this.txtPath.TabIndex = 1;
			this.txtPath.Text = "";
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(392, 32);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(40, 24);
			this.label51.TabIndex = 3;
			this.label51.Text = "نام فايل";
			// 
			// txtOutPutFileName
			// 
			this.txtOutPutFileName.Location = new System.Drawing.Point(432, 32);
			this.txtOutPutFileName.Name = "txtOutPutFileName";
			this.txtOutPutFileName.Size = new System.Drawing.Size(136, 21);
			this.txtOutPutFileName.TabIndex = 1;
			this.txtOutPutFileName.Text = "";
			this.toolTipGlobal.SetToolTip(this.txtOutPutFileName, "ابتدا باید در جعبه متن بالای صفحه نام فایل مورد نظر را تایپ نمایید");
			// 
			// label52
			// 
			this.label52.Location = new System.Drawing.Point(568, 32);
			this.label52.Name = "label52";
			this.label52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label52.Size = new System.Drawing.Size(24, 24);
			this.label52.TabIndex = 3;
			this.label52.Text = ".txt";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox5
			// 
			this.groupBox5.BackColor = System.Drawing.Color.Transparent;
			this.groupBox5.Controls.Add(this.listOutPutFiles);
			this.groupBox5.Controls.Add(this.pictureBox18);
			this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.groupBox5.Location = new System.Drawing.Point(32, 120);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.groupBox5.Size = new System.Drawing.Size(616, 344);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "نحوه ذخيره نتايج";
			// 
			// listOutPutFiles
			// 
			this.listOutPutFiles.Location = new System.Drawing.Point(16, 120);
			this.listOutPutFiles.Name = "listOutPutFiles";
			this.listOutPutFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.listOutPutFiles.Size = new System.Drawing.Size(576, 212);
			this.listOutPutFiles.TabIndex = 28;
			// 
			// pictureBox18
			// 
			this.pictureBox18.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox18.ContextMenu = this.conMnu;
			this.pictureBox18.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.pictureBox18.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox18.Image")));
			this.pictureBox18.Location = new System.Drawing.Point(480, 32);
			this.pictureBox18.Name = "pictureBox18";
			this.pictureBox18.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.pictureBox18.Size = new System.Drawing.Size(96, 88);
			this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox18.TabIndex = 27;
			this.pictureBox18.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox18, "نرم افزار دارای 5 قسمت (صفحه) میباشد که برای حرکت بین آنها از این دکمه ،استفاده م" +
				"ی کنیم \nاز طرف دیگر برای راحتی بیشتر یک منو در نظر گرفته شده که در صورت راست کلی" +
				"ک\n کردن روی دکمه ها ظاهر می شود به وسیله این منو می توانید به صفحه مورد نظر مراج" +
				"ه نمایید");
			this.pictureBox18.Click += new System.EventHandler(this.btnSave_Click);
			this.pictureBox18.MouseEnter += new System.EventHandler(this.pictureBox18_MouseEnter);
			this.pictureBox18.MouseLeave += new System.EventHandler(this.pictureBox18_MouseLeave);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 664);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.statusBarPanel1,
																						 this.statusBarPanel2,
																						 this.statusBarPanel3,
																						 this.statusBarPanel4,
																						 this.statusBarPanel5,
																						 this.statusBarPanel6});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(664, 22);
			this.statusBar.TabIndex = 9;
			this.statusBar.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar_PanelClick);
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Text = "تعداد برگه ها:";
			this.statusBarPanel1.Width = 150;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.Text = "تعداد برگه های صحیح:";
			this.statusBarPanel2.Width = 150;
			// 
			// statusBarPanel3
			// 
			this.statusBarPanel3.Text = "تعداد برگه های خطادار:";
			this.statusBarPanel3.Width = 150;
			// 
			// statusBarPanel4
			// 
			this.statusBarPanel4.Width = 150;
			// 
			// statusBarPanel5
			// 
			this.statusBarPanel5.Width = 175;
			// 
			// statusBarPanel6
			// 
			this.statusBarPanel6.Width = 300;
			// 
			// panelAnalyze
			// 
			this.panelAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panelAnalyze.Controls.Add(this.groupBox2);
			this.panelAnalyze.Controls.Add(this.lblWeakPoints);
			this.panelAnalyze.Controls.Add(this.label63);
			this.panelAnalyze.Controls.Add(this.pictureBox19);
			this.panelAnalyze.Controls.Add(this.txtSearchParam);
			this.panelAnalyze.Controls.Add(this.button3);
			this.panelAnalyze.Controls.Add(this.button4);
			this.panelAnalyze.Controls.Add(this.dataGrid);
			this.panelAnalyze.Controls.Add(this.button1);
			this.panelAnalyze.Controls.Add(this.button6);
			this.panelAnalyze.Controls.Add(this.lbl);
			this.panelAnalyze.Location = new System.Drawing.Point(349, 0);
			this.panelAnalyze.Name = "panelAnalyze";
			this.panelAnalyze.Size = new System.Drawing.Size(320, 1307);
			this.panelAnalyze.TabIndex = 28;
			this.panelAnalyze.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAnalyze_Paint);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkPaint2);
			this.groupBox2.Controls.Add(this.chkDisplay2);
			this.groupBox2.Location = new System.Drawing.Point(8, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(272, 48);
			this.groupBox2.TabIndex = 38;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "نحوه نمایش ";
			// 
			// chkPaint2
			// 
			this.chkPaint2.Location = new System.Drawing.Point(8, 24);
			this.chkPaint2.Name = "chkPaint2";
			this.chkPaint2.Size = new System.Drawing.Size(96, 16);
			this.chkPaint2.TabIndex = 1;
			this.chkPaint2.Text = "ویرایش در Paint";
			this.chkPaint2.CheckedChanged += new System.EventHandler(this.chkPaint2_CheckedChanged);
			// 
			// chkDisplay2
			// 
			this.chkDisplay2.Location = new System.Drawing.Point(168, 24);
			this.chkDisplay2.Name = "chkDisplay2";
			this.chkDisplay2.Size = new System.Drawing.Size(96, 16);
			this.chkDisplay2.TabIndex = 0;
			this.chkDisplay2.Text = "نمایش جداگانه";
			this.chkDisplay2.CheckedChanged += new System.EventHandler(this.chkDisplay2_CheckedChanged);
			// 
			// lblWeakPoints
			// 
			this.lblWeakPoints.Location = new System.Drawing.Point(96, 472);
			this.lblWeakPoints.Name = "lblWeakPoints";
			this.lblWeakPoints.Size = new System.Drawing.Size(72, 24);
			this.lblWeakPoints.TabIndex = 28;
			this.lblWeakPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label63
			// 
			this.label63.Location = new System.Drawing.Point(176, 112);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(64, 16);
			this.label63.TabIndex = 27;
			this.label63.Text = "کد داوطلب :";
			// 
			// pictureBox19
			// 
			this.pictureBox19.ContextMenu = this.conMnu;
			this.pictureBox19.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox19.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox19.Image")));
			this.pictureBox19.Location = new System.Drawing.Point(240, 88);
			this.pictureBox19.Name = "pictureBox19";
			this.pictureBox19.Size = new System.Drawing.Size(48, 48);
			this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox19.TabIndex = 26;
			this.pictureBox19.TabStop = false;
			this.toolTipGlobal.SetToolTip(this.pictureBox19, "نرم افزار دارای 5 قسمت (صفحه) میباشد که برای حرکت بین آنها از این دکمه ،استفاده م" +
				"ی کنیم \nاز طرف دیگر برای راحتی بیشتر یک منو در نظر گرفته شده که در صورت راست کلی" +
				"ک\n کردن روی دکمه ها ظاهر می شود به وسیله این منو می توانید به صفحه مورد نظر مراج" +
				"ه نمایید");
			this.pictureBox19.Click += new System.EventHandler(this.pictureBox19_Click);
			this.pictureBox19.MouseEnter += new System.EventHandler(this.pictureBox19_MouseEnter);
			this.pictureBox19.MouseLeave += new System.EventHandler(this.pictureBox19_MouseLeave);
			// 
			// txtSearchParam
			// 
			this.txtSearchParam.Location = new System.Drawing.Point(8, 104);
			this.txtSearchParam.Name = "txtSearchParam";
			this.txtSearchParam.Size = new System.Drawing.Size(168, 21);
			this.txtSearchParam.TabIndex = 9;
			this.txtSearchParam.Text = "";
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(216, 512);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 80);
			this.button3.TabIndex = 8;
			this.button3.Text = "اصلاح برگه جاري";
			this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
			this.button4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button4.Location = new System.Drawing.Point(32, 512);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(72, 80);
			this.button4.TabIndex = 7;
			this.button4.Text = "ذخيره نتايج در پا يگاه داده ";
			this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// dataGrid
			// 
			this.dataGrid.AllowSorting = false;
			this.dataGrid.DataMember = "";
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(8, 184);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.Size = new System.Drawing.Size(288, 280);
			this.dataGrid.TabIndex = 6;
			this.dataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								 this.dataGridTableStyle1});
			this.dataGrid.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid_Navigate);
			this.dataGrid.CurrentCellChanged += new System.EventHandler(this.dataGrid_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgCounter;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "TempResults";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = " قسمت اول کد داوطلب";
			this.dataGridTextBoxColumn1.MappingName = "strVar1CodeFirst";
			this.dataGridTextBoxColumn1.Width = 200;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "قسمت دوم کد داوطلب";
			this.dataGridTextBoxColumn4.MappingName = "strVar1CodeSecond";
			this.dataGridTextBoxColumn4.Width = 75;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "نتیجه نهایی";
			this.dataGridTextBoxColumn2.MappingName = "SavedResult";
			this.dataGridTextBoxColumn2.Width = 250;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "مسیر";
			this.dataGridTextBoxColumn3.MappingName = "Path";
			this.dataGridTextBoxColumn3.Width = 350;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(72, 600);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(176, 56);
			this.button1.TabIndex = 8;
			this.button1.Text = "برگشت به صفحه اصلي";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button6
			// 
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
			this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button6.Location = new System.Drawing.Point(80, 16);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(144, 72);
			this.button6.TabIndex = 8;
			this.button6.Text = "حذف کل نتايج";
			this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// lbl
			// 
			this.lbl.Location = new System.Drawing.Point(176, 472);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(120, 24);
			this.lbl.TabIndex = 28;
			this.lbl.Text = "تعداد گزینه های ضعیف :";
			this.lbl.Click += new System.EventHandler(this.lbl_Click);
			// 
			// dgCounter
			// 
			this.dgCounter.AllowSorting = false;
			this.dgCounter.CaptionText = "وضعیت برگه های بدون شماره";
			this.dgCounter.DataMember = "";
			this.dgCounter.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCounter.Location = new System.Drawing.Point(32, 40);
			this.dgCounter.Name = "dgCounter";
			this.dgCounter.Size = new System.Drawing.Size(600, 440);
			this.dgCounter.TabIndex = 10;
			this.dgCounter.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dgCounter.CurrentCellChanged += new System.EventHandler(this.dgCounter_CurrentCellChanged);
			// 
			// panelPaint
			// 
			this.panelPaint.Controls.Add(this.label46);
			this.panelPaint.Location = new System.Drawing.Point(0, 0);
			this.panelPaint.Name = "panelPaint";
			this.panelPaint.Size = new System.Drawing.Size(664, 664);
			this.panelPaint.TabIndex = 29;
			this.toolTipGlobal.SetToolTip(this.panelPaint, " قسمت(صفحه) اول را مشاهده می نمایید که حاصل تصحیح برگه را نمایش می دهد\n،در بالا س" +
				"ربرگ که ممکن است شامل شماره داوطلب و شماره آزمون باشد و در زیر سؤالات و گزینه ها" +
				" نمایش داده می شود ");
			this.panelPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.OrginalForm_Paint);
			this.panelPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPaint_MouseDown);
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(184, 8);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(64, 16);
			this.label46.TabIndex = 0;
			this.label46.Text = "کد داوطلب :";
			// 
			// panelPerformanceStatus
			// 
			this.panelPerformanceStatus.Controls.Add(this.button7);
			this.panelPerformanceStatus.Controls.Add(this.dataGridErrList);
			this.panelPerformanceStatus.Location = new System.Drawing.Point(0, 0);
			this.panelPerformanceStatus.Name = "panelPerformanceStatus";
			this.panelPerformanceStatus.Size = new System.Drawing.Size(664, 664);
			this.panelPerformanceStatus.TabIndex = 30;
			this.toolTipGlobal.SetToolTip(this.panelPerformanceStatus, "قسمت مربوط گزارش خطاها یا گزارش وضعیت عملکرد را مشاهده می فرمایید ");
			this.panelPerformanceStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPerformanceStatus_Paint);
			// 
			// button7
			// 
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
			this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button7.Location = new System.Drawing.Point(232, 504);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(168, 88);
			this.button7.TabIndex = 9;
			this.button7.Text = "حذف کل نتايج";
			this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTipGlobal.SetToolTip(this.button7, "چنانچه مایل به حذف کل نتایج باشید می توانید روی دکمه ی حذف کل نتایج کلیک نمایید");
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// dataGridErrList
			// 
			this.dataGridErrList.CaptionText = "وضعيت عملکرد";
			this.dataGridErrList.DataMember = "";
			this.dataGridErrList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridErrList.Location = new System.Drawing.Point(16, 16);
			this.dataGridErrList.Name = "dataGridErrList";
			this.dataGridErrList.Size = new System.Drawing.Size(624, 464);
			this.dataGridErrList.TabIndex = 0;
			this.toolTipGlobal.SetToolTip(this.dataGridErrList, "جدول خطاهای رخ داده بر روی برگه ها");
			this.dataGridErrList.CurrentCellChanged += new System.EventHandler(this.dataGridErrList_CurrentCellChanged);
			// 
			// panelColorSettings
			// 
			this.panelColorSettings.Controls.Add(this.label62);
			this.panelColorSettings.Controls.Add(this.lblRed);
			this.panelColorSettings.Controls.Add(this.label56);
			this.panelColorSettings.Controls.Add(this.trkRed);
			this.panelColorSettings.Controls.Add(this.trkGreen);
			this.panelColorSettings.Controls.Add(this.trkBlue);
			this.panelColorSettings.Controls.Add(this.label60);
			this.panelColorSettings.Controls.Add(this.label61);
			this.panelColorSettings.Controls.Add(this.lblGreen);
			this.panelColorSettings.Controls.Add(this.lblBlue);
			this.panelColorSettings.Location = new System.Drawing.Point(0, 0);
			this.panelColorSettings.Name = "panelColorSettings";
			this.panelColorSettings.Size = new System.Drawing.Size(664, 664);
			this.panelColorSettings.TabIndex = 31;
			this.toolTipGlobal.SetToolTip(this.panelColorSettings, " قسمت مربوط به تنظیم رنگ نرم افزار را مشاهده می فرمایید که بوسیله آن می توانید\n ر" +
				"نگ پس زمینه نرم افزار را نغییر داده و بدین ترتیب هیچگاه از محیط نرم افزار خسته ن" +
				"شوید");
			// 
			// label62
			// 
			this.label62.Location = new System.Drawing.Point(240, 40);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(176, 48);
			this.label62.TabIndex = 3;
			this.label62.Text = "تنظيم رنگ پس زمينه نرم افزار";
			// 
			// lblRed
			// 
			this.lblRed.Location = new System.Drawing.Point(72, 136);
			this.lblRed.Name = "lblRed";
			this.lblRed.Size = new System.Drawing.Size(56, 32);
			this.lblRed.TabIndex = 2;
			// 
			// label56
			// 
			this.label56.Location = new System.Drawing.Point(544, 128);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(32, 24);
			this.label56.TabIndex = 1;
			this.label56.Text = "قرمز";
			// 
			// trkRed
			// 
			this.trkRed.Cursor = System.Windows.Forms.Cursors.Hand;
			this.trkRed.Location = new System.Drawing.Point(144, 128);
			this.trkRed.Maximum = 255;
			this.trkRed.Name = "trkRed";
			this.trkRed.Size = new System.Drawing.Size(400, 45);
			this.trkRed.TabIndex = 0;
			this.trkRed.TickStyle = System.Windows.Forms.TickStyle.None;
			this.toolTipGlobal.SetToolTip(this.trkRed, "زبانه را حرکت دهید تا تغییر رنگ را ببینید");
			this.trkRed.ValueChanged += new System.EventHandler(this.trkRed_ValueChanged);
			// 
			// trkGreen
			// 
			this.trkGreen.Cursor = System.Windows.Forms.Cursors.Hand;
			this.trkGreen.Location = new System.Drawing.Point(144, 208);
			this.trkGreen.Maximum = 255;
			this.trkGreen.Name = "trkGreen";
			this.trkGreen.Size = new System.Drawing.Size(400, 45);
			this.trkGreen.TabIndex = 0;
			this.trkGreen.TickStyle = System.Windows.Forms.TickStyle.None;
			this.toolTipGlobal.SetToolTip(this.trkGreen, "زبانه را حرکت دهید تا تغییر رنگ را ببینید");
			this.trkGreen.ValueChanged += new System.EventHandler(this.trkGreen_ValueChanged);
			// 
			// trkBlue
			// 
			this.trkBlue.Cursor = System.Windows.Forms.Cursors.Hand;
			this.trkBlue.Location = new System.Drawing.Point(144, 288);
			this.trkBlue.Maximum = 255;
			this.trkBlue.Name = "trkBlue";
			this.trkBlue.Size = new System.Drawing.Size(400, 45);
			this.trkBlue.TabIndex = 0;
			this.trkBlue.TickStyle = System.Windows.Forms.TickStyle.None;
			this.toolTipGlobal.SetToolTip(this.trkBlue, "زبانه را حرکت دهید تا تغییر رنگ را ببینید");
			this.trkBlue.ValueChanged += new System.EventHandler(this.trkBlue_ValueChanged);
			// 
			// label60
			// 
			this.label60.Location = new System.Drawing.Point(552, 208);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(24, 24);
			this.label60.TabIndex = 1;
			this.label60.Text = "سبز";
			// 
			// label61
			// 
			this.label61.Location = new System.Drawing.Point(552, 288);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(24, 24);
			this.label61.TabIndex = 1;
			this.label61.Text = "آبي";
			// 
			// lblGreen
			// 
			this.lblGreen.Location = new System.Drawing.Point(72, 216);
			this.lblGreen.Name = "lblGreen";
			this.lblGreen.Size = new System.Drawing.Size(56, 32);
			this.lblGreen.TabIndex = 2;
			// 
			// lblBlue
			// 
			this.lblBlue.Location = new System.Drawing.Point(72, 296);
			this.lblBlue.Name = "lblBlue";
			this.lblBlue.Size = new System.Drawing.Size(56, 32);
			this.lblBlue.TabIndex = 2;
			// 
			// toolTipGlobal
			// 
			this.toolTipGlobal.AutoPopDelay = 30000;
			this.toolTipGlobal.InitialDelay = 500;
			this.toolTipGlobal.ReshowDelay = 100;
			this.toolTipGlobal.ShowAlways = true;
			// 
			// panelNonCounterDisplay
			// 
			this.panelNonCounterDisplay.Controls.Add(this.dgCounter);
			this.panelNonCounterDisplay.Controls.Add(this.button8);
			this.panelNonCounterDisplay.Controls.Add(this.button9);
			this.panelNonCounterDisplay.Location = new System.Drawing.Point(0, 0);
			this.panelNonCounterDisplay.Name = "panelNonCounterDisplay";
			this.panelNonCounterDisplay.Size = new System.Drawing.Size(664, 664);
			this.panelNonCounterDisplay.TabIndex = 32;
			this.toolTipGlobal.SetToolTip(this.panelNonCounterDisplay, "قسمت مربوط گزارش خطاها یا گزارش وضعیت عملکرد را مشاهده می فرمایید ");
			// 
			// button8
			// 
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
			this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button8.Location = new System.Drawing.Point(136, 504);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(192, 104);
			this.button8.TabIndex = 9;
			this.button8.Text = "حذف کل نتايج";
			this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTipGlobal.SetToolTip(this.button8, "چنانچه مایل به حذف کل نتایج باشید می توانید روی دکمه ی حذف کل نتایج کلیک نمایید");
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
			this.button9.Location = new System.Drawing.Point(344, 504);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(192, 104);
			this.button9.TabIndex = 9;
			this.button9.Text = "به نتایج اضافه شود";
			this.toolTipGlobal.SetToolTip(this.button9, "چنانچه مایلید که این برگه ها به کل نتایج  اضافه شوند باشید می توانید روی این کلیک" +
				" نمایید");
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// OrginalForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.ClientSize = new System.Drawing.Size(614, 339);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.groupMain);
			this.Controls.Add(this.panelAnalyze);
			this.Controls.Add(this.panelPaint);
			this.Controls.Add(this.panelNonCounterDisplay);
			this.Controls.Add(this.panelOutPutSettings);
			this.Controls.Add(this.panelColorSettings);
			this.Controls.Add(this.panelPageSettings);
			this.Controls.Add(this.panelPerformanceStatus);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "OrginalForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "سيستم تشخيص صفحه هاي تستي";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrginalForm_KeyDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.OrginalForm_Closing);
			this.Load += new System.EventHandler(this.OrginalForm_Load);
			this.groupMain.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupReadMethod.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trkThr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkSence)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkCodeDarkPoints)).EndInit();
			this.panelPageSettings.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox16.ResumeLayout(false);
			this.groupBox15.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox9.ResumeLayout(false);
			this.panelOutPutSettings.ResumeLayout(false);
			this.groupPath.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel6)).EndInit();
			this.panelAnalyze.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgCounter)).EndInit();
			this.panelPaint.ResumeLayout(false);
			this.panelPerformanceStatus.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridErrList)).EndInit();
			this.panelColorSettings.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trkRed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkGreen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkBlue)).EndInit();
			this.panelNonCounterDisplay.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private	void LoadBmpInArray()
		{
			//min(r,g,b) = (r<g)?(r<b)?r:b:(g<b)?g:b;
			//max(r,g,b) = (r>g)?(r>b)?r:b:(g>b)?g:b;
			//bright = 0.55 *( max +	min)
			//sat =if (max==min) then sat=0	 
			//		else if	(br	< 0.55 )then	sat=(max-min)/(max+min)	
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
						pixeles[nRowIndex,nColumnIndex]= (byte)(0.299*rgbPtr [2]+0.5587*	rgbPtr [1]+0.114*rgbPtr	[0]);
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
				return	(float)(0.299* bmpPtr[2]+0.5587*	 bmpPtr[1]+0.114* bmpPtr[0])/255;
			}
		}
		[STAThread]
		static void	Main() 
		{
			try
			{
				string strMDBPath=Application.StartupPath ;
				strMDBPath+="\\FormReader.mdb";
				if(!File.Exists (strMDBPath))
				{
					MessageBox.Show("پایگاه داده نرم افزار موجود نیست");
					Application.Exit();
				}
				else
				{
					LockCheker lc=new LockCheker();
					if(lc.IsCorrect())
					{					
						Application.Run(new	OrginalForm ());
					}
					else
						Application.Exit();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message );
			}
		}
		void ComputeDistanceArray()
		{
			int	[,]arrTemp={
							   {(int)(cellSize * 0.09),(int)(cellSize * 0.04)},
							   {(int)(cellSize * 0.09),(int)(cellSize * 0.08)},
							   {(int)(cellSize * 0.09),(int)(cellSize * 0.12)},
							   {(int)(cellSize * 0.09),(int)(cellSize * 0.16)},
							   {(int)(cellSize * -0.09),(int)(cellSize *	0.04)},
							   {(int)(cellSize * -0.09),(int)(cellSize *	0.08)},
							   {(int)(cellSize * -0.09),(int)(cellSize *	0.12)},
							   {(int)(cellSize * -0.09),(int)(cellSize *	0.16)},

							   {(int)(cellSize * 0.09),(int)(cellSize * -0.04)},
							   {(int)(cellSize * 0.09),(int)(cellSize * -0.08)},	
							   {(int)(cellSize * 0.09),(int)(cellSize * -0.12)},
							   {(int)(cellSize * 0.09),(int)(cellSize * -0.16)},
							   {(int)(cellSize * -0.09),(int)(cellSize *	-0.04)},
							   {(int)(cellSize * -0.09),(int)(cellSize *	-0.08)},
							   {(int)(cellSize * -0.09),(int)(cellSize *	-0.12)},
							   {(int)(cellSize * -0.09),(int)(cellSize *	-0.16)},


							   {(int)(cellSize * 0.18),(int)(cellSize * 0.04)},
							   {(int)(cellSize * 0.18),(int)(cellSize * 0.08)},
							   {(int)(cellSize * 0.18),(int)(cellSize * 0.12)},
							   {(int)(cellSize * 0.18),(int)(cellSize * 0.16)},
							   {(int)(cellSize * -0.18),(int)(cellSize *	0.04)},
							   {(int)(cellSize * -0.18),(int)(cellSize *	0.08)},
							   {(int)(cellSize * -0.18),(int)(cellSize *	0.12)},
							   {(int)(cellSize * -0.18),(int)(cellSize *	0.16)},
							   
							   {(int)(cellSize * 0.18),(int)(cellSize * -0.04)},
							   {(int)(cellSize * 0.18),(int)(cellSize * -0.08)},	
							   {(int)(cellSize * 0.18),(int)(cellSize * -0.12)},
							   {(int)(cellSize * 0.18),(int)(cellSize * -0.16)},
							   {(int)(cellSize * -0.18),(int)(cellSize *	-0.04)},
							   {(int)(cellSize * -0.18),(int)(cellSize *	-0.08)},
							   {(int)(cellSize * -0.18),(int)(cellSize *	-0.12)},
							   {(int)(cellSize * -0.18),(int)(cellSize *	-0.16)},
								

							   {(int)(cellSize * 0.27),(int)(cellSize * 0.04)},
							   {(int)(cellSize * 0.27),(int)(cellSize * 0.08)},
							   {(int)(cellSize * 0.27),(int)(cellSize * 0.12)},
							   {(int)(cellSize * 0.27),(int)(cellSize * 0.16)},
							   {(int)(cellSize * -0.27),(int)(cellSize *	0.04)},
							   {(int)(cellSize * -0.27),(int)(cellSize *	0.08)},
							   {(int)(cellSize * -0.27),(int)(cellSize *	0.12)},
							   {(int)(cellSize * -0.27),(int)(cellSize *	0.16)},

							   {(int)(cellSize * 0.27),(int)(cellSize * -0.04)},
							   {(int)(cellSize * 0.27),(int)(cellSize * -0.08)},	
							   {(int)(cellSize * 0.27),(int)(cellSize * -0.12)},
							   {(int)(cellSize * 0.27),(int)(cellSize * -0.16)},
							   {(int)(cellSize * -0.27),(int)(cellSize *	-0.04)},
							   {(int)(cellSize * -0.27),(int)(cellSize *	-0.08)},
							   {(int)(cellSize * -0.27),(int)(cellSize *	-0.12)},
							   {(int)(cellSize * -0.27),(int)(cellSize *	-0.16)},


							   {(int)(cellSize * 0.36),(int)(cellSize * 0.04)},
							   {(int)(cellSize * 0.36),(int)(cellSize * 0.08)},					 
							   {(int)(cellSize * 0.36),(int)(cellSize * 0.12)},
							   {(int)(cellSize * 0.36),(int)(cellSize * 0.16)},
							   {(int)(cellSize * -0.36),(int)(cellSize *	0.04)},
							   {(int)(cellSize * -0.36),(int)(cellSize *	0.08)},
							   {(int)(cellSize * -0.36),(int)(cellSize *	0.12)},
							   {(int)(cellSize * -0.36),(int)(cellSize *	0.16)},

							   {(int)(cellSize * 0.36),(int)(cellSize * -0.04)},
							   {(int)(cellSize * 0.36),(int)(cellSize * -0.08)},					 
							   {(int)(cellSize * 0.36),(int)(cellSize * -0.12)},
							   {(int)(cellSize * 0.36),(int)(cellSize * -0.16)},
							   {(int)(cellSize * -0.36),(int)(cellSize *	-0.04)},
							   {(int)(cellSize * -0.36),(int)(cellSize *	-0.08)},
							   {(int)(cellSize * -0.36),(int)(cellSize *	-0.12)},
							   {(int)(cellSize * -0.36),(int)(cellSize *	-0.16)},
			};
			//arrDistance=new int[64,2];
			arrDistance=(int[,])arrTemp.Clone();
			//arrTemp.CopyTo(arrDistance,0);
		}
		void ComputeTopDistanceArray()
		{
			int caseSize=cellSize/5;
			int	[,]arrTemp={
							   {(int)(caseSize),(int)(caseSize * 2.0/3)},
							   {(int)(caseSize ),(int)(caseSize * 1.0/3)},							   
							   {(int)(caseSize),(int)(caseSize * -2.0/3)},
							   {(int)(caseSize ),(int)(caseSize * -1.0/3)},	
							   {(int)(-1*caseSize ),(int)(caseSize * 2.0/3)},
							   {(int)(-1*caseSize  ),(int)(caseSize * 1.0/3)},							   						   
							   {(int)(-1*caseSize ),(int)(caseSize * -2.0/3)},
							   {(int)(-1*caseSize  ),(int)(caseSize * -1.0/3)},

							   {(int)(caseSize* 2/3.0),(int)(caseSize * 2.0/3)},
							   {(int)(caseSize *2/3.0),(int)(caseSize * 1.0/3)},	
							   {(int)(caseSize *2/3.0),(int)(caseSize * -2.0/3)},
							   {(int)(caseSize *2/3.0),(int)(caseSize * -1.0/3)},
							   {(int)(caseSize *-2/3.0),(int)(caseSize * 2.0/3)},
							   {(int)(caseSize *-2/3.0),(int)(caseSize * 1.0/3)},
							   {(int)(caseSize *-2/3.0),(int)(caseSize *	-2.0/3)},
							   {(int)(caseSize *-2/3.0),(int)(caseSize *	-1.0/3)},


							   {(int)(caseSize *1.0/3),(int)(caseSize * 2.0/3)},
							   {(int)(caseSize *1.0/3),(int)(caseSize * 1.0/3)},
							   {(int)(caseSize *1.0/3),(int)(caseSize * -2.0/3)},
							   {(int)(caseSize *1.0/3),(int)(caseSize * -1.0/3)},
							   {(int)(caseSize *-1.0/3),(int)(caseSize * 2.0/3)},
							   {(int)(caseSize *-1.0/3),(int)(caseSize * 1.0/3)},
							   {(int)(caseSize *-1.0/3),(int)(caseSize *	-2.0/3)},
							   {(int)(caseSize *-1.0/3),(int)(caseSize *	-1.0/3)},
							   
							   {(int)(0),(int)(caseSize * 2.0/3)},
							   {(int)(0),(int)(caseSize * 1.0/3)},	
							   {(int)(0),(int)(caseSize * -2.0/3)},
							   {(int)(0),(int)(caseSize * -1.0/3)},
							   {(int)(0),(int)(caseSize * 2.0/4)},
							   {(int)(0),(int)(caseSize * 1.0/4)},	
							   {(int)(0),(int)(caseSize * -2.0/4)},
							   {(int)(0),(int)(caseSize * -1.0/4)},	

							   {(int)(caseSize),(int)(caseSize * 2.0/3)},
							   {(int)(caseSize ),(int)(caseSize * 1.0/3)},							   
							   {(int)(caseSize),(int)(caseSize * -2.0/3)},
							   {(int)(caseSize ),(int)(caseSize * -1.0/3)},	
							   {(int)(-1*caseSize ),(int)(caseSize * 2.0/3)},
							   {(int)(-1*caseSize  ),(int)(caseSize * 1.0/3)},							   						   
							   {(int)(-1*caseSize ),(int)(caseSize * -2.0/3)},
							   {(int)(-1*caseSize  ),(int)(caseSize * -1.0/3)},

							   {(int)(caseSize* 2/3.0),(int)(caseSize * 2.0/3)},
							   {(int)(caseSize *2/3.0),(int)(caseSize * 1.0/3)},	
							   {(int)(caseSize *2/3.0),(int)(caseSize * -2.0/3)},
							   {(int)(caseSize *2/3.0),(int)(caseSize * -1.0/3)},
							   {(int)(caseSize *-2/3.0),(int)(caseSize * 2.0/3)},
							   {(int)(caseSize *-2/3.0),(int)(caseSize * 1.0/3)},
							   {(int)(caseSize *-2/3.0),(int)(caseSize *	-2.0/3)},
							   {(int)(caseSize *-2/3.0),(int)(caseSize *	-1.0/3)},


							   {(int)(caseSize *1.0/3),(int)(caseSize * 2.0/3)},
							   {(int)(caseSize *1.0/3),(int)(caseSize * 1.0/3)},
							   {(int)(caseSize *1.0/3),(int)(caseSize * -2.0/3)},
							   {(int)(caseSize *1.0/3),(int)(caseSize * -1.0/3)},
							   {(int)(caseSize *-1.0/3),(int)(caseSize * 2.0/3)},
							   {(int)(caseSize *-1.0/3),(int)(caseSize * 1.0/3)},
							   {(int)(caseSize *-1.0/3),(int)(caseSize *	-2.0/3)},
							   {(int)(caseSize *-1.0/3),(int)(caseSize *	-1.0/3)},
							   
							   {(int)(0),(int)(caseSize * 2.0/3)},
							   {(int)(0),(int)(caseSize * 1.0/3)},	
							   {(int)(0),(int)(caseSize * -2.0/3)},
							   {(int)(0),(int)(caseSize * -1.0/3)},
							   {(int)(0),(int)(caseSize * 2.0/4)},
							   {(int)(0),(int)(caseSize * 1.0/4)},	
							   {(int)(0),(int)(caseSize * -2.0/4)},
							   {(int)(0),(int)(caseSize * -1.0/4)},	
							   
			};
			//arrDistance=new int[64,2];
			arrDistance=(int[,])arrTemp.Clone();
			//arrTemp.CopyTo(arrDistance,0);
		}
		int	 ComputeResults(string path)
		{
			//try
		{
			int	errCode=0,nCounterTHR;
			strPath=path;
			nWeakCellCount=0;
			Results=null;startPoints=null;TempResults=null;FinalResults=null;
			Results=new	int[100,31];
			TopFormResults=new int[2,62];
			startPoints=new	int[3,2];
			arrNumbers = new int[13];
			arrRowNumbers=new	int[13,3];
			StudentCode="";		
	
			img= Image.FromFile(path);			
			bmp=new	Bitmap(img);	
			bmpWidth = bmp.Width ;
			bmpHeight =	bmp.Height;
			if(bmpHeight>2500)
				nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.006));
			else
				nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.005));	
			double degree=GetDiffDegree  ();
			FindTopLeftRightLayout(false);
			Graphics g=Graphics.FromImage( bmp );
			/*cellSize=20;
			ComputeDistanceArray();
			int	darkPointsCount= 0;
			int	[,]arrPoints=new int[64,2];
			float Sat=0;
			for(int	i=0;i<64;i++)
			{
				arrPoints[i,0]=88+arrDistance[i,0];
				arrPoints[i,1]=397+arrDistance[i,1];
				g.FillRectangle(Brushes.Black,arrPoints[i,0],arrPoints[i,1],1,1);
				if(arrPoints[i,0]<0 || arrPoints[i,1] <0)
				{
					arrErrCodes.Add(9);
					throw new OutOfMemoryException();					
				}
			}
			
			bmp.Save("c:\\1.jpg");*/
			if(Math.Abs( degree) > 0.1 && degree< 360 )
			{
				 g=Graphics.FromImage( bmp );
				g.FillRectangle(Brushes.White,0,0,bmp.Width, bmp.Height);
				g.RotateTransform((float)degree);
					
				g.DrawImage(img,-1*(startX-nCounterTHR) ,0,  img.Width ,	img.Height );	
				g.FillRectangle(Brushes.White,startXRight+5,0,bmpWidth,bmpHeight);												
			}
			else 
				if	(degree== 180){arrErrCodes.Add(1);arrErrPaths.Add(strPath); img.Dispose();return -1;}
			else
				if(degree== 360){arrErrCodes.Add(2);arrErrPaths.Add(strPath); img.Dispose();return -1;}
			
			/*g.DrawImage(img,0 ,0, bmpWidth ,	img.Height );	
			g.FillRectangle(Brushes.White,startXRight+2,0,bmpWidth,bmpHeight);*/
			//g.FillRectangle(Brushes.White,startXRight-(startX )+10,0,bmpWidth,bmpHeight);
			/*if(startPoints[0,0]==0 || startPoints[1,0]==0)
				{
					arrErrCodes.Add(3);
					arrErrPaths.Add(path);
					img.Dispose();
					return -1;
				}	*/	
			
			GetStartPoints();
			if((errCode= ProcessRows())!=0)
			{
				
				arrErrPaths.Add(strPath);//bmp.Save("c:\\1.jpg");
				img.Dispose();
				return -1;
			}
			arrValPaths.Add(path);
			//bmp.Save("c:\\1.jpg");
			
			bmp.Dispose();
			img.Dispose ();
			img=null;
			bmp=null;
			
			GC.Collect();
			
			return 0;
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
			return 0;
		}
		double GetDiffDegree()
		{
			int xTopCor=0,xBelowCor=0;
			
			float Bright=0;
			int nMidleTop=bmpHeight/4;
			int nMidleDown=bmpHeight/4*3;
			int nXSearch=bmpWidth/5;
			bool bWhite=false;
			int counter=0,nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.005)),nTemp=0;
			for(int i=0;i<nXSearch;i++)
			{
				Color color=bmp.GetPixel(i,nMidleTop );				
				Bright=color.GetBrightness();
				if( Bright <0.555 &&bWhite)
				{
					nTemp=i;
					counter=0;
					while(true)
					{
						color=bmp.GetPixel(nTemp++,nMidleTop );				
						Bright=color.GetBrightness();
						if(Bright>0.555)
						{
							if(counter<=nCounterTHR*3.0/4.0)break;
							startX= xTopCor=i;	
							break;
						}
						counter++;
					}
					if(counter<=nCounterTHR*3.0/4.0)continue;									
					break;
				}
				else
					if(Bright >0.555)bWhite=true;
			}
			counter=0;
			Bright=0;
			bWhite=false;
			for(int i=0;i<nXSearch;i++)
			{
				Color color=bmp.GetPixel(i,nMidleDown );
				Bright=color.GetBrightness();
				
				if( Bright <0.555&&bWhite)
				{
					counter=0;
					nTemp=i;
					while(true)
					{
						color=bmp.GetPixel(nTemp++,nMidleDown );				
						Bright=color.GetBrightness();
						if(Bright>0.555)
						{
							if(counter<=nCounterTHR*3.0/4.0)break;
							xBelowCor=i;
							break;
						}
						counter++;
					}
					if(counter<=nCounterTHR*3.0/4.0)continue;									
					
					break;
				}
				else
					if(Bright >0.555)bWhite=true;
			}
			int len=nMidleDown-nMidleTop;
			Double  radius=Math.Sqrt( /*y^2*/(len*len)+ /*x^2*/Math.Pow((xBelowCor- xTopCor),2));
			startX=xTopCor;
			if (xTopCor <xBelowCor)
				return (180/Math.PI)*Math.Acos(len/radius);
			else
				return -(180/Math.PI)*Math.Acos(len/radius);
						
		}

		void GetStartPoints()
		{
			
			int nMidleTop=bmpHeight/4;
			int nMidleDown=bmpHeight/4*3;
			int nXSearch=bmpWidth/5;
			float Bright=0;
			bool bWhite=false;
			int counter=0,nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.005)),nTemp=0;
			//Start of Columns
			for(int i=0;i<nXSearch;i++)
			{
				Color color=bmp.GetPixel(i,nMidleTop );				
				Bright=color.GetBrightness();
				if(Bright<0.55 && bWhite)
				{
					nTemp=i;
					counter=0;
					while(true)
					{
						color=bmp.GetPixel(nTemp++,nMidleTop );				
						Bright=color.GetBrightness();
						if(Bright>0.55)
						{
							if(counter<=nCounterTHR*3.0/4.0)break;
							startX=i;	
							break;
						}
						counter++;
					}
					if(counter<=nCounterTHR*3.0/4.0)continue;	
					break;
				}
				else
					if(Bright >0.55)bWhite=true;
			}
			startPoints [0,0]=startX;			

		}
		
		bool FindTopLeftRightLayout(bool bDirect)
		{
			int nMidleTop=bmpHeight/4;
			int nMidleDown=bmpHeight/4*3;
			int nXSearch=bmpWidth- bmpWidth/5;
			float Bright=0;
			bool bWhite=false;
			Color color;
			bmpWidth=bmp.Width;
			bmpHeight=bmp.Height;
			int counter=0,nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.005)),nTemp=0;
			//Start of Columns
			int nMiddle=0;
			for(int i=bmpWidth-1;i>nXSearch;i--)
			{
				color=bmp.GetPixel(i,nMidleTop );				
				Bright=color.GetBrightness();
				if(Bright<0.55 &&bWhite)
				{
					counter=0;
					nTemp=i;
					while(true)
					{
						color=bmp.GetPixel(nTemp--,nMidleTop );				
						Bright=color.GetBrightness();
						if(Bright>0.55)
						{
							if(counter<nCounterTHR)break;
							startY=(int)(bmpHeight *0.05);						
							nMiddle=nTemp-(int)(nCounterTHR*3.0/4.0);
							while(startY>0)
							{
									
								color=bmp.GetPixel(nMiddle,startY-- );				
								Bright=color.GetBrightness();
								if(Bright>0.55)
								{					
									break;
								}
							}
							if(startY==0){i=nTemp-1; continue;}
							startXRight=i;	
							break;
						}
						counter++;
					}
					if(counter<nCounterTHR)continue;					
					break;
				}
				else
					if(Bright >0.55)bWhite=true;
			}
			
			startPoints [1,0]=startXRight-2;
			return true;
		}
		bool FlipOnReverse()
		{
			//			bmp.Save("C:\\2.jpg");					
			float Bright=0;			
			Color color;
			int	nCounterTHR;
			if(bA5)
			{
				if(bmpHeight>1250)
					nCounterTHR=(int)Math.Ceiling (((bmpHeight*2)*0.006));
				else
					nCounterTHR=(int)Math.Ceiling (((bmpHeight*2)*0.005));
			}
			else
			{
				if(bmpHeight>2500)
					nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.006));
				else
					nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.005));
			}
			pageSize = startPoints[1,0]-startPoints[0,0];
			cellSize = (int)Math.Round(pageSize/39.5);
			cellPad	= (float)((pageSize+2)/33.33);
			int nMiddle=startPoints[0,0]+nCounterTHR+ cellSize/2,nAvgPoint=(int)(bmpHeight *0.05);
			int nDistCount=0,nMaxDist=0,counter=0;
			while(nAvgPoint <bmpHeight)
			{
				color=bmp.GetPixel(nMiddle,nAvgPoint++ );				
				Bright=color.GetBrightness();
				if(Bright<0.55)
				{					
					break;
				}
			}
			while(nDistCount<3)
			{
				counter=0;
				while(nAvgPoint <bmpHeight)
				{
					color=bmp.GetPixel( nMiddle,nAvgPoint++);				
					Bright=color.GetBrightness();
					counter++;
					if(Bright <0.4)
					{											
						while(nAvgPoint <bmpHeight)
						{
							color=bmp.GetPixel(nMiddle,nAvgPoint++ );				
							Bright=color.GetBrightness();
							if(Bright>0.4)
							{									
								break;
							}
						}
						break;
					}
				
				}
				if(nMaxDist<counter)nMaxDist=counter;
				nDistCount++;
			}
			
			
			if(nMaxDist<nCounterTHR*2)
			{
					
				bmp.RotateFlip(RotateFlipType.RotateNoneFlipX  );
				bmp.RotateFlip(RotateFlipType.RotateNoneFlipY  );				
				return true;
			}
			return false;
		
		}
		int	ProcessRows()
		{						
			try
			{
				int	prev=0,xLeftVerMiddlePoint=0,xRightVerMiddlePoint=0;
				int	nLayOutCounter=-1;int	nCounterTHR;
				if(bA5)
				{
					if(bmpHeight>1250)
						nCounterTHR=(int)Math.Ceiling (((bmpHeight*2)*0.006));
					else
						nCounterTHR=(int)Math.Ceiling (((bmpHeight*2)*0.005));
				}
				else
				{
					if(bmpHeight>2500)
						nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.006));
					else
						nCounterTHR=(int)Math.Ceiling ((bmpHeight*0.005));
				}
				nCounterTHR++;//bmp.Save("c:\\1.jpg");
				if (!FindTopLeftRightLayout(true)){arrErrCodes.Add(6); return -1;}
				if(FlipOnReverse()){GetStartPoints();if (!FindTopLeftRightLayout(true)){arrErrCodes.Add(6); return -1;}}
				
				//if(startPoints[2,0]==bmpWidth-1){arrErrCodes.Add(4); return -1;}
				startPoints[0,0]+=nCounterTHR;
				startPoints[1,0]-=nCounterTHR;
				pageSize = startPoints[1,0]-startPoints[0,0];
				
				int	xRightHorMiddlePoint=startPoints[1,0]-cellSize/2;
				cellSize = (int)Math.Round(pageSize/39.5);
				cellPad	= (float)((pageSize+2)/33.33);
				int	xHorMiddlePoint=startPoints[0,0]+cellSize/2,nMiddle=startPoints[0,0]-nCounterTHR/2;/*startPoints[0,0]+(startPoints[1,0]-startPoints[0,0])/2*/;
				int	j=(int)(bmpHeight *0.1);
				ComputeDistanceArray ();
				Color color;float Bright=0;
				while(j>0)
				{
					color=bmp.GetPixel(nMiddle,j-- );				
					Bright=color.GetBrightness();
					if(Bright>0.4)
					{					
						break;
					}
				}
				j=j+nCounterTHR*4;
				int	control=0;
				for(int	i=j;i<bmpHeight && j	< bmpHeight;)
				{
					if(control==0)
					{
						if(bmp.GetPixel(xHorMiddlePoint,i).GetBrightness()<0.55)
						{
							prev=i;
							while( i<bmpHeight-1)
							{
								if(!(bmp.GetPixel(xHorMiddlePoint,++i).GetBrightness()<0.55))
								{
									
									if((i-prev<nCounterTHR-1))
									{
										if(nLayOutCounter ==nNumberOfLeftLayout+nNumberOfTopLayout)break;;
										i=prev+nCounterTHR;
										while( i<bmpHeight-1)
										{
											if(bmp.GetPixel(xHorMiddlePoint,++i).GetBrightness()>0.55)
												break;
										}
									}
									if( i<bmpHeight-1)
									{
										xLeftVerMiddlePoint=prev+(i-prev)/2;							
										nLayOutCounter++;
										control=1;
									}
									break;
								}
							}
					
						}
						i++;
					
					}
					else
					{
						if(bmp.GetPixel(xRightHorMiddlePoint,j).GetBrightness()<0.55)
						{
							prev=j;
							while(j<bmpHeight-1)
							{
								if(!(bmp.GetPixel(xRightHorMiddlePoint,++j).GetBrightness()<0.55))
								{
									if((j-prev<nCounterTHR-1))
									{

										j=prev+nCounterTHR;
										while(j<bmpHeight-1)
										{
											if(bmp.GetPixel(xHorMiddlePoint,++j).GetBrightness()>0.55)
												break;
										}
									}
									if( j<bmpHeight-1)
									{
									
										xRightVerMiddlePoint =prev+(j-prev)/2;	
										if(Math.Abs(xRightVerMiddlePoint-xLeftVerMiddlePoint)>5*nCounterTHR)
										{arrErrCodes.Add(5); return -1;}
										//if(nLayOutCounter==2)ComputeDistanceArray();
										ReadRow(xHorMiddlePoint,xLeftVerMiddlePoint,xRightVerMiddlePoint,nLayOutCounter);
										control=0;
									}
									break;
								}
							}
					
						}
						j++;
					}
				


				}
				if(bBottomLayout)nLayOutCounter--;
				if(nLayOutCounter+1 != nNumberOfLeftLayout+nNumberOfTopLayout)
				{
					arrErrCodes.Add(8); return -1;
				}
				ProcessResults();
				CreateResultsString();
				
				if (SaveResultsInDatabase()==-1)return -1;
				formCounter++;
				statusBarPanels4.Text="تعداد برگه های خوانده شده:"+formCounter.ToString();
				return 0;
			}
			catch(OutOfMemoryException exUnk){return -1;}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );return 5;}
		}
		void ProccessResultCode()
		{
				

			strTopFormResults="";
			string []str={strVar1Code.Replace(" ","").Substring(0,9),strVar1Code.Replace(" ","").Substring(9,9)};
			long number=0;
			
			for(int  i=0;i<2;i++)
			{		
				number=long.Parse (str[i].Replace(" ",""));
				for(int j=1;j<31 && number >0 &&(number!=0);j++)
				{
					TopFormResults[i,j]=(number%2==0)?0:100;
					number/=2;
				}
			}			

			
		}
		void CreateResultsString()
		{
			//try
		{			
			int nNumberofFill=0;
			int nCorrectNumber=0;
			strTempResults=strFinalResults=strSavedResult=null;
			strTempResults="";
			strFinalResults="";
			strSavedResult="";
			strTopFormResults="";
			for(int  i=0;i<61;i++)
			{
				for(int j=0;j<31;j++)
				{
					strTempResults+=(TempResults[i,j])?"1":"0";
				}
			}				
			for(int  i=0;i<nNumberOfTotalQuestions;i++)
			{
				nCorrectNumber=0;
				nNumberofFill=0;
				for(int j=0;j<nNumberCasesNumber;j++)
				{
					if(FinalResults[i,j])
					{
						strFinalResults+="1";
						nCorrectNumber=j+1;
						nNumberofFill++;
					}
					else
						strFinalResults+="0";
				}
				nCorrectNumber=((CasesDir^QuestionsDir)&&nCorrectNumber==0)?5:nCorrectNumber;
				if(CasesDir && QuestionsDir){strSavedResult+=(nNumberofFill<=1)?nCorrectNumber.ToString():"*";}
				else if(CasesDir && !QuestionsDir){strSavedResult+=(nNumberofFill<=1)?(5-nCorrectNumber).ToString():"*";}
				else if(!CasesDir && QuestionsDir){strSavedResult+=(nNumberofFill<=1)?(5-nCorrectNumber).ToString():"*";}
				else {strSavedResult+=(nNumberofFill<=1)?(nCorrectNumber).ToString():"*";}
					
			}			
			for(int i=0;i<2;i++)
				for(int j=0;j<62;j++)
				{
					strTopFormResults+=TopFormResults[i,j].ToString()+";";
				}
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}
		void ProcessResults()
		{
		
			int max=0;
			TempResults=null;FinalResults=null;
			int [,]tempCount=new int[nNumberOfTotalQuestions ,nNumberCasesNumber];
			TempResults = new bool[61 ,31];
			FinalResults=new bool[nNumberOfTotalQuestions ,nNumberCasesNumber];
			int nNumberOfClassDistance=0;
			int classCounter=0,caseCounter=0,QCounter=0;
				
			if(bReadColorized)
			{
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
						for(int colIndex=0;colIndex<nNumberColNumber  *nNumberCasesNumber;colIndex++)
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
								if(TempResults[rowIndex+nNumberOfTopLayout+nNumberFirstRow,nNumberFirstCol-colIndex-nNumberOfClassDistance+colIndex* nNumberHorDistance ])
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
			}
			else
			{
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
						for(int colIndex=0;colIndex<nNumberColNumber  *nNumberCasesNumber;colIndex++)
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
									nNumberFirstCol-colIndex-nNumberOfClassDistance+colIndex* nNumberHorDistance];	
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

			}
			ProcessFormNumbers();
		
		}
		void ProcessFormNumbers()
		{
			int nFirst9Digit=0;
			int nSecond8Digit=0;
			string strTemp="";
			strVar1Code="";
			for(int i=1;i<=30;i++)
			{
				if(TopFormResults[0,i]>=nCodeDarkPointThr )
					nFirst9Digit |= ((int)Math.Pow(2,i-1));
			}
			for(int i=1;i<=30;i++)
			{
				if(TopFormResults[1,i]>=nCodeDarkPointThr)
					nSecond8Digit |= ((int)Math.Pow(2,i-1));
			}			
			strTemp=nFirst9Digit.ToString(new string('0',9));
			strTemp +=nSecond8Digit.ToString(new string('0',9));
			//Error Occured 
			//if(strTemp.Length >17)strTemp=strTemp.Substring(0,17);
			//Error Occured
			strVar1Code+=strTemp.Substring(0,3)+" ";
			strVar1Code+=strTemp.Substring(3,3)+" ";strVar1Code+=strTemp.Substring(6,3)+" ";
			strVar1Code+=strTemp.Substring(9,3)+" ";strVar1Code+=strTemp.Substring(12,3)+" ";
			strVar1Code+=strTemp.Substring(15,3)+" ";
		}
		void ReadResultsString()
		{
			//try
		{
			
			FinalResults=new bool[nNumberOfTotalQuestions ,nNumberCasesNumber];			
			if(TopFormResults==null)
			{
				TopFormResults =new int[2,62];

			}
			string []strNumbers=strTopFormResults.Split(';');
			for(int i=0;i<2;i++)
				for(int j=0;j<62;j++)
				{
					TopFormResults[i,j]=int.Parse( strNumbers[i*62+j]);
				}
			TempResults=null;FinalResults=null;
			TempResults = new bool[61 ,31];

			FinalResults=new bool[nNumberOfTotalQuestions ,nNumberCasesNumber];


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
				for(int j=0;j<nNumberCasesNumber;j++)
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
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}
		void DeleteTotalRowsFromDB()
		{
			//try
		{
			conn.Open();
			command.CommandText="delete from results";
			command.ExecuteNonQuery();
			dsResults.Tables[0].Rows.Clear();
			conn.Close();
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}

		}
		void DeleteTotalErrorResultFromDB()
		{
			//try
		{
			conn.Open();
			command.CommandText="delete from errorResults";
			command.ExecuteNonQuery();
			conn.Close();
			dsErrResult.Tables[0].Rows.Clear();
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}

		}
		int  SaveResultsInDatabase()
		{
			//try
		{
			//ReadResultsFromDB();
			int res=AddNewDataRowToResults();
			//conn.Open();
			daResults.Update(dsResults,"results");
			daTempResults.Update(dsTempResults,"TempResults");
			//conn.Close();
			return res;
		}
			//catch(Exception ex){MessageBox.Show(ex.Message );}
		}
		int AddNewDataRowToResults()
		{
			//try
		{
			DataRowCollection drc=dsResults.Tables["results"].Rows;
			int nCount=drc.Count;
				
			CreateResultsString();
			/*if(!bVerdict)
			{
				for(int i =0;i<nCount;i++ )
				{
					if(drc[i][1].ToString()==strVar1Code)
					{
						if(MessageBox.Show("کد "+strVar2Code +":"+ strVar1Code+"تکراريست،آيا مايل به چايگزينی هستید؟","",MessageBoxButtons.YesNo)==DialogResult.Yes )
						{							
							DisplayForm dispForm=new DisplayForm();
							dispForm.frmPaernt=this;
							dispForm.BackColor=BackColor;
							
							if (!dispForm.SetPicPaths(drc[i][10].ToString(),strPath))
							{
								MessageBox.Show("فایل قبلی در هارد دیسک این کامپیوتر وجود ندارد");
								break;
							}
							
							DisplayForm d=new DisplayForm();
							d.bShow=false;
							d.Show();
							dispForm.bShow=true;
							dispForm.ShowDialog();
							
							if(dispForm.bTrue)
							{
								string strP="";
								if(!File.Exists(drc[i][10].ToString()))							
									strP=drc[i][10].ToString().Replace(".val",".jpg");
								else
									strP=drc[i][10].ToString();
								if(strP.ToLower() == strPath.ToLower())
								{
									if(MessageBox.Show("این دو فایل در واقع یک فایل میباشند آیا مایلید خطا در نظر گرفته شود؟","",MessageBoxButtons.YesNo )==DialogResult.No  )
									{
										return 0;
									}
									else
									{
										arrErrCodes.Add(10);										
										drc[i].Delete();
										dispForm.Close();
										return -1;
									}
								}
								arrErrCodes.Add(10);	
								dispForm.Close();
								return -1;
							}
							else
							{
								string strP="";
								if(!File.Exists(drc[i][10].ToString()))							
									strP=drc[i][10].ToString().Replace(".val",".jpg");
								else
									strP=drc[i][10].ToString();
								if(strP.ToLower() == strPath.ToLower())
								{
									if(MessageBox.Show("این دو فایل در واقع یک فایل میباشند آیا مایلید خطا در نظر گرفته شود؟","",MessageBoxButtons.YesNo )==DialogResult.No  )
									{
										return 0;
									}
									else
									{
										arrErrCodes.Add(10);										
										drc[i].Delete();
										dispForm.Close();
										return -1;
									}
								}
								if(arrValPaths.Contains(strP ))
									arrValPaths.Remove(strP );
								arrErrCodes.Add(10);
								arrErrPaths.Add(strP);
								drc[i].Delete();
								dispForm.Close();
							}
							break;
						}
						else
							return 0;
					}
				}
			}*/
			string code=strVar1Code.Replace(" ","");
			if(long.Parse(code)==0)
			{
				bNoNumberIsOk=true;

				int charIndex=strPath.LastIndexOf(".");				
				strPath =strPath.Substring (0,charIndex)+".val";
				DataRowCollection drcTempRes=dsTempResults.Tables[0].Rows;
				System.Data.DataRow dr=dsTempResults.Tables[0].NewRow();
				dr[1]="0";
				dr[12]="0";
				dr[2]="";
				dr[3]="";		
				dr[4]="";
				dr[5]="";
				dr[6]=strFinalResults ;
				dr[7]=strTempResults ;
				dr[8]=strSavedResult;
				dr[9]=strTemplateName;
				dr[10]=strPath;
				dr[11]=strTopFormResults;
				drcTempRes.Add(dr);
			}
			else
			{
				int charIndex=strPath.LastIndexOf(".");				
				strPath =strPath.Substring (0,charIndex)+".val";

				System.Data.DataRow dr=dsResults.Tables["results"].NewRow();
				dr[1]=strVar1Code;
				dr[2]="";
				dr[3]="";		
				dr[4]="";
				dr[5]="";
				dr[6]=strFinalResults ;
				dr[7]=strTempResults ;
				dr[8]=strSavedResult;
				dr[9]=strTemplateName;
				dr[10]=strPath;
				dr[11]=strTopFormResults;
				drc.Add(dr);
			}
			return 0;
			//drc.Add(dr);
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}
		void ReadResultsFromDB()
		{
			//try
		{
			if(dsResults.Tables.Contains("results"))
				dsResults.Tables[0].Rows.Clear();
			daResults.Fill(dsResults,"results");
			if(dsTempResults.Tables.Contains("TempResults"))
				dsTempResults.Tables[0].Rows.Clear();
			daTempResults.Fill(dsTempResults,"TempResults");
			ReadErrorResultsFromDB();
			if(dsTempResults.Tables[0].Rows.Count >0)
			{
				bNoNumberIsOk=false;
				picNoNumbers.Image.Dispose();
				Bitmap bmp=new Bitmap(GetType(),"NotOk.png");
				
				lblNoNumbers.ForeColor=Color.Red;
				picNoNumbers.Image=bmp;
			}
			else
			{
				bNoNumberIsOk=true;
				picNoNumbers.Image.Dispose();
				Bitmap bmp=new Bitmap(GetType(),"Ok.png");
				lblNoNumbers .ForeColor=Color.DarkOliveGreen;
				picNoNumbers.Image=bmp;
			}
			if(dsResults.Tables[0].Rows.Count >0 && (!bNoNumberIsOk ||!bPerformaneIsOk))
			{
				bReachedResultsIsOk=false;
				picReachedResults.Image.Dispose();
				Bitmap bmp=new Bitmap(GetType(),"NotOk.png");
				lblReachedResults.ForeColor=Color.Red;
				picReachedResults.Image=bmp;
			}
			else
			{
				bReachedResultsIsOk=true;
				picReachedResults.Image.Dispose();
				Bitmap bmp=new Bitmap(GetType(),"Ok.png");
				lblReachedResults.ForeColor=Color.DarkOliveGreen;
				picReachedResults.Image=bmp;
			}
			
		}
			//catch(Exception ex){MessageBox.Show(ex.Message );}
		}
		void ReadRow(int xCor,int yCor,int yRightCor,int nLayOutCounter)
		{
			
			float  gradient	 = (yRightCor -	yCor)/(float)pageSize,pad=0;
			int	Y0=Math.Abs(yRightCor -	yCor);
			int	X,Y,res;
			int pad0=cellSize /4;
			//float pad1=(float)(Math.Ceiling( pageSize*0.0174));

			if(nLayOutCounter <2)
			{

				
				for(int	i= 1; i <= 31 ;i++)
				{
					X=(int)(xCor+i*cellPad);
					Y=(int)(gradient*X);//((gradient>0)?gradient*X-Y0:gradient*X);
					res=TopFormResults[nLayOutCounter,i-1]=ReadCell(X,yCor+Y);					
				}
				/*
				for(int	i= 1; i <= 31 ;i++)
				{
					X=(int)(xCor+i*cellPad);
					Y=(int)(gradient*X);//((gradient>0)?gradient*X-Y0:gradient*X);
					res=TopFormResults[nLayOutCounter,2*(i-1)]=ReadCell(X-pad0 ,yCor+Y);					
					res=TopFormResults[nLayOutCounter,2*(i-1)+1]=ReadCell(X+pad0,yCor+Y);					
				}*/
			}
			else
			{
				for(int	i= 1; i <= 31 ;i++)
				{
					X=(int)(xCor+i*cellPad);
					Y=(int)(gradient*X);//((gradient>0)?gradient*X-Y0:gradient*X);
					res=Results[nLayOutCounter,i-1]=ReadCell(X,yCor+Y);
					if(res>=nDarkPointThr &&  res<25)
					{
						nWeakCellCount++;
					}
				}
			}
		}
		
		string ConvertToArabic(string str)
		{
			if(str!=null)
			{
				int strlen=str.Length;
				char []strTemp=new char[strlen];
				str.CopyTo(0,strTemp,0,strlen);
				for(int i=0;i<strlen;i++)
				{				
					strTemp[i]=(str[i]!=' ')?(char)(str[i]+1728):' ';
				}
				str=new string (strTemp);
			}
			else
				str="";
			return str;
		}
		
		int	ReadCell(int xCor,int yCor)
		{
			
			int	darkPointsCount= 0;
			int	[,]arrPoints=new int[64,2];
			float Sat=0;
			for(int	i=0;i<64;i++)
			{
				arrPoints[i,0]=xCor+arrDistance[i,0];
				arrPoints[i,1]=yCor+arrDistance[i,1];
				if(arrPoints[i,0]<0 || arrPoints[i,1] <0)
				{
					arrErrCodes.Add(9);
					throw new OutOfMemoryException();					
				}
			}
			float brightThreshold=nBrightThreshold;
			float brightness = 0  ;	
			for	( int i= 0 ;i <	64 ;i++)
			{
				brightness	= bmp.GetPixel(arrPoints[i,0],arrPoints[i,1]).GetBrightness();				
				Sat=bmp.GetPixel(arrPoints[i,0],arrPoints[i,1]).GetSaturation();
							
				if ( brightness	>=brightThreshold  )
				{					
					continue;
				}
				if ( brightness	< brightThreshold )
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
				for	(int j=0;j<nNumberCasesNumber;j++)
				{
					if (FinalResults[i,j])
						t.Write((j+1).ToString ()+"	- ");
				}
				t.WriteLine();
			}
			t.Close();
		}

		//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		
		
		void ApplyChanges()
		{
			switch(nFormType)
			{
				case 0://360
				{
					nNumber1Cases	=2;
					nNumber1Col		=31;
					nNumber1Digits	=30;
					nNumber1Row		=0;
					nNumber2Cases	=0;
					nNumber2Col		=0;
					nNumber2Digits	=0;
					nNumber2Row		=0;
					nNumber3Cases	=0;
					nNumber3Col		=0;
					nNumber3Digits	=0;
					nNumber3Row		=0;
					nNumber4Cases	=0;
					nNumber4Col		=0;
					nNumber4Digits	=0;
					nNumber4Row		=0;
					nNumber5Cases	=0;
					nNumber5Col		=0;		
					nNumber5Digits	=0;
					nNumber5Row		=0;
					nNumberCasesNumber		=4;
					nNumberClassDistance	=1;
					nNumberclassNumber		=6;
					nNumberColNumber		=6;
					nNumberColDistance		=2;
				
					nNumberFirstCol			=1;
					nNumberFirstRow			=0;
					nNumberHorDistance		=0;
					nNumberOfLeftLayout		=60;
					nNumberOfTopLayout		=2;
					nNumberQuestionNumber	=10;
					nNumberOfTotalQuestions =360;
					nNumberVerDistance		=0;
					break;

				}
				case 2://210
				{
					nNumber1Cases	=2;
					nNumber1Col		=31;
					nNumber1Digits	=30;
					nNumber1Row		=0;
					nNumber2Cases	=0;
					nNumber2Col		=0;
					nNumber2Digits	=0;
					nNumber2Row		=0;
					nNumber3Cases	=0;
					nNumber3Col		=0;
					nNumber3Digits	=0;
					nNumber3Row		=0;
					nNumber4Cases	=0;
					nNumber4Col		=0;
					nNumber4Digits	=0;
					nNumber4Row		=0;
					nNumber5Cases	=0;
					nNumber5Col		=0;		
					nNumber5Digits	=0;
					nNumber5Row		=0;
					nNumberCasesNumber		=4;
					nNumberClassDistance	=1;
					nNumberclassNumber		=6;
					nNumberColNumber		=6;
					nNumberColDistance		=2;
				
					nNumberFirstCol			=1;
					nNumberFirstRow			=0;
					nNumberHorDistance		=0;
					nNumberOfLeftLayout		=35;
					nNumberOfTopLayout		=2;
					nNumberQuestionNumber	=10;
					nNumberOfTotalQuestions =210;
					nNumberVerDistance		=0;			
					break;
				}
				default://300
				{
					nNumber1Cases	=2;
					nNumber1Col		=31;
					nNumber1Digits	=30;
					nNumber1Row		=0;
					nNumber2Cases	=0;
					nNumber2Col		=0;
					nNumber2Digits	=0;
					nNumber2Row		=0;
					nNumber3Cases	=0;
					nNumber3Col		=0;
					nNumber3Digits	=0;
					nNumber3Row		=0;
					nNumber4Cases	=0;
					nNumber4Col		=0;
					nNumber4Digits	=0;
					nNumber4Row		=0;
					nNumber5Cases	=0;
					nNumber5Col		=0;		
					nNumber5Digits	=0;
					nNumber5Row		=0;
					nNumberCasesNumber		=4;
					nNumberClassDistance	=1;
					nNumberclassNumber		=6;
					nNumberColNumber		=6;
					nNumberColDistance		=2;
				
					nNumberFirstCol			=1;
					nNumberFirstRow			=0;
					nNumberHorDistance		=0;
					nNumberOfLeftLayout		=50;
					nNumberOfTopLayout		=2;
					nNumberQuestionNumber	=10;
					nNumberOfTotalQuestions =300;
					nNumberVerDistance		=0;			
					break;
				}
			}
			//nNumberFixNumber		=int.Parse(txtGroupedFixNumber.Text  );
			//nAzmunCounter=long.Parse(txtAzmunNumber.Text );
			//nStudentCounter=long.Parse(txtStudentNumber.Text );
			bVerdict				=false;
			bBottomLayout			=true;
			bStartFromMiddle		=false;
			str1VarName="کد داوطلب";
			str2VarName="کدآزمون";
			str3VarName="";
			str4VarName="";
			str5VarName="";
			
			CasesDir=true;
			QuestionsDir=true;
			bA5=false;
			bSubjectSelect=false;
			//validating of	DisplayForm's Static Members
		}
		private	void pageTestSettings_Validated(object sender, System.EventArgs	e)
		{
			ApplyChanges();
			//MessageBox.Show(" تغييرات در تنظيمات صفحه آزمون اعمال خواهد شد");
		}



		private	void menuItem1_Select(object sender, System.EventArgs e)
		{
			ApplyChanges();
			ApplyCodeSettings();
		}
		void ApplyCodeSettings()
		{
			//try
		{
			
			nStudentCounter=nNumberStudentNumber;
			nAzmunCounter=nNumberAzmunNumber;
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}
		private	void pageCodeSettings_Validated(object sender, System.EventArgs	e)
		{
			ApplyCodeSettings();
		}

		private	void CorrectionCurrentRow()
		{
			//try
		{
			if(dsResults.Tables.Contains("results"))
			{
				
				
				int row=dataGrid.CurrentCell.RowNumber ;
				int col=dataGrid.CurrentCell.ColumnNumber;
				
				strSavedResult=dsResults.Tables[0].Rows[row]["SavedResult"].ToString();				
				if(dsResults.Tables["results"].Rows[row]["TemplateName"].ToString().Equals(strTemplateName))
				{
					if( strSavedResult != "")
					{
					
						strTempResults=dsResults.Tables["results"].Rows[row]["TempResults"].ToString();
						strFinalResults=dsResults.Tables["results"].Rows[row]["FinalResults"].ToString();
						strVar1Code=dsResults.Tables["results"].Rows[row]["strVar1Code"].ToString();
						strVar2Code=dsResults.Tables["results"].Rows[row]["strVar2Code"].ToString();
						strTopFormResults=dsResults.Tables["results"].Rows[row]["TopFormresults"].ToString();
						if(strFinalResults!="" && strTempResults != "")
						{
							ReadResultsString();
							ProccessResultCode();
							ProcessFormNumbers();
						}			
					
					}	
				}
				/*else
				{
					MessageBox.Show("تفاوت در الگو\nنام الگوی این رکورد \" "+dsResults.Tables["results"].Rows[row]["TemplateName"].ToString()+" \"می باشد در صورت تمایل می توانید این الگو را از لیست بازشونده نام فرم در صفحه اصلی انتخاب نمایید");
				}*/
			
				
			}
			else
			{
				MessageBox.Show("لطفا قبل از نمايش، حداقل يک فرم را توسط برنامه پردازش نماييد");
			}
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}


		private void comboreadMethod_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if (bIsBusy)return;
			if(comboreadMethod.SelectedIndex == 1 )
			{
				bReadColorized = true;

			}
			else
			{
				bReadColorized = false;

			}
		}

		private void trkThr_Scroll(object sender, System.EventArgs e)
		{
			if (!bIsBusy)
				nDarkPointThr = trkThr.Value;
			lblDarkPointThr.Text=nDarkPointThr.ToString();
		}



		private void comboFormName_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			
			
			TempResults=null;FinalResults=null;
			TempResults = new bool[61 ,31];
			FinalResults=new bool[nNumberOfTotalQuestions ,nNumberCasesNumber];
			panelPaint.Invalidate();
		}


		

		private void button3_Click(object sender, System.EventArgs e)
		{
			CreateResultsString();			
			dsResults.Tables["results"].Rows[rowIndex]["FinalResults"]=strFinalResults;
			dsResults.Tables["results"].Rows[rowIndex]["TempResults"]=strTempResults ;
			dsResults.Tables["results"].Rows[rowIndex]["SavedResult"]=strSavedResult ;
			SaveFlag=true;		
		}



		private void menuItemDelete_Click(object sender, System.EventArgs e)
		{
			//try
		{
			DeleteTotalRowsFromDB();
			dsResults.Tables[0].Rows.Clear();
			dataGrid.Refresh();
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
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
			//try
		{
			conn.Open();
			if(dsResults.Tables.Contains("results"))daResults.Update(dsResults,"results");
			conn.Close();
			SaveFlag=false;
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}



		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
		
			string strVar="",strPath1="\\\\"+SystemInformation.ComputerName+"\\";
			if(!dsResults.Tables.Contains("results"))			
			{
				ReadResultsFromDB();
				dataGrid.DataSource=dsResults.Tables[0];
				statusBar.Panels[5].Text="تعداد برگه های خوانده شده در پایگاه داده: "+dsResults.Tables[0].Rows.Count.ToString();

			}
			if( txtOutPutFileName.Text  !="" )
			{
				strOutputPath =txtPath.Text + "\\"+txtOutPutFileName.Text+".txt";
				string strOut="";
				DataTable tbl= dsResults.Tables[0];
				int rowCount=dsResults.Tables[0].Rows.Count;
				
		
				TextWriter tw=new StreamWriter(strOutputPath);
				string strTemp="";
				for(int i=0;i<rowCount;i++)
				{
					
					strSavedResult=tbl.Rows[i]["SavedResult"].ToString();
					strSavedResult=strSavedResult.ToString().Replace('1','8');							
					strSavedResult=strSavedResult.ToString().Replace('4','1');							
					strSavedResult=strSavedResult.ToString().Replace('2','4');
					strSavedResult=strSavedResult.ToString().Replace('3','2');	
					strTemp="";
					for(int k=0;k<strSavedResult.Length;k++)	
					{
						strTemp+=strSavedResult[k].ToString();
						strTemp+=",";
					}
					//strTemp=strTemp.Remove(strTemp.Length-1,1);
					
					strVar=tbl.Rows[i][1].ToString();	
					strVar=strVar.Replace(" ","");
					strVar=strVar.Insert(9,",");					
					strOut =strVar+","+strTemp +tbl.Rows[i][2].ToString()+"," +strPath1  +tbl.Rows[i]["Path"].ToString ().Replace(":","");								
					if(i==rowCount -1)
					{
						strOut+=",CR";
						tw.Write(strOut );	
					}
					else
						tw.WriteLine(strOut);	
				}				
			
				tw.Close();
				MessageBox.Show("عمليات با موقيت انجام شد");
			
				
			}
			else
				MessageBox.Show("لطفا  يک نام خروجي انتخاب نماييد");

			FillOutPutListFiles(txtPath.Text );
		}

		private void panelAnalyze_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void panelOutPutSettings_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}





		private void radioTest_CheckedChanged_1(object sender, System.EventArgs e)
		{
						
		}

		private void chkStudent_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}



		private void listFiles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			bStartCorrection=true;
			if (bIsBusy)return;
			nBrightThreshold=(float)(trkSence.Value/255.0);	
			bContinue=false;
			ReadResultsFromDB();
			statusBar.Panels[5].Text="تعداد برگه های خوانده شده در پایگاه داده: "+dsResults.Tables[0].Rows.Count.ToString();

			
			ApplyChanges();
			if(lblPath.Text == ""|| (listFiles.SelectedItem.ToString().LastIndexOf (".val")!=-1)||(listFiles.SelectedItem.ToString().LastIndexOf (".err")!=-1))
				return;
			string strPath=filesPaths[listFiles.SelectedIndex].ToString();//lblPath.Text+"\\"+listFiles.SelectedItem.ToString();
			arrErrCodes.Clear();
			arrErrPaths.Clear();
			arrValPaths.Clear();	
			formCounter=0;
			if(comboFormType.SelectedIndex == -1)
			{
				CreateCaret ( comboFormType.Handle ,(IntPtr.Zero ),comboFormType.Width ,20);
				SetCaretPos(0,0);
				ShowCaret( comboFormType.Handle);
				MessageBox.Show("لطفا نوع فرم را در قسمت تعیین شده مشخص نمایید");
				return ;
			}
		strTemplateName=comboFormType.Text;
			OpenSingle(strPath);
			MarkTheFiles();
			SaveInDBErrorResults();
			panelPaint.BringToFront();
			panelCounter=0;
			panelPaint.Invalidate();
			FillListFiles(lblPath.Text);
			bStartCorrection=false;
			//ReadResultsFromDB();
			TablesStatus();
		}
		void OpenSingle(string path)			
		{
			//try
		{								
			
			
			ComputeResults(path);
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}
		private void button6_Click(object sender, System.EventArgs e)
		{
			//try
		{
			bNoNumberIsOk=true;
			picNoNumbers.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"Ok.png");
			lblNoNumbers .ForeColor=Color.DarkOliveGreen;
			picNoNumbers.Image=bmp;

			bReachedResultsIsOk =true;
			picReachedResults.Image.Dispose();
			bmp=new Bitmap(GetType(),"Ok.png");
			lblReachedResults.ForeColor=Color.DarkOliveGreen;
			picReachedResults.Image=bmp;

			bPerformaneIsOk=true;
			picPerformaneStatus.Image.Dispose();
			bmp=new Bitmap(GetType(),"Ok.png");
			lblPerformaneStatus .ForeColor=Color.DarkOliveGreen;
			picPerformaneStatus.Image=bmp;


			if(MessageBox.Show("آيا مايليد نتايج قبلي پاک  شود","",MessageBoxButtons.YesNo)==DialogResult.Yes )
			{
				DeleteTotalRowsFromDB();
			}
			dsResults.Tables[0].Rows.Clear();
			dataGrid.DataSource=dsResults.Tables[0].Copy();
			statusBar.Panels[5].Text="تعداد برگه های خوانده شده در پایگاه داده: "+dsResults.Tables[0].Rows.Count.ToString();
			dataGrid.Refresh();
			DeleteTempRows();
			DeleteTotalErrorResultFromDB();
			TablesStatus();
			
		}
			//catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}

		private void menuItem7_Click_1(object sender, System.EventArgs e)
		{
			if(dsResults.Tables.Contains("results"))
			{
				string strOut="";
				DataTable tbl= dsResults.Tables[0];
				int rowCount=dsResults.Tables[0].Rows.Count;
				if(strOutputPath!=null && strOutputPath !="" )
				{
					//try
				{
					TextWriter tw=new StreamWriter(strOutputPath);
					for(int i=0;i<rowCount;i++)
					{
						strOut =tbl.Rows[i][1].ToString()+tbl.Rows[i]["FinalResults"].ToString()+"\n";
						tw.WriteLine(strOut);
					}						
					tw.Close();
					MessageBox.Show("عمليات با موقيت انجام شد");
				}
					//catch(Exception ex){MessageBox.Show("عمليات با موقيت انجام نشد،لطفا با گروه پشتيباني تماس بگيريد"+ex.Message );}
				}
				else
					MessageBox.Show("لطفا در صفحه تنظيمات شيوه خواندن و ذخيره يک مسير خروجي انتخاب نماييد");
			}
			else
				MessageBox.Show("لطفا اطلاعات را از پايگاه داده لود نماييد");
		}



		private void radioCodes_CheckedChanged(object sender, System.EventArgs e)
		{
			
		
		}





		private	void menuItem3_Click(object	sender,	System.EventArgs e)
		{
			////try
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
			////catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}

		private	void menuItem7_Click(object	sender,	System.EventArgs e)
		{
			MessageBox.Show("لطفا دقيقا وسط گزينه هاي اول و آخر دو ستون مجاور کليک نماييد.");         
			
		}
	
		private	void menuItem9_Click(object	sender,	System.EventArgs e)
		
		{
			////try
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
			////catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}
		

		private	void trackBar2_Scroll(object sender, System.EventArgs e)
		{
			lblSence.Text=trkSence.Value.ToString()+"  ("+((trkSence.Value/255.0)*100).ToString("00")+"%)";
					
			lblColorSence.BackColor=Color.FromArgb(trkSence.Value,trkSence.Value,trkSence.Value);
		
		}
		Point prevPoint;
		private	void label7_Click(object sender, System.EventArgs e)
		{
			
			
		}



		private	void radioOutPut_Click(object sender, System.EventArgs e)
		{
			
		}

		private	void radioTestOmit_Click(object	sender,	System.EventArgs e)
		{
			MessageBox.Show("اين گزينه بصورت خودکار توسط قسمت متغيرها انجام مي شود.");
		}

		private	void radioTest_CheckedChanged(object sender, System.EventArgs e)
		{
			
		}





	
				
		

		private	void txtHorDistance_KeyPress(object	sender,	System.Windows.Forms.KeyPressEventArgs e)
		{
		}
		private	void txtNumbers_KeyPress(object	sender,	System.Windows.Forms.KeyPressEventArgs e)
		{
			
		}

		private	void menuItemX_Click(object	sender,	System.EventArgs e)
		{
			((MenuItem)sender).Checked=!((MenuItem)sender).Checked;

		}

		private	void radioCodes_Click(object sender, System.EventArgs e)
		{
			GroupBox prnt=(GroupBox)((RadioButton)sender).Parent;
			
			
		}

		private void picColInRecord_Click(object sender, System.EventArgs e)
		{
			if(lblPath.Text != "")
				FillListFiles(lblPath.Text);
		}
		void TablesStatus()
		{
			 int nNoNumber=0,nPerformane=0,nReachedResults =0;
			ReadErrorResultsFromDB();
			ReadResultsFromDB();
			nNoNumber=dsTempResults.Tables[0].Rows.Count;
			nPerformane=dsErrResult.Tables[0].Rows.Count;
			nReachedResults=dsResults.Tables[0].Rows.Count;
			lblNoNumbersO.Text=lblNoNumbersO.Text.Substring(0,26)+"("+nNoNumber.ToString()+")";
			lblPerformaneStatusO.Text=lblPerformaneStatusO.Text.Substring(0,23)+"("+nPerformane.ToString()+")";
			lblReachedResultsO.Text=lblReachedResultsO.Text.Substring(0,27)+"("+nReachedResults.ToString()+")";

		}
		void FillListFiles(string strPath)
		{
			
			lblPath.Text= strPath;
			int nCorrectFormatCounter=0,nCorrectedPageCounter=0,nErrorPageCounter=0;
			listFiles.Items.Clear();	
			string strErrorPath=strPath+"\\Errors";
			System.IO.Directory.CreateDirectory(strErrorPath);
			strErrorPath+="\\";
			filesPaths.Clear();
			if(bSubFolders)
			{
				string []directories=System.IO.Directory.GetDirectories(strPath);
				string[] filesPath=System.IO.Directory.GetFiles(strPath);
				for(int i=0;i<filesPath.Length ;i++)
				{
					if (filesPath[i].LastIndexOf(".JPG") !=	-1 ||filesPath[i].LastIndexOf(".jpg") !=	-1 || filesPath[i].LastIndexOf(".BMP") !=	-1 ||filesPath[i].LastIndexOf(".bmp") != -1 ||	
						filesPath[i].LastIndexOf(".JPEG") !=	-1 ||filesPath[i].LastIndexOf(".jpeg") != -1)
					{
						nCorrectFormatCounter++;
						int index=filesPath[i].LastIndexOf("\\");
						listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
						filesPaths.Add(filesPath[i]);
					}
					else
					{
						if (filesPath[i].LastIndexOf(".val") !=	-1||filesPath[i].LastIndexOf(".VAL") !=	-1)
						{
							nCorrectedPageCounter++;
							int index=filesPath[i].LastIndexOf("\\");
							listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
							filesPaths.Add(filesPath[i]);
						}
						else
						{
							if (filesPath[i].LastIndexOf(".err") !=	-1||filesPath[i].LastIndexOf(".ERR") !=	-1)
							{
								int index=filesPath[i].LastIndexOf("\\");
								/*if (bStartCorrection)
										System.IO.File.Move(filesPath[i],strErrorPath+filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
									else*/
								listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
								filesPaths.Add(filesPath[i]);
								nErrorPageCounter++;
							
								//listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
							}
						}
					}
				}
			
				for(int dirIndex=0;dirIndex<directories.Length ;dirIndex++)
				{
					filesPath=System.IO.Directory.GetFiles(directories[dirIndex]);
					for(int i=0;i<filesPath.Length ;i++)
					{
						if (filesPath[i].LastIndexOf(".JPG") !=	-1 ||filesPath[i].LastIndexOf(".jpg") !=	-1 || filesPath[i].LastIndexOf(".BMP") !=	-1 ||filesPath[i].LastIndexOf(".bmp") != -1 ||	
							filesPath[i].LastIndexOf(".JPEG") !=	-1 ||filesPath[i].LastIndexOf(".jpeg") != -1)
						{
							nCorrectFormatCounter++;
							int index=filesPath[i].LastIndexOf("\\");
							listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
							filesPaths.Add(filesPath[i]);
						}
						else
						{
							if (filesPath[i].LastIndexOf(".val") !=	-1||filesPath[i].LastIndexOf(".VAL") !=	-1)
							{
								nCorrectedPageCounter++;
								int index=filesPath[i].LastIndexOf("\\");
								listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
								filesPaths.Add(filesPath[i]);
							}
							else
							{
								if (filesPath[i].LastIndexOf(".err") !=	-1||filesPath[i].LastIndexOf(".ERR") !=	-1)
								{
									int index=filesPath[i].LastIndexOf("\\");
									/*if (bStartCorrection)
										System.IO.File.Move(filesPath[i],strErrorPath+filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
									else*/
									listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
									filesPaths.Add(filesPath[i]);
									nErrorPageCounter++;
							
									//listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
								}
							}
						}
					}
				}
			}
			else
			{

				string []filesPath=System.IO.Directory.GetFiles(strPath);
				for(int i=0;i<filesPath.Length ;i++)
				{
					if (filesPath[i].LastIndexOf(".JPG") !=	-1 ||filesPath[i].LastIndexOf(".jpg") !=	-1 || filesPath[i].LastIndexOf(".BMP") !=	-1 ||filesPath[i].LastIndexOf(".bmp") != -1 ||	
						filesPath[i].LastIndexOf(".JPEG") !=	-1 ||filesPath[i].LastIndexOf(".jpeg") != -1)
					{
						nCorrectFormatCounter++;
						int index=filesPath[i].LastIndexOf("\\");
						listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
						filesPaths.Add(filesPath[i]);
					}
					else
					{
						if (filesPath[i].LastIndexOf(".val") !=	-1||filesPath[i].LastIndexOf(".VAL") !=	-1)
						{
							nCorrectedPageCounter++;
							int index=filesPath[i].LastIndexOf("\\");
							listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
							filesPaths.Add(filesPath[i]);
						}
						else
						{
							if (filesPath[i].LastIndexOf(".err") !=	-1||filesPath[i].LastIndexOf(".ERR") !=	-1)
							{
								int index=filesPath[i].LastIndexOf("\\");
								/*if (bStartCorrection)
									System.IO.File.Move(filesPath[i],strErrorPath+filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
								else*/
								listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
								nErrorPageCounter++;
								filesPaths.Add(filesPath[i]);
							
								//listFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
							}
						}
					}
				}
			}
			lblNumberOfTotal.Text="("+(nCorrectFormatCounter+nCorrectedPageCounter+nErrorPageCounter).ToString()+")";
			statusBar.Panels[0].Text="تعداد برگه های خوانده نشده:"+nCorrectFormatCounter.ToString();
			statusBar.Panels[1].Text="تعداد برگه های صحیح:"+nCorrectedPageCounter.ToString();
			statusBar.Panels[2].Text="تعداد برگه های خطادار:"+nErrorPageCounter.ToString();
			statusBar.Panels[3].Text="تعداد کل برگه ها:"+(nCorrectFormatCounter+nCorrectedPageCounter+nErrorPageCounter).ToString();

		}
		void FillOutPutListFiles(string strPath)
		{
			if(Directory.Exists(strPath))
			{
				listOutPutFiles.Items.Clear();	
				string []filesPath=System.IO.Directory.GetFiles(strPath);
				for(int i=0;i<filesPath.Length ;i++)
				{
					int index=filesPath[i].LastIndexOf("\\");
					listOutPutFiles.Items.Add(filesPath[i].Substring (index+1,filesPath[i].Length-index-1));
				}
			}
		}
		private void OrginalForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			////try
		{
			if (dsPaths.Tables.Contains("Paths"))
			{
				string strTemp="";
				strTemp= daPaths.SelectCommand.CommandText;
				daPaths.SelectCommand.CommandText="select * from paths";					
				if (dsPaths.Tables["Paths"].Rows.Count >0)
				{
					DataRow dr= dsPaths.Tables["Paths"].Rows[0];
					dr["LastOpen"] =lblPath.Text;
					dr[1]=txtPath.Text;
					dr[5]=trkRed.Value;
					dr[6]=trkGreen.Value;
					dr[7]=trkBlue.Value;
					dr[8]=trkThr.Value;
					dr[9]=trkSence.Value;
					dr[10]=trkCodeDarkPoints.Value;
					dr[11]=comboreadMethod.SelectedIndex ;
					conn.Open();			
					daPaths.Update(dsPaths.Tables["Paths"]);
					conn.Close();
				}
				else
				{
					DataRow dr=	dsPaths.Tables["Paths"].NewRow ();
					dr[5]=trkRed.Value;
					dr[6]=trkGreen.Value;
					dr[7]=trkBlue.Value;
					dr["LastOpen"]=lblPath.Text ;
					dr[1]=txtPath.Text;
					dr[8]=trkThr.Value;
					dr[9]=trkSence.Value;
					dr[10]=trkCodeDarkPoints.Value;
					dr[11]=comboreadMethod.SelectedIndex ;
					dsPaths.Tables["Paths"].Rows.Add(dr);
					conn.Open();			
					daPaths.Update(dsPaths,"Paths");
					conn.Close();
				}
						
			}
		}
			////catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}

		private void OrginalForm_Load(object sender, System.EventArgs e)
		{
			////try
		{
			filesPaths=new ArrayList();
			foreach(InputLanguage il in InputLanguage.InstalledInputLanguages)
			{
				if(il.LayoutName =="Farsi")
				{
					InputLanguage.CurrentInputLanguage=il;
					break;
				}
			}
			statusBarPanels4=statusBar.Panels[4];
			strTemplateName="";
			trkRed.Value=BackColor.R;
			trkGreen.Value=BackColor.G;
			trkBlue.Value=BackColor.B;
			arrValPaths=new ArrayList();
			arrErrPaths=new ArrayList();;
			arrValCodes=new ArrayList();;
			arrErrCodes=new ArrayList();;
			nFormType=2;
			tf=new TempForm();
			string strMDBPath=Application.StartupPath ;
			strMDBPath+="\\FormReader.mdb";
			
			conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+strMDBPath+";Persist Security Info=False");
			
			command = new OleDbCommand();
			command.Connection=conn;
			da=new OleDbDataAdapter("select * from templates",conn);
			cmdBuilder=new OleDbCommandBuilder(da);
			ds=new DataSet();				
			daResults=new OleDbDataAdapter("select * from results",conn);
			cmdBuilderResults=new OleDbCommandBuilder(daResults);
			
			dsResults=new DataSet();

			daTempResults=new OleDbDataAdapter("select * from TempResults",conn);
			cmdBuilderTempResults=new OleDbCommandBuilder(daTempResults);
			dsTempResults=new DataSet();

			daPaths=new OleDbDataAdapter("select * from Paths",conn);
			cmdBuilderPaths=new OleDbCommandBuilder(daPaths);
			dsPaths=new DataSet();
			daErrResult=new OleDbDataAdapter("select * from ErrorResults",conn);
			cmdBuilderErrResult=new OleDbCommandBuilder(daErrResult);
			dsErrResult=new DataSet();
			ApplyChanges();
			TempResults=null;FinalResults=null;
			if(TempResults == null)
			{
				TempResults = new bool[61 ,31];
			}
			if(FinalResults == null)
			{
				FinalResults=new bool[nNumberOfTotalQuestions ,nNumberCasesNumber];
			}
			TopFormResults=new int[2,62];
			
			ReadFromDatasetPaths();
			ReadErrorResultsFromDB();
			ReadResultsFromDB();			
			dataGrid.DataSource=dsResults.Tables[0];
			statusBar.Panels[5].Text="تعداد برگه های خوانده شده در پایگاه داده: "+dsResults.Tables[0].Rows.Count.ToString();
			arrNumbers = new int[13];
			arrRowNumbers=new	int[13,3];
			arrCaseLables=null;arrQuestionSCases=null;arrCasesState=null;
			arrCaseLables=new Rectangle [61,31];
			arrQuestionSCases=new Rectangle[nNumberOfTotalQuestions,nNumberCasesNumber]; 
			arrCasesState=new int[nNumberOfTotalQuestions,nNumberCasesNumber];
			
			DrawDownSection();
			
			listFiles.Focus();
			FillOutPutListFiles(txtPath.Text );
			TablesStatus();
		}
			////catch(Exception ex)	{MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}
		void ReadFromDatasetPaths()
		{
			string strTemp="";
			strStuderntsResultPath="";
			strChortsResultPath="";
			strTemp= daPaths.SelectCommand.CommandText;
			daPaths.SelectCommand.CommandText="select * from paths";
			conn.Open();			
			daPaths.Fill(dsPaths,"Paths");
			conn.Close();
			if (dsPaths.Tables["Paths"].Rows.Count >0)
			{
				lblPath.Text =dsPaths.Tables["Paths"].Rows[0][0].ToString();
				
				trkRed.Value=int.Parse (dsPaths.Tables["Paths"].Rows[0][5].ToString());
				trkGreen.Value=int.Parse (dsPaths.Tables["Paths"].Rows[0][6].ToString());
				trkBlue.Value=int.Parse (dsPaths.Tables["Paths"].Rows[0][7].ToString());
				BackColor=Color.FromArgb(trkRed.Value,trkGreen.Value,trkBlue.Value);
				trkThr.Value=int.Parse (dsPaths.Tables["Paths"].Rows[0][8].ToString());
				trkSence.Value=int.Parse (dsPaths.Tables["Paths"].Rows[0][9].ToString());
				trkCodeDarkPoints.Value=int.Parse (dsPaths.Tables["Paths"].Rows[0][10].ToString());
				comboreadMethod.SelectedIndex=int.Parse (dsPaths.Tables["Paths"].Rows[0][11].ToString());
				txtPath.Text=dsPaths.Tables["Paths"].Rows[0][1].ToString();
				nDarkPointThr=trkThr.Value;
				nCodeDarkPointThr=trkCodeDarkPoints.Value;
				nBrightThreshold=(float)(trkSence.Value/255.0);;
				lblSence.Text=trkSence.Value.ToString()+"  ("+((trkSence.Value/255.0)*100).ToString("00")+"%)";
				lblDarkPointThr.Text=nDarkPointThr.ToString();
				lblCodeDarkPoints.Text=nCodeDarkPointThr.ToString();
				lblColorSence.BackColor=Color.FromArgb(trkSence.Value,trkSence.Value,trkSence.Value);
				if(!Directory.Exists(txtPath.Text))
				{
					txtPath.Text="";
				}
				if(Directory.Exists( lblPath.Text))
				{
					FillListFiles(lblPath.Text);
				}
				else
					lblPath.Text ="";
				
			
			}
		}
		void DrawTopSection()
		{
			Graphics g=panelPaint.CreateGraphics();
			
			int xCounter=0,yCounter=nNumber1Row*10+15;	
			
			g.DrawString(ConvertToArabic( strVar1Code),new Font("Tahoma",8),Brushes.Black ,50,5);
			xCounter=250;
			if(TempResults == null)
			{
				TempResults = new bool[61 ,31];
			}
			if(FinalResults == null)
			{
				FinalResults=new bool[nNumberOfTotalQuestions ,nNumberCasesNumber];
			}
			for(int colIndex=1;colIndex<=30;colIndex++)
			{
				xCounter +=10;
				yCounter=5;
				for(int rowIndex=0;rowIndex <2 ;rowIndex++)
				{											
					arrCaseLables[rowIndex,colIndex]=new Rectangle (xCounter,yCounter,7,7);
					if(TopFormResults[rowIndex ,colIndex  ]>=nDarkPointThr )
					{
						g.FillRectangle(Brushes.Black,arrCaseLables[rowIndex,colIndex]);
						
					}
					else
						g.FillRectangle(Brushes.White,arrCaseLables[rowIndex,colIndex]);
					yCounter +=10;
				}
				
			}

			nDownSectionY = 7+(nNumber1Cases*12) ;
		}
		void CreateComponents()
		{			
			DrawDownSection();			
		}
		
		void DrawDownSection()
		{
			try
			{
				Graphics g=panelPaint.CreateGraphics();
				int nNumberOfClassDistance=0;
				int xCounter=0,yCounter=nDownSectionY+nNumberFirstRow*10,
					classCounter=0,caseCounter=0,QCounter=0;int trueCounter=0;int rowIndex=0;
				for(;rowIndex <nNumberOfLeftLayout ;rowIndex++)
				{
					if(trueCounter>1)
					{
						for(int i=0;i<nNumberCasesNumber ;i++)
							arrCasesState[rowIndex-1+nNumberOfLeftLayout*classCounter, i]=(FinalResults[rowIndex-1+nNumberOfLeftLayout*classCounter, i])?3:0;
					}
					if(QCounter==nNumberQuestionNumber  )
					{
						QCounter=0;
						yCounter +=15;
					
					}
					else
						yCounter +=10;
					if(!QuestionsDir)xCounter=600;
					else
						xCounter=xCounter=10;
					caseCounter=0;
					QCounter++;
					g.DrawString((rowIndex+1).ToString(),new Font("Tahoma",6),Brushes.Black,xCounter,yCounter);
					classCounter=0;
					nNumberOfClassDistance=0;
					trueCounter=0;
					for(int colIndex=0;colIndex<nNumberColNumber  *nNumberCasesNumber ;colIndex++)
					{
						if(caseCounter==nNumberCasesNumber)
						{
							if(trueCounter>1)
							{
								for(int i=0;i<nNumberCasesNumber ;i++)
									arrCasesState[rowIndex+nNumberOfLeftLayout*classCounter, i]=(FinalResults[rowIndex+nNumberOfLeftLayout*classCounter, i])?3:0;
							}
							trueCounter=0;
							caseCounter=0;
							classCounter++;
							if(!QuestionsDir)
							{
								xCounter -=40;
								g.DrawString((rowIndex+1+nNumberOfLeftLayout*classCounter).ToString(),new Font("Tahoma",6),Brushes.Black,xCounter+20,yCounter);
							}
							else 
							{
								xCounter +=40;
								g.DrawString((rowIndex+1+nNumberOfLeftLayout*classCounter).ToString(),new Font("Tahoma",6),Brushes.Black,xCounter-20,yCounter);
							}
						}
						else
						{
							if(!QuestionsDir)xCounter -=20;
							else xCounter +=20;
						}
						if(rowIndex==0)
						{
							if(CasesDir)
								g.DrawString((caseCounter+1).ToString(),new Font("Tahoma",6),Brushes.Black,xCounter+5,yCounter-10);
							else
								g.DrawString((5-caseCounter-1).ToString(),new Font("Tahoma",6),Brushes.Black,xCounter+5,yCounter-10);
						}
						arrCaseLables[rowIndex,colIndex]=new Rectangle (xCounter,yCounter,15,7);
						nNumberOfClassDistance=classCounter* nNumberClassDistance;
						if((rowIndex+nNumberOfLeftLayout*classCounter)< nNumberOfTotalQuestions)
						{
							arrQuestionSCases[rowIndex+nNumberOfLeftLayout*classCounter,caseCounter]=new Rectangle (xCounter,yCounter,15,7);
					
							if(FinalResults[rowIndex+nNumberOfLeftLayout*classCounter, caseCounter])
							{
								arrCasesState[rowIndex+nNumberOfLeftLayout*classCounter,caseCounter]=1;
								trueCounter++;
								//listCases.Add(arrCaseLables[rowIndex,colIndex],1);
								//g.FillRectangle(Brushes.Black,arrCaseLables[rowIndex,colIndex]);
							}
							else
							{
								arrCasesState[rowIndex+nNumberOfLeftLayout*classCounter,caseCounter]=0;
								//listCases.Add(arrCaseLables[rowIndex,colIndex],0);
								//g.FillRectangle(Brushes.White,arrCaseLables[rowIndex,colIndex]);
							}
						}
						caseCounter++;
					}
				}
				if(trueCounter>1)
				{
					for(int i=0;i<nNumberCasesNumber ;i++)
						arrCasesState[rowIndex-1+nNumberOfLeftLayout*classCounter, i]=(FinalResults[rowIndex-1+nNumberOfLeftLayout*classCounter, i])?3:0;
				}
			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);}
		}
		private void OrginalForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			////try
		{		
			arrCaseLables=null;arrQuestionSCases=null;arrCasesState=null;
			arrCaseLables=new Rectangle [61,31];
			arrQuestionSCases=new Rectangle[nNumberOfTotalQuestions,nNumberCasesNumber]; 
			arrCasesState=new int[nNumberOfTotalQuestions,nNumberCasesNumber];
			DrawTopSection();CreateComponents();			
			DrawNCeaseAndSelectedCases();
		}
			////catch(Exception ex){MessageBox.Show(ex.Message);}
		
		}
		private void DrawNCeaseAndSelectedCases()
		{
			
			
			Graphics g=panelPaint.CreateGraphics();
			for(int i=0;i<nNumberOfTotalQuestions;i++)
			{
				for(int j=0;j<nNumberCasesNumber;j++)
					switch(arrCasesState[i,j])
					{
						case 0:g.FillRectangle(Brushes.White   ,arrQuestionSCases[i,j]);break;
						case 1:g.FillRectangle(Brushes.Black  ,arrQuestionSCases[i,j]);break;
						case 2:g.FillRectangle(Brushes.Blue  ,arrQuestionSCases[i,j]);break;														
						case 3:g.FillRectangle(Brushes.Red   ,arrQuestionSCases[i,j]);break;														
					}	
			}
					
					
				
			
		}
		private void panelPaint_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			for(int i=0;i<nNumberOfTotalQuestions;i++)
			{
				for(int j=0;j<nNumberCasesNumber;j++)
					if(arrQuestionSCases[i,j].Contains(e.X,e.Y ))
					{
						if(FinalResults[i,j])
						{
							FinalResults[i,j]=false;
							arrCasesState[i,j]=0;
							DrawNCeaseAndSelectedCases();
							break;
						}
						for(int counter=0;counter<nNumberCasesNumber;counter++)
							FinalResults[i,counter]=false;
						FinalResults[i,j]=true;
						for(int counter=0;counter<nNumberCasesNumber;counter++)
							arrCasesState[i,counter]=0;
						arrCasesState[i,j]=2;
						DrawNCeaseAndSelectedCases();
						break;
					}
			}
		}
		private void pictureBox5_Click(object sender, System.EventArgs e)
		{
			if (bIsBusy)return;
			panelCounter++;
			switch(Math.Abs( panelCounter)%4)
			{
				case 0:panelPaint.BringToFront(); break;
				
				case 1:panelOutPutSettings.BringToFront();break;
				case 2:panelPerformanceStatus.BringToFront();break;
				case 3:panelColorSettings.BringToFront();break;
			}
		}

		private void pictureBox2_Click(object sender, System.EventArgs e)
		{			
			if (bIsBusy)return;
			panelAnalyze.BringToFront();
			panelPaint.BringToFront();
			statusBar.BringToFront();
			panelCounter=0;
			SaveFlag=false;
			ReadResultsFromDB();						
			dataGrid.DataSource=dsResults.Tables[0].Copy();
			statusBar.Panels[5].Text="تعداد برگه های خوانده شده در پایگاه داده: "+dsResults.Tables[0].Rows.Count.ToString();
			if(dsResults.Tables[0].Rows.Count>0)dataGrid.CurrentRowIndex=0;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(SaveFlag&&MessageBox.Show("آيا مايليد تغييرات در پايگاه داده ذخيره شود","هشدار",MessageBoxButtons.YesNo )==DialogResult.Yes )
			{
				////try
			{
				conn.Open();
				if(dsResults.Tables.Contains("results"))daResults.Update(dsResults,"results");
				conn.Close();
			}
				////catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
			}				
			groupMain.BringToFront();
			statusBar.BringToFront();
		}

		private void dataGrid_CurrentCellChanged(object sender, System.EventArgs e)
		{
			panelPaint.BringToFront();
			panelCounter=0;
			int row=dataGrid.CurrentRowIndex;
			if(row < dsResults.Tables[0].Rows.Count )
			{
				if(dataGrid.CurrentCell.ColumnNumber ==0)
				{
					string strPath=dsResults.Tables[0].Rows[row][10].ToString();
					string strPath1=strPath;
					if(!System.IO.File.Exists (strPath ))
					{
						strPath1=strPath.Replace(".jpg",".val");
						if(!System.IO.File.Exists (strPath1))
						{
							strPath1=strPath.Replace(".jpg",".VAL");
							if(!System.IO.File.Exists (strPath1))
							{
								MessageBox.Show("چنين فايلي در اين كامپيوتر موجود نمي باشد");	
								return ;
							}

						}
					}
					if( bDisplayInPaiont)
					{							
						System.Diagnostics.Process.Start("mspaint.exe","\""+strPath1+"\"");
					}
				
					if( bOrginalDispaly)
					{
						string strTempPath=System.IO.Path.GetTempFileName();
						File.Copy(strPath1,strTempPath,true);
						if(tf.bDisposed)tf=new TempForm();if(tf.bDisposed)tf=new TempForm();tf.filePath=strTempPath;
						tf.Location= new Point((int)( panelPaint.Size.Width*0.65),(int)(this.Height/4));;
					
						tf.Show();tf.BringToFront();tf.TopMost=true;tf.TopMost=true;
						tf.pictureBox.Image = Image.FromFile  (strTempPath);
					}
				
					CorrectionCurrentRow();	
					panelPaint.Invalidate();
					rowIndex=dataGrid.CurrentRowIndex;
				}
			}
		}
		private void label53_Click(object sender, System.EventArgs e)
		{
			ApplyCodeSettings();
			MessageBox.Show("اعمال گرديد","",MessageBoxButtons.OK ,MessageBoxIcon.Information);
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
			InvertErrorFile();	
			MessageBox.Show("اعمال گرديد","",MessageBoxButtons.OK ,MessageBoxIcon.Information);
			
		}
		void InvertErrorFile()
		{
			if (bIsBusy)return;
			if(lblPath.Text != "")
			{
				string []filesPath=new string[filesPaths.Count ];
				filesPaths.CopyTo(filesPath);
				for(int i=0;i<filesPath.Length ;i++)
				{
					if (filesPath[i].LastIndexOf(".err") !=	-1||filesPath[i].LastIndexOf(".ERR") !=	-1 )
					{
						int index=filesPath[i].LastIndexOf(".err");					
						index=(index==-1)?filesPath[i].LastIndexOf(".ERR"):index;
						if(File.Exists (filesPath[i].Substring (0,index)+".jpg"))File.Delete(filesPath[i].Substring (0,index)+".jpg");
						File.Move(filesPath[i],filesPath[i].Substring (0,index)+".jpg");
					}
				}	

			}
			FillListFiles(lblPath.Text );
		}
		private void pictureBox4_Click(object sender, System.EventArgs e)
		{
			if (bIsBusy)return;
			DeleteTotalRowsFromDB();
			TablesStatus();
			if(lblPath.Text != "")
			{
				string []filesPath=new string[filesPaths.Count ];
				filesPaths.CopyTo(filesPath);
				for(int i=0;i<filesPath.Length ;i++)
				{
					if (filesPath[i].LastIndexOf(".VAL") !=	-1||filesPath[i].LastIndexOf(".val") !=	-1 )
					{
						int index=filesPath[i].LastIndexOf(".val");	
						index=(index==-1)?filesPath[i].LastIndexOf(".VAL"):index;
						if(File.Exists (filesPath[i].Substring (0,index)+".jpg"))File.Delete(filesPath[i].Substring (0,index)+".jpg");
						File.Move(filesPath[i],filesPath[i].Substring (0,index)+".jpg");
					}
				}
				MessageBox.Show("اعمال گرديد","",MessageBoxButtons.OK ,MessageBoxIcon.Information);
				FillListFiles(lblPath.Text );
			}
		}
		private void MarkTheFiles()
		{
			string path;int charIndex;
			for(int index=0;index<arrValPaths.Count ;index++)
			{
				path=(string)arrValPaths[index];
				charIndex=path.LastIndexOf(".");
				if (File.Exists( path.Substring (0,charIndex)+".val"))File.Delete(path.Substring (0,charIndex)+".val");
				File.Move(path,path.Substring (0,charIndex)+".val");
			}

			if(bContinue || arrErrPaths.Count> 0)
			{
				if(arrErrPaths.Count> 0)
				{
					bPerformaneIsOk=false;
					bReachedResultsIsOk=false;

					picPerformaneStatus.Image.Dispose();
					Bitmap bmp=new Bitmap(GetType(),"NotOk.png");
					picPerformaneStatus.Image=bmp;

					picReachedResults.Image.Dispose();
					bmp=new Bitmap(GetType(),"NotOk.png");
					lblReachedResults.ForeColor=Color.Red;
					picReachedResults.Image=bmp;
				}
				else
				{
					bPerformaneIsOk=true;
					if(bNoNumberIsOk)
					{
						bReachedResultsIsOk=true;
						picReachedResults.Image.Dispose();
						Bitmap bmp=new Bitmap(GetType(),"Ok.png");
						lblReachedResults.ForeColor=Color.DarkOliveGreen;
						picReachedResults.Image=bmp;
					}
					else
					{
						bReachedResultsIsOk=false;
						picReachedResults.Image.Dispose();
						Bitmap bmp=new Bitmap(GetType(),"NotOk.png");
						picReachedResults.Image=bmp;
						lblReachedResults.ForeColor=Color.Red;
					}
					picPerformaneStatus.Image.Dispose();
					Bitmap bmp1=new Bitmap(GetType(),"Ok.png");
					lblPerformaneStatus .ForeColor=Color.DarkOliveGreen;
					picPerformaneStatus.Image=bmp1;
				}
				if(bNoNumberIsOk)
				{
					picNoNumbers.Image.Dispose();
					Bitmap bmp=new Bitmap(GetType(),"Ok.png");
					lblNoNumbers .ForeColor=Color.DarkOliveGreen;
					picNoNumbers.Image=bmp;
					if(bPerformaneIsOk)
					{
						bReachedResultsIsOk=true;
						picReachedResults.Image.Dispose();
						bmp=new Bitmap(GetType(),"Ok.png");
						lblReachedResults.ForeColor=Color.DarkOliveGreen;
						picReachedResults.Image=bmp;
					}
					else
					{
						bReachedResultsIsOk=false;
						picReachedResults.Image.Dispose();
						bmp=new Bitmap(GetType(),"NotOk.png");
						picReachedResults.Image=bmp;
						lblReachedResults.ForeColor=Color.Red;
					}
				}
				else
				{
					picNoNumbers.Image.Dispose();
					Bitmap bmp=new Bitmap(GetType(),"NotOk.png");
					
					lblNoNumbers.ForeColor=Color.Red;
					picNoNumbers.Image=bmp;
					bReachedResultsIsOk=false;
					picReachedResults.Image.Dispose();
					bmp=new Bitmap(GetType(),"NotOk.png");
					picReachedResults.Image=bmp;
					lblReachedResults.ForeColor=Color.Red;
				}
			}
			
			for(int index=0;index<arrErrPaths.Count ;index++)
			{
				
				path=(string)arrErrPaths[index];
				charIndex=path.LastIndexOf(".");	
				if (File.Exists( path.Substring (0,charIndex)+".err"))File.Delete(path.Substring (0,charIndex)+".err");
				File.Move(path,path.Substring (0,charIndex)+".err");
			}
			//statusBar.Panels[1].Text="تعداد برگه های صحیح:"+arrValPaths.Count.ToString();
			//statusBar.Panels[2].Text="تعداد برگه های خطادار:"+arrErrPaths.Count.ToString();
		}
		private void SaveInDBErrorResults()
		{
			string strErrors="";
			for(int index=0;index<arrErrCodes.Count ;index++)
			{
				DataRow dr= dsErrResult.Tables["ErrorResults"].NewRow();
				dr["Code"]=arrErrCodes[index];
				dr["Comment"]=arrErrorStrings[(int)arrErrCodes[index]-1];
				dr["path"]=arrErrPaths[index];
				strErrors+="\n"+arrErrPaths[index]+" =>\n"+arrErrorStrings[(int)arrErrCodes[index]-1];
				dsErrResult.Tables["ErrorResults"].Rows.Add(dr);
			}		
			daErrResult.Update (dsErrResult,"ErrorResults");
			/*if(strErrors != "")
				MessageBox.Show(strErrors);*/
		}
		void ReadErrorResultsFromDB()
		{
			conn.Open();			
			if(dsErrResult.Tables.Contains("ErrorResults")&&dsErrResult.Tables["ErrorResults"].Rows.Count >0)
				dsErrResult.Tables[0].Rows.Clear();
			daErrResult.Fill(dsErrResult,"ErrorResults");
			if(dsErrResult.Tables[0].Rows.Count >0)
			{
				bPerformaneIsOk=false;
				picPerformaneStatus.Image.Dispose();
				Bitmap bmp=new Bitmap(GetType(),"NotOk.png");
				
				lblPerformaneStatus .ForeColor=Color.Red;
				picPerformaneStatus.Image=bmp;
			}
			else
			{
				bPerformaneIsOk=true;
				picPerformaneStatus.Image.Dispose();
				Bitmap bmp=new Bitmap(GetType(),"Ok.png");
				lblPerformaneStatus .ForeColor=Color.DarkOliveGreen;
				picPerformaneStatus.Image=bmp;
			}
			conn.Close();
		}
		private void pictureBox3_Click(object sender, System.EventArgs e)
		{
			if (bIsBusy)return;
			DataTable dt=dsErrResult.Tables["ErrorResults"];
			panelPerformanceStatus.BringToFront();
			panelCounter=3;			
			dataGridErrList.DataSource=dt;
		
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			////try
		{
			bPerformaneIsOk=true;

			picPerformaneStatus.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"Ok.png");
			lblPerformaneStatus .ForeColor=Color.DarkOliveGreen;
			picPerformaneStatus.Image=bmp;
			if(bNoNumberIsOk)
			{
				bReachedResultsIsOk=true;
				picReachedResults.Image.Dispose();
				 bmp=new Bitmap(GetType(),"Ok.png");
				lblReachedResults.ForeColor=Color.DarkOliveGreen;
				picReachedResults.Image=bmp;
			}
			conn.Open();
			command.CommandText="delete from ErrorResults";
			command.ExecuteNonQuery();
			conn.Close();
			dsErrResult.Tables["ErrorResults"].Rows.Clear();
			dataGridErrList.Refresh();
			TablesStatus();
		}
			////catch(Exception ex){MessageBox.Show("عمليات انجام نشد،لطفا با گروه پشتيباني تماس بگيريد" );MessageBox.Show(ex.Message );}
		}



		private void label54_Click(object sender, System.EventArgs e)
		{
			if(lblPath.Text =="..." || lblPath.Text =="" || !Directory.Exists(lblPath.Text ))
			{
				MessageBox.Show("چنين مسيري موجود نمي باشد");
				return;
			}
			if(listFiles.Items.Count==0 )
			{
				MessageBox.Show("ليست خاليست،لطفا يك مسير ديگر انتخاب نماييد");
				return;
			}
			if (bIsBusy)return;
			bContinue=true;
			bStartCorrection=true;
			nBrightThreshold=(float)(trkSence.Value/255.0);	
			string path=lblPath.Text ;
			ReadResultsFromDB();
			statusBar.Panels[5].Text="تعداد برگه های خوانده شده در پایگاه داده: "+dsResults.Tables[0].Rows.Count.ToString();
			DeleteTotalErrorResultFromDB();
			/*DeleteTempRows();
			DeleteTotalRowsFromDB();
			int nNoNumber=dsTempResults.Tables[0].Rows.Count;
			int nPerformane=dsErrResult.Tables[0].Rows.Count;
			int nReachedResults=dsResults.Tables[0].Rows.Count;
			lblNoNumbersO.Text=lblNoNumbersO.Text.Substring(0,26)+"("+nNoNumber.ToString()+")";
			lblPerformaneStatusO.Text=lblPerformaneStatusO.Text.Substring(0,23)+"("+nPerformane.ToString()+")";
			lblReachedResultsO.Text=lblReachedResultsO.Text.Substring(0,27)+"("+nReachedResults.ToString()+")";
*/
			ApplyChanges();
			InvertErrorFile();
			if(comboFormType.SelectedIndex == -1)
			{
				CreateCaret ( comboFormType.Handle ,(IntPtr.Zero ),comboFormType.Width ,20);
				SetCaretPos(0,0);
				ShowCaret( comboFormType.Handle);
				MessageBox.Show("لطفا نوع فرم را در قسمت تعیین شده مشخص نمایید");
				return ;
			}
			strTemplateName=comboFormType.Text;
			/*DialogResult dialogRes=MessageBox.Show("آيا مايليد نتايج قبلي پاک  شود","",MessageBoxButtons.YesNoCancel );
			if(dialogRes ==DialogResult.Yes )
			{
				DeleteTotalRowsFromDB();
				ReadResultsFromDB ();
				statusBar.Panels[5].Text="تعداد برگه های خوانده شده در پایگاه داده: "+dsResults.Tables[0].Rows.Count.ToString();

				DeleteTotalErrorResultFromDB();
			}
			else
			{
				if(dialogRes ==DialogResult.Cancel  )
				{
					return;
				}
			}*/
			if(lblPath.Text != "")
			{
				arrErrCodes.Clear();
				arrErrPaths.Clear();
				arrValPaths.Clear();
				int nCount=listFiles.Items.Count ;arrFilesPathes=null;
				arrFilesPathes = new string[listFiles.Items.Count];
				nFilesCount=0;
				for(int i=0;i<nCount;i++)
				{
					if( (listFiles.Items[i].ToString().LastIndexOf (".val")!=-1)||(listFiles.Items[i].ToString().LastIndexOf (".VAL")!=-1)||(listFiles.Items[i].ToString().LastIndexOf (".err")!=-1)||(listFiles.Items[i].ToString().LastIndexOf (".ERR")!=-1))
						continue;
					
					//arrFilesPathes[nFilesCount++]=path+"\\"+listFiles.Items[i].ToString();
					arrFilesPathes[nFilesCount++]=filesPaths[i].ToString();
				}
				
				formCounter=0;	
				bIsBusy = true;
				Refresh();
				WorkerThread();
				TablesStatus();
				/*System.Threading.Thread wt=new System.Threading.Thread(new System.Threading.ThreadStart(WorkerThread));				
				wt.ApartmentState=System.Threading.ApartmentState.STA ;
				wt.Priority=System.Threading.ThreadPriority.Highest;
				wt.Start();*/
				
				
			}
		}
		void WorkerThread()
		{
			try
			{
				string str="پايان پردازش سريال\n";		
				DateTime time=DateTime.Now;
				for(int index=0;index<nFilesCount;index++)
				{
					if(!bContinue )
					{
						str+="\n"+DateTime.Now.Subtract(time).ToString();
						MessageBox.Show(str);
						MarkTheFiles();
						SaveInDBErrorResults();
						FillListFiles(lblPath.Text);
						bIsBusy = false;
						bStartCorrection=false;
						return;
					}							
					OpenSingle(arrFilesPathes[index]);				
				}
				str+="\n"+DateTime.Now.Subtract(time).ToString();
				MessageBox.Show(str);
				MarkTheFiles();
				SaveInDBErrorResults();
				FillListFiles(lblPath.Text);
				bIsBusy = false;
				bStartCorrection=false;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message );				
				MarkTheFiles();
				SaveInDBErrorResults();
				FillListFiles(lblPath.Text);
				bIsBusy = false;
				bStartCorrection=false;
			}
			bIsBusy = false;
		}
		private void picColInRecord_DoubleClick(object sender, System.EventArgs e)
		{
			FolderBrowserDialog fb=new FolderBrowserDialog();
			if(lblPath.Text != "" && lblPath.Text!="...")
			{
				fb.SelectedPath =lblPath.Text.Substring(0, lblPath.Text.LastIndexOf("\\"));
			}
			if(fb.ShowDialog()==DialogResult.OK )
			{
				if(lblPath.Text != fb.SelectedPath && dsResults.Tables[0].Rows.Count > 0 )
				{
					DialogResult dialogRes=MessageBox.Show("آيا مايليد نتايج قبلي پاک  شود","",MessageBoxButtons.YesNoCancel );
					if(dialogRes ==DialogResult.Yes )
					{
						DeleteTotalErrorResultFromDB();
						DeleteTempRows();
						DeleteTotalRowsFromDB();
						bReachedResultsIsOk=true;
						picReachedResults.Image.Dispose();
						Bitmap bmp=new Bitmap(GetType(),"Ok.png");
						lblReachedResults.ForeColor=Color.DarkOliveGreen;
						picReachedResults.Image=bmp;

						bReachedResultsIsOk=true;
						picPerformaneStatus.Image.Dispose();
						bmp=new Bitmap(GetType(),"Ok.png");
						lblPerformaneStatus .ForeColor=Color.DarkOliveGreen;
						picPerformaneStatus.Image=bmp;

						bNoNumberIsOk=true;
						picNoNumbers.Image.Dispose();
						bmp=new Bitmap(GetType(),"Ok.png");
						lblNoNumbers .ForeColor=Color.DarkOliveGreen;
						picNoNumbers.Image=bmp;
						TablesStatus();
					}
					else
					{
						if(dialogRes ==DialogResult.Cancel  )
						{
							FillListFiles(lblPath.Text );
							return;
						}
					}

				}
				else
				{
					/*DeleteTotalErrorResultFromDB();
					DeleteTempRows();
					DeleteTotalRowsFromDB();
					bReachedResultsIsOk=true;
					picReachedResults.Image.Dispose();
					Bitmap bmp=new Bitmap(GetType(),"Ok.png");
					lblReachedResults.ForeColor=Color.DarkOliveGreen;
					picReachedResults.Image=bmp;

					bReachedResultsIsOk=true;
					picPerformaneStatus.Image.Dispose();
					 bmp=new Bitmap(GetType(),"Ok.png");
					lblPerformaneStatus .ForeColor=Color.DarkOliveGreen;
					picPerformaneStatus.Image=bmp;

					bNoNumberIsOk=true;
					picNoNumbers.Image.Dispose();
					 bmp=new Bitmap(GetType(),"Ok.png");
					lblNoNumbers .ForeColor=Color.DarkOliveGreen;
					picNoNumbers.Image=bmp;*/
				}
				
				//statusBar.Panels[1].Text="تعداد برگه های صحیح: 0";
				//statusBar.Panels[2].Text="تعداد برگه های خطادار: 0";
			}
			FillListFiles(fb.SelectedPath);
		}

		private void groupBox3_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
		
		}



		private void txtFixNumber_TextChanged(object sender, System.EventArgs e)
		{
			


		}

		private void txtGroupedFixNumber_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		private void panelPageSettings_Validated(object sender, System.EventArgs e)
		{
			ApplyChanges();
		}

		private void txtFixNumber_Validated(object sender, System.EventArgs e)
		{
			if(txtFixNumber.Text.Length != nNumber1Digits )
			{
				MessageBox.Show("لطفا تعداد ارقام وارد شده را مطابق تعداد ارقام ذکر شده در قسمت مربوط به متغير اول، وارد نماييد\nيا در قسمت مربوطه تعداد ارقام را تغيير دهيد ");
				((TextBox)sender).Focus();
			}
		}

		private void txtAzmunNumber_Validated(object sender, System.EventArgs e)
		{
			
		}

		private void txtStudentNumber_Validated(object sender, System.EventArgs e)
		{
			
		}

		private void txt1VarName_Validated(object sender, System.EventArgs e)
		{
			
		}

		private void txt2VarName_Validated(object sender, System.EventArgs e)
		{
			
		}

		private void txt1Digits_Validated(object sender, System.EventArgs e)
		{
			if(txt1Digits.Text.Length ==0 )
			{
				MessageBox.Show("  تعداد ارقام  مربوط به متغير اول حداقل بايد يک رقم باشد");
				txt1Digits.Focus();
			}
			else
			{
				if(int.Parse(txt1Digits.Text)<3)
				{
					MessageBox.Show("  تعداد ارقام  مربوط به متغير اول حداقل بايد عدد سه باشد");
					txt1Digits.Focus();
				}
			}
		}

		private void txt2Digits_Validated(object sender, System.EventArgs e)
		{
			
		}

		private void label57_Click(object sender, System.EventArgs e)
		{
			if (bIsBusy)return;
			panelOutPutSettings.BringToFront();
			panelCounter=2;
		}

		private void radioQLeftToRight_CheckedChanged(object sender, System.EventArgs e)
		{
			QuestionsDir =radioQLeftToRight.Checked; 
		}

		private void radioCLeftToRight_CheckedChanged(object sender, System.EventArgs e)
		{
			CasesDir = radioCLeftToRight.Checked; 
		}
		bool bSubjectSelect;
		private void combSubjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void combSubjects_MouseEnter(object sender, System.EventArgs e)
		{
			bSubjectSelect=true;
		}

		private void combSubjects_Leave(object sender, System.EventArgs e)
		{
			bSubjectSelect=false;
		}
		bool btxt2DigitsEnter;
		private void txt2Digits_MouseEnter(object sender, System.EventArgs e)
		{
			btxt2DigitsEnter=true;
		}

		private void txt2Digits_MouseLeave(object sender, System.EventArgs e)
		{
			btxt2DigitsEnter=false;
		}

		private void txt2Digits_Leave(object sender, System.EventArgs e)
		{
			
		}

		private void txtGroupedFixNumber_Validated(object sender, System.EventArgs e)
		{
			
		}
		bool btxt1DigitsEnter;
		private void txt1Digits_MouseEnter(object sender, System.EventArgs e)
		{
			btxt1DigitsEnter=true;
		}

		private void txt1Digits_MouseLeave(object sender, System.EventArgs e)
		{
			btxt1DigitsEnter=false;
		}

		private void txt1Digits_Leave(object sender, System.EventArgs e)
		{
			

		}

		private void txt1Row_Validated(object sender, System.EventArgs e)
		{
			TextBox txtTemp=(TextBox)sender;
			if(int.Parse(txtTemp.Text)<1)
			{
				MessageBox.Show("اين مقدار بايد بيشتر يا مساوي يک باشد");
				txtTemp.Focus();
			}
		}

		private void chkStartFromMiddle_CheckedChanged(object sender, System.EventArgs e)
		{
			bStartFromMiddle=chkStartFromMiddle.Checked ;
		}

		private void OrginalForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue ==27)
				bContinue=false;
			
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void trkRed_ValueChanged(object sender, System.EventArgs e)
		{
			lblRed.Text=trkRed.Value.ToString();
			BackColor=Color.FromArgb(trkRed.Value ,BackColor.G ,BackColor.B );
		}

		private void trkGreen_ValueChanged(object sender, System.EventArgs e)
		{
			lblGreen.Text=trkGreen.Value.ToString();
			BackColor=Color.FromArgb(BackColor.R ,trkGreen.Value,BackColor.B );
		}

		private void trkBlue_ValueChanged(object sender, System.EventArgs e)
		{
		    lblBlue.Text=trkBlue.Value.ToString();
			BackColor=Color.FromArgb(BackColor.R ,BackColor.G,trkBlue.Value );

		}

		private void pictureBox13_Click(object sender, System.EventArgs e)
		{
			if (bIsBusy)return;
			switch(Math.Abs( panelCounter+3)%4)
			{
				case 0:panelCounter=0;panelPaint.BringToFront(); break;				
				case 1:panelCounter=1;panelOutPutSettings.BringToFront();break;
				case 2:panelCounter=2;panelPerformanceStatus.BringToFront();break;
				case 3:panelCounter=3;panelColorSettings.BringToFront();break;
			}

		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			panelCounter=1;panelPageSettings.BringToFront();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			panelPaint.BringToFront();
			panelCounter=0;
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			panelCounter=2;panelOutPutSettings.BringToFront();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			panelCounter=3;panelPerformanceStatus.BringToFront();
		}

		private void menuItem3_Click_1(object sender, System.EventArgs e)
		{
			panelCounter=4;panelColorSettings.BringToFront();
		}

		private void panelPerformanceStatus_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void radioDefault_MouseEnter(object sender, System.EventArgs e)
		{
			btxt2DigitsEnter=true;
		}

		private void radioDefault_MouseLeave(object sender, System.EventArgs e)
		{
			btxt2DigitsEnter=false;
		}

		private void groupBox15_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void chkStudent_MouseEnter(object sender, System.EventArgs e)
		{
			btxt1DigitsEnter=true;
		}

		private void chkStudent_MouseLeave(object sender, System.EventArgs e)
		{
			btxt1DigitsEnter=false;
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			if(lblPath.Text != "" && listFiles.SelectedIndex>=0)
			{
				string strPath=filesPaths[listFiles.SelectedIndex].ToString();//lblPath.Text+"\\"+listFiles.SelectedItem .ToString();
				string strTempPath=System.IO.Path.GetTempFileName();
				File.Copy(strPath,strTempPath,true);
				
				if(tf.bDisposed)tf=new TempForm();tf.filePath=strTempPath;
				tf.Location= new Point((int)( panelPaint.Size.Width*0.65),(int)(this.Height/4));;;
				tf.Show();tf.BringToFront();tf.TopMost=true;
				tf.pictureBox.Image = Image.FromFile  (strTempPath);
			}
		}

		private void comboPageType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(comboPageType.SelectedIndex==1)
			{
				bA5=true;
			}
			else
			{
				bA5=false;
			}
		}

		private void txtGroupedFixNumber_VisibleChanged(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox13_MouseEnter(object sender, System.EventArgs e)
		{
			pictureBox13.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"lightright.png");
			pictureBox13.Image=bmp;
		}

		private void pictureBox13_MouseLeave(object sender, System.EventArgs e)
		{
			pictureBox13.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"right.png");
			pictureBox13.Image=bmp;
		}

		private void pictureBox5_MouseEnter(object sender, System.EventArgs e)
		{
			pictureBox5.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"llighleft.png");
			pictureBox5.Image=bmp;
		}

		private void pictureBox5_MouseLeave(object sender, System.EventArgs e)
		{
			pictureBox5.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"left.png");
			pictureBox5.Image=bmp;
		}

		private void comboreadMethod_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void comboFormName_Click(object sender, System.EventArgs e)
		{
			if (bIsBusy)listFiles.Focus();
		}

		private void comboreadMethod_Click(object sender, System.EventArgs e)
		{
			if (bIsBusy)listFiles.Focus();;
		}

		private void statusBar_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
		
		}

		private void pictureBox16_MouseEnter(object sender, System.EventArgs e)
		{
			pictureBox16.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"a5361.png");
			pictureBox16.Image=bmp;
		}

		private void pictureBox16_MouseLeave(object sender, System.EventArgs e)
		{
			pictureBox16.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"a536.png");
			pictureBox16.Image=bmp;
		}

		private void groupUotputFormat_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void radioColInRecord_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox17_MouseEnter(object sender, System.EventArgs e)
		{
			pictureBox17.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"browse1.png");
			pictureBox17.Image=bmp;
		}

		private void pictureBox17_MouseLeave(object sender, System.EventArgs e)
		{
			pictureBox17.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"browse.png");
			pictureBox17.Image=bmp;
		}

		private void pictureBox18_MouseEnter(object sender, System.EventArgs e)
		{
			pictureBox18.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"save1.png");
			pictureBox18.Image=bmp;
		}

		private void pictureBox18_MouseLeave(object sender, System.EventArgs e)
		{
		pictureBox18.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"save.png");
			pictureBox18.Image=bmp;
		}

		private void pictureBox17_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog fb=new FolderBrowserDialog();
			if(fb.ShowDialog()==DialogResult.OK )
			{
				txtPath.Text=				fb.SelectedPath;
				FillOutPutListFiles(fb.SelectedPath);
			}
		}

		private void pictureBox16_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void pictureBox19_MouseEnter(object sender, System.EventArgs e)
		{
			pictureBox19.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"search1.png");
			pictureBox19.Image=bmp;
		}

		private void pictureBox19_MouseLeave(object sender, System.EventArgs e)
		{
			pictureBox19.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"search.png");
			pictureBox19.Image=bmp;
		}

		private void pictureBox19_Click(object sender, System.EventArgs e)
		{
			int index=0;
			DataTable table=dsResults.Tables[0];
			int count =table.Rows.Count;
			string strParam="";string []strArgs=txtSearchParam.Text.Split(' ');
			int len=strArgs.Length;
			for(int j=1;j<=len;j++)
				strParam+=strArgs[len-j];
			strParam=strParam.Replace(" ","");
			for(int i=0;i<count;i++)
			{
				if(table.Rows[i][1].ToString().Replace(" ","").IndexOf( strParam)!=-1)
				{
					index=i;
					break;
				}
			}
			if(dataGrid.VisibleRowCount > 0 )			
			dataGrid.NavigateTo(index,"");
		}

		private void lbl_Click(object sender, System.EventArgs e)
		{
		
		}

		private void picBackGround_Click(object sender, System.EventArgs e)
		{
		
		}

		private void dataGrid_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}


		private void comboFormType_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			nFormType=comboFormType.SelectedIndex;			
		}

		private void pictureBox6_Click(object sender, System.EventArgs e)
		{
			panelNonCounterDisplay.BringToFront();
			dgCounter.DataSource=dsTempResults.Tables[0];
		}

		private void dgCounter_CurrentCellChanged(object sender, System.EventArgs e)
		{
			int row=dgCounter.CurrentRowIndex;
			if(row < dsTempResults.Tables[0].Rows.Count )
			{
				if(dgCounter.CurrentCell.ColumnNumber ==0)
				{
					string strPath=dsTempResults.Tables[0].Rows[row][10].ToString();
					string strPath1=strPath;
					if(!System.IO.File.Exists (strPath ))
					{
						strPath1=strPath.Replace(".jpg",".val");
						if(!System.IO.File.Exists (strPath1))
						{
							strPath1=strPath.Replace(".jpg",".VAL");
							if(!System.IO.File.Exists (strPath1))
							{
								MessageBox.Show("چنين فايلي در اين كامپيوتر موجود نمي باشد");	
								return ;
							}

						}
					}
					if( bDisplayInPaiont)
					{
						
						System.Diagnostics.Process.Start("mspaint.exe","\""+strPath1+"\"");
					}
				
					if( bOrginalDispaly)
					{
						string strTempPath=System.IO.Path.GetTempFileName();
						File.Copy(strPath1,strTempPath,true);
					
						if(tf.bDisposed)tf=new TempForm();tf.filePath=strTempPath;
						tf.Location= new Point((int)( panelPaint.Size.Width*0.65),(int)(this.Height/4));;;
						tf.Show();
						tf.pictureBox.Image = Image.FromFile  (strTempPath);tf.BringToFront();tf.TopMost=true;tf.BringToFront();tf.TopMost=true;
					}
					
				}
			}
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			DeleteTempRows();
			bNoNumberIsOk=true;
			picNoNumbers.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"Ok.png");
			lblNoNumbers .ForeColor=Color.DarkOliveGreen;
			picNoNumbers.Image=bmp;
			if(bPerformaneIsOk)
			{
				bReachedResultsIsOk=true;
				picReachedResults.Image.Dispose();
				 bmp=new Bitmap(GetType(),"Ok.png");
				lblReachedResults.ForeColor=Color.DarkOliveGreen;
				picReachedResults.Image=bmp;
			}
			TablesStatus();
		}
		void DeleteTempRows()
		{
			conn.Open();
			command.CommandText="delete from TempResults";
			command.ExecuteNonQuery();
			conn.Close();
			dsTempResults.Tables["TempResults"].Rows.Clear();
			dgCounter.Refresh();
		}
		private void button9_Click(object sender, System.EventArgs e)
		{
			DataTable table=dsResults.Tables[0];
			DataRowCollection drc=table.Rows;
			int nCount=dsTempResults.Tables[0].Rows.Count;
			string str1="";
			strVar1Code="";
			for(int i = 0 ; i< nCount;i++)
			{
				DataRow drSource=dsTempResults.Tables[0].Rows[i];
				System.Data.DataRow dr=table.NewRow();
				strVar1Code="";
				dr[2]=drSource[2];
				dr[3]=drSource[3];		
				dr[4]=drSource[4];
				dr[5]=drSource[5];
				dr[6]=drSource [6];
				dr[7]=drSource [7];
				dr[8]=drSource[8];
				dr[9]=drSource[9];
				dr[10]=drSource[10];
				dr[11]=drSource[11];
				str1= (long.Parse(drSource[1].ToString().Replace(" ",""))).ToString(new string('0',9));
				str1+= (long.Parse(drSource[12].ToString().Replace(" ",""))).ToString(new string('0',9));
				strVar1Code+=str1.Substring(0,3)+" ";
				strVar1Code+=str1.Substring(3,3)+" ";strVar1Code+=str1.Substring(6,3)+" ";
				strVar1Code+=str1.Substring(9,3)+" ";strVar1Code+=str1.Substring(12,3)+" ";
				strVar1Code+=str1.Substring(15,3)+" ";
				dr[1]=strVar1Code;
				drc.Add(dr);
			}
			int x=daResults.Update( dsResults,"results");
			DeleteTempRows();
			bNoNumberIsOk=true;
			picNoNumbers.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"Ok.png");
			lblNoNumbers .ForeColor=Color.DarkOliveGreen;
			picNoNumbers.Image=bmp;
			if(bPerformaneIsOk)
			{
				bReachedResultsIsOk=true;
				picReachedResults.Image.Dispose();
				 bmp=new Bitmap(GetType(),"Ok.png");
				lblReachedResults.ForeColor=Color.DarkOliveGreen;
				picReachedResults.Image=bmp;
			}
			TablesStatus();
		}

		private void chkDisplayInPaint_CheckedChanged(object sender, System.EventArgs e)
		{
			bDisplayInPaiont=chkPaint2.Checked =chkDisplayInPaint.Checked;
		}

		private void chkDisplay_CheckedChanged(object sender, System.EventArgs e)
		{
			bOrginalDispaly=chkDisplay2.Checked =chkDisplay.Checked;
		}

		private void menuItem7_Click_2(object sender, System.EventArgs e)
		{
			if(listFiles.SelectedIndex>=0)
			{
				string file=listFiles.Items[listFiles.SelectedIndex].ToString();
				
				string filesPath=filesPaths[listFiles.SelectedIndex].ToString();//lblPath.Text+"\\"+file;
				int index=filesPath.LastIndexOf(".val");				
				index=(index==-1)?filesPath.LastIndexOf(".VAL"):index;
				index=(index==-1)?filesPath.LastIndexOf(".err"):index;
				index=(index==-1)?filesPath.LastIndexOf(".ERR"):index;
				if(index==-1)return;
				if(File.Exists (filesPath.Substring (0,index)+".jpg"))File.Delete(filesPath.Substring (0,index)+".jpg");
				File.Move(filesPath,filesPath.Substring (0,index)+".jpg");

			}
			FillListFiles(lblPath.Text);
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			if(listFiles.SelectedIndex>=0)
			{
				string file=listFiles.Items[listFiles.SelectedIndex].ToString();
				
				string filesPath=filesPaths[listFiles.SelectedIndex].ToString();//lblPath.Text+"\\"+file;
				int index=filesPath.LastIndexOf(".val");				
				index=(index==-1)?filesPath.LastIndexOf(".VAL"):index;
				index=(index==-1)?filesPath.LastIndexOf(".err"):index;
				index=(index==-1)?filesPath.LastIndexOf(".ERR"):index;
				/*if(index!=-1)
				{
					filesPath=		 filesPath.Substring (0,index)+".jpg";
				}*/
				 
				System.Diagnostics.Process.Start("mspaint.exe","\""+filesPath+"\"");
			}
		}

		private void dataGridErrList_CurrentCellChanged(object sender, System.EventArgs e)
		{
			int row=dataGridErrList.CurrentRowIndex;
			if(row < dsErrResult.Tables[0].Rows.Count )
			{
				if(dataGridErrList.CurrentCell.ColumnNumber ==0)
				{
					string strPath=dsErrResult.Tables[0].Rows[row][3].ToString();
					string strPath1=strPath;
					if(!System.IO.File.Exists (strPath ))
					{
						strPath1=strPath.Replace(".jpg",".err");
						if(!System.IO.File.Exists (strPath1))
						{
							strPath1=strPath.Replace(".jpg",".ERR");
							if(!System.IO.File.Exists (strPath1))
							{
								MessageBox.Show("چنين فايلي در اين كامپيوتر موجود نمي باشد");	
								return ;
							}

						}
					}
					if( bDisplayInPaiont)
					{
							
						System.Diagnostics.Process.Start("mspaint.exe","\""+strPath1+"\"");
					}
						
					if( bOrginalDispaly)
					{
						
						string strTempPath=System.IO.Path.GetTempFileName();
						File.Copy(strPath1,strTempPath,true);
						
						if(tf.bDisposed)tf=new TempForm();tf.filePath=strTempPath;
						tf.Location= new Point((int)( panelPaint.Size.Width*0.65),(int)(this.Height/4));;;
						tf.Show();tf.BringToFront();tf.TopMost=true;
						tf.pictureBox.Image = Image.FromFile  (strTempPath);
					}
				

				}
			}
		}

		private void trkCodeDarkPoints_Scroll(object sender, System.EventArgs e)
		{
		
			if (!bIsBusy)
				nCodeDarkPointThr = trkCodeDarkPoints.Value;
			lblCodeDarkPoints.Text=nCodeDarkPointThr.ToString();
		}

		private void picColInRecord_MouseEnter(object sender, System.EventArgs e)
		{
			if(bReachedResultsIsOk)
			{
				if(dsResults.Tables[0].Rows.Count>0)
				{
					
					picReachedResults.Image.Dispose();
					Bitmap bmp=new Bitmap(GetType(),"NotOk.png");
					picReachedResults.Image=bmp;
					lblReachedResults.ForeColor=Color.Red;
				}
			}
		}

		private void picColInRecord_MouseLeave(object sender, System.EventArgs e)
		{
			if(bReachedResultsIsOk)
			{
				if(dsResults.Tables[0].Rows.Count>0)
				{
					
					picReachedResults.Image.Dispose();
					Bitmap bmp=new Bitmap(GetType(),"Ok.png");
					picReachedResults.Image=bmp;
					
					lblReachedResults.ForeColor=Color.DarkOliveGreen;
				}
			}
		}

		private void chkSubFolders_CheckedChanged(object sender, System.EventArgs e)
		{
			bSubFolders=chkSubFolders.Checked;
		}

		private void chkPaint2_CheckedChanged(object sender, System.EventArgs e)
		{
			bDisplayInPaiont=chkDisplayInPaint.Checked =chkPaint2.Checked;
			
		}

		private void chkDisplay2_CheckedChanged(object sender, System.EventArgs e)
		{
			bOrginalDispaly=chkDisplay .Checked =chkDisplay2.Checked;
		}

		private void pictureBox7_MouseEnter(object sender, System.EventArgs e)
		{
			pictureBox7.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"ab copy.png");
			pictureBox7.Image=bmp;
		}

		private void pictureBox7_MouseLeave(object sender, System.EventArgs e)
		{
			pictureBox7.Image.Dispose();
			Bitmap bmp=new Bitmap(GetType(),"ab.png");
			pictureBox7.Image=bmp;
		}

		private void pictureBox7_Click(object sender, System.EventArgs e)
		{
			this.WindowState=FormWindowState.Minimized;
		}









		


	}
		
	
}


