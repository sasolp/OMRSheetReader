using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BinaryFormReader
{
	/// <summary>
	/// Summary description for TempForm.
	/// </summary>
	public class TempForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.PictureBox pictureBox13;
		private System.Windows.Forms.PictureBox pictureBox12;
		private System.Windows.Forms.Label lblComment;
		private System.Windows.Forms.TextBox txtColQuestionNumber;
		private System.Windows.Forms.Label lblColQuestionNumber;
		private System.Windows.Forms.RadioButton radioTopDown;
		private System.Windows.Forms.RadioButton radioDownUp;
		private System.Windows.Forms.CheckBox checkSTEPlike;
		public System.Windows.Forms.PictureBox pictureBox;
		public string filePath;
		public bool bDisposed;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TempForm()
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
			bDisposed=true;
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TempForm));
			this.groupBox17 = new System.Windows.Forms.GroupBox();
			this.pictureBox13 = new System.Windows.Forms.PictureBox();
			this.pictureBox12 = new System.Windows.Forms.PictureBox();
			this.lblComment = new System.Windows.Forms.Label();
			this.txtColQuestionNumber = new System.Windows.Forms.TextBox();
			this.lblColQuestionNumber = new System.Windows.Forms.Label();
			this.radioTopDown = new System.Windows.Forms.RadioButton();
			this.radioDownUp = new System.Windows.Forms.RadioButton();
			this.checkSTEPlike = new System.Windows.Forms.CheckBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.groupBox17.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox17
			// 
			this.groupBox17.Controls.Add(this.pictureBox13);
			this.groupBox17.Controls.Add(this.pictureBox12);
			this.groupBox17.Controls.Add(this.lblComment);
			this.groupBox17.Controls.Add(this.txtColQuestionNumber);
			this.groupBox17.Controls.Add(this.lblColQuestionNumber);
			this.groupBox17.Controls.Add(this.radioTopDown);
			this.groupBox17.Controls.Add(this.radioDownUp);
			this.groupBox17.Location = new System.Drawing.Point(70, 48);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.groupBox17.Size = new System.Drawing.Size(152, 280);
			this.groupBox17.TabIndex = 21;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "    ‘ò· Å·ò«‰Ì";
			// 
			// pictureBox13
			// 
			this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
			this.pictureBox13.Location = new System.Drawing.Point(80, 80);
			this.pictureBox13.Name = "pictureBox13";
			this.pictureBox13.Size = new System.Drawing.Size(64, 72);
			this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox13.TabIndex = 17;
			this.pictureBox13.TabStop = false;
			// 
			// pictureBox12
			// 
			this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
			this.pictureBox12.Location = new System.Drawing.Point(80, 24);
			this.pictureBox12.Name = "pictureBox12";
			this.pictureBox12.Size = new System.Drawing.Size(64, 64);
			this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox12.TabIndex = 16;
			this.pictureBox12.TabStop = false;
			// 
			// lblComment
			// 
			this.lblComment.Enabled = false;
			this.lblComment.Location = new System.Drawing.Point(8, 216);
			this.lblComment.Name = "lblComment";
			this.lblComment.Size = new System.Drawing.Size(136, 56);
			this.lblComment.TabIndex = 15;
			this.lblComment.Text = "·ÿ›« ⁄œ«œ ”Ê«·«  Â— ” Ê‰ —« œ— ò«œ— „ ‰Ì ›Êﬁ »Ê”Ì·Â Œÿ ›«’·Â(-)  «“ Â„ Ãœ« ‰„«ÌÌœ" +
				".";
			// 
			// txtColQuestionNumber
			// 
			this.txtColQuestionNumber.Enabled = false;
			this.txtColQuestionNumber.Location = new System.Drawing.Point(8, 184);
			this.txtColQuestionNumber.Name = "txtColQuestionNumber";
			this.txtColQuestionNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtColQuestionNumber.Size = new System.Drawing.Size(136, 20);
			this.txtColQuestionNumber.TabIndex = 14;
			this.txtColQuestionNumber.Text = "00";
			// 
			// lblColQuestionNumber
			// 
			this.lblColQuestionNumber.Enabled = false;
			this.lblColQuestionNumber.Location = new System.Drawing.Point(48, 160);
			this.lblColQuestionNumber.Name = "lblColQuestionNumber";
			this.lblColQuestionNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblColQuestionNumber.Size = new System.Drawing.Size(96, 16);
			this.lblColQuestionNumber.TabIndex = 13;
			this.lblColQuestionNumber.Text = " ⁄œ«œ ”Ê«·«  Â— ” Ê‰ :";
			this.lblColQuestionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// radioTopDown
			// 
			this.radioTopDown.Checked = true;
			this.radioTopDown.Enabled = false;
			this.radioTopDown.Location = new System.Drawing.Point(8, 48);
			this.radioTopDown.Name = "radioTopDown";
			this.radioTopDown.Size = new System.Drawing.Size(64, 16);
			this.radioTopDown.TabIndex = 0;
			this.radioTopDown.TabStop = true;
			this.radioTopDown.Text = "»«·« »Â Å«ÌÌ‰";
			// 
			// radioDownUp
			// 
			this.radioDownUp.Enabled = false;
			this.radioDownUp.Location = new System.Drawing.Point(8, 112);
			this.radioDownUp.Name = "radioDownUp";
			this.radioDownUp.Size = new System.Drawing.Size(64, 24);
			this.radioDownUp.TabIndex = 0;
			this.radioDownUp.Text = "Å«ÌÌ‰ »Â »«·«";
			// 
			// checkSTEPlike
			// 
			this.checkSTEPlike.Location = new System.Drawing.Point(208, 48);
			this.checkSTEPlike.Name = "checkSTEPlike";
			this.checkSTEPlike.Size = new System.Drawing.Size(16, 16);
			this.checkSTEPlike.TabIndex = 22;
			// 
			// pictureBox
			// 
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(416, 496);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 23;
			this.pictureBox.TabStop = false;
			// 
			// TempForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 496);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.checkSTEPlike);
			this.Controls.Add(this.groupBox17);
			this.Name = "TempForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "‰„«Ì‘  ’ÊÌ—";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.TempForm_Closing);
			this.Load += new System.EventHandler(this.load);
			this.groupBox17.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		private void load (object sender, System.EventArgs e)
		{
			this.BringToFront();
			bDisposed=false;
		}
		private void axPreview1_OnPreviewReady(object sender, System.EventArgs e)
		{
		
		}

		private void TempForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}


	}
}
