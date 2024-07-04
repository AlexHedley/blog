---
title: Automator
# lead:
tags:
  - apple
  - automator
author: AlexHedley
# description:
published: 2014-04-20
# image:
# imageattribution:
---

I found a tweet about a Standford Mac Dev course.

https://twitter.com/indragie/statuses/457607755621097473

<blockquote class="twitter-tweet" lang="en"><p>TIL Stanford has a class on Cocoa Programming for OS X: <a href="http://t.co/TdFAUYifeX">http://t.co/TdFAUYifeX</a>. Impressive.</p>&mdash; Indragie Karunaratne (@indragie) <a href="https://twitter.com/indragie/statuses/457607755621097473">April 19, 2014</a></blockquote>
<script async src="//platform.twitter.com/widgets.js" charset="utf-8"></script>

http://www.stanford.edu/class/cs193e/

Didn't want to download all the files individually so why not use automator.

I'd played about with this kind of thing before:

http://www.therobbiedshow.com/web-dev-notes/2011/12/14/automator-workflow-to-download-specific-files-from-url.html

1. Open Automator.
2. Make a new workflow.
3. Add these actions, in this order:
   1. Get Specific URLs
   2. Get Link URLs from Webpages
   3. FIlter URLs
4. In the "Get Specific URLs" action, set your URL.
5. In the "FIlter URLs" action, add your filter(s). (e.g., Name contains .pdf)
6. Run, to test results.
7. Add the "Download URLs" action and choose a download folder
