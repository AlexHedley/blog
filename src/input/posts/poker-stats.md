---
title: Poker - Stats
# lead:
tags:
  - poker
  - api
  - dotnet
  - csharp
author: alexhedley
description: Displaying stats for the given game.
published: 2023-09-18
# image: /posts/images/###.png
# imageattribution:
---

<!-- # Poker - Stats -->

<?# Markdown ?>
<?!^ "./../includes/posts/poker.md" /?>
<?#/ Markdown ?>

Whilst working on the tracking of the cards I thought it might be also useful to see certain stats, luckily I don't have to do the calculations myself and have found 2 projects written in C# I can repurpose. The first is **PokerOddsPro** from _@dyh1213_ and the other is **Poker-Hand-Evaluator** from _@danielpaz6_.

<?# YouTube YEwy2yhG9P4 /?>

![Evaluator Demo](https://raw.githubusercontent.com/AlexHedley/Poker-Hand-Evaluator/master/images/webdemo.png "Evaluator Demo")

I'm forked them to keep a copy and am moving them into the [Poker](https://github.com/AlexHedley/poker-recording/tree/app/src/Poker) source for the main repo.

There is still some work to combine the stats together and I'm looking to deploy them as a Blazor WASM app so you can try them out yourself. I also need to add in the capability to burn cards.

You can try out _@dyh1213_'s here: [https://dyh1213.github.io/PokerOddsPro.io/](https://dyh1213.github.io/PokerOddsPro.io/)

## Links

- https://github.com/dyh1213/PokerOddsPro
  - Fork - https://github.com/AlexHedley/PokerOddsPro/tree/dev
- https://github.com/dyh1213/PokerOddsPro.io
  - https://dyh1213.github.io/PokerOddsPro.io/
- 📼 https://www.youtube.com/watch?v=YEwy2yhG9P4

- https://github.com/danielpaz6/Poker-Hand-Evaluator Thanks Daniel Paz (danielpaz6)
  - Site ❌ https://jspoker.net/ (https://danielpaz.me/)
  - Fork https://github.com/AlexHedley/Poker-Hand-Evaluator
