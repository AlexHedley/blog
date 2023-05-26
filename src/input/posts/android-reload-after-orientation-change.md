---
title: Android - Stop reload after orientation change
tags:
    - android
author: AlexHedley
# description: 
published: 2015-01-28
---

I have added Barcode scanning into my app but after I have scanned it returns to my Activity and reloads the page.

I don't want this to happen

\[gist a128ce976d9d2f0dee92 /\]

`manifest.xml`

```xml
<activity
    android:name=".YourActivityName"
    android:configChanges="orientation|screenSize" >
</activity>

//http://stackoverflow.com/questions/5913130/dont-reload-application-when-orientation-changes
```

`manifest2.xml`

```xml
<activity
    android:screenOrientation="portrait" >
</activity>
```

http://stackoverflow.com/questions/5913130/dont-reload-application-when-orientation-changes

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/01/28/android-reload-after-orientation-change/)
