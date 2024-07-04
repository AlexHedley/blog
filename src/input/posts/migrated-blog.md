---
title: Migrated Blog
# lead:
tags:
  - github
  - statiq.web
  - static site generator
  - markdown
author: alex-hedley
description: The journey to a new blog platform.
published: 2023-06-09
image: /posts/images/statiq-web.svg
imageattribution: https://www.statiq.dev/assets/statiq-web.svg
---

A couple of weeks ago I finally decided to migrate my Blog to [Statiq Web](https://www.statiq.dev/web).

> Statiq Web is a powerful static web site generation toolkit suitable for most use cases. It's built on top of [Statiq Framework](https://www.statiq.dev/framework) so you can always extend or customize it beyond those base capabilities as well.

It's predecessor was [Wyam](https://wyam.io/).

I wanted to use a .NET tool to create my blog as you know my passion for .NET, so the journey began.

My blog(s) have existed in a number of formats. The first one was made in about 2010 using Classic ASP and a [Microsoft Access](https://www.microsoft.com/en-gb/microsoft-365/access). I'd been learning this on [599CD](https://www.599cd.com/) so was putting it into practice. A few years later I started a ![Wordpress](../images/wordpress.png "Wordpress") Wordpress blog at [https://alexhedley.wordpress.com/](https://alexhedley.wordpress.com/). This contained a majority of my iOS and Android journey. I used [gist](https://gist.github.com/alexhedley) to host a lot of the code as it has support for that. Then I moved over to [Jekyll Now](https://github.com/barryclark/jekyll-now) as I started hosting on GitHub. As these were already in [Markdown](https://daringfireball.net/projects/markdown/syntax) it was just a couple of attribute changes and they were ready. Next I tackled my original blog. I'd exported the data from the db as `json` and was hosting it as a simple [AngularJS](https://angularjs.org/) app just so it wasn't lost, hadn't really put any effort into styling and as there were only a few posts I manually converted the posts needed to md. Next was the fun one! ![Wordpress](../images/wordpress.png "Wordpress") Wordpress. I exported my existing data following the steps on [Export Your WordPress.com Site](https://wordpress.com/support/export/). I then needed a way to convert this output to Markdown. I tried this a few years back and couldn't get it working but when I looked again I found: [wordpress-export-to-markdown](https://github.com/lonekorean/wordpress-export-to-markdown). It has a nice little guided tour of steps and then I got my output. The images were also included so this meant just moving them over to the new repo. Some of the attributes were different so an update to those and I was good to go.

I've got all the data now I need to setup the **Statiq.Web** project. There's a [Quick Start](https://www.statiq.dev/web) on the main page.

`dotnet new console --name MySite`

`cd MySite`

`dotnet add package Statiq.Web --version 1.0.0-beta.57`

Check for the latest version: [nuget - Statiq.Web](https://www.nuget.org/packages/Statiq.Web/1.0.0-beta.57)

Update [Program.cs](../src/Program.cs)

```csharp
using System.Threading.Tasks;
using Statiq.App;
using Statiq.Web;

return await Bootstrapper
  .Factory
  .CreateWeb(args)
  .RunAsync();
```

`mkdir input`

`touch index.md`

```md
## Title: My First Statiq page

# Hello World!

Hello from my first Statiq page.

Testing
```

`dotnet run`

`dotnet run -- preview`

- http://localhost:5080

**Theme**

`cd src`

`git submodule add https://github.com/statiqdev/CleanBlog.git theme`

If you want to make any changes to the theme you might want to copy this locally.

**Settings**

`appsettings.json`

Update the `"LinkRoot": "/blog",` if you're not hosting on your _github.io_ root.

Next step was adding extra functionality. I ❤ [Mermaid](https://mermaid.js.org/) and wanted a way to support this. Now came the issue, I found another blog generating it from a separate md file and converting it to a picture, this was all done as a build step. As it's a static site this really should be the way I do it, but then when you link it to your page you have to know the filename before it's generated and it won't preview before hand. I instead opted for adding the js and doing it dynamically, see [Mermaid](mermaid) for more info on how.

In other SSG I've used a tab group to display information, for example in [MFractor](https://www.mfractor.com/), see [Open Android Manifest](https://docs.mfractor.com/android/tools/open-android-manifest/) ([Source](https://github.com/mfractor/mfractor.github.io/blob/docs/docs/android/tools/open-android-manifest.md)). It uses the [Content tabs](https://squidfunk.github.io/mkdocs-material/reference/content-tabs/) feature of [Material for MkDocs](https://squidfunk.github.io/mkdocs-material/).

To use this just add the [nuget](https://www.nuget.org/packages/Devlead.Statiq) then in the page you wish to add the `tabs` syntax.

```html
<?# TabGroup ?>
<?*
tabs:
  - name: Tab One
    content: |
    ...
  - name: Tab Two
    content: |
    ...
?>
<?#/ TabGroup ?>
```

I prefer this over others as it's really easy to see what is happening.
[docfx](https://dotnet.github.io/docfx/) uses a `md` syntax which keeps it consistent but then previewers have a hard time with this.

Another really handy plugin is `IncludeCode`. This could be used instead of hosting as a [gist](https://gist.github.com/alexhedley) or including large amounts of code in the post. You could also reference code from a single place and only have to update it once.

`<?# IncludeCode "./../_head.cshtml" /?>`

`src/input/_head.cshtml`

I was getting decent analytics on my WP site and prob had it on others so I've added that here too. Just a few lines of code in your `src/input/_scripts.cshtml`

Another thing I wanted to do was keep the commit history of when I wrote the posts, so I did this manually with:

`GIT_COMMITTER_DATE="Mon 20 Aug 2018 20:19:19 BST" git commit --amend --no-edit --date "Mon 20 Aug 2018 20:19:19 BST"`

Finally as usual I needed a way to build and deploy so I used GitHub Actions and GitHub Pages, there are links below and you can see the source of this blog for exact steps.

There are other updates I'm planning on adding like Search, a Header image etc, so check those out in the future.

---

## Mermaid

- [Mermaid](mermaid)

- [Using Mermaid diagrams with Statiq.](https://www.dpvreony.com/articles/mermaid-with-statiq/)
  - [repo](https://github.com/dpvreony/article-statiq-mermaid)
- [Mermaid Diagrams in Statiq](https://blog.beckshome.com/2022/09/mermaid-in-statiq)

  - [code](https://github.com/thbst16/dotnet-statiq-beckshome-blog/blob/main/input/posts/mermaid-in-statiq.md)

- [StatiqMermaid Repo](https://github.com/ociaw/StatiqMermaid)
  - [nuget](https://www.nuget.org/packages/Ociaw.StatiqMermaid/0.1.0-beta.2)

---

## Plugins

- [nuget - Devlead.Statiq](https://www.nuget.org/packages/Devlead.Statiq)

- [Devlead.Statiq - Part 1 - Tabs](https://www.devlead.se/posts/2021/2021-04-09-devlead-statiq-part1-tabs)
- [Devlead.Statiq - Part 2 - Theme from external web resource](https://www.devlead.se/posts/2021/2021-04-10-devlead-statiq-part2-theme-from-uri)
- [Devlead.Statiq - Part 3 - IncludeCode 🤺](https://www.devlead.se/posts/2021/2021-04-11-devlead-statiq-part3-includecode)

---

## Links

- [devlead](https://www.devlead.se)

  - [Source](https://github.com/devlead/devlead.se)
  - [Devlead.Statiq - Part 1 - Tabs](https://www.devlead.se/posts/2021/2021-04-09-devlead-statiq-part1-tabs)

- [Alexandre Nédélec](https://www.techwatching.dev/)

  - [Source](https://github.com/TechWatching/techwatching.dev)

- [Thomas Beck](https://beckshome.com/)

  - [Source](https://github.com/thbst16/dotnet-statiq-beckshome-blog)
  - [Beckshome on Statiq](https://beckshome.com/2022/09/beckshome-on-statiq)

- [The Freeze Team](https://thefreezeteam.com/)

  - [Source](https://github.com/TheFreezeTeam/TheFreezeTeamBlog/tree/master/Source/TheFreezeTeamBlog)

- [Structed](https://blog.structed.me/)

  - [https://github.com/structed](https://github.com/structed)

- [C# Tutorials Blog](https://wellsb.com/csharp/)
  - [Source](https://github.com/bradwellsb/statiq-blog-boilerplate)

### Config

- [Settings](https://www.statiq.dev/guide/configuration/settings)
- [Web Settings](https://www.statiq.dev/guide/configuration/web-settings)

### Deploy

- [GitHub Pages](https://www.statiq.dev/guide/deployment/github-pages)
- [Deploying Statiq Web to GitHub Pages](https://forloop.co.uk/blog/deploying-statiq-web-to-github-pages) 15 September 2022 by Russ Cam
- [Build and deploy a Statiq site to Github Pages in 5 min](https://thefreezeteam.com/posts/steven-t-cramer/2022/09/23/statiq-github-pages) FRIDAY, 23 SEPTEMBER 2022 Steven T. Cramer

## Legacy

- https://github.com/AlexHedley/blog_legacy
- https://github.com/AlexHedley/wordpress
- https://github.com/AlexHedley/blog_2020
