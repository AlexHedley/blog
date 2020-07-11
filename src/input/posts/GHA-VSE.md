---
title: Publish a Visual Studio Extension from GitHub Actions
tags:
    - programming
    - vs
author: AlexHedley
# description: 
published: 2020-07-11
---

In a previous [post](/post/VisualStudioExtension/) I discussed starting to create a Visual Studio Extension for [BuildLight](/post/BuildLight/).

It would be nice to automate new versions to the marketplace.

There are a number or articles on-line showing how to do this with [ADO](https://azure.microsoft.com/en-gb/services/devops/) but I wanted to keep all the code and CI/CD in the same GitHub Repo of [BuildLight](https://github.com/praeclarum/BuildLight).

I started looking into how to deploy a VSIX to the [Marketplace](https://marketplace.visualstudio.com/) and came across a very recent blog post [CI/CD for Visual Studio extensions with GitHub Actions](https://david.gardiner.net.au/2020/07/vs-extension-cicd-with-github-actions.html) from [David Gardiner](https://twitter.com/DavidRGardiner) which I'm looking forward to reading when more are released but kindly the [GH Action](https://github.com/flcdrg/VsShowMissing/blob/master/.github/workflows/publish.yml) is already available in a repo [VsShowMissing](https://github.com/flcdrg/VsShowMissing).

So my journey began.

I created an account on the marketplace and added the necessary details:

- [AlexHedley](https://marketplace.visualstudio.com/publishers/alexhedley)

Then I created a simple VSIX and uploaded it to my own repo and added David's `publish.yml`. There's a GHA `main.yml` in `.github\workflows` for pushing a new build to GH Releases but I'll look at that later. For now I'm happy to just manually building the vsix locally and when I upload to GH Releases the GHA can trigger and publish on the marketplace.

Looking through the `publish.yml` a few places would need to be updated for filenames and paths. I added an `Overview.md` and the `build\extension-manifest.json` file, with updates.

During my testing it doesn't seem like any updates to the `Overview.md` are being reflected on the marketplace listing. The image didn't upload either. But new versions of the vsix did get uploaded.

One thing you need to create is a PAT or Personal Access Token. But where do you create this?

I couldn't find anything specific to a Visual Studio Marketplace extension but there are other articles for [VSCode](https://code.visualstudio.com/api/working-with-extensions/publishing-extension)

Make sure when you create one:

> make it accessible to every organization

Click on "Show all scopes" and scroll down to the **Marketplace** section and tick all:

[✔] Read [✔] Acquire [✔] Publish [✔] Manage

Save this token.

In the Repo create a new [Secret](https://docs.github.com/en/actions/configuring-and-managing-workflows/creating-and-storing-encrypted-secrets) on the Settings tab, Secrets section, click "New secret" and call it `PERSONAL_ACCESS_TOKEN `.

This matches the example from the [Download Assets](https://github.com/marketplace/actions/download-assets) ([Code](https://github.com/i3h/download-release-asset)) Action.

Make sure this is the same name in your `publish.yml`: `${ secrets.PersonalAccessToken }` (This will be double `{` and `}`).

Now just create a new release and watch the GHA run and upload your extension to the marketplace.
