---
title: Send an Email (with Attachment)
tags:
    - iOS
author: AlexHedley
# description: 
published: 2015-05-04
---

[gist 6e306d13653113d8fcc6 /]

`ViewController.h`

```objectivec
#import <MessageUI/MessageUI.h>

@interface ViewController : UIViewController <MFMailComposeViewControllerDelegate>
```

`ViewController.m`

```objectivec
- (void)sendEmail {
    // Email Subject
    NSString *emailTitle = @"Subject";
    // Email Content
    NSString *messageBody = @"\n\nSent from the iOS App";
    // To address
    //NSArray *toRecipents = [NSArray arrayWithObject:kEmail];
    
    MFMailComposeViewController *mc = [[MFMailComposeViewController alloc] init];
    mc.mailComposeDelegate = self;
    [mc setSubject:emailTitle];
    [mc setMessageBody:messageBody isHTML:NO];
    //[mc setToRecipients:toRecipents];
    
    //NSData *pdfData = [NSData dataWithContentsOfFile:[[NSBundle mainBundle]pathForResource:@"X" ofType:@"pdf"]];
    NSArray *paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *documentsDirectory = [paths objectAtIndex:0];
    NSString *path = [documentsDirectory stringByAppendingPathComponent:@"X.pdf"];
    NSData *pdfData = [NSData dataWithContentsOfFile:path];
    [mc addAttachmentData:pdfData mimeType:@"application/pdf" fileName:@"X"];
    // Present mail view controller on screen
    [self presentViewController:mc animated:YES completion:^{
        [[UIApplication sharedApplication] setStatusBarStyle:UIStatusBarStyleLightContent];
    }];
}

- (void) mailComposeController:(MFMailComposeViewController *)controller didFinishWithResult:(MFMailComposeResult)result error:(NSError *)error {
    switch (result) {
        case MFMailComposeResultCancelled:
            NSLog(@"Mail cancelled");
            break;
        case MFMailComposeResultSaved:
            NSLog(@"Mail saved");
            break;
        case MFMailComposeResultSent:
            NSLog(@"Mail sent");
            break;
        case MFMailComposeResultFailed:
            NSLog(@"Mail sent failure: %@", [error localizedDescription]);
            break;
        default:
            break;
    }
    // Close the Mail Interface
    [self dismissViewControllerAnimated:YES completion:NULL];
}
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/05/04/send-an-email/)
