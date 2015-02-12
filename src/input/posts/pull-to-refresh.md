---
title: Pull To Refresh
tags:
    - iOS
author: AlexHedley
# description: 
published: 2015-02-12
---

Wanted to add the Pull To Refresh capability.

[gist feef1785d533d3960a22 /]

`Macro.m`

```objectivec
#define UIColorFromRGB(rgbValue) [UIColor colorWithRed:((float)((rgbValue & 0xFF0000) >> 16))/255.0 green:((float)((rgbValue & 0xFF00) >> 8))/255.0 blue:((float)(rgbValue & 0xFF))/255.0 alpha:1.0]
```

`ViewController.m`

```objectivec
- (void)viewDidLoad {
    [super viewDidLoad];
    [self setupRefresh];
    ...
}

- (void)setupRefresh {
    UIRefreshControl *refresh = [[UIRefreshControl alloc] init];
    refresh.tintColor = UIColorFromRGB(0x2194D3);
    refresh.attributedTitle = [[NSAttributedString alloc] initWithString:@"Pull to Refresh"];
    [refresh addTarget:self action:@selector(refreshView:) forControlEvents:UIControlEventValueChanged];
    self.refreshControl = refresh;
}

- (void)refreshView:(UIRefreshControl *)refresh {
    [self getData];
    
    refresh.attributedTitle = [[NSAttributedString alloc] initWithString:@"Refreshing data..."];
    // custom refresh logic would be placed here...
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:@"MMM d, h:mm a"];
    NSString *lastUpdated = [NSString stringWithFormat:@"Last updated on %@", [formatter stringFromDate:[NSDate date]]];
    refresh.attributedTitle = [[NSAttributedString alloc] initWithString:lastUpdated];
    [refresh endRefreshing];
}
```

Useful Blog:

[http://www.intertech.com/Blog/ios-6-pull-to-refresh-uirefreshcontrol/](http://www.intertech.com/Blog/ios-6-pull-to-refresh-uirefreshcontrol/)

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/02/12/pull-to-refresh/)
