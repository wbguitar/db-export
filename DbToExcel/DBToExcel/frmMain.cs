using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace DBToExcel
{
    [DesignerGenerated]
    public class frmMain : Form
    {
        public struct Address
        {
            public int ByteNumber;

            public int BitNumber;
        }

        public enum DataType
        {
            BOOL = 1,
            BYTE,
            CHAR,
            WORD,
            INT,
            DWORD,
            DINT,
            REAL,
            DATE,
            TIME_OF_DAY,
            TIME,
            S5TIME,
            DT13,
            DATE_AND_TIME,
            DT15,
            ARRAY,
            STRUCT,
            STRING = 19
        }

        private static List<WeakReference> __ENCList = new List<WeakReference>();

        private IContainer components;

        [AccessedThroughProperty("OpenFileDialog1")]
        private OpenFileDialog _OpenFileDialog1;

        [AccessedThroughProperty("MenuStrip1")]
        private MenuStrip _MenuStrip1;

        [AccessedThroughProperty("FileToolStripMenuItem")]
        private ToolStripMenuItem _FileToolStripMenuItem;

        [AccessedThroughProperty("OpenS7ProjectToolStripMenuItem")]
        private ToolStripMenuItem _OpenS7ProjectToolStripMenuItem;

        [AccessedThroughProperty("lbxBlockCont")]
        private System.Windows.Forms.ListBox _lbxBlockCont;

        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;

        [AccessedThroughProperty("lbxDbs")]
        private System.Windows.Forms.ListBox _lbxDbs;

        [AccessedThroughProperty("lbxSelDbs")]
        private System.Windows.Forms.ListBox _lbxSelDbs;

        [AccessedThroughProperty("btnSel")]
        private System.Windows.Forms.Button _btnSel;

        [AccessedThroughProperty("btnDesel")]
        private System.Windows.Forms.Button _btnDesel;

        [AccessedThroughProperty("StatusStrip1")]
        private StatusStrip _StatusStrip1;

        [AccessedThroughProperty("tstStatus")]
        private ToolStripStatusLabel _tstStatus;

        [AccessedThroughProperty("tpbProgress")]
        private ToolStripProgressBar _tpbProgress;

        [AccessedThroughProperty("SaveFileDialog1")]
        private SaveFileDialog _SaveFileDialog1;

        [AccessedThroughProperty("Timer1")]
        private System.Windows.Forms.Timer _Timer1;

        [AccessedThroughProperty("Label1")]
        private System.Windows.Forms.Label _Label1;

        [AccessedThroughProperty("Label2")]
        private System.Windows.Forms.Label _Label2;

        [AccessedThroughProperty("Label3")]
        private System.Windows.Forms.Label _Label3;

        [AccessedThroughProperty("SelectedBlocksToolStripMenuItem")]
        private ToolStripMenuItem _SelectedBlocksToolStripMenuItem;

        [AccessedThroughProperty("CreateExcelToolStripMenuItem")]
        private ToolStripMenuItem _CreateExcelToolStripMenuItem;

        [AccessedThroughProperty("CreateAWLSourceToolStripMenuItem")]
        private ToolStripMenuItem _CreateAWLSourceToolStripMenuItem;

        [AccessedThroughProperty("AboutToolStripMenuItem")]
        private ToolStripMenuItem _AboutToolStripMenuItem;

        [AccessedThroughProperty("tvwDbTags")]
        private TreeView _tvwDbTags;

        [AccessedThroughProperty("OpenExcelFileToolStripMenuItem")]
        private ToolStripMenuItem _OpenExcelFileToolStripMenuItem;

        [AccessedThroughProperty("ActualValuesInitialValuesToolStripMenuItem")]
        private ToolStripMenuItem _ActualValuesInitialValuesToolStripMenuItem;

        [AccessedThroughProperty("Timer2")]
        private System.Windows.Forms.Timer _Timer2;

        [AccessedThroughProperty("ReadActualValuesToolStripMenuItem")]
        private ToolStripMenuItem _ReadActualValuesToolStripMenuItem;

        private Collection Containers;

        private string ActDirectory;

        public Collection InitValues;

        private Microsoft.Office.Interop.Excel.Application Excel1;

        private byte[] myCode;

        private byte[] myCode1;

        private byte[] myCode37;

        public string filename;

        private int SelDbNumber;

        private bool FillExcelRunning;

        private int ExcelZeile;

        private object myText;

        private string DirStep7;

        private string DirExcel;

        private string DirAwl;

        private int CodePage;

        public Encoding enc;

        public Encoding enc2;

        //private clsBlockCont $STATIC$lbxBlockCont_SelectedIndexChanged$20211C1269$SelItem;

        //private int $STATIC$Timer1_Tick$20211C1269$seldb;

        //private StaticLocalInitFlag $STATIC$lbxBlockCont_MouseMove$20211C1280A9$LastIndex$Init;

        //private int $STATIC$Timer1_Tick$20211C1269$count;

        //private int $STATIC$lbxBlockCont_MouseMove$20211C1280A9$LastIndex;


        private clsBlockCont SelItem;

        private int seldb;

        private StaticLocalInitFlag Init;

        private int count;

        private int LastIndex;

        internal virtual OpenFileDialog OpenFileDialog1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._OpenFileDialog1;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._OpenFileDialog1 = value;
            }
        }

        internal virtual MenuStrip MenuStrip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._MenuStrip1;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._MenuStrip1 = value;
            }
        }

        internal virtual ToolStripMenuItem FileToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._FileToolStripMenuItem;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._FileToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem OpenS7ProjectToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._OpenS7ProjectToolStripMenuItem;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.OpenS7ProjectToolStripMenuItem_Click);
                bool flag = this._OpenS7ProjectToolStripMenuItem != null;
                if (flag)
                {
                    this._OpenS7ProjectToolStripMenuItem.Click -= value2;
                }
                this._OpenS7ProjectToolStripMenuItem = value;
                flag = (this._OpenS7ProjectToolStripMenuItem != null);
                if (flag)
                {
                    this._OpenS7ProjectToolStripMenuItem.Click += value2;
                }
            }
        }

        internal virtual System.Windows.Forms.ListBox lbxBlockCont
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lbxBlockCont;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler value2 = new MouseEventHandler(this.lbxBlockCont_MouseMove);
                EventHandler value3 = new EventHandler(this.lbxBlockCont_SelectedIndexChanged);
                bool flag = this._lbxBlockCont != null;
                if (flag)
                {
                    this._lbxBlockCont.MouseMove -= value2;
                    this._lbxBlockCont.SelectedIndexChanged -= value3;
                }
                this._lbxBlockCont = value;
                flag = (this._lbxBlockCont != null);
                if (flag)
                {
                    this._lbxBlockCont.MouseMove += value2;
                    this._lbxBlockCont.SelectedIndexChanged += value3;
                }
            }
        }

        internal virtual ToolTip ToolTip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ToolTip1;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._ToolTip1 = value;
            }
        }

        internal virtual System.Windows.Forms.ListBox lbxDbs
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lbxDbs;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler value2 = new MouseEventHandler(this.lbxBlockCont_MouseMove);
                KeyPressEventHandler value3 = new KeyPressEventHandler(this.lbxDbs_KeyPress);
                bool flag = this._lbxDbs != null;
                if (flag)
                {
                    this._lbxDbs.MouseMove -= value2;
                    this._lbxDbs.KeyPress -= value3;
                }
                this._lbxDbs = value;
                flag = (this._lbxDbs != null);
                if (flag)
                {
                    this._lbxDbs.MouseMove += value2;
                    this._lbxDbs.KeyPress += value3;
                }
            }
        }

        internal virtual System.Windows.Forms.ListBox lbxSelDbs
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lbxSelDbs;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                MouseEventHandler value2 = new MouseEventHandler(this.lbxBlockCont_MouseMove);
                EventHandler value3 = new EventHandler(this.lbxSelDbs_SelectedIndexChanged);
                bool flag = this._lbxSelDbs != null;
                if (flag)
                {
                    this._lbxSelDbs.MouseMove -= value2;
                    this._lbxSelDbs.SelectedIndexChanged -= value3;
                }
                this._lbxSelDbs = value;
                flag = (this._lbxSelDbs != null);
                if (flag)
                {
                    this._lbxSelDbs.MouseMove += value2;
                    this._lbxSelDbs.SelectedIndexChanged += value3;
                }
            }
        }

        internal virtual System.Windows.Forms.Button btnSel
        {
            [DebuggerNonUserCode]
            get
            {
                return this._btnSel;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.btnSel_Click);
                bool flag = this._btnSel != null;
                if (flag)
                {
                    this._btnSel.Click -= value2;
                }
                this._btnSel = value;
                flag = (this._btnSel != null);
                if (flag)
                {
                    this._btnSel.Click += value2;
                }
            }
        }

        internal virtual System.Windows.Forms.Button btnDesel
        {
            [DebuggerNonUserCode]
            get
            {
                return this._btnDesel;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.btnDesel_Click);
                bool flag = this._btnDesel != null;
                if (flag)
                {
                    this._btnDesel.Click -= value2;
                }
                this._btnDesel = value;
                flag = (this._btnDesel != null);
                if (flag)
                {
                    this._btnDesel.Click += value2;
                }
            }
        }

        internal virtual StatusStrip StatusStrip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._StatusStrip1;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._StatusStrip1 = value;
            }
        }

        internal virtual ToolStripStatusLabel tstStatus
        {
            [DebuggerNonUserCode]
            get
            {
                return this._tstStatus;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tstStatus = value;
            }
        }

        internal virtual ToolStripProgressBar tpbProgress
        {
            [DebuggerNonUserCode]
            get
            {
                return this._tpbProgress;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tpbProgress = value;
            }
        }

        internal virtual SaveFileDialog SaveFileDialog1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SaveFileDialog1;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SaveFileDialog1 = value;
            }
        }

        internal virtual System.Windows.Forms.Timer Timer1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Timer1;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.Timer1_Tick);
                bool flag = this._Timer1 != null;
                if (flag)
                {
                    this._Timer1.Tick -= value2;
                }
                this._Timer1 = value;
                flag = (this._Timer1 != null);
                if (flag)
                {
                    this._Timer1.Tick += value2;
                }
            }
        }

        internal virtual System.Windows.Forms.Label Label1
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

        internal virtual System.Windows.Forms.Label Label2
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

        internal virtual System.Windows.Forms.Label Label3
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

        internal virtual ToolStripMenuItem SelectedBlocksToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SelectedBlocksToolStripMenuItem;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._SelectedBlocksToolStripMenuItem = value;
            }
        }

        internal virtual ToolStripMenuItem CreateExcelToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._CreateExcelToolStripMenuItem;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.CreateExcelToolStripMenuItem_Click);
                bool flag = this._CreateExcelToolStripMenuItem != null;
                if (flag)
                {
                    this._CreateExcelToolStripMenuItem.Click -= value2;
                }
                this._CreateExcelToolStripMenuItem = value;
                flag = (this._CreateExcelToolStripMenuItem != null);
                if (flag)
                {
                    this._CreateExcelToolStripMenuItem.Click += value2;
                }
            }
        }

        private ToolStripMenuItem _CreateCSharpToolStripMenuItem = null;
        internal virtual ToolStripMenuItem CreateCSharpToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._CreateCSharpToolStripMenuItem;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.CreateCSHarpToolStripMenuItem_Click);
                bool flag = this._CreateCSharpToolStripMenuItem != null;
                if (flag)
                {
                    this._CreateCSharpToolStripMenuItem.Click -= value2;
                }
                this._CreateCSharpToolStripMenuItem = value;
                flag = (this._CreateCSharpToolStripMenuItem != null);
                if (flag)
                {
                    this._CreateCSharpToolStripMenuItem.Click += value2;
                }
            }
        }

        internal virtual ToolStripMenuItem CreateAWLSourceToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._CreateAWLSourceToolStripMenuItem;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.CreateAWLSourceToolStripMenuItem_Click);
                bool flag = this._CreateAWLSourceToolStripMenuItem != null;
                if (flag)
                {
                    this._CreateAWLSourceToolStripMenuItem.Click -= value2;
                }
                this._CreateAWLSourceToolStripMenuItem = value;
                flag = (this._CreateAWLSourceToolStripMenuItem != null);
                if (flag)
                {
                    this._CreateAWLSourceToolStripMenuItem.Click += value2;
                }
            }
        }

        internal virtual ToolStripMenuItem AboutToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._AboutToolStripMenuItem;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.AboutToolStripMenuItem_Click);
                bool flag = this._AboutToolStripMenuItem != null;
                if (flag)
                {
                    this._AboutToolStripMenuItem.Click -= value2;
                }
                this._AboutToolStripMenuItem = value;
                flag = (this._AboutToolStripMenuItem != null);
                if (flag)
                {
                    this._AboutToolStripMenuItem.Click += value2;
                }
            }
        }

        internal virtual TreeView tvwDbTags
        {
            [DebuggerNonUserCode]
            get
            {
                return this._tvwDbTags;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._tvwDbTags = value;
            }
        }

        internal virtual ToolStripMenuItem OpenExcelFileToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._OpenExcelFileToolStripMenuItem;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.OpenExcelFileToolStripMenuItem_Click);
                bool flag = this._OpenExcelFileToolStripMenuItem != null;
                if (flag)
                {
                    this._OpenExcelFileToolStripMenuItem.Click -= value2;
                }
                this._OpenExcelFileToolStripMenuItem = value;
                flag = (this._OpenExcelFileToolStripMenuItem != null);
                if (flag)
                {
                    this._OpenExcelFileToolStripMenuItem.Click += value2;
                }
            }
        }

        internal virtual ToolStripMenuItem ActualValuesInitialValuesToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ActualValuesInitialValuesToolStripMenuItem;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.ActualValuesInitialValuesToolStripMenuItem_Click);
                bool flag = this._ActualValuesInitialValuesToolStripMenuItem != null;
                if (flag)
                {
                    this._ActualValuesInitialValuesToolStripMenuItem.Click -= value2;
                }
                this._ActualValuesInitialValuesToolStripMenuItem = value;
                flag = (this._ActualValuesInitialValuesToolStripMenuItem != null);
                if (flag)
                {
                    this._ActualValuesInitialValuesToolStripMenuItem.Click += value2;
                }
            }
        }

        internal virtual System.Windows.Forms.Timer Timer2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Timer2;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._Timer2 = value;
            }
        }

        internal virtual ToolStripMenuItem ReadActualValuesToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ReadActualValuesToolStripMenuItem;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler value2 = new EventHandler(this.ReadActualValuesToolStripMenuItem_Click);
                bool flag = this._ReadActualValuesToolStripMenuItem != null;
                if (flag)
                {
                    this._ReadActualValuesToolStripMenuItem.Click -= value2;
                }
                this._ReadActualValuesToolStripMenuItem = value;
                flag = (this._ReadActualValuesToolStripMenuItem != null);
                if (flag)
                {
                    this._ReadActualValuesToolStripMenuItem.Click += value2;
                }
            }
        }

        public frmMain()
        {
            base.FormClosing += new FormClosingEventHandler(this.frmMain_FormClosing);
            base.KeyPress += new KeyPressEventHandler(this.frmMain_KeyPress);
            base.Load += new EventHandler(this.frmMain_Load);
            frmMain.__ENCAddToList(this);
            this.Containers = new Collection();
            this.ActDirectory = "";
            this.InitValues = new Collection();
            this.myCode = new byte[256];
            this.myCode1 = new byte[256];
            this.myCode37 = new byte[256];
            this.FillExcelRunning = false;
            this.DirStep7 = "";
            this.DirExcel = "";
            this.DirAwl = "";
            this.CodePage = checked((int)(frmMain.GetOEMCP() % 4096L));
            this.enc = Encoding.GetEncoding(this.CodePage);
            this.enc2 = Encoding.GetEncoding(this.CodePage);
            this.Init = new StaticLocalInitFlag();
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            List<WeakReference> _ENCList = frmMain.__ENCList;
            checked
            {
                lock (_ENCList)
                {
                    bool flag = frmMain.__ENCList.Count == frmMain.__ENCList.Capacity;
                    if (flag)
                    {
                        int num = 0;
                        int arg_3F_0 = 0;
                        int num2 = frmMain.__ENCList.Count - 1;
                        int num3 = arg_3F_0;
                        while (true)
                        {
                            int arg_90_0 = num3;
                            int num4 = num2;
                            if (arg_90_0 > num4)
                            {
                                break;
                            }
                            WeakReference weakReference = frmMain.__ENCList[num3];
                            flag = weakReference.IsAlive;
                            if (flag)
                            {
                                bool flag2 = num3 != num;
                                if (flag2)
                                {
                                    frmMain.__ENCList[num] = frmMain.__ENCList[num3];
                                }
                                num++;
                            }
                            num3++;
                        }
                        frmMain.__ENCList.RemoveRange(num, frmMain.__ENCList.Count - num);
                        frmMain.__ENCList.Capacity = frmMain.__ENCList.Count;
                    }
                    frmMain.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMain));
            this.OpenFileDialog1 = new OpenFileDialog();
            this.MenuStrip1 = new MenuStrip();
            this.FileToolStripMenuItem = new ToolStripMenuItem();
            this.OpenS7ProjectToolStripMenuItem = new ToolStripMenuItem();
            this.OpenExcelFileToolStripMenuItem = new ToolStripMenuItem();
            this.SelectedBlocksToolStripMenuItem = new ToolStripMenuItem();
            this.CreateExcelToolStripMenuItem = new ToolStripMenuItem();
            CreateCSharpToolStripMenuItem = new ToolStripMenuItem();
            this.CreateAWLSourceToolStripMenuItem = new ToolStripMenuItem();
            this.ActualValuesInitialValuesToolStripMenuItem = new ToolStripMenuItem();
            this.ReadActualValuesToolStripMenuItem = new ToolStripMenuItem();
            this.AboutToolStripMenuItem = new ToolStripMenuItem();
            this.lbxBlockCont = new System.Windows.Forms.ListBox();
            this.ToolTip1 = new ToolTip(this.components);
            this.lbxDbs = new System.Windows.Forms.ListBox();
            this.lbxSelDbs = new System.Windows.Forms.ListBox();
            this.btnSel = new System.Windows.Forms.Button();
            this.btnDesel = new System.Windows.Forms.Button();
            this.StatusStrip1 = new StatusStrip();
            this.tstStatus = new ToolStripStatusLabel();
            this.tpbProgress = new ToolStripProgressBar();
            this.SaveFileDialog1 = new SaveFileDialog();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.tvwDbTags = new TreeView();
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            this.MenuStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.FileToolStripMenuItem,
                this.SelectedBlocksToolStripMenuItem,
                this.AboutToolStripMenuItem
            });
            Control arg_1EA_0 = this.MenuStrip1;
            System.Drawing.Point location = new System.Drawing.Point(0, 0);
            arg_1EA_0.Location = location;
            this.MenuStrip1.Name = "MenuStrip1";
            Control arg_218_0 = this.MenuStrip1;
            Size size = new Size(744, 24);
            arg_218_0.Size = size;
            this.MenuStrip1.TabIndex = 1;
            this.MenuStrip1.Text = "MenuStrip1";
            this.FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.OpenS7ProjectToolStripMenuItem,
                this.OpenExcelFileToolStripMenuItem
            });
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            ToolStripItem arg_28E_0 = this.FileToolStripMenuItem;
            size = new Size(37, 20);
            arg_28E_0.Size = size;
            this.FileToolStripMenuItem.Text = "&File";
            this.OpenS7ProjectToolStripMenuItem.Name = "OpenS7ProjectToolStripMenuItem";
            ToolStripItem arg_2CD_0 = this.OpenS7ProjectToolStripMenuItem;
            size = new Size(158, 22);
            arg_2CD_0.Size = size;
            this.OpenS7ProjectToolStripMenuItem.Text = "Open S7 Project";
            this.OpenExcelFileToolStripMenuItem.Name = "OpenExcelFileToolStripMenuItem";
            ToolStripItem arg_30C_0 = this.OpenExcelFileToolStripMenuItem;
            size = new Size(158, 22);
            arg_30C_0.Size = size;
            this.OpenExcelFileToolStripMenuItem.Text = "Open Excel file";
            this.SelectedBlocksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                CreateCSharpToolStripMenuItem,
                this.CreateExcelToolStripMenuItem,
                this.CreateAWLSourceToolStripMenuItem,
                this.ActualValuesInitialValuesToolStripMenuItem,
                this.ReadActualValuesToolStripMenuItem
            });
            this.SelectedBlocksToolStripMenuItem.Name = "SelectedBlocksToolStripMenuItem";
            ToolStripItem arg_389_0 = this.SelectedBlocksToolStripMenuItem;
            size = new Size(100, 20);
            arg_389_0.Size = size;
            this.SelectedBlocksToolStripMenuItem.Text = "&Selected blocks";
            this.CreateExcelToolStripMenuItem.Name = "CreateExcelToolStripMenuItem";
            ToolStripItem arg_3C8_0 = this.CreateExcelToolStripMenuItem;
            size = new Size(228, 22);
            arg_3C8_0.Size = size;
            this.CreateExcelToolStripMenuItem.Text = "Create Excel";

            CreateCSharpToolStripMenuItem.Name = "CreateCSharpToolStripMenuItem";
            CreateCSharpToolStripMenuItem.Text = "Create C# source";
            CreateCSharpToolStripMenuItem.Size = new Size(228, 22);

            this.CreateAWLSourceToolStripMenuItem.Name = "CreateAWLSourceToolStripMenuItem";
            ToolStripItem arg_407_0 = this.CreateAWLSourceToolStripMenuItem;
            size = new Size(228, 22);
            arg_407_0.Size = size;
            this.CreateAWLSourceToolStripMenuItem.Text = "Create AWL source";
            this.ActualValuesInitialValuesToolStripMenuItem.Name = "ActualValuesInitialValuesToolStripMenuItem";
            ToolStripItem arg_446_0 = this.ActualValuesInitialValuesToolStripMenuItem;
            size = new Size(228, 22);
            arg_446_0.Size = size;
            this.ActualValuesInitialValuesToolStripMenuItem.Text = "Actual values -> Initial values";
            this.ReadActualValuesToolStripMenuItem.Name = "ReadActualValuesToolStripMenuItem";
            ToolStripItem arg_485_0 = this.ReadActualValuesToolStripMenuItem;
            size = new Size(228, 22);
            arg_485_0.Size = size;
            this.ReadActualValuesToolStripMenuItem.Text = "Read actual values";
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            ToolStripItem arg_4C1_0 = this.AboutToolStripMenuItem;
            size = new Size(52, 20);
            arg_4C1_0.Size = size;
            this.AboutToolStripMenuItem.Text = "&About";
            this.lbxBlockCont.FormattingEnabled = true;
            Control arg_4F8_0 = this.lbxBlockCont;
            location = new System.Drawing.Point(13, 74);
            arg_4F8_0.Location = location;
            this.lbxBlockCont.Name = "lbxBlockCont";
            Control arg_526_0 = this.lbxBlockCont;
            size = new Size(120, 290);
            arg_526_0.Size = size;
            this.lbxBlockCont.TabIndex = 2;
            this.lbxDbs.FormattingEnabled = true;
            this.lbxDbs.HorizontalScrollbar = true;
            Control arg_569_0 = this.lbxDbs;
            location = new System.Drawing.Point(139, 73);
            arg_569_0.Location = location;
            this.lbxDbs.Name = "lbxDbs";
            this.lbxDbs.SelectionMode = SelectionMode.MultiExtended;
            Control arg_5A7_0 = this.lbxDbs;
            size = new Size(160, 290);
            arg_5A7_0.Size = size;
            this.lbxDbs.TabIndex = 2;
            this.ToolTip1.SetToolTip(this.lbxDbs, "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n");
            this.lbxSelDbs.FormattingEnabled = true;
            this.lbxSelDbs.HorizontalScrollbar = true;
            Control arg_601_0 = this.lbxSelDbs;
            location = new System.Drawing.Point(406, 73);
            arg_601_0.Location = location;
            this.lbxSelDbs.Name = "lbxSelDbs";
            Control arg_632_0 = this.lbxSelDbs;
            size = new Size(160, 290);
            arg_632_0.Size = size;
            this.lbxSelDbs.TabIndex = 2;
            Control arg_65E_0 = this.btnSel;
            location = new System.Drawing.Point(308, 174);
            arg_65E_0.Location = location;
            this.btnSel.Name = "btnSel";
            Control arg_689_0 = this.btnSel;
            size = new Size(92, 23);
            arg_689_0.Size = size;
            this.btnSel.TabIndex = 3;
            this.btnSel.Text = "------>";
            this.btnSel.UseVisualStyleBackColor = true;
            Control arg_6D3_0 = this.btnDesel;
            location = new System.Drawing.Point(308, 203);
            arg_6D3_0.Location = location;
            this.btnDesel.Name = "btnDesel";
            Control arg_6FE_0 = this.btnDesel;
            size = new Size(92, 23);
            arg_6FE_0.Size = size;
            this.btnDesel.TabIndex = 3;
            this.btnDesel.Text = "<------";
            this.btnDesel.UseVisualStyleBackColor = true;
            this.StatusStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.tstStatus,
                this.tpbProgress
            });
            Control arg_771_0 = this.StatusStrip1;
            location = new System.Drawing.Point(0, 365);
            arg_771_0.Location = location;
            this.StatusStrip1.Name = "StatusStrip1";
            Control arg_79F_0 = this.StatusStrip1;
            size = new Size(744, 22);
            arg_79F_0.Size = size;
            this.StatusStrip1.TabIndex = 5;
            this.StatusStrip1.Text = "StatusStrip1";
            this.tstStatus.AutoSize = false;
            this.tstStatus.Name = "tstStatus";
            ToolStripItem arg_7F8_0 = this.tstStatus;
            size = new Size(200, 17);
            arg_7F8_0.Size = size;
            this.tstStatus.Text = "Start";
            this.tstStatus.TextAlign = ContentAlignment.MiddleLeft;
            this.tpbProgress.Name = "tpbProgress";
            ToolStripControlHost arg_842_0 = this.tpbProgress;
            size = new Size(100, 16);
            arg_842_0.Size = size;
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1000;
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Control arg_8A4_0 = this.Label1;
            location = new System.Drawing.Point(27, 37);
            arg_8A4_0.Location = location;
            this.Label1.Name = "Label1";
            Control arg_8CF_0 = this.Label1;
            size = new Size(80, 32);
            arg_8CF_0.Size = size;
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Block\r\ncontainers";
            this.Label1.TextAlign = ContentAlignment.MiddleCenter;
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Control arg_942_0 = this.Label2;
            location = new System.Drawing.Point(162, 38);
            arg_942_0.Location = location;
            this.Label2.Name = "Label2";
            Control arg_96D_0 = this.Label2;
            size = new Size(54, 32);
            arg_96D_0.Size = size;
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Data\r\nblocks";
            this.Label2.TextAlign = ContentAlignment.MiddleCenter;
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            Control arg_9E0_0 = this.Label3;
            location = new System.Drawing.Point(449, 38);
            arg_9E0_0.Location = location;
            this.Label3.Name = "Label3";
            Control arg_A0B_0 = this.Label3;
            size = new Size(70, 32);
            arg_A0B_0.Size = size;
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Selected\r\nblocks";
            this.Label3.TextAlign = ContentAlignment.MiddleCenter;
            Control arg_A53_0 = this.tvwDbTags;
            location = new System.Drawing.Point(575, 74);
            arg_A53_0.Location = location;
            this.tvwDbTags.Name = "tvwDbTags";
            Control arg_A84_0 = this.tvwDbTags;
            size = new Size(160, 290);
            arg_A84_0.Size = size;
            this.tvwDbTags.TabIndex = 7;
            SizeF autoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleDimensions = autoScaleDimensions;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(744, 387);
            this.ClientSize = size;
            this.Controls.Add(this.tvwDbTags);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.btnDesel);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.lbxSelDbs);
            this.Controls.Add(this.lbxDbs);
            this.Controls.Add(this.lbxBlockCont);
            this.Controls.Add(this.MenuStrip1);
            this.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
            this.MainMenuStrip = this.MenuStrip1;
            size = new Size(760, 425);
            this.MaximumSize = size;
            size = new Size(760, 425);
            this.MinimumSize = size;
            this.Name = "frmMain";
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "DB to Excel";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        [DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetWindowThreadProcessId(int hWnd, ref IntPtr lpdwProcessId);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern long GetOEMCP();

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SavePar();
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool flag = Operators.CompareString(Conversions.ToString(e.KeyChar), "c", false) == 0;
            if (flag)
            {
                MessageBox.Show("Codepage is " + Conversions.ToString(frmMain.GetOEMCP() % 4096L), "Codepage", MessageBoxButtons.OK);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.ExecutablePath);
            string[] array = versionInfo.FileVersion.Split(new char[]
            {
                '.'
            });
            this.myText = string.Concat(new string[]
            {
                "DB Import V",
                array[0],
                ".",
                array[1],
                ".",
                array[2]
            });
            this.Text = Conversions.ToString(this.myText);
            this.SetMyCode();
            try
            {
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                frmMain.killExcelInstanceById(ref application);
            }
            catch (Exception expr_9D)
            {
                ProjectData.SetProjectError(expr_9D);
                string text = "MS Excel 2010 is not installed on your computer";
                MessageBox.Show(text, "No MS Excel 2010", MessageBoxButtons.OK);
                this.OpenExcelFileToolStripMenuItem.Enabled = false;
                this.CreateExcelToolStripMenuItem.Enabled = false;
                ProjectData.ClearProjectError();
            }
            this.LoadPar();
        }

        public void SetMyCode()
        {
            int num = 0;
            checked
            {
                int arg_2B_0;
                int num2;
                do
                {
                    this.myCode[num] = (byte)num;
                    this.myCode1[num] = (byte)num;
                    this.myCode37[num] = (byte)num;
                    num++;
                    arg_2B_0 = num;
                    num2 = 127;
                }
                while (arg_2B_0 <= num2);
                this.myCode[128] = 0;
                this.myCode[129] = 0;
                this.myCode[130] = 0;
                this.myCode[131] = 0;
                this.myCode[132] = 0;
                this.myCode[133] = 0;
                this.myCode[134] = 0;
                this.myCode[135] = 0;
                this.myCode[136] = 0;
                this.myCode[137] = 0;
                this.myCode[138] = 0;
                this.myCode[139] = 0;
                this.myCode[140] = 0;
                this.myCode[141] = 0;
                this.myCode[142] = 0;
                this.myCode[143] = 0;
                this.myCode[144] = 0;
                this.myCode[145] = 0;
                this.myCode[146] = 0;
                this.myCode[147] = 0;
                this.myCode[148] = 0;
                this.myCode[149] = 0;
                this.myCode[150] = 0;
                this.myCode[151] = 0;
                this.myCode[152] = 0;
                this.myCode[153] = 0;
                this.myCode[154] = 0;
                this.myCode[155] = 0;
                this.myCode[156] = 0;
                this.myCode[157] = 0;
                this.myCode[158] = 0;
                this.myCode[159] = 0;
                this.myCode[160] = 255;
                this.myCode[161] = 173;
                this.myCode[162] = 189;
                this.myCode[163] = 156;
                this.myCode[164] = 207;
                this.myCode[165] = 190;
                this.myCode[166] = 221;
                this.myCode[167] = 245;
                this.myCode[168] = 249;
                this.myCode[169] = 184;
                this.myCode[170] = 166;
                this.myCode[171] = 174;
                this.myCode[172] = 170;
                this.myCode[173] = 240;
                this.myCode[174] = 169;
                this.myCode[175] = 238;
                this.myCode[176] = 248;
                this.myCode[177] = 241;
                this.myCode[178] = 253;
                this.myCode[179] = 252;
                this.myCode[180] = 239;
                this.myCode[181] = 230;
                this.myCode[182] = 244;
                this.myCode[183] = 250;
                this.myCode[184] = 247;
                this.myCode[185] = 251;
                this.myCode[186] = 167;
                this.myCode[187] = 175;
                this.myCode[188] = 172;
                this.myCode[189] = 171;
                this.myCode[190] = 243;
                this.myCode[191] = 168;
                this.myCode[192] = 183;
                this.myCode[193] = 181;
                this.myCode[194] = 182;
                this.myCode[195] = 199;
                this.myCode[196] = 142;
                this.myCode[197] = 143;
                this.myCode[198] = 146;
                this.myCode[199] = 128;
                this.myCode[200] = 212;
                this.myCode[201] = 144;
                this.myCode[202] = 210;
                this.myCode[203] = 211;
                this.myCode[204] = 222;
                this.myCode[205] = 214;
                this.myCode[206] = 215;
                this.myCode[207] = 216;
                this.myCode[208] = 209;
                this.myCode[209] = 165;
                this.myCode[210] = 227;
                this.myCode[211] = 224;
                this.myCode[212] = 226;
                this.myCode[213] = 229;
                this.myCode[214] = 153;
                this.myCode[215] = 158;
                this.myCode[216] = 157;
                this.myCode[217] = 235;
                this.myCode[218] = 233;
                this.myCode[219] = 234;
                this.myCode[220] = 154;
                this.myCode[221] = 237;
                this.myCode[222] = 232;
                this.myCode[223] = 225;
                this.myCode[224] = 133;
                this.myCode[225] = 160;
                this.myCode[226] = 131;
                this.myCode[227] = 198;
                this.myCode[228] = 132;
                this.myCode[229] = 134;
                this.myCode[230] = 145;
                this.myCode[231] = 135;
                this.myCode[232] = 138;
                this.myCode[233] = 130;
                this.myCode[234] = 136;
                this.myCode[235] = 137;
                this.myCode[236] = 141;
                this.myCode[237] = 161;
                this.myCode[238] = 140;
                this.myCode[239] = 139;
                this.myCode[240] = 208;
                this.myCode[241] = 164;
                this.myCode[242] = 149;
                this.myCode[243] = 162;
                this.myCode[244] = 147;
                this.myCode[245] = 228;
                this.myCode[246] = 148;
                this.myCode[247] = 246;
                this.myCode[248] = 155;
                this.myCode[249] = 151;
                this.myCode[250] = 163;
                this.myCode[251] = 150;
                this.myCode[252] = 129;
                this.myCode[253] = 236;
                this.myCode[254] = 231;
                this.myCode[255] = 152;
                this.myCode1[146] = 159;
                this.myCode1[49] = 213;
                this.myCode37[145] = 176;
                this.myCode37[146] = 177;
                this.myCode37[147] = 178;
                this.myCode37[2] = 179;
                this.myCode37[36] = 180;
                this.myCode37[99] = 185;
                this.myCode37[81] = 186;
                this.myCode37[87] = 187;
                this.myCode37[93] = 188;
                this.myCode37[16] = 191;
                this.myCode37[20] = 192;
                this.myCode37[52] = 193;
                this.myCode37[44] = 194;
                this.myCode37[28] = 195;
                this.myCode37[0] = 196;
                this.myCode37[60] = 197;
                this.myCode37[90] = 200;
                this.myCode37[84] = 201;
                this.myCode37[105] = 202;
                this.myCode37[102] = 203;
                this.myCode37[96] = 204;
                this.myCode37[80] = 205;
                this.myCode37[108] = 206;
                this.myCode37[24] = 217;
                this.myCode37[12] = 218;
                this.myCode37[136] = 219;
                this.myCode37[132] = 220;
                this.myCode37[128] = 223;
                this.myCode37[160] = 254;
            }
        }

        private void OpenS7ProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            OleDbConnection oleDbConnection = new OleDbConnection();
            OleDbCommand oleDbCommand = new OleDbCommand();
            OleDbConnection oleDbConnection2 = new OleDbConnection();
            OleDbCommand oleDbCommand2 = new OleDbCommand();
            this.OpenFileDialog1.FileName = "";
            this.OpenFileDialog1.Filter = "S7 projects (*.s7p)|*.s7p";
            bool flag = Operators.CompareString(this.DirStep7, "", false) == 0;
            if (flag)
            {
                this.OpenFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            }
            else
            {
                this.OpenFileDialog1.InitialDirectory = this.DirStep7;
            }
            DialogResult dialogResult = this.OpenFileDialog1.ShowDialog();
            flag = (dialogResult != DialogResult.OK);
            checked
            {
                if (!flag)
                {
                    string fileName = this.OpenFileDialog1.FileName;
                    string directoryName = Path.GetDirectoryName(fileName);
                    this.DirStep7 = directoryName.Substring(0, directoryName.LastIndexOf(Path.DirectorySeparatorChar));
                    this.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(this.myText, "    "), Path.GetFileName(fileName)));
                    flag = (Operators.CompareString(fileName, "", false) == 0);
                    if (!flag)
                    {
                        IEnumerator enumerator = this.Containers.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                clsBlockCont clsBlockCont = (clsBlockCont)enumerator.Current;
                                clsBlockCont.Dbs.Clear();
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
                        this.Containers.Clear();
                        this.lbxBlockCont.Items.Clear();
                        this.lbxDbs.Items.Clear();
                        this.lbxSelDbs.Items.Clear();
                        this.Cursor = Cursors.WaitCursor;
                        this.Update();
                        flag = (File.Exists(directoryName + "\\Global\\Language.old") | File.Exists(directoryName + "\\Global\\Language"));
                        bool flag2;
                        if (flag)
                        {
                            try
                            {
                                flag2 = File.Exists(directoryName + "\\Global\\Language");
                                FileStream fileStream;
                                if (flag2)
                                {
                                    fileStream = new FileStream(directoryName + "\\Global\\Language", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                                }
                                else
                                {
                                    fileStream = new FileStream(directoryName + "\\Global\\Language.old", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                                }
                                StreamReader streamReader = new StreamReader(fileStream);
                                int num4 = 0;
                                while (streamReader.Peek() > 0)
                                {
                                    string value = streamReader.ReadLine();
                                    flag2 = (num4 == 3);
                                    if (flag2)
                                    {
                                        num3 = Conversions.ToInteger(value);
                                    }
                                    num4++;
                                }
                                flag2 = (num3 > 0);
                                if (flag2)
                                {
                                    this.enc2 = Encoding.GetEncoding(num3);
                                }
                                else
                                {
                                    this.enc2 = Encoding.GetEncoding(this.CodePage);
                                }
                                streamReader.Close();
                                fileStream.Close();
                            }
                            catch (Exception expr_2C6)
                            {
                                ProjectData.SetProjectError(expr_2C6);
                                ProjectData.ClearProjectError();
                            }
                        }
                        oleDbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + directoryName + "\\ombstx\\offline\\;Extended Properties=dBASE IV;";
                        oleDbConnection.Open();
                        oleDbCommand.Connection = oleDbConnection;
                        oleDbCommand.CommandText = "SELECT ID, NAME, ANZDB FROM BSTCNTOF.DBF ORDER BY ID";
                        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                        flag2 = (oleDbConnection.State == ConnectionState.Open);
                        if (flag2)
                        {
                            while (oleDbDataReader.Read())
                            {
                                flag = Operators.ConditionalCompareObjectGreater(oleDbDataReader["ANZDB"], 0, false);
                                if (flag)
                                {
                                    clsBlockCont item = new clsBlockCont(Conversions.ToString(oleDbDataReader["NAME"]), Conversions.ToInteger(oleDbDataReader["ID"]), directoryName);
                                    this.Containers.Add(item, null, null, null);
                                    num = Conversions.ToInteger(Operators.AddObject(num, oleDbDataReader["ANZDB"]));
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Can not connect to Data base", "Ha Ha Ha !!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        oleDbConnection.Close();
                        this.tpbProgress.Maximum = num;
                        this.tpbProgress.Minimum = 0;

                        IEnumerator enumerator2 = this.Containers.GetEnumerator();

                        try
                        {
                            while (enumerator2.MoveNext())
                            {
                                clsBlockCont clsBlockCont2 = (clsBlockCont)enumerator2.Current;
                                flag2 = File.Exists(clsBlockCont2.Directory + "links.lnk");
                                if (flag2)
                                {
                                    try
                                    {
                                        FileStream fileStream2 = new FileStream(clsBlockCont2.Directory + "links.lnk", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                                        BinaryReader binaryReader = new BinaryReader(fileStream2);
                                        fileStream2.Seek(528L, SeekOrigin.Begin);
                                        bool flag3 = true;
                                        byte[] array = new byte[8];
                                        while (flag3 & fileStream2.Length > fileStream2.Position + 8L)
                                        {
                                            array = binaryReader.ReadBytes(8);
                                            flag2 = (array[0] == 1 & array[1] == 65 & array[2] == 20);
                                            if (flag2)
                                            {
                                                clsBlockCont2.ContId = (int)array[3] * 256 + (int)array[4];
                                                flag3 = false;
                                            }
                                        }
                                        fileStream2.Close();
                                    }
                                    catch (Exception expr_4D9)
                                    {
                                        ProjectData.SetProjectError(expr_4D9);
                                        ProjectData.ClearProjectError();
                                    }
                                }
                                flag2 = (clsBlockCont2.ContId > 0);
                                if (flag2)
                                {
                                    try
                                    {
                                        oleDbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + clsBlockCont2.ProjectDirectory + "\\hrs\\;Extended Properties=dBASE IV;";
                                        oleDbConnection.Open();
                                        oleDbCommand.Connection = oleDbConnection;
                                        oleDbCommand.CommandText = "SELECT [ID], [NAME]  FROM S7RESOFF.DBF WHERE ID = " + Conversions.ToString(clsBlockCont2.ContId);
                                        oleDbDataReader = oleDbCommand.ExecuteReader();
                                        flag2 = (oleDbConnection.State == ConnectionState.Open);
                                        if (flag2)
                                        {
                                            oleDbDataReader.Read();
                                            clsBlockCont2.ProgramName = Conversions.ToString(oleDbDataReader["NAME"]);
                                        }
                                        oleDbConnection.Close();
                                    }
                                    catch (Exception expr_58F)
                                    {
                                        ProjectData.SetProjectError(expr_58F);
                                        oleDbConnection.Close();
                                        ProjectData.ClearProjectError();
                                    }
                                }
                                flag2 = (clsBlockCont2.ContId > 0);
                                if (flag2)
                                {
                                    try
                                    {
                                        oleDbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + clsBlockCont2.ProjectDirectory + "\\YDBs\\;Extended Properties=dBASE IV;";
                                        oleDbConnection.Open();
                                        oleDbCommand.Connection = oleDbConnection;
                                        oleDbCommand.CommandText = "SELECT SOI  FROM YLNKLIST.DBF WHERE TOI = " + Conversions.ToString(clsBlockCont2.ContId);
                                        oleDbDataReader = oleDbCommand.ExecuteReader();
                                        flag2 = (oleDbConnection.State == ConnectionState.Open);
                                        if (flag2)
                                        {
                                            oleDbDataReader.Read();
                                            string text = Conversions.ToString(oleDbDataReader["SOI"]);
                                            flag2 = Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(oleDbDataReader["SOI"]));
                                            if (flag2)
                                            {
                                                int value2 = Conversions.ToInteger(oleDbDataReader["SOI"]);
                                                clsBlockCont2.SymbolDirectory = clsBlockCont2.ProjectDirectory + "\\YDBs\\" + Conversions.ToString(value2) + "\\";
                                            }
                                        }
                                        oleDbConnection.Close();
                                        File.Copy(clsBlockCont2.SymbolDirectory + "\\SYMLIST.DBF", System.Windows.Forms.Application.StartupPath + "\\SYMLIST.DBF", true);
                                        FileStream fileStream3 = new FileStream(System.Windows.Forms.Application.StartupPath + "\\SYMLIST.DBF", FileMode.Open);
                                        BinaryWriter binaryWriter = new BinaryWriter(fileStream3);
                                        byte value3 = 0;
                                        binaryWriter.Seek(15, SeekOrigin.Begin);
                                        binaryWriter.Write(value3);
                                        fileStream3.Close();
                                        oleDbConnection2.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Windows.Forms.Application.StartupPath + ";Extended Properties=dBASE IV;";
                                        flag2 = (Operators.CompareString(clsBlockCont2.ProgramName, "", false) != 0);
                                        if (flag2)
                                        {
                                            oleDbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + clsBlockCont2.ProjectDirectory + "\\hrs\\;Extended Properties=dBASE IV;";
                                            oleDbConnection.Open();
                                            oleDbCommand.Connection = oleDbConnection;
                                            oleDbCommand.CommandText = "SELECT RSRVD2_L, RSRVD10_C  FROM S7RESONL.DBF WHERE [NAME] = '" + clsBlockCont2.ProgramName + "'";
                                            oleDbDataReader = oleDbCommand.ExecuteReader();
                                            flag2 = (oleDbConnection.State == ConnectionState.Open);
                                            if (flag2)
                                            {
                                                oleDbDataReader.Read();
                                                string text2 = Conversions.ToString(oleDbDataReader[0]);
                                                flag2 = Versioned.IsNumeric(text2);
                                                if (flag2)
                                                {
                                                    int num5 = Conversions.ToInteger(text2);
                                                    clsBlockCont2.Rack = (int)Math.Round(Conversion.Int((double)num5 / 32.0));
                                                    clsBlockCont2.Slot = num5 % 32;
                                                }
                                                string s = Conversions.ToString(oleDbDataReader[1]);
                                                byte[] bytes = this.enc.GetBytes(s);
                                                clsBlockCont2.IPAddress = string.Concat(new string[]
                                                {
                                                    Conversions.ToString(bytes[0]),
                                                    ".",
                                                    Conversions.ToString(bytes[1]),
                                                    ".",
                                                    Conversions.ToString(bytes[2]),
                                                    ".",
                                                    Conversions.ToString(bytes[3])
                                                });
                                            }
                                            oleDbConnection.Close();
                                        }
                                    }
                                    catch (Exception expr_89D)
                                    {
                                        ProjectData.SetProjectError(expr_89D);
                                        oleDbConnection.Close();
                                        ProjectData.ClearProjectError();
                                    }
                                }
                                this.lbxBlockCont.Items.Add(clsBlockCont2);
                                oleDbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + clsBlockCont2.Directory + ";Extended Properties=dBASE IV;";
                                oleDbConnection.Open();
                                OleDbDataReader oleDbDataReader2 = new OleDbCommand
                                {
                                    Connection = oleDbConnection,
                                    CommandText = "SELECT MC5CODE, BLKNUMBER, USERNAME FROM SUBBLK.DBF WHERE SUBBLKTYP = '00006'  ORDER BY BLKNUMBER"
                                }.ExecuteReader();
                                flag2 = (oleDbConnection.State == ConnectionState.Open);
                                if (flag2)
                                {
                                    while (oleDbDataReader2.Read())
                                    {
                                        string str = Conversions.ToString(oleDbDataReader2["BLKNUMBER"]);
                                        object objectValue = RuntimeHelpers.GetObjectValue(oleDbDataReader2["USERNAME"]);
                                        flag2 = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(objectValue));
                                        if (!flag2)
                                        {
                                            goto IL_982;
                                        }
                                        flag = Operators.ConditionalCompareObjectEqual(objectValue, "ES_MAP", false);
                                        if (!flag)
                                        {
                                            goto IL_982;
                                        }
                                        continue;
                                        IL_982:
                                        try
                                        {
                                            OleDbCommand oleDbCommand3 = new OleDbCommand();
                                            oleDbCommand3.Connection = oleDbConnection;
                                            oleDbCommand3.CommandText = "SELECT OBJECTID, SUBBLKTYP, BLKNUMBER, MC5LEN, USERNAME, BLOCKFNAME, BLOCKNAME, VERSION  FROM SUBBLK.DBF WHERE SUBBLKTYP = '00010' AND BLKNUMBER = '" + str + "' ";
                                            OleDbDataReader oleDbDataReader3 = oleDbCommand3.ExecuteReader();
                                            oleDbDataReader3.Read();
                                            flag2 = Information.IsDBNull(RuntimeHelpers.GetObjectValue(oleDbDataReader2["MC5CODE"]));
                                            if (!flag2)
                                            {
                                                object objectValue2;
                                                try
                                                {
                                                    objectValue2 = RuntimeHelpers.GetObjectValue(oleDbDataReader2["MC5CODE"]);
                                                }
                                                catch (Exception expr_9F7)
                                                {
                                                    ProjectData.SetProjectError(expr_9F7);
                                                    ProjectData.ClearProjectError();
                                                    continue;
                                                }
                                                string[] array2 = (string[])NewLateBinding.LateGet(objectValue2, null, "Split", new object[]
                                                {
                                                    "\r\n"
                                                }, null, null, null);
                                                flag2 = (array2.GetUpperBound(0) > 1);
                                                if (flag2)
                                                {
                                                    flag = !LikeOperator.LikeString(array2[1], "*VAR*", CompareMethod.Binary);
                                                    if (flag)
                                                    {
                                                        OleDbDataReader oleDbDataReader4 = new OleDbCommand
                                                        {
                                                            Connection = oleDbConnection,
                                                            CommandText = "SELECT OBJECTID, SSBPART, BLKNUMBER  FROM SUBBLK.DBF WHERE SUBBLKTYP = '00020' AND BLKNUMBER = '" + str + "' "
                                                        }.ExecuteReader();
                                                        oleDbDataReader4.Read();
                                                        object objectValue3 = RuntimeHelpers.GetObjectValue(oleDbDataReader4[1]);
                                                        clsDb clsDb = new clsDb(oleDbDataReader3, RuntimeHelpers.GetObjectValue(objectValue3), clsBlockCont2.Directory);
                                                        flag2 = (Operators.CompareString(clsBlockCont2.SymbolDirectory, "", false) != 0);
                                                        if (flag2)
                                                        {
                                                            try
                                                            {
                                                                oleDbConnection2.Open();
                                                                oleDbCommand2.Connection = oleDbConnection2;
                                                                oleDbCommand2.CommandText = "SELECT [_SKZ], [_COMMENT] FROM SYMLIST.DBF WHERE ([_OPCODE] = 5) AND ([_OPBYTEO] = " + Conversions.ToString(clsDb.Number) + ")";
                                                                OleDbDataReader oleDbDataReader5 = oleDbCommand2.ExecuteReader();
                                                                flag2 = (oleDbConnection2.State == ConnectionState.Open);
                                                                if (flag2)
                                                                {
                                                                    oleDbDataReader5.Read();
                                                                    string text3 = oleDbDataReader5[0].ToString();
                                                                    string text4 = oleDbDataReader5[1].ToString();
                                                                    byte[] bytes2 = this.enc.GetBytes(text3);
                                                                    text3 = this.enc2.GetString(bytes2);
                                                                    byte[] bytes3 = this.enc.GetBytes(text4);
                                                                    text4 = this.enc2.GetString(bytes3);
                                                                    flag2 = !Information.IsDBNull(text3);
                                                                    if (flag2)
                                                                    {
                                                                        clsDb.Symbol = text3;
                                                                        clsDb.SymbolComment = text4;
                                                                    }
                                                                }
                                                                oleDbConnection2.Close();
                                                            }
                                                            catch (Exception expr_BD0)
                                                            {
                                                                ProjectData.SetProjectError(expr_BD0);
                                                                oleDbConnection2.Close();
                                                                ProjectData.ClearProjectError();
                                                            }
                                                        }
                                                        clsBlockCont2.Dbs.Add(clsDb, null, null, null);
                                                        num2++;
                                                        this.tstStatus.Text = "DB " + Conversions.ToString(clsDb.Number);
                                                        this.tpbProgress.Value = num2;
                                                        this.Update();
                                                    }
                                                }
                                                oleDbDataReader3.Close();
                                                oleDbDataReader3 = null;
                                                oleDbCommand3.Dispose();
                                            }
                                        }
                                        catch (Exception expr_C4D)
                                        {
                                            ProjectData.SetProjectError(expr_C4D);
                                            ProjectData.ClearProjectError();
                                        }
                                    }
                                }
                                oleDbConnection.Close();
                            }
                        }
                        finally
                        {
                            //IEnumerator enumerator2;
                            flag2 = (enumerator2 is IDisposable);
                            if (flag2)
                            {
                                (enumerator2 as IDisposable).Dispose();
                            }
                        }
                        File.Delete(System.Windows.Forms.Application.StartupPath + "\\SYMLIST.DBF");
                        this.tstStatus.Text = Conversions.ToString(num2) + " Data blocks found";
                        flag2 = (this.lbxBlockCont.Items.Count > 0);
                        if (flag2)
                        {
                            this.lbxBlockCont.SelectedIndex = 0;
                        }
                        flag2 = (this.lbxDbs.Items.Count > 0);
                        if (flag2)
                        {
                            this.lbxDbs.SelectedIndex = 0;
                        }
                        this.tpbProgress.Value = 0;
                        this.Cursor = Cursors.Arrow;
                    }
                }
            }
        }

        public string[] GetUDT(int UdtNumber)
        {
            OleDbConnection oleDbConnection = new OleDbConnection();
            OleDbCommand oleDbCommand = new OleDbCommand();
            oleDbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.ActDirectory + ";Extended Properties=dBASE IV;";
            oleDbConnection.Open();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "SELECT OBJECTID, BLKNUMBER, MC5CODE  FROM SUBBLK.DBF WHERE SUBBLKTYP = '00001' AND BLKNUMBER = '" + UdtNumber.ToString("D5") + "'";
            OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            oleDbDataReader.Read();
            bool hasRows = oleDbDataReader.HasRows;
            string[] array;
            if (hasRows)
            {
                object objectValue = RuntimeHelpers.GetObjectValue(oleDbDataReader["MC5CODE"]);
                oleDbConnection.Close();
                array = (string[])NewLateBinding.LateGet(objectValue, null, "Split", new object[]
                {
                    "\r\n"
                }, null, null, null);
            }
            else
            {
                MessageBox.Show("UDT" + Conversions.ToString(UdtNumber) + " not found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                array = new string[]
                {
                    "",
                    ""
                };
            }
            string[] result = array;
            oleDbConnection.Close();
            return result;
        }

        private void OpenExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num = 0;
            this.OpenFileDialog1.FileName = "";
            this.OpenFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files (*.xls)|*.xls";
            bool flag = Operators.CompareString(this.DirExcel, "", false) == 0;
            if (flag)
            {
                this.OpenFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            }
            else
            {
                this.OpenFileDialog1.InitialDirectory = this.DirExcel;
            }
            DialogResult dialogResult = this.OpenFileDialog1.ShowDialog();
            flag = (dialogResult != DialogResult.OK);
            checked
            {
                if (!flag)
                {
                    string fileName = this.OpenFileDialog1.FileName;
                    this.DirExcel = Path.GetDirectoryName(fileName);
                    this.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(this.myText, "    "), Path.GetFileName(fileName)));
                    this.Cursor = Cursors.WaitCursor;
                    IEnumerator enumerator = this.Containers.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            clsBlockCont clsBlockCont = (clsBlockCont)enumerator.Current;
                            clsBlockCont.Dbs.Clear();
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
                    this.Containers.Clear();
                    this.lbxBlockCont.Items.Clear();
                    this.lbxDbs.Items.Clear();
                    this.lbxSelDbs.Items.Clear();
                    Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Workbook workbook = application.Workbooks.Open(fileName, 2, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    FileInfo fileInfo = new FileInfo(fileName);
                    string name = fileInfo.Name;
                    clsBlockCont clsBlockCont2 = new clsBlockCont(name);
                    this.lbxBlockCont.Items.Add(clsBlockCont2);
                    IEnumerator enumerator2 = application.Sheets.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            Worksheet worksheet = (Worksheet)enumerator2.Current;
                            flag = Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(worksheet.get_Range("A1", Missing.Value).Text, "DB-Number", false)));
                            if (!flag)
                            {
                                flag = !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(worksheet.get_Range("B1", Missing.Value).Text));
                                if (!flag)
                                {
                                    this.tstStatus.Text = Conversions.ToString(Operators.ConcatenateObject("Read DB", worksheet.get_Range("B1", Missing.Value).Text));
                                    this.Update();
                                    num++;
                                    clsDb clsDb = new clsDb(Conversions.ToInteger(worksheet.get_Range("B1", Missing.Value).Text), Conversions.ToString(worksheet.get_Range("B2", Missing.Value).Text), Conversions.ToString(worksheet.get_Range("B3", Missing.Value).Text), Conversions.ToString(worksheet.get_Range("B4", Missing.Value).Text), Conversions.ToString(worksheet.get_Range("B5", Missing.Value).Text), Conversions.ToString(worksheet.get_Range("B6", Missing.Value).Text));
                                    clsBlockCont2.Dbs.Add(clsDb, null, null, null);
                                    int value = 9;
                                    frmMain.Address address = default(frmMain.Address);
                                    address.ByteNumber = 0;
                                    address.BitNumber = 0;
                                    while (Operators.ConditionalCompareObjectNotEqual(worksheet.get_Range("B" + Conversions.ToString(value), Missing.Value).Text, "", false))
                                    {
                                        clsTag item = new clsTag(ref worksheet, ref value, ref address);
                                        clsDb.Tags.Add(item, null, null, null);
                                    }
                                    clsDb.Length = address.ByteNumber;
                                    clsDb.ReadDone = true;
                                }
                            }
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
                    workbook.Close(Missing.Value, Missing.Value, Missing.Value);
                    application.Workbooks.Close();
                    application.Quit();
                    frmMain.killExcelInstanceById(ref application);
                    flag = (this.lbxBlockCont.Items.Count > 0);
                    if (flag)
                    {
                        this.lbxBlockCont.SelectedIndex = 0;
                    }
                    this.tstStatus.Text = Conversions.ToString(num) + " Data blocks found";
                    Thread.CurrentThread.CurrentCulture = currentCulture;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void CreateExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateExcel();
        }

        private void CreateCSHarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true,
            };
            var res = fbd.ShowDialog();
            if (res != DialogResult.OK)
                return;

            Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            try
            {
                var root = fbd.SelectedPath;
                var dbs = CSharpHelper.CreateCSharp(lbxSelDbs.Items.Cast<clsDb>()); //CreateCSharp();
                foreach (var pair in dbs)
                {
                    var name = pair.Key;
                    var sb = pair.Value;

                    var fpath = Path.Combine(root, name + ".cs");
                    if (File.Exists(fpath))
                        File.Delete(fpath);

                    //var bytes = Encoding.UTF8.GetBytes(sb.ToString());
                    File.WriteAllText(fpath, sb.ToString());
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                this.Enabled = true;
            }

            Process.Start("explorer", fbd.SelectedPath);
        }

        #region CSHARP HELPER

