using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.Principal;



namespace HWIDChecker
{

    public partial class Form1 : Form
    {
        HwiDs hw = new HwiDs();
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
                using (TextWriter TW = new StreamWriter(originalHwidPath))
                {
                    TW.Write(string.Empty);

                    try
                    {
                        StringBuilder stringBuilder;


                        foreach (ListViewItem item in ListView1.Items)
                        {
                            stringBuilder = new StringBuilder();
                            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                            {
                                stringBuilder.Append(string.Format("{0}", subItem.Text));
                            }
                            TW.WriteLine(stringBuilder.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        TW.Close();
                        return;
                    }

                }

            }
            else
            {

                try
                {
                    var create = File.Create(originalHwidPath);
                    create.Close();
                }
                catch (Exception)
                {

                    return;
                }

                using (TextWriter TW = new StreamWriter(originalHwidPath))
                {
                    try
                    {
                        StringBuilder stringBuilder;


                        foreach (ListViewItem item in ListView1.Items)
                        {
                            stringBuilder = new StringBuilder();
                            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                            {
                                stringBuilder.Append(string.Format("{0}", subItem.Text));
                            }
                            TW.WriteLine(stringBuilder.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        TW.Close();
                        return;
                    }


                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newHwidPath = (curDir + newHwids);

            if (newCheck)
            {
                using (TextWriter TW = new StreamWriter(newHwidPath))
                {
                    TW.Write(string.Empty);

                    try
                    {
                        StringBuilder stringBuilder;


                        foreach (ListViewItem item in ListView1.Items)
                        {
                            stringBuilder = new StringBuilder();
                            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                            {
                                stringBuilder.Append(string.Format("{0}", subItem.Text));
                            }
                            TW.WriteLine(stringBuilder.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        TW.Close();
                        return;
                    }


                }

            }
            else
            {

                try
                {
                    var create = File.Create(newHwidPath);
                    create.Close();
                }
                catch (Exception)
                {
                    return;
                }

                using (TextWriter TW = new StreamWriter(newHwidPath))
                {
                    try
                    {
                        StringBuilder stringBuilder;


                        foreach (ListViewItem item in ListView1.Items)
                        {
                            stringBuilder = new StringBuilder();
                            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                            {
                                stringBuilder.Append(string.Format("{0}", subItem.Text));
                            }
                            TW.WriteLine(stringBuilder.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        TW.Close();
                        return;
                    }


                }

            }



            var newHwidTxt = File.ReadAllLines(newHwidPath);
            var comparedTxt = File.ReadAllLines(curDir + ogHwids).Where(line => newHwidTxt.Contains(line));

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

            StringBuilder sb;


            string[] OverHeads = { VolumeOverHead, ControllerOverHead, GpuOverHead , KeyboardOverHead,
            MouseOverHead, MacsOverHead, WinKeyOverHead, CpuOverHead,  RamOverHead,  SsdOverHead,
            MoboOverHead, BiosOverHead, SimOverHead,  MonitorOverHead};

            foreach (var item in comparedTxt)
            {
                sb = new StringBuilder();
                sb.Append(string.Format("{0}", item));

                foreach (var overHead in OverHeads)
                {
                    if (sb.ToString() == overHead)
                    {
                        ListView1.Items.Add(overHead).BackColor = Color.MidnightBlue;
                        goto SKIP;
                    }

                }

                ListView1.Items.Add(sb.ToString()).ForeColor = Color.Red;

            SKIP: continue;
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
                stringBuilder.Append(string.Format("{0}{1}", "VERBOSE : ", p.StandardOutput.ReadLine().ToString()));


                if (Firstlines > 9)
                {
                    ListView1.Items.Add(stringBuilder.ToString());
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
