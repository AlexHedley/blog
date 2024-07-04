---
title: The Beginning of Blashing
# lead:
tags:
  - dashboard
  - dotnet
  - csharp
author: alexhedley
description: Build a beautiful dashboard
published: 2023-06-23
# image: /posts/images/blashing/bowtie_blazor_logo.png
# imageattribution: http://dashing.io/images/bowtie.png
---

Having worked with a [Dashing](https://github.com/Shopify/dashing) / [Smashing](https://github.com/Smashing/smashing) meant having to setup 💎 [Ruby](https://www.ruby-lang.org/en/), as this isn't a language I'm not familiar with there was a little bit of a barrier to entry. I've used in the past with some iOS projects but only in little bursts.

Having a discussion with a colleague they had a similar experience, now as we're both .NET enthusiasts the obvious choice was to port it to [.NET](https://dotnet.microsoft.com/) and since [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) is the hot stuff atm why not use that.

Before we start, we need a name...

**Blashing** ![Blashing](images/blashing/bowtie_blazor_logo.png "Blashing")

I know, clever! I don't know how I come up with such great names.

Next is create a [repo](https://github.com/AlexHedley/blashing) and the journey begins.

I've already made a start creating the original list of [widgets](https://github.com/Smashing/smashing/tree/master/templates/project/widgets): _clock_, _comments_, _graph_, _iframe_, _image_, _list_, _meter_, _number_, _text_. There is also a community of [Additional Widgets](https://github.com/Smashing/smashing/wiki/Additional-Widgets) that could be fun to port over too.

There's the grid system to think about, drag & drop capabilities, [Font Awesome](https://fontawesome.com/) icons and much, much more.

You can follow along with the progress using the GitHub [Project](https://github.com/users/AlexHedley/projects/2/views/2).

I'd like to use a Blazor WASM project to host a demo and documentation site showing the features.

## Links

- [Blashing](https://github.com/AlexHedley/blashing)

  - [Project](https://github.com/users/AlexHedley/projects/2/views/2)
  - Website - WIP

- [Dashing Website](http://dashing.io/)
  - [Code](https://github.com/Shopify/dashing)
- [Smashing Website](https://smashing.github.io/)
  - [Code](https://github.com/Smashing/smashing)
