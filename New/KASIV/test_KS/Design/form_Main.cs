using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Reflection.PortableExecutable;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

using IronPython;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython.Modules;


namespace KSJr
{
    public partial class form_Main : Form
    {
        string fileName;
        string File_name;
        long File_size;
        string Mal_flag;

        int file_count;

        public form_Main()
        // GUI 메인 함수
        {
            form_About about_Form = new form_About();
            about_Form.ShowDialog();

            InitializeComponent();

            first_show();
        }


        private void button_Search_Click(object sender, EventArgs e)
        {
            list_View.Items.Clear();

            String dir_path = null;

            file_count = 0;

            DateTime startDate = DateTime.Now;





            if (folderBD.ShowDialog() == DialogResult.OK)
            {

                

                
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

            

            dirSearch(dir_path);




            



            list_View.EndUpdate();

            // label 아웃풋
            DateTime endDate = DateTime.Now;
            TimeSpan localDate;
            localDate = endDate - startDate;

            
            label_fileindex.Text = "파일 갯수 : " + file_count;
            
            label_searchtime.Text = "검색 시간 : " + localDate.ToString();
        }

        private void dirSearch(string dir)
        {
            string[] Dirs = Directory.GetDirectories(dir);
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dir);
            {
                //string[] Files = Directory.GetFiles(dir);
                
                
                //foreach (var fileName in Files)
                foreach(var item in di.GetFiles())
                {
                    fileName = item.FullName;
                    File_name = item.Name;
                    csv_mal_fit cs_col = new csv_mal_fit();
                    Mal_flag = cs_col.find_mal_value(File_name);
                    File_size = item.Length;
/* 
                    if(File_size > 0)
                    {
                        classification cc = new classification(item);
                    }
*/


                    file_count++;
                    /*

                    bool b = WinTrust.VerifyEmbeddedSignature(fileName);
                    

                    String str = b.ToString();
                    textBox_test.Text = str;
                    */
                    //-------------------------------여기다가 python 연동 코드 작성

                    //여기까지 작성해서 결과를 가지고 filename add
                    list_View.Items.Add(fileName);
                }
                foreach (var nodeDir in Dirs)
                {
                    list_View.Items.Add(nodeDir);
                    dirSearch(nodeDir);
                }
            }
        }


        private void first_show()
        {
            var engine = IronPython.Hosting.Python.CreateEngine();
            var scope = engine.CreateScope();

            try
            {
                var source = engine.CreateScriptSourceFromFile(@"test1.py");
                source.Execute(scope);

                var getPythonfuncResult = scope.GetVariable<Func<string>>("getPythonFunc");

                //textBox1.Text = "test1: " + getPythonfuncResult();

                var sum = scope.GetVariable<Func<int, int, int>>("sum");
                int a = sum(1, 2);
                //textBox_test.Text = a.ToString();
            }
            catch (Exception ex)
            {
                //textBox_test.Text = "error";
            }
        }

     
    }

