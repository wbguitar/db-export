using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DBToExcel.My
{
    [StandardModule, HideModuleName, GeneratedCode("MyTemplate", "8.0.0.0")]
    internal sealed class MyProject
    {
        [MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms"), EditorBrowsable(EditorBrowsableState.Never)]
        internal sealed class MyForms
        {
            public frmHelp m_frmHelp;

            public frmMain m_frmMain;

            public frmMessage m_frmMessage;

            [ThreadStatic]
            private static Hashtable m_FormBeingCreated;

            public frmHelp frmHelp
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmHelp = MyProject.MyForms.Create__Instance__<frmHelp>(this.m_frmHelp);
                    return this.m_frmHelp;
                }
                [DebuggerNonUserCode]
                set
                {
                    bool flag = value == this.m_frmHelp;
                    if (!flag)
                    {
                        flag = (value != null);
                        if (flag)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmHelp>(ref this.m_frmHelp);
                    }
                }
            }

            public frmMain frmMain
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmMain = MyProject.MyForms.Create__Instance__<frmMain>(this.m_frmMain);
                    return this.m_frmMain;
                }
                [DebuggerNonUserCode]
                set
                {
                    bool flag = value == this.m_frmMain;
                    if (!flag)
                    {
                        flag = (value != null);
                        if (flag)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmMain>(ref this.m_frmMain);
                    }
                }
            }

            public frmMessage frmMessage
            {
                [DebuggerNonUserCode]
                get
                {
                    this.m_frmMessage = MyProject.MyForms.Create__Instance__<frmMessage>(this.m_frmMessage);
                    return this.m_frmMessage;
                }
                [DebuggerNonUserCode]
                set
                {
                    bool flag = value == this.m_frmMessage;
                    if (!flag)
                    {
                        flag = (value != null);
                        if (flag)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        this.Dispose__Instance__<frmMessage>(ref this.m_frmMessage);
                    }
                }
            }

            [DebuggerHidden]
            private static T Create__Instance__<T>(T Instance) where T : Form, new()
            {
                bool flag = Instance == null || Instance.IsDisposed;
                T result;
                if (flag)
                {
                    bool flag2 = MyProject.MyForms.m_FormBeingCreated != null;
                    if (flag2)
                    {
                        bool flag3 = MyProject.MyForms.m_FormBeingCreated.ContainsKey(typeof(T));
                        if (flag3)
                        {
                            throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
                        }
                    }
                    else
                    {
                        MyProject.MyForms.m_FormBeingCreated = new Hashtable();
                    }
                    MyProject.MyForms.m_FormBeingCreated.Add(typeof(T), null);
                    try
                    {
                        try
                        {
                            result = Activator.CreateInstance<T>();
                            return result;
                        }
                        catch (Exception ex)
                        {
                            //object arg_97_0;
                            //TargetInvocationException expr_9C = arg_97_0 as TargetInvocationException;
                            //int arg_B9_0;
                            //if (expr_9C == null)
                            //{
                            //    arg_B9_0 = 0;
                            //}
                            //else
                            //{
                            //    //TargetInvocationException ex = expr_9C;
                            //    ProjectData.SetProjectError(expr_9C);
                            //    //arg_B9_0 = (((ex.InnerException != null) > false) ? 1 : 0);
                            //}
                            ////endfilter(arg_B9_0);
                            ProjectData.SetProjectError(ex);
                        }
                    }
                    finally
                    {
                        MyProject.MyForms.m_FormBeingCreated.Remove(typeof(T));
                    }
                }
                result = Instance;
                return result;
            }

            [DebuggerHidden]
            private void Dispose__Instance__<T>(ref T instance) where T : Form
            {
                instance.Dispose();
                instance = default(T);
            }

            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            public MyForms()
            {
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            internal new Type GetType()
            {
                return typeof(MyProject.MyForms);
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString()
            {
                return base.ToString();
            }
        }

        [MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", ""), EditorBrowsable(EditorBrowsableState.Never)]
        internal sealed class MyWebServices
        {
            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            internal new Type GetType()
            {
                return typeof(MyProject.MyWebServices);
            }

            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            public override string ToString()
            {
                return base.ToString();
            }

            [DebuggerHidden]
            private static T Create__Instance__<T>(T instance) where T : new()
            {
                bool flag = instance == null;
                T result;
                if (flag)
                {
                    result = Activator.CreateInstance<T>();
                }
                else
                {
                    result = instance;
                }
                return result;
            }

            [DebuggerHidden]
            private void Dispose__Instance__<T>(ref T instance)
            {
                instance = default(T);
            }

            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            public MyWebServices()
            {
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), ComVisible(false)]
        internal sealed class ThreadSafeObjectProvider<T> where T : new()
        {
            [CompilerGenerated, ThreadStatic]
            private static T m_ThreadStaticValue;

            internal T GetInstance
            {
                [DebuggerHidden]
                get
                {
                    bool flag = MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null;
                    if (flag)
                    {
                        MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = Activator.CreateInstance<T>();
                    }
                    return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never), DebuggerHidden]
            public ThreadSafeObjectProvider()
            {
            }
        }

        private static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();

        private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();

        private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();

        private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();

        private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

        [HelpKeyword("My.Computer")]
        internal static MyComputer Computer
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_ComputerObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Application")]
        internal static MyApplication Application
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_AppObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.User")]
        internal static User User
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_UserObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Forms")]
        internal static MyProject.MyForms Forms
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_MyFormsObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.WebServices")]
        internal static MyProject.MyWebServices WebServices
        {
            [DebuggerHidden]
            get
            {
                return MyProject.m_MyWebServicesObjectProvider.GetInstance;
            }
        }
    }
}
