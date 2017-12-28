using DBToExcel.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows.Forms;

namespace DBToExcel
{
	public class clsBlockCont
	{
		private libnodave.daveConnection myDc;

		private libnodave.daveOSserialType myFds;

		private libnodave.daveInterface myDi;

		private bool myConnected;

		private string myName;

		private int myId;

		private int myContId;

		private string myProjectDirectory;

		private string mySymbolDirectory;

		private string myDirectory;

		private Collection myDbs;

		private string mySource;

		private string myProgramName;

		private string myIPAddress;

		private int myRack;

		private int mySlot;

		private string myCodePage1;

		private string myCodePage2;

		public libnodave.daveConnection dc
		{
			get
			{
				return this.myDc;
			}
			set
			{
				this.myDc = this.dc;
			}
		}

		public string Name
		{
			get
			{
				return this.myName;
			}
			set
			{
				this.myName = value;
			}
		}

		public int Id
		{
			get
			{
				return this.myId;
			}
			set
			{
				this.myId = value;
			}
		}

		public int ContId
		{
			get
			{
				return this.myContId;
			}
			set
			{
				this.myContId = value;
			}
		}

		public string ProjectDirectory
		{
			get
			{
				return this.myProjectDirectory;
			}
		}

		public string SymbolDirectory
		{
			get
			{
				return this.mySymbolDirectory;
			}
			set
			{
				this.mySymbolDirectory = value;
			}
		}

		public string Directory
		{
			get
			{
				return this.myDirectory;
			}
		}

		public Collection Dbs
		{
			get
			{
				return this.myDbs;
			}
		}

		public string Source
		{
			get
			{
				return this.mySource;
			}
			set
			{
				this.mySource = value;
			}
		}

		public string ProgramName
		{
			get
			{
				return this.myProgramName;
			}
			set
			{
				this.myProgramName = value;
			}
		}

		public string IPAddress
		{
			get
			{
				return this.myIPAddress;
			}
			set
			{
				this.myIPAddress = value;
			}
		}

		public int Rack
		{
			get
			{
				return this.myRack;
			}
			set
			{
				this.myRack = value;
			}
		}

		public int Slot
		{
			get
			{
				return this.mySlot;
			}
			set
			{
				this.mySlot = value;
			}
		}

		public string CodePage1
		{
			get
			{
				return this.myCodePage1;
			}
			set
			{
				this.myCodePage1 = value;
			}
		}

		public string CodePage2
		{
			get
			{
				return this.myCodePage2;
			}
			set
			{
				this.myCodePage2 = value;
			}
		}

		public clsBlockCont(string Name, int Id, string ProjmyDir)
		{
			this.myIPAddress = "192.168.0.1";
			this.myRack = 0;
			this.mySlot = 1;
			this.myDbs = new Collection();
			this.myName = Name;
			this.myProjectDirectory = ProjmyDir;
			this.myId = Id;
			string text = "00000000" + Conversion.Hex(Id);
			this.myDirectory = this.myProjectDirectory + "\\ombstx\\offline\\" + text.Substring(checked(text.Length - 8), 8) + "\\";
			this.myContId = 0;
			this.myProgramName = "";
			this.mySource = "S7";
		}

		public clsBlockCont(string Name)
		{
			this.myIPAddress = "192.168.0.1";
			this.myRack = 0;
			this.mySlot = 1;
			this.myDbs = new Collection();
			this.myName = Name;
			this.myProjectDirectory = "";
			this.myId = 0;
			this.myDirectory = "";
			this.myContId = 0;
			this.myProgramName = "";
			this.mySource = "Excel";
		}

		public override string ToString()
		{
			string str = this.myProgramName;
			bool flag = Operators.CompareString(this.myProgramName, "", false) != 0;
			if (flag)
			{
				str += "/";
			}
			return str + this.myName;
		}

		public string GetToolTip()
		{
			return string.Concat(new string[]
			{
				this.myName,
				", ID=",
				Conversions.ToString(this.myId),
				", \r\n",
				this.myDirectory,
				"IP Address: ",
				this.myIPAddress,
				", Rack: ",
				Conversions.ToString(this.myRack),
				", Slot:",
				Conversions.ToString(this.mySlot)
			});
		}

		public int Connect(ref string msg)
		{
			msg = "Try connect :" + this.myIPAddress;
			bool flag = !MyProject.Computer.Network.Ping(this.myIPAddress);
			int result;
			if (flag)
			{
				MessageBox.Show("Can not connect to PLC with IP Adress " + this.myIPAddress, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = -1;
			}
			else
			{
				this.myFds.rfd = libnodave.openSocket(102, this.myIPAddress);
				this.myFds.wfd = this.myFds.rfd;
				flag = (this.myFds.rfd > 0);
				if (flag)
				{
					msg = DateTime.Now.ToString() + " " + this.myName + " open socket OK";
					this.myDi = new libnodave.daveInterface(this.myFds, this.myName, 0, libnodave.daveProtoISOTCP, 0);
					this.myDi.setTimeout(100);
					int num = this.myDi.initAdapter();
					flag = (num == 0);
					if (flag)
					{
						msg = DateTime.Now.ToString() + " " + this.myName + " init adapter OK";
						this.myDc = new libnodave.daveConnection(this.myDi, 0, this.myRack, this.mySlot);
						num = this.myDc.connectPLC();
						flag = (num == 0);
						if (flag)
						{
							msg = DateTime.Now.ToString() + " " + this.myName + " PLC connect OK";
							this.myConnected = true;
							result = 0;
						}
						else
						{
							msg = DateTime.Now.ToString() + " " + this.myName + " PLC connect NOK";
							this.myConnected = false;
							MessageBox.Show("Can not connect to PLC with IP Adress " + this.myIPAddress, "Error", MessageBoxButtons.OK);
							result = -3;
						}
					}
					else
					{
						msg = DateTime.Now.ToString() + " " + this.myName + " init adapter NOK";
						this.myConnected = false;
						MessageBox.Show("Can not connect to PLC with IP Adress " + this.myIPAddress, "Error", MessageBoxButtons.OK);
						result = -2;
					}
				}
				else
				{
					msg = DateTime.Now.ToString() + " " + this.myName + " open socket NOK";
					this.myConnected = false;
					MessageBox.Show("Can not connect to PLC with IP Adress " + this.myIPAddress, "Error", MessageBoxButtons.OK);
					result = -1;
				}
			}
			return result;
		}

		public string Disconnect()
		{
			bool flag = this.myDc != null;
			if (flag)
			{
				this.myDc.disconnectPLC();
			}
			flag = (this.myDi != null);
			if (flag)
			{
				this.myDi.disconnectAdapter();
			}
			libnodave.closePort(this.myFds.rfd);
			return DateTime.Now.ToString() + " " + this.myName + " myDisconnected\r\n";
		}
	}
}
