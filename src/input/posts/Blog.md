---
title: Blog
# lead:
tags:
  - programming
  - jekyll
author: AlexHedley
# description:
published: 2020-03-02
# image:
# imageattribution:
---

When I knew I wanted to blog again I had to decide where, and how, I've rolled my own, I've used Wordpress but now as I love using markdown, and GitHub has the ability to host webpages it made sense to use those.

There are a number of options:

- [Hugo](https://gohugo.io)
- [Gatsby](https://www.gatsbyjs.org/)
- [Jekyll](https://jekyllrb.com/)
- [MkDocs](http://www.mkdocs.org/)
- [docfx](https://dotnet.github.io/docfx/)

I've used _mkdocs_ for application documentation and I'm in the process of migrating it to _docfx_ but for this I wanted to try something new.

I found [jekyll-now](https://www.jekyllnow.com)([GitHub](https://github.com/barryclark/jekyll-now)) and it's a quick setup but I wanted a few extra features.

In this post I'll run through the changes I've made.

The [README.md](https://github.com/barryclark/jekyll-now/blob/master/README.md) is thorough but I'll run through it anyway.

Firstly fork the repo, rename it to your username i.e. `alexhedley.github.io`.

## Config

Next is the configuring i.e. `_config.yml`

Update `name`, `description` and then find an image you wish to use, add it to the `images` folder and update the `avatar`.

`avatar: https://raw.githubusercontent.com/AlexHedley/alexhedley.github.io/master/images/alexhedley.png`

## Footer Links

Next is the `footer-links`. Add any social media accounts you wish to show in the footer.

Next is the `url`, this should be amended to your github url and if it isn't the default repo update `baseurl` to whatever the repo is called i.e. `\blog`.

## Favicon

To add your own favicon you can add it to the repo then update your html in [default.html](../_layouts/default.html):

```html
<link rel="shortcut icon" href="/favicon.ico" />
```

## Author

Most individual blogs probably wouldn't need an Author, unless you wanted guest posts but if you wish to add them it doesn't take much.
I found a [blog](https://blog.sorryapp.com/blogging-with-jekyll/2014/02/06/adding-authors-to-your-jekyll-site.html) explaining how.

Create a new file `_data/authors.yml` and update `first_last` to your name i.e. `alex_hedley`.

```yml
# Author details.
first_last:
  name: Alex Hedley
  email: alex@alexhedley.com
  web: http://twitter.com/alexhedley
```

In your post md file you can add it to the config at the top:

```yml
# Author.
author: first_last
```

## Tags and Categories

Tags and Categories are a similar process, I found a couple of ways from a useful [blog](http://www.minddust.com/).

- http://www.minddust.com/post/alternative-tags-and-categories-on-github-pages/
- http://www.minddust.com/post/tags-and-categories-on-github-pages/

## Supplementary Pages

If you wish to add extra, one off, pages this is easy to do. Just create a `.md` file.

In the config at the top of the page add a route:

```md
---
layout: page
title: Apps
permalink: /apps/
---
```

Then add it to the main nav, in [default.html](../_layouts/default.html).

```html
<nav>
  <a href="{{ site.baseurl }}/">Blog</a>
  <a href="{{ site.baseurl }}/about">About</a>
  <a href="{{ site.baseurl }}/apps">Apps</a>
</nav>
```

TODO

- icons
- paging
