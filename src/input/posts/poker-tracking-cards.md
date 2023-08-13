---
title: Poker - Tracking cards
tags:
  - poker
  - rfid
  - nfc
  - NTAG215
  - ISO15693
author: alexhedley
description: How to know what cards are currently in play.
published: 2023-08-11
# image: /posts/images/###.png
# imageattribution:
---

This is Part 2 of the Poker series, see [Recording Poker Games](/posts/recording-poker-games) for the initial setup.

What would be the best way to track the cards being played?

I could train a machine learning model or use an existing one? See [Playing-Cards-Computer-Vision](https://github.com/awrd2019/Playing-Cards-Computer-Vision) from [@awrd2019](https://github.com/awrd2019/). Not sure how much work this would be and how accurate the results are.

The next idea was RFID Playing cards, I got a link for [Luna NFC/RFID Cards by Andras Barthazi](https://www.saturnmagic.co.uk/saturn-magic-shop/luna-nfcrfid-cards-by-andras-barthazi.html) and thought £21.99 for a pack isn't bad, but I'd miss read:

- Blank face (6 cards): £21.99
- Poker face (52 + 2 cards): £104.99
- Blank face (54 cards): £104.99

Checking other sites I found one a little cheaper in [RFID PLAYING CARD DECK, ISO15693](https://illuminati-magic.com/products/rfid-deck-iso15693) £93.00 GBP.

So why don't I just buy some NFC / RFID stickers and put them on an existing pack of playing cards?
It might make them harder to shuffle and easier to see a marked card but for an inital POC it'll be cheaper.

> 50pcs NFC Tags, BetterJonny NFC Cards, NFC Stickers Ntag 215 NFC Tag NFC Coin Cards Compatible with TagMo & Amiibo, NFC Enabled Mobile Phones and Devices, Round, White

- https://www.amazon.co.uk/gp/product/B0C786FJ82/

Only £8.99 for 50, that's much better, albeit I need 52 and I'll have to stick them all on and program them all, but that's the fun part!

![NTAG215](images/poker/NTAG215.jpg "NTAG215")

Next I need a reader/writer, which I'm sure I saw in the [ADVENTURE KIT 2](https://inventr.io/product/adventure-kit-2-pre-order/) $197.00 I'd bought.

> 1x RFID reader and Keychain
> 
> Create your own unique ID card and be able to read the data from it. Allowing just those with access keys in.

![MFRC522](images/poker/ar054-rfid-mfrc522.png "MFRC522")

There's a video and board layout on the course:

- https://inventr.io/lessons/nfc-badges/
- https://inventr.io/lessons/rfid-reader-badge/

Next problem is I'll need a board to connect to them, so that then adds more wires, there doesn't seem to be a nice compact way like with the camera.

I also need to test what the pickup area is, will I only need one per pocket? Will The Board only need one too? Once I've tested I'll feed back with the results.

I can then create a local API that I can post the cards too, which in turn will update the screen.

![Hole Cards](images/poker/HoleCards.png "Hole Cards")

Having access to what cards are available I can also calculate rudimentary pot odds. Add them to the screen too.

The actual pot will be harder - mic with voice recognition? Weigh the table? RFID on each chip? Let's solve one problem at a time.

All this hardware setup it starting to get messy, my thoughts here are to create my own custom table, I can then hide all the parts in custom fitting areas. If the wood is thin enough the devices should be able to pick up the cards. Plus then I have an excuse to do some woodwork :).
