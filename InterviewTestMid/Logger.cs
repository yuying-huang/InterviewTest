using System.Diagnostics;
using System.IO;

namespace InterviewTestMid
{
    internal class Logger : ILogger
    {
        public void WriteLogMessage(string LogMessage)
    {
        if (string.IsNullOrEmpty(LogMessage))
            throw new ArgumentException("Log message not provided", "LogMessage");

        Debug.WriteLine(LogMessage);
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