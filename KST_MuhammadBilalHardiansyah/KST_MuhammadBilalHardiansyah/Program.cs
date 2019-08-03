using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Data;

namespace KST_MuhammadBilalHardiansyah
{
    class Program
    {
      public  DataTable dtNama = new DataTable();      
      

        static void Main(string[] args)
        {
            try
            {

                DataTable dtTemp = new DataTable();
                dtTemp.Columns.Add("First Name", typeof(string));
                dtTemp.Columns.Add("Mid Name", typeof(string));
                dtTemp.Columns.Add("Last Name", typeof(string));
                NamaLengkapList NamaList;
                int NamaLength;
                string fileName = "unsorted-names-list.txt";
               string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);

               using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine("Reading " + fileName + " maximum 3 word of name can be sorted");
                    string line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Split string on spaces.
                        // ... This will separate all the words.
                        string[] words = line.Split(' ');
                       
                        NamaLength = words.Length;
                        if (NamaLength == 3 || NamaLength == 2 || NamaLength == 1)
                        {
                            Console.WriteLine(line);
                        }
                        
                        NamaList = new NamaLengkapList();
                        // Check Length word of name
                        // @#$%123 = use to counter if names not in 3 words
                        if (NamaLength == 3)
                        {
                            NamaList.FirstName = words[0].ToString();
                            NamaList.MidName = words[1].ToString();
                            NamaList.LastName = words[2].ToString();
                            dtTemp.Rows.Add(NamaList.FirstName, NamaList.MidName, NamaList.LastName);
                        }
                        else if (NamaLength == 2)
                        {
                            NamaList.FirstName = "@#$%123";
                            NamaList.MidName = words[0].ToString();
                            NamaList.LastName = words[1].ToString();
                            dtTemp.Rows.Add(NamaList.FirstName, NamaList.MidName, NamaList.LastName);
                        }
                        else if (NamaLength == 1)
                        {
                            NamaList.FirstName = "@#$%123";
                            NamaList.MidName = "@#$%123";
                            NamaList.LastName = words[0].ToString();
                            dtTemp.Rows.Add(NamaList.FirstName, NamaList.MidName, NamaList.LastName);
                        }



                    }
                }

                // Call to sorting names
                SortName(dtTemp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                

                
            }
          }



        static void SortName(DataTable dt)
        {
            Console.WriteLine("");
            Console.WriteLine("Execute to Sort Name :");
            string Inpput = Console.ReadLine();
            DataTable sortedDT = new DataTable();

            bool SecondLoop = false;
            try
            {
                do
                {
                    if (SecondLoop == true)
                    {
                        Console.WriteLine("Execute to Sort Name :");
                        Inpput = Console.ReadLine();
                    }


                    if (Inpput != "name-sorter ./unsorted-names-list.txt")
                    {
                        Console.WriteLine("Wrong Exceute format, you must type : name-sorter ./unsorted-names-list.txt");
                        
                        
                    }
                    else
                    {
                        DataView dv = dt.DefaultView;
                        dv.Sort = "Last Name asc";
                         sortedDT = dv.ToTable();
                        
                    }
                    SecondLoop = true;
                    
                } while (Inpput != "name-sorter ./unsorted-names-list.txt");

                //Call to display and export file
               ExportFile.ExportFileToTxt(sortedDT);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

       
    }
}
