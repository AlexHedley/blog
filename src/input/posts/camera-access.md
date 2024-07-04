---
title: Camera Access
# lead:
tags:
  - iOS
  - camera
author: AlexHedley
# description:
published: 2017-01-08
# image:
# imageattribution:
---

Info.plist

Add a new item

Privacy - Camera Usage Description

Value: "Used to scan barcodes"

Or as XML

```xml
<key>NSCameraUsageDescription</key>
<string>Used to scan barcodes</string>
```

[http://useyourloaf.com/blog/privacy-settings-in-ios-10/](http://useyourloaf.com/blog/privacy-settings-in-ios-10/)

---

Photo Access

```xml
<key>NSPhotoLibraryUsageDescription</key>
<string>This app requires access to the photo library.</string>
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2017/01/08/camera-access/)