//        public Dictionary<string, StringBuilder> CreateCSharp()
//        {
//            var items = lbxSelDbs.Items.Cast<clsDb>();
//            if (items == null)
//                return null;

//            var dict = new Dictionary<string, StringBuilder>();

//            dict["DBBase"] = new StringBuilder(@"
//using System;
//
//public class DBBase
//{ }
//
//public class S7DBAttribute : System.Attribute
//{
//    public int DB { get; set; }
//}
//
//public class S7ArrayAttribute : System.Attribute
//{
//    public int Count { get; set; }
//}
//");

//            foreach (var db in items)
//            {
//                try
//                {
//                    //Console.WriteLine("DB{0} - {1} - {2}", db.Number, db.Symbol, db.SymbolComment);
//                    var sb = new StringBuilder();

//                    var className = db.Symbol.Replace(" ", "");
//                    var comment = createComment(db, "");
//                    sb.Append(comment);
//                    sb.AppendFormat(@"[S7DB(DB = {1})]
//public class {0}: DBBase // DB{1}
//{{", className, db.Number);
//                    var tags = db.Tags.Cast<clsTag>();
//                    sb.Append(parseTags(tags));
//                    sb.Append("\r\n}");

//                    Console.WriteLine(sb);
//                    Console.WriteLine("-------");

