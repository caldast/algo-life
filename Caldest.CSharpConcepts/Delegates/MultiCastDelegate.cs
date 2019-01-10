using System;
using System.IO;

namespace Caldest.CSharpConcepts.Delegates
{
    class MultiCastDelegate
    {
        public delegate void Log(string s);

        public void LogToFile(string s)
        {
            File.WriteAllText("log.txt",s);
        }

        public void LogToConsole(string s)
        {
            Console.WriteLine(s);
        }

        /// <summary>
        /// Pointing to multiple methods using delegates
        /// </summary>
        public void LogContents()
        {
            string s = "log this text";

            Log l = new Log(LogToFile);
            l += LogToConsole;
            l(s);
        }

        /// <summary>
        /// Calling method signagure with delegate to point multiple methods 
        /// </summary>
        public void LogContentsAnotherWay()
        {
            LogContents("Hello file", LogToFile);
            LogContents("Hello console", LogToConsole);
        }

        /// <summary>
        /// Passing delegate as param method
        /// </summary>
        /// <param name="content"></param>
        /// <param name="l"></param>
        private void LogContents(string content,Log l)
        {
            string s = $"{DateTime.UtcNow}: " + content;
            l(s);
        }

    }
}
