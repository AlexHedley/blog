---
title: Poor Mans TSql Formatter
tags:
    - programming
    - sql
    - nuget
    - csharp
author: AlexHedley
# description: 
published: 2020-05-17
---

[PoorMansTSqlFormatter](http://architectshack.com/PoorMansTSqlFormatter.ashx) is

> This is a free and open-source SQL (T-SQL) formatter

It's a fantasic tool with plugins for SSMS, VS Code, there's a website [Poor SQL](http://poorsql.com/).

If you want to use this in a .NET app you can pull the [NuGet](https://www.nuget.org/packages/PoorMansTSQLFormatter/) which is currently at version 1.4.3.1, but the current [release](https://github.com/TaoK/PoorMansTSqlFormatter/releases) is 1.6.13.

To try it out I downloaded the WinForms App to see what options there are.

> WinForms App (simple exe): SqlFormatterWinforms.1.6.13.zip (1644 downloads this version, about 32000 for previous versions)

I then decompiled the *SqlFormatterWinforms.exe* to see how to setup the formatter.

Another way would be to look at the [Demo](https://github.com/TaoK/PoorMansTSqlFormatter/tree/master/PoorMansTSqlFormatterDemo) code on GitHub.

Then look into the [MainForm.cs](https://github.com/TaoK/PoorMansTSqlFormatter/blob/master/PoorMansTSqlFormatterDemo/MainForm.cs)

If you wish to run the app you will need to build the [Lib](https://github.com/TaoK/PoorMansTSqlFormatter/tree/master/PoorMansTSqlFormatterLib) so the app can use the DLL.

![PoorMansTSqlFormatter](images/pmtf/pmtf_1.png "PoorMansTSqlFormatter Demo App")

`DoFormatting()` is the method which converts your SQL string into the formatted code so this contains a number of items we need to get the basics working.

I created a Console App, added the NuGet and started my journey.

First we need a `tokenizer`, a `parser` and `formatter`.

```csharp
private static ISqlTokenizer _tokenizer;
private static ISqlTokenParser _parser;
private static ISqlTreeFormatter _formatter;
```

We can set the defaults for these

```csharp
_tokenizer = (ISqlTokenizer)new TSqlStandardTokenizer();
_parser = (ISqlTokenParser)new TSqlStandardParser();
```

The formatter needs a few options.
Unfortunately `TSqlStandardFormatterOptions` isn't in this version of the NuGet.

```csharp
string indentString = "\t";
int spacesPerTab = 4;
int maxLineWidth = 999;
bool expandCommaLists = true;
bool trailingCommas = false;
bool spaceAfterExpandedComma = false;
bool expandBooleanExpressions = true;
bool expandCaseStatements = true;
bool expandBetweenConditions = true;
bool breakJoinOnSections = false;
bool uppercaseKeywords = true;
bool htmlColoring = true;
bool keywordStandardization = false;

ISqlTreeFormatter underlyingFormatter = new TSqlStandardFormatter(indentString, spacesPerTab, maxLineWidth, expandCommaLists, trailingCommas, spaceAfterExpandedComma, expandBooleanExpressions, expandCaseStatements, expandBetweenConditions, breakJoinOnSections, uppercaseKeywords, htmlColoring, keywordStandardization);
```

Next we can create the `formatter` using the options above from the `underlyingFormatter`.

```csharp
_formatter = (ISqlTreeFormatter)new HtmlPageWrapper(underlyingFormatter);
```

Next create a sample piece of sql:

```sql
Select * from table
```

```csharp
var sqlString = "Select * from table";
```

And pass it to the tokenizer:

```csharp
ITokenList tokenList = _tokenizer.TokenizeSQL(sqlString);
```

With a token list available we can parse this sql:

```csharp
XmlDocument sql = _parser.ParseSQL(tokenList);
```

You may notice the `Node` type in the code.

Now that the SQL is in an `XMLDocument` we can format it:

```csharp
string formattedSql = _formatter.FormatSQLTree(sql);
```

This will produce a HTML doc which you can display in a browser control.

```html
<!DOCTYPE html >
<html>
<head>
</head>
<body>
<style type="text/css">
.SQLCode {
	font-size: 13px;
	font-weight: bold;
	font-family: monospace;;
	white-space: pre;
    -o-tab-size: 4;
    -moz-tab-size: 4;
    -webkit-tab-size: 4;
}
.SQLComment {
	color: #00AA00;
}
.SQLString {
	color: #AA0000;
}
.SQLFunction {
	color: #AA00AA;
}
.SQLKeyword {
	color: #0000AA;
}
.SQLOperator {
	color: #777777;
}
.SQLErrorHighlight {
	background-color: #FFFF00;
}


</style>
<pre class="SQLCode"><span class="SQLKeyword">SELECT</span> <span class="SQLOperator">*</span>
<span class="SQLKeyword">FROM</span> <span class="SQLKeyword">TABLE</span>
</pre>
</body>
</html>
```

As this is in `<pre>` tags the newline characters matter for formatting.

Ouput:

<!DOCTYPE html >
<html>
<head>
</head>
<body>

<style type="text/css">
    .SQLCode {
        font-size: 13px;
        font-weight: bold;
        font-family: monospace;;
        white-space: pre;
        -o-tab-size: 4;
        -moz-tab-size: 4;
        -webkit-tab-size: 4;
    }
    .SQLComment {
        color: #00AA00;
    }
    .SQLString {
        color: #AA0000;
    }
    .SQLFunction {
        color: #AA00AA;
    }
    .SQLKeyword {
        color: #0000AA;
    }
    .SQLOperator {
        color: #777777;
    }
    .SQLErrorHighlight {
        background-color: #FFFF00;
    }
</style>

<pre class="SQLCode"><span class="SQLKeyword">SELECT</span> <span class="SQLOperator">*</span>
<span class="SQLKeyword">FROM</span> <span class="SQLKeyword">TABLE</span>
</pre>

</body>
</html>