//                    dict[string.Format("DB{0}", db.Number)] = sb;
//                }
//                catch (Exception exc)
//                {
//                    throw exc;
//                }
//            }

//            return dict;
//        }

//        Dictionary<string, string> typeConverter = new Dictionary<string, string>()
//        {
//            {"INT", "short"},
//            {"BOOL", "bool"},
//            {"DINT", "int"},
//            {"REAL", "double"},
//            {"BYTE", "byte"},
//            {"WORD", "ushort"},
//            {"CHAR", "byte"},
//            {"TIME", "int"},
//            {"DWORD", "uint"},
//            {"DATE_AND_TIME", "DateTime"},
//            //{"", ""},
//            //{"", ""},
//            //{"", ""},
//            //{"", ""},// = new
//            //{"", ""},
//            //{"", ""},
//        };

//        StringBuilder createComment(IComment tag, string tabs)
//        {
//            var sb = new StringBuilder();
//            var comment = tag.Comment.Replace('\0', ' ');
//            sb.AppendFormat("\r\n{0}/// <summary>\r\n", tabs);
//            sb.AppendFormat(tabs + "/// {0}\r\n", comment);
//            sb.AppendLine(tabs + "/// </summary>");
//            return sb;
//        }

//        StringBuilder parseTags(IEnumerable<clsTag> tags, int nestCount = 1)
//        {
//            var tabs = Enumerable.Range(0, nestCount).Select(i => "\t").Aggregate("", (s1, s2) => s1 + s2);
//            var sb = new StringBuilder();
//            foreach (var tag in tags)
//            {
//                //Console.WriteLine("\t{0} {1} {{ get; set; }} // {2}", tag.DataType, tag.Name, tag.Comment);

