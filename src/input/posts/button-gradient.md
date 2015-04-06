---
title: Programmatic Button Gradient
tags:
    - iOS
author: AlexHedley
# description: 
published: 2015-04-06
---

I'm programatically creating buttons and I'm using an image as a background, I'm no designer and got a bit bored of making a new one for each button, I've not even got to the different sizes yet, so thought why not use a gradient.

[gist ce30093516d5cf99ea35 /]

`ButtonGradient.m`

```objectivec
CAGradientLayer* gradientLayer = [[CAGradientLayer alloc] init];
[gradientLayer setBounds:[buttonTest bounds]];
[gradientLayer setPosition:
CGPointMake([buttonTest bounds].size.width/2, [buttonTest bounds].size.height/2)];
    
[gradientLayer setColors:
[NSArray arrayWithObjects:
  (id)[[UIColor blueColor] CGColor],
  (id)[[UIColor cyanColor] CGColor], nil]];
[[buttonTest layer] insertSublayer:gradientLayer atIndex:0];

//http://www.wmdeveloper.com/2012/01/uibutton-with-gradient.html
```

http://www.wmdeveloper.com/2012/01/uibutton-with-gradient.html

Other tuts http://www.raywenderlich.com/33330/core-graphics-tutorial-glossy-buttons

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/04/06/button-gradient/)
