using System;
using System.IO;
using System.Diagnostics;

using MezumUtils;

class MezumTerminal
{

    public static void Main (string[] args)
    {
		while (true)
		{
			Terminal.ShowPrompt(Directory.GetCurrentDirectory());
      		string cmd = Console.ReadLine();
            if (cmd == "exit")
            {
				System.Environment.Exit(0);
            }
            else if (cmd.StartsWith("cd "))
            {
                cmd = cmd.Replace("cd ", "");
                cmd = Terminal.WinifyDir(cmd);            
                try
                {
                    Directory.SetCurrentDirectory(cmd);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The specified directory does not exist");
                }
            }
            else 
            {
                Terminal.ExecuteCommand(Terminal.WinifyDir(cmd));
            }	
		}	
    }
}
