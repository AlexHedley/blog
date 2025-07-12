---
title: .NET by Example
# lead: 
description: .NET by Example is a hands-on introduction to .NET using annotated example programs.
tags:
  - programming
  - dotnet
  - csharp
author: AlexHedley
published: 2025-06-06
image: /posts/images/dotNET/dotNET.png
imageattribution: https://neosmart.net/blog/new-dot-net-standard-framework-logo/
---

<!-- .NET by Example -->
<!-- ![.NET](images/dotNET/dotNET.png ".NET") -->

In this post I will explain how I built **.NET by Example**, a clone of [Go by Example](https://gobyexample.com/), using the updated [nocco](dotnet-nocco) tool I've recently been working on.

I've modified the code a little to take a list of files: `.cs`, `.vb`, `.fs`, in a folder, with a `.bat` to explain how to run the provided scripts and it builds a tabbed page of each of the files.

It also has a _copy_ button option to make working with the code a little easier.

![Hello World](images/dotNET/byexample/hello-world.png "Hello World")

The home page is then built with the list of the examples.

![Home](images/dotNET/byexample/home.png "Home")

If you have any ideas of other examples please add a new 💡[Discussion](https://github.com/AlexHedley/dotnetbyexample/discussions/new?category=ideas) item. I'll be working on adding more in the near future.

I added a build and deploy [script](https://github.com/AlexHedley/dotnetbyexample/blob/main/.github/workflows/build-deploy.yml) via GitHub Actions and deployed it via GitHub Pages: https://alexhedley.github.io/dotnetbyexample.

## </> Code

- https://alexhedley.github.io/dotnetbyexample
  - https://github.com/AlexHedley/dotnetbyexample

## 🔗 Links

- https://github.com/mmcgrana/gobyexample
  - https://gobyexample.com/
