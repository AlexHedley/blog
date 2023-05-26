---
title: MFMailComposeViewController
tags:
    - iOS
    - mfmailcomposeviewcontroller
author: AlexHedley
# description: 
published: 2014-10-14
---

I used the following tutorial to get an email to send in the app.

http://www.appcoda.com/tag/mfmailcomposeviewcontroller/

The issue i then came across was it didn't have the white theme I needed.

\[gist d326c1efbd1830d33a48 /\]

```objectivec
//http://www.appcoda.com/ios-programming-101-send-email-iphone-app/
- (IBAction)sendEmail:(id)sender {
    // Email Subject
    NSString *emailTitle = @"iOS Email";
    // Email Content
    NSString *messageBody = @"Sent from iOS App";
    // To address
    NSArray *toRecipents = [NSArray arrayWithObject:@"unpluggedne@gmail.com"];
    
    MFMailComposeViewController *mc = [[MFMailComposeViewController alloc] init];
    mc.mailComposeDelegate = self;
    [mc setSubject:emailTitle];
    [mc setMessageBody:messageBody isHTML:NO];
    [mc setToRecipients:toRecipents];
    //[[mc navigationBar] setTitleTextAttributes:[NSDictionary dictionaryWithObject:[UIColor whiteColor] forKey:NSForegroundColorAttributeName]];
    [[mc navigationBar] setTintColor:[UIColor whiteColor]];
    
    // Present mail view controller on screen
    [self presentViewController:mc animated:YES completion:^{
        [[UIApplication sharedApplication] setStatusBarStyle:UIStatusBarStyleLightContent];
    }];
    
    //[self applyComposerInterfaceApperance];
}
```

```objectivec
- (void) mailComposeController:(MFMailComposeViewController *)controller didFinishWithResult:(MFMailComposeResult)result error:(NSError *)error
{
    switch (result)
    {
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

```objectivec
- (void)applyComposerInterfaceApperance
{
    [[UINavigationBar appearance] setTintColor:[UIColor whiteColor]];
    [[UINavigationBar appearance] setTitleTextAttributes:@{NSForegroundColorAttributeName: [UIColor whiteColor]}];
    [[UIApplication sharedApplication] setStatusBarStyle:UIStatusBarStyleLightContent];
}
```

I now would like the first responder to be the Body so you can start typing from the get go.

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2014/10/14/mfmailcomposeviewcontroller/)
