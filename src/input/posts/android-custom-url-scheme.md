---
title: Android - Custom URL Scheme
# lead:
tags:
  - android
  - java
author: AlexHedley
# description:
published: 2015-01-30
# image:
# imageattribution:
---

So I've implemented a Custom URL Scheme in iOS and want to do the same in Android.

Make sure the android:scheme="" is lowercase.

[gist 7fb8cbea4a69743cb7e2/]

<?# Gist 7fb8cbea4a69743cb7e2 /?>

`Activity.java`

```java
//XXX://settings/?d=hello
Intent intent = getIntent();
if (Intent.ACTION_VIEW.equals(intent.getAction())) {
    Uri data = intent.getData();
    Log.d(TAG, "URI Data: " + data.toString());
    String d = data.getQueryParameter("d");
    Log.d(TAG, "d:" + d);
}
```

`Manifest.xml`

```xml
<intent-filter>
 <action android:name="android.intent.action.VIEW" />
 <category android:name="android.intent.category.DEFAULT" />
 <category android:name="android.intent.category.BROWSABLE" />
 <data android:scheme="XXX" />
</intent-filter>
```

http://developer.android.com/training/basics/intents/filters.html

http://stackoverflow.com/questions/2448213/how-to-implement-my-very-own-uri-scheme-on-android

http://stackoverflow.com/questions/17063696/android-app-how-to-read-get-parameters-from-a-custom-url-scheme

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/01/30/android-custom-url-scheme/)
