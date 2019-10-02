using System;
using System.IO;
using System.Text;




namespace MyFileUtilities
{
    class GetFixedWidth
    {


        static void Main(string[] args)
        {

            //Check to see if the input file exists
            String path = @"C:\Users\208002021\Documents\Hooksett Projects\EM\Phase1c\MMCS";
            String pathtoread = @"MMCS-File.txt";
            String pathString1 = System.IO.Path.Combine(path, pathtoread);

            System.Console.WriteLine($"Opening Input File {pathtoread}...");
            if(!System.IO.File.Exists(pathString1))
            {
                Console.WriteLine($"Input file {pathString1} not found");
                Environment.Exit(0);
            }

            //Open the file as a stream
            var fileStream = new FileStream($"{pathString1}", FileMode.Open, FileAccess.Read);

            //Build the random output file name and path
            String pathtowrite = System.IO.Path.GetRandomFileName();
            String pathString2 = System.IO.Path.Combine(path, pathtowrite);
            Console.WriteLine($"Creating Output File {pathtowrite}...");
            if(System.IO.File.Exists(pathString2))
            {
                try
                {
                    System.IO.File.Delete(pathString2);
                    Console.WriteLine($"File {pathString2} deleted");
                } catch (Exception e) {
                    Console.WriteLine($"Unable to delete file {pathString2}");
                    Console.WriteLine($"Caught exception {e}");
                    Environment.Exit(0);
                }
            }

            //Create the random file
            StreamWriter fs = new StreamWriter(pathString2);


            //Parse each line of the file and process each of the fixed width fields
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                int i = 1;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine($"Reading line {i} with string length of {line.Length} characters");
    
                    string IdentificationNo = line.Substring(0,11);
                    string Barcode = line.Substring(18,10);
                    string Unknown1 = line.Substring(34,4);
                    string InventoryDate = line.Substring(43, 8);
                    string Nomenclature = line.Substring(52,24);
                    string SiteCode = line.Substring(78,1);
                    string Unknown2 = line.Substring(81,16);
                    string Unknown3 = line.Substring(101,19);
                    string Unknown4 = line.Substring(121,4);
                    string UnitNo = line.Substring(133,4);

                    Console.Clear();
                    Console.WriteLine($"Identification Number: \t {IdentificationNo} \n");
                    Console.WriteLine($"Barcode: \t {Barcode} \n");
                    Console.WriteLine($"Unknown1: \t {Unknown1} \n");
                    Console.WriteLine($"InventoryDate: \t {InventoryDate} \n");
                    Console.WriteLine($"Nomenclature: \t {Nomenclature} \n");
                    Console.WriteLine($"Site Code: \t {SiteCode} \n");
                    Console.WriteLine($"Unknown2: \t {Unknown2} \n");
                    Console.WriteLine($"Unknown3: \t {Unknown3} \n");
                    Console.WriteLine($"Unknown4: \t {Unknown4} \n");
                    Console.WriteLine($"Unit Number: \t {UnitNo} \n");
                    i++;
                    Console.ReadLine();

                    //Write the formatted output to the file
                    String outline = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", IdentificationNo, Barcode, Unknown1, InventoryDate, Nomenclature, SiteCode, Unknown2, Unknown3, Unknown4, UnitNo);
                    fs.WriteLine(outline, Encoding.UTF8);
                }
            }
            fs.Close();
            fileStream.Close();
        }

    }
}
