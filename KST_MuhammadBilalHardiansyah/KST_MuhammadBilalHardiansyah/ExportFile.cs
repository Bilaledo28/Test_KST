using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Reflection;

namespace KST_MuhammadBilalHardiansyah
{
    class ExportFile
    {
      public  static void ExportFileToTxt(DataTable dtNama)
        {
            try
            {
                //File name to exported
                string fileName = "sorted-names-list.txt";
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);


                int i = 0;
                StreamWriter sw = null;

                sw = new StreamWriter(path, false);


                //loop each datatable to export
                foreach (DataRow row in dtNama.Rows)
                {
                    object[] array = row.ItemArray;

                    for (i = 0; i < array.Length - 1; i++)
                    {
                        if (array[i].ToString() != "@#$%123")
                        {

                            sw.Write(array[i].ToString() + " ");
                            //display names
                            Console.Write(array[i].ToString() + " ");
                        }

                    }
                    Console.Write(array[i].ToString());
                    sw.Write(array[i].ToString());
                    sw.WriteLine();
                    Console.WriteLine();
                }

                sw.Close();

                Console.WriteLine("Export Succes please check at : " + path);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
      
    }
}
