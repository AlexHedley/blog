﻿using System.Threading.Tasks;
using Statiq.Alerts;
using Statiq.App;
using Statiq.Web;
using Statiq.Plugins;

return await Bootstrapper
  .Factory
  .CreateWeb(args)
  .AddTabGroupShortCode()
  .AddIncludeCodeShortCode()
  .AddAlertShortCodes()
  .AddConfigurator<Bootstrapper>(new ReadingTimeConfigurator())
  .RunAsync();