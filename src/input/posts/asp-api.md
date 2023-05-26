---
title: ASP API
# tags:
#     - 
author: AlexHedley
# description: 
published: 2013-09-02
---

API

http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api

CRUD API

http://www.asp.net/web-api/overview/creating-web-apis/creating-a-web-api-that-supports-crud-operations

---

http://scottdesapio.com/VBScriptOAuth/

---

http://www.timacheson.com/Blog/2013/jun/asptwitter

---

http://stackoverflow.com/questions/2883444/making-a-http-request-to-api-possible-with-vb-asp-classic

```vbscript
Dim req
Set req = Server.CreateObject("MSXML2.ServerXMLHTTP")

req.open "GET", "http://blabla.com", False
req.send()

Response.Write(req.responseText)
```
