---
title: Archery Scores
# lead: 
tags:
  - archery
  - score keeper
  - app
author: alexhedley
description: Archery Score Keeper
published: 2024-10-29
# image: /posts/images/
# imageattribution:
---

<!-- # Archery Scores -->

Since [returning to archery](archery-return) I thought it might be a good idea to keep a track of my scores.

I'd already bought a book to write them in whilst at the venue but shouldn't there be a digital version as well?

I went about building one. I've kept it in legacy AngularJS just because it's so easy to work with and my other sites use that too.

- [Archery](https://alexhedley.com/archery/)

I've made initial tabs including _Summary_, _Scores_, a _Score Creator_, a _Target_, info about the _Club_ and my _Equipment_. I'll be looking to add _Graphs_ and some other stats once I've got more weeks added to the data set.

The Score Creator is much like the one from my [Bowling](https://alexhedley.com/bowling/) and it lets me quickly type in my scores and output a json object I can then add to the repo.

I found a useful [CodePen](https://codepen.io/GGalizzi/pen/PogggB) from [@GGalizzi](https://codepen.io/GGalizzi) which lets you select a point on the target and it will tell you your score. I'm still working on integrating that into the site.

---

My club uses [Golden Records Online](https://archery-records.net/) which I'm adding my scores as well. They have an API, so let's add another App to my [projects](https://alexhedley.com/projects/) graveyard.

## 🔗 Links

- https://alexhedley.com/archery/
  - https://github.com/AlexHedley/archery
