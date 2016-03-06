---
title: Movem iOS game
tags:
    - iOS
    - movem
    - game
author: AlexHedley
# description: 
published: 2016-03-06
---

So I found an implementation of an iOS Sokoban game

https://github.com/kennycason/swift_boxxle

It's a year old so my first step was to update it.

I ran the Xcode updater then got to the left over errors.

```swift
@nonobjc var isPaused: Bool = false
```

Touches Began

```swift
override func touchesBegan(touches: Set<UITouch>?, withEvent event: UIEvent?)

let touch = touches!.first
```

CheckForWin

```swift
func checkForWin()

if ~isBoxOnGoal(box)

if !isBoxOnGoal(box)
```

I swapped out some images

Then i wanted to tile a background sprite

I found http://www.spritekitlessons.com/tile-a-background-image-with-sprite-kit/ then I converted it

[gist id=b5e6ad227d988fe61327 file=TileSprite2.swift /]

`TileSprite2.swift`

```swift
func createBackgroundTiled() {
  //var coverageSize: CGSize = CGSizeMake(2000, 2000)
  var coverageSize: CGSize = CGSizeMake(self.size.width, self.size.height)
  var textureSize: CGRect = CGRectMake(0, 0, 32, 32)
  var backgroundCGImage: CGImageRef = UIImage(named: "Background")!.CGImage!
  UIGraphicsBeginImageContext(CGSizeMake(coverageSize.width, coverageSize.height))
  var context: CGContextRef = UIGraphicsGetCurrentContext()!
  CGContextDrawTiledImage(context, textureSize, backgroundCGImage)
  var tiledBackground: UIImage = UIGraphicsGetImageFromCurrentImageContext()
  UIGraphicsEndImageContext()
  //var backgroundTexture: SKTexture = SKTexture.textureWithCGImage(tiledBackground.CGImage!)
  let backgroundTexture = SKTexture(CGImage: tiledBackground.CGImage!)
  //var backgroundTiles: SKSpriteNode = SKSpriteNode.spriteNodeWithTexture(backgroundTexture)
  var backgroundTiles: SKSpriteNode = SKSpriteNode(texture: backgroundTexture)
  backgroundTiles.yScale = -1
  backgroundTiles.position = CGPointMake(0, 0)
  
  backgroundTiles.zPosition = -1
  backgroundTiles.position = CGPointMake(self.size.width/2, self.size.height/2)
  
  self.addChild(backgroundTiles)
}
```

padNumber

```swift
let digits = countElements(String(number))

let digits = String(number).characters.count
```

Links

https://alexhedley.wordpress.com/2011/06/14/rw-beginning-iphone-programming-finished/

https://alexhedley.wordpress.com/2015/01/25/ios-maze-game-tutorial-initial-setup/

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2016/03/06/movem-ios-game/)
