---
title: fTerminal
# lead:
tags:
  - mac
  - automator
author: AlexHedley
# description:
published: 2012-04-06
# image:
# imageattribution:
---

Just been surfing the net and came across this handy little tool, **fTerminal**, for opening the finder window in the terminal

[http://www.hiddenelephant.com/blog/2009/05/11/quick-jump-from-finder-to-terminal/](http://www.hiddenelephant.com/blog/2009/05/11/quick-jump-from-finder-to-terminal/)

One problem, I downloaded, unzipped and had the

![Error](images/screen-shot-2012-04-06-at-19-19-18.png "Error")

and when I tried to run it

"_You can't open the application fTerminal - PowerPC because PowerPC applications are no longer supported._"

So let's create a new Automator Application.

![Automator](images/screen-shot-2012-04-06-at-19-20-55.png "Automator")

Search for **Automator** and choose **Run AppleScript**

[![](http://alexhedley.files.wordpress.com/2012/04/screen-shot-2012-04-06-at-19-21-27.png?w=300 "Run AppleScript")](http://alexhedley.files.wordpress.com/2012/04/screen-shot-2012-04-06-at-19-21-27.png)

Now add your code `on run {input, parameters} (* Your script goes here *) return input end run`

Maybe you want to add an Icon to the Application: [http://apple.stackexchange.com/questions/369/can-i-change-the-application-icon-of-an-automator-script](http://apple.stackexchange.com/questions/369/can-i-change-the-application-icon-of-an-automator-script)

After the script has been created do the following :

1. Find the icon you want
2. *Get Info* of the icon file (cmd\-i)
3. Click on the icon inside the info window
4. Copy it (cmd\-c)
5. *Get Info* of the application (cmd\-i)
6. Click on the icon inside the info window
7. Paste the icon in the clipboard (cmd\-v)

This method works for every files in Mac OS X.

---

Can be done with a service:

**System Preferences** \> **Keyboard** \> **Keyboard Shortcuts** \> **Services**

Enable     **New Terminal at Folder**     **New Terminal Tab at Folder**

![Keyboard Shortcuts - Services](images/screen-shot-2012-04-06-at-19-42-19.png?w=300 "Keyboard Shortcuts - Services")

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2012/04/06/fterminal/)
