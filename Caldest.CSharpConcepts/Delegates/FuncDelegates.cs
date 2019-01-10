using System;
using System.IO;
using System.Text;

namespace Caldest.CSharpConcepts.Delegates
{
    /// <summary>
    /// All Func delegates return something
    /// public delegate TResult Func<TResult>()
    /// Sample code using Func delegates in C#
    /// </summary>
    class FuncDelegates
    {
        public string ConsoleFormattedText(string s)
        {
            return s;
        }

        public string FileFormattedText(string s)
        {
            return $"<s>{s}</s>";
        }

        public void LogContents(string logText)
        {         

            Func<string,string> func = ConsoleFormattedText;
            func += FileFormattedText;

            func(logText);
        }

        private void LogContents(Func<string,string> func)
        {
            var sb = new StringBuilder();
            sb.Append($"{DateTime.UtcNow}: " + "Hello world!");
            sb.Append($"{DateTime.UtcNow}: " + "Hello world Again!");
            sb.Append($"{DateTime.UtcNow}: " + "Hello world Again Again!");
            func(sb.ToString());
        }

        public void LogContentsAnotherWay(string logText)
        {
            Func<string,string> func = ConsoleFormattedText;
            func+= FileFormattedText;
            LogContents(func);
        }

    }
}
