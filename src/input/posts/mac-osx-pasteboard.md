---
title: Mac OSX Pasteboard
# lead:
tags:
  - macosx
  - objc
  - nspasteboard
author: AlexHedley
# description:
published: 2015-07-26
# image:
# imageattribution:
---

Need to copy a value to the Pasteboard?

Don't forget to clear it first.

[gist 92a8e93464a3f0f449be /]

<?# Gist 92a8e93464a3f0f449be  /?>

`pb.m`

```objectivec
- (IBAction)copyURL:(id)sender {
    NSPasteboard *pasteboard = [NSPasteboard generalPasteboard];
    //pasteboard.string = txtURLEncode.stringValue;
    [pasteboard clearContents];
    [pasteboard setString:txtURLEncode.stringValue forType:NSPasteboardTypeString]; //NSStringPboardType;
}
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/07/26/mac-osx-pasteboard/)
