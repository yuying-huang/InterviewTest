
namespace InterviewTestMid
{
    internal interface ILogger
    {
        void WriteLogMessage(string LogMessage);
        void WriteErrorMessage(Exception Ex);
        void WriteCsvMessage(List<string> Lines);
    }
}
