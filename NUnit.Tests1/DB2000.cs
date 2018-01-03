
/// <summary>
///  
/// </summary>
[S7DB(DB = 2000)]
public class DataExchangeCYB500: DBBase // DB2000
{
	/// <summary>
	/// 
	/// </summary>
	public class T_AREA_DATI_DA_CYB500	{

		/// <summary>
		/// BITUMEN WEIGHT [Kg]
		/// </summary>
		public double BIT_WEIGHT { get; set; }


		/// <summary>
		/// BITUMEN TARE [Kg]
		/// </summary>
		public double BIT_TARE { get; set; }


		/// <summary>
		/// BIT SPRAYING
		/// </summary>
		public bool BIT_SPRAYING { get; set; }


		/// <summary>
		/// AGG DOOR OPENED
		/// </summary>
		public bool AGG_DOOR_OPENED { get; set; }


		/// <summary>
		/// BITUMEN PUMP FEEDBACK
		/// </summary>
		public bool BITUMEN_PUMP_ON { get; set; }


		/// <summary>
		/// EXTERNAL START
		/// </summary>
		public bool START_AQUABLACK { get; set; }


		/// <summary>
		/// ABORT DOSING
		/// </summary>
		public bool ABORT { get; set; }


		/// <summary>
		/// BITUMEN FLOW [Kg/sec]
		/// </summary>
		public double BIT_FLOW { get; set; }


		/// <summary>
		/// [Kg]
		/// </summary>
		public double BIT_TOTALIZER { get; set; }

	}

	public T_AREA_DATI_DA_CYB500 AREA_DATI_DA_CYB500 { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public bool WATCHDOG { get; set; }


	/// <summary>
	/// [*C]
	/// </summary>
	public double TEMPERATURA_BITUME { get; set; }


	/// <summary>
	/// 
	/// </summary>

	protected short [] __Dummy = new short[40];
	[S7Array(Count = 40)]
	public short [] Dummy { get { return __Dummy; } set { __Dummy = value; } } // = new short[40];\r\n
	/// <summary>
	/// 
	/// </summary>
	public class T_AREA_DATI_DA_PLC_AQUAB	{

		/// <summary>
		/// 
		/// </summary>
		public bool FINE_DOSAGGIO_H2O { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public bool EMERGENZA { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public bool WATCHDOG { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public bool ENABLE { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public bool ERR_TOLLERANZA { get; set; }

	}

	public T_AREA_DATI_DA_PLC_AQUAB AREA_DATI_DA_PLC_AQUAB { get; set; }
}