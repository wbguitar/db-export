using DBToExcel.My;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DBToExcel
{
    public class clsTag
    {
        private int myArrayLowerBound;

        private int myArrayUpperBound;

        private string myArrayDataType;

        private int[] BoundsLow;

        private int[] BoundsUpp;

        private string myName;

        private string myComment;

        private string myDataType;

        private string myInitValue;

        private string myActValue;

        private frmMain.Address myAddress;

        private string myPrefix;

        private Collection myTags;

        private Collection myTagProperties;

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

        public string DataType
        {
            get
            {
                return this.myDataType;
            }
            set
            {
                this.myDataType = value;
            }
        }

        public string InitValue
        {
            get
            {
                return this.myInitValue;
            }
            set
            {
                this.myInitValue = value;
            }
        }

        public string ActValue
        {
            get
            {
                return this.myActValue;
            }
            set
            {
                this.myActValue = value;
            }
        }

        public frmMain.Address Address
        {
            get
            {
                return this.myAddress;
            }
            set
            {
                this.myAddress = value;
            }
        }

        public string Prefix
        {
            get
            {
                return this.myPrefix;
            }
            set
            {
                this.myPrefix = value;
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
                int num = 1;
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

        public string ToolTip
        {
            get
            {
                string text = string.Concat(new string[]
                {
                    "DBX",
                    Conversions.ToString(this.myAddress.ByteNumber),
                    ".",
                    Conversions.ToString(this.myAddress.BitNumber),
                    " ",
                    this.myPrefix,
                    " ",
                    this.myName,
                    "\r\nData type: ",
                    this.myDataType,
                    "\r\nInitial value:  ",
                    this.myInitValue,
                    "\r\nActual value: ",
                    this.myActValue,
                    "\r\nComment: ",
                    this.myComment
                });
                bool flag = this.myTagProperties.Count > 0;
                if (flag)
                {
                    text += "\r\nAttributes:";
                    IEnumerator enumerator = this.TagProperties.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            TagProperty tagProperty = (TagProperty)enumerator.Current;
                            text = string.Concat(new string[]
                            {
                                text,
                                "\r\n",
                                tagProperty.Name,
                                "=",
                                tagProperty.Value
                            });
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
                }
                return text;
            }
        }

        public Collection TagProperties
        {
            get
            {
                return this.myTagProperties;
            }
        }

        public clsTag()
        {
            this.myName = "";
            this.myComment = "";
            this.myDataType = "";
            this.myInitValue = "";
            this.myActValue = "";
            this.myPrefix = "";
            this.myTags = new Collection();
            this.myTagProperties = new Collection();
        }

        public clsTag(string[] s, ref int i, ref string _prefix, ref frmMain.Address Adr)
        {
            char[] trimChars = new char[]
            {
                ' ',
                '\t',
                '\n',
                '.',
                '=',
                ';',
                '\0'
            };
            this.myTags = new Collection();
            this.myTagProperties = new Collection();
            string[] array = s[i].Split(Conversions.ToCharArrayRankOne("//"), 2, StringSplitOptions.RemoveEmptyEntries);
            bool flag = array.GetUpperBound(0) > 0;
            if (flag)
            {
                this.myComment = array[array.GetUpperBound(0)].Trim(trimChars);
                byte[] bytes = MyProject.Forms.frmMain.enc.GetBytes(this.myComment);
                this.myComment = MyProject.Forms.frmMain.enc2.GetString(bytes);
            }
            else
            {
                this.myComment = "";
            }
            string text = "";
            flag = (array.GetUpperBound(0) >= 0);
            if (flag)
            {
                text = array[0];
            }
            int num = text.IndexOf("{");
            int num2 = text.IndexOf("}");
            flag = (num > 0 & num2 > 0);
            checked
            {
                if (flag)
                {
                    string text2 = text.Substring(num, num2 - num + 1);
                    string[] array2 = text2.Split(new char[]
                    {
                        ';'
                    });
                    int arg_14F_0 = 0;
                    int upperBound = array2.GetUpperBound(0);
                    int num3 = arg_14F_0;
                    while (true)
                    {
                        int arg_17F_0 = num3;
                        int num4 = upperBound;
                        if (arg_17F_0 > num4)
                        {
                            break;
                        }
                        TagProperty item = new TagProperty(array2[num3]);
                        this.myTagProperties.Add(item, null, null, null);
                        num3++;
                    }
                    text = text.Remove(num, num2 - num + 1);
                }
                string[] array3 = text.Split(Conversions.ToCharArrayRankOne(":"), 3, StringSplitOptions.RemoveEmptyEntries);
                switch (array3.GetUpperBound(0))
                {
                case 0:
                    this.myName = "";
                    this.myPrefix = _prefix;
                    this.myDataType = array3[0].Trim(trimChars);
                    this.myInitValue = this.GetDefaultInitValue();
                    break;
                case 1:
                    this.myName = array3[0].Trim(trimChars);
                    this.myPrefix = _prefix;
                    this.myDataType = array3[1].Trim(trimChars);
                    this.myInitValue = this.GetDefaultInitValue();
                    break;
                case 2:
                    this.myName = array3[0].Trim(trimChars);
                    this.myPrefix = _prefix;
                    this.myDataType = array3[1].Trim(trimChars);
                    this.myInitValue = array3[2].Trim(trimChars);
                    break;
                default:
                    this.myName = "";
                    this.myPrefix = "";
                    this.myDataType = "";
                    this.myInitValue = "";
                    break;
                }
                this.myAddress = clsDataType.GetStartAddress(Adr, this.myDataType);
                Adr = clsDataType.GetNextAddress(this.myAddress, this.myDataType);
                flag = LikeOperator.LikeString(this.myDataType, "UDT *", CompareMethod.Binary);
                if (flag)
                {
                    int udtNumber = Conversions.ToInteger(this.myDataType.Substring(4, this.myDataType.Length - 4).Trim(trimChars));
                    object value = _prefix + this.myName + ".";
                    string[] uDT = MyProject.Forms.frmMain.GetUDT(udtNumber);
                    int arg_342_0 = 2;
                    int num5 = uDT.GetUpperBound(0) - 1;
                    int num6 = arg_342_0;
                    while (true)
                    {
                        int arg_382_0 = num6;
                        int num4 = num5;
                        if (arg_382_0 > num4)
                        {
                            break;
                        }
                        string[] arg_357_0 = uDT;
                        string text3 = Conversions.ToString(value);
                        clsTag arg_360_0 = new clsTag(arg_357_0, ref num6, ref text3, ref Adr);
                        value = text3;
                        clsTag item2 = arg_360_0;
                        this.myTags.Add(item2, null, null, null);
                        num6++;
                    }
                    Adr = clsDataType.GetStartAddress(Adr, "END_UDT");
                }
                flag = LikeOperator.LikeString(this.myDataType, "STRUCT", CompareMethod.Binary);
                if (flag)
                {
                    object value2 = _prefix + this.myName + ".";
                    i++;
                    while (!LikeOperator.LikeString(s[i], "*END_STRUCT*", CompareMethod.Binary))
                    {
                        string text3 = Conversions.ToString(value2);
                        clsTag arg_3E8_0 = new clsTag(s, ref i, ref text3, ref Adr);
                        value2 = text3;
                        clsTag item3 = arg_3E8_0;
                        this.myTags.Add(item3, null, null, null);
                        i++;
                    }
                    Adr = clsDataType.GetStartAddress(Adr, "END_STRUCT");
                }
                flag = LikeOperator.LikeString(this.myDataType, "ARRAY*", CompareMethod.Binary);
                if (flag)
                {
                    int num7 = this.myDataType.IndexOf("[") + 1;
                    int num8 = this.myDataType.IndexOf("]");
                    string text4 = this.myDataType.Substring(num7, num8 - num7);
                    string[] array4 = text4.Split(new char[]
                    {
                        ','
                    });
                    int[] array5 = new int[array4.GetUpperBound(0) + 1];
                    int[] array6 = new int[array4.GetUpperBound(0) + 1];
                    int arg_4CD_0 = 0;
                    int upperBound2 = array4.GetUpperBound(0);
                    int num9 = arg_4CD_0;
                    while (true)
                    {
                        int arg_4FE_0 = num9;
                        int num4 = upperBound2;
                        if (arg_4FE_0 > num4)
                        {
                            break;
                        }
                        this.GetBounds(array4[num9], ref array5[num9], ref array6[num9]);
                        num9++;
                    }
                    this.BoundsLow = array5;
                    this.BoundsUpp = array6;
                    int num10 = this.myDataType.IndexOf("]");
                    this.myArrayLowerBound = 1;
                    this.myArrayUpperBound = this.GetArrayLength(this.BoundsLow, this.BoundsUpp);
                    flag = (this.myComment.Length > 0 | this.myDataType.Length < num10 + 5);
                    if (flag)
                    {
                        i++;
                        this.myArrayDataType = s[i].Trim(trimChars);
                    }
                    else
                    {
                        this.myArrayDataType = this.myDataType.Substring(num10 + 5, this.myDataType.Length - num10 - 5);
                    }
                    bool flag2 = true;
                    flag = (flag2 == (Operators.CompareString(this.myArrayDataType, "STRUCT", false) == 0));
                    if (flag)
                    {
                        int num11 = i;
                        int num12 = 1;
                        while (!(num12 == 0 | i >= s.GetUpperBound(0)))
                        {
                            flag = LikeOperator.LikeString(s[i], "*END_STRUCT*", CompareMethod.Binary);
                            if (flag)
                            {
                                num12--;
                            }
                            flag = (LikeOperator.LikeString(s[i], "* STRUCT*", CompareMethod.Binary) & i > num11);
                            if (flag)
                            {
                                num12++;
                            }
                            flag = (num12 > 0);
                            if (flag)
                            {
                                i++;
                            }
                        }
                        string[] array7 = new string[i - num11 + 1];
                        Array.Copy(s, num11 + 1, array7, 1, i - num11);
                        int arg_670_0 = this.myArrayLowerBound;
                        int num13 = this.myArrayUpperBound;
                        int num14 = arg_670_0;
                        while (true)
                        {
                            int arg_709_0 = num14;
                            int num4 = num13;
                            if (arg_709_0 > num4)
                            {
                                break;
                            }
                            string arrayString = this.GetArrayString(num14, this.BoundsLow, this.BoundsUpp);
                            array7[0] = this.myName + "[" + arrayString + "] :  STRUCT";
                            object value3 = _prefix;
                            int arg_6B8_0 = 0;
                            int upperBound3 = array7.GetUpperBound(0);
                            int num15 = arg_6B8_0;
                            while (true)
                            {
                                int arg_6F8_0 = num15;
                                num4 = upperBound3;
                                if (arg_6F8_0 > num4)
                                {
                                    break;
                                }
                                string[] arg_6CD_0 = array7;
                                string text3 = Conversions.ToString(value3);
                                clsTag arg_6D6_0 = new clsTag(arg_6CD_0, ref num15, ref text3, ref Adr);
                                value3 = text3;
                                clsTag item4 = arg_6D6_0;
                                this.myTags.Add(item4, null, null, null);
                                num15++;
                            }
                            num14++;
                        }
                    }
                    else
                    {
                        flag = (flag2 == LikeOperator.LikeString(this.myArrayDataType, "UDT*", CompareMethod.Binary));
                        if (flag)
                        {
                            int num16 = Conversions.ToInteger(this.myArrayDataType.Substring(4, this.myArrayDataType.Length - 4).Trim(trimChars));
                            int arg_766_0 = this.myArrayLowerBound;
                            int num17 = this.myArrayUpperBound;
                            int num18 = arg_766_0;
                            while (true)
                            {
                                int arg_801_0 = num18;
                                int num4 = num17;
                                if (arg_801_0 > num4)
                                {
                                    break;
                                }
                                string[] array8 = new string[1];
                                string arrayString2 = this.GetArrayString(num18, this.BoundsLow, this.BoundsUpp);
                                array8[0] = string.Concat(new string[]
                                {
                                    this.myName,
                                    "[",
                                    arrayString2,
                                    "] :  ",
                                    this.myArrayDataType
                                });
                                string[] arg_7DA_0 = array8;
                                int num19 = 0;
                                clsTag item5 = new clsTag(arg_7DA_0, ref num19, ref _prefix, ref Adr);
                                this.myTags.Add(item5, null, null, null);
                                num18++;
                            }
                        }
                        else
                        {
                            int arg_81A_0 = this.myArrayLowerBound;
                            int num20 = this.myArrayUpperBound;
                            int num21 = arg_81A_0;
                            while (true)
                            {
                                int arg_8DC_0 = num21;
                                int num4 = num20;
                                if (arg_8DC_0 > num4)
                                {
                                    break;
                                }
                                string[] array9 = new string[1];
                                string arrayString3 = this.GetArrayString(num21, this.BoundsLow, this.BoundsUpp);
                                array9[0] = string.Concat(new string[]
                                {
                                    this.myName,
                                    "[",
                                    arrayString3,
                                    "]:",
                                    this.myArrayDataType,
                                    "; //",
                                    this.myComment
                                });
                                string[] arg_8AC_0 = array9;
                                int num19 = 0;
                                string text3 = this.Prefix;
                                clsTag arg_8BA_0 = new clsTag(arg_8AC_0, ref num19, ref text3, ref Adr);
                                this.Prefix = text3;
                                clsTag item6 = arg_8BA_0;
                                this.myTags.Add(item6, null, null, null);
                                num21++;
                            }
                        }
                    }
                    Adr = clsDataType.GetStartAddress(Adr, "END_ARRAY");
                }
            }
        }

        public clsTag(ref Worksheet xlsTabBlatt, ref int zeile, ref frmMain.Address Adr)
        {
            char[] array = new char[]
            {
                ' ',
                '\t',
                '\n',
                '.',
                '=',
                ';',
                '\0'
            };
            this.myTags = new Collection();
            this.myTagProperties = new Collection();
            string text = Conversions.ToString(xlsTabBlatt.get_Range("B" + Conversions.ToString(zeile), Missing.Value).Text);
            string[] array2 = text.Split(new char[]
            {
                '.'
            });
            this.myName = array2[array2.GetUpperBound(0)];
            checked
            {
                this.myPrefix = text.Substring(0, text.Length - this.myName.Length);
                this.myDataType = Conversions.ToString(xlsTabBlatt.get_Range("C" + Conversions.ToString(zeile), Missing.Value).Text);
                this.myInitValue = Conversions.ToString(xlsTabBlatt.get_Range("D" + Conversions.ToString(zeile), Missing.Value).Text);
                this.myActValue = Conversions.ToString(xlsTabBlatt.get_Range("E" + Conversions.ToString(zeile), Missing.Value).Text);
                this.myComment = Conversions.ToString(xlsTabBlatt.get_Range("F" + Conversions.ToString(zeile), Missing.Value).Text);
                string text2 = Conversions.ToString(xlsTabBlatt.get_Range("G" + Conversions.ToString(zeile), Missing.Value).Text);
                bool flag = Operators.CompareString(text2, "", false) != 0;
                if (flag)
                {
                    string[] array3 = text2.Split(new char[]
                    {
                        '\r'
                    });
                    int arg_1D3_0 = 0;
                    int upperBound = array3.GetUpperBound(0);
                    int num = arg_1D3_0;
                    while (true)
                    {
                        int arg_24E_0 = num;
                        int num2 = upperBound;
                        if (arg_24E_0 > num2)
                        {
                            break;
                        }
                        string[] array4 = array3[num].Split(new char[]
                        {
                            '='
                        });
                        flag = (array4.GetUpperBound(0) == 1);
                        if (flag)
                        {
                            TagProperty tagProperty = new TagProperty();
                            tagProperty.Name = array4[0].Trim();
                            tagProperty.Value = array4[1].Trim();
                            this.myTagProperties.Add(tagProperty, null, null, null);
                        }
                        num++;
                    }
                }
                this.myAddress = clsDataType.GetStartAddress(Adr, this.myDataType);
                Adr = clsDataType.GetNextAddress(this.myAddress, this.myDataType);
                zeile++;
                flag = LikeOperator.LikeString(this.myDataType, "STRUCT*", CompareMethod.Binary);
                if (flag)
                {
                    while (!Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(xlsTabBlatt.get_Range("C" + Conversions.ToString(zeile), Missing.Value).Text, "END_STRUCT", false), Operators.CompareObjectEqual(xlsTabBlatt.get_Range("C" + Conversions.ToString(zeile), Missing.Value).Text, "", false))))
                    {
                        clsTag item = new clsTag(ref xlsTabBlatt, ref zeile, ref Adr);
                        this.Tags.Add(item, null, null, null);
                    }
                    zeile++;
                }
                flag = LikeOperator.LikeString(this.myDataType, "UDT*", CompareMethod.Binary);
                if (flag)
                {
                    while (!Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(xlsTabBlatt.get_Range("C" + Conversions.ToString(zeile), Missing.Value).Text, "END_UDT", false), Operators.CompareObjectEqual(xlsTabBlatt.get_Range("C" + Conversions.ToString(zeile), Missing.Value).Text, "", false))))
                    {
                        clsTag item2 = new clsTag(ref xlsTabBlatt, ref zeile, ref Adr);
                        this.Tags.Add(item2, null, null, null);
                    }
                    zeile++;
                }
                flag = LikeOperator.LikeString(this.myDataType, "ARRAY*", CompareMethod.Binary);
                if (flag)
                {
                    int num3 = this.myDataType.IndexOf("..");
                    int num4 = this.myDataType.IndexOf("]");
                    int num5 = this.myDataType.IndexOf("[") + 1;
                    int num6 = this.myDataType.IndexOf("]");
                    string text3 = this.myDataType.Substring(num5, num6 - num5);
                    string[] array5 = text3.Split(new char[]
                    {
                        ','
                    });
                    int[] array6 = new int[array5.GetUpperBound(0) + 1];
                    int[] array7 = new int[array5.GetUpperBound(0) + 1];
                    int arg_4A1_0 = 0;
                    int upperBound2 = array5.GetUpperBound(0);
                    int num7 = arg_4A1_0;
                    while (true)
                    {
                        int arg_4D2_0 = num7;
                        int num2 = upperBound2;
                        if (arg_4D2_0 > num2)
                        {
                            break;
                        }
                        this.GetBounds(array5[num7], ref array6[num7], ref array7[num7]);
                        num7++;
                    }
                    this.BoundsLow = array6;
                    this.BoundsUpp = array7;
                    this.myArrayLowerBound = 1;
                    this.myArrayUpperBound = this.GetArrayLength(this.BoundsLow, this.BoundsUpp);
                    this.myArrayDataType = Conversions.ToString(xlsTabBlatt.get_Range("C" + Conversions.ToString(zeile), Missing.Value).Text);
                    while (!Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(xlsTabBlatt.get_Range("C" + Conversions.ToString(zeile), Missing.Value).Text, "END_ARRAY", false), Operators.CompareObjectEqual(xlsTabBlatt.get_Range("C" + Conversions.ToString(zeile), Missing.Value).Text, "", false))))
                    {
                        clsTag item3 = new clsTag(ref xlsTabBlatt, ref zeile, ref Adr);
                        this.Tags.Add(item3, null, null, null);
                    }
                    zeile++;
                }
            }
        }

        public frmMain.Address GetStartAddress(frmMain.Address oldAddress)
        {
            frmMain.Address result = oldAddress;
            string left = this.myDataType;
            bool flag = Operators.CompareString(left, "BOOL", false) == 0;
            checked
            {
                if (!flag)
                {
                    flag = (Operators.CompareString(left, "BYTE", false) == 0 || Operators.CompareString(left, "CHAR", false) == 0);
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
                this.myAddress = result;
                return result;
            }
        }

        public frmMain.Address GetNextAddress(frmMain.Address oldAddress)
        {
            frmMain.Address result = oldAddress;
            string left = this.myDataType;
            bool flag = Operators.CompareString(left, "BOOL", false) == 0;
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
                    flag = (Operators.CompareString(left, "BYTE", false) == 0 || Operators.CompareString(left, "CHAR", false) == 0);
                    if (flag)
                    {
                        result.ByteNumber++;
                    }
                    else
                    {
                        bool arg_ED_0;
                        if (Operators.CompareString(left, "INT", false) != 0 && Operators.CompareString(left, "WORD", false) != 0)
                        {
                            if (Operators.CompareString(left, "S5TIME", false) != 0)
                            {
                                if (Operators.CompareString(left, "DATE", false) != 0)
                                {
                                    arg_ED_0 = false;
                                    goto IL_EC;
                                }
                            }
                        }
                        arg_ED_0 = true;
                        IL_EC:
                        flag = arg_ED_0;
                        if (flag)
                        {
                            result.ByteNumber += 2;
                        }
                        else
                        {
                            bool arg_164_0;
                            if (Operators.CompareString(left, "DINT", false) != 0 && Operators.CompareString(left, "DWORD", false) != 0)
                            {
                                if (Operators.CompareString(left, "REAL", false) != 0)
                                {
                                    if (Operators.CompareString(left, "TIME", false) != 0)
                                    {
                                        if (Operators.CompareString(left, "TIME_OF_DAY", false) != 0)
                                        {
                                            arg_164_0 = false;
                                            goto IL_163;
                                        }
                                    }
                                }
                            }
                            arg_164_0 = true;
                            IL_163:
                            flag = arg_164_0;
                            if (flag)
                            {
                                result.ByteNumber += 4;
                            }
                            else
                            {
                                flag = (Operators.CompareString(left, "DATE_AND_TIME", false) == 0);
                                if (flag)
                                {
                                    result.ByteNumber += 6;
                                }
                                else
                                {
                                    flag = (Operators.CompareString(left, "STRUCT", false) == 0);
                                    if (!flag)
                                    {
                                        flag = LikeOperator.LikeString(this.myDataType, "STRING*", CompareMethod.Binary);
                                        if (flag)
                                        {
                                            int num = 0;
                                            int num2 = this.myDataType.IndexOf("[");
                                            int num3 = this.myDataType.IndexOf("]");
                                            flag = (num2 > 0 & num3 > 0);
                                            if (flag)
                                            {
                                                string text = this.myDataType.Substring(num2 + 1, num3 - num2 - 1).Trim(new char[]
                                                {
                                                    ' '
                                                });
                                                flag = Versioned.IsNumeric(text);
                                                if (flag)
                                                {
                                                    num = Conversions.ToInteger(text);
                                                }
                                            }
                                            result.ByteNumber = result.ByteNumber + num + 2;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return result;
            }
        }

        public string GetString(frmMain.Address Address)
        {
            return "DBX" + Conversions.ToString(Address.ByteNumber) + "." + Conversions.ToString(Address.BitNumber);
        }

        public string GetDefaultInitValue()
        {
            string result = "";
            string left = this.myDataType;
            bool flag = Operators.CompareString(left, "BOOL", false) == 0;
            if (flag)
            {
                result = "FALSE";
            }
            else
            {
                flag = (Operators.CompareString(left, "BYTE", false) == 0);
                if (flag)
                {
                    result = "B#16#0";
                }
                else
                {
                    flag = (Operators.CompareString(left, "CHAR", false) == 0);
                    if (flag)
                    {
                        result = " ";
                    }
                    else
                    {
                        flag = (Operators.CompareString(left, "WORD", false) == 0);
                        if (flag)
                        {
                            result = "W#16#0";
                        }
                        else
                        {
                            flag = (Operators.CompareString(left, "INT", false) == 0);
                            if (flag)
                            {
                                result = "0";
                            }
                            else
                            {
                                flag = (Operators.CompareString(left, "DWORD", false) == 0);
                                if (flag)
                                {
                                    result = "DW#16#0";
                                }
                                else
                                {
                                    flag = (Operators.CompareString(left, "DINT", false) == 0);
                                    if (flag)
                                    {
                                        result = "L#0";
                                    }
                                    else
                                    {
                                        flag = (Operators.CompareString(left, "REAL", false) == 0);
                                        if (flag)
                                        {
                                            result = "0.000000e+000";
                                        }
                                        else
                                        {
                                            flag = (Operators.CompareString(left, "DATE", false) == 0);
                                            if (flag)
                                            {
                                                result = "D#1990-1-1";
                                            }
                                            else
                                            {
                                                flag = (Operators.CompareString(left, "TIME_OF_DAY", false) == 0);
                                                if (flag)
                                                {
                                                    result = "TOD#0:0:0.0";
                                                }
                                                else
                                                {
                                                    flag = (Operators.CompareString(left, "TIME", false) == 0);
                                                    if (flag)
                                                    {
                                                        result = "T#0MS";
                                                    }
                                                    else
                                                    {
                                                        flag = (Operators.CompareString(left, "S5TIME", false) == 0);
                                                        if (flag)
                                                        {
                                                            result = "S5T#0MS";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void GetActValue(byte[] b)
        {
            string text = "";
            bool flag = b.GetUpperBound(0) >= this.myAddress.ByteNumber;
            checked
            {
                if (flag)
                {
                    string left = this.myDataType;
                    bool flag2 = Operators.CompareString(left, "BOOL", false) == 0;
                    if (flag2)
                    {
                        byte b2 = b[this.myAddress.ByteNumber];
                        object right = Math.Pow(2.0, (double)this.myAddress.BitNumber);
                        flag2 = Operators.ConditionalCompareObjectEqual(Operators.AndObject(b2, right), right, false);
                        if (flag2)
                        {
                            text = "TRUE";
                        }
                        else
                        {
                            text = "FALSE";
                        }
                    }
                    else
                    {
                        flag2 = (Operators.CompareString(left, "BYTE", false) == 0);
                        if (flag2)
                        {
                            text = "B#16#" + Conversion.Hex(b[this.myAddress.ByteNumber]);
                        }
                        else
                        {
                            flag2 = (Operators.CompareString(left, "CHAR", false) == 0);
                            if (flag2)
                            {
                                text = "'" + Conversions.ToString(Strings.Chr((int)b[this.myAddress.ByteNumber])) + "'";
                            }
                            else
                            {
                                flag2 = (Operators.CompareString(left, "WORD", false) == 0);
                                if (flag2)
                                {
                                    text = "W#16#";
                                    flag2 = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + 1);
                                    if (flag2)
                                    {
                                        short number = BitConverter.ToInt16(new byte[]
                                        {
                                            b[this.myAddress.ByteNumber + 1],
                                            b[this.myAddress.ByteNumber + 0]
                                        }, 0);
                                        text += Conversion.Hex(number);
                                    }
                                    else
                                    {
                                        text += "0";
                                    }
                                }
                                else
                                {
                                    flag2 = (Operators.CompareString(left, "INT", false) == 0);
                                    if (flag2)
                                    {
                                        flag = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + 1);
                                        if (flag)
                                        {
                                            short value = BitConverter.ToInt16(new byte[]
                                            {
                                                b[this.myAddress.ByteNumber + 1],
                                                b[this.myAddress.ByteNumber + 0]
                                            }, 0);
                                            text += Conversions.ToString((int)value);
                                        }
                                        else
                                        {
                                            text += "0";
                                        }
                                    }
                                    else
                                    {
                                        flag2 = (Operators.CompareString(left, "DWORD", false) == 0);
                                        if (flag2)
                                        {
                                            text = "DW#16#";
                                            flag2 = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + 3);
                                            if (flag2)
                                            {
                                                int number2 = BitConverter.ToInt32(new byte[]
                                                {
                                                    b[this.myAddress.ByteNumber + 3],
                                                    b[this.myAddress.ByteNumber + 2],
                                                    b[this.myAddress.ByteNumber + 1],
                                                    b[this.myAddress.ByteNumber + 0]
                                                }, 0);
                                                text += Conversion.Hex(number2);
                                            }
                                            else
                                            {
                                                text += "0";
                                            }
                                        }
                                        else
                                        {
                                            flag2 = (Operators.CompareString(left, "DINT", false) == 0);
                                            if (flag2)
                                            {
                                                text = "L#";
                                                flag2 = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + 3);
                                                if (flag2)
                                                {
                                                    int value2 = BitConverter.ToInt32(new byte[]
                                                    {
                                                        b[this.myAddress.ByteNumber + 3],
                                                        b[this.myAddress.ByteNumber + 2],
                                                        b[this.myAddress.ByteNumber + 1],
                                                        b[this.myAddress.ByteNumber + 0]
                                                    }, 0);
                                                    text += Conversions.ToString(value2);
                                                }
                                                else
                                                {
                                                    text += "0";
                                                }
                                            }
                                            else
                                            {
                                                flag2 = (Operators.CompareString(left, "REAL", false) == 0);
                                                if (flag2)
                                                {
                                                    flag = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + 3);
                                                    if (flag)
                                                    {
                                                        text = BitConverter.ToSingle(new byte[]
                                                        {
                                                            b[this.myAddress.ByteNumber + 3],
                                                            b[this.myAddress.ByteNumber + 2],
                                                            b[this.myAddress.ByteNumber + 1],
                                                            b[this.myAddress.ByteNumber + 0]
                                                        }, 0).ToString().Replace(",", ".");
                                                    }
                                                    else
                                                    {
                                                        text += "0.0000";
                                                    }
                                                }
                                                else
                                                {
                                                    flag2 = (Operators.CompareString(left, "DATE", false) == 0);
                                                    if (flag2)
                                                    {
                                                        flag = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + 1);
                                                        if (flag)
                                                        {
                                                            short num = BitConverter.ToInt16(new byte[]
                                                            {
                                                                b[this.myAddress.ByteNumber + 1],
                                                                b[this.myAddress.ByteNumber + 0]
                                                            }, 0);
                                                            DateTime dateTime = new DateTime(1990, 1, 1);
                                                            DateTime dateTime2 = DateTime.FromBinary(unchecked((long)num) * 864000000000L + dateTime.ToBinary());
                                                            text = string.Concat(new string[]
                                                            {
                                                                "D#",
                                                                Conversions.ToString(dateTime2.Year),
                                                                "-",
                                                                Conversions.ToString(dateTime2.Month),
                                                                "-",
                                                                Conversions.ToString(dateTime2.Day)
                                                            });
                                                            DateTime dateTime3 = new DateTime(1990, 1, 2);
                                                            long num2 = dateTime3.ToBinary() - dateTime.ToBinary();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        flag2 = (Operators.CompareString(left, "TIME_OF_DAY", false) == 0);
                                                        if (flag2)
                                                        {
                                                            flag = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + 3);
                                                            if (flag)
                                                            {
                                                                int num3 = BitConverter.ToInt32(new byte[]
                                                                {
                                                                    b[this.myAddress.ByteNumber + 3],
                                                                    b[this.myAddress.ByteNumber + 2],
                                                                    b[this.myAddress.ByteNumber + 1],
                                                                    b[this.myAddress.ByteNumber + 0]
                                                                }, 0);
                                                                int value3 = (int)Math.Round(Conversion.Int((double)num3 / 3600000.0));
                                                                int num4 = num3 % 3600000;
                                                                int value4 = (int)Math.Round(Conversion.Int((double)num4 / 60000.0));
                                                                num4 %= 60000;
                                                                int value5 = (int)Math.Round(Conversion.Int((double)num4 / 1000.0));
                                                                int value6 = Conversion.Int(num4 % 1000);
                                                                text = string.Concat(new string[]
                                                                {
                                                                    "TOD#",
                                                                    Conversions.ToString(value3),
                                                                    ":",
                                                                    Conversions.ToString(value4),
                                                                    ":",
                                                                    Conversions.ToString(value5),
                                                                    ".",
                                                                    Conversions.ToString(value6)
                                                                });
                                                            }
                                                        }
                                                        else
                                                        {
                                                            flag2 = (Operators.CompareString(left, "TIME", false) == 0);
                                                            if (flag2)
                                                            {
                                                                flag = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + 3);
                                                                if (flag)
                                                                {
                                                                    int num5 = BitConverter.ToInt32(new byte[]
                                                                    {
                                                                        b[this.myAddress.ByteNumber + 3],
                                                                        b[this.myAddress.ByteNumber + 2],
                                                                        b[this.myAddress.ByteNumber + 1],
                                                                        b[this.myAddress.ByteNumber + 0]
                                                                    }, 0);
                                                                    int num6 = (int)Math.Round(Conversion.Int((double)num5 / 51000000.0));
                                                                    int num7 = num5 % 51000000;
                                                                    num7 %= 3600000;
                                                                    int num8 = (int)Math.Round(Conversion.Int((double)num5 / 3600000.0));
                                                                    int num9 = (int)Math.Round(Conversion.Int((double)num7 / 60000.0));
                                                                    num7 %= 60000;
                                                                    int num10 = (int)Math.Round(Conversion.Int((double)num7 / 1000.0));
                                                                    int num11 = Conversion.Int(num7 % 1000);
                                                                    text = "T#";
                                                                    flag2 = (num8 > 0);
                                                                    if (flag2)
                                                                    {
                                                                        text = text + Conversions.ToString(num8) + "H";
                                                                    }
                                                                    flag2 = (num9 > 0);
                                                                    if (flag2)
                                                                    {
                                                                        text = text + Conversions.ToString(num9) + "M";
                                                                    }
                                                                    flag2 = (num10 > 0);
                                                                    if (flag2)
                                                                    {
                                                                        text = text + Conversions.ToString(num10) + "S";
                                                                    }
                                                                    flag2 = (num11 > 0);
                                                                    if (flag2)
                                                                    {
                                                                        text = text + Conversions.ToString(num11) + "MS";
                                                                    }
                                                                    flag2 = (Operators.CompareString(text, "T#", false) == 0);
                                                                    if (flag2)
                                                                    {
                                                                        text = "T#0MS";
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                flag2 = (Operators.CompareString(left, "S5TIME", false) == 0);
                                                                if (flag2)
                                                                {
                                                                    flag = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + 1);
                                                                    if (flag)
                                                                    {
                                                                        int num12 = (int)Math.Round(unchecked((double)(b[checked(this.myAddress.ByteNumber + 1)] & 15) + (double)(b[checked(this.myAddress.ByteNumber + 1)] & 240) / 16.0 * 10.0 + (double)(checked((b[this.myAddress.ByteNumber] & 15) * 100))));
                                                                        switch ((short)Math.Round((double)(b[this.myAddress.ByteNumber] & 48) / 16.0))
                                                                        {
                                                                        case 1:
                                                                            num12 *= 10;
                                                                            break;
                                                                        case 2:
                                                                            num12 *= 100;
                                                                            break;
                                                                        case 3:
                                                                            num12 *= 1000;
                                                                            break;
                                                                        }
                                                                        int num13 = (int)Math.Round(Conversion.Int((double)num12 / 360000.0));
                                                                        int num14 = num12 % 360000;
                                                                        int num15 = (int)Math.Round(Conversion.Int((double)num14 / 6000.0));
                                                                        num14 %= 6000;
                                                                        int num16 = (int)Math.Round(Conversion.Int((double)num14 / 100.0));
                                                                        int num17 = Conversion.Int(num14 % 100);
                                                                        text = "S5T#";
                                                                        flag2 = (num13 > 0);
                                                                        if (flag2)
                                                                        {
                                                                            text = text + Conversions.ToString(num13) + "H";
                                                                        }
                                                                        flag2 = (num15 > 0);
                                                                        if (flag2)
                                                                        {
                                                                            text = text + Conversions.ToString(num15) + "m";
                                                                        }
                                                                        flag2 = (num16 > 0);
                                                                        if (flag2)
                                                                        {
                                                                            text = text + Conversions.ToString(num16) + "s";
                                                                        }
                                                                        flag2 = (num17 > 0 | Operators.CompareString(text, "S5T#", false) == 0);
                                                                        if (flag2)
                                                                        {
                                                                            text = text + Conversions.ToString(num17) + "ms";
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    flag2 = (Operators.CompareString(left, "DATE_AND_TIME", false) == 0);
                                                                    if (flag2)
                                                                    {
                                                                        flag = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + 7);
                                                                        if (flag)
                                                                        {
                                                                            text = "DT#";
                                                                            text += Conversion.Hex(b[this.myAddress.ByteNumber]);
                                                                            text += "-";
                                                                            text += Conversion.Hex(b[this.myAddress.ByteNumber + 1]);
                                                                            text += "-";
                                                                            text += Conversion.Hex(b[this.myAddress.ByteNumber + 2]);
                                                                            text += "-";
                                                                            text += Conversion.Hex(b[this.myAddress.ByteNumber + 3]);
                                                                            text += ":";
                                                                            text += Conversion.Hex(b[this.myAddress.ByteNumber + 4]);
                                                                            text += ":";
                                                                            text += Conversion.Hex(b[this.myAddress.ByteNumber + 5]);
                                                                            text += ".";
                                                                            int num18 = (int)Math.Round(unchecked(Conversion.Int((double)b[checked(this.myAddress.ByteNumber + 6)] / 256.0) * 100.0));
                                                                            num18 += (int)b[this.myAddress.ByteNumber + 6] % 256 * 10;
                                                                            num18 = (int)Math.Round(unchecked((double)num18 + Conversion.Int((double)b[checked(this.myAddress.ByteNumber + 7)] / 256.0)));
                                                                            text += Conversions.ToString(num18 % 1000);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    flag2 = LikeOperator.LikeString(this.DataType, "STRING*", CompareMethod.Binary);
                    if (flag2)
                    {
                        int num19 = this.DataType.IndexOf("[") + 1;
                        int num20 = this.DataType.IndexOf("]");
                        flag2 = (num19 > 0 & num20 > num19);
                        if (flag2)
                        {
                            string text2 = this.DataType.Substring(num19, num20 - num19);
                            int num21 = 0;
                            flag2 = Versioned.IsNumeric(text2);
                            if (flag2)
                            {
                                num21 = Conversions.ToInteger(text2);
                            }
                            flag2 = (b.GetUpperBound(0) >= this.myAddress.ByteNumber + num21 + 1);
                            if (flag2)
                            {
                                text = "'";
                                int arg_D6C_0 = 2;
                                int num22 = num21 + 1;
                                int num23 = arg_D6C_0;
                                while (true)
                                {
                                    int arg_DBA_0 = num23;
                                    int num24 = num22;
                                    if (arg_DBA_0 > num24)
                                    {
                                        break;
                                    }
                                    flag2 = (b[this.myAddress.ByteNumber + num23] > 0);
                                    if (flag2)
                                    {
                                        text += Conversions.ToString(Strings.Chr((int)b[this.myAddress.ByteNumber + num23]));
                                    }
                                    num23++;
                                }
                                text += "'";
                            }
                        }
                    }
                }
                this.myActValue = text;
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
                    bool flag2 = enumerator is IDisposable;
                    if (flag2)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
        }

        public void FillExcel(Worksheet xlsTabBlatt, ref int zeile, ref int level, ref int[] groups)
        {
            long num = (long)zeile;
            long num2 = (long)zeile;
            this.WriteRow(xlsTabBlatt, ref num2, ref level, ref groups, false);
            checked
            {
                zeile = (int)num2;
                bool flag;
                IEnumerator enumerator = this.Tags.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        clsTag clsTag = (clsTag)enumerator.Current;
                        clsTag.FillExcel(xlsTabBlatt, ref zeile, ref level, ref groups);
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
                flag = (Operators.CompareString(this.myDataType, "STRUCT", false) == 0 | LikeOperator.LikeString(this.myDataType, "ARRAY*", CompareMethod.Binary) | LikeOperator.LikeString(this.myDataType, "UDT*", CompareMethod.Binary));
                if (flag)
                {
                    num2 = unchecked((long)zeile);
                    this.WriteRow(xlsTabBlatt, ref num2, ref level, ref groups, true);
                    zeile = (int)num2;
                    string rowIndex = Conversions.ToString(num + 1L) + ":" + Conversions.ToString(zeile - 1);
                    NewLateBinding.LateCall(xlsTabBlatt.Rows[rowIndex, Missing.Value], null, "group", new object[0], null, null, null, true);
                }
            }
        }

        public void WriteRow(Worksheet xlsTabBlatt, ref long zeile, ref int level, ref int[] groups, bool myEnd)
        {
            bool flag = this.myDataType.Length > 2;
            checked
            {
                if (flag)
                {
                    Range range = xlsTabBlatt.get_Range(RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[zeile, 1]), RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[zeile, 6]));
                    flag = !myEnd;
                    if (flag)
                    {
                        range[1, 1] = this.GetString(this.myAddress);
                    }
                    string text = this.myPrefix + this.myName;
                    text = text.Trim(new char[]
                    {
                        '.'
                    });
                    range[1, 2] = text;
                    string text2 = this.myDataType;
                    bool flag2;
                    if (myEnd)
                    {
                        flag2 = (Operators.CompareString(this.myDataType, "STRUCT", false) == 0);
                        if (flag2)
                        {
                            text2 = "END_STRUCT";
                        }
                        flag2 = LikeOperator.LikeString(this.myDataType, "ARRAY*", CompareMethod.Binary);
                        if (flag2)
                        {
                            text2 = "END_ARRAY";
                        }
                        flag2 = LikeOperator.LikeString(this.myDataType, "UDT*", CompareMethod.Binary);
                        if (flag2)
                        {
                            text2 = "END_UDT";
                        }
                    }
                    range[1, 3] = text2;
                    string text3 = this.myInitValue;
                    flag2 = LikeOperator.LikeString(text3, "'*", CompareMethod.Binary);
                    if (flag2)
                    {
                        text3 = "'" + text3;
                    }
                    range[1, 4] = text3;
                    string text4 = this.myActValue;
                    flag2 = LikeOperator.LikeString(text4, "'*", CompareMethod.Binary);
                    if (flag2)
                    {
                        text4 = "'" + text4;
                    }
                    range[1, 5] = text4;
                    range[1, 6] = this.myComment;
                    string text5 = "";
                    IEnumerator enumerator = this.TagProperties.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            TagProperty tagProperty = (TagProperty)enumerator.Current;
                            flag2 = (Operators.CompareString(text5, "", false) != 0);
                            if (flag2)
                            {
                                text5 += "\r\n";
                            }
                            text5 = text5 + tagProperty.Name + "=" + tagProperty.Value;
                        }
                    }
                    finally
                    {
                        flag2 = (enumerator is IDisposable);
                        if (flag2)
                        {
                            (enumerator as IDisposable).Dispose();
                        }
                    }
                    range[1, 7] = text5;
                    zeile += 1L;
                    int num = level;
                    flag2 = (Operators.CompareString(text, "", false) != 0);
                    if (flag2)
                    {
                        string[] array = text.Split(new char[]
                        {
                            '.'
                        });
                        string[] array2 = text.Split(new char[]
                        {
                            '['
                        });
                        level = array.GetUpperBound(0) + array2.GetUpperBound(0);
                    }
                    int num2 = num;
                    while (true)
                    {
                        flag2 = (level > num2);
                        if (!flag2)
                        {
                            break;
                        }
                        num2++;
                        groups[num2] = (int)zeile;
                    }
                    while (true)
                    {
                        flag2 = (level < num2 & level >= 0);
                        if (!flag2)
                        {
                            break;
                        }
                        string text6 = Conversions.ToString(groups[num2] - 1) + ":" + Conversions.ToString(zeile - 1L);
                        groups[num2] = 0;
                        num2--;
                    }
                    flag2 = (level != num);
                    if (flag2)
                    {
                        level = level;
                    }
                    flag2 = LikeOperator.LikeString(text2, "*STRUCT*", CompareMethod.Binary);
                    if (flag2)
                    {
                        range.Interior.ColorIndex = 35;
                    }
                    flag2 = LikeOperator.LikeString(text2, "*UDT*", CompareMethod.Binary);
                    if (flag2)
                    {
                        range.Interior.ColorIndex = 36;
                    }
                    flag2 = LikeOperator.LikeString(text2, "*ARRAY*", CompareMethod.Binary);
                    if (flag2)
                    {
                        range.Interior.ColorIndex = 24;
                    }
                    flag2 = (this.myTagProperties.Count > 0);
                    if (flag2)
                    {
                        NewLateBinding.LateSetComplex(NewLateBinding.LateGet(range[1, 2], null, "Interior", new object[0], null, null, null), null, "ColorIndex", new object[]
                        {
                            4
                        }, null, null, false, true);
                    }
                }
                MyProject.Forms.frmMain.UpdateProgress((int)zeile);
            }
        }

        public void CopyActualToInitial()
        {
            this.myInitValue = this.myActValue;
            IEnumerator enumerator = this.Tags.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    clsTag clsTag = (clsTag)enumerator.Current;
                    clsTag.CopyActualToInitial();
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

        public void WriteAwlTag(StreamWriter sw)
        {
            string text = "  ";
            bool flag = this.myPrefix.Length > 0;
            checked
            {
                if (flag)
                {
                    text += " ";
                    string[] array = this.myPrefix.Split(new char[]
                    {
                        '.'
                    });
                    int arg_4D_0 = 2;
                    int upperBound = array.GetUpperBound(0);
                    int num = arg_4D_0;
                    while (true)
                    {
                        int arg_6C_0 = num;
                        int num2 = upperBound;
                        if (arg_6C_0 > num2)
                        {
                            break;
                        }
                        text += " ";
                        num++;
                    }
                }
                string text2 = text;
                bool flag2 = true;
                flag = (Operators.CompareString(this.myName, "", false) != 0);
                if (flag)
                {
                    text2 += this.myName;
                    flag = (this.myTagProperties.Count > 0);
                    if (flag)
                    {
                        text2 += " { ";
                        int num3 = 1;
                        IEnumerator enumerator = this.myTagProperties.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                TagProperty tagProperty = (TagProperty)enumerator.Current;
                                flag = (num3 > 1);
                                if (flag)
                                {
                                    text2 += "; ";
                                }
                                text2 = string.Concat(new string[]
                                {
                                    text2,
                                    tagProperty.Name,
                                    " := '",
                                    tagProperty.Value,
                                    "'"
                                });
                                num3++;
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
                        text2 += " }";
                    }
                    text2 += " : ";
                }
                flag = LikeOperator.LikeString(this.myDataType, "STRING*", CompareMethod.Binary);
                if (flag)
                {
                    this.myDataType = this.myDataType;
                }
                flag = LikeOperator.LikeString(this.myDataType, "ARRAY*", CompareMethod.Binary);
                bool flag3;
                if (flag)
                {
                    flag3 = (this.myDataType.IndexOf("OF") > 0);
                    if (flag3)
                    {
                        text2 += this.myDataType.Substring(0, this.myDataType.IndexOf("OF") + 2);
                    }
                    else
                    {
                        text2 += this.myDataType;
                    }
                    text2 = text2 + "  //" + this.myComment + "\r\n";
                    text2 = text2 + text + this.myArrayDataType;
                    flag3 = (Operators.CompareString(this.myArrayDataType, "STRUCT", false) != 0);
                    if (flag3)
                    {
                        text2 += ";";
                    }
                    text2 += "\r\n";
                }
                else
                {
                    text2 += this.myDataType;
                    flag3 = (Operators.CompareString(this.myInitValue, "", false) != 0 & Operators.CompareString(this.myInitValue, this.GetDefaultInitValue(), false) != 0);
                    if (flag3)
                    {
                        text2 = text2 + "  := " + this.GetActString(this.myInitValue);
                    }
                    flag3 = (Operators.CompareString(this.myDataType, "STRUCT", false) != 0);
                    if (flag3)
                    {
                        text2 += "; ";
                    }
                    flag3 = (this.myName.Length > 0);
                    if (flag3)
                    {
                        text2 = text2 + "  //" + this.myComment;
                    }
                    text2 += "\r\n";
                }
                flag3 = flag2;
                if (flag3)
                {
                    sw.Write(text2);
                }
                flag3 = (Operators.CompareString(this.myDataType, "STRUCT", false) == 0);
                if (flag3)
                {
                    IEnumerator enumerator2 = this.Tags.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            clsTag clsTag = (clsTag)enumerator2.Current;
                            clsTag.WriteAwlTag(sw);
                        }
                    }
                    finally
                    {
                        flag3 = (enumerator2 is IDisposable);
                        if (flag3)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                    sw.Write(text + "END_STRUCT ;\r\n");
                }
                flag3 = (LikeOperator.LikeString(this.myDataType, "ARRAY*", CompareMethod.Binary) & Operators.CompareString(this.myArrayDataType, "STRUCT", false) == 0);
                if (flag3)
                {
                    IEnumerator enumerator3 = this.Tags.GetEnumerator();
                    try
                    {
                        if (enumerator3.MoveNext())
                        {
                            clsTag clsTag2 = (clsTag)enumerator3.Current;
                            IEnumerator enumerator4 = clsTag2.Tags.GetEnumerator();
                            try
                            {
                                while (enumerator4.MoveNext())
                                {
                                    clsTag clsTag3 = (clsTag)enumerator4.Current;
                                    clsTag3.WriteAwlTag(sw);
                                }
                            }
                            finally
                            {
                                flag3 = (enumerator4 is IDisposable);
                                if (flag3)
                                {
                                    (enumerator4 as IDisposable).Dispose();
                                }
                            }
                            sw.Write(text + "END_STRUCT ;\r\n");
                        }
                    }
                    finally
                    {
                        flag3 = (enumerator3 is IDisposable);
                        if (flag3)
                        {
                            (enumerator3 as IDisposable).Dispose();
                        }
                    }
                }
            }
        }

        public void WriteAwlActVal(StreamWriter sw)
        {
            bool flag = Operators.CompareString(this.myActValue, "", false) != 0;
            if (flag)
            {
                string value = string.Concat(new string[]
                {
                    "   ",
                    this.myPrefix,
                    this.myName,
                    " := ",
                    this.GetActString(this.myActValue),
                    "; \r\n"
                });
                sw.Write(value);
            }
            IEnumerator enumerator = this.Tags.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    clsTag clsTag = (clsTag)enumerator.Current;
                    clsTag.WriteAwlActVal(sw);
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
        }

        private string GetActString(string value)
        {
            string text = value;
            bool flag = Operators.CompareString(this.myDataType, "REAL", false) == 0;
            checked
            {
                bool flag2;
                if (flag)
                {
                    flag2 = Versioned.IsNumeric(value);
                    if (flag2)
                    {
                        string numberDecimalSeparator = System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                        string text2 = value.Replace(".", System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                        text2 = text2.Replace(".", System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                        float num = Conversions.ToSingle(text2);
                        int num2 = 0;
                        flag2 = (num >= 10f | num <= -10f);
                        if (flag2)
                        {
                            while (num >= 10f | num <= -10f)
                            {
                                num /= 10f;
                                num2++;
                            }
                        }
                        flag2 = (num < 1f & num > -1f);
                        if (flag2)
                        {
                            while (num < 1f & num > -1f & num != 0f)
                            {
                                unchecked
                                {
                                    num *= 10f;
                                }
                                num2--;
                            }
                        }
                        text = Conversions.ToString(num);
                        text = text.Replace(",", ".");
                        flag2 = (text.IndexOf(".") < 0);
                        if (flag2)
                        {
                            text += ".";
                        }
                        text = text.PadRight(8, '0');
                        flag2 = (num2 >= 0);
                        if (flag2)
                        {
                            text = text + "e+" + num2.ToString("D3");
                        }
                        else
                        {
                            text = text + "e" + num2.ToString("D3");
                        }
                    }
                }
                flag2 = (Operators.CompareString(this.myDataType, "CHAR", false) == 0);
                if (flag2)
                {
                    flag = (Operators.CompareString(value, "'\0'", false) == 0 | Operators.CompareString(value, "' '", false) == 0);
                    if (flag)
                    {
                        text = "'$00'";
                    }
                }
                return text;
            }
        }

        private void GetBounds(string s, ref int BoundLow, ref int BoundUpp)
        {
            string[] array = s.Split(new char[]
            {
                '.'
            });
            BoundLow = Conversions.ToInteger(array[0]);
            BoundUpp = Conversions.ToInteger(array[2]);
        }

        private int GetArrayLength(int[] BndLow, int[] BndUpp)
        {
            int num = 1;
            int arg_12_0 = BndLow.GetLowerBound(0);
            int upperBound = BndLow.GetUpperBound(0);
            int num2 = arg_12_0;
            checked
            {
                while (true)
                {
                    int arg_2C_0 = num2;
                    int num3 = upperBound;
                    if (arg_2C_0 > num3)
                    {
                        break;
                    }
                    num *= BndUpp[num2] - BndLow[num2] + 1;
                    num2++;
                }
                return num;
            }
        }

        private string GetArrayString(int n, int[] BndLow, int[] BndUpp)
        {
            string text = "";
            checked
            {
                int[] array = new int[BndLow.GetUpperBound(0) + 1];
                int num = 1;
                int arg_28_0 = BndLow.GetUpperBound(0);
                int lowerBound = BndLow.GetLowerBound(0);
                int num2 = arg_28_0;
                while (true)
                {
                    int arg_4E_0 = num2;
                    int num3 = lowerBound;
                    if (arg_4E_0 < num3)
                    {
                        break;
                    }
                    num *= BndUpp[num2] - BndLow[num2] + 1;
                    array[num2] = num;
                    num2 += -1;
                }
                int num4 = n - 1;
                int arg_65_0 = BndLow.GetUpperBound(0);
                int lowerBound2 = BndLow.GetLowerBound(0);
                int num5 = arg_65_0;
                while (true)
                {
                    int arg_102_0 = num5;
                    int num3 = lowerBound2;
                    if (arg_102_0 < num3)
                    {
                        break;
                    }
                    object left = num4 % (BndUpp[num5] - BndLow[num5] + 1);
                    double number = (double)num4 / (double)(BndUpp[num5] - BndLow[num5] + 1);
                    num4 = (int)Math.Round(Conversion.Int(number));
                    bool flag = num5 == BndLow.GetUpperBound(0);
                    if (flag)
                    {
                        text = Conversions.ToString(Operators.AddObject(left, BndLow[num5]));
                    }
                    else
                    {
                        text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(left, BndLow[num5]), ","), text));
                    }
                    num5 += -1;
                }
                return text;
            }
        }
    }
}
