---
title: Reachability
tags:
    - iOS
author: AlexHedley
# description: 
published: 2014-09-20
---

http://iosameer.blogspot.co.uk/2013/01/checking-internet-connection-in-ios-apps.html

https://gist.github.com/AlexHedley/2f257ee45d78b83631cc

\[gist https://gist.github.com/2f257ee45d78b83631cc /\]

```objectivec
//http://iosameer.blogspot.co.uk/2013/01/checking-internet-connection-in-ios-apps.html
#import "Reachability.h"

//// Just use it ,Where you need it  (checking internet connection)
Reachability *reachTest = [Reachability reachabilityWithHostName:@"www.apple.com"];     
NetworkStatus internetStatus = [reachTest  currentReachabilityStatus];    

if ((internetStatus != ReachableViaWiFi) && (internetStatus != ReachableViaWWAN)) {   
  /// Create an alert if connection doesn't work,no internet connection   
  UIAlertView *myAlert = [[UIAlertView alloc] initWithTitle:@"No Internet Connection" 
                                              message:@"You require an internet connection via WiFi or cellular network for location finding to work."  
                                              delegate:self 
                                              cancelButtonTitle:@"Ok" 
                                              otherButtonTitles:nil];  
  [myAlert show];  
  [myAlert release];  
} 
else {  
  // There is a internet connection
  /// Do,Whatever you want  
} 
```

//https://developer.apple.com/library/ios/samplecode/Reachability/Introduction/Intro.html
//https://github.com/tonymillion/Reachability
//http://code.tutsplus.com/tutorials/ios-sdk-detecting-network-changes-with-reachability--mobile-18299

Links

https://github.com/tonymillion/Reachability

https://developer.apple.com/library/ios/samplecode/Reachability/Introduction/Intro.html

http://code.tutsplus.com/tutorials/ios-sdk-detecting-network-changes-with-reachability--mobile-18299
