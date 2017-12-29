using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data.OleDb;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace DBToExcel
{
	public class clsDb: IComment
	{
		public struct Group
		{
			public int StartRow;

			public int EndRow;
		}

		private bool myReadDone;

		private int Level;

		private int myId;

		private int myNumber;

		private string mySymbol;

		private string mySymbolComment;

		private string MyAuthor;

		private string myFamily;

		private string myName;

		private string myComment;

		private string myDirectory;

		private string myVersion;

		private Collection myTags;

		private int myLength;

		public bool ReadDone
		{
			get
			{
				return this.myReadDone;
			}
			set
			{
				this.myReadDone = value;
			}
		}

		public int Id
		{
			get
			{
				return this.myId;
			}
		}

		public int Number
		{
			get
			{
				return this.myNumber;
			}
		}

		public string Symbol
		{
			get
			{
				return this.mySymbol;
			}
			set
			{
				this.mySymbol = value;
			}
		}

		public string SymbolComment
		{
			get
			{
				return this.mySymbolComment;
			}
			set
			{
				this.mySymbolComment = value;
			}
		}

		public string Author
		{
			get
			{
				return this.MyAuthor;
			}
		}

		public string Family
		{
			get
			{
				return this.myFamily;
			}
		}

		public string Name
		{
			get
			{
				return this.myName;
			}
		}

		public string Comment
		{
			get
			{
				return this.myComment;
			}
			set
			{
				this.myComment = value;
			}
		}

		public string Directory
		{
			get
			{
				return this.myDirectory;
			}
		}

		public string Version
		{
			get
			{
				return this.myVersion;
			}
		}

		public Collection Tags
		{
			get
			{
				return this.myTags;
			}
		}

		public int NumberOfTags
		{
			get
			{
				int num = 0;
				checked
				{
				    IEnumerator enumerator = this.Tags.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							clsTag clsTag = (clsTag)enumerator.Current;
							num += clsTag.NumberOfTags;
						}
					}
					finally
					{
						bool flag = enumerator is IDisposable;
						if (flag)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					return num;
				}
			}
		}

		public int Length
		{
			get
			{
				return this.myLength;
			}
			set
			{
				this.myLength = value;
			}
		}

		public clsDb(OleDbDataReader dr, object Comment, string Dir)
		{
			this.myTags = new Collection();
			this.myId = Conversions.ToInteger(dr["OBJECTID"]);
			this.myNumber = Conversions.ToInteger(dr["BLKNUMBER"]);
			bool flag = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dr["MC5LEN"]));
			bool flag2;
			if (flag)
			{
				flag2 = Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dr["MC5LEN"]));
				if (flag2)
				{
					this.myLength = Conversions.ToInteger(dr["MC5LEN"]);
				}
			}
			flag2 = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dr["BLOCKNAME"]));
			if (flag2)
			{
				this.myName = Conversions.ToString(dr["BLOCKNAME"]);
			}
			flag2 = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dr["BLOCKFNAME"]));
			if (flag2)
			{
				this.myFamily = Conversions.ToString(dr["BLOCKFNAME"]);
			}
			flag2 = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dr["USERNAME"]));
			if (flag2)
			{
				this.MyAuthor = Conversions.ToString(dr["USERNAME"]);
			}
			flag2 = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(Comment));
			if (flag2)
			{
				Encoding @default = Encoding.Default;
				object arg_174_0 = @default;
				Type arg_174_1 = null;
				string arg_174_2 = "GetBytes";
				object[] array = new object[]
				{
					RuntimeHelpers.GetObjectValue(Comment)
				};
				object[] arg_174_3 = array;
				string[] arg_174_4 = null;
				Type[] arg_174_5 = null;
				bool[] array2 = new bool[]
				{
					true
				};
				object arg_189_0 = NewLateBinding.LateGet(arg_174_0, arg_174_1, arg_174_2, arg_174_3, arg_174_4, arg_174_5, array2);
				if (array2[0])
				{
					Comment = RuntimeHelpers.GetObjectValue(array[0]);
				}
				byte[] array3 = (byte[])arg_189_0;
				this.myComment = @default.GetString(array3, 3, checked(array3.GetLength(0) - 4));
				this.myDirectory = Dir;
			}
			this.myVersion = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(Conversions.ToInteger(Operators.SubtractObject(Operators.DivideObject(dr["VERSION"], 16), 0.499))) + ".", Operators.ModObject(dr["VERSION"], 8)));
			this.myReadDone = false;
		}

		public clsDb(int iNumber, string sComment, string sAuthor, string sFamily, string sName, string sVersion)
		{
			this.myTags = new Collection();
			this.myId = 1;
			this.myNumber = iNumber;
			this.myComment = sComment;
			this.MyAuthor = sAuthor;
			this.myFamily = sFamily;
			this.myName = sName;
			this.myVersion = sVersion;
			this.myLength = 0;
			this.myDirectory = "";
			this.myReadDone = false;
		}

		public override string ToString()
		{
			string text = "DB" + Conversions.ToString(this.myNumber);
			text = text.PadRight(9);
			return text + this.mySymbol;
		}

		public string GetToolTip()
		{
			return string.Concat(new string[]
			{
				"DB",
				Conversions.ToString(this.myNumber),
				"\r\nSymbol: ",
				this.mySymbol,
				"\r\nSymbol comment: ",
				this.mySymbolComment,
				"\r\nAuthor: ",
				this.MyAuthor,
				"\r\nName: ",
				this.myName,
				"\r\nFamily: ",
				this.myFamily,
				"\r\nComment: ",
				this.myComment
			});
		}

		public int Fill(string[] s)
		{
			int result = 0;
			frmMain.Address oldAddress = default(frmMain.Address);
			string text = "";
			oldAddress.ByteNumber = 0;
			oldAddress.BitNumber = 0;
			this.myTags.Clear();
			int arg_39_0 = 2;
			checked
			{
				int num = s.GetUpperBound(0) - 1;
				int num2 = arg_39_0;
				while (true)
				{
					int arg_6B_0 = num2;
					int num3 = num;
					if (arg_6B_0 > num3)
					{
						break;
					}
					clsTag item = new clsTag(s, ref num2, ref text, ref oldAddress);
					this.myTags.Add(item, null, null, null);
					num2++;
				}
				oldAddress = clsDataType.GetStartAddress(oldAddress, "END_STRUCT");
				bool flag = oldAddress.ByteNumber != this.myLength;
				if (flag)
				{
					string text2 = "DB" + Conversions.ToString(this.myNumber) + "\r\n";
					text2 = text2 + "Length in data base = " + Conversions.ToString(this.myLength) + "\r\n";
					text2 = text2 + "Length calculated = " + Conversions.ToString(oldAddress.ByteNumber);
					MessageBox.Show(text2, "Mistake", MessageBoxButtons.OK);
				}
				return result;
			}
		}

		public void FillExcel(Worksheet xlsTabBlatt, int zeile)
		{
			int[] array = new int[21];
			this.Level = 0;
		    IEnumerator enumerator = this.Tags.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					clsTag clsTag = (clsTag)enumerator.Current;
					clsTag.FillExcel(xlsTabBlatt, ref zeile, ref this.Level, ref array);
				}
			}
			finally
			{
				bool flag = enumerator is IDisposable;
				if (flag)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}

		public void GetActVal(byte[] b)
		{
		    IEnumerator enumerator = this.Tags.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					clsTag clsTag = (clsTag)enumerator.Current;
					clsTag.GetActValue(b);
				}
			}
			finally
			{
				bool flag = enumerator is IDisposable;
				if (flag)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}

		public void WriteAwl(StreamWriter sw)
		{
			sw.Write("DATA_BLOCK DB " + Conversions.ToString(this.myNumber) + "\r\n");
			bool flag = Operators.CompareString(this.myComment, "", false) != 0;
			if (flag)
			{
				sw.Write("TITLE =" + this.myComment.Replace(Conversions.ToString(Convert.ToChar(0)), "") + "\r\n");
			}
			flag = (Operators.CompareString(this.MyAuthor, "", false) != 0);
			if (flag)
			{
				sw.Write("AUTHOR : " + this.MyAuthor + "\r\n");
			}
			flag = (Operators.CompareString(this.myFamily, "", false) != 0);
			if (flag)
			{
				sw.Write("FAMILY : " + this.myFamily + "\r\n");
			}
			flag = (Operators.CompareString(this.myName, "", false) != 0);
			if (flag)
			{
				sw.Write("NAME : " + this.myName + "\r\n");
			}
			flag = (Operators.CompareString(this.myVersion, "", false) != 0);
			if (flag)
			{
				sw.Write("VERSION : " + this.myVersion + "\r\n");
			}
			sw.Write("\r\n");
			sw.Write("  STRUCT\r\n");
		    IEnumerator enumerator = this.Tags.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					clsTag clsTag = (clsTag)enumerator.Current;
					clsTag.WriteAwlTag(sw);
				}
			}
			finally
			{
				flag = (enumerator is IDisposable);
				if (flag)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			sw.Write("\r\n");
			sw.Write("  END_STRUCT ;\r\n");
			sw.Write("BEGIN\r\n");
		    IEnumerator enumerator2 = this.Tags.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					clsTag clsTag2 = (clsTag)enumerator2.Current;
					clsTag2.WriteAwlActVal(sw);
				}
			}
			finally
			{
				flag = (enumerator2 is IDisposable);
				if (flag)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			sw.Write("END_DATA_BLOCK\r\n\r\n");
		}

		public void ReadActVal(ref libnodave.daveConnection dc)
		{
			bool flag = dc != null;
			if (flag)
			{
				byte[] array = new byte[checked(this.myLength + 1)];
				int num = dc.readManyBytes(libnodave.daveDB, this.myNumber, 0, this.myLength, array);
				flag = (num >= 0);
				if (flag)
				{
					this.GetActVal(array);
				}
				else
				{
					MessageBox.Show("Sorry, something is wrong", "Sorry", MessageBoxButtons.OK);
				}
			}
		}
	}
}
