using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Collections;

namespace TestHello
{
    class Program
    {
        static void Main(string[] args)
        {
            // string currentdir = Directory.GetCurrentDirectory();
            string currentdir = @"C:\Users\Chris\Desktop\src";
            ctFiles(currentdir); 
            Console.WriteLine("\nSelect which type of files you'll like to move... \nuse * for all files \n"); // all * func
            string ext = @Convert.ToString(Console.ReadLine());
            moveDir(currentdir, ext);
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
            /*For Testing ...*
             Console.WriteLine("---Starting: Folder Organize---\n Select the User Directory you would like to use....\n");
             string userDirs = @"C:/Users/Chris";
             showDir(userDirs); // Display Directories
             Console.WriteLine("Enter Name of a directory listed above.\n");
             string sourceDir = userDirs +@"/"+ Convert.ToString(Console.ReadLine()); // Set source dir to use
             ctFiles(sourceDir);   // add ability to use sub folders
             Console.WriteLine("\nSelect which type of files you'll like to move... \nuse * for all files \n"); // all * func
             string ext = @Convert.ToString(Console.ReadLine());
             moveDir(sourceDir, ext);
             */
        }

        private static void showDir(string dir)
        {
            string result = "";
            int enumdircnt = 1;
            try
            {
                var selFiles = Directory.EnumerateDirectories(dir);
                foreach (string currentFile in selFiles)
                {   
                    string fileName = currentFile.Substring(dir.Length + 1);
                    result += "\nDir:" + enumdircnt +"| " + fileName + "\n";
                    enumdircnt++;
                }
                Console.WriteLine(result);  
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

        }
             
        private static void moveDir(string source, string ext) {
            string srcDir = source;
            string newDir = source + @"/"+ ext + "Files";
            string fileCon = "";
            ext = "*" + ext;
            try
            {
                if (Directory.Exists(newDir))
                {
                    Console.WriteLine("Duplicate Directory.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(newDir);
                Console.WriteLine("Dir created @ " + newDir + "\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                var files = Directory.EnumerateFiles(srcDir,ext);
                foreach (string currentFile in files)
                {

                    string fileName = Path.GetFileName(currentFile);
                    Directory.Move(currentFile, Path.Combine(newDir, fileName));
                    fileCon += fileName + "\n";                 

                }
                Console.WriteLine("Files Moved: \n" + fileCon);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
    }
        
        private static void ctFiles(string src)
        {
            int exeCt = 0;
            int pdfCt = 0;
            int mp3Ct = 0;
            int pptxCt = 0;
            int xlxsCt = 0;
            int docCt = 0;
            int txtCt = 0;
            int jpgCt = 0;
            int pngCt = 0;  
            int otherCt = 0;
            int totalCt = 0;
            
            try
            {
                var files = Directory.EnumerateFiles(src);
                foreach (string currentFile in files)
                {
                    totalCt++;
                    string ext = Path.GetExtension(currentFile);

                    switch (ext)
                    {

                        case ".exe":
                            exeCt++;
                            break;

                        case ".pdf":
                            pdfCt++;
                            break;
                        case ".mp3":
                            mp3Ct++;
                            break;
                        case ".pptx":
                            pptxCt++;
                            break;
                        case ".xlxs":
                            xlxsCt++;
                            break;
                        case ".txt":
                            txtCt++;
                            break;
                        case ".png":
                            pngCt++;
                            break;
                        case ".jpg":
                           jpgCt++;
                            break;

                        case ".doc":
                        case ".docx":
                            docCt++;
                            break;

                        default:
                            otherCt++;
                            break;

                    }

                 }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                Console.WriteLine("\nFiles:\n .exe: {0}\n .pdf: {1}\n .mp3: {2}\n .ppt: {3}\n .xls: {4}\n .doc: {5}\n .txt: {6}\n .jpg: {7}\n .png: {8}\n Other files: {9}\n Total Files: {10}\n", 
                    exeCt, pdfCt, mp3Ct, pptxCt, xlxsCt, docCt, txtCt,jpgCt,pngCt, otherCt,totalCt);
        }
    }
}