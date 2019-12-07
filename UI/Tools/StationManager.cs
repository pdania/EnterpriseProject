using System;
using DBModels;

namespace UI.Tools
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }

        public static FileWriter AutoLogin { get; } = new FileWriter($@"{Environment.CurrentDirectory}\Autologin.txt");
        public static FileWriter Logging { get; } = new FileWriter($@"{Environment.CurrentDirectory}\Log.txt");
    }
}