    public class classification
    {
        void Clear()
        {
            ;
        }
        public classification(FileInfo item)
        {
            this.Clear();
            double Entropy_value;
            long File_size;
            //string File_name;
            string Hash_md5;
            //string Mal_flag;
            int Entry_Point;
            long[] Dll_arr = new long[17];
            int section_corrupt_bit;
            float IAT_Ratio;

            //string path = @"D:\work\study_hacking\K-Shield\project\AI-vaccine-project\DB\ex";
            //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);


            


            //foreach (var item in di.GetFiles())
          // {
          
                byte[] file_byte = File.ReadAllBytes(item.FullName);

                if ((file_byte[0] == 77) && (file_byte[1] == 90))  //MZ file
                {
                    //File_name = item.Name;
                    File_size = item.Length;
                    //Console.WriteLine("{0}", File_name);
                    Stream stream = new MemoryStream(file_byte);
                    PE pe_struct = new PE(stream);

                    //-----------------------entropy calc-----------------------------------
                    DataEntropy test = new DataEntropy(item.FullName, file_byte);
                    Entropy_value = test.Entropy;
                    //Console.WriteLine("{0}", Entropy_value);
                    //-----------------------entropy calc-----------------------------------

                    //------------------------hash calc-------------------------------------
                    Md5 mm = new Md5(file_byte);
                    Hash_md5 = mm.Gethash();
                    //Console.WriteLine("{0}", Hash_md5);
                    //------------------------hash calc-------------------------------------
                
                    //------------------------Mal_flag input--------------------------------
                    
                    //Console.WriteLine("{0}", Mal_flag);
                    //------------------------Mal_flag input--------------------------------

                    //------------------------PE value input--------------------------------
                    Entry_Point = pe_struct.GetEP();
                    Dll_arr = pe_struct.GetDllCh();
                    section_corrupt_bit = pe_struct.GetsectionCorrupt();
                    IAT_Ratio = Option1_ExecProcess(item.FullName);
                    
                    //------------------------PE value input--------------------------------
                }
            //}
            float Option1_ExecProcess(string fullpath)
            {

                var psi = new ProcessStartInfo();
                psi.FileName = @"D:\ProgramData\Anaconda3\python.exe";


                var script = @"C:\Users\ghdhf\OneDrive\Desktop\KS_Project\dir\대용량_정상,악성파일Ⅳ_정답지모음\1.trainSet.csv";
                var path = fullpath;


                psi.Arguments = $"\"{script}\" \"{path}\" \"{File_size}\" \"{Entropy_value}\" \"{section_corrupt_bit}\" \"{Entry_Point}\" \"{Dll_arr[0]}\" \"{Dll_arr[1]}\" \"{Dll_arr[2]}\" \"{Dll_arr[3]}\" \"{Dll_arr[4]}\" \"{Dll_arr[5]}\" \"{Dll_arr[6]}\" \"{Dll_arr[7]}\" \"{Dll_arr[8]}\" \"{Dll_arr[9]}\" \"{Dll_arr[10]}\" \"{Dll_arr[11]}\" \"{Dll_arr[12]}\" \"{Dll_arr[13]}\" \"{Dll_arr[14]}\" \"{Dll_arr[15]}\" \"{Dll_arr[16]}\" \"{Dll_arr[17]}\"";


                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;



                var errors = "";
                var results = "";

                using (var process = Process.Start(psi))
                {
                    errors = process.StandardError.ReadToEnd();
                    results = process.StandardOutput.ReadToEnd();
                }
                return Convert.ToSingle(results);

                //Console.WriteLine("ERRORS:");
                //Console.WriteLine(errors);
                //Console.WriteLine();
                //Console.WriteLine("Results:");
                //Console.WriteLine(results);




            }



        }
    }

    public class PE
    {
        PEReader Pe;
        int section_corrupt = 0;
        int EP = -1;
        long Dll_ch = -1;
       
        public PE(Stream stream)
        {
            try
            {
                Pe = new PEReader(stream);
                int section_len = Pe.PEHeaders.SectionHeaders.Length;
                EP = Pe.PEHeaders.PEHeader.AddressOfEntryPoint;
                string Dll_str = Pe.PEHeaders.PEHeader.DllCharacteristics.ToString();
                Dll_ch = Dll_ch_change(Dll_str);
                for (int i = 0; i < section_len; i++)
                {
                    string name = Pe.PEHeaders.SectionHeaders[i].Name;
                    string section_ch = Pe.PEHeaders.SectionHeaders[i].SectionCharacteristics.ToString();
                    bool detect_property = section_name_ret(name, section_ch);
                    if (!detect_property)
                    {
                        section_corrupt = 1;        //find corrupt
                        break;
                    }
                }

            }
            catch
            {
                if (EP == -1)
                {
                    EP = 100000;
                }
                if (Dll_ch == -1)
                {
                    Dll_ch = 0;
                }
                if (section_corrupt == 0)
                {
                    section_corrupt = 1;
                }
            }

        }
        
