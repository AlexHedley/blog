---
title: SQLite Help
tags:
    - iOS
    - date
    - sqlite
author: AlexHedley
# description: 
published: 2015-05-10
---

Order By Date

Dates are stored as TEXT or if you want a number from 1970.

If they are TEXT and you want to sort them you need to convert them to a Date first.

```sql
SELECT * FROM Table ORDER BY date(dateColumn) DESC
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/05/10/sqlite-help/)
