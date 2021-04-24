using System;

namespace SampleCommon
{
    public static class Constants
    {
        public const string AppSettings = "AppSettings";
        public const string ConnectionSettingPath = "AppSettings:ConnectionStrings:Sample_API_DbConnection";
        public const string ConnectionStringsSectionName = "ConnectionStrings";
        public const string API_DbConnection = "Sample_API_DbConnection";

        public enum ToastLevel
        {
            Info,
            Success,
            Warning,
            Error
        }
    }
}
