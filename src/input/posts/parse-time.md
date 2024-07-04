---
title: Parse Time
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

Parse time from seconds to hours:minutes:seconds

\[gist https://gist.github.com/5bc12ef4902bf1ce8fb7 /\]

<?# Gist 5bc12ef4902bf1ce8fb7 /?>

```objectivec
- (NSString *)formattedTime {
    int seconds = [self.duration intValue] % 60;
    int minutes = [self.duration intValue] / 60;
    int hours = [self.duration intValue] / 3600;

    return [NSString stringWithFormat:@"%02d:%02d:%02d", hours, minutes, seconds];
}
```

```objectivec
//Better solution
- (NSString *)timeFormatted:(int)totalSeconds{
  int seconds = totalSeconds % 60;
  int minutes = (totalSeconds / 60) % 60;
  int hours = totalSeconds / 3600;

  return [NSString stringWithFormat:@"%02d:%02d:%02d",hours, minutes, seconds];
}
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2014/10/01/parse-time/)
