using CheeseMeUp.Core;
using Gtk;
using Microsoft.Extensions.DependencyInjection;


// Start GTK
Application.Init();

// Setup DI
var services = new ServiceCollection();

services.AddSingleton<IComplimentService, ComplimentService>();
services.AddSingleton<IComplimentTrayManager, ComplimentTrayManager>();

var provider = services.BuildServiceProvider();

await provider.GetRequiredService<IComplimentTrayManager>().RunTray();

Application.Run();