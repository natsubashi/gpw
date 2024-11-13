using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using Npgsql;

namespace gpw
{
public partial class Form1 : Form{
    Panel panel1;
    TextBox textBox1;
    Button button1;
    public Form1(){
        //InitializeComponent();
        CALControls();
    }

    void CALControls(){
        this.ClientSize = new System.Drawing.Size(400, 300);

        this.Controls.Add(panel1 = new Panel{
            Location = new Point(10, 10),
            BackColor = Color.Azure,
            Size = new Size(300, 100),
        });

        panel1.Controls.Add(textBox1 = new TextBox{
            Location = new Point(5, 0),
            Size = new Size(200, 22),
        });

        panel1.Controls.Add(button1 = new Button{
            Location = new Point(5, 23),
            Size = new Size(200, 22),
            Text = "botann",
            BackColor = Color.Crimson,
        });

        button1.Click += Button1_Click;

        panel1.BringToFront();
    }

    private void Button1_Click(object sender, EventArgs e){
        MessageBox.Show(textBox1.Text);
    }
}


}
