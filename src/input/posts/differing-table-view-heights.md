---
title: Differing Table View Heights
# lead:
tags:
  - iOS
  - height
  - tableview
author: AlexHedley
# description:
published: 2015-05-03
# image:
# imageattribution:
---

So I'm creating an app which I wanted different themes for the Table View. I've created two Prototype Cells and given them different CellIdentifiers. This is then stored in a plist of DefaultPreferences.

Even though I'd given them different heights in IB but this wasn't reflected in the app.

[gist 6218ba01a2e8fc3ef0b5 /]

<?# Gist 6218ba01a2e8fc3ef0b5 /?>

`TableViewController.m`

```objectivec
- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    NSString *cellIdentifier = [[NSUserDefaults standardUserDefaults] stringForKey:@"Theme"];
    UITableViewCell *cell = [self.tableView dequeueReusableCellWithIdentifier:cellIdentifier];
    return cell.bounds.size.height;
}
```

Then once you've made your choice and you return to the List you'll want to reload the data.

```objectivec
-(void)viewWillAppear:(BOOL)animated {
    [self.tableView reloadData];
}
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/05/03/differing-table-view-heights/)
