---
title: Multi Select TableView
tags:
    - iOS
    - UITableView
author: AlexHedley
# description: 
published: 2015-08-13
---

Want to select more than one row in a TableView?

[gist 1e4aefb923ee02c652fd /]

`TableViewController.m`

```objectivec
NSArray *selectedRows = [self.tableView indexPathsForSelectedRows];
NSLog(@"selected: %@", selectedRows);
for (NSIndexPath *indexPath in selectedRows) {
    if(indexPath.section == 0){
        Player *player = [self.playersNotInGame objectAtIndex:indexPath.row];
        NSLog(@"1: %@", player.PlayerName);
    }
    else if(indexPath.section == 1){
        Player *player = [self.playersInGame objectAtIndex:indexPath.row];
        NSLog(@"2: %@", player.PlayerName);
    }
}
```

`TVC.m`

```objectivec
self.tableView.allowsMultipleSelection = YES;
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/08/13/multi-select-tableview/)
