using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Principal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Windows.Media.Ocr;


namespace HWIDChecker
{

    public partial class Form1 : Form
    {
        readonly FileOps fo = new FileOps();
        readonly HwiDs hw = new HwiDs();
        ListView ListView1 = new ListView();
        private string curDir { get; set; }
        private string ogHwids = "\\OriginalHWIDs.txt";
        private string newHwids = "\\NewHWIDs.txt";
        private bool ogCheck { get; set; }
        private bool newCheck { get; set; }

        private string VolumeOverHead = "VOLUME IDS";
        private string ControllerOverHead = "CIM CONTROLLER IDS";
        private string GpuOverHead = "GPU IDS";
        private string KeyboardOverHead = "KEYBOARD IDS";
        private string MouseOverHead = "MOUSE IDS";
        private string MacsOverHead = "MAC ADDRESSES";
        private string WinKeyOverHead = "WINDOWS KEY";
        private string CpuOverHead = "CPU ID";
        private string RamOverHead = "RAM IDS";
        private string SsdOverHead = "SSD IDS";
        private string MoboOverHead = "MOBO ID";
        private string BiosOverHead = "BIOS ID";
        private string SimOverHead = "SMBIOS ID";
        private string MonitorOverHead = "Monitor IDS";




        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            curDir = System.IO.Directory.GetCurrentDirectory();
            string ogHwidPath = (curDir + ogHwids);
            string newHwidPath = (curDir + newHwids);

            if (File.Exists(ogHwidPath)) ogCheck = true;
            if (File.Exists(newHwidPath)) newCheck = true;
            ListView1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ListView1.Visible)
            {
                ListView1.Visible = false;
                return;
            }

            ListView1.Clear();
            ListView1.Location = new Point(284, 31);
            ListView1.Size = new Size(552, 501);
            ListView1.BorderStyle = BorderStyle.Fixed3D;
            ListView1.Font = new Font("Ruda Bold", 10);
            ListView1.Scrollable = true;
            ListView1.Columns.Add("");
            ListView1.Columns[0].Width = ListView1.Width;
            ListView1.View = View.Details;

            ListView1.ForeColor = Color.OrangeRed;

            ListView1.Items.Add(VolumeOverHead).BackColor = Color.MidnightBlue;
            foreach (var item in hw.VolumeIds)
            {
                ListView1.Items.Add(item).ForeColor = Color.Green;
            }

            ListView1.Items.Add("");
            ListView1.Items.Add(ControllerOverHead).BackColor = Color.MidnightBlue;
            foreach (var item in hw.ControllerIds)
            {
                ListView1.Items.Add(item).ForeColor = Color.Green;
            }

            ListView1.Items.Add("");
            ListView1.Items.Add(GpuOverHead).BackColor = Color.MidnightBlue;
            foreach (var item in hw.GPUIds)
            {
                ListView1.Items.Add(item).ForeColor = Color.Green;

            }

            ListView1.Items.Add("");
            ListView1.Items.Add(KeyboardOverHead).BackColor = Color.MidnightBlue;
            foreach (var item in hw.KeyboardIds)
            {
                ListView1.Items.Add(item).ForeColor = Color.Green;

            }


            ListView1.Items.Add("");
            ListView1.Items.Add(MouseOverHead).BackColor = Color.MidnightBlue;
            foreach (var item in hw.MouseIds)
            {
                ListView1.Items.Add(item).ForeColor = Color.Green;

            }

            ListView1.Items.Add("");
            ListView1.Items.Add(MacsOverHead).BackColor = Color.MidnightBlue;
            foreach (var item in hw.MacIds)
            {
                ListView1.Items.Add(item.MacAddress).ForeColor = Color.Green;
            }


            ListView1.Items.Add(WinKeyOverHead).BackColor = Color.MidnightBlue;
            ListView1.Items.Add(hw.WindowsKey).ForeColor = Color.Green;


            ListView1.Items.Add("");
            ListView1.Items.Add(CpuOverHead).BackColor = Color.MidnightBlue;
            ListView1.Items.Add(hw.CPUId).ForeColor = Color.Green;


            ListView1.Items.Add("");
            ListView1.Items.Add(RamOverHead).BackColor = Color.MidnightBlue;
            foreach (var item in hw.RamIds)
            {
                ListView1.Items.Add(item).ForeColor = Color.Green;
            }


            ListView1.Items.Add("");
            ListView1.Items.Add(SsdOverHead).BackColor = Color.MidnightBlue;
            foreach (var item in hw.SSDIds)
            {
                ListView1.Items.Add(item).ForeColor = Color.Green;
            }


            ListView1.Items.Add("");
            ListView1.Items.Add(MoboOverHead).BackColor = Color.MidnightBlue;
            ListView1.Items.Add(hw.MOBOId).ForeColor = Color.Green;


            ListView1.Items.Add("");
            ListView1.Items.Add(BiosOverHead).BackColor = Color.MidnightBlue;
            ListView1.Items.Add(hw.BIOSId).ForeColor = Color.Green;


            ListView1.Items.Add("");
            ListView1.Items.Add(SimOverHead).BackColor = Color.MidnightBlue;
            ListView1.Items.Add(hw.SMBIOSId).ForeColor = Color.Green;