        public long Dll_ch_change(string Dll_str)
        {
            long result = 0;
            bool ch_flag = false;
            if (Dll_str.Contains("AppContainer"))
            {
                ch_flag = true;
                result += 4096;
            }
            if (Dll_str.Contains("DynamicBase"))
            {
                ch_flag = true;
                result += 64;
            }
            if (Dll_str.Contains("HighEntropyVirtualAddressSpace"))
            {
                ch_flag = true;
                result += 32;
            }
            if (Dll_str.Contains("NoBind"))
            {
                ch_flag = true;
                result += 2048;
            }
            if (Dll_str.Contains("NoIsolation"))
            {
                ch_flag = true;
                result += 512;
            }
            if (Dll_str.Contains("NoSeh"))
            {
                ch_flag = true;
                result += 1024;
            }
            if (Dll_str.Contains("NxCompatible"))
            {
                ch_flag = true;
                result += 256;
            }
            if (Dll_str.Contains("ProcessInit"))
            {
                ch_flag = true;
                result += 1;
            }
            if (Dll_str.Contains("ProcessTerm"))
            {
                ch_flag = true;
                result += 2;
            }
            if (Dll_str.Contains("TerminalServerAware"))
            {
                ch_flag = true;
                result += 32768;
            }
            if (Dll_str.Contains("ThreadInit"))
            {
                ch_flag = true;
                result += 4;
            }
            if (Dll_str.Contains("ThreadTerm"))
            {
                ch_flag = true;
                result += 8;
            }
            if (Dll_str.Contains("WdmDriver"))
            {
                ch_flag = true;
                result += 8192;
            }

            if (!ch_flag)
            {
                result = Convert.ToInt64(Dll_str);
            }

            return result;
        }

        public int GetsectionCorrupt()
        {
            return section_corrupt;
        }
        public int GetEP()
        {
            return EP;
        }

        public long[] GetDllCh()
        {
            long[] ary = new long[17];
            if (Dll_ch == -1)
            {
                ary[0] = 0;
            }
            else
            {
                ary[0] = 1;
                long temp = Dll_ch;
                for (int i = 1; i < 17; i++)
                {
                    ary[i] = temp & 0x1;
                    temp >>= 1;
                    if (temp == 0)
                    {
                        break;
                    }
                }



            }
            return ary;
        }




