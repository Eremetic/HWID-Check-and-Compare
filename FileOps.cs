using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWIDChecker
{
    public class FileOps
    {

        public void OverWriteFile(string Filename, ListView Listview)
        {
            using (TextWriter TW = new StreamWriter(Filename))
            {
                TW.Write(string.Empty);

                try
                {
                    StringBuilder stringBuilder;


                    foreach (ListViewItem item in Listview.Items)
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

                TW.Close();
            }
        }


        public void CreatAndWrite(string Filename, ListView Listview)
        {
            try
            {
                var create = File.Create(Filename);
                create.Close();
            }
            catch (Exception)
            {
                return;
            }

            using (TextWriter TW = new StreamWriter(Filename))
            {
                try
                {
                    StringBuilder stringBuilder;


                    foreach (ListViewItem item in Listview.Items)
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


                TW.Close();
            }
        }
    }
}
