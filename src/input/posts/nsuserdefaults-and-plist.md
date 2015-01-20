---
title: NSUserDefaults and plist
# tags:
#     - 
author: AlexHedley
# description: 
published: 2015-01-20
---

Using your own plist with NSUserDefaults

http://oleb.net/blog/2014/02/nsuserdefaults-handling-default-values/

\[gist 879e80de094b983c13e3\]

`NSUserDefaults.m`

```objectivec
NSString *defaultPrefsFile = [[NSBundle mainBundle] pathForResource:@"defaultPrefs" ofType:@"plist"];
NSDictionary *defaultPrefs = [NSDictionary dictionaryWithContentsOfFile:defaultPrefsFile];
[[NSUserDefaults standardUserDefaults] registerDefaults:defaultPrefs];

//Get
NSString *strBaseURL = [[NSUserDefaults standardUserDefaults] stringForKey:@"BaseURL"];

//Set
[[NSUserDefaults standardUserDefaults] setObject:baseURL forKey:@"BaseURL"];
```

`Other.m`

```objectivec
NSURL *defaultPrefsFile = [[NSBundle mainBundle] URLForResource:@"DefaultPreferences" withExtension:@"plist"];
NSDictionary *defaultPrefs = [NSDictionary dictionaryWithContentsOfURL:defaultPrefsFile];
[[NSUserDefaults standardUserDefaults] registerDefaults:defaultPrefs];
```

[Original Link](https://alexhedley.wordpress.com/2015/01/20/nsuserdefaults-and-plist/)
