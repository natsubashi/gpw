using System;
using System.Windows.Forms;
using Npgsql;

namespace gpw{

public static class Program{
    [STAThread]
    static void Main(){
        Application.EnableVisualStyles();

        Application.Run(new Form1());
    }
}

}