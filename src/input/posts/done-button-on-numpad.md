---
title: Done button on NumPad
# lead:
tags:
  - iOS
  - objc
author: AlexHedley
# description:
published: 2015-05-10
# image:
# imageattribution:
---

I've been researching adding a done button to a NumPad and keep getting the same error:

> **Can't find keyplane that supports type 4 for keyboard iPhone-PortraitChoco-NumberPad; using 2705787216_PortraitChoco_iPhone-Simple-Pad_Default**

And it seems to take a lot of code.

Another option would be to add a toolbar above the keyboard.

[gist b2311df9ba1c63e910a5 /]

<?# Gist b2311df9ba1c63e910a5 /?>

`ViewController.m`

```objectivec
UIToolbar *doneToolbar = [[UIToolbar alloc] initWithFrame:(CGRect){0, 0, 50, 50}]; // Create and init
doneToolbar.barStyle = UIBarStyleBlackTranslucent; // Specify the preferred barStyle
doneToolbar.items = @[
[[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemFlexibleSpace target:nil action:nil],
[[UIBarButtonItem alloc] initWithTitle:@"Done" style:UIBarButtonItemStylePlain target:self action:@selector(doneEditAction)] // Add your target action
]; // Define items -- you can add more

yourField.inputAccessoryView = doneToolbar; // Now add toolbar to your field's inputview and run
[doneToolbar sizeToFit]; // call this to auto fit to the view

- (void)doneEditAction {
    [self.view endEditing:YES];
}
```

- http://stackoverflow.com/questions/25842168/cant-find-keyplane-that-supports-type-4-for-keyboard-iphone-portrait-numberpad

Not sure how well this will work with [TPKeyboardAvoiding](https://github.com/michaeltyson/TPKeyboardAvoiding) but let's see, and it does!

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/05/10/done-button-on-numpad/)
