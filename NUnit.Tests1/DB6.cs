
/// <summary>
///  
/// </summary>
[S7DB(DB = 6)]
public class DatiBilancia: DBBase // DB6
{
	/// <summary>
	/// 
	/// </summary>
	public class T_Valori_di_misura	{

		/// <summary>
		/// Command code
		/// </summary>
		public short iCode { get; set; }


		/// <summary>
		/// Command trigger
		/// </summary>
		public bool boTrigger { get; set; }


		/// <summary>
		/// Command in progress
		/// </summary>
		public bool boInProgress { get; set; }


		/// <summary>
		/// Command finished ok
		/// </summary>
		public bool boFinishedOk { get; set; }


		/// <summary>
		/// Command finished with error
		/// </summary>
		public bool boFinishedError { get; set; }

	}

	public T_Valori_di_misura Valori_di_misura { get; set; }
}