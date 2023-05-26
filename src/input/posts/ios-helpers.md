---
title: iOS Helpers
tags:
    - iOS
author: AlexHedley
# description: 
published: 2014-09-21
---

Make a Label **Bold** or _Italic_

`myLabel.font = [UIFont boldSystemFontOfSize:16.0f] myLabel.font = [UIFont italicSystemFontOfSize:16.0f];` http://stackoverflow.com/questions/4713236/how-do-i-set-bold-and-italic-on-uilabel-of-iphone-ipad

Check if a value is Equal to a String

`if ([myLabel.text isEqualToString:@"A Day"]) { }` http://stackoverflow.com/questions/9318229/check-if-text-in-uilabel-is-equal-to-string-ios-objective-c

Loop all Labels on a Form. `for (UILabel *lbl in self.view.subviews) { [lbl setFont:[UIFont fontWithName:@"AppleGothic" size:22]]; }` http://stackoverflow.com/questions/1253091/loop-through-labels-iphone-sdk

Loop through Labels with Tag

`for (int i; i = 0; i < 10; i++) { UILabel * label = [theView viewWithTag: i]; }`

Change Colours

`.backgroundColor = [UIColor redColor];`

---

Bowling Scores - Highlight a Strike

```objectivec
-(void)changeColorToRed { 
  for (int i = 101; i < 134; i++) { 
    UILabel * lbl = [self.view viewWithTag: i]; 
    if ([lbl.text isEqualToString:@"X"]) { 
      lbl.textColor = [UIColor redColor]; 
      lbl.font = [UIFont boldSystemFontOfSize:16.0f];
    }
  }
}
```

Tried

```objectivec
for (UILabel *lbl in self.view.subviews) {
  if ([lbl.text isEqualToString:@"X"]) {
    lbl.textColor = [UIColor redColor];
    lbl.font = [UIFont boldSystemFontOfSize:16.0f];
  }
}
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2014/09/21/ios-helpers/)