//                sb.Append(createComment(tag, tabs));
//                if (tag.DataType.StartsWith("UDT") || tag.DataType.StartsWith("STRUCT"))
//                {
//                    //sb.Append(createComment(tag, tabs));
//                    var className = "T_" + tag.Name;
//                    sb.AppendFormat("{0}public class {1}", tabs, className);
//                    var innerTags = parseTags(tag.Tags.Cast<clsTag>(), nestCount + 1);
//                    sb.AppendLine(tabs + "{");
//                    sb.Append(innerTags);
//                    sb.AppendLine(tabs + "}");
//                    sb.AppendFormat(@"
//{0}public {1} {2} {{ get; set; }}", tabs, className, tag.Name);
//                }
//                else if (tag.DataType.StartsWith("ARRAY"))
//                {
//                    int count = 0;
//                    string @type = "";

//                    var m = Regex.Match(tag.DataType, @"ARRAY\s.\[(\d*) \.* (\d*) \] OF (\w*)");
//                    if (m.Success)
//                    {
//                        count = int.Parse(m.Groups[2].Value);
//                        @type = m.Groups[3].Value;
//                    }
//                    else
//                    {
//                        count = tag.Tags.Count;
//                        @type = (tag.Tags[1] as clsTag).DataType;
//                    }

