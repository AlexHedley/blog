---
title: TVML tvOS 10
tags:
    - tvOS
    - 10
    - tvml
    - tvmljs
author: AlexHedley
# description: 
published: 2016-06-18
---

So there's an updated TVML Catalog sample code project out.

Instead of having js files that make an XML file, it's just a straight XML file now. Makes much more sense to me to have it this way.

TVML Catalog: Using TVML Templates

[https://developer.apple.com/library/prerelease/content/samplecode/TVMLCatalog/Introduction/Intro.html#//apple\_ref/doc/uid/TP40016505-Intro-DontLinkElementID\_2](https://developer.apple.com/library/prerelease/content/samplecode/TVMLCatalog/Introduction/Intro.html#//apple_ref/doc/uid/TP40016505-Intro-DontLinkElementID_2)

Another thing they've changed is they suggest using Ruby instead of Python.

`ruby -run -ehttpd . -p9001`

I think this might  be to get around the fact videos locally didn't work with Python, I still need to test this.

In most of my previous files I was using template=".xml.js" whereas now they use documentURL=".xml" so one to check on.

I've also amended a couple of files to get video playback working, the documentcontroller.js was the place to add it.

[gist 1f510cc84ce9968642383aa62b621643]

`Catalog.xml`

```xml
<listItemLockup videoURL="">
  <ordinal minLength="2" class="ordinalLayout">0</ordinal>
  <title>Introduction</title>
  <subtitle>0</subtitle>
  <decorationLabel>(9:58)</decorationLabel>
</listItemLockup>
```

`DocumentController.js`

```javascript
class DocumentController {
...
    setupDocument(document) {
        document.addEventListener("select", this.handleEvent);
        document.addEventListener("play", this.handleEvent);
    }
...
    handleEvent(event) {
        const target = event.target;
        ...
        const videoURL = target.getAttribute("videoURL");
        ...
        } else if (videoURL) {
            var player = new Player();
            var playlist = new Playlist();
            var mediaItem = new MediaItem("video", videoURL);

            player.playlist = playlist;
            player.playlist.push(mediaItem);
            player.play();
        }
    }
}
```

A useful dub dub video to watch is the following.

WWDC 212 - Developing tvOS Apps Using TVMLKit: Part 1

([https://developer.apple.com/videos/play/wwdc2016/212/](https://developer.apple.com/videos/play/wwdc2016/212/))

The video/slides do cover a basic example:

[http://devstreaming.apple.com/videos/wwdc/2016/212s41rh77qgdg26s86/212/212\_developing\_tvos\_apps\_using\_tvmlkit\_part\_1.pdf](http://devstreaming.apple.com/videos/wwdc/2016/212s41rh77qgdg26s86/212/212_developing_tvos_apps_using_tvmlkit_part_1.pdf)

```javascript
// Setting up a TVMLKit JS Video Player

var video = new MediaItem('video', '[https://example.com/video.m3u8](https://example.com/video.m3u8)');

video.title = 'My Great Movie';

video.description = 'An extensive description...';

video.resumeTime = 10.0; // seconds

var playlist = new Playlist();

playlist.push(video);

var player = new Player();

player.playlist = playlist;

player.play(); // Present the player
```

The AudioVideo sample code hasn't been updated yet and there isn't an example of video playback in the above Catalog sample, the WWDC video was handy though. I like the embedded player in a lockup.

TVMLAudioVideo: Audio and Video Playback on tvOS

[https://developer.apple.com/library/tvos/samplecode/TVMLAudioVideo/Introduction/Intro.html#//apple\_ref/doc/uid/TP40016506](https://developer.apple.com/library/tvos/samplecode/TVMLAudioVideo/Introduction/Intro.html#//apple_ref/doc/uid/TP40016506)

Check out the new MediaContent docs:

MediaContent

[https://developer.apple.com/library/prerelease/content/documentation/LanguagesUtilities/Conceptual/ATV\_Template\_Guide/CompoundMultimediaElements.html#//apple\_ref/doc/uid/TP40015064-CH46-SW2](https://developer.apple.com/library/prerelease/content/documentation/LanguagesUtilities/Conceptual/ATV_Template_Guide/CompoundMultimediaElements.html#//apple_ref/doc/uid/TP40015064-CH46-SW2https://developer.apple.com/library/prerelease/content/documentation/LanguagesUtilities/Conceptual/ATV_Template_Guide/CompoundMultimediaElements.html#//apple_ref/doc/uid/TP40015064-CH46-SW2)

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2016/06/18/tvml-tvos-10/)
