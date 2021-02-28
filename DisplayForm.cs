using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BinaryFormReader
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class DisplayForm : System.Windows.Forms.Form
	{
		public bool bShow;
		
		public bool bTrue;
		public OrginalForm  frmPaernt;
		private string strPrevPicPath;
		private string strCurrentPicPath;
		private System.Windows.Forms.Label lblComment;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox PrevPic;
		private System.Windows.Forms.PictureBox CurrentPic;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DisplayForm()
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
			this.lblComment = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.PrevPic = new System.Windows.Forms.PictureBox();
			this.CurrentPic = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblComment
			// 
			this.lblComment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.lblComment.Location = new System.Drawing.Point(624, 8);
			this.lblComment.Name = "lblComment";
			this.lblComment.Size = new System.Drawing.Size(384, 32);
			this.lblComment.TabIndex = 6;
			this.lblComment.Text = "·ÿ›« ÃÂ   «ÌÌœ  »—êÂ ﬁ»·Ì —ÊÌ œò„Â  «ÌÌœ ò·Ìò Ê œ— €Ì— «Ì‰ ’Ê—  ÃÂ   «ÌÌœ »—êÂ Ãœ" +
				"Ìœ —ÊÌ œò„Â Œÿ« ò·Ìò ‰„«ÌÌœ";
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.button4.Location = new System.Drawing.Point(368, 8);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 24);
			this.button4.TabIndex = 7;
			this.button4.Text = " «ÌÌœ";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.button1.Location = new System.Drawing.Point(520, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 24);
			this.button1.TabIndex = 8;
			this.button1.Text = "Œÿ«";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// PrevPic
			// 
			this.PrevPic.Location = new System.Drawing.Point(0, 56);
			this.PrevPic.Name = "PrevPic";
			this.PrevPic.Size = new System.Drawing.Size(496, 488);
			this.PrevPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PrevPic.TabIndex = 9;
			this.PrevPic.TabStop = false;
			// 
			// CurrentPic
			// 
			this.CurrentPic.Location = new System.Drawing.Point(504, 56);
			this.CurrentPic.Name = "CurrentPic";
			this.CurrentPic.Size = new System.Drawing.Size(496, 488);
			this.CurrentPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CurrentPic.TabIndex = 10;
			this.CurrentPic.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.label1.Location = new System.Drawing.Point(192, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 11;
			this.label1.Text = "»—êÂ ﬁ»·Ì";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.label2.Location = new System.Drawing.Point(712, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = "»—êÂ Ã«—Ì(ÃœÌœ)";
			// 
			// DisplayForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.ClientSize = new System.Drawing.Size(670, 399);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CurrentPic);
			this.Controls.Add(this.PrevPic);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.lblComment);
			this.Name = "DisplayForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "‰„«Ì‘ ›—„ ﬁ»·Ì";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayForm_MouseDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.DisplayForm_Closing);
			this.Load += new System.EventHandler(this.DisplayForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayForm_Paint);
			this.BackgroundImageChanged += new System.EventHandler(this.DisplayForm_BackgroundImageChanged);
			this.ResumeLayout(false);

		}
		#endregion

		public bool SetPicPaths(string strPrevPicPath ,string strCurrentPicPath )
		{
			string strPath1=strPrevPicPath;
			if(!System.IO.File.Exists (strPrevPicPath))
			{
				strPath1=strPrevPicPath.Replace(".val",".jpg");
				if(!System.IO.File.Exists (strPath1))
				{
					return false;

				}
			}
			
			string strPath2=strCurrentPicPath.Replace(".val",".jpg");
			string strTempPath1=System.IO.Path.GetTempFileName();
			string strTempPath2=System.IO.Path.GetTempFileName();
			System.IO.File.Copy(strPath1,strTempPath1,true);
			System.IO.File.Copy(strPath2,strTempPath2,true);
			PrevPic.Image = Image.FromFile(strTempPath1);			
			CurrentPic.Image = Image.FromFile(strTempPath2);
			return true;
		}

		private void DisplayForm_Load(object sender, System.EventArgs e)
		{
			
		}
		
		private void DisplayForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(!bShow){Hide();return;}
			PrevPic.Height=Height-100;
			CurrentPic.Height=Height-100;
			//CreateComponents();
			
		}
		
		private void DisplayForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
		}
		
		bool bSelect;
		private void button4_Click(object sender, System.EventArgs e)
		{
			bTrue=true;
			bSelect=true;
			Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			bTrue=false;
			bSelect=true;
			Close();
		}

		private void DisplayForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(!bSelect )
			if(MessageBox.Show("¬Ì« «Ì‰ »—êÂ —« «ÌÌœ „Ì ‰„«ÌÌœø","",MessageBoxButtons.YesNo)==DialogResult.Yes )
			{		
				bTrue=true;
			}
			else
			{
				bTrue=false;
			}
		}

		private void DisplayForm_BackgroundImageChanged(object sender, System.EventArgs e)
		{
		
		}
	
	}
}
