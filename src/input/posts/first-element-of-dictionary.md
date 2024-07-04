---
title: First Element of Dictionary
# lead:
tags:
  - iOS
  - objc
author: AlexHedley
# description:
published: 2014-10-01
# image:
# imageattribution:
---

Get the first Element of a Dictionary:

\[gist https://gist.github.com/80552a75bfdf071f58cb /\]

<?# Gist 3eb964d2e1a0a77690e9 /?>

URL: http://gdata.youtube.com/feeds/api/users/unpluggedacoustic1/uploads/?alt=json

JSON:

```json
"media$group":{
  "media$thumbnail": [
    { "url":"http://i.ytimg.com/vi/OKJk4QVyUTw/0.jpg","height":360,"width":480,"time":"00:01:39.500" },
    { "url":"http://i.ytimg.com/vi/OKJk4QVyUTw/1.jpg","height":90,"width":120,"time":"00:00:49.750" },
    { "url":"http://i.ytimg.com/vi/OKJk4QVyUTw/2.jpg","height":90,"width":120,"time":"00:01:39.500" },
    { "url":"http://i.ytimg.com/vi/OKJk4QVyUTw/3.jpg","height":90,"width":120,"time":"00:02:29.250" }
  ]
}
```

```objectivec
NSDictionary *mediagroup = [entry objectForKey:@"media$group"];
//NSLog(@"MediaGroup: %@", mediagroup);
NSDictionary *mediathumbnail = [mediagroup objectForKey:@"media$thumbnail"][0];
NSString *url = [mediathumbnail objectForKey:@"url"];
NSLog(@"%@", url);
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2014/10/01/first-element-of-dictionary/)
