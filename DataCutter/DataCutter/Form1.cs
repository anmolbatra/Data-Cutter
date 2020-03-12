using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;




namespace DataCutter
{
    
    public partial class Form1 : Form
    {
                
        public static String Source_File_Path = "File Path";
        public static String Source_File_Name = "File Name";
        public static String Dest_File_Path = "Destination File Name";
        public static String Dest_File_Name = "Destination File Name";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size = -1;
            string[] File_Path_Split;
            //openFileDialog1.Filter();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    //string text = File.ReadAllText(file);
                    Source_File_Path = file;
                    File_Path_Split = file.Split('\\');
                    size = File_Path_Split.Length;
                    Source_File_Name = File_Path_Split[size-1];
                    
                    label3.Text = Source_File_Name;
                    //size = text.Length;
                }
                catch (IOException)
                {
                }

                
                
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size = -1;
            int val_result = -1;
            string[] File_Path_Split;
            
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string Des_File = saveFileDialog1.FileName;
                Dest_File_Path = Des_File;
                File_Path_Split = Dest_File_Path.Split('\\');
                size = File_Path_Split.Length;
                Dest_File_Name = File_Path_Split[size - 1];
                try
                {
                    val_result = Validate_Source_File();
                    if (val_result == 1)
                        Split_And_Write();

                }
                catch (IOException)
                {
                }
            }
        }
        private int Validate_Source_File()
        {
            string Src_Delim = comboBox1.Text;
            string Fnl_Delim;
            Boolean End_Delim = Convert.ToBoolean(checkBox1.CheckState);
            int Src_No_Delims = Convert.ToInt32(numericUpDown1.Value);
            int[] Col_Pos = new int[100];

            Col_Pos[0] = Convert.ToInt32(numericUpDown2.Value);
            Col_Pos[1] = Convert.ToInt32(numericUpDown3.Value);
            Col_Pos[2] = Convert.ToInt32(numericUpDown4.Value);
            Col_Pos[3] = Convert.ToInt32(numericUpDown5.Value);
            Col_Pos[4] = Convert.ToInt32(numericUpDown6.Value);
            Col_Pos[5] = Convert.ToInt32(numericUpDown7.Value);
            Col_Pos[6] = Convert.ToInt32(numericUpDown8.Value);
            Col_Pos[7] = Convert.ToInt32(numericUpDown9.Value);
            Col_Pos[8] = Convert.ToInt32(numericUpDown10.Value);
            Col_Pos[9] = Convert.ToInt32(numericUpDown11.Value);

            if(Src_Delim == "[Tab]")
            {
                Fnl_Delim = "\t";
            }
            if (Src_Delim == "[Space]")
            {
                Fnl_Delim = " ";
            }
            if ((Src_Delim != "[Tab]") && (Src_Delim != "[Space]"))
            {
                Fnl_Delim = Src_Delim;
            }

            if ((Col_Pos.Max() > Src_No_Delims + 1) && (End_Delim = false))
            {
                MessageBox.Show("Incorrect Number of Columns Specified");
                return 0;
            }
             if ((Col_Pos.Max() > Src_No_Delims) && (End_Delim = true))
             {
                 MessageBox.Show("Incorrect Number of Columns Specified");
                 return 0;
              }
            if (Source_File_Path == "File Path")
            {
                 MessageBox.Show("File not selected");
                 return 0;
            }

             return 1;
        }
        private int Split_And_Write()
        {
            try
            {

                StreamReader Src = new StreamReader(Source_File_Path);
                StreamWriter Des;
                string Src_Cur_Line;
                string[] temp;
                string Des_Cur_Line;
                long line_cnt;
                string Src_Delim = comboBox1.Text;
                string Fnl_Delim;
                int[] Col_Pos = new int[100];

                Des = new StreamWriter(Dest_File_Path);
                Fnl_Delim = "";

                Col_Pos[0] = Convert.ToInt32(numericUpDown2.Value);
                Col_Pos[1] = Convert.ToInt32(numericUpDown3.Value);
                Col_Pos[2] = Convert.ToInt32(numericUpDown4.Value);
                Col_Pos[3] = Convert.ToInt32(numericUpDown5.Value);
                Col_Pos[4] = Convert.ToInt32(numericUpDown6.Value);
                Col_Pos[5] = Convert.ToInt32(numericUpDown7.Value);
                Col_Pos[6] = Convert.ToInt32(numericUpDown8.Value);
                Col_Pos[7] = Convert.ToInt32(numericUpDown9.Value);
                Col_Pos[8] = Convert.ToInt32(numericUpDown10.Value);
                Col_Pos[9] = Convert.ToInt32(numericUpDown11.Value);

                if (Src_Delim == "[Tab]")
                {
                    Fnl_Delim = "\t";
                }
                if (Src_Delim == "[Space]")
                {
                    Fnl_Delim = " ";
                }
                if ((Src_Delim != "[Tab]") && (Src_Delim != "[Space]"))
                {
                    Fnl_Delim = Src_Delim;
                }

                line_cnt = 0;
                do
                {
                    Src_Cur_Line = Src.ReadLine();
                    temp = Src_Cur_Line.Split(Convert.ToChar(Fnl_Delim));
                    Des_Cur_Line = "";
                    for( int j = 1; j <= 10; j++)
                    {
                        if (Col_Pos[j-1] > 0)  
                        {
                            if (Des_Cur_Line == "")
                            {
                            Des_Cur_Line = temp[Col_Pos[j-1] - 1];
                            j++;
                            }
                            if ((Col_Pos[j-1] >= 1) && (Des_Cur_Line != ""))
                            {
                            Des_Cur_Line = Des_Cur_Line + Fnl_Delim + temp[Col_Pos[j-1] - 1];
                            }
                        }

                    }
                    Des.WriteLine(Des_Cur_Line);
                    line_cnt++;
                } while (Src.Peek() != -1);
                Des.Close();
                MessageBox.Show(Convert.ToString(line_cnt) + " Rows Extracted to file" + Dest_File_Name, "Data Spool Complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return 0;
        }

    }
       
}
