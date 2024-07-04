---
title: JSQMessagesViewController - Messages UI
# lead:
tags:
  - iOS
  - objc
author: AlexHedley
# description:
published: 2018-02-03
image: /posts/images/jsq_messages_banner.png
imageattribution: https://github.com/jessesquires/JSQMessagesViewController
---

On the app I'm currently working on I've got a messaging portion.

Originally I implemented a basic TableView with a TextField to add a message.

Then I searched for Messages UI frameworks and came across **JSQMessagesViewController**

- [http://www.jessesquires.com/JSQMessagesViewController/](http://www.jessesquires.com/JSQMessagesViewController/)
- [https://github.com/jessesquires/JSQMessagesViewController](https://github.com/jessesquires/JSQMessagesViewController)

There's a Sample project you can look into - JSQMessagesDemo.

It comes as a Cocoapod:

- [https://cocoapods.org/pods/JSQMessagesViewController](https://cocoapods.org/pods/JSQMessagesViewController)

I'm using 7.3.4.

---

Create a new Xcode project.

Open terminal at that folder

`pod init`

add

`pod 'JSQMessagesViewController'`

then

`pod install`

Open the Xcode '#App.xcworkspace'

Create a View Controller that inherits

`: JSQMessagesViewController<UIActionSheetDelegate, JSQMessagesComposerTextViewPasteDelegate>`

`#import <JSQMessagesViewController/JSQMessagesViewController.h>`

`#import "DemoData.h"`

`@class MessageViewController;`

`@protocol MessageViewControllerDelegate <NSObject>`

`- (void)didDismissMessagesViewController:(MessageViewController *)vc;`

`@end`

Add some properties and methods

`@property (weak, nonatomic) id<MessageViewControllerDelegate> delegateModal;`

`@property (strong, nonatomic) DemoData *data;`

`- (void)receiveMessagePressed:(UIBarButtonItem *)sender;`

`- (void)closePressed:(UIBarButtonItem *)sender;`

I didn't bother with any of the settings so commented these checks out.

---

I couldn't find the Accessory Button Delegate to add to my View Controller.

`#import "JSQMessagesViewAccessoryButtonDelegate.h"`

`<JSQMessagesViewAccessoryButtonDelegate>`

---

For testing create a new class for your demo data.

**DemoData.h**

`@interface DemoData : NSObject`

`@property (strong, nonatomic) NSMutableArray *messages;`

`@property (strong, nonatomic) NSDictionary *users;`

`@property (strong, nonatomic) JSQMessagesBubbleImage *outgoingBubbleImageData;`

`@property (strong, nonatomic) JSQMessagesBubbleImage *incomingBubbleImageData;`

@end

---

**DemoData.m**

Create some test Users.

```objectivec
- (instancetype)init
{
    self = [super init];
    if (self) {  
        [self loadFakeMessages];

        self.users = @{ @"1" : @"Alex",
                        @"2" : @"Sam",
                        @"3" : @"Kev",
                        @"4" : @"Ray" };

        JSQMessagesBubbleImageFactory *bubbleFactory = [[JSQMessagesBubbleImageFactory alloc] init];       
        self.outgoingBubbleImageData = [bubbleFactory outgoingMessagesBubbleImageWithColor:[UIColor jsq_messageBubbleLightGrayColor]];
        self.incomingBubbleImageData = [bubbleFactory incomingMessagesBubbleImageWithColor:[UIColor jsq_messageBubbleGreenColor]];
    }
    return self;
}
```

Create the Fake Messages

`- (void)loadFakeMessages { ... }`

We can use this back in our `MessageViewController.m`

`#pragma mark - View lifecycle`

- `viewDidLoad`
- `viewWillAppear`
- `viewDidAppear`

Since I'm not using Avatars add this to `viewDidLoad`

`self.collectionView.collectionViewLayout.incomingAvatarViewSize = CGSizeZero; self.collectionView.collectionViewLayout.outgoingAvatarViewSize = CGSizeZero;`

Also return nil in 'avatarImageDataForItemAtIndexPath'

```objectivec
- (id<JSQMessageAvatarImageDataSource>)collectionView:(JSQMessagesCollectionView \*)collectionView avatarImageDataForItemAtIndexPath:(NSIndexPath \*)indexPath {
    ...
    return nil;
}
```

Implement these other methods.

`#pragma mark - Custom menu actions for cells`

`#pragma mark - Actions`

`#pragma mark - JSQMessagesViewController method overrides`

`#pragma mark - JSQMessages CollectionView DataSource`

Choose a user here

- `senderId`
- `senderId`

`#pragma mark - UICollectionView DataSource`

`#pragma mark - UICollectionView Delegate`

`#pragma mark - Custom menu items`

`#pragma mark - JSQMessages collection view flow layout delegate`

`#pragma mark - Adjusting cell label heights`

`#pragma mark - Responding to collection view tap events`

`#pragma mark - JSQMessagesComposerTextViewPasteDelegate methods`

`#pragma mark - JSQMessagesViewAccessoryDelegate methods`

---

Changing some settings

I didn't want the Add Attachments button.

`viewDidLoad`

`self.inputToolbar.contentView.leftBarButtonItem = nil;`

- [https://github.com/jessesquires/JSQMessagesViewController/issues/338](https://github.com/jessesquires/JSQMessagesViewController/issues/338)
- [https://github.com/jessesquires/JSQMessagesViewController/issues/280](https://github.com/jessesquires/JSQMessagesViewController/issues/280)

---

Now just to swap out the messages to my XMPP Server...

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2018/02/03/jsqmessagesviewcontroller-messages-ui/)
