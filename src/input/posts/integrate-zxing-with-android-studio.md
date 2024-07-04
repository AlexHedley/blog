---
title: Integrate Zxing with Android Studio
# lead:
tags:
  - android
  - android-studio
  - zxing
  - java
author: AlexHedley
# description:
published: 2015-01-28
# image:
# imageattribution:
---

Spent some time trying to integrate [Zxing](https://github.com/zxing/zxing/) into my app and couldn't get the Activity to work.

Lots of posts saying add this activity but the name was linked to their project so didn't work.

Do i add it in via the Project Structure, do I compile the jar using maven.

Nothing seemed to work.

I asked on the TeamTreehouse Forum and got a reply,

https://teamtreehouse.com/forum/adding-an-external-library-to-an-android-studio-project

http://stackoverflow.com/questions/18543668/integrate-zxing-in-android-studio

I think I'd come across that SO answer but as I'd been going back and forth trying everything had overlooked it.

https://github.com/journeyapps/zxing-android-embedded

Tried again and got it working.

[gist e7374ab15ebd3722e904 /]

<?# Gist e7374ab15ebd3722e904 /?>

`build.grade`

```kotlin
repositories {
    mavenCentral()

    maven {
        url "https://raw.github.com/embarkmobile/zxing-android-minimal/mvn-repo/maven-repository/"
    }
}

dependencies {
    compile 'com.google.zxing:core:2.2'
    compile 'com.embarkmobile:zxing-android-minimal:1.2.1@aar'
}
```

`MainActivity.java`

```java
// import the various classes

// Add the controls to your View
Button button;
TextView tvScanResults;

@Override
protected void onCreate(Bundle savedInstanceState) {
  super.onCreate(savedInstanceState);
  setContentView(R.layout.activity_barcode);

  button = (Button) findViewById(R.id.button);
  tvScanResults = (TextView) findViewById(R.id.textView);
  button.setOnClickListener(this);
}

@Override
public void onClick(View v) {
  IntentIntegrator.initiateScan(this);
}

// Add the following
public void onActivityResult(int requestCode, int resultCode, Intent intent) {
  IntentResult scanResult = IntentIntegrator.parseActivityResult(requestCode, resultCode, intent);
  if (scanResult != null) {
    // handle scan result
    tvScanResults.setText(scanResult.getContents());
  } else {
    // else continue with any other code you need in the method
    Log.v("BarcodeActivity", "No result");
  }
}
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/01/28/integrate-zxing-with-android-studio/)