//                    //sb.Append(createComment(tag, tabs));
//                    if (!typeConverter.ContainsKey(@type))
//                        throw new Exception(string.Format("Type not found: {0}", @type));

//                    //sb.AppendFormat("{0}[S7Array(Count = {1})]\r\n", tabs, count);
//                    sb.AppendFormat(@"
//{0}protected {1} [] __{2} = new {1}[{3}];
//{0}[S7Array(Count = {3})]
//{0}public {1} [] {2} {{ get {{ return __{2}; }} set {{ __{2} = value; }} }} // = new {1}[{3}];\r\n", tabs, typeConverter[@type], tag.Name, count);
//                }
//                else if (tag.DataType.StartsWith("STRING"))
//                {
//                    //sb.Append(createComment(tag, tabs));
//                    sb.AppendFormat(tabs + "public string {0} {{ get; set; }}\r\n\r\n", tag.Name);
//                }
//                else
//                {
//                    if (!typeConverter.ContainsKey(tag.DataType))
//                        throw new Exception(string.Format("Type not found: {0}", tag.DataType));

//                    //sb.Append(createComment(tag, tabs));
//                    sb.AppendFormat(tabs + "public {0} {1} {{ get; set; }}\r\n\r\n", typeConverter[tag.DataType], tag.Name);
//                }
//            }

