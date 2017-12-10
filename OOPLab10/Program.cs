using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

using System.Reflection;
using System.IO;


namespace OOPLab10
{

    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                SVVLog.Create();
                SVVDiskInfo.DiskAll();
                SVVDiskInfo.DiskAvailableFreeSpace("D:\\");
                SVVDiskInfo.DiskDriveFormat("D:\\");
                Console.WriteLine("------------------------------------");
                SVVFileInfo.Way();
                SVVFileInfo.Size();
                SVVFileInfo.Time();
                Console.WriteLine("------------------------------------");
                SVVDirInfo.Count();
                SVVDirInfo.Time();
                SVVDirInfo.Subdir(@"C:\Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug");
                SVVDirInfo.Parents();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("------------------------------------");
                SVVFileManager.CreateDirAndFile();
                Console.WriteLine("Click to continue");
                Console.ReadKey();
                SVVFileManager.Copy();
                SVVFileManager.CreateNewDirectory();
                Console.WriteLine("Click to continue");
                Console.ReadKey();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                SVVLog.Close();
                SVVLog.ShowLogDay();
                Console.WriteLine("-----------------");
                SVVLog.ShowLogKey();
                Console.WriteLine("-----------------");
                SVVLog.ShowLogTime();
                Console.WriteLine("-----------------");
                SVVLog.DeleteLog();
            }



            Console.ReadKey();
        }



        static class SVVFileManager
        {
            static string diskName = "E:\\";
            static string dirName = "SVVInspect";
            static string fileName = "SVVInspect\\SVVdirinfo.txt";
            static string fileName2 = "SVVInspect\\SVVdirinfoCopy.txt";
            static string newdir = "SVVFiles";
            static string Extension = ".txt";

            static public void CreateDirAndFile()
            {
                DirectoryInfo dir = new DirectoryInfo(@"C:\Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug");
                dir.CreateSubdirectory(dirName);
                SVVLog.WriteLog(@"Create C: \Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug\"+ dirName);

                FileInfo fi = new FileInfo(fileName);
                FileStream ff = fi.Create();
                SVVLog.WriteLog("Create "+ fileName);
                string[] d = Directory.GetDirectories(diskName);
                SVVLog.WriteLog(@"Show " + diskName);

                foreach (string i in d)
                {
                    byte[] input = Encoding.Default.GetBytes(i);
                    ff.Write(input, 0, input.Length);
                }
                ff.Close();
            }
            static public void Copy()
            {
                FileInfo File = new FileInfo(fileName);
                SVVLog.WriteLog("Copy_in " + fileName2);

                FileInfo File2 = new FileInfo(fileName2);
                if (File2.Exists) File2.Delete();
                    File.CopyTo(fileName2);
                File.Delete();
            }
            static public void CreateNewDirectory()
            {

                DirectoryInfo dir = new DirectoryInfo(@"C:\Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug");
                dir.CreateSubdirectory(newdir);
                SVVLog.WriteLog(@"Create  C:\Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug" + newdir);
                DirectoryInfo dirinf = new DirectoryInfo(diskName);

                FileInfo[] FILEINF = dirinf.GetFiles();
                string st=null;
                foreach (FileInfo f in FILEINF)
                {
                    if (f.Extension != Extension) continue;
                     st = newdir + "\\" + f.Name;
                    FileInfo File2 = new FileInfo(st);
                    if (File2.Exists) File2.Delete();
                    f.CopyTo(st);
                }
                SVVLog.WriteLog(@"Copy_in " + st);


            }


        }



        static class SVVDirInfo
        {
            static public void Count()
            {
                var dir = new DirectoryInfo(@"C:\Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug");
                if (dir.Exists)
                {
                    Console.WriteLine("Files = " + dir.GetFiles().Length);
                }
                else
                {
                    Console.WriteLine("Not foud");
                }
                Console.WriteLine();

            }
            static public void Time()
            {
                if (Directory.Exists(@"C:\Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug"))
                {
                    Console.WriteLine("Time: " + Directory.GetCreationTime(@"C:\Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug"));
                }
                else
                {
                    Console.WriteLine("Not foud");
                }
                Console.WriteLine();

            }
            static public void Subdir(string s)
            {
                if (Directory.Exists(s))
                {
                    Console.WriteLine("Count subdir: " + Directory.GetDirectories(@"C:\Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug").Length);
                }
                else
                {
                    Console.WriteLine("Not foud");
                }
                Console.WriteLine();

            }
            static public void Parents()
            {
                if (Directory.Exists(@"C:\Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug"))
                {
                    string st = Directory.GetParent(@"C:\Users\User\Desktop\Lab OOP\Lab13\OOPLab10\bin\Debug").ToString();
                    Console.WriteLine();

                    while (true)
                    {
                        object tt = Directory.GetParent(st);
                        if (tt == null) break;
                        Console.WriteLine(tt.ToString());
                        st = tt.ToString();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Not foud");
                }
                Console.WriteLine();
            }
        }

        static class SVVFileInfo
        {
            static FileInfo fileInf= new FileInfo("SVVLog.txt");
            static public void Way()
            {
                if(fileInf.Exists)
                {
                    Console.WriteLine(fileInf.DirectoryName);
                }
                else
                {
                    Console.WriteLine("Not fund");
                }
            }
            static public void Size()
            {
                if (fileInf.Exists)
                {
                    Console.WriteLine("Name " + fileInf.Name);
                    Console.WriteLine("Size "+  fileInf.Length);
                    Console.WriteLine("Extension "  + fileInf.Extension);

                }
                else
                {
                    Console.WriteLine("Not fund");
                }
            }
            static public void Time()
            {
                if (fileInf.Exists)
                {
                    Console.WriteLine("Time Create: " +File.GetCreationTime("SVVLog.txt"));
                }
                else
                {
                    Console.WriteLine("Not fund");
                }
            }


        }

        static class SVVDiskInfo
        {
            public static void DiskAvailableFreeSpace(string s)
            {
                var d = new DriveInfo(s);
               
                                
                Console.WriteLine("Memory "+d.Name+"  " +d.AvailableFreeSpace);
                
                Console.WriteLine();

            }
            public static void DiskDriveFormat(string s)
            {
                var d = new DriveInfo(s);
                
                    Console.WriteLine("DriveFormat "+d.Name + "  " + d.DriveFormat);
                
                Console.WriteLine();

            }
            public static void DiskAll()
            {
                var disk = DriveInfo.GetDrives();
                foreach (var d in disk)
                {
                    Console.WriteLine("Name: " + d.Name);
                    Console.WriteLine("DriveFormat: " + d.DriveFormat);
                    Console.WriteLine("TotalFreeSpace: " + d.TotalFreeSpace);
                    Console.WriteLine("AvailableFreeSpace: " + d.AvailableFreeSpace);
                }
                Console.WriteLine();
            }
        }

        static class SVVLog
        {
           static StreamWriter FileLog;
           static FileInfo fileInf;

            public static void  Create()
            {
                FileLog = new StreamWriter("SVVLog.txt", true, System.Text.Encoding.Default);
                fileInf = new FileInfo("SVVLog.txt");

                if (!fileInf.Exists)
                {
                    throw  new Exception("Not opened SVVLog.txt");
                }
            }
            public static void Close()
            {
                fileInf = new FileInfo("SVVLog.txt");
                if (fileInf.Exists)
                {
                    FileLog.Close();
                }

            }


            public static void WriteLog(string st)
            {
                FileLog.WriteLine(DateTime.Now.ToString()+"   "+st);
            }
            public static void ShowLogDay()
            {
                int day = 15;
                using (StreamReader sr = new StreamReader("SVVLog.txt"))
                {

                    while (!sr.EndOfStream) {
                        string str = sr.ReadLine();
                        string[] Mas = str.Split('.');
                        int t = Int32.Parse(Mas[0]);
                        if(t==day)Console.WriteLine(t);
                    }

                }
            }
            public static void ShowLogKey()
            {
                using (StreamReader st = new StreamReader("SVVLog.txt"))
                {
                    while (!st.EndOfStream)
                    {
                        string str = st.ReadLine();
                        int ind = str.IndexOf("Create", StringComparison.CurrentCulture);
                        if (ind > 0) Console.WriteLine(str);
                    }
                }
            }
            public static void ShowLogTime()
            {
                int t1= Int32.Parse("10") * 3600 + Int32.Parse("20") * 60 + Int32.Parse("00");
                int t2 = Int32.Parse("10") * 3600 + Int32.Parse("30") * 60 + Int32.Parse("00");

                using (StreamReader st = new StreamReader("SVVLog.txt"))
                {
                    while (!st.EndOfStream)
                    {
                        string str = st.ReadLine();
                        string[] Mas = str.Split(' ',':');
                        int t = Int32.Parse(Mas[1]) * 3600 + Int32.Parse(Mas[2]) * 60 + Int32.Parse(Mas[3]);
                        if (t >= t1 && t <= t2) Console.WriteLine(str);
                    }
                }
            }

            public static void DeleteLog()
            {
                DateTime time = DateTime.Now;
                FileInfo file = new FileInfo("SVVLog2.txt");
                FileInfo LOG = new FileInfo("SVVLog.txt");


                if (file.Exists) file.Delete();
                file.Create().Close();
                StreamWriter fw= new StreamWriter("SVVLog2.txt", true, System.Text.Encoding.Default);

                using (StreamReader st = new StreamReader("SVVLog.txt"))
                {
                    while (!st.EndOfStream)
                    {
                        string str = st.ReadLine();
                        string[] Mas = str.Split(' ', ':');
                        int t = Int32.Parse(Mas[1]);
                        if ((t - time.Hour) == 0)
                        {
                            fw.WriteLine(str);
                        }
                    }
                    fw.Close();
                    st.Close();
                    LOG.Delete();
                    file.CopyTo("SVVLog.txt");
                    file.Delete();
                }
            }
        }
       

        ///////////////////////+
    }
}
