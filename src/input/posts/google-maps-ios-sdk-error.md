---
title: Google Maps iOS SDK - Error
tags:
    - iOS
    - googlemaps
author: AlexHedley
# description: 
published: 2017-01-09
---

Google Maps iOS SDK

[https://developers.google.com/maps/documentation/ios-sdk/start](https://developers.google.com/maps/documentation/ios-sdk/start)

Followed the setup instructions using Cocoa Pods.

- GoogleMaps (2.1.1)
- GooglePlaces (2.1.1)

Built the Project and got the following error:

> Module 'GoogleMapsBase' not found

Added the following in:

> Target -> Build Setting -> Search Path-> Framework Search Paths

Add the following (+)

_Framework Search Paths_

> "${PODS_ROOT}/GoogleMaps/Maps/Frameworks"
> "${PODS_ROOT}/GoogleMaps/Base/Frameworks"

Build and Run.

* * *

Helpful Links

- [https://github.com/googlemaps/google-maps-ios-utils/issues/19](https://github.com/googlemaps/google-maps-ios-utils/issues/19)
- [https://github.com/googlemaps/google-maps-ios-utils/pull/20](https://github.com/googlemaps/google-maps-ios-utils/pull/20)
- [https://code.google.com/p/gmaps-api-issues/issues/detail?id=10190](https://code.google.com/p/gmaps-api-issues/issues/detail?id=10190)
- [http://stackoverflow.com/questions/19130629/framework-not-found-googlemaps-sdk-in-ios/19946503#19946503](http://stackoverflow.com/questions/19130629/framework-not-found-googlemaps-sdk-in-ios/19946503#19946503)

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2017/01/09/google-maps-ios-sdk-error/)
