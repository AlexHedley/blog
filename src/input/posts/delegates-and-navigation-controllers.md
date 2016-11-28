---
title: Delegates and Navigation Controllers
tags:
    - tvOS
    - 10
    - tvml
    - tvmljs
author: AlexHedley
# description: 
published: 2016-11-28
---

Using Delegates with Navigation Controllers

Get the nav controller first.

[gist b044059d586dd051b4c88225df1168b4]

`Controller.m`

```objectivec
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    if ([segue.identifier isEqualToString:@"showLocations"]) {
        //LocationsTableViewController *ltvc = (LocationsTableViewController *)[segue destinationViewController];
        
        UINavigationController *navController = [segue destinationViewController];
        LocationsTableViewController *ltvc = (LocationsTableViewController *)([navController viewControllers][0]);
        ltvc.delegate = self;
    }
}
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2016/11/28/delegates-and-navigation-controllers/)
