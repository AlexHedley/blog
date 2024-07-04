---
title: FMDB
# lead:
tags:
  - iOS
  - fmdb
  - database
  - db
  - objc
author: AlexHedley
# description:
published: 2015-05-15
# image:
# imageattribution:
---

Useful ways to get data out of FMDB.

_Count_

```objectivec
NSUInteger count = [db intForQuery:@"SELECT COUNT(field) FROM table_name"];
```

Make sure to include the [`FMDatabaseAdditions.h` header file](https://github.com/ccgus/fmdb/blob/master/src/FMDatabaseAdditions.h) to use `intForQuery:`

_Max_

```objectivec
NSUInteger max = [db intForQuery:@"SELECT MAX(field) FROM table_name"];
```

_Min_

```objectivec
NSUInteger min = [db intForQuery:@"SELECT MIN(field) FROM table_name"];
```

_Average_

```objectivec
NSUInteger average = [db intForQuery:@"SELECT AVG(field) FROM table_name"];
```

_Sum (Σ)_

```objectivec
NSUInteger sum = [db intForQuery:@"SELECT SUM(field) FROM table_name"];
```

_Total_

```objectivec
NSUInteger total = [db intForQuery:@"SELECT TOTAL(field) FROM table_name"];
```

[https://www.sqlite.org/lang_aggfunc.html](https://www.sqlite.org/lang_aggfunc.html)

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/05/15/fmdb/)
