using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestMid
{
    internal class TimestampLogger : ILogger
    {
        public void WriteLogMessage(string LogMessage)
        {
            if (string.IsNullOrEmpty(LogMessage))
                throw new ArgumentException("Log message not provided", "LogMessage");
            string timestampedMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {LogMessage}";
            Debug.WriteLine(timestampedMessage);
        }

        public void WriteErrorMessage(Exception Ex)
        {
            if (Ex == null)
                throw new ArgumentException("Exception not provided", "Ex");

            Debug.WriteLine($"Error recieved: {Ex.Message}");
            Debug.WriteLine($"{Ex.StackTrace}");
        }
        public void WriteCsvMessage(List<string> Lines)
        {
            if (Lines == null || Lines.Count == 0)
                throw new ArgumentException("Lines not provided", "Lines");

            string filePath = Path.Combine(AppContext.BaseDirectory, "LogOutput.csv");
            File.WriteAllLines(filePath, Lines);

            Debug.WriteLine($"CSV log written to: {filePath}");
        }
    }
    }
