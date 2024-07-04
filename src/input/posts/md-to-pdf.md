---
title: Markdown to PDF via GitHub Actions and Pandoc
# lead:
tags:
  - programming
  - markdown
  - github
  - github actions
  - pandoc
author: AlexHedley
# description:
published: 2021-02-20
# image:
# imageattribution:
---

In this post I'll run through converting a `md` file to a PDF using [Pandoc](https://pandoc.org) and [GitHub Actions](https://github.com/actions/).

> If you need to convert files from one markup format into another, pandoc is your swiss-army knife. Pandoc can convert between the following formats:

This is useful if you're writing up documentation and want to output to different file formats.

I found a useful [example](https://github.com/pandoc/pandoc-action-example) on a GitHub [profile](https://github.com/pandoc).

Create a new file called `book.md` and a folder called `images`.

Add you content.

Create a GitHub workflow:

```yml
name: Create PDF

on: push

jobs:
  convert_via_pandoc:
    runs-on: ubuntu-18.04
    steps:
      - uses: actions/checkout@v2
      - run: |
          mkdir output  # create output dir
          # this will also include README.md
          echo "FILELIST=$(printf '"%s" ' *.md)" >> $GITHUB_ENV
      - uses: docker://pandoc/latex:2.9
        with:
          args: --output=output/result.pdf ${ env.FILELIST }
      - uses: actions/upload-artifact@v2
        with:
          name: output
          path: output
```

Note: `${ var }` needs double `{` `}`

As well as creating an [artifact](https://github.com/actions/upload-artifact) you could also [create](https://github.com/actions/create-release) a release and [upload](https://github.com/actions/upload-release-asset) that.

```yml
name: Create PDF

on: push

jobs:
  convert_via_pandoc:
    runs-on: ubuntu-18.04
    steps:
      - uses: actions/checkout@v2
      - run: |
          mkdir output # create output dir
          # this will also include README.md
          echo "FILELIST=$(printf '"%s" ' *.md)" >> $GITHUB_ENV
      - uses: docker://pandoc/latex:2.9
        with:
          args: --output=output/result.pdf ${ env.FILELIST }
      - uses: actions/upload-artifact@v2
        with:
          name: output
          path: output

      - name: Create Release
        id: create_release
        uses: actions/create-release@v1
        env:
          GITHUB_TOKEN: ${ secrets.GITHUB_TOKEN }
        with:
          tag_name: v0.1 #${ github.ref }
          release_name: Release v0.1 #${ github.ref }
          draft: true
          prerelease: false

      - name: Upload Release Asset
        id: upload-release-asset
        uses: actions/upload-release-asset@v1
        env:
          GITHUB_TOKEN: ${ secrets.GITHUB_TOKEN }
        with:
          upload_url: ${ steps.create_release.outputs.upload_url }
          asset_path: output/result.pdf
          asset_name: Handbook.pdf
          asset_content_type: application/pdf
```

Note: `${ var }` needs double `{` `}`

Note: There is a problem with the `set-env` [Issue](https://github.com/pandoc/pandoc-action-example/issues/12) and [PR](https://github.com/pandoc/pandoc-action-example/pull/14).

One workaround is:

```yml
- run: |
    echo "::set-env name=FILELIST::$(printf '"%s" ' *.md)"
  env:
    ACTIONS_ALLOW_UNSECURE_COMMANDS: "true"
```

## HTML

You might also want to create it as HTML:

Sample:

```yml
name: Create HTML

on: push

jobs:
  convert_via_pandoc:
    runs-on: ubuntu-18.04
    steps:
      - name: Checkout
        uses: actions/checkout@v2

      - name: Create output directory
        run: |
          mkdir output  # create output dir
          echo "FILELIST=book.md" >> $GITHUB_ENV

      - name: Pandoc
        uses: docker://pandoc/latex:2.9
        with:
          args: --output=output/index.html ${{ env.FILELIST }} -s

      # copy the images from the repo to the output folder for inclusion in the artifact
      - name: Copy images dir to output dir
        run: cp -r images/ output/

      - name: Upload Artifact
        uses: actions/upload-artifact@v2
        with:
          name: Handbook
          path: output
```

Another option would be to add an extra arg ([`--extract-media`](https://pandoc.org/MANUAL.html#option--extract-media)) which takes a DIRECTORY: `--extract-media=DIR`, just set the folder to **images**: `--extract-media=images` and you will get the necessary files.

The file names do become random strings.

But then the path doesn't work with the HTML.
