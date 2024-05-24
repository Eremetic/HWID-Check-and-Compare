using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace HWIDChecker
{

    struct MacAddresses
    {
        public string Name { get; set; }
        public string MacAddress { get; set; }
    }


    internal class HwiDs
    {

        public List<string> VolumeIds { get; set; }
        public List<string> ControllerIds { get; set; }
        public List<string> GPUIds { get; set; }
        public List<string> KeyboardIds { get; set; }
        public List<string> MouseIds { get; set; }
        public List<HWIDChecker.MacAddresses> MacIds { get; set; }
        public string WindowsKey { get; set; }
        public string CPUId { get; set; }
        public List<string> RamIds { get; set; }
        public List<string> SSDIds { get; set; }
        public string MOBOId { get; set; }
        public string BIOSId { get; set; }
        public string SMBIOSId { get; set; }
        public List<string> MonitorIds { get; set; }


       public HwiDs()
       {
            this.VolumeIds = Volumes();
            this.ControllerIds = Cim_Cntroller();
            this.GPUIds = GPU_CIM();
            this.KeyboardIds = Keyboard_CIM();
            this.MouseIds = Mouse_CIM();
            this.MacIds = MACS();
            this.WindowsKey = OSKEY();
            this.CPUId = CPUSerial();
            this.RamIds = RAMSerials();
            this.SSDIds = SSDSerials();
            this.MOBOId = MOBO();
            this.BIOSId = BIOSSerial();
            this.SMBIOSId = Smbios();
            this.MonitorIds = MonitorSerial();
       }



        private List<string> Volumes()
        {
            //volumes
            List<string> temp = new List<string>();
            var volume = new SelectQuery("CIM_StorageVolume");
            var mgmtvolume = new ManagementScope("root\\cimv2");
            mgmtvolume.Connect();
            var mgmt = new ManagementObjectSearcher(mgmtvolume, volume);
            
            foreach (var device in mgmt.Get())
            {
                temp.Add(device.GetPropertyValue("DeviceID").ToString());
            }

            return temp;
        }

        private List<string> Cim_Cntroller()
        {
            //cim controller
            List<string> temp = new List<string>();
            var con = new SelectQuery("CIM_Controller");
            var conScope = new ManagementScope("root\\cimv2");
            conScope.Connect();
            var mgmt = new ManagementObjectSearcher(conScope, con);
      
            foreach (var device in mgmt.Get())
            {
                temp.Add(device.GetPropertyValue("PNPDeviceID").ToString()); 
            }

            return temp;
        }

        private List<string> GPU_CIM()
        {
            //gpu
            List<string> temp = new List<string>();
            var gpu = new SelectQuery("CIM_PCVideoController");
            var gpuScope = new ManagementScope("root\\cimv2");
            gpuScope.Connect();
            var mgmt = new ManagementObjectSearcher(gpuScope, gpu);
          
            foreach (var device in mgmt.Get())
            {
                temp.Add(device.GetPropertyValue("PNPDeviceID").ToString());     
            }

            return temp;
        }

        private List<string> Keyboard_CIM()
        {
            //keyboard
            List<string> temp = new List<string>();
            var key = new SelectQuery("CIM_Keyboard");
            var keyScope = new ManagementScope("root\\cimv2");
            keyScope.Connect();
            var mgmt = new ManagementObjectSearcher(keyScope, key);
           
            foreach (var device in mgmt.Get())
            {
                temp.Add(device.GetPropertyValue("PNPDeviceID").ToString());   
            }

            return temp;
        }

        private List<string> Mouse_CIM()
        {
            //mouse
            List<string> temp = new List<string>();
            var mouse = new SelectQuery("CIM_PointingDevice");
            var mouseScope = new ManagementScope("root\\cimv2");
            mouseScope.Connect();
            var mgmt = new ManagementObjectSearcher(mouseScope, mouse);
           
            foreach (var device in mgmt.Get())
            {
                temp.Add(device.GetPropertyValue("PNPDeviceID").ToString());
            }

            return temp;
        }

        private List<HWIDChecker.MacAddresses> MACS()
        {
            List<HWIDChecker.MacAddresses> temp = new List<MacAddresses>();
            HWIDChecker.MacAddresses storage = new MacAddresses();
            //mac address
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
          
                storage.Name = nic.Name;
                storage.MacAddress = BitConverter.ToString(nic.GetPhysicalAddress().GetAddressBytes());

                temp.Add(storage);
            }

            return temp;
        }

        private string OSKEY()
        {
            //os product key
            var oskey = new SelectQuery("CIM_SoftwareElement");
            var osScope = new ManagementScope("root\\cimv2");
            osScope.Connect();
            var mgmt = new ManagementObjectSearcher(osScope, oskey);
            ManagementObject? obj = mgmt.Get().Cast<ManagementObject>().FirstOrDefault();

            return obj["SerialNumber"].ToString();
        }

        private string CPUSerial()
        {
            //cpu
            var cpukey = new SelectQuery("CIM_SoftwareElement");
            var cpuScope = new ManagementScope("root\\cimv2");
            cpuScope.Connect();
            var mgmt = new ManagementObjectSearcher(cpuScope, cpukey);

            ManagementObject? obj = mgmt.Get().Cast<ManagementObject>().FirstOrDefault();

            return obj["SerialNumber"].ToString();
        }

        private List<string> RAMSerials()
        {
            //ram
            List<string> temp = new List<string>();
            var ram = new SelectQuery("CIM_PhysicalMemory");
            var ramScope = new ManagementScope("root\\cimv2");
            ramScope.Connect();
            var mgmt = new ManagementObjectSearcher(ramScope, ram);
           
            foreach (var device in mgmt.Get())
            {
                temp.Add(device.GetPropertyValue("SerialNumber").ToString());
            }

            return temp;
        }

        private List<string> SSDSerials()
        {
            //harddrive
            List<string> temp = new List<string>();
            ManagementObjectSearcher mgmt = new
            ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
          
            foreach (ManagementObject obj in mgmt.Get())
            {
                temp.Add(obj["SerialNumber"].ToString());
            }

            return temp;
        }

        private string MOBO()
        {
            //mobo
            var mobo = new SelectQuery("CIM_Card");
            var moboScope = new ManagementScope("root\\cimv2");
            moboScope.Connect();
            var mgmt = new ManagementObjectSearcher(moboScope, mobo);
            ManagementBaseObject? obj = mgmt.Get().Cast<ManagementBaseObject>().FirstOrDefault();

           return obj.GetPropertyValue("SerialNumber").ToString();
        }

        private string BIOSSerial()
        {
            //bios 
            var bios = new SelectQuery("CIM_BIOSElement");
            var biosScope = new ManagementScope("root\\cimv2");
            biosScope.Connect();
            var mgmt = new ManagementObjectSearcher(biosScope, bios);
            ManagementBaseObject? obj = mgmt.Get().Cast<ManagementBaseObject>().FirstOrDefault();

            return obj.GetPropertyValue("SerialNumber").ToString();
        }

        private string Smbios()
        {
            //smbios serial
            ManagementObjectSearcher mgmt = new
            ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct");
            ManagementObject? obj = mgmt.Get().Cast<ManagementObject>().FirstOrDefault();
           
            return obj["UUID"].ToString();
        }


        private List<string> MonitorSerial()
        {
            //monitor
            List<string> temp = new List<string>();
            List<string> sKeys = new List<string>();
            System.Management.ManagementObjectSearcher MOS = new System.Management.ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_PnPEntity WHERE Service = 'monitor'");
            foreach (ManagementObject MO in MOS.Get())
            {
               
                string sPnPDeviceID = "";

                try
                {
                    sPnPDeviceID = MO["PNPDeviceID"].ToString();
                    sKeys.Add(@"SYSTEM\CurrentControlSet\Enum\" + sPnPDeviceID + @"\Device Parameters");
                    string sKey = @"SYSTEM\CurrentControlSet\Enum\" + sPnPDeviceID + @"\Device Parameters";
                    RegistryKey Display = Registry.LocalMachine.OpenSubKey(sKey, false);


                    //Define Search Keys
                    string sSerFind = new string(new char[] { (char)00, (char)00, (char)00, (char)0xff });
                    
                    //Get the EDID code
                    byte[] bObj = Display.GetValue("EDID", null) as byte[];
                    if (bObj != null)
                    {

                        Encoding utf = Encoding.GetEncoding("UTF-8");
                        string[] sDescriptor = new string[4];
                        sDescriptor[0] = Encoding.UTF7.GetString(bObj, 0x36, 18);
                        sDescriptor[1] = Encoding.UTF7.GetString(bObj, 0x48, 18);
                        sDescriptor[2] = Encoding.UTF7.GetString(bObj, 0x5A, 18);
                        sDescriptor[3] = Encoding.UTF7.GetString(bObj, 0x6C, 18);
                        



                        //Search the Keys
                        foreach (string sDesc in sDescriptor)
                        {
                            if (sDesc.Contains(sSerFind))
                            {
                                temp.Add(sDesc.Substring(4).Replace("\0", "").Trim());
                            }

                        }


                    }
                    Display.Close();
                }
                catch { continue; }

            }
            return temp;
        }
    }
}
