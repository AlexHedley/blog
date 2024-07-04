---
title: Private NuGet Library
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

In a previous post I explained how to create a [Private NuGet Feed](/post/Private-NuGet-Feed/).

In this post I want to explain how to create a Private NuGet Library which we can publish to a feed.

Firstly we need something to publish so we can create a .NET Class Library project and add some code. There are many tutorials online for this so I'll let you find this yourself.

Push it to a Repo in your Project.

Now that it's in a Repo we will want to create a Pipeline to manage the lib.

- [Create your first pipeline](https://docs.microsoft.com/en-us/azure/devops/pipelines/create-first-pipeline?view=azure-devops&tabs=net%2Cyaml%2Cbrowser%2Ctfs-2018-2)

Then you need to add some necessary settings.

One big question is how to version your Library. Do you handle it yourself, or do you let the build tool handle it?

- [Semantic Versioning 2.0.0](https://semver.org/)
- [Assembly versioning](https://docs.microsoft.com/en-us/dotnet/standard/assembly/versioning)
- [SemanticVersion.NET](https://github.com/Ruhrpottpatriot/SemanticVersion)

This is in the format:

`<major version>.<minor version>.<build number>.<revision>`

> For example, version **1.5.1254.0** indicates **1** as the major version, **5** as the minor version, **1254** as the build number, and **0** as the revision number.

When using this I like to define a few variables, in the pipeline, I can control.

- [Define variables](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/variables?view=azure-devops&tabs=yaml%2Cbatch)

- `version.major` : 1
- `version.minor` : 0
- `version.patch` : 0

Then I let the pipeline increment a value each time I push and it builds, using `$(Rev:.r)`.

Example: `.1`.

This will prefix with a ".". Don't add your own or you will get ".." in your library.

If you change a variable, i.e. update the Major version to "2" this will reset. See below for more detail.

| Token      | Example replacement value                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| ---------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `$(Rev:r)` | 2 (The third run on this day will be 3, and so on.)<br /><br /> Use **\(Rev:r)** to ensure that every completed build has a unique name. When a build is completed, if nothing else in the build number has changed, the Rev integer value is incremented by one.<br /><br />If you want to show prefix zeros in the number, you can add additional **'r'** characters. For example, specify **\$(Rev:rr)** if you want the Rev number to begin with 01, 02, and so on. |

As we now have a plan we need a way to implement this, so you're thinking, how do I update the `AssemblyInfo` during the build pipeline? Well luckily Bleddyn has you covered, use their plugin to update the Assembly Info:

Visual Studio marketplace:

- [Assembly Info](https://marketplace.visualstudio.com/items?itemName=bleddynrichards.Assembly-Info-Task) from [Bleddyn Richards](https://marketplace.visualstudio.com/publishers/bleddynrichards).

Example Name:

```yml
name: $(version.major).$(version.minor).$(version.patch)$(rev:.r)
```

Some people like to add the date:

```yml
name: $(Build.DefinitionName)_$(Date:yyyyMMdd))
```

## Links

- [Assembly versioning](https://docs.microsoft.com/en-us/dotnet/standard/assembly/versioning)

- [Define variables](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/variables?view=azure-devops&tabs=classic%2Cbatch)

- [Use predefined variables](https://docs.microsoft.com/en-us/azure/devops/pipelines/build/variables?view=azure-devops&tabs=yaml)

- [Configure run or build numbers](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/run-number?view=azure-devops&tabs=yaml)

## Sample Code

```yml
name: $(version.major).$(version.minor).$(version.patch)$(rev:.r)

# the build will trigger on any changes to the master branch
trigger:
  - master

# the build will run on a Microsoft hosted agent, using the lastest Windows VM Image
pool:
  vmImage: "windows-latest"

# these variables are available throughout the build file
# just the build configuration is defined, in this case we are building Release packages
variables:
  buildConfiguration: "Release"

#The build has # seperate tasks run under 1 step
steps:
  - task: NuGetCommand@2
    inputs:
      command: "restore"
      restoreSolution: "**/*.sln"
      feedsToUse: "config"

  - task: Assembly-Info-NetFramework@2
    inputs:
      Path: "$(Build.SourcesDirectory)"
      FileNames: '**\AssemblyInfo.cs'
      InsertAttributes: false
      FileEncoding: "auto"
      WriteBOM: false
      Product: "NuGet2"
      Company: "[CompanyName]"
      Copyright: "Copyright &copy; yyyy [CompanyName]"
      VersionNumber: "$(Build.BuildNumber)"
      FileVersionNumber: "$(Build.BuildNumber)"
      InformationalVersion: "$(Build.BuildNumber)"

  - task: VSBuild@1
    displayName: 'Build solution **\*.sln'
    inputs:
      solution: '**\*.sln'
      configuration: "$(buildConfiguration)"

  - task: NuGetCommand@2
    displayName: "NuGet pack"
    inputs:
      command: pack
      packagesToPack: '**\*.csproj;!**\*.Tests.csproj'
      versioningScheme: byBuildNumber

  # The last task is a nuget command, nuget push
  # This will push any .nupkg files to the '[FEEDNAME]' artifact feed
  # allowPackageConflicts allows us to build the same version and not throw an error when trying to push
  # instead it just ingores the latest package unless the version changes
  - task: NuGetCommand@2
    displayName: "nuget push"
    inputs:
      command: "push"
      feedsToUse: "select"
      packagesToPush: "$(Build.ArtifactStagingDirectory)/**/*.nupkg;!$(Build.ArtifactStagingDirectory)/**/*.symbols.nupkg"
      nuGetFeedType: "internal"
      publishVstsFeed: "[FEEDNAME]"
      versioningScheme: "off"
      allowPackageConflicts: true
```
