---
title: API Clients - Chaining Requests
tags:
    - api
author: AlexHedley
# description: 
published: 2017-03-20
---

_POSTMAN_

https://www.getpostman.com/docs/chaining_requests

http://blog.getpostman.com/2014/01/27/extracting-data-from-responses-and-chaining-requests/

```javascript
var jsonData = JSON.parse(responseBody);

postman.setEnvironmentVariable("token", jsonData.token);
```

Add

`{{token}}`

* * *

_PAW_

## Variables from previous responses

https://paw.cloud/docs/environments/environments-from-responses

In the response view, right-click on the field you're interested in and pick _Copy as Response Body Dynamic Value_
