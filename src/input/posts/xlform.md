---
title: XLForm
tags:
    - iOS
    - XLForm
author: AlexHedley
# description: 
published: 2017-04-06
image: /posts/images/xl_appicon_152.png
imageattribution: https://github.com/xmartlabs/XLForm
---

> XLForm is the most flexible and powerful iOS library to create dynamic table-view forms. The goal of the library is to get the same power of hand-made forms but spending 1/10 of the time.

- https://github.com/xmartlabs/XLForm

_Image_

Add an image to the left of a form input

```objectivec
row = [XLFormRowDescriptor formRowDescriptorWithTag:@"fullname" rowType:XLFormRowDescriptorTypeText];
[row.cellConfigAtConfigure setObject:@"Full Name" forKey:@"textField.placeholder"];
[row.cellConfigAtConfigure setObject:[UIImage imageNamed:@"User"] forKey:@"imageView.image"];
[section addFormRow:row];
```

_Buttons_

```objectivec
XLFormRowDescriptor *buttonRow = [XLFormRowDescriptor formRowDescriptorWithTag:kButton rowType:XLFormRowDescriptorTypeButton title:@"A 6 digit verification code has been sent via SMS"];
[buttonRow.cellConfig setObject:[UIColor purpleColor] forKey:@"textLabel.color"];
[buttonRow.cellConfig setObject:[UIFont fontWithName:kFont size:10] forKey:@"textLabel.font"];
buttonRow.cellStyle = UITableViewCellStyleValue1;
buttonRow.value = @"Enter Code";
buttonRow.action.formSelector = @selector(didTouchButton:);
[section addFormRow:buttonRow];
```

_Screenshot_

