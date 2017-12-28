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
	public class frmCpuProp : Form
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();

		private IContainer components;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("tbxCpuName")]
		private TextBox _tbxCpuName;

		[AccessedThroughProperty("tbxIp4")]
		private TextBox _tbxIp4;

		[AccessedThroughProperty("tbxIp3")]
		private TextBox _tbxIp3;

		[AccessedThroughProperty("tbxIp2")]
		private TextBox _tbxIp2;

		[AccessedThroughProperty("tbxIp1")]
		private TextBox _tbxIp1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		[AccessedThroughProperty("tbxRack")]
		private TextBox _tbxRack;

		[AccessedThroughProperty("tbxSlot")]
		private TextBox _tbxSlot;

		[AccessedThroughProperty("btnCancel")]
		private Button _btnCancel;

		[AccessedThroughProperty("btnOk")]
		private Button _btnOk;

		[AccessedThroughProperty("lblWrn")]
		private Label _lblWrn;

		private clsBlockCont myCpu;

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

		internal virtual TextBox tbxCpuName
		{
			[DebuggerNonUserCode]
			get
			{
				return this._tbxCpuName;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._tbxCpuName = value;
			}
		}

		internal virtual TextBox tbxIp4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._tbxIp4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.tbx_KeyPress);
				EventHandler value3 = new EventHandler(this.tbxIp1_Validated);
				bool flag = this._tbxIp4 != null;
				if (flag)
				{
					this._tbxIp4.KeyPress -= value2;
					this._tbxIp4.Validated -= value3;
				}
				this._tbxIp4 = value;
				flag = (this._tbxIp4 != null);
				if (flag)
				{
					this._tbxIp4.KeyPress += value2;
					this._tbxIp4.Validated += value3;
				}
			}
		}

		internal virtual TextBox tbxIp3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._tbxIp3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.tbx_KeyPress);
				EventHandler value3 = new EventHandler(this.tbxIp1_Validated);
				bool flag = this._tbxIp3 != null;
				if (flag)
				{
					this._tbxIp3.KeyPress -= value2;
					this._tbxIp3.Validated -= value3;
				}
				this._tbxIp3 = value;
				flag = (this._tbxIp3 != null);
				if (flag)
				{
					this._tbxIp3.KeyPress += value2;
					this._tbxIp3.Validated += value3;
				}
			}
		}

		internal virtual TextBox tbxIp2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._tbxIp2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.tbx_KeyPress);
				EventHandler value3 = new EventHandler(this.tbxIp1_Validated);
				bool flag = this._tbxIp2 != null;
				if (flag)
				{
					this._tbxIp2.KeyPress -= value2;
					this._tbxIp2.Validated -= value3;
				}
				this._tbxIp2 = value;
				flag = (this._tbxIp2 != null);
				if (flag)
				{
					this._tbxIp2.KeyPress += value2;
					this._tbxIp2.Validated += value3;
				}
			}
		}

		internal virtual TextBox tbxIp1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._tbxIp1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.tbx_KeyPress);
				EventHandler value3 = new EventHandler(this.tbxIp1_Validated);
				bool flag = this._tbxIp1 != null;
				if (flag)
				{
					this._tbxIp1.KeyPress -= value2;
					this._tbxIp1.Validated -= value3;
				}
				this._tbxIp1 = value;
				flag = (this._tbxIp1 != null);
				if (flag)
				{
					this._tbxIp1.KeyPress += value2;
					this._tbxIp1.Validated += value3;
				}
			}
		}

		internal virtual Label Label2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label2 = value;
			}
		}

		internal virtual Label Label4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label4 = value;
			}
		}

		internal virtual Label Label5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label5 = value;
			}
		}

		internal virtual Label Label3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label3 = value;
			}
		}

		internal virtual Label Label6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label6 = value;
			}
		}

		internal virtual Label Label7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label7 = value;
			}
		}

		internal virtual TextBox tbxRack
		{
			[DebuggerNonUserCode]
			get
			{
				return this._tbxRack;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.tbx_KeyPress);
				EventHandler value3 = new EventHandler(this.tbxIp1_Validated);
				bool flag = this._tbxRack != null;
				if (flag)
				{
					this._tbxRack.KeyPress -= value2;
					this._tbxRack.Validated -= value3;
				}
				this._tbxRack = value;
				flag = (this._tbxRack != null);
				if (flag)
				{
					this._tbxRack.KeyPress += value2;
					this._tbxRack.Validated += value3;
				}
			}
		}

		internal virtual TextBox tbxSlot
		{
			[DebuggerNonUserCode]
			get
			{
				return this._tbxSlot;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.tbx_KeyPress);
				EventHandler value3 = new EventHandler(this.tbxIp1_Validated);
				bool flag = this._tbxSlot != null;
				if (flag)
				{
					this._tbxSlot.KeyPress -= value2;
					this._tbxSlot.Validated -= value3;
				}
				this._tbxSlot = value;
				flag = (this._tbxSlot != null);
				if (flag)
				{
					this._tbxSlot.KeyPress += value2;
					this._tbxSlot.Validated += value3;
				}
			}
		}

		internal virtual Button btnCancel
		{
			[DebuggerNonUserCode]
			get
			{
				return this._btnCancel;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.btnCancel_Click);
				bool flag = this._btnCancel != null;
				if (flag)
				{
					this._btnCancel.Click -= value2;
				}
				this._btnCancel = value;
				flag = (this._btnCancel != null);
				if (flag)
				{
					this._btnCancel.Click += value2;
				}
			}
		}

		internal virtual Button btnOk
		{
			[DebuggerNonUserCode]
			get
			{
				return this._btnOk;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.btnOk_Click);
				bool flag = this._btnOk != null;
				if (flag)
				{
					this._btnOk.Click -= value2;
				}
				this._btnOk = value;
				flag = (this._btnOk != null);
				if (flag)
				{
					this._btnOk.Click += value2;
				}
			}
		}

		internal virtual Label lblWrn
		{
			[DebuggerNonUserCode]
			get
			{
				return this._lblWrn;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._lblWrn = value;
			}
		}

		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = frmCpuProp.__ENCList;
			checked
			{
				lock (_ENCList)
				{
					bool flag = frmCpuProp.__ENCList.Count == frmCpuProp.__ENCList.Capacity;
					if (flag)
					{
						int num = 0;
						int arg_3F_0 = 0;
						int num2 = frmCpuProp.__ENCList.Count - 1;
						int num3 = arg_3F_0;
						while (true)
						{
							int arg_90_0 = num3;
							int num4 = num2;
							if (arg_90_0 > num4)
							{
								break;
							}
							WeakReference weakReference = frmCpuProp.__ENCList[num3];
							flag = weakReference.IsAlive;
							if (flag)
							{
								bool flag2 = num3 != num;
								if (flag2)
								{
									frmCpuProp.__ENCList[num] = frmCpuProp.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						frmCpuProp.__ENCList.RemoveRange(num, frmCpuProp.__ENCList.Count - num);
						frmCpuProp.__ENCList.Capacity = frmCpuProp.__ENCList.Count;
					}
					frmCpuProp.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
			this.Label1 = new Label();
			this.tbxCpuName = new TextBox();
			this.tbxIp4 = new TextBox();
			this.tbxIp3 = new TextBox();
			this.tbxIp2 = new TextBox();
			this.tbxIp1 = new TextBox();
			this.Label2 = new Label();
			this.Label4 = new Label();
			this.Label5 = new Label();
			this.Label3 = new Label();
			this.Label6 = new Label();
			this.Label7 = new Label();
			this.tbxRack = new TextBox();
			this.tbxSlot = new TextBox();
			this.btnCancel = new Button();
			this.btnOk = new Button();
			this.lblWrn = new Label();
			this.SuspendLayout();
			this.Label1.AutoSize = true;
			Control arg_F4_0 = this.Label1;
			Point location = new Point(17, 17);
			arg_F4_0.Location = location;
			this.Label1.Name = "Label1";
			Control arg_11E_0 = this.Label1;
			Size size = new Size(58, 13);
			arg_11E_0.Size = size;
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Cpu name:";
			Control arg_155_0 = this.tbxCpuName;
			location = new Point(83, 13);
			arg_155_0.Location = location;
			this.tbxCpuName.Name = "tbxCpuName";
			Control arg_17F_0 = this.tbxCpuName;
			size = new Size(126, 20);
			arg_17F_0.Size = size;
			this.tbxCpuName.TabIndex = 1;
			Control arg_1A8_0 = this.tbxIp4;
			location = new Point(182, 48);
			arg_1A8_0.Location = location;
			this.tbxIp4.Name = "tbxIp4";
			Control arg_1D2_0 = this.tbxIp4;
			size = new Size(27, 20);
			arg_1D2_0.Size = size;
			this.tbxIp4.TabIndex = 2;
			this.tbxIp4.Text = "123";
			Control arg_20C_0 = this.tbxIp3;
			location = new Point(149, 48);
			arg_20C_0.Location = location;
			this.tbxIp3.Name = "tbxIp3";
			Control arg_236_0 = this.tbxIp3;
			size = new Size(27, 20);
			arg_236_0.Size = size;
			this.tbxIp3.TabIndex = 3;
			this.tbxIp3.Text = "123";
			Control arg_26D_0 = this.tbxIp2;
			location = new Point(116, 48);
			arg_26D_0.Location = location;
			this.tbxIp2.Name = "tbxIp2";
			Control arg_297_0 = this.tbxIp2;
			size = new Size(27, 20);
			arg_297_0.Size = size;
			this.tbxIp2.TabIndex = 4;
			this.tbxIp2.Text = "123";
			Control arg_2CE_0 = this.tbxIp1;
			location = new Point(83, 48);
			arg_2CE_0.Location = location;
			this.tbxIp1.Name = "tbxIp1";
			Control arg_2F8_0 = this.tbxIp1;
			size = new Size(27, 20);
			arg_2F8_0.Size = size;
			this.tbxIp1.TabIndex = 5;
			this.tbxIp1.Text = "123";
			this.Label2.AutoSize = true;
			this.Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			Control arg_35A_0 = this.Label2;
			location = new Point(108, 52);
			arg_35A_0.Location = location;
			this.Label2.Name = "Label2";
			Control arg_384_0 = this.Label2;
			size = new Size(11, 13);
			arg_384_0.Size = size;
			this.Label2.TabIndex = 6;
			this.Label2.Text = ".";
			this.Label4.AutoSize = true;
			this.Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			Control arg_3E9_0 = this.Label4;
			location = new Point(141, 52);
			arg_3E9_0.Location = location;
			this.Label4.Name = "Label4";
			Control arg_413_0 = this.Label4;
			size = new Size(11, 13);
			arg_413_0.Size = size;
			this.Label4.TabIndex = 8;
			this.Label4.Text = ".";
			this.Label5.AutoSize = true;
			this.Label5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			Control arg_478_0 = this.Label5;
			location = new Point(174, 52);
			arg_478_0.Location = location;
			this.Label5.Name = "Label5";
			Control arg_4A2_0 = this.Label5;
			size = new Size(11, 13);
			arg_4A2_0.Size = size;
			this.Label5.TabIndex = 9;
			this.Label5.Text = ".";
			this.Label3.AutoSize = true;
			Control arg_4E7_0 = this.Label3;
			location = new Point(15, 52);
			arg_4E7_0.Location = location;
			this.Label3.Name = "Label3";
			Control arg_511_0 = this.Label3;
			size = new Size(60, 13);
			arg_511_0.Size = size;
			this.Label3.TabIndex = 10;
			this.Label3.Text = "IP address:";
			this.Label6.AutoSize = true;
			Control arg_556_0 = this.Label6;
			location = new Point(39, 82);
			arg_556_0.Location = location;
			this.Label6.Name = "Label6";
			Control arg_580_0 = this.Label6;
			size = new Size(36, 13);
			arg_580_0.Size = size;
			this.Label6.TabIndex = 11;
			this.Label6.Text = "Rack:";
			this.Label7.AutoSize = true;
			Control arg_5C8_0 = this.Label7;
			location = new Point(145, 82);
			arg_5C8_0.Location = location;
			this.Label7.Name = "Label7";
			Control arg_5F2_0 = this.Label7;
			size = new Size(28, 13);
			arg_5F2_0.Size = size;
			this.Label7.TabIndex = 12;
			this.Label7.Text = "Slot:";
			Control arg_62A_0 = this.tbxRack;
			location = new Point(83, 79);
			arg_62A_0.Location = location;
			this.tbxRack.Name = "tbxRack";
			Control arg_654_0 = this.tbxRack;
			size = new Size(27, 20);
			arg_654_0.Size = size;
			this.tbxRack.TabIndex = 13;
			this.tbxRack.Text = "123";
			Control arg_68F_0 = this.tbxSlot;
			location = new Point(182, 79);
			arg_68F_0.Location = location;
			this.tbxSlot.Name = "tbxSlot";
			Control arg_6B9_0 = this.tbxSlot;
			size = new Size(27, 20);
			arg_6B9_0.Size = size;
			this.tbxSlot.TabIndex = 14;
			this.tbxSlot.Text = "123";
			Control arg_6F4_0 = this.btnCancel;
			location = new Point(135, 112);
			arg_6F4_0.Location = location;
			this.btnCancel.Name = "btnCancel";
			Control arg_71E_0 = this.btnCancel;
			size = new Size(75, 20);
			arg_71E_0.Size = size;
			this.btnCancel.TabIndex = 16;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			Control arg_763_0 = this.btnOk;
			location = new Point(44, 112);
			arg_763_0.Location = location;
			this.btnOk.Name = "btnOk";
			Control arg_78D_0 = this.btnOk;
			size = new Size(75, 20);
			arg_78D_0.Size = size;
			this.btnOk.TabIndex = 15;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.lblWrn.AutoSize = true;
			this.lblWrn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblWrn.ForeColor = Color.Red;
			Control arg_80E_0 = this.lblWrn;
			location = new Point(75, 36);
			arg_80E_0.Location = location;
			this.lblWrn.Name = "lblWrn";
			Control arg_83B_0 = this.lblWrn;
			size = new Size(141, 13);
			arg_83B_0.Size = size;
			this.lblWrn.TabIndex = 17;
			this.lblWrn.Text = "CPU name alreday exist";
			SizeF autoScaleDimensions = new SizeF(6f, 13f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = AutoScaleMode.Font;
			size = new Size(224, 139);
			this.ClientSize = size;
			this.Controls.Add(this.lblWrn);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tbxSlot);
			this.Controls.Add(this.tbxRack);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.tbxIp1);
			this.Controls.Add(this.tbxIp2);
			this.Controls.Add(this.tbxIp3);
			this.Controls.Add(this.tbxIp4);
			this.Controls.Add(this.tbxCpuName);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label2);
			this.Name = "frmCpuProp";
			this.Text = "CPU properties";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		public frmCpuProp(ref clsBlockCont Cpu)
		{
			base.Load += new EventHandler(this.frmCpuProp_Load);
			frmCpuProp.__ENCAddToList(this);
			this.InitializeComponent();
			this.myCpu = Cpu;
		}

		private void tbx_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == '\r';
			if (flag)
			{
				this.btnOk.Enabled = true;
				this.btnOk.Focus();
			}
		}

		private void frmCpuProp_Load(object sender, EventArgs e)
		{
			string[] array = new string[6];
			this.tbxCpuName.Text = this.myCpu.Name;
			array = this.myCpu.IPAddress.Split(new char[]
			{
				'.'
			});
			this.tbxIp1.Text = array[0];
			this.tbxIp2.Text = array[1];
			this.tbxIp3.Text = array[2];
			this.tbxIp4.Text = array[3];
			this.tbxRack.Text = Conversions.ToString(this.myCpu.Rack);
			this.tbxSlot.Text = Conversions.ToString(this.myCpu.Slot);
			this.lblWrn.Visible = false;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.myCpu.Name = this.tbxCpuName.Text;
			this.myCpu.IPAddress = string.Concat(new string[]
			{
				this.tbxIp1.Text,
				".",
				this.tbxIp2.Text,
				".",
				this.tbxIp3.Text,
				".",
				this.tbxIp4.Text
			});
			this.myCpu.Rack = Conversions.ToInteger(this.tbxRack.Text);
			this.myCpu.Slot = Conversions.ToInteger(this.tbxSlot.Text);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
			this.DialogResult = DialogResult.Cancel;
		}

		private void tbxIp1_Validated(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			bool flag = !Versioned.IsNumeric(textBox.Text);
			if (flag)
			{
				textBox.ForeColor = Color.Red;
				textBox.Focus();
				this.btnOk.Enabled = false;
			}
			else
			{
				textBox.ForeColor = Color.Black;
				this.btnOk.Enabled = true;
			}
		}
	}
}
