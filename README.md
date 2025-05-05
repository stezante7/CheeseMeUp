[![Build Status](https://github.com/stezante7/CheeseMeUp/actions/workflows/build.yml/badge.svg)](https://github.com/stezante7/CheeseMeUp/actions)

# CheeseMeUp 🧀

CheeseMeUp is a lightweight, Linux-friendly tray app that delivers delightful, cheese-themed compliments every 30 minutes — because everyone deserves to feel 
a little gouda. 😄

**Okay seriously, but why?**

> I wanted to start a new, simple project to test my Linux setup for .NET development.
So I thought to myself: what’s the cheesiest idea I can come up with? 🐵🙈

https://github.com/user-attachments/assets/d33791ab-6019-486a-9975-34f642d0f1c2


## Features

- 🧀 System tray icon using GTK#
- 🕒 Automatic compliments every 30 minutes
- 👆 Need cheese *now*? Click the tray icon to get instant dairy-based validation
- 🍽️ Right-click menu with:
  - Exit
  - Toggle "Start at Login"
- 🚀 Built with .NET 8 and GTK# on Linux

### Got cravings?

If you're in desperate need of a cheese compliment and simply can't wait 30 minutes,  
**just click the tray icon** and let the cheese work its emotional magic. 🧀✨  
No judgment — we all need a little cheddar love sometimes.

## Installation

➡️ [Download latest .deb](https://github.com/stezante7/CheeseMeUp/releases/latest/download/cheesemeup.deb)

### System Requirements

Install the following packages to ensure notifications and tray icon support:

```bash
sudo apt install libnotify-bin gnome-shell-extension-appindicator
```

- libnotify-bin: required for notify-send notifications to work
- gnome-shell-extension-appindicator: enables tray icons in GNOME/Pop!_OS

After installing the [AppIndicator extension](https://extensions.gnome.org/extension/615/appindicator-support/), you may need to log out and back in or enable it via GNOME Extensions.

#### CheeseMeUp install (.deb) 

```bash
sudo dpkg -i cheesemeup.deb

```


## Credits

- Cheese icon by [Freepik](https://www.iconfinder.com/Freepik) from [Iconfinder](https://www.iconfinder.com/) — used under [CC BY 3.0](https://creativecommons.org/licenses/by/3.0/)

## License

CheeseMeUp is licensed under the MIT License — see [LICENSE](./LICENSE) for details.
