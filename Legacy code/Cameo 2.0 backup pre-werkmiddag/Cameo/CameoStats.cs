using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cameo
{
    public partial class CameoStats : Form
    {

        private string sessionTitle = "";
        private string sessionDate = "";
        private int sessionDuration = 0; 

        public CameoStats()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Cameo files|*.cameo";
            ofd.Title = "Select a Cameo file";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                
                sessionTitle = sr.ReadLine();
                sessionDate = sr.ReadLine();
                sessionDuration = int.Parse(sr.ReadLine());

                labelSessionDate.Text = sessionDate;
                labelSessionDuration.Text = sessionDuration + " seconds";
                labelSessionTitle.Text = sessionTitle;
                

                
                //MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }

            //TextReader tr = new StreamReader("date.txt");

            // read a line of text
            //Console.WriteLine(tr.ReadLine());

            // close the stream
//            tr.Close();
        }
    }
}
