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
using System.Text.RegularExpressions;

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

        private void btn_ProcessFiles_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Commidity");
            String comm = null;
            string active = "no";
            String lineformatted = null;
            String piperef = null;
            try
            {
                foreach (DataGridViewRow row in dgv_FileList.Rows)
                {

                    const Int32 BufferSize = 128;
                    using (var fileStream = File.OpenRead(row.Cells[1].Value.ToString()))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {
                        String line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            lineformatted = Regex.Replace(line, @"\s+", "%20");
                                //MessageBox.Show(lineformatted);
                                if (lineformatted.Contains("PIPELINE-REFERENCE"))
                                {
                                    piperef = lineformatted;
                                    
                                }

                            if (!lineformatted.StartsWith("%20"))
                            {
                                // MessageBox.Show(lineformatted);
                                comm = lineformatted;
                                active = "fitting";
                                //MessageBox.Show(comm);
                            }
                            if (lineformatted.StartsWith("%20"))
                            {
                                if (active == "fitting");
                                        {
                                    comm = comm + ";" + lineformatted;
                                    //MessageBox.Show(comm);
                                }

                            }
                            if (!lineformatted.StartsWith("%20"))
                            {
                                if (active == "fitting")
                                {
                                    dt.Rows.Add(piperef +";" + comm);
                                    active = "no";
                                    comm = null;
                                }

                            }
                            
                        }
                    }
                    dgv_report.DataSource = dt;
                }
            }
            catch { }
        }
    }
}
