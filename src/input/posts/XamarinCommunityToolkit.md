---
title: Xamarin CommunityToolkit
tags:
    - programming
    - xamarin
author: AlexHedley
# description: 
published: 2020-07-10
---

The [Xamarin CommunityToolkit](https://github.com/xamarin/XamarinCommunityToolkit) is a reboot of an old set of helpful additions to Xamarin for example 

- Behaviors
- Controls
- Converters
- Effects
- Extensions

I'd raised an [Issue #121](https://github.com/xamarin/XamarinCommunityToolkit/issues/121) to suggest using [DocFX](/post/DocFX/) to build the docs within the repo and started on a [PR !135](https://github.com/xamarin/XamarinCommunityToolkit/pull/135/files) with some of the structure laid out.

A comment was made saying [MS Docs](https://docs.microsoft.com/xamarin/) would be making a repo and to hold off for a little bit.

Checking back a few weeks later I found the [Xamarin Community Toolkit Documentation](https://github.com/MicrosoftDocs/xamarin-communitytoolkit) repo had been made.

I made a start on porting over some of the work and opened [PR !4](https://github.com/MicrosoftDocs/xamarin-communitytoolkit/pull/4).

I received some really helpful comments from [David Britch](https://github.com/davidbritch), as I'd copied some of the base files from [Xamarin.Essentials](https://docs.microsoft.com/en-gb/xamarin/essentials/) and not checked they matched the [Contributing Guidelines](https://github.com/MicrosoftDocs/xamarin-communitytoolkit/blob/master/CONTRIBUTING.md)

It's just a start to get the shell of the structure there, to make it easier for others to get to the meat of the work but every little bit helps.

I'm hoping to start on the list above soon, the easier it is to get people started with the Toolkit, hopefully the more contributions will be made towards growing the functionality.

---

Original info about the Toolkit.

Profile:
- https://www.nuget.org/profiles/FormsCommunityToolkit

Packages:
- https://www.nuget.org/packages/FormsCommunityToolkit.Effects/1.0.0.110-beta
- https://www.nuget.org/packages/FormsCommunityToolkit.Converters/1.0.0.66-beta
- https://www.nuget.org/packages/FormsCommunityToolkit.Behaviors/1.0.0.66-beta
- https://www.nuget.org/packages/FormsCommunityToolkit.Controls/1.0.0.66-beta