            ListView1.Items.Add("");
            ListView1.Items.Add(MonitorOverHead).BackColor = Color.MidnightBlue;
            foreach (var item in hw.MonitorIds)
            {
                ListView1.Items.Add(item).ForeColor = Color.Green;
            }



            this.Controls.Add(ListView1);
            ListView1.BringToFront();
            ListView1.Visible = true;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string originalHwidPath = (curDir + ogHwids);

            if (ogCheck)
            {
                fo.CreatAndWrite(originalHwidPath, ListView1);
            }
            else
            {
                fo.OverWriteFile(originalHwidPath, ListView1);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newHwidPath = (curDir + newHwids);

            if (newCheck)
            {
                fo.CreatAndWrite(newHwidPath, ListView1);
            }
            else
            {
                fo.OverWriteFile(newHwidPath, ListView1);
            }


            ListView1.Clear();
            ListView1.Location = new Point(284, 31);
            ListView1.Size = new Size(552, 501);
            ListView1.BorderStyle = BorderStyle.Fixed3D;
            ListView1.Font = new Font("Ruda Bold", 10);
            ListView1.Scrollable = true;
            ListView1.Columns.Add("");
            ListView1.Columns[0].Width = ListView1.Width;
            ListView1.View = View.Details;
            ListView1.ForeColor = Color.OrangeRed;



            string[] OverHeads = { VolumeOverHead, ControllerOverHead, GpuOverHead , KeyboardOverHead,
            MouseOverHead, MacsOverHead, WinKeyOverHead, CpuOverHead,  RamOverHead,  SsdOverHead,
            MoboOverHead, BiosOverHead, SimOverHead,  MonitorOverHead};

           
            var ogHwidTxt = File.ReadAllLines(curDir + ogHwids);
            var newHwidTxt = File.ReadAllLines(curDir + newHwids);
            StringBuilder sb;


            foreach (var (error, success) in ogHwidTxt.Zip(newHwidTxt))
            {
                foreach (var overHead in OverHeads)
                {
                    if (error.ToString() == overHead.ToString())
                    {
                        ListView1.Items.Add(overHead.ToString()).BackColor = Color.MidnightBlue;
                        goto jmp;
                    }   
                }

                if (success.ToString() == error.ToString())
                {
                    if (error.ToString() == "Default string")
                    {
                        sb = new StringBuilder();
                        sb.AppendLine(string.Format("{0} {1}", error.ToString(), "(This is Okay To Not Change)"));
                        ListView1.Items.Add(sb.ToString()).ForeColor = Color.Red;
                        goto jmp;
                    }
                    
                    ListView1.Items.Add(error.ToString()).ForeColor = Color.Red;
                }
                else
                {

                    if (success.ToString() == "Default string")
                    {
                        sb = new StringBuilder();
                        sb.AppendLine(string.Format("{0} {1}", error.ToString(), "(This is Okay To Not Change)"));
                        ListView1.Items.Add(sb.ToString()).ForeColor = Color.Green;
                        goto jmp;
                    }

                    ListView1.Items.Add(success.ToString()).ForeColor = Color.Green;
                }

                jmp:;
            }


            this.Controls.Add(ListView1);
            ListView1.BringToFront();
            ListView1.Visible = true;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.UseFading = true;
            toolTip.Show("Click View Hwids, Then Click Save", button2);

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.UseFading = true;
            toolTip.Show("Click View Hwids, Then Click Compare", button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string deletescript = @"
            $status = ""Unknown""
            foreach ($dev in (Get-PnpDevice | Where-Object{$_.Status -eq $status})) {
            & ""pnputil"" /remove-device $dev.InstanceId }";

            string SystemDir = System.Environment.SystemDirectory;
            string Powershell = "\\WindowsPowerShell\\v1.0\\powershell.exe";
            StringBuilder stringBuilder;


            ListView1.Clear();
            ListView1.Location = new Point(284, 31);
            ListView1.Size = new Size(552, 501);
            ListView1.BorderStyle = BorderStyle.Fixed3D;
            ListView1.Font = new Font("Ruda Bold", 10);
            ListView1.Scrollable = true;
            ListView1.Columns.Add("");
            ListView1.Columns[0].Width = ListView1.Width;
            ListView1.View = View.Details;
            ListView1.ForeColor = Color.LightGoldenrodYellow;

           


            Process p = new Process();
            p.StartInfo.FileName = SystemDir + Powershell;
            p.StartInfo.Verb = "runas";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            p.StandardInput.WriteLine(deletescript + "\n");
            System.Threading.Thread.Sleep(3000);
            p.Kill();

            int Firstlines = 0;
            while (!p.StandardOutput.EndOfStream)
            {
                stringBuilder = new StringBuilder();
                if (p.StandardOutput.ReadLine().ToString() == null) continue;
                if (p.StandardOutput.ReadLine().ToString().StartsWith("PS")) continue;

                stringBuilder.Append(string.Format("{0}{1}", "VERBOSE : ", p.StandardOutput.ReadLine().ToString()));

                if (Firstlines > 9)
                {
                    ListView1.Items.Add(stringBuilder.ToString()).ForeColor = Color.LightGoldenrodYellow;
                }
                Firstlines++;
            }

            p.Close();


            this.Controls.Add(ListView1);
            ListView1.BringToFront();
            ListView1.Visible = true;
        }
    }
}
