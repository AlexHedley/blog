---
title: Android - Preferences Screen
tags:
    - android
author: AlexHedley
# description: 
published: 2015-01-30
---

I've wanted to add Preferences Screen to my app.

There's a section on Treehouse

http://teamtreehouse.com/library/android-data-persistence

Key-Value Saving with SharedPreferences

It had a lot going on and most of it was already configured

The article I found most useful was:

https://androidresearch.wordpress.com/2012/03/09/creating-a-preference-activity-in-android/

Added here in case the site goes.

[gist 9b3d87f19f4a7c3caea6/]

`AndroidManifest.xml`

```xml
<application
......./>
  <activity
    android:name=".PrefsActivity"
    android:theme="@android:style/Theme.Black.NoTitleBar" >
  </activity>
</application>
```

`array.xml`

```xml
<?xml version="1.0" encoding="utf-8"?>
 <resources>
   <string-array name="listOptions">
     <item>Option 1</item>
     <item>Option 2</item>
     <item>Option 3</item>
     </string-array>
 
   <string-array name="listValues">
     <item>1 is selected</item>
     <item>2 is selected</item>
     <item>3 is selected</item>
   </string-array>
 </resources>
```

`layout.xml`

```xml
<Button
  android:id="@+id/btnPrefs"
  android:layout_width="wrap_content"
  android:layout_height="wrap_content"
  android:text="Preferences Screen" />
```

`MainActivity.java`

```java
public static final String DEFAULT_URL = "http://alexhedley.com/landingpage";
SharedPreferences sharedPref;

// Set the Default Values
PreferenceManager.setDefaultValues(this, R.xml.preferences, false);
sharedPref = PreferenceManager.getDefaultSharedPreferences(this);
String defaultURL = sharedPref.getString("url", DEFAULT_URL);

SharedPreferences.Editor editor = sharedPref.edit();
editor.putString("url", url); //url is value you get
editor.commit();
Toast.makeText(getApplicationContext(), "Default URL Updated", Toast.LENGTH_SHORT).show();

`PreferenceDemoActivity.java`
public class PreferenceDemoActivity extends Activity {
TextView textView;
 
@Override
public void onCreate(Bundle savedInstanceState) {
   super.onCreate(savedInstanceState);
   setContentView(R.layout.main);
 
   Button btnPrefs = (Button) findViewById(R.id.btnPrefs);
   Button btnGetPrefs = (Button) findViewById(R.id.btnGetPreferences);
 
   textView = (TextView) findViewById(R.id.txtPrefs);
 
   View.OnClickListener listener = new View.OnClickListener() {
 
   @Override
   public void onClick(View v) {
   switch (v.getId()) {
     case R.id.btnPrefs:
        Intent intent = new Intent(PreferenceDemoActivity.this,
        PrefsActivity.class);
        startActivity(intent);
        break;
   
     case R.id.btnGetPreferences:
        displaySharedPreferences();
        break;
   
     default:
       break;
     }
    }
   };
 
   btnPrefs.setOnClickListener(listener);
}
```

`preferences.xml`

```xml
//https://androidresearch.wordpress.com/2012/03/09/creating-a-preference-activity-in-android/
<?xml version="1.0" encoding="utf-8"?>
<PreferenceScreen xmlns:android="http://schemas.android.com/apk/res/android" >
 <PreferenceCategory
   android:summary="Username and password information"
   android:title="Login information" >
  <EditTextPreference
     android:key="username"
     android:summary="Please enter your login username"
     android:title="Username" />
 </PreferenceCategory>
</PreferenceScreen>
```

`PrefsActivity.java`

```java
public class PrefsActivity extends PreferenceActivity{
 
  @Override
  protected void onCreate(Bundle savedInstanceState) {
     super.onCreate(savedInstanceState);
     addPreferencesFromResource(R.xml.prefs);
  }
}
```

Others included but were old:

http://android-elements.blogspot.co.uk/2011/06/creating-android-preferences-screen.html

http://stackoverflow.com/questions/14756457/android-deprecated-method-warning-regarding-preferenceactivity/24051942#24051942

http://stackoverflow.com/questions/15126290/adding-settings-to-android-app

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/01/30/android-preferences-screen/)
