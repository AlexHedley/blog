---
title: Utility Blazor
tags:
    - programming
    - blazor
author: AlexHedley
# description: 
published: 2020-09-28
---

To add to my increasing collection of Utility apps I've decided to produce a [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) version.

I love the idea of writing the web app in C#, with minimal js, and being able to host it anywhere.

Azure Static Web Apps look like a nice option too.

- [Tutorial: Building a static web app with Blazor in Azure Static Web Apps](https://docs.microsoft.com/en-ca/azure/static-web-apps/deploy-blazor)
- [Blazor WebAssembly on Azure Static Web Apps](https://www.hanselman.com/blog/BlazorWebAssemblyonAzureStaticWebApps.aspx)

The initial site has been configured and is deploying:

- [Site](https://alexhedley.github.io/Utility-Blazor/)
- [Utility-Blazor Code](https://github.com/AlexHedley/Utility-Blazor)

I'm looking forward to trying out [bUnit](https://github.com/egil/bUnit) for Unit Testing.

I found a GitHub Action to deploy it to GitHub Pages, just a couple of tasks to modify the ouptut so it runs correctly.

Much like an AngularJS app you need to set the base href so the app loads properly.

```yml
- name: Change base-tag in index.html from / to blazor-test
  run: sed -i 's/<base href="\/" \/>/<base href="\/blazor-test\/" \/>/g' release/wwwroot/index.html
```

To help with routing make the *404* the same as the *index*.

```yml
- name: copy index.html to 404.html
  run: cp release/wwwroot/index.html release/wwwroot/404.html
```

As GHP uses jekyll add the following file so it doesnt use those settings.

```yml
- name: Add .nojekyll file
  run: touch release/wwwroot/.nojekyll
```

Next I just need to port the original feature set to this application.

## References

Thanks to [@Swimburger](https://github.com/Swimburger) for the GitHub Action for deploying the app to GitHub Pages

How to deploy ASP.NET Blazor WebAssembly to GitHub Pages
- https://swimburger.net/blog/dotnet/how-to-deploy-aspnet-blazor-webassembly-to-github-pages

 - BlazorGitHubPagesDemo (https://github.com/Swimburger/BlazorGitHubPagesDemo)
