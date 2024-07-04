---
title: Parse Date
# lead:
tags:
  - iOS
  - objc
  - date
  - format
author: AlexHedley
# description:
published: 2014-10-01
# image:
# imageattribution:
---

SetDateFormat

[gist https://gist.github.com/1f916f41ef31e334f5b7 /]

<?# Gist 1f916f41ef31e334f5b7  /?>

```objectivec
//Parsing a date in the following format '//2014-07-13T20:35:47.000Z'
//Use the DateFormat of @"yyyy-MM-dd'T'HH:mm:ss.zzz'Z'"

- (NSString *)formattedDate {
    NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
    [dateFormatter setDateFormat:@"yyyy-MM-dd'T'HH:mm:ss.zzz'Z'"]; //2014-07-13T20:35:47.000Z
    NSDate *tempDate = [dateFormatter dateFromString:self.date];
    [dateFormatter setDateFormat:@"EE MMM, dd"];
    return [dateFormatter stringFromDate:tempDate];
}
```

[gist id=1f916f41ef31e334f5b7]

[gist]https://gist.github.com/AlexHedley/1f916f41ef31e334f5b7[gist]

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2014/10/01/parse-date/)
