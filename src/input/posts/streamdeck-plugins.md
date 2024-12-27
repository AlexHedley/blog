---
title: StreamDeck Plugins
# lead:
description: Calling PowerShell cmdlets 
tags:
  - programming
  - streamdeck
  - powershell
  - recording
author: AlexHedley
published: 2024-12-27
# image:
# imageattribution:
---

<!-- StreamDeck Plugins -->

Whilst recording my tutorials I've needed to change the screen resolution for better uploading to YouTube. I was recording at 1080 but needed it at 720.

I went looking for a way to change this but it was a little convoluted. I stubbled across a PowerShell module called `DisplaySettings`.

- https://www.powershellgallery.com/packages/DisplaySettings/0.0.2
- https://github.com/lust4life/display-resolution

It had a simple `cmdlet`:

```powershell
Set-DisplayResolution -Width 1920 -Height 1080
```

```powershell
Set-DisplayResolution -Width 1280 -Height 720
```

Next was how do I call this from my Stream Deck? I could use the [StreamDeck Toolkit](streamdecktoolkit) but it's likely someone already has a solution.

I found a plugin from @StartAutomating but it was using PS v5. I raised an Issue [#120](https://github.com/StartAutomating/ScriptDeck/issues/120#issuecomment-2563555784) asking if it were possible to swap to v7. I hadn't seen there were two versions of the plugin.

- Website: https://scriptdeck.start-automating.com/
- Code: https://github.com/StartAutomating/

## Plugins

**Windows ScriptDeck**

- https://marketplace.elgato.com/product/windows-scriptdeck-857f01dd-8fd4-44d5-8ec7-67ac850b21d3

**ScriptDeck**

- https://marketplace.elgato.com/product/scriptdeck-927e59aa-b42d-4da7-84cc-8c78f4dd7e18
