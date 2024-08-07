---
title: Build Light
# lead:
tags:
  - dotnet
  - programming
  - github
  - iot
author: AlexHedley
# description:
published: 2020-06-20
# image:
# imageattribution:
---

[Build Light](https://github.com/praeclarum/BuildLight) is a way to _display your IDE's build status using RGB LEDs and IoT devices!_

It's being built by [@praeclarum](http://twitter.com/praeclarum) on his [Twitch](https://twitch.tv/FrankKrueger) channel the last few sunday nights.

It's an ESP32 device running a mini web server that when connected to a set of RGB lights will toggle the colour from red (for a failed build) to green (for a successful build) in Visual Studio for Mac.

It even has support in Alexa so you can turn it on and off.

For my first Twitch stream ([YouTube Archive](https://www.youtube.com/watch?v=It13T8YBX8g)) I built the Windows version of the Build Light Extension. See [PR !7](https://github.com/praeclarum/BuildLight/pull/7)

This was a fun new challenge having never worked in the [VS SDK](https://docs.microsoft.com/en-us/visualstudio/extensibility/visual-studio-sdk?view=vs-2019) before.

I'm hoping to spend some mode time in this SDK for both Mac and Win and write up what I find.

## 📼 Videos

<?# YouTube It13T8YBX8g /?>

<!-- <iframe width="560" height="315" src="https://www.youtube.com/embed/It13T8YBX8g" title="Build Light - Visual Studio Extension for Windows" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe> -->
