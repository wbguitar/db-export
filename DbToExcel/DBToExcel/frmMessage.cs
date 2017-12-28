using DBToExcel.My;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DBToExcel
{
	[DesignerGenerated]
	public class frmMessage : Form
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();

		private IContainer components;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("LinkLabel1")]
		private LinkLabel _LinkLabel1;

		[AccessedThroughProperty("btnOK")]
		private Button _btnOK;

		internal virtual Label Label1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label1 = value;
			}
		}

		internal virtual LinkLabel LinkLabel1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._LinkLabel1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				LinkLabelLinkClickedEventHandler value2 = new LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
				MouseEventHandler value3 = new MouseEventHandler(this.LinkLabel1_MouseClick);
				bool flag = this._LinkLabel1 != null;
				if (flag)
				{
					this._LinkLabel1.LinkClicked -= value2;
					this._LinkLabel1.MouseClick -= value3;
				}
				this._LinkLabel1 = value;
				flag = (this._LinkLabel1 != null);
				if (flag)
				{
					this._LinkLabel1.LinkClicked += value2;
					this._LinkLabel1.MouseClick += value3;
				}
			}
		}

		internal virtual Button btnOK
		{
			[DebuggerNonUserCode]
			get
			{
				return this._btnOK;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.btnOK_Click);
				bool flag = this._btnOK != null;
				if (flag)
				{
					this._btnOK.Click -= value2;
				}
				this._btnOK = value;
				flag = (this._btnOK != null);
				if (flag)
				{
					this._btnOK.Click += value2;
				}
			}
		}

		[DebuggerNonUserCode]
		public frmMessage()
		{
			base.Load += new EventHandler(this.frmMessage_Load);
			frmMessage.__ENCAddToList(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = frmMessage.__ENCList;
			checked
			{
				lock (_ENCList)
				{
					bool flag = frmMessage.__ENCList.Count == frmMessage.__ENCList.Capacity;
					if (flag)
					{
						int num = 0;
						int arg_3F_0 = 0;
						int num2 = frmMessage.__ENCList.Count - 1;
						int num3 = arg_3F_0;
						while (true)
						{
							int arg_90_0 = num3;
							int num4 = num2;
							if (arg_90_0 > num4)
							{
								break;
							}
							WeakReference weakReference = frmMessage.__ENCList[num3];
							flag = weakReference.IsAlive;
							if (flag)
							{
								bool flag2 = num3 != num;
								if (flag2)
								{
									frmMessage.__ENCList[num] = frmMessage.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						frmMessage.__ENCList.RemoveRange(num, frmMessage.__ENCList.Count - num);
						frmMessage.__ENCList.Capacity = frmMessage.__ENCList.Count;
					}
					frmMessage.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
				}
			}
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMessage));
			this.Label1 = new Label();
			this.LinkLabel1 = new LinkLabel();
			this.btnOK = new Button();
			this.SuspendLayout();
			this.Label1.AutoSize = true;
			Control arg_5C_0 = this.Label1;
			Point location = new Point(12, 9);
			arg_5C_0.Location = location;
			this.Label1.Name = "Label1";
			Control arg_87_0 = this.Label1;
			Size size = new Size(104, 13);
			arg_87_0.Size = size;
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Your file is saved as ";
			this.LinkLabel1.AutoSize = true;
			Control arg_CB_0 = this.LinkLabel1;
			location = new Point(12, 31);
			arg_CB_0.Location = location;
			this.LinkLabel1.Name = "LinkLabel1";
			Control arg_F6_0 = this.LinkLabel1;
			size = new Size(59, 13);
			arg_F6_0.Size = size;
			this.LinkLabel1.TabIndex = 1;
			this.LinkLabel1.TabStop = true;
			this.LinkLabel1.Text = "LinkLabel1";
			Control arg_13A_0 = this.btnOK;
			location = new Point(102, 101);
			arg_13A_0.Location = location;
			this.btnOK.Name = "btnOK";
			Control arg_165_0 = this.btnOK;
			size = new Size(75, 23);
			arg_165_0.Size = size;
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			SizeF autoScaleDimensions = new SizeF(6f, 13f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = AutoScaleMode.Font;
			size = new Size(267, 135);
			this.ClientSize = size;
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.LinkLabel1);
			this.Controls.Add(this.Label1);
			this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			size = new Size(283, 173);
			this.MaximumSize = size;
			size = new Size(283, 173);
			this.MinimumSize = size;
			this.Name = "frmMessage";
			this.Text = "Congratulation";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void frmMessage_Load(object sender, EventArgs e)
		{
			this.LinkLabel1.Text = MyProject.Forms.frmMain.filename;
			bool flag = this.LinkLabel1.Text.Length > 40;
			if (flag)
			{
				this.LinkLabel1.Text = this.LinkLabel1.Text.Insert(40, "\r\n");
			}
			flag = (this.LinkLabel1.Text.Length > 80);
			if (flag)
			{
				this.LinkLabel1.Text = this.LinkLabel1.Text.Insert(80, "\r\n");
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void LinkLabel1_MouseClick(object sender, MouseEventArgs e)
		{
			Process.Start(MyProject.Forms.frmMain.filename);
			this.Close();
		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Close();
		}
	}
}
