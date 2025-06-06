---
title: Deploying .NET nocco using GitHub Action
lead: via GitHub Actions
# description: 
tags:
  - programming
  - dotnet
  - github
  - github-actions
  - yml
author: AlexHedley
published: 2025-05-13
image: /posts/images/dotNET/dotNET.png
imageattribution: https://neosmart.net/blog/new-dot-net-standard-framework-logo/
---

<!-- .NET nocco using GitHub Action -->
<!-- ![.NET](images/dotNET/dotNET.png ".NET") -->

In my previous blog post [.NET nocco](dotnet-nocco) I explained upgrading an old version of **nocco** to the latest, and making it a [.NET tool](dotnet-tool-example). Now that I have both of these setup and configured I can use [GitHub](https://github.com/) [Pages](https://pages.github.com/) to deploy my code.

```yaml
jobs:
    steps:
     - name: ⬇️ Install nocco
       run: dotnet tool install --global Nocco --version 0.2.0
```

It needs to be **N**occo with a capital N as I forgot to add `<ToolCommandName>nocco</ToolCommandName>` to the `.csproj`.

Once that is installed you can navigate to your source folder then run the tool.

```yaml
    - name: 📄 Generate Docs
      run: |
        cd src
        Nocco *.cs
```

Once the files have been generated you can save them to a `gh-pages` branch and deploy them as a static site.

```yaml
    - name: ⬇️ Commit docs to GitHub Pages
      uses: JamesIves/github-pages-deploy-action@v4.7.3
      with:
        branch: gh-pages
        folder: src/docs
```

Others are available

- https://github.com/JamesIves/github-pages-deploy-action
- https://github.com/actions/deploy-pages
- https://github.com/peaceiris/actions-gh-pages

As there isn't an index.html page generated if you go to the root page you will get an error. https://alexhedley.github.io/nocco-example/. Instead go directly to one of the files: https://alexhedley.github.io/nocco-example/nocco.html.

If there were multiple files a picker is generated and added to the top right of the screen where you can switch between all the files.

See the yaml source for full steps.

- https://github.com/AlexHedley/nocco-example/blob/main/.github/workflows/generate-docs-and-deploy.yml
  - https://raw.githubusercontent.com/AlexHedley/nocco-example/refs/heads/main/.github/workflows/generate-docs-and-deploy.yml

## </> Code

- https://github.com/AlexHedley/nocco-example
  - https://github.com/AlexHedley/nocco

## 🔗 Links

- https://github.com/dontangg/nocco
  - http://donwilson.net/nocco/
- https://ashkenas.com/docco/
