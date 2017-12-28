using DBToExcel.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows.Forms;

namespace DBToExcel
{
	public class clsCpu
	{
		private libnodave.daveConnection myDc;

		private libnodave.daveOSserialType fds;

		private libnodave.daveInterface di;

		private libnodave.PDU PDU;

		private bool myConnected;

		private string myName;

		private string myIPAddress;

		private int myRack;

		private int mySlot;

		private Collection myObjects;

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

		public Collection Objects
		{
			get
			{
				return this.myObjects;
			}
		}

		public clsCpu()
		{
			this.myIPAddress = "192.168.0.1";
			this.myRack = 0;
			this.mySlot = 3;
			this.myObjects = new Collection();
			this.myName = "CpuName";
			this.myIPAddress = "192.168.0.0";
			this.myRack = 0;
			this.mySlot = 3;
		}

		public clsCpu(string Name, string IPAddress, string Rack, string Slot)
		{
			this.myIPAddress = "192.168.0.1";
			this.myRack = 0;
			this.mySlot = 3;
			this.myObjects = new Collection();
			this.myName = Name;
			this.myIPAddress = IPAddress;
			bool flag = Versioned.IsNumeric(Rack);
			if (flag)
			{
				this.myRack = Conversions.ToInteger(Rack);
			}
			else
			{
				this.myRack = 0;
			}
			flag = Versioned.IsNumeric(Slot);
			if (flag)
			{
				this.mySlot = Conversions.ToInteger(Slot);
			}
			else
			{
				this.mySlot = 3;
			}
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
				this.fds.rfd = libnodave.openSocket(102, this.myIPAddress);
				this.fds.wfd = this.fds.rfd;
				flag = (this.fds.rfd > 0);
				if (flag)
				{
					msg = DateTime.Now.ToString() + " " + this.myName + " open socket OK";
					this.di = new libnodave.daveInterface(this.fds, this.myName, 0, libnodave.daveProtoISOTCP, 0);
					this.di.setTimeout(100);
					int num = this.di.initAdapter();
					flag = (num == 0);
					if (flag)
					{
						msg = DateTime.Now.ToString() + " " + this.myName + " init adapter OK";
						this.myDc = new libnodave.daveConnection(this.di, 0, 0, 3);
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
			bool flag = this.dc != null;
			if (flag)
			{
				this.dc.disconnectPLC();
			}
			flag = (this.di != null);
			if (flag)
			{
				this.di.disconnectAdapter();
			}
			libnodave.closePort(this.fds.rfd);
			this.myConnected = false;
			return DateTime.Now.ToString() + " " + this.myName + " disconnected\r\n";
		}

		public override string ToString()
		{
			return this.myName;
		}

		public string GetString()
		{
			return string.Concat(new string[]
			{
				"CPU;",
				this.myName,
				";",
				this.myIPAddress,
				";",
				Conversions.ToString(this.myRack),
				";",
				Conversions.ToString(this.mySlot)
			});
		}

		public string GetToolTip()
		{
			return string.Concat(new string[]
			{
				this.myName,
				", ",
				this.myIPAddress,
				", Rack ",
				Conversions.ToString(this.myRack),
				", Slot ",
				Conversions.ToString(this.mySlot)
			});
		}
	}
}
