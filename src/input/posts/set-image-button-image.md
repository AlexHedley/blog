---
title: Android - Set Image Button Image
# lead:
tags:
  - android
  - java
author: AlexHedley
# description:
published: 2015-01-28
# image:
# imageattribution:
---

Add the Image to src/res/drawable

Add the various sizes (-hdpi) etc

[gist 18cd7f5557d5804c02ac/]

<?# Gist 18cd7f5557d5804c02ac /?>

`activity.java`

```java
ImageButton button = (ImageButton) this.findViewById(R.id.BUTTONID);
button.setColorFilter(Color.argb(255, 255, 255, 255)); // White Tint
```

`Activity_Main.xml`

```xml
<ImageButton
  ...
  android:src="@drawable/NAME"
  android:background="@null"
  android:tint="@android:color/white"
  />

  //Transparent Background add "@null"
```

http://www.tutorialspoint.com/android/android\_imagebutton\_control.htm

Change it's colour:

http://stackoverflow.com/questions/3024983/how-do-i-change-the-tint-of-an-imagebutton-on-focus-press

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/01/28/set-image-button-image/)