![Register](https://alexhedley.files.wordpress.com/2017/03/register.png?w=175)

* * *

Switch

- [PredicateFormViewController](https://github.com/xmartlabs/XLForm/blob/master/Examples/Objective-C/Examples/PredicateExamples/PredicateFormViewController.m)

To turn the switch on

```objectivec
row = [XLFormRowDescriptor formRowDescriptorWithTag:@"switch" rowType:XLFormRowDescriptorTypeBooleanSwitch title:@"Boolean"];
row.value = @1;
```

* * *

Issues

I raised an issue about the Floating Label covering the Image.

- [https://github.com/xmartlabs/XLForm/issues/940](https://github.com/xmartlabs/XLForm/issues/940https://github.com/xmartlabs/XLForm/issues/940)

![Register - JVFloatLabeledTextField (2)](images/register-jvfloatlabeledtextfield-2.png)

A very quick reply to update

```objectivec
- (NSArray *)layoutConstraints
```

I added the following:

```objectivec
const static CGFloat kHMargin = 50.0f;

NSDictionary \*metrics = @{@"vMargin":@(kVMargin), @"hMargin":@(kHMargin)};

[result addObjectsFromArray:[NSLayoutConstraint constraintsWithVisualFormat:@"H:|-(hMargin)-[floatLabeledTextField]-|" options:0 metrics:metrics views:views]];
```

![Register - JVFloatLabeledTextField (4)](images/register-jvfloatlabeledtextfield-4.png)

* * *

Cell Separator

Add in 'viewDidLoad'

```objectivec
self.tableView.separatorColor = [UIColor redColor];
```

- [https://github.com/xmartlabs/XLForm/issues/943](https://github.com/xmartlabs/XLForm/issues/943)

![Register - JVFloatLabeledTextField (5)](images/register-jvfloatlabeledtextfield-5.png)

* * *

Section Background Colour

I wished to change the Header/Footer background colour.

_Code_

```objectivec
- (void)viewDidLoad {
    [[self tableView] registerClass:[UITableViewHeaderFooterView class] forHeaderFooterViewReuseIdentifier:@"headerFooterReuseIdentifier"];
}
```

**Header**

```objectivec
-(UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section {
    UITableViewHeaderFooterView *headerFooterView = [[self tableView] dequeueReusableHeaderFooterViewWithIdentifier:@"headerFooterReuseIdentifier"];
    headerFooterView.contentView.backgroundColor = kBackgroundColor;

    return headerFooterView;
}
```

**Footer**

```objectivec
-(UIView *)tableView:(UITableView *)tableView viewForFooterInSection:(NSInteger)section {
    UITableViewHeaderFooterView *headerFooterView = [[self tableView] dequeueReusableHeaderFooterViewWithIdentifier:@"headerFooterReuseIdentifier"];
    headerFooterView.contentView.backgroundColor = kBackgroundColor;

    return headerFooterView;
}
```

- http://stackoverflow.com/questions/43180133/custom-xlform-section-background-color/43232745#43232745
- https://github.com/xmartlabs/XLForm/issues/335

* * *

FloatLabeledTextFieldCell

- [Github](https://github.com/xmartlabs/XLForm/tree/master/Examples/Objective-C/Examples/CustomRows/FloatLabeledTextField)

**Floating Label**

There is a property on the TextField you can set to change the colour of the Floating Label

- floatingLabelActiveTextColor

```objectivec
[row.cellConfig setObject:[UIColor redColor] forKey:@"floatLabeledTextField.floatingLabelActiveTextColor"];
```

**TextField**

If you want to change the TextField text colour:

```objectivec
[row.cellConfig setObject:[UIColor whiteColor] forKey:@"floatLabeledTextField.textColor"];
```

![Register - JVFloatLabeledTextField (5)](images/register-jvfloatlabeledtextfield-5.png)

Didn't change anything:

```objectivec
[row.cellConfig setObject:[UIColor greenColor] forKey:@"textLabel.highlightedTextColor"];
```

Or

```objectivec
[row.cellConfig setObject:[UIColor redColor] forKey:@"floatLabeledTextField.floatingLabel.textColor"];
```

**Image**

Set the "imageView.tintColor"

```objectivec
[row.cellConfigAtConfigure setObject:[UIColor whiteColor] forKey:@"imageView.tintColor"];
```

![Register - JVFloatLabeledTextField (6)](images/register-jvfloatlabeledtextfield-6.png)

* * *

Accessory

- [https://github.com/xmartlabs/XLForm#how-to-change-input-accessory-view-navigation-view](https://github.com/xmartlabs/XLForm#how-to-change-input-accessory-view-navigation-view)

```objectivec
- (UIView *)inputAccessoryViewForRowDescriptor:(XLFormRowDescriptor *)rowDescriptor
{
      return nil; //will hide it completely
      // You can use the rowDescriptor parameter to hide/customize the accessory view for a particular rowDescriptor type.
}
```
 

Without reading the documentation!!

Adding a Checkmark

```objectivec
XLFormRowDescriptor *row = [XLFormRowDescriptor formRowDescriptorWithTag:@"Check" rowType:XLFormRowDescriptorTypeBooleanCheck title:NSLocalizedString(@"Check", nil)];
[newSection addFormRow:row];
```

Swap to a different image

```objectivec
UIImageView *imageView = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"Circle"]];
imageView.tintColor = [UIColor redColor];
[row.cellConfig setObject:imageView forKey:@"accessoryView"];
```

Now to handle the toggling...

This method isn't being called.

```objectivec
- (void)tableView:(UITableView *)tableView accessoryButtonTappedForRowWithIndexPath:(NSIndexPath *)indexPath {
    NSLog(@"Tapped");
}
```

* * *

Dynamically Adding Rows

I'm using segues to move between views.

I'm setting a property - an array of items in the 'prepareForSegue'.

But 'initWithCoder' doesn't have these values set yet.

'viewDidLoad' does so call a method there.

Create your Form, Section(s) and Row(s) in the interface and use them:

```objectivec
[section addFormRow:row beforeRow:buttonRow];
```

* * *

Selected Row Label colour

- [https://github.com/xmartlabs/XLForm/issues/574](https://github.com/xmartlabs/XLForm/issues/574)

Tried a couple of options:

```objectivec
[row.cellConfig setObject:[UIColor redColor] forKey:@"textLabel.highlightedTextColor"];
```

And

```objectivec
[row.cellConfig setObject:[UIColor redColor] forKey:@"textLabel.tintColor"];
```

* * *

Change the cursor colour

- **textField.tintColor**

```objectivec
[row.cellConfig setObject:[UIColor greenColor] forKey:@"textField.tintColor"];
```

![Register - JVFloatLabeledTextField (7)](images/register-jvfloatlabeledtextfield-7.png)

* * *

* * *

Alternatives

- [https://github.com/nicklockwood/FXForms](https://github.com/nicklockwood/FXForms)
- [https://github.com/hyperoslo/Form](https://github.com/hyperoslo/Form)

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2017/04/06/xlform/)
