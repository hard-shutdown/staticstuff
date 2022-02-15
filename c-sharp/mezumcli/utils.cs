using System;
using System.IO;
using System.Diagnostics;

namespace MezumUtils
{
    public class Terminal
    {
        private static string CurrentDir = Directory.GetCurrentDirectory();
        private static string NewPath = (Environment.GetEnvironmentVariable("PATH") + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase) + "\\NixUtils;").Replace(@"file:\", "");
        public static void ExecuteCommand(string command)
        {
            Environment.SetEnvironmentVariable("PATH", NewPath);
            command = WinifyDir(command);
            Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = "/C \"" + command + "\"";
            proc.StartInfo.UseShellExecute = false; 
            proc.StartInfo.RedirectStandardOutput = false;
            proc.Start();

            /*while (!proc.StandardOutput.EndOfStream) {
                Console.WriteLine (proc.StandardOutput.ReadLine ());
            }*/
			proc.WaitForExit();
        }

        public static void ShowPrompt(string Directory) 
        {
            CurrentDir = Directory;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("(" + NixifyDir(CurrentDir) + ") ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("~> ");
            Console.ResetColor();
        }

        public static string NixifyDir(string Dir)
        {
            Dir = Dir.Replace(@"C:\Users\" + Environment.GetEnvironmentVariable("username"), "~");
            Dir = Dir.Replace(@"C:", "/c");
            Dir = Dir.Replace(@"\", "/");
            return Dir;
        }
        public static string WinifyDir(string Dir)
        {
            Dir = Dir.Replace("~", @"C:\Users\" + Environment.GetEnvironmentVariable("username"));
            Dir = Dir.Replace("/c", "C:");
            Dir = Dir.Replace("/", @"\");
            return Dir;
        }
    }
}
