---
title: Change Android SDK
# lead:
tags:
  - Android
author: AlexHedley
# description:
published: 2015-03-20
# image:
# imageattribution:
---

In Android Studio

Right click the App Folder

Open Module Settings (⌘↓)

Compile Sdk version (_x_)

Build Gradle

CompileSKDVersion

Doesn't change  other version.

Build errors for theme, was showing 21 since it was originally built with this.

Change the version here:

---

```java
dependencies {
  compile 'com.android.support:appcompat-v7:19.0.0'
}
```

---

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/03/20/change-android-sdk/)
