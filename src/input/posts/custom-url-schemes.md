---
title: Custom URL Schemes
# tags:
#     - 
author: AlexHedley
# description: 
published: 2015-01-20
---

An app I'm working on needed a custom URL Scheme, I found a simple tutorial at:

http://www.idev101.com/code/Objective-C/custom\_url\_schemes.html

\[gist 3eb964d2e1a0a77690e9\]

`application:handleOpenURL.m`

```objectivec
- (BOOL)application:(UIApplication *)application handleOpenURL:(NSURL *)url {
    NSLog(@"url recieved: %@", url);
    NSLog(@"query string: %@", [url query]);
    NSLog(@"host: %@", [url host]);
    NSLog(@"url path: %@", [url path]);
    NSDictionary *dict = [self parseQueryString:[url query]];
    NSLog(@"query dict: %@", dict);
    return YES;
}
```

`parseQueryString.m`

```objectivec
//http://www.idev101.com/code/Objective-C/custom_url_schemes.html
- (NSDictionary *)parseQueryString:(NSString *)query {
    NSMutableDictionary *dict = [[[NSMutableDictionary alloc] initWithCapacity:6] autorelease];
    NSArray *pairs = [query componentsSeparatedByString:@"&"];
    
    for (NSString *pair in pairs) {
        NSArray *elements = [pair componentsSeparatedByString:@"="];
        NSString *key = [[elements objectAtIndex:0] stringByReplacingPercentEscapesUsingEncoding:NSUTF8StringEncoding];
        NSString *val = [[elements objectAtIndex:1] stringByReplacingPercentEscapesUsingEncoding:NSUTF8StringEncoding];
        
        [dict setObject:val forKey:key];
    }
    return dict;
}
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/01/20/custom-url-schemes/)
