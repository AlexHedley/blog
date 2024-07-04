---
title: Private NuGet Feed
# lead:
tags:
  - programming
  - nuget
  - ado
  - dotnet
author: AlexHedley
# description:
published: 2020-03-14
# image:
# imageattribution:
---

As a .NET developer you probably use [NuGet](https://www.nuget.org/) everyday, or something from it.

![NuGet](images/nuget-logo-footer-184x57.png)

> What is NuGet?
>
> NuGet is the package manager for .NET. The NuGet client tools provide the ability to produce and consume packages. The NuGet Gallery is the central package repository used by all package authors and consumers.

This is great for consuming other peoples libraries, even your own, if they can be public, but there are times you may wish to have a Private feed. Luckily there are options. One is hosting it yourself on your Azure Dev Ops (ADO) instance.

To do this create a new Project:

- [Create a project in Azure DevOps and TFS](https://docs.microsoft.com/en-us/azure/devops/organizations/projects/create-project?view=azure-devops&tabs=preview-page)

Then create a new Repo:

- [Create a new Git repo in your project](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-new-repo?view=azure-devops)

Click on the "Artifacts" tab

_old_ `https://[TENANT].visualstudio.com/[PROJECT]/_packaging?_a=feed&feed=[FEEDNAME]`
_new_ `https://[TENANT].azure.com/[PROJECT]/_packaging?_a=feed&feed=[FEEDNAME]`

Click "+ Create Feed".

Give it a "Name", set it's Visibility as you might only allow certain Users in the Org to see it, and decide if you want to include "Upstream sources".

Next we can create a Pipeline.

## PipeLines

- [Create your first pipeline](https://docs.microsoft.com/en-us/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=net%2Cyaml%2Cbrowser%2Ctfs-2018-2)

Create a new Pipeline:

```yml
trigger:
- master

pool:
  vmImage: '[CHOOSE]'

steps:
- script: echo Hello, world!
  displayName: 'Run a one-line script'

- task:
  [TODO]
```

You can decide which branches will trigger the pipeline to run.

You can pick an image to run your build on.

Next there is a publish step you can use, on the right hand side of the page there will either be a "Show assistant" button or a column of tasks.

Search for "NuGet"

Command: "push"

Path to NuGet package(s) to publish: "$(Build.ArtifactStagingDirectory)/**/*.nupkg;!$(Build.ArtifactStagingDirectory)/\*_/_.symbols.nupkg"

Target feed location: This organization/collection

Target feed: Choose from a picker.

```yml
- task: NuGetCommand@2
  inputs:
    command: "push"
    packagesToPush: "$(Build.ArtifactStagingDirectory)/**/*.nupkg;!$(Build.ArtifactStagingDirectory)/**/*.symbols.nupkg"
    nuGetFeedType: "internal"
    publishVstsFeed: "[GUID]"
```

The `publishVstsFeed` can either be a GUID or the name of the feed. When using the GUI it usually adds the underlying Guid.

I've skipped the other tasks needed, your code would need to be Built then packed etc.

---

## Links

- [Create a project in Azure DevOps and TFS](https://docs.microsoft.com/en-us/azure/devops/organizations/projects/create-project?view=azure-devops&tabs=preview-page)

- [Create a new Git repo in your project](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-new-repo?view=azure-devops)

- [What is Azure Artifacts?](https://docs.microsoft.com/en-gb/azure/devops/artifacts/overview?view=azure-devops)

- [Feeds](https://docs.microsoft.com/en-us/azure/devops/artifacts/concepts/feeds?view=azure-devops)

- [Publish and download artifacts](https://docs.microsoft.com/en-us/azure/devops/pipelines/artifacts/pipeline-artifacts?view=azure-devops&tabs=yaml)

- [Create your first pipeline](https://docs.microsoft.com/en-us/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=net%2Cyaml%2Cbrowser%2Ctfs-2018-2)
