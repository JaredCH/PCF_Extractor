using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PCF_Extractor
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_SelectFiles_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PCF Files|*.PCF";
            openFileDialog1.Title = "Select PCF Files";
            openFileDialog1.Multiselect = true;

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i=0; i < openFileDialog1.FileNames.Length; i++)
                {
                    dgv_FileList.Rows.Add(openFileDialog1.SafeFileNames[i], Path.GetDirectoryName(openFileDialog1.FileNames[i]+@"\"));
                }
            }
        }
    }
}
