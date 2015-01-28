---
title: Android - Dismiss Keyboard
tags:
    - android
author: AlexHedley
# description: 
published: 2015-01-28
---

How to dismiss a keyboard on a button click

\[gist cd4c31f6557504060ca0/\]

`Activity.java`

```java
InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
imm.hideSoftInputFromWindow(EDITTEXT.getWindowToken(), 0);

//http://stackoverflow.com/questions/3553779/android-dismiss-keyboard
```

http://stackoverflow.com/questions/3553779/android-dismiss-keyboard

[Original Link](https://alexhedley.wordpress.com/2015/01/28/android-dismiss-keyboard/)
