using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KSJr
{
    public partial class form_Main : Form
    {
        public form_Main()
        {
            form_About about_Form = new form_About();
            about_Form.ShowDialog();

            InitializeComponent();
        }
        private void button_result_Click(object sender, EventArgs e)
        {

        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            list_View.Items.Clear();

            String dir_path = null;

            
            

            
            


            if (folderBD.ShowDialog() == DialogResult.OK)
            {

                DateTime localDate = DateTime.Now;
                now_label.Text = "Scan Time : " + localDate.ToString(); 
                try
                {
                    dir_path = folderBD.SelectedPath;


                    //testBox.Text = folderBD.SelectedPath;
                }
                catch(Exception exp)
                {
                    MessageBox.Show("Error"
                        + Environment.NewLine + exp.ToString() + Environment.NewLine);
                    this.Dispose();
                }
                Invalidate();


            }
            else
            {
                return;
            }


            list_View.BeginUpdate();


            list_View.Columns.Add("파일명", 999, HorizontalAlignment.Left);

            //new Preloader().Show();

            dirSearch(dir_path);



            //list_View.EnsureVisible(list_View.Items.Count - 1);
            list_View.EndUpdate();

            //
        }

        private void dirSearch(string dir)
        {
            string[] Dirs = Directory.GetDirectories(dir);
            {
                string[] Files = Directory.GetFiles(dir);
                

                foreach (var fileName in Files)
                {
                    

                    bool b = WinTrust.VerifyEmbeddedSignature(fileName);
                    

                    String str = b.ToString();
                    textBox_test.Text = str;


                    
                    list_View.Items.Add(fileName);
                }
                foreach (var nodeDir in Dirs)
                {
                    list_View.Items.Add(nodeDir);
                    dirSearch(nodeDir);
                }
            }
        }


    }
}
