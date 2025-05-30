﻿namespace MauiApp1_noteapp.Models
{
    internal class AboutModel
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string Message => "This app is written in XAML and C# with .NET MAUI.";

        public string RedirectUrl = "https://aka.ms/maui";
    }
}
