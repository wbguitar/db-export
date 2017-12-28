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
	public class frmHelp : Form
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();

		private IContainer components;

		[AccessedThroughProperty("Help")]
		private Label _Help;

		internal virtual Label Help
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Help;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Help = value;
			}
		}

		[DebuggerNonUserCode]
		public frmHelp()
		{
			frmHelp.__ENCAddToList(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			List<WeakReference> _ENCList = frmHelp.__ENCList;
			checked
			{
				lock (_ENCList)
				{
					bool flag = frmHelp.__ENCList.Count == frmHelp.__ENCList.Capacity;
					if (flag)
					{
						int num = 0;
						int arg_3F_0 = 0;
						int num2 = frmHelp.__ENCList.Count - 1;
						int num3 = arg_3F_0;
						while (true)
						{
							int arg_90_0 = num3;
							int num4 = num2;
							if (arg_90_0 > num4)
							{
								break;
							}
							WeakReference weakReference = frmHelp.__ENCList[num3];
							flag = weakReference.IsAlive;
							if (flag)
							{
								bool flag2 = num3 != num;
								if (flag2)
								{
									frmHelp.__ENCList[num] = frmHelp.__ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						frmHelp.__ENCList.RemoveRange(num, frmHelp.__ENCList.Count - num);
						frmHelp.__ENCList.Capacity = frmHelp.__ENCList.Count;
					}
					frmHelp.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmHelp));
			this.Help = new Label();
			this.SuspendLayout();
			Control arg_36_0 = this.Help;
			Point location = new Point(5, 9);
			arg_36_0.Location = location;
			this.Help.Name = "Help";
			Control arg_67_0 = this.Help;
			Size size = new Size(399, 255);
			arg_67_0.Size = size;
			this.Help.TabIndex = 1;
			this.Help.Text = componentResourceManager.GetString("Help.Text");
			SizeF autoScaleDimensions = new SizeF(6f, 13f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = AutoScaleMode.Font;
			size = new Size(408, 273);
			this.ClientSize = size;
			this.Controls.Add(this.Help);
			this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			this.Name = "frmHelp";
			this.SizeGripStyle = SizeGripStyle.Hide;
			this.Text = "About";
			this.ResumeLayout(false);
		}
	}
}
