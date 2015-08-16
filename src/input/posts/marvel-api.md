---
title: Marvel API
# tags:
#     - 
author: AlexHedley
# description: 
published: 2015-08-16
---

So I found that Marvel have an API.

**Marvel API**
[http://developer.marvel.com/](http://developer.marvel.com/)

_Community_
[http://developer.marvel.com/community](http://developer.marvel.com/community)

_Authorization_
[http://developer.marvel.com/documentation/authorization](http://developer.marvel.com/documentation/authorization)

Original
[https://gist.github.com/oshliaer/eb8d7197e6749475652a](https://gist.github.com/oshliaer/eb8d7197e6749475652a)

[gist 2726b33578720c42b24c /]

`character_by_name.py`

```python
# #!/usr/bin/python
# -*- coding: utf-8 -*-
import time
import hashlib
import urllib.parse
import urllib.request

q = {}
q['ts'] = str(time.time())
q['apikey'] = '{Your_public_key}'
q['name'] = 'Spider-Man'
privateKey = '{Your_private_key}'
q['hash'] = hashlib.md5(bytes(q['ts'] + privateKey + q['apikey'], 'utf-8')).hexdigest()

params = urllib.parse.urlencode(q)
url = 'http://gateway.marvel.com/v1/public/characters?%s' % params

with urllib.request.urlopen(url) as f:
	print(f.read())
```

`characters.py`

```python
# #!/usr/bin/python
# -*- coding: utf-8 -*-
import time
import hashlib
import urllib.parse
import urllib.request

q = {}
q['ts'] = str(time.time())
q['apikey'] = '{Your_public_key}'
privateKey = '{Your_private_key}'
q['hash'] = hashlib.md5(bytes(q['ts'] + privateKey + q['apikey'], 'utf-8')).hexdigest()

params = urllib.parse.urlencode(q)
url = 'http://gateway.marvel.com/v1/public/characters?%s' % params

with urllib.request.urlopen(url) as f:
	print(f.read())
```

`characters2.py`

```python
# #!/usr/bin/python
# -*- coding: utf-8 -*-
from __future__ import with_statement
from __future__ import absolute_import
import time
import hashlib
import urllib2, urllib, urlparse

q = {}
q[u'ts'] = unicode(time.time())
q['apikey'] = '{Your_public_key}'
privateKey = '{Your_private_key}'
q[u'hash'] = hashlib.md5(str(q['ts'] + privateKey + q['apikey']).encode('utf-8')).hexdigest()

params = urllib.urlencode(q)
print params
url = u'http://gateway.marvel.com/v1/public/characters?%s' % params

#with urllib2.urlopen(url) as f:
f = urllib2.urlopen(url)
#print f.read()
```

I converted them to version 2 as I only have 2.7 on my machine atm

Convert from 3 to 2 [https://pypi.python.org/pypi/3to2/1.1.1](https://pypi.python.org/pypi/3to2/1.1.1)

`3to2 -w FILENAME.py`

**MD5** [http://www.miraclesalad.com/webtools/md5.php](http://www.miraclesalad.com/webtools/md5.php)

The [Authorisation](http://developer.marvel.com/documentation/authorization) page shows:

ts: 1

Public Key: 1234

Private Key: abcd

making: 1abcd1234

hash: ffd275c5130566a2916217b101f26150

(http://gateway.marvel.com/v1/comics?ts=1&apikey=1234&hash=ffd275c5130566a2916217b101f26150)

I created a Mac App to create the Hash and create this URL.

[http://stackoverflow.com/questions/2018550/how-do-i-create-an-md5-hash-of-a-string-in-cocoa](http://stackoverflow.com/questions/2018550/how-do-i-create-an-md5-hash-of-a-string-in-cocoa)

```objectivec
NSTimeInterval timeStamp = \[\[NSDate date\] timeIntervalSince1970\];
// NSTimeInterval is defined as double
NSNumber \*timeStampObj = \[NSNumber numberWithDouble: timeStamp\];
txtTimestamp.stringValue = \[timeStampObj stringValue\];
```

I call this in the app and it doesn't work.

[https://developer.apple.com/library/mac/documentation/Cocoa/Reference/Foundation/Miscellaneous/Foundation\_Constants/index.html#//apple\_ref/doc/constant\_group/URL\_Loading\_System\_Error\_Codes](https://developer.apple.com/library/mac/documentation/Cocoa/Reference/Foundation/Miscellaneous/Foundation_Constants/index.html#//apple_ref/doc/constant_group/URL_Loading_System_Error_Codes)

```objectivec
NSURLErrorUserAuthenticationRequired = -1013
NSURLErrorDomain Code=-1013
```

I can't get the MD5 from Python to match the ObjC one.

I can't get it to work with [CocoaRestClient](http://mmattozzi.github.io/cocoa-rest-client/) or ObjC.

Then I realise I've got my keys swapped, d'oh!

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/08/16/marvel-api/)
