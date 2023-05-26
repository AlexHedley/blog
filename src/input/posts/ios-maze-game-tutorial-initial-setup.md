---
title: iOS Maze Game Tutorial - Initial Setup
tags:
    - ios
    - dev
    - game
    - maze
author: AlexHedley
# description: 
published: 2015-01-25
---

So [Cartoon Smart](http://cartoonsmart.com) have released another Tutorial, this time on how to make a [Maze Game](http://cartoonsmart.com/maze-games-with-swift-and-sprite-kit-video-tutorial/) with [Swift](https://developer.apple.com/swift/) and [Sprite Kit](https://developer.apple.com/library/ios/documentation/GraphicsAnimation/Conceptual/SpriteKit_PG/Introduction/Introduction.html).

This has the ability to teach me how to make the Sokoban game I've been wanting to do for years.

I've never been able to work out how to push an object around a maze, just never sat down an properly thought about it.

I could get collision detection working with help from the [Tile Based Tutorial](http://www.raywenderlich.com/29458/how-to-make-a-tile-based-game-with-cocos2d-2-x) on [Ray Wenderlich](http://www.raywenderlich.com/).

First hurdle with this one was I stupidly didn't pick the correct **Game Technology**.

In a New Project It Defaults to **SceneKit** and we're using **SpriteKit**, although I think it remembers your last choice,

I had no GameScene.sks or GameScene.swift files which should have been my first prompt.

I made them and tried to run the app and got the following error:

> Could not instantiate class named SCNView

Quick search on google came to:

http://stackoverflow.com/questions/26576837/could-not-instantiate-class-named-scnview

Steps to fix:

Main.Storyboard Click on View Identity Inspector Class = SKView

This then worked.

My issue was is there anything else missing and would this lead to more problems further down the road.

Best start a new Project and check the correct settings.

It was a good mistake as I should learn to not do it again.

Anyway let the game development continue.

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/01/25/ios-maze-game-tutorial-initial-setup/)
