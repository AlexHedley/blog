---
title: Statiq.Web - Shortcodes - Include
tags:
  - statiq.web
  - shortcodes
  - include
  - markdown
author: alexhedley
description: How to reuse content.
published: 2023-07-02
image: /posts/images/statiq-web.svg
imageattribution: https://www.statiq.dev/assets/statiq-web.svg
---

<?! Raw ?><?# Raw ?>

In another project ([Symantec Connect Articles](https://alexhedley.com/symantec-connect-articles/)) I've got a Table of Contents (toc) for many sets of Articles. This can sometimes be a lot of information and is duplicated in each article, at the top and bottom. This isn't ideal if I need to update anything.

Seeing an `Include` option in [Devlead.Statiq - Part 1 - Tabs](https://www.devlead.se/posts/2021/2021-04-09-devlead-statiq-part1-tabs) I wondered if there was similar functionality already built in.

When I originally tried it, looking at other `Shortcodes`, it didn't work. It was showing it as plain text and not converting to markdown.

```html
<?# Include "./../includes/posts/toc.md" /?>
```

This can't be the only option? To the docs. [Processing Phases](https://www.statiq.dev/guide/content-and-data/shortcodes#processing-phases) explained what was going on.

- Pre-rendering: `<?! ShortcodeName /?>`
- Intermediate: `<?^ ShortcodeName /?>`
- Post-rendering: `<?# ShortcodeName /?>`

I'd been using Post-rendering `<?#` since this is what was used on a code example. Swapping it to *Intermediate* worked a treat.

Looking for other examples I also found the **Markdown** `Shortcode`.

```html
<?# Markdown ?>
<?!^ "./../includes/posts/toc.md" /?>
<?#/ Markdown ?>
```

I prefer this as the intention is very clear.

Now all I need to do is update all my articles to use this...

## Links

- https://www.statiq.dev/api/statiq.web.shortcodes/
  - https://www.statiq.dev/api/statiq.web.shortcodes/youtubeshortcode/
- [Shortcodes](https://www.statiq.dev/guide/content-and-data/shortcodes)
  - [Processing Phases](https://www.statiq.dev/guide/content-and-data/shortcodes#processing-phases)
  - [wyam](https://wyam.io/docs/concepts/shortcodes)

---

## Options

- [x] Include
- [x] Markdown
- [ ] Raw
- [ ] Embed
- [ ] Giphy
- [ ] Gist
- [ ] Twitter
- [ ] YouTube
- [ ] Link
- [ ] Figure
- [ ] Table

<?#/ Raw ?><?!/ Raw ?>
