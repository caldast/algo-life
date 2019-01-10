using System;
using System.IO;

namespace Caldest.CSharpConcepts.Delegates
{
    /// <summary>
    /// All the Action delegates return void. 
    /// public delegate void Action<T>(T obj)
    /// </summary>
   
    class ActionDelegate
    {

        public void LogToConsole(string s)
        {
            Console.WriteLine(s);
        }

        public void LogToFile(string s)
        {
            File.WriteAllText("log.txt", s);
        }


        public void LogContents(string text,Action<string> a)
        {
            a(text);
        }

        public void Log(string textToLog)
        {
         

            Action<string> a = LogToConsole;
            a += LogToFile;

            a(textToLog);
        }

        public void LogContentsAnotherWay(string textToLog)
        {
            Action<string> a = LogToConsole;
            a += LogToFile;

            LogContents(textToLog, a);           

        }


    }
}
