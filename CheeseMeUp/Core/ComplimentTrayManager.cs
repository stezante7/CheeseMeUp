using System.Diagnostics;
using Gdk;
using Gtk;
using Timer = System.Timers.Timer;

namespace CheeseMeUp.Core;

public class ComplimentTrayManager(IComplimentService complimentService) : IComplimentTrayManager
{
    private readonly string _iconPath = Path.Combine(AppContext.BaseDirectory, "Assets/cheese_1.png");

    private static string DesktopFileName => "cheesemeup.desktop";

    private static string AutoStartPath => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "autostart", DesktopFileName);

    public async Task RunTray()
    {
#pragma warning disable CS0612
        var trayIcon = new StatusIcon(new Pixbuf("Assets/cheese_1.png"))
        {
            Visible = true,
            TooltipText = "CheeseMeUp 🧀"
        };
#pragma warning restore CS0612

        trayIcon.Activate += async (_, _) => { await SendCheeseComplimentNotification(); };

        trayIcon.PopupMenu += (_, _) =>
        {
            var menu = new Menu();

            var autostartItem = new CheckMenuItem("Start at login")
            {
                Active = IsAutoStartEnabled()
            };
            autostartItem.Toggled += (_, _) =>
            {
                if (autostartItem.Active)
                    EnableAutoStart();
                else
                    DisableAutoStart();
            };
            menu.Append(autostartItem);

            var exitItem = new MenuItem("Exit");
            exitItem.Activated += (_, _) => Application.Quit();
            menu.Append(exitItem);

            menu.ShowAll();
            menu.Popup();
        };

        await SendCheeseComplimentNotification();
        SetupComplimentTimer();
    }

    private static bool IsAutoStartEnabled()
    {
        return File.Exists(AutoStartPath);
    }

    private static void EnableAutoStart()
    {
        var source = "/usr/share/applications/" + DesktopFileName;
        Directory.CreateDirectory(Path.GetDirectoryName(AutoStartPath)!);
        File.Copy(source, AutoStartPath, true);
    }

    private static void DisableAutoStart()
    {
        if (File.Exists(AutoStartPath))
            File.Delete(AutoStartPath);
    }

    private async Task SendCheeseComplimentNotification()
    {
        var compliment = await complimentService.PickCompliment();
        var title = $"CheeseMeUp ({DateTime.Now:HH:mm:ss})";
        Process.Start("/usr/bin/notify-send",
            $"-i \"{_iconPath}\" --hint=int:transient:1 \"{title}\" \"{compliment}\"");
    }

    private void SetupComplimentTimer()
    {
        var timer = new Timer
        {
            Interval = TimeSpan.FromMinutes(30).TotalMilliseconds,
            AutoReset = true,
            Enabled = true
        };

        timer.Elapsed += async (_, _) => { await SendCheeseComplimentNotification(); };
    }
}