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
        string comm = null;
        string active = "dunno";
        String lineformatted = null;
        String piperef = null;
        String ic = null;
        string final = null;
        string[] segments;
        int previousLength;

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


            try
            {
                foreach (DataGridViewRow row in dgv_FileList.Rows)
                {
                    final = null;
                    const Int32 BufferSize = 128;
                    using (var fileStream = File.OpenRead(row.Cells[1].Value.ToString()))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {
                        String line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            lineformatted = Regex.Replace(line, @"\s+", "%20");
                            //MessageBox.Show(lineformatted.Substring(0, 3).ToString());
                            if (lineformatted.Contains("PIPELINE-REFERENCE"))
                            {
                                piperef = lineformatted;

                            }
                            if (lineformatted.Contains("ITEM-CODE"))
                            {
                                ic = lineformatted;

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
                                comm = comm + ";" + lineformatted;
                                final = comm;
                                //MessageBox.Show(comm);
                            }
                            if (!lineformatted.Substring(0, 3).Equals("%20"))
                            {
                                dt.Rows.Add(piperef + ";" + ic + ";" + final);
                                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                {
                                    dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("%20", " ");
                                    dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace("PIPELINE-REFERENCE ", "");
                                    dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace(" PIPING-SPEC ", "");
                                    dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace(" END-POINT", "");
                                    dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace(" CO-ORDS ", "");
                                    dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace(" UNIQUE-COMPONENT-IDENTIFIER ", "");
                                    dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace(" INSULATION-ON", "");
                                    dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace(" UNIQUE-COMPONENT-IDENTIFIER ", "");
                                    dt.Rows[i][0] = dt.Rows[i][0].ToString().Replace(" DESCRIPTION ", "");
                                    if (dt.Rows[i][0].ToString().Equals(";;") || dt.Rows[i][0].ToString().Equals(piperef + ";" + ic+";") || dt.Rows[i][0].ToString().Equals(piperef+";;") || dt.Rows[i][0].ToString().Equals(piperef+" "+ic) || dt.Rows[i][0].ToString().Contains("FLOW-ARROW") || dt.Rows[i][0].ToString().Contains("REFERENCE-DIMENSION") || dt.Rows[i][0].ToString().Contains("FLOOR-SYMBOL"))
                                    {
                                        dt.Rows.Remove(dt.Rows[i]);
                                    }
                                }
                                dgv_report.DataSource = dt;
                                active = "no";
                                comm = lineformatted;
                            }

                        }

                    }
                }
            }
            catch { }
        }
    }
}
