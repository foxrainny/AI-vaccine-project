using System;
using System.IO;
using System.Windows.Forms;

namespace K_Shield_AVGUI
{
    public partial class Main_Form : Form
    {

        public Main_Form()
        {
            InitializeComponent();
        }


        private void file_button_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();

            String dir_path = null;

            listView1.BeginUpdate();

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {

                dir_path = folderDialog.SelectedPath;

                //testBox.Text = folderDialog.SelectedPath;

            }
            dirSearch(dir_path);




            listView1.EndUpdate();
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
                    testBox.Text = str;


                    ///
                    listView1.Items.Add(fileName);
                }
                foreach (var nodeDir in Dirs)
                {
                    listView1.Items.Add(nodeDir);
                    dirSearch(nodeDir);
                }
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {



        }
    }
}
