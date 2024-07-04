---
title: Android - Rename a Project
# lead:
tags:
  - android
author: AlexHedley
# description:
published: 2015-02-06
# image:
# imageattribution:
---

Refactor didn't change it everywhere.

build.gradle : applicationId

`AndroidManifest.xml`

```xml
<manifest package="com._company_._appname_" >
    <application android:label="@string/app_name" ...>
    </application>
</manifest>
```

Choose the "Project" view

Open ".idea" folder

Open ".name" and change here.

Run a Sync Gradle

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/02/06/android-rename-a-project/)
