using System;
using System.Runtime.InteropServices;

public class libnodave
{
	public struct daveOSserialType
	{
		public int rfd;

		public int wfd;
	}

	public class pseudoPointer
	{
		public IntPtr pointer;

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveFree(IntPtr p);

		~pseudoPointer()
		{
			libnodave.pseudoPointer.daveFree(this.pointer);
		}
	}

	public class daveInterface : libnodave.pseudoPointer
	{
		public daveInterface(libnodave.daveOSserialType fd, string name, int localMPI, int useProto, int speed)
		{
			this.pointer = libnodave.daveInterface.daveNewInterface(fd, name, localMPI, useProto, speed);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		private static extern IntPtr daveNewInterface(libnodave.daveOSserialType fd, string name, int localMPI, int useProto, int speed);

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveInitAdapter(IntPtr di);

		public int initAdapter()
		{
			return libnodave.daveInterface.daveInitAdapter(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveListReachablePartners(IntPtr di, byte[] buffer);

		public int listReachablePartners(byte[] buffer)
		{
			return libnodave.daveInterface.daveListReachablePartners(this.pointer, buffer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern void daveSetTimeout(IntPtr di, int time);

		public void setTimeout(int time)
		{
			libnodave.daveInterface.daveSetTimeout(this.pointer, time);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetTimeout(IntPtr di);

		public int getTimeout()
		{
			return libnodave.daveInterface.daveGetTimeout(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern IntPtr daveDisconnectAdapter(IntPtr di);

		public IntPtr disconnectAdapter()
		{
			return libnodave.daveInterface.daveDisconnectAdapter(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern string daveGetName(IntPtr di);

		public string getName()
		{
			return libnodave.daveInterface.daveGetName(this.pointer);
		}
	}

	public class daveConnection : libnodave.pseudoPointer
	{
		public daveConnection(libnodave.daveInterface di, int MPI, int rack, int slot)
		{
			this.pointer = libnodave.daveConnection.daveNewConnection(di.pointer, MPI, rack, slot);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern IntPtr daveNewConnection(IntPtr di, int MPI, int rack, int slot);

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveConnectPLC(IntPtr dc);

		public int connectPLC()
		{
			return libnodave.daveConnection.daveConnectPLC(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveDisconnectPLC(IntPtr dc);

		public int disconnectPLC()
		{
			return libnodave.daveConnection.daveDisconnectPLC(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveReadBytes(IntPtr dc, int area, int DBnumber, int start, int len, byte[] buffer);

		public int readBytes(int area, int DBnumber, int start, int len, byte[] buffer)
		{
			return libnodave.daveConnection.daveReadBytes(this.pointer, area, DBnumber, start, len, buffer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveReadManyBytes(IntPtr dc, int area, int DBnumber, int start, int len, byte[] buffer);

		public int readManyBytes(int area, int DBnumber, int start, int len, byte[] buffer)
		{
			return libnodave.daveConnection.daveReadManyBytes(this.pointer, area, DBnumber, start, len, buffer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveReadBits(IntPtr dc, int area, int DBnumber, int start, int len, byte[] buffer);

		public int readBits(int area, int DBnumber, int start, int len, byte[] buffer)
		{
			return libnodave.daveConnection.daveReadBits(this.pointer, area, DBnumber, start, len, buffer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveWriteBytes(IntPtr dc, int area, int DBnumber, int start, int len, byte[] buffer);

		public int writeBytes(int area, int DBnumber, int start, int len, byte[] buffer)
		{
			return libnodave.daveConnection.daveWriteBytes(this.pointer, area, DBnumber, start, len, buffer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveWriteManyBytes(IntPtr dc, int area, int DBnumber, int start, int len, byte[] buffer);

		public int writeManyBytes(int area, int DBnumber, int start, int len, byte[] buffer)
		{
			return libnodave.daveConnection.daveWriteManyBytes(this.pointer, area, DBnumber, start, len, buffer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveWriteBits(IntPtr dc, int area, int DBnumber, int start, int len, byte[] buffer);

		public int writeBits(int area, int DBnumber, int start, int len, byte[] buffer)
		{
			return libnodave.daveConnection.daveWriteBits(this.pointer, area, DBnumber, start, len, buffer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetS32(IntPtr dc);

		public int getS32()
		{
			return libnodave.daveConnection.daveGetS32(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetU32(IntPtr dc);

		public int getU32()
		{
			return libnodave.daveConnection.daveGetU32(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetS16(IntPtr dc);

		public int getS16()
		{
			return libnodave.daveConnection.daveGetS16(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetU16(IntPtr dc);

		public int getU16()
		{
			return libnodave.daveConnection.daveGetU16(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetS8(IntPtr dc);

		public int getS8()
		{
			return libnodave.daveConnection.daveGetS8(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetU8(IntPtr dc);

		public int getU8()
		{
			return libnodave.daveConnection.daveGetU8(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern float daveGetFloat(IntPtr dc);

		public float getFloat()
		{
			return libnodave.daveConnection.daveGetFloat(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetCounterValue(IntPtr dc);

		public int getCounterValue()
		{
			return libnodave.daveConnection.daveGetCounterValue(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern float daveGetSeconds(IntPtr dc);

		public float getSeconds()
		{
			return libnodave.daveConnection.daveGetSeconds(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetS32At(IntPtr dc, int pos);

		public int getS32At(int pos)
		{
			return libnodave.daveConnection.daveGetS32At(this.pointer, pos);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetU32At(IntPtr dc, int pos);

		public int getU32At(int pos)
		{
			return libnodave.daveConnection.daveGetU32At(this.pointer, pos);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetS16At(IntPtr dc, int pos);

		public int getS16At(int pos)
		{
			return libnodave.daveConnection.daveGetS16At(this.pointer, pos);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetU16At(IntPtr dc, int pos);

		public int getU16At(int pos)
		{
			return libnodave.daveConnection.daveGetU16At(this.pointer, pos);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetS8At(IntPtr dc, int pos);

		public int getS8At(int pos)
		{
			return libnodave.daveConnection.daveGetS8At(this.pointer, pos);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetU8At(IntPtr dc, int pos);

		public int getU8At(int pos)
		{
			return libnodave.daveConnection.daveGetU8At(this.pointer, pos);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern float daveGetFloatAt(IntPtr dc, int pos);

		public float getFloatAt(int pos)
		{
			return libnodave.daveConnection.daveGetFloatAt(this.pointer, pos);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetCounterValueAt(IntPtr dc, int pos);

		public int getCounterValueAt(int pos)
		{
			return libnodave.daveConnection.daveGetCounterValueAt(this.pointer, pos);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern float daveGetSecondsAt(IntPtr dc, int pos);

		public float getSecondsAt(int pos)
		{
			return libnodave.daveConnection.daveGetSecondsAt(this.pointer, pos);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetAnswLen(IntPtr dc);

		public int getAnswLen()
		{
			return libnodave.daveConnection.daveGetAnswLen(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetMaxPDULen(IntPtr dc);

		public int getMaxPDULen()
		{
			return libnodave.daveConnection.daveGetMaxPDULen(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int davePrepareReadRequest(IntPtr dc, IntPtr p);

		public libnodave.PDU prepareReadRequest()
		{
			libnodave.PDU pDU = new libnodave.PDU();
			libnodave.daveConnection.davePrepareReadRequest(this.pointer, pDU.pointer);
			return pDU;
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int davePrepareWriteRequest(IntPtr dc, IntPtr p);

		public libnodave.PDU prepareWriteRequest()
		{
			libnodave.PDU pDU = new libnodave.PDU();
			libnodave.daveConnection.davePrepareWriteRequest(this.pointer, pDU.pointer);
			return pDU;
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveExecReadRequest(IntPtr dc, IntPtr p, IntPtr rl);

		public int execReadRequest(libnodave.PDU p, libnodave.resultSet rl)
		{
			return libnodave.daveConnection.daveExecReadRequest(this.pointer, p.pointer, rl.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveExecWriteRequest(IntPtr dc, IntPtr p, IntPtr rl);

		public int execWriteRequest(libnodave.PDU p, libnodave.resultSet rl)
		{
			return libnodave.daveConnection.daveExecWriteRequest(this.pointer, p.pointer, rl.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveUseResult(IntPtr dc, IntPtr rs, int number);

		public int useResult(libnodave.resultSet rs, int number)
		{
			return libnodave.daveConnection.daveUseResult(this.pointer, rs.pointer, number);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveReadSZL(IntPtr dc, int id, int index, byte[] ddd, int len);

		public int readSZL(int id, int index, byte[] ddd, int len)
		{
			return libnodave.daveConnection.daveReadSZL(this.pointer, id, index, ddd, len);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveStart(IntPtr dc);

		public int start()
		{
			return libnodave.daveConnection.daveStart(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveStop(IntPtr dc);

		public int stop()
		{
			return libnodave.daveConnection.daveStop(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveForce200(IntPtr dc, int area, int start, int val);

		public int force200(int area, int start, int val)
		{
			return libnodave.daveConnection.daveForce200(this.pointer, area, start, val);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveForceDisconnectIBH(IntPtr dc, int src, int dest, int MPI);

		public int forceDisconnectIBH(int src, int dest, int MPI)
		{
			return libnodave.daveConnection.daveForceDisconnectIBH(this.pointer, src, dest, MPI);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetResponse(IntPtr dc);

		public int getGetResponse()
		{
			return libnodave.daveConnection.daveGetResponse(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveSendMessage(IntPtr dc, IntPtr p);

		public int getMessage(libnodave.PDU p)
		{
			return libnodave.daveConnection.daveSendMessage(this.pointer, p.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetProgramBlock(IntPtr dc, int blockType, int number, byte[] buffer, ref int length);

		public int getProgramBlock(int blockType, int number, byte[] buffer, ref int length)
		{
			Console.WriteLine("length:" + length);
			int result = libnodave.daveConnection.daveGetProgramBlock(this.pointer, blockType, number, buffer, ref length);
			Console.WriteLine("length:" + length);
			return result;
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveListBlocksOfType(IntPtr dc, int blockType, byte[] buffer);

		public int ListBlocksOfType(int blockType, byte[] buffer)
		{
			return libnodave.daveConnection.daveListBlocksOfType(this.pointer, blockType, buffer);
		}
	}

	public class PDU : libnodave.pseudoPointer
	{
		public PDU()
		{
			this.pointer = libnodave.PDU.daveNewPDU();
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern IntPtr daveNewPDU();

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern void daveAddVarToReadRequest(IntPtr p, int area, int DBnum, int start, int bytes);

		public void addVarToReadRequest(int area, int DBnum, int start, int bytes)
		{
			libnodave.PDU.daveAddVarToReadRequest(this.pointer, area, DBnum, start, bytes);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern void daveAddBitVarToReadRequest(IntPtr p, int area, int DBnum, int start, int bytes);

		public void addBitVarToReadRequest(int area, int DBnum, int start, int bytes)
		{
			libnodave.PDU.daveAddBitVarToReadRequest(this.pointer, area, DBnum, start, bytes);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern void daveAddVarToWriteRequest(IntPtr p, int area, int DBnum, int start, int bytes, byte[] buffer);

		public void addVarToWriteRequest(int area, int DBnum, int start, int bytes, byte[] buffer)
		{
			libnodave.PDU.daveAddVarToWriteRequest(this.pointer, area, DBnum, start, bytes, buffer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern void daveAddBitVarToWriteRequest(IntPtr p, int area, int DBnum, int start, int bytes, byte[] buffer);

		public void addBitVarToWriteRequest(int area, int DBnum, int start, int bytes, byte[] buffer)
		{
			libnodave.PDU.daveAddBitVarToWriteRequest(this.pointer, area, DBnum, start, bytes, buffer);
		}
	}

	public class resultSet : libnodave.pseudoPointer
	{
		public resultSet()
		{
			this.pointer = libnodave.resultSet.daveNewResultSet();
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern IntPtr daveNewResultSet();

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern void daveFreeResults(IntPtr rs);

		~resultSet()
		{
			libnodave.resultSet.daveFreeResults(this.pointer);
		}

		[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
		protected static extern int daveGetErrorOfResult(IntPtr rs, int number);

		public int getErrorOfResult(int number)
		{
			return libnodave.resultSet.daveGetErrorOfResult(this.pointer, number);
		}
	}

	public static readonly int daveProtoMPI = 0;

	public static readonly int daveProtoMPI2 = 1;

	public static readonly int daveProtoMPI3 = 2;

	public static readonly int daveProtoMPI4 = 3;

	public static readonly int daveProtoPPI = 10;

	public static readonly int daveProtoAS511 = 20;

	public static readonly int daveProtoS7online = 50;

	public static readonly int daveProtoISOTCP = 122;

	public static readonly int daveProtoISOTCP243 = 123;

	public static readonly int daveProtoMPI_IBH = 223;

	public static readonly int daveProtoPPI_IBH = 224;

	public static readonly int daveProtoUserTransport = 255;

	public static readonly int daveSpeed9k = 0;

	public static readonly int daveSpeed19k = 1;

	public static readonly int daveSpeed187k = 2;

	public static readonly int daveSpeed500k = 3;

	public static readonly int daveSpeed1500k = 4;

	public static readonly int daveSpeed45k = 5;

	public static readonly int daveSpeed93k = 6;

	public static readonly int daveFuncOpenS7Connection = 240;

	public static readonly int daveFuncRead = 4;

	public static readonly int daveFuncWrite = 5;

	public static readonly int daveFuncRequestDownload = 26;

	public static readonly int daveFuncDownloadBlock = 27;

	public static readonly int daveFuncDownloadEnded = 28;

	public static readonly int daveFuncStartUpload = 29;

	public static readonly int daveFuncUpload = 30;

	public static readonly int daveFuncEndUpload = 31;

	public static readonly int daveFuncInsertBlock = 40;

	public static readonly int daveBlockType_OB = 56;

	public static readonly int daveBlockType_DB = 65;

	public static readonly int daveBlockType_SDB = 66;

	public static readonly int daveBlockType_FC = 67;

	public static readonly int daveBlockType_SFC = 68;

	public static readonly int daveBlockType_FB = 69;

	public static readonly int daveBlockType_SFB = 70;

	public static readonly int daveSysInfo = 3;

	public static readonly int daveSysFlags = 5;

	public static readonly int daveAnaIn = 6;

	public static readonly int daveAnaOut = 7;

	public static readonly int daveP = 128;

	public static readonly int daveInputs = 129;

	public static readonly int daveOutputs = 130;

	public static readonly int daveFlags = 131;

	public static readonly int daveDB = 132;

	public static readonly int daveDI = 133;

	public static readonly int daveLocal = 134;

	public static readonly int daveV = 135;

	public static readonly int daveCounter = 28;

	public static readonly int daveTimer = 29;

	public static readonly int daveCounter200 = 30;

	public static readonly int daveTimer200 = 31;

	public static readonly int daveResOK = 0;

	public static readonly int daveResNoPeripheralAtAddress = 1;

	public static readonly int daveResMultipleBitsNotSupported = 6;

	public static readonly int daveResItemNotAvailable200 = 3;

	public static readonly int daveResItemNotAvailable = 10;

	public static readonly int daveAddressOutOfRange = 5;

	public static readonly int daveWriteDataSizeMismatch = 7;

	public static readonly int daveResCannotEvaluatePDU = -123;

	public static readonly int daveResCPUNoData = -124;

	public static readonly int daveUnknownError = -125;

	public static readonly int daveEmptyResultError = -126;

	public static readonly int daveEmptyResultSetError = -127;

	public static readonly int daveResUnexpectedFunc = -128;

	public static readonly int daveResUnknownDataUnitSize = -129;

	public static readonly int daveResShortPacket = -1024;

	public static readonly int daveResTimeout = -1025;

	public static readonly int daveMaxRawLen = 2048;

	public static readonly int daveDebugRawRead = 1;

	public static readonly int daveDebugSpecialChars = 2;

	public static readonly int daveDebugRawWrite = 4;

	public static readonly int daveDebugListReachables = 8;

	public static readonly int daveDebugInitAdapter = 16;

	public static readonly int daveDebugConnect = 32;

	public static readonly int daveDebugPacket = 64;

	public static readonly int daveDebugByte = 128;

	public static readonly int daveDebugCompare = 256;

	public static readonly int daveDebugExchange = 512;

	public static readonly int daveDebugPDU = 1024;

	public static readonly int daveDebugUpload = 2048;

	public static readonly int daveDebugMPI = 4096;

	public static readonly int daveDebugPrintErrors = 8192;

	public static readonly int daveDebugPassive = 16384;

	public static readonly int daveDebugErrorReporting = 32768;

	public static readonly int daveDebugOpen = 65536;

	public static readonly int daveDebugAll = 131071;

	public static int daveMPIReachable = 48;

	public static int daveMPIunused = 16;

	public static int davePartnerListSize = 126;

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi, EntryPoint = "daveStrerror")]
	public static extern IntPtr _daveStrerror(int res);

	public static string daveStrerror(int res)
	{
		return Marshal.PtrToStringAuto(libnodave._daveStrerror(res));
	}

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern void daveSetDebug(int newDebugLevel);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern int daveGetDebug();

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern int setPort([MarshalAs(20)] string portName, [MarshalAs(20)] string baud, int parity);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern int openSocket(int port, [MarshalAs(20)] string portName);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern int openS7online([MarshalAs(20)] string portName);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern int closePort(int port);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern int closeSocket(int port);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern int closeS7online(int port);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern float toPLCfloat(float f);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern int daveToPLCfloat(float f);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern int daveSwapIed_32(int i);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	public static extern int daveSwapIed_16(int i);

	public static int getS16from(byte[] b, int pos)
	{
		if (BitConverter.IsLittleEndian)
		{
			byte[] array = new byte[]
			{
				default(byte),
				b[pos + 0]
			};
			array[0] = b[pos + 1];
			return (int)BitConverter.ToInt16(array, 0);
		}
		return (int)BitConverter.ToInt16(b, pos);
	}

	public static int getU16from(byte[] b, int pos)
	{
		if (BitConverter.IsLittleEndian)
		{
			byte[] array = new byte[]
			{
				default(byte),
				b[pos + 0]
			};
			array[0] = b[pos + 1];
			return (int)BitConverter.ToUInt16(array, 0);
		}
		return (int)BitConverter.ToUInt16(b, pos);
	}

	public static int getS32from(byte[] b, int pos)
	{
		if (BitConverter.IsLittleEndian)
		{
			byte[] array = new byte[]
			{
				default(byte),
				default(byte),
				default(byte),
				b[pos]
			};
			array[2] = b[pos + 1];
			array[1] = b[pos + 2];
			array[0] = b[pos + 3];
			return BitConverter.ToInt32(array, 0);
		}
		return BitConverter.ToInt32(b, pos);
	}

	public static uint getU32from(byte[] b, int pos)
	{
		if (BitConverter.IsLittleEndian)
		{
			byte[] array = new byte[]
			{
				default(byte),
				default(byte),
				default(byte),
				b[pos]
			};
			array[2] = b[pos + 1];
			array[1] = b[pos + 2];
			array[0] = b[pos + 3];
			return BitConverter.ToUInt32(array, 0);
		}
		return BitConverter.ToUInt32(b, pos);
	}

	public static float getFloatfrom(byte[] b, int pos)
	{
		if (BitConverter.IsLittleEndian)
		{
			byte[] array = new byte[]
			{
				default(byte),
				default(byte),
				default(byte),
				b[pos]
			};
			array[2] = b[pos + 1];
			array[1] = b[pos + 2];
			array[0] = b[pos + 3];
			return BitConverter.ToSingle(array, 0);
		}
		return BitConverter.ToSingle(b, pos);
	}

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	private static extern int daveAreaName(int area);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	private static extern int daveBlockName(int blockType);

	[DllImport("libnodave.dll", CharSet = CharSet.Ansi)]
	private static extern void daveStringCopy(int i, byte[] c);

	public static string blockName(int blockType)
	{
		byte[] array = new byte[255];
		int num = libnodave.daveBlockName(blockType);
		libnodave.daveStringCopy(num, array);
		string text = "";
		num = 0;
		while (array[num] != 0)
		{
			text += (char)array[num];
			num++;
		}
		return text;
	}

	public static string areaName(int blockType)
	{
		byte[] array = new byte[255];
		int num = libnodave.daveAreaName(blockType);
		libnodave.daveStringCopy(num, array);
		string text = "";
		num = 0;
		while (array[num] != 0)
		{
			text += (char)array[num];
			num++;
		}
		return text;
	}
}
