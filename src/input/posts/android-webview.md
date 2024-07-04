---
title: Android WebView
# lead:
# tags:
#     -
author: AlexHedley
# description:
published: 2015-01-23
# image:
# imageattribution:
---

I'm replicating an app from iOS in Android

Here's how to fill in a form and click a button in a web view:

[gist 8b015912875c8f1e693e /]

<?# Gist 8b015912875c8f1e693e /?>

`activity.java`

```java
Button button = (Button) findViewById(R.id.button);
Toolbar toolbar = (Toolbar) findViewById(R.id.myToolbar);

final WebView webView = (WebView) findViewById(R.id.webView);
//Set links to show in webview not open in another program.
webView.setWebViewClient(new WebViewClient());

webView.getSettings().setJavaScriptEnabled(true);
String url = "http://www.alexhedley.com/form.asp";
webView.loadUrl(url);

View.OnClickListener listener = new View.OnClickListener() {
    @Override
    public void onClick(View v) {
        String barcode = "barcode";
        String fillIn = "document.getElementById('barcode').value = '" + barcode + "';";
        String click = "(function(){document.getElementById('btnEnter').click();})()";
        String combined = "javascript:" + fillIn + click;
        webView.loadUrl(combined);
    }
};
button.setOnClickListener(listener);
```

`activity.xml`

```xml
<android.support.v7.widget.Toolbar
  android:id="@+id/myToolbar"
  android:layout_width="match_parent"
  android:layout_height="wrap_content"
  android:layout_alignParentBottom="true"
  />
```

`form.html`

```html
<form method="POST" action="form-process.asp">
  <label for="barcode">Barcode: </label>
  <input id="barcode" name="barcode" type="text" value="" />
  <br />
  <input id="btnEnter" name="btnEnter" type="submit" value="Submit" />
</form>
```

`manifest.xml`

```xml
<uses-permission
  android:name="android.permission.INTERNET">
</uses-permission>
```

> https://gist.github.com/anonymous/30f18702e450f0cdf0fe

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/01/23/android-webview/)
