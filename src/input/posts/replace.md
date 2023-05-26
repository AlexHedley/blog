---
title: Replace
tags:
    - iOS
author: AlexHedley
# description: 
published: 2014-10-02
---

`xLabel.text = [STRING stringByReplacingOccurrencesOfString:@" " withString:@""];`

`-(NSString *) stringByStrippingHTML: (NSString *)strValue { NSRange r; while ((r = [strValue rangeOfString:@"]+>" options:NSRegularExpressionSearch]).location != NSNotFound) strValue = [strValue stringByReplacingCharactersInRange:r withString:@""]; return strValue; }`

HTML

`NSString *cleanTitle = facebookPost.title; cleanTitle = [cleanTitle stringByReplacingOccurrencesOfString:@"'" withString:@"'"]; cleanTitle = [cleanTitle stringByReplacingOccurrencesOfString:@"&#064" withString:@"@"]; cell.textLabel.text = cleanTitle;`

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2014/10/02/replace/)
