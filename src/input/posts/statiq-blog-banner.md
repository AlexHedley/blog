---
title: Statiq - Blog Banner
# lead:
description: Adding a custom banner image to the blog.
tags:
  - statiq
  - statiq.web
  - dotnet
author: alex-hedley
published: 2023-06-17
image: /posts/images/statiq-web.svg
imageattribution: https://www.statiq.dev/web
---

Create a new banner image.

Add a new property `"Image": "images/banner.png",` to the `appsettings.json`

<?# IncludeCode "./../../appsettings.json" /?>

The publish.

I took the banner from my website: [https://www.alexhedley.com/](https://www.alexhedley.com/), might need to create a new one to handle positioning of the text better, but it's not the default anymore.

Example:

![Original Blog Banner](images/blog_banner.png "Original Blog Banner")

![Updated Blog Banner](images/blog_banner_new.png "Updated Blog Banner")
