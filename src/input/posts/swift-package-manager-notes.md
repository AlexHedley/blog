---
title: Swift Package Manager Notes
tags:
    - Swift
    - guard
    - kata
author: AlexHedley
# description: 
published: 2017-01-27
---

I've been running through the excellent tutorials from [NSScreencast](http://nsscreencast.com/episodes) ([@NSScreencast](https://twitter.com/nsscreencast)) on using the swift package manager.

- [Fizz Buzz Kata](http://nsscreencast.com/episodes/245-fizz-buzz-kata)
- [Improved Guard Setup for Swift](http://nsscreencast.com/episodes/246-improved-guard-setup-for-swift)

I've ran into a couple of issues which I thought I'd share as others might also run into them and hopefully they will be of use.

Thanks to [subdigital](https://twitter.com/subdigital) for the help whilst I'm learning.

I had a couple of issues with some gems in Ruby since macOS comes shipped with a lesser version.

Setup: [https://gorails.com/setup/osx/10.12-sierra](https://gorails.com/setup/osx/10.12-sierrahttps://gorails.com/setup/osx/10.12-sierra)

Reboot once completed.

Next when I went to complete the second video in the series I'd realised I hadn't set up a great folder structure.

I had Katas then the code I'd been working with for the first FizzBuzz, this really needs it's own folder, I moved this over then made a copy for the updates to guard, should really be using source control but I haven't for now.

I tried running

```bash
bundle exec guard init
bundle exec guard
```

But got an error when I tried updating any of the code

> <unknown>:0: error: build had 1 command failures
> error: exit(1): /Applications/Xcode.app/Contents/Developer/Toolchains/XcodeDefault.xctoolchain/usr/bin/swift-build-tool -f /Users/AlexHedley/Documents/NSScreencast/Katas/FizzBuzz/.build/debug.yaml test
> Failed

I asked ben for help and he pointed me in the right direction, this wasn't an issue with ruby but with swift.

I ran

```bash
swift build
```

and got a better error to work with

> :0: error: PCH was compiled with module cache path '/Users/AlexHedley/Documents/NSScreencast/Katas/.build/debug/ModuleCache/Q3KKH3V7UU86', but the path is currently '/Users/AlexHedley/Documents/NSScreencast/Katas/FizzBuzz Updated/.build/debug/ModuleCache/Q3KKH3V7UU86'

Looking around I found that I needed to **delete the _.build_ folder**

[http://stackoverflow.com/a/410...](http://disq.us/url?url=http%3A%2F%2Fstackoverflow.com%2Fa%2F41083189%2F2895831%3A262XMoSfyhOd8GmV-82wUGbVMPY&cuid=1255790)

then I ran

```bash
swift build
bundle exec guard init
bundle exec guard
```

and everything was working.

* * *

Other things I looked at

> Command-Option-Shift-K to clean out the build folder. Even better, quit Xcode and clean out ~/Library/Developer/Xcode/DerivedData

[http://stackoverflow.com/quest...](http://disq.us/url?url=http%3A%2F%2Fstackoverflow.com%2Fquestions%2F5714372%2Fhow-to-empty-caches-and-clean-all-targets-xcode-4%2F6247073%236247073%3A2mdJ5AUyQYt6faMTXcIF41_mOSw&cuid=1255790)

Would it be worth deleting the ModuleCache folder _/Users/AlexHedley/Library/Developer/Xcode/DerivedData/ModuleCache_ [http://meandmark.com/blog/2016...](http://disq.us/url?url=http%3A%2F%2Fmeandmark.com%2Fblog%2F2016%2F04%2Fmissing-required-module-swiftshims-problem%2F%3AfsnS6odp-egrSnbwLSPTlZ7fu4c&cuid=1255790)

> Usually it can be resolved by holding down the Option key and choosing Product > Clean Build Folder...

[http://stackoverflow.com/a/154...](http://disq.us/url?url=http%3A%2F%2Fstackoverflow.com%2Fa%2F15463219%2F2895831%3Az9MqESact7R9zBRej-VN2cOgXkI&cuid=1255790) Is there a way to do this for what we are using?

* * *

Completed Tutorials

- [Fizz Buzz Kata](http://nsscreencast.com/episodes/245-fizz-buzz-kata) (8/1/17)
- [Improved Guard Setup for Swift](http://nsscreencast.com/episodes/246-improved-guard-setup-for-swift) (28/1/17)
- [Yahtzee Kata](http://nsscreencast.com/episodes/247-yahtzee-kata) (29/1/17)

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2017/01/27/swift-package-manager-notes/)
