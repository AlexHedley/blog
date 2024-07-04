---
title: SQLite App
# lead:
tags:
  - iOS
  - csv
  - sqlite
  - database
author: AlexHedley
# description:
published: 2015-05-04
# image:
# imageattribution:
---

So I'm finally writing my Bowling Scores app. I'm using [FMDB](https://github.com/ccgus/fmdb).

I've also bought the following book: How To Develop iOS Database Apps using SQLite https://leanpub.com/iossqlite

Export to CSV http://stackoverflow.com/questions/4656887/how-to-export-sqlite-file-into-csv-file-in-iphone-sdk

[CHCSVParser](https://github.com/davedelong/CHCSVParser)

[gist 4ac103b5018c9d5fa974 /]

<?# Gist 4ac103b5018c9d5fa974 /?>

`Export.m`

```objectivec
    FMDatabase *db = [FMDatabase databaseWithPath:[Utility getDatabasePath]];
    [db open];
    FMResultSet *results = [db executeQuery:@"SELECT * FROM tblScores"];
    //CHCSVWriter *csvWriter = [[CHCSVWriter alloc] initForWritingToCSVFile:[NSHomeDirectory() stringByAppendingPathComponent:@"demo.csv"]];
    NSArray *paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *documentsDirectory = [paths objectAtIndex:0]; // Get documents folder
    NSString *document = [[NSString alloc] initWithFormat:@"%@/demo.csv", documentsDirectory];
    CHCSVWriter *csvWriter = [[CHCSVWriter alloc] initForWritingToCSVFile:document];

    while([results next]) {
        //NSDictionary *resultRow = [results resultDict];
        NSDictionary *resultRow = [results resultDictionary];
        NSArray *orderedKeys = [[resultRow allKeys] sortedArrayUsingSelector:@selector(compare:)];
        //iterate over the dictionary
        for (NSString *columnName in orderedKeys) {
            id value = [resultRow objectForKey:columnName];
            [csvWriter writeField:value];
        }
        //[csvWriter writeLine];
        [csvWriter finishLine];
    }
    //[csvWriter closeFile];
    [csvWriter closeStream];
```

Graphing

https://alexhedley.wordpress.com/2015/06/23/ios-charts/

I'll add more findings throughout my journey...

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/05/04/sqlite-app/)
