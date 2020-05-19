---
title: DocFX
tags:
    - programming
    - github
author: AlexHedley
# description: 
published: 2020-05-19
---

There are a number of options to build static sites these days.

My current blog is built using [Jekyll Now](https://github.com/barryclark/jekyll-now) which is great static site which uses [Markdown](https://daringfireball.net/projects/markdown/syntax).

Another tool I've used is [MkDocs](https://www.mkdocs.org/), this has been helpful as it allowed me to quickly contribute to [MFractor](../MFractor-Documentation)

But with me working with .NET predominantly it makes sense to use the tooling MS use. This is [DocFX](https://dotnet.github.io/docfx/).

For a great customised version of this see [Prism Library Docs](https://prismlibrary.com/docs/).

One thing I love about the jekyll based sites is you can use them with GitHub Pages. Just push and it auto builds. 

For MkDocs this allows a command to push `mkdocs gh-deploy`.

I'd like the same for DocFX but this doesn't currently exist out of the box.

Time to use [GitHub Actions](https://github.com/features/actions)

Researching first to see if anyone had got it working yet I found:

- [3284](https://github.com/dotnet/docfx/issues/3284)
- [Community](https://github.community/t5/GitHub-Actions/Github-action-not-triggering-gh-pages-upon-push/td-p/26869/highlight/true/page/3)

From here I tried a few ideas:

Create a new file under the following folder:

`.github/workflows/`

- `main.yml`

Add the following:

Setup which branch will trigger the action to run:

```yml
on:
  push:
    branches:
      - master
```

Then we need to run a job on an OS:

```yml
jobs:
  deploy:
    runs-on: ubuntu-latest 
```

Next we need to build the DocFX site, this is done locally running the following command:

`docfx docfx.json`

This will build the site the chosen path from the above `.json` file.

```json
"dest": "_site",
```

Luckily this GitHub Action has already been built:

**[docfx-action](https://github.com/marketplace/actions/docfx-action)** from [nikeee](https://github.com/nikeee) Niklas Mollenhauer

Just add the following **step**:

```yml
      - name: docfx-action
        uses: nikeee/docfx-action@v0.1.0
        with:
          args: docfx.json
```

If your `docfx.json` is in another location update the `args` input accordingly.

One thing to note is we can't use `windows-latest` as we get an error with the "docfx-action".

`##[error]Container action is only supported on Linux`

Now that the site is built we want to publish it to GitHub Pages:

Again there's an Action already built for this:

**[GitHub Actions for GitHub Pages](https://github.com/peaceiris/actions-gh-pages)** from [peaceiris](https://github.com/peaceiris) Shohei Ueda

```yml
      - name: Deploy
        uses: peaceiris/actions-gh-pages@v3.6.1
        with:
          github_token: ${ secrets.GITHUB_TOKEN }
          publish_dir: ./_site
```

Note: use double "{" and "}" around the `github_token`.

If you have changed your `dest` to another folder name update the `publish_dir`.

All GHA have a `GITHUB_TOKEN` automatically generated when they run so you can use this in your action.

See [github_token](https://github.com/peaceiris/actions-gh-pages#%EF%B8%8F-github_token) for more info.

Push this `yml` file to your repo and push to your trigger branch, then click on the "Actions" tab and see it run.

This now means you don't have to build it locally, then push to the `gh-pages` branch manually to deploy it online.

---

## Code

```yml
name: github pages

on:
  push:
    branches:
      - master

jobs:
  deploy:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout
        uses: actions/checkout@v2

      - name: docfx-action
        uses: nikeee/docfx-action@v0.1.0
        with:
          args: docfx.json
      
      - name: Deploy
        uses: peaceiris/actions-gh-pages@v3.6.1
        with:
          github_token: ${ secrets.GITHUB_TOKEN }
          publish_dir: ./_site
```

Note: use double "{" and "}" around the `github_token`.
