using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Windows.Automation;
using System.Threading;
using System.Linq;

class Program {
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindowEx(IntPtr hWnd, IntPtr previousWnd, string className, string windowText);
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, StringBuilder lParam);
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool EnumChildWindows(IntPtr hWnd, EnumWindowsProc enumProc, IntPtr lParam);

    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lparam);

    public static string MyGetClassNameString(IntPtr hWnd){
        StringBuilder csb = new StringBuilder(1000); //stringBuilderに大きな数を渡すとClassNameが見切れずに格納される
        GetClassName(hWnd, csb, csb.Capacity);
        Console.WriteLine(hWnd.ToString("X8"));
        Console.WriteLine(csb.Length);
        Console.WriteLine(csb);
        return csb.ToString();
    }

    public static bool EnumChildWindowCallBack(IntPtr hWnd, IntPtr lparam) {
        MyGetClassNameString(hWnd);
        return true;
    }

    public static IntPtr FindWindowByClassName(string targetClassName, IntPtr phdl) {
        IntPtr foundWindow = IntPtr.Zero;

        // デスクトップ（最上位ウィンドウ）から開始して、すべての子孫ウィンドウを列挙
        EnumChildWindows(phdl, (hwnd, lParam) =>
        {
            StringBuilder className = new StringBuilder(256);
            GetClassName(hwnd, className, className.Capacity);
            Console.WriteLine(className.ToString());

            if (className.ToString() == targetClassName)
            {
                foundWindow = hwnd;
                return false; // 検索を終了
            }
            return true; // 検索を続行
        }, IntPtr.Zero);

        return foundWindow;
    }

    public static void SetTextToTextBox(string windowTitle, string automationId, string textToSet){
        AutomationElement targetWindow = FindWindowByTitle(windowTitle);
        //AutomationElement textBox = FindTextBox(targetWindow, automationId);
        //SetTextTotElement(textBox, textToSet);
    }

    private static AutomationElement FindWindowByTitle(string windowTitle) {
        AutomationElement window = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, windowTitle));
        if (window != null) return window;
        return null;
    }

    private static AutomationElement FindTextBox(AutomationElement parent, string automationID){
        AutomationElement textBox = parent.FindFirst(
            TreeScope.Descendants,
            new PropertyCondition(AutomationElement.AutomationIdProperty, automationID));
        return textBox;
    }

    static void Main(string[] args) {
        var cnd = new PropertyCondition(AutomationElement.NameProperty, "beInput");
        var apliElement = AutomationElement.RootElement.FindFirst(TreeScope.Children, cnd);

        Console.WriteLine(apliElement.GetCurrentPropertyValue(AutomationElement.ClassNameProperty));
        Console.WriteLine(FindTextBox(apliElement, "textBox111").GetCurrentPropertyValue(AutomationElement.AutomationIdProperty));

        var tb111 = FindTextBox(apliElement, "textBox111");
        ValuePattern editValue = tb111.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
        editValue.SetValue("WD!2011111f");        

        /*IntPtr hdl = FindWindow(null, "beInput");
        if(hdl != IntPtr.Zero) {
            MyGetClassNameString(hdl);
            IntPtr chdl1 = FindWindowEx(hdl, IntPtr.Zero, "", "");
            MyGetClassNameString(chdl1);

            chdl1 = FindWindowEx(hdl, IntPtr.Zero, "", "");
            if(chdl1 != IntPtr.Zero) Console.WriteLine(chdl1.ToString("X8"));
            else Console.WriteLine("1 = null");

            EnumChildWindows(hdl, EnumChildWindowCallBack, IntPtr.Zero);
            Console.WriteLine("---------End EnumChildWindows------");

            chdl1 = FindWindowByClassName("29e8405_r3_ad1", hdl);
            MyGetClassNameString(chdl1);

            IntPtr mhdl = Process.GetProcessesByName("beinput")[0].MainWindowHandle;
            MyGetClassNameString(mhdl);
            /*
            IntPtr tbx = (IntPtr)0x0013087E;
            tbx = FindWindowEx((IntPtr)0, IntPtr.Zero, "WindowsForms10.Edit.app.0.29e8405_r3_ad12", null);
            MyGetClassNameString(tbx);

            StringBuilder send = new StringBuilder("WD100040021");
            SendMessage(tbx, 0, IntPtr.Zero, send);
        }
        else {
            Console.WriteLine("none!");
        }*/
    }
}