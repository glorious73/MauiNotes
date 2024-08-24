using System;

namespace MauiNotes.Models;

public class About
{
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;
    public string MoreInfoUrl => "https://aka.ms/maui";
    public string Message => "This app is written by glorious73 in XAML and C# with .NET MAUI.";
}
