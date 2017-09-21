---
title: UIBarButtonItem Image and Text
tags:
  - iOS
  - UIBarButtonItem
  - UIButton
  - UIImage
author: AlexHedley
# description:
published: 2017-09-21
---

I want to add an image and text to a BarButtonItem but can't in IB.

I looked into EdgeInsets but couldn't get them to work with the image.

I'd also like to shrink the image

```objectivec
// https://stackoverflow.com/a/18853240/2895831
UIView \*rightButtonView = \[\[UIView alloc\]initWithFrame:CGRectMake(0, 0, 110, 50)\];

UIImage \*buttonImage = \[UIImage imageNamed:@"LocationArrow"\];
//UIEdgeInsets edgeInsets = UIEdgeInsetsMake(50, 50, 50, 50);
//UIImage \*buttonImage = \[\[UIImage imageNamed:@"LocationArrow"\] resizableImageWithCapInsets:edgeInsets\];
//UIImage(CGImage: originalImage!.CGImage!, scale: 5, orientation: originalImage!.imageOrientation)
// https://stackoverflow.com/a/38523085/2895831
buttonImage = \[UIImage imageWithCGImage:buttonImage.CGImage
 scale:4//CGImageGetHeight(buttonImage.CGImage)/2
 orientation:UIImageOrientationUp\];

UIButton \*rightButton = \[UIButton buttonWithType:UIButtonTypeSystem\];
rightButton.backgroundColor = \[UIColor clearColor\];
rightButton.frame = rightButtonView.frame;
\[rightButton setImage:buttonImage forState:UIControlStateNormal\];
\[rightButton setTitle:NSLocalizedString(@"My Location", nil) forState:UIControlStateNormal\];
rightButton.tintColor = \[UIColor whiteColor\];
rightButton.autoresizesSubviews = YES;
rightButton.autoresizingMask = UIViewAutoresizingFlexibleWidth | UIViewAutoresizingFlexibleLeftMargin;
rightButton.semanticContentAttribute = UISemanticContentAttributeForceRightToLeft;
\[rightButton addTarget:self action:@selector(myLocationAction:) forControlEvents:UIControlEventTouchUpInside\];

CGFloat padding = 10.0f;
\[rightButton setTitleEdgeInsets:UIEdgeInsetsMake(0, 0, 0, padding)\];
//\[rightButton setContentEdgeInsets:UIEdgeInsetsMake(0, 0, 0, padding)\];
//\[rightButton setContentEdgeInsets:UIEdgeInsetsMake(padding, padding, padding, padding)\];
//\[rightButton setImageEdgeInsets:UIEdgeInsetsMake(padding, 0, padding, 0)\]; //0, padding, 0, padding
//\[rightButton setImageEdgeInsets:UIEdgeInsetsMake(padding, padding, padding, padding)\];

\[rightButtonView addSubview:rightButton\];

UIBarButtonItem \*rightBarButton = \[\[UIBarButtonItem alloc\] initWithCustomView:rightButtonView\];
self.navigationItem.rightBarButtonItem = rightBarButton;
```

Image

- https://stackoverflow.com/a/38523085/2895831

```objectivec
[UIImage imageWithCGImage:buttonImage.CGImage scale:4 orientation:UIImageOrientationUp];
```

Pick your method to scale

```objectivec
CGImageGetHeight(buttonImage.CGImage)/2
```

Or

```objectivec
CGImageGetWidth(...)/DESIREDWIDTH
```

**IB**

There is the handy

- Bar Item
- Image Inset

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2017/09/21/uibarbuttonitem-image-and-text/)
