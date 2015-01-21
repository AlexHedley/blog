---
title: Android Woes
# tags:
#     - 
author: AlexHedley
# description: 
published: 2015-01-21
---

Needed to download Android Studio at work work and it didn't work.

> Android Studio was unable to find a valid JVM.

http://stackoverflow.com/questions/27369269/android-studio-was-unable-to-find-a-valid-jvm-related-to-mac-os/27370525#27370525

Open up Script Editor

```
do shell script "launchctl setenv STUDIO_JDK /Library/Java/JavaVirtualMachines/jdk1.8.0_25.jdk"
```

Save this as an Application.

Change the version to your version:

In the Terminal:

javac -version

[Original Link](https://alexhedley.wordpress.com/2015/01/21/android-woes/)
