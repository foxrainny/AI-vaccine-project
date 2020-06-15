using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //openFileDig.InitialDirectory = "C:\\";
            String dir_path = null;

            listView1.BeginUpdate();
            //if(openFileDig.ShowDialog() == DialogResult.OK)
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                //file_path = openFileDig.FileName;
                dir_path = folderDialog.SelectedPath;

                testBox.Text = folderDialog.SelectedPath;
                    //file_path.Split('\\')[file_path.Split('\\').Length - 1];
            }
            dirSearch(dir_path);
           

            

            listView1.EndUpdate();
        }
        
        private void dirSearch(string dir)
        {
            string[] Dirs = Directory.GetDirectories(dir);
            {
                string[] Files = Directory.GetFiles(dir);
                foreach(var fileName in Files)
                {
                    listView1.Items.Add(fileName);
                }
                foreach(var nodeDir in Dirs)
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