//            return sb;
//        } 
        #endregion

        public void CreateExcel()
        {
            int num2=0;
            int num3=0;
            try
            {
                IL_01:
                int num = 1;
                IL_07:
                num = 2;
                string text = "";
                IL_10:
                num = 3;
                this.Cursor = Cursors.WaitCursor;
                IL_1F:
                num = 4;
                this.Update();
                IL_29:
                num = 5;
                this.Excel1 = new ApplicationClass();
                IL_37:
                num = 6;
                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                IL_45:
                num = 7;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                IL_5D:
                num = 8;
                Workbook workbook = this.Excel1.Workbooks.Add(Missing.Value);
                IL_77:
                num = 9;
                this.FillExcelRunning = true;
                IL_82:
                num = 10;
                IEnumerator enumerator = this.lbxSelDbs.Items.GetEnumerator();
                bool flag;
                while (enumerator.MoveNext())
                {
                    clsDb clsDb = (clsDb)enumerator.Current;
                    IL_AB:
                    num = 11;
                    this.tstStatus.Text = "Generate DB" + Conversions.ToString(clsDb.Number);
                    IL_D1:
                    num = 12;
                    int numberOfTags = clsDb.NumberOfTags;
                    IL_DE:
                    num = 13;
                    this.tpbProgress.Maximum = numberOfTags;
                    IL_F0:
                    num = 14;
                    this.Update();
                    IL_FB:
                    num = 15;
                    workbook.Sheets.Add(Missing.Value, RuntimeHelpers.GetObjectValue(workbook.Sheets[workbook.Sheets.Count]), Missing.Value, Missing.Value);
                    IL_13D:
                    num = 16;
                    flag = (Operators.CompareString(text, "", false) != 0);
                    if (flag)
                    {
                        IL_159:
                        num = 17;
                        text += "_";
                    }
                    IL_169:
                    num = 19;
                    text = text + "DB" + Conversions.ToString(clsDb.Number);
                    IL_185:
                    num = 20;
                    Worksheet worksheet = (Worksheet)workbook.ActiveSheet;
                    IL_197:
                    num = 21;
                    worksheet.Outline.SummaryRow = XlSummaryRow.xlSummaryAbove;
                    IL_1A9:
                    num = 22;
                    this.ExcelZeile = 9;
                    IL_1B5:
                    num = 23;
                    this.CreateHead(worksheet, clsDb);
                    IL_1C4:
                    num = 24;
                    clsDb.FillExcel(worksheet, this.ExcelZeile);
                    IL_1D8:
                    num = 25;
                }
                flag = (enumerator is IDisposable);
                if (flag)
                {
                    (enumerator as IDisposable).Dispose();
                }
                IL_20E:
                num = 26;
                this.FillExcelRunning = false;
                IL_219:
                num = 27;
                this.tstStatus.Text = "Save file";
                IL_22E:
                num = 28;
                this.Update();
                IL_239:
                num = 29;
                IEnumerator enumerator2 = workbook.Worksheets.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    Worksheet worksheet2 = (Worksheet)enumerator2.Current;
                    IL_25B:
                    num = 30;
                    flag = (workbook.Sheets.Count > 1 & !LikeOperator.LikeString(worksheet2.Name, "DB*", CompareMethod.Binary));
                    if (flag)
                    {
                        IL_28A:
                        num = 31;
                        worksheet2.Delete();
                    }
                    IL_296:
                    IL_297:
                    num = 33;
                }
                flag = (enumerator2 is IDisposable);
                if (flag)
                {
                    (enumerator2 as IDisposable).Dispose();
                }
                IL_2CA:
                num = 34;
                this.Cursor = Cursors.Arrow;
                IL_2DA:
                num = 35;
                this.Update();
                string value;
                while (true)
                {
                    IL_2E7:
                    num = 36;
                    this.SaveFileDialog1.FileName = text;
                    IL_2F8:
                    num = 37;
                    this.SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    IL_30D:
                    num = 38;
                    flag = (Operators.CompareString(this.DirExcel, "", false) == 0);
                    if (flag)
                    {
                        IL_32B:
                        num = 39;
                        this.SaveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
                        IL_340:;
                    }
                    else
                    {
                        IL_342:
                        num = 41;
                        IL_347:
                        num = 42;
                        this.SaveFileDialog1.InitialDirectory = this.DirExcel;
                    }
                    IL_35D:
                    IL_35E:
                    num = 44;
                    value = Conversions.ToString((int)this.SaveFileDialog1.ShowDialog());
                    IL_373:
                    num = 45;
                    flag = (Conversions.ToDouble(value) != 1.0);
                    if (flag)
                    {
                        break;
                    }
                    IL_396:
                    num = 48;
                    this.filename = this.SaveFileDialog1.FileName;
                    IL_3AB:
                    num = 49;
                    flag = (Operators.CompareString(this.filename, "", false) == 0);
                    if (flag)
                    {
                        goto IL_3C9;
                    }
                    IL_3CF:
                    num = 52;
                    this.DirExcel = Path.GetDirectoryName(this.filename);
                    IL_3E4:
                    num = 53;
                    FileInfo fileInfo = new FileInfo(this.filename);
                    IL_3F4:
                    num = 54;
                    this.Excel1.DisplayAlerts = false;
                    IL_405:
                    ProjectData.ClearProjectError();
                    num2 = -2;
                    IL_40E:
                    num = 56;
                    workbook.SaveAs(this.filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    IL_453:
                    num = 57;
                    flag = (Information.Err().Number > 0);
                    if (!flag)
                    {
                        goto IL_4B2;
                    }
                    IL_46A:
                    num = 58;
                    string text2 = "File " + this.filename + " is read only\r\n";
                    IL_485:
                    num = 59;
                    DialogResult dialogResult = MessageBox.Show(text2, "File exist", MessageBoxButtons.RetryCancel);
                    IL_498:
                    num = 60;
                    flag = (dialogResult == DialogResult.Cancel);
                    if (flag)
                    {
                        goto IL_4A7;
                    }
                    IL_4AD:;
                }
                IL_391:
                goto IL_4E1;
                IL_3C9:
                IL_4A7:
                goto IL_70B;
                IL_4B2:
                IL_4B3:
                ProjectData.ClearProjectError();
                num2 = 0;
                IL_4BB:
                num = 66;
                this.Excel1.Workbooks.Close();
                IL_4D0:
                num = 67;
                this.Excel1.Quit();
                IL_4E1:
                IL_4E2:
                num = 68;
                frmMain.killExcelInstanceById(ref this.Excel1);
                IL_4F2:
                num = 69;
                flag = (Conversions.ToDouble(value) == 1.0);
                if (!flag)
                {
                    goto IL_531;
                }
                IL_50D:
                num = 70;
                frmMessage frmMessage = new frmMessage();
                IL_518:
                num = 71;
                frmMessage.StartPosition = FormStartPosition.CenterParent;
                IL_525:
                num = 72;
                frmMessage.ShowDialog();
                IL_531:
                IL_532:
                num = 74;
                this.tstStatus.Text = "Finish";
                IL_547:
                num = 75;
                this.Update();
                IL_552:
                num = 76;
                this.FillExcelRunning = false;
                IL_55D:
                num = 77;
                Thread.CurrentThread.CurrentCulture = currentCulture;
                IL_56D:
                goto IL_70B;
                IL_576:
                int arg_57D_0 = num3 + 1;
                num3 = 0;
                //@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], arg_57D_0);
                IL_6BE:
                goto IL_700;
                num3 = num;
                //@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
                IL_6DC:
                goto IL_700;
            }
            catch (Exception) { }
            object arg_6DE_0;
            //endfilter(arg_6DE_0 is Exception & num2 != 0 & num3 == 0);
            IL_700:
            throw ProjectData.CreateProjectError(-2146828237);
            IL_70B:
            if (num3 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }

        public void CreateHead(Worksheet xlsTabBlatt, clsDb db)
        {
            xlsTabBlatt.Name = "DB" + Conversions.ToString(db.Number);
            NewLateBinding.LateSetComplex(xlsTabBlatt.Columns["A:C", Missing.Value], null, "ColumnWidth", new object[]
            {
                20
            }, null, null, false, true);
            NewLateBinding.LateSetComplex(xlsTabBlatt.Columns["D:E", Missing.Value], null, "ColumnWidth", new object[]
            {
                16
            }, null, null, false, true);
            NewLateBinding.LateSetComplex(xlsTabBlatt.Columns["F:F", Missing.Value], null, "ColumnWidth", new object[]
            {
                70
            }, null, null, false, true);
            NewLateBinding.LateSetComplex(xlsTabBlatt.Columns["G:G", Missing.Value], null, "ColumnWidth", new object[]
            {
                20
            }, null, null, false, true);
            NewLateBinding.LateSetComplex(xlsTabBlatt.Columns["A:F", Missing.Value], null, "NumberFormat", new object[]
            {
                "@"
            }, null, null, false, true);
            Range range = xlsTabBlatt.get_Range(RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[1, 1]), RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[8, 6]));
            range.Font.Bold = true;
            range = xlsTabBlatt.get_Range(RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[1, 1]), RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[8, 1]));
            range.Font.Size = 12;
            range = xlsTabBlatt.get_Range(RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[8, 1]), RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[8, 6]));
            range.Font.Size = 12;
            range.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, Missing.Value);
            range = xlsTabBlatt.get_Range(RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[1, 2]), RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[6, 6]));
            range.Interior.ColorIndex = 35;
            range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlDash;
            range.Font.ColorIndex = 41;
            range = xlsTabBlatt.get_Range(RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[1, 5]), RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[2, 5]));
            range.Font.Size = 12;
            range.Interior.ColorIndex = 2;
            range.Font.ColorIndex = 1;
            range = xlsTabBlatt.get_Range(RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[1, 1]), RuntimeHelpers.GetObjectValue(xlsTabBlatt.Cells[8, 6]));
            range[1, 1] = "DB-Number";
            range[1, 2] = db.Number;
            range[2, 1] = "DB-Comment";
            range[2, 2] = db.Comment;
            range[3, 1] = "AUTHOR";
            range[3, 2] = db.Author;
            range[4, 1] = "Family";
            range[4, 2] = db.Family;
            range[5, 1] = "NAME";
            range[5, 2] = db.Name;
            range[6, 1] = "VERSION";
            range[6, 2] = db.Version;
            range[1, 5] = "Symbol";
            range[1, 6] = db.Symbol;
            range[2, 5] = "Symbol comment";
            range[2, 6] = db.SymbolComment;
            range[8, 1] = "DB-Adresse";
            range[8, 2] = "Name";
            range[8, 3] = "Type";
            range[8, 4] = "Initial Value";
            range[8, 5] = "Actual Value";
            range[8, 6] = "Comment";
        }

        private void CreateAWLSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int num2=0;
            int num3=0;
            try
            {
                IL_01:
                int num = 1;
                string text = "DB";
                IL_0A:
                num = 2;
                IEnumerator enumerator = this.lbxSelDbs.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    clsDb clsDb = (clsDb)enumerator.Current;
                    IL_2F:
                    num = 3;
                    text = text + "_" + Conversions.ToString(clsDb.Number);
                    IL_4A:
                    num = 4;
                }
                bool flag = enumerator is IDisposable;
                if (flag)
                {
                    (enumerator as IDisposable).Dispose();
                }
                StreamWriter streamWriter;
                while (true)
                {
                    IL_7E:
                    num = 5;
                    this.SaveFileDialog1.FileName = text;
                    IL_8E:
                    num = 6;
                    this.SaveFileDialog1.Filter = "AWL sources (*.awl)|*.awl";
                    IL_A2:
                    num = 7;
                    flag = (Operators.CompareString(this.DirAwl, "", false) == 0);
                    if (flag)
                    {
                        IL_BF:
                        num = 8;
                        this.SaveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
                        IL_D3:;
                    }
                    else
                    {
                        IL_D5:
                        num = 10;
                        IL_DA:
                        num = 11;
                        this.SaveFileDialog1.InitialDirectory = this.DirAwl;
                    }
                    IL_F0:
                    IL_F1:
                    num = 13;
                    string value = Conversions.ToString((int)this.SaveFileDialog1.ShowDialog());
                    IL_106:
                    num = 14;
                    flag = (Conversions.ToDouble(value) != 1.0);
                    if (flag)
                    {
                        break;
                    }
                    IL_12A:
                    num = 17;
                    this.filename = this.SaveFileDialog1.FileName;
                    IL_13F:
                    num = 18;
                    flag = (Operators.CompareString(this.filename, "", false) == 0);
                    if (flag)
                    {
                        break;
                    }
                    IL_163:
                    num = 21;
                    this.DirAwl = Path.GetDirectoryName(this.filename);
                    IL_178:
                    num = 22;
                    FileInfo fileInfo = new FileInfo(this.filename);
                    IL_188:
                    ProjectData.ClearProjectError();
                    num2 = -2;
                    IL_191:
                    num = 24;
                    streamWriter = fileInfo.CreateText();
                    IL_19C:
                    num = 25;
                    flag = (Information.Err().Number > 0);
                    if (!flag)
                    {
                        goto IL_1FB;
                    }
                    IL_1B3:
                    num = 26;
                    string text2 = "File " + this.filename + " is read only\r\n";
                    IL_1CE:
                    num = 27;
                    DialogResult dialogResult = MessageBox.Show(text2, "File exist", MessageBoxButtons.RetryCancel);
                    IL_1E1:
                    num = 28;
                    flag = (dialogResult == DialogResult.Cancel);
                    if (flag)
                    {
                        break;
                    }
                    IL_1F6:;
                }
                IL_124:
                IL_15D:
                IL_1F0:
                goto IL_373;
                IL_1FB:
                IL_1FC:
                ProjectData.ClearProjectError();
                num2 = 0;
                IL_204:
                num = 34;
                IEnumerator enumerator2 = this.lbxSelDbs.Items.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    clsDb clsDb2 = (clsDb)enumerator2.Current;
                    IL_22A:
                    num = 35;
                    clsDb2.WriteAwl(streamWriter);
                    IL_237:
                    num = 36;
                }
                flag = (enumerator2 is IDisposable);
                if (flag)
                {
                    (enumerator2 as IDisposable).Dispose();
                }
                IL_26A:
                num = 37;
                streamWriter.Close();
                IL_275:
                goto IL_373;
                IL_27E:
                int arg_285_0 = num3 + 1;
                num3 = 0;
                //@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], arg_285_0);
                IL_326:
                goto IL_368;
                num3 = num;
                //@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num2 > -2) ? num2 : 1);
                IL_344:
                goto IL_368;
            }
            catch (Exception) { }
            object arg_346_0;
            //endfilter(arg_346_0 is Exception & num2 != 0 & num3 == 0);
            IL_368:
            throw ProjectData.CreateProjectError(-2146828237);
            IL_373:
            if (num3 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }

        private void ActualValuesInitialValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerator enumerator = this.lbxSelDbs.Items.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    clsDb clsDb = (clsDb)enumerator.Current;
                    IEnumerator enumerator2 = clsDb.Tags.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            clsTag clsTag = (clsTag)enumerator2.Current;
                            clsTag.CopyActualToInitial();
                        }
                    }
                    finally
                    {
                        bool flag = enumerator2 is IDisposable;
                        if (flag)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
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
            this.BuildTree();
        }

        private void ReadActualValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = this.lbxBlockCont.SelectedItem != null;
            if (flag)
            {
                clsBlockCont clsBlockCont = (clsBlockCont)this.lbxBlockCont.SelectedItem;
                frmCpuProp frmCpuProp = new frmCpuProp(ref clsBlockCont);
                DialogResult dialogResult = frmCpuProp.ShowDialog();
                flag = (dialogResult == DialogResult.OK);
                if (flag)
                {
                    string text = "";
                    flag = (clsBlockCont.Connect(ref text) < 0);
                    if (!flag)
                    {
                        IEnumerator enumerator = this.lbxSelDbs.Items.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                clsDb clsDb = (clsDb)enumerator.Current;
                                clsDb arg_99_0 = clsDb;
                                clsBlockCont clsBlockCont2 = clsBlockCont;
                                libnodave.daveConnection dc = clsBlockCont2.dc;
                                arg_99_0.ReadActVal(ref dc);
                                clsBlockCont2.dc = dc;
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
                        clsBlockCont.Disconnect();
                        EventArgs e2 = new EventArgs();
                        this.lbxSelDbs_SelectedIndexChanged(this.lbxSelDbs, e2);
                    }
                }
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmHelp
            {
                StartPosition = FormStartPosition.CenterParent
            }.ShowDialog();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            Collection collection = new Collection();
            int selectedIndex = this.lbxDbs.SelectedIndex;
            int num = 0;
            bool flag;
            IEnumerator enumerator = this.lbxDbs.SelectedItems.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    clsDb item = (clsDb)enumerator.Current;
                    collection.Add(item, null, null, null);
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
            IEnumerator enumerator2 = collection.GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    clsDb clsDb = (clsDb)enumerator2.Current;
                    this.ActDirectory = clsDb.Directory;
                    num = this.lbxSelDbs.Items.Add(clsDb);
                    this.lbxDbs.Items.Remove(clsDb);
                    flag = !clsDb.ReadDone;
                    if (flag)
                    {
                        this.ReadDb(clsDb);
                    }
                    this.Update();
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
            flag = (this.lbxSelDbs.Items.Count > num);
            if (flag)
            {
                this.lbxSelDbs.SelectedIndex = num;
            }
            flag = (this.lbxDbs.Items.Count > selectedIndex);
            if (flag)
            {
                this.lbxDbs.SelectedIndex = selectedIndex;
            }
            else
            {
                this.lbxDbs.SelectedIndex = checked(this.lbxDbs.Items.Count - 1);
            }
        }

        private void ReadDb(clsDb db)
        {
            OleDbConnection oleDbConnection = new OleDbConnection();
            OleDbCommand oleDbCommand = new OleDbCommand();
            OleDbCommand oleDbCommand2 = new OleDbCommand();
            oleDbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + db.Directory + ";Extended Properties=dBASE IV";
            oleDbConnection.Open();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "SELECT MC5CODE  FROM SUBBLK.DBF WHERE SUBBLKTYP = '00006' AND BLKNUMBER = '" + db.Number.ToString("D5") + "'";
            OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
            oleDbDataReader.Read();
            object objectValue = RuntimeHelpers.GetObjectValue(oleDbDataReader["MC5CODE"]);
            string[] s = (string[])NewLateBinding.LateGet(objectValue, null, "Split", new object[]
            {
                "\r\n"
            }, null, null, null);
            db.Fill(s);
            oleDbCommand2.Connection = oleDbConnection;
            oleDbCommand2.CommandText = "SELECT MC5CODE  FROM SUBBLK.DBF WHERE SUBBLKTYP = '00010' AND BLKNUMBER = '" + db.Number.ToString("D5") + "'";
            OleDbDataReader oleDbDataReader2 = oleDbCommand2.ExecuteReader();
            oleDbDataReader2.Read();
            string s2 = "";
            bool flag = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(oleDbDataReader2["MC5CODE"]));
            if (flag)
            {
                s2 = Conversions.ToString(oleDbDataReader2["MC5CODE"]);
            }
            byte[] bytes = this.enc.GetBytes(s2);
            db.GetActVal(bytes);
            oleDbConnection.Close();
            flag = (this.lbxSelDbs.Items.Count > 0);
            if (flag)
            {
                this.lbxSelDbs.SelectedIndex = 0;
            }
            db.ReadDone = true;
        }

        private void btnDesel_Click(object sender, EventArgs e)
        {
            Collection collection = new Collection();
            IEnumerator enumerator = this.lbxSelDbs.SelectedItems.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    clsDb item = (clsDb)enumerator.Current;
                    collection.Add(item, null, null, null);
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
            int selectedIndex = this.lbxSelDbs.SelectedIndex;
            this.lbxDbs.SelectedIndex = -1;
            checked
            {
                bool flag;
                IEnumerator enumerator2 = collection.GetEnumerator();
                try
                {
                    while (enumerator2.MoveNext())
                    {
                        clsDb clsDb = (clsDb)enumerator2.Current;
                        int num = 0;
                        IEnumerator enumerator3 = this.lbxDbs.Items.GetEnumerator();
                        try
                        {
                            while (enumerator3.MoveNext())
                            {
                                clsDb clsDb2 = (clsDb)enumerator3.Current;
                                flag = (clsDb2.Number < clsDb.Number);
                                if (flag)
                                {
                                    num++;
                                }
                            }
                        }
                        finally
                        {
                            flag = (enumerator3 is IDisposable);
                            if (flag)
                            {
                                (enumerator3 as IDisposable).Dispose();
                            }
                        }
                        this.lbxDbs.Items.Insert(num, clsDb);
                        this.lbxDbs.SelectedIndex = num;
                        this.lbxSelDbs.Items.Remove(clsDb);
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
                flag = (selectedIndex >= this.lbxSelDbs.Items.Count);
                if (flag)
                {
                    this.lbxSelDbs.SelectedIndex = this.lbxSelDbs.Items.Count - 1;
                }
                else
                {
                    this.lbxSelDbs.SelectedIndex = selectedIndex;
                }
            }
        }

        public void FillSheet(string[] s, Worksheet xlsTabBlatt, ref long zeile, ref frmMain.Address myAddress, string prefix, byte[] act)
        {
        }

        public bool IsInCollection(ref Collection col, ref string key)
        {
            int num = 0;
            bool flag2 = false;
            int num3 = 0;
            try
            {
                IL_01:
                ProjectData.ClearProjectError();
                num = -2;
                IL_09:
                int num2 = 2;
                bool flag = col[key] != null;
                if (!flag)
                {
                    goto IL_30;
                }
                IL_20:
                num2 = 3;
                flag2 = (Information.Err().Number == 0);
                IL_30:
                ProjectData.ClearProjectError();
                num = 0;
                IL_37:
                goto IL_A9;
                IL_3C:
                int arg_41_0 = num3 + 1;
                num3 = 0;
                //@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], arg_41_0);
                IL_62:
                goto IL_9E;
                num3 = num2;
                //@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], (num > -2) ? num : 1);
                IL_7C:
                goto IL_9E;
            }
            catch (Exception) { }
            object arg_7E_0;
            //endfilter(arg_7E_0 is Exception & num != 0 & num3 == 0);
            IL_9E:
            throw ProjectData.CreateProjectError(-2146828237);
            IL_A9:
            bool arg_B2_0 = flag2;
            if (num3 != 0)
            {
                ProjectData.ClearProjectError();
            }
            return arg_B2_0;
        }

        private byte[] GetBytes(byte[] b)
        {
            checked
            {
                byte[] array = new byte[(int)Math.Round((double)b.GetUpperBound(0) / 2.0) + 1];
                int arg_2C_0 = 0;
                int num = array.GetUpperBound(0) - 2;
                int num2 = arg_2C_0;
                while (true)
                {
                    int arg_B2_0 = num2;
                    int num3 = num;
                    if (arg_B2_0 > num3)
                    {
                        break;
                    }
                    byte b2 = b[2 * num2 + 1];
                    bool flag = b2 == 0;
                    if (flag)
                    {
                        array[num2] = this.myCode[(int)b[2 * num2]];
                    }
                    else
                    {
                        flag = (b2 == 1);
                        if (flag)
                        {
                            array[num2] = this.myCode1[(int)b[2 * num2]];
                        }
                        else
                        {
                            flag = (b2 == 32);
                            if (flag)
                            {
                                array[num2] = 242;
                            }
                            else
                            {
                                flag = (b2 == 37);
                                if (flag)
                                {
                                    array[num2] = this.myCode37[(int)b[2 * num2]];
                                }
                            }
                        }
                    }
                    num2++;
                }
                return array;
            }
        }

        public void UpdateProgress(int zeile)
        {
            bool flag = zeile <= this.tpbProgress.Maximum;
            if (flag)
            {
                this.tpbProgress.Value = zeile;
            }
            else
            {
                this.tpbProgress.Value = this.tpbProgress.Maximum;
            }
            this.Update();
        }

        private void lbxSelDbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BuildTree();
        }

        private void BuildTree()
        {
            System.Windows.Forms.ListBox lbxSelDbs = this.lbxSelDbs;
            this.tvwDbTags.Nodes.Clear();
            this.tvwDbTags.ShowNodeToolTips = true;
            bool flag = lbxSelDbs.SelectedItem == null;
            if (!flag)
            {
                clsDb clsDb = (clsDb)lbxSelDbs.SelectedItem;
                IEnumerator enumerator = clsDb.Tags.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        clsTag clsTag = (clsTag)enumerator.Current;
                        TreeNode treeNode = this.tvwDbTags.Nodes.Add(clsTag.Name);
                        treeNode.ToolTipText = clsTag.ToolTip;
                        this.FillTree(clsTag, treeNode);
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
        }

        public void FillTree(clsTag myTag, TreeNode myTreeNode)
        {
            IEnumerator enumerator = myTag.Tags.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    clsTag clsTag = (clsTag)enumerator.Current;
                    TreeNode treeNode = myTreeNode.Nodes.Add(clsTag.Name);
                    treeNode.ToolTipText = clsTag.ToolTip;
                    this.FillTree(clsTag, treeNode);
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

        private void lbxBlockCont_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = this.lbxBlockCont.SelectedItem != null;
            if (flag)
            {
                clsBlockCont clsBlockCont = (clsBlockCont)this.lbxBlockCont.SelectedItem;
                flag = (this.lbxBlockCont.SelectedItem != this.SelItem);
                IEnumerator enumerator = clsBlockCont.Dbs.GetEnumerator();
                if (flag)
                {
                    this.lbxDbs.Items.Clear();
                    this.lbxSelDbs.Items.Clear();
                    this.tvwDbTags.Nodes.Clear();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            clsDb item = (clsDb)enumerator.Current;
                            this.lbxDbs.Items.Add(item);
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
                this.SelItem = (clsBlockCont)this.lbxBlockCont.SelectedItem;
            }
        }

        private void lbxDbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool flag = e.KeyChar == '\b';
            checked
            {
                if (flag)
                {
                    this.SelDbNumber = (int)Math.Round(Conversion.Int((double)this.SelDbNumber / 10.0));
                    IEnumerator enumerator = this.lbxDbs.Items.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            clsDb clsDb = (clsDb)enumerator.Current;
                            flag = LikeOperator.LikeString(Conversions.ToString(clsDb.Number), Conversions.ToString(this.SelDbNumber) + "*", CompareMethod.Binary);
                            if (flag)
                            {
                                this.lbxDbs.SelectedItem = clsDb;
                                goto IL_1AD;
                            }
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
                flag = Versioned.IsNumeric(e.KeyChar);
                bool flag2;
                if (flag)
                {
                    flag2 = (this.SelDbNumber < 1000);
                    IEnumerator enumerator2 = this.lbxDbs.Items.GetEnumerator();
                    if (flag2)
                    {
                        this.SelDbNumber = this.SelDbNumber * 10 + Conversion.Val(e.KeyChar);
                    }
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            clsDb clsDb2 = (clsDb)enumerator2.Current;
                            flag2 = LikeOperator.LikeString(Conversions.ToString(clsDb2.Number), Conversions.ToString(this.SelDbNumber) + "*", CompareMethod.Binary);
                            if (flag2)
                            {
                                this.lbxDbs.SelectedItems.Clear();
                                this.lbxDbs.SelectedItem = clsDb2;
                                break;
                            }
                        }
                    }
                    finally
                    {
                        flag2 = (enumerator2 is IDisposable);
                        if (flag2)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                }
                IL_1AD:
                flag2 = (Operators.CompareString(Conversions.ToString(e.KeyChar), 'C'.ToString().ToLower(), false) == 0);
                if (flag2)
                {
                    MessageBox.Show("Codepage is " + Conversions.ToString(frmMain.GetOEMCP() % 4096L), "Codepage", MessageBoxButtons.OK);
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            bool flag = this.seldb == this.SelDbNumber;
            checked
            {
                if (flag)
                {
                    this.count++;
                }
                else
                {
                    this.count = 0;
                }
                flag = (this.count > 5);
                if (flag)
                {
                    this.SelDbNumber = 0;
                    this.count = 5;
                }
                this.seldb = this.SelDbNumber;
            }
        }

        private void lbxBlockCont_MouseMove(object sender, MouseEventArgs e)
        {
            Monitor.Enter(this.Init);
            bool flag;
            try
            {
                flag = (this.Init.State == 0);
                if (flag)
                {
                    this.Init.State = 2;
                    this.LastIndex = -1;
                }
                else
                {
                    flag = (this.Init.State == 2);
                    if (flag)
                    {
                        throw new IncompleteInitialization();
                    }
                }
            }
            finally
            {
                this.Init.State = 1;
                Monitor.Exit(this.Init);
            }
            Type arg_9E_1 = null;
            string arg_9E_2 = "IndexFromPoint";
            object[] array = new object[1];
            object[] arg_98_0 = array;
            int arg_98_1 = 0;
            System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);
            arg_98_0[arg_98_1] = point;
            int num = Conversions.ToInteger(NewLateBinding.LateGet(sender, arg_9E_1, arg_9E_2, array, null, null, null));
            flag = (num != -1);
            if (flag)
            {
                bool flag2 = this.LastIndex != num;
                if (flag2)
                {
                    object arg_110_0 = NewLateBinding.LateGet(sender, null, "Items", new object[0], null, null, null);
                    Type arg_110_1 = null;
                    string arg_110_2 = "Item";
                    object[] array2 = new object[]
                    {
                        num
                    };
                    object[] arg_110_3 = array2;
                    string[] arg_110_4 = null;
                    Type[] arg_110_5 = null;
                    bool[] array3 = new bool[]
                    {
                        true
                    };
                    object arg_14D_0 = NewLateBinding.LateGet(arg_110_0, arg_110_1, arg_110_2, arg_110_3, arg_110_4, arg_110_5, array3);
                    if (array3[0])
                    {
                        num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(int));
                    }
                    string caption = Conversions.ToString(NewLateBinding.LateGet(arg_14D_0, null, "GetToolTip", new object[0], null, null, null));
                    this.ToolTip1.SetToolTip((Control)sender, caption);
                }
            }
            this.LastIndex = num;
        }

        private static void killExcelInstanceById(ref Microsoft.Office.Interop.Excel.Application xlsApp)
        {
            IntPtr intPtr = IntPtr.Zero;
            frmMain.GetWindowThreadProcessId(xlsApp.Hwnd, ref intPtr);
            Process processById = Process.GetProcessById(intPtr.ToInt32());
            processById.Kill();
        }

        private void SavePar()
        {
            string text = System.Windows.Forms.Application.StartupPath + "\\Config.xml";
            UnicodeEncoding encoding = new UnicodeEncoding();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(text, encoding);
            XmlTextWriter xmlTextWriter2 = xmlTextWriter;
            xmlTextWriter2.Formatting = Formatting.Indented;
            xmlTextWriter2.Indentation = 4;
            xmlTextWriter2.WriteStartDocument();
            xmlTextWriter2.WriteStartElement("Configuration");
            xmlTextWriter2.WriteStartElement("Directory");
            xmlTextWriter2.WriteAttributeString("Step7", this.DirStep7);
            xmlTextWriter2.WriteAttributeString("Excel", this.DirExcel);
            xmlTextWriter2.WriteAttributeString("Awl", this.DirAwl);
            xmlTextWriter2.WriteEndElement();
            xmlTextWriter2.WriteEndElement();
            xmlTextWriter2.Close();
        }

        private void LoadPar()
        {
            string text = System.Windows.Forms.Application.StartupPath + "\\Config.xml";
            bool flag = !File.Exists(text);
            if (!flag)
            {
                XmlTextReader xmlTextReader = new XmlTextReader(text);
                XmlTextReader xmlTextReader2 = xmlTextReader;
                while (xmlTextReader2.Read())
                {
                    XmlNodeType nodeType = xmlTextReader2.NodeType;
                    flag = (nodeType == XmlNodeType.Element);
                    if (flag)
                    {
                        string name = xmlTextReader2.Name;
                        bool flag2 = Operators.CompareString(name, "Directory", false) == 0;
                        if (flag2)
                        {
                            while (xmlTextReader2.MoveToNextAttribute())
                            {
                                string name2 = xmlTextReader2.Name;
                                bool flag3 = Operators.CompareString(name2, "Step7", false) == 0;
                                if (flag3)
                                {
                                    this.DirStep7 = xmlTextReader2.Value;
                                }
                                else
                                {
                                    flag3 = (Operators.CompareString(name2, "Excel", false) == 0);
                                    if (flag3)
                                    {
                                        this.DirExcel = xmlTextReader2.Value;
                                    }
                                    else
                                    {
                                        flag3 = (Operators.CompareString(name2, "Awl", false) == 0);
                                        if (flag3)
                                        {
                                            this.DirAwl = xmlTextReader2.Value;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        bool flag3 = nodeType == XmlNodeType.EndElement;
                        if (flag3)
                        {
                        }
                    }
                }
                xmlTextReader2.Close();
            }
        }
    }
}
