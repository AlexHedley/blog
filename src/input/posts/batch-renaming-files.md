---
title: Batch renaming files
# lead:
# tags:
#     -
author: AlexHedley
# description:
published: 2015-07-11
# image:
# imageattribution:
---

I needed to batch rename some files

`brew install rename`

To test run it

`rename -n -e 's/-.*-/_/'  *.png`

Remove the -n to perform it

`rename -e 's/-.*-/_/'  *.png`

I wanted to remove the following -portrait

`rename -d -portrait *`

Thanks to

http://stackoverflow.com/questions/24102974/mac-os-x-terminal-batch-rename

http://superuser.com/questions/398709/mass-remove-file-prefix-on-a-mac

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/07/11/batch-renaming-files/)
