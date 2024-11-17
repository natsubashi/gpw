using System;
using System.Windows.Forms;
using Npgsql;

namespace gpw{

public static class Program{
    [STAThread]
    static void Main(){
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.SystemAware);

        Application.Run(new Form1());
    }
}

}