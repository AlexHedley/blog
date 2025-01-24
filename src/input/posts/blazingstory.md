---
title: Blazing Story
# lead: Blazing Story
description: The clone of "Storybook" for Blazor, a frontend workshop for building UI components and pages in isolation.
tags:
  - programming
  - dotnet
  - blazor
  - csharp
author: alexhedley
published: 2025-01-24
image: /posts/images/blazor/blazing-story/blazing-story.png
imageattribution: https://jsakamoto.github.io/BlazingStory/
---

<!-- # Blazing Story -->

Over the past couple of years I've been working with React and on occasion there have been a [Storybook](https://storybook.js.org/) of components for the UI libraries I've been working with. This is an excellent way to have examples of the control(s) you may need to implement in your site. It gives you options to try different parameter combinations, see it in action and even grab a copy of the code needed to add it to your page(s).

In my pursuit to have all these great options but in .NET I was lucky enough to come across [Blazing Story](https://jsakamoto.github.io/BlazingStory/):

> The clone of "[Storybook](https://storybook.js.org/)" for Blazor, a frontend workshop for building UI components and pages in isolation.

![Blazing Story](images/blazor/blazing-story/blazing-story.png "Blazing Story")

> The "Blazing Story" is built on almost 100% Blazor native (except only a few JavaScript helper codes), so you don't have to care about npm, package.json, webpack, and any JavaScript/TypeScript code. You can create a UI catalog application on the Blazor way!

See it in action: https://jsakamoto.github.io/BlazingStory/

It's very simple to setup.

`dotnet new install BlazingStory.ProjectTemplates`

Add a new Project to your Solution. Add your components Project to this new _Stories_ Project. Add a new `[COMPONENT].stories.razor` Razor file and setup the properties.

If you choose the WASM version you can then deploy it via [GitHub Pages](https://pages.github.com/) too!

There's a discussion showing how: [#33](https://github.com/jsakamoto/BlazingStory/discussions/33)

- https://github.com/jsakamoto/PublishSPAforGitHubPages.Build

```xml
  <ItemGroup>
    <PackageReference Include="PublishSPAforGitHubPages.Build" Version="3.0.0" />
  </ItemGroup>
```

I usually just use `sed` in the GHA.

I quickly built an example and had it published in about 5 mins:

- https://github.com/AlexHedley/BlazingStoryExample
- https://alexhedley.github.io/BlazingStoryExample/

Looking forward to adding more of the features and working with some components I've built.

## 🔗 Links

- [Code](https://github.com/jsakamoto/BlazingStory)
- [Website](https://jsakamoto.github.io/BlazingStory/)
