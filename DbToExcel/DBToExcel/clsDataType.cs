using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;

namespace DBToExcel
{
	public class clsDataType
	{
		public enum DataTypes
		{
			BOOL = 1,
			BYTE_,
			WORD,
			DWORD,
			INT,
			DINT,
			REAL,
			S5TIME,
			TIME,
			DATE_,
			TIME_OF_DAY
		}

		[DebuggerNonUserCode]
		public clsDataType()
		{
		}

		public static frmMain.Address GetStartAddress(frmMain.Address oldAddress, string DataType)
		{
			frmMain.Address result = oldAddress;
			bool flag = Operators.CompareString(DataType, "BOOL", false) == 0;
			checked
			{
				if (!flag)
				{
					flag = (Operators.CompareString(DataType, "BYTE", false) == 0 || Operators.CompareString(DataType, "CHAR", false) == 0);
					if (flag)
					{
						bool flag2 = result.BitNumber > 0;
						if (flag2)
						{
							result.ByteNumber++;
							result.BitNumber = 0;
						}
					}
					else
					{
						bool flag2 = result.BitNumber > 0;
						if (flag2)
						{
							result.ByteNumber++;
							result.BitNumber = 0;
						}
						result.ByteNumber += result.ByteNumber % 2;
					}
				}
				return result;
			}
		}

		public static frmMain.Address GetNextAddress(frmMain.Address oldAddress, string DataType)
		{
			frmMain.Address result = oldAddress;
			bool flag = Operators.CompareString(DataType, "BOOL", false) == 0;
			checked
			{
				if (flag)
				{
					result.BitNumber++;
					flag = (result.BitNumber > 7);
					if (flag)
					{
						result.BitNumber = 0;
						result.ByteNumber++;
					}
				}
				else
				{
					flag = (Operators.CompareString(DataType, "BYTE", false) == 0 || Operators.CompareString(DataType, "CHAR", false) == 0);
					if (flag)
					{
						result.ByteNumber++;
					}
					else
					{
						bool arg_E8_0;
						if (Operators.CompareString(DataType, "INT", false) != 0 && Operators.CompareString(DataType, "WORD", false) != 0)
						{
							if (Operators.CompareString(DataType, "S5TIME", false) != 0)
							{
								if (Operators.CompareString(DataType, "DATE", false) != 0)
								{
									arg_E8_0 = false;
									goto IL_E7;
								}
							}
						}
						arg_E8_0 = true;
						IL_E7:
						flag = arg_E8_0;
						if (flag)
						{
							result.ByteNumber += 2;
						}
						else
						{
							bool arg_15F_0;
							if (Operators.CompareString(DataType, "DINT", false) != 0 && Operators.CompareString(DataType, "DWORD", false) != 0)
							{
								if (Operators.CompareString(DataType, "REAL", false) != 0)
								{
									if (Operators.CompareString(DataType, "TIME", false) != 0)
									{
										if (Operators.CompareString(DataType, "TIME_OF_DAY", false) != 0)
										{
											arg_15F_0 = false;
											goto IL_15E;
										}
									}
								}
							}
							arg_15F_0 = true;
							IL_15E:
							flag = arg_15F_0;
							if (flag)
							{
								result.ByteNumber += 4;
							}
							else
							{
								flag = (Operators.CompareString(DataType, "DATE_AND_TIME", false) == 0);
								if (flag)
								{
									result.ByteNumber += 8;
								}
								else
								{
									flag = (Operators.CompareString(DataType, "STRUCT", false) == 0);
									if (flag)
									{
									}
								}
							}
						}
					}
				}
				flag = LikeOperator.LikeString(DataType, "STRING*", CompareMethod.Binary);
				if (flag)
				{
					int num = DataType.IndexOf("[") + 1;
					int num2 = DataType.IndexOf("]");
					flag = (num > 0 & num2 > num);
					if (flag)
					{
						string text = DataType.Substring(num, num2 - num);
						flag = Versioned.IsNumeric(text);
						if (flag)
						{
							result.ByteNumber = (int)Math.Round(unchecked((double)result.ByteNumber + Conversions.ToDouble(text) + 2.0));
						}
					}
				}
				return result;
			}
		}

		public static string GetString(frmMain.Address Address, string DataType)
		{
			return "DBX" + Conversions.ToString(Address.ByteNumber) + "." + Conversions.ToString(Address.BitNumber);
		}
	}
}