        public bool section_name_ret(string name, string section_ch)
        {
            switch (name)
            {
                case ".text":
                    string a = "ContainsCode, MemExecute, MemRead";
                    // Console.WriteLine(".text")
                    return a.Equals(section_ch);
                case ".itext":
                    string a1 = "ContainsCode, MemExecute, MemRead";
                    // Console.WriteLine(".text")
                    return a1.Equals(section_ch);
                case ".rdata":
                    string b = "ContainsInitializedData, MemRead";
                    // Console.WriteLine(".rdata")
                    return b.Equals(section_ch);
                case ".data":
                    string c = "ContainsInitializedData, MemRead, MemWrite";
                    // Console.WriteLine(".data")
                    return c.Equals(section_ch);
                case ".rsrc":
                    string d = "ContainsInitializedData, MemRead";
                    // Console.WriteLine(".rsrc")
                    return d.Equals(section_ch);
                case ".reloc":
                    string e = "ContainsInitializedData, MemDiscardable, MemRead";
                    // Console.WriteLine(".reloc")
                    return e.Equals(section_ch);
                case ".bss":
                    string f = "ContainsUninitializedData, MemRead, MemWrite";
                    // Console.WriteLine(".bss")
                    return f.Equals(section_ch);
                case ".cormeta":
                    string g = "LinkerInfo";
                    // Console.WriteLine(".cormeta")
                    return g.Equals(section_ch);
                case ".debug$F":
                    string h = "ContainsInitializedData, MemDiscardable, MemRead";
                    // Console.WriteLine(".debug$F")
                    return h.Equals(section_ch);
                case ".debug$P":
                    string i = "ContainsInitializedData, MemDiscardable, MemRead";
                    // Console.WriteLine(".debug$P")
                    return i.Equals(section_ch);
                case ".debug$S":
                    string j = "ContainsInitializedData, MemDiscardable, MemRead";
                    // Console.WriteLine(".debug$S")
                    return j.Equals(section_ch);
                case ".debug$T":
                    string k = "ContainsInitializedData, MemDiscardable, MemRead";
                    // Console.WriteLine(".debug$T")
                    return k.Equals(section_ch);
                case ".drective":
                    string l = "LinkerInfo";
                    // Console.WriteLine(".drective")
                    return l.Equals(section_ch);
                case ".edat":
                    string m = "ContainsInitializedData, MemRead";
                    // Console.WriteLine(".edat")
                    return m.Equals(section_ch);
                case ".idata":
                    string n = "ContainsInitializedData, MemRead, MemWrite";
                    // Console.WriteLine(".idata")
                    return n.Equals(section_ch);
                case ".idlsym":
                    string o = "LinkerInfo";
                    // Console.WriteLine(".idlsym")
                    return o.Equals(section_ch);
                case ".pdata":
                    string p = "ContainsInitializedData, MemRead";
                    // Console.WriteLine(".pdata")
                    return p.Equals(section_ch);
                case ".sbss":
                    string q = "ContainsUninitializedData, MemFardata, MemRead, MemWrite";
                    // Console.WriteLine(".sbss")
                    return q.Equals(section_ch);
                case ".sdata":
                    string r = "ContainsInitializedData, MemFardata, MemRead, MemWrite";
                    // Console.WriteLine(".sdata")
                    return r.Equals(section_ch);
                case ".srdata":
                    string s = "ContainsInitializedData, MemFardata, MemRead";
                    // Console.WriteLine(".srdata")
                    return s.Equals(section_ch);
                case ".sxdata":
                    string t = "LinkerInfo";
                    // Console.WriteLine(".sxdata")
                    return t.Equals(section_ch);
                case ".tls":
                    string u = "ContainsInitializedData, MemRead, MemWrite";
                    // Console.WriteLine(".tls")
                    return u.Equals(section_ch);
                case ".tls$":
                    string v = "ContainsInitializedData, MemRead, MemWrite";
                    // Console.WriteLine(".tls$")
                    return v.Equals(section_ch);
                case ".vsdata":
                    string w = "ContainsInitializedData, MemRead,  MemWrite";
                    // Console.WriteLine(".vsdata")
                    return w.Equals(section_ch);
                case ".xdata":
                    string x = "ContainsInitializedData, MemRead";
                    // Console.WriteLine(".xdata")
                    return x.Equals(section_ch);
                case ".didat":
                    string y = "ContainsInitializedData, MemRead, MemWrite";
                    // Console.WriteLine(".didat")
                    return y.Equals(section_ch);
                default:
                    // Console.WriteLine("Corruption!")
                    return false;

            }

        }

    }
    public class csv_mal_fit
    {
        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
        public csv_mal_fit()
        {
            using (var reader = new StreamReader(@"C:\project\실제 값 비교해보기\파일비교_7_3\2.preSet.csv"))
            {


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }

            }
        }
        public string find_mal_value(string File_name)
        {
            int index = listA.FindIndex(x => x == File_name);
            if(index == -1)
            {
                return "0";
            }
            return listB[index];
        }

    }




    public class Md5
    {
        string hash;
        public Md5(byte[] bytes)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, bytes);
                //Console.WriteLine("{0}", hash);
            }
        }
        public string Gethash()
        {
            return hash;
        }
        static string GetMd5Hash(MD5 md5Hash, byte[] bytes)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(bytes);

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }





    public class DataEntropy
    {
        // Stores the number of times each symbol appears
        SortedList<byte, int> distributionDict;
        // Stores the entropy for each character
        SortedList<byte, double> probabilityDict;
        // Stores the last calculated entropy
        double overalEntropy;
        // Used for preventing unnecessary processing
        bool isDirty;
        // Bytes of data processed
        int dataSize;

        public int DataSampleSize
        {
            get { return dataSize; }
            private set { dataSize = value; }
        }

        public int UniqueSymbols
        {
            get { return distributionDict.Count; }
        }

        public double Entropy
        {
            get { return GetEntropy(); }
        }

        public Dictionary<byte, int> Distribution
        {
            get { return GetSortedDistribution(); }
        }

        public Dictionary<byte, double> Probability
        {
            get { return GetSortedProbability(); }
        }

        public byte GetGreatestDistribution()
        {
            return distributionDict.Keys[0];
        }

        public byte GetGreatestProbability()
        {
            return probabilityDict.Keys[0];
        }

        public double GetSymbolDistribution(byte symbol)
        {
            return distributionDict[symbol];
        }

        public double GetSymbolEntropy(byte symbol)
        {
            return probabilityDict[symbol];
        }

        Dictionary<byte, int> GetSortedDistribution()
        {
            List<Tuple<int, byte>> entryList = new List<Tuple<int, byte>>();
            foreach (KeyValuePair<byte, int> entry in distributionDict)
            {
                entryList.Add(new Tuple<int, byte>(entry.Value, entry.Key));
            }
            entryList.Sort();
            entryList.Reverse();

            Dictionary<byte, int> result = new Dictionary<byte, int>();
            foreach (Tuple<int, byte> entry in entryList)
            {
                result.Add(entry.Item2, entry.Item1);
            }
            return result;
        }

        Dictionary<byte, double> GetSortedProbability()
        {
            List<Tuple<double, byte>> entryList = new List<Tuple<double, byte>>();
            foreach (KeyValuePair<byte, double> entry in probabilityDict)
            {
                entryList.Add(new Tuple<double, byte>(entry.Value, entry.Key));
            }
            entryList.Sort();
            entryList.Reverse();

            Dictionary<byte, double> result = new Dictionary<byte, double>();
            foreach (Tuple<double, byte> entry in entryList)
            {
                result.Add(entry.Item2, entry.Item1);
            }
            return result;
        }

        double GetEntropy()
        {
            // If nothing has changed, dont recalculate
            if (!isDirty)
            {
                return overalEntropy;
            }
            // Reset values
            overalEntropy = 0;
            probabilityDict = new SortedList<byte, double>();

            foreach (KeyValuePair<byte, int> entry in distributionDict)
            {
                // Probability = Freq of symbol / # symbols examined thus far
                probabilityDict.Add(
                    entry.Key,
                    (double)distributionDict[entry.Key] / (double)dataSize
                );
            }

            foreach (KeyValuePair<byte, double> entry in probabilityDict)
            {
                // Entropy = probability * Log2(1/probability)
                overalEntropy += entry.Value * Math.Log((1 / entry.Value), 2);
            }

            isDirty = false;
            return overalEntropy;
        }

        public void ExamineChunk(byte[] chunk)
        {
            if (chunk.Length < 1 || chunk == null)
            {
                return;
            }

            isDirty = true;
            dataSize += chunk.Length;

            foreach (byte bite in chunk)
            {
                if (!distributionDict.ContainsKey(bite))
                {
                    distributionDict.Add(bite, 1);
                    continue;
                }
                distributionDict[bite]++;
            }
        }

        public void ExamineChunk(string chunk)
        {
            ExamineChunk(StringToByteArray(chunk));
        }

        byte[] StringToByteArray(string inputString)
        {
            char[] c = inputString.ToCharArray();
            IEnumerable<byte> b = c.Cast<byte>();
            return b.ToArray();
        }

        void Clear()
        {
            isDirty = true;
            overalEntropy = 0;
            dataSize = 0;
            distributionDict = new SortedList<byte, int>();
            probabilityDict = new SortedList<byte, double>();
        }

        public DataEntropy(string fileName, byte[] bytes)
        {
            this.Clear();
            if (File.Exists(fileName))
            {
                ExamineChunk(bytes);
                GetEntropy();
                GetSortedDistribution();
            }
        }

        public DataEntropy()
        {
            this.Clear();
        }
    }

}
