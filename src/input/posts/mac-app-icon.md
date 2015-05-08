---
title: Mac App Icon
tags:
    - mac
    - icon
author: AlexHedley
# description: 
published: 2015-05-08
---

Add the value to a PList

- Create an icon .icns resource file
- Edit the Info.plist file and change the "CFBundleIconFile" value string to "icon"

I use [http://www.img2icnsapp.com/](http://www.img2icnsapp.com/) to make an .icns from an image

---

Checkout the following instructions ([link](http://developer.apple.com/library/mac/#documentation/GraphicsAnimation/Conceptual/HighResolutionOSX/Optimizing/Optimizing.html)):

**Use iconutil to Create an icns File Manually**

The `iconutil` command-line tool converts `iconset` folders to deployment-ready, high-resolution icns files. (You can find complete documentation for this tool by entering `man iconutil` in Terminal.) Using this tool also compresses the resulting `icns` file, so there is no need for you to perform additional compression.

**To convert a set of icons to an icns file**

Enter this command into the Terminal window:

`iconutil -c icns <iconset filename>`

where `<iconset filename>` is the path to the folder containing the set of icons you want to convert to `icns`. The output is written to the same location as the `iconset file`, unless you specify an output file as shown:

`iconutil -c icns -o <icon filename> <iconset filename>`

---

Add the .iconset folder with the following 10 items:

`icon_16x16.png icon_16x16@2x.png icon_32x32.png icon_32x32@2x.png icon_128x128.png icon_128x128@2x.png icon_256x256.png icon_256x256@2x.png icon_512x512.png icon_512x512@2x.png`

`I also use a great utility (`[http://makeappicon.com/](http://makeappicon.com/)) to create iOS icons with all the correct sizes.

They've added watch support so I've suggested Mac sizes too.

(It already has Android)

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/05/08/mac-app-icon/)
