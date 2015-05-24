---
title: Adding A Settings Bundle
tags:
    - iOS
author: AlexHedley
# description: 
published: 2015-05-24
---

I'd like to add a Settings section to my app to show Licenses and other info.

Maybe put the Options section there too.

https://codehappily.wordpress.com/2014/03/18/ios-how-to-create-an-ios-settings-entry-for-your-app-using-settings-bundle/

http://stackoverflow.com/questions/6428353/best-way-to-add-license-section-to-ios-settings-bundle/6453507#6453507

[gist 5830083ef0625204a016 /]

`license.pl`

```perl
#!/usr/bin/perl -w

use strict;

my $out = "../Settings.bundle/en.lproj/Acknowledgements.strings";
my $plistout =  "../Settings.bundle/Acknowledgements.plist";

unlink $out;

open(my $outfh, '>', $out) or die $!;
open(my $plistfh, '>', $plistout) or die $!;

print $plistfh <<'EOD';
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
        <key>StringsTable</key>
        <string>Acknowledgements</string>
        <key>PreferenceSpecifiers</key>
        <array>
EOD
for my $i (sort glob("*.license"))
{
    my $value=`cat $i`;
    $value =~ s/\r//g;
    $value =~ s/\n/\r/g;
    $value =~ s/[ \t]+\r/\r/g;
    $value =~ s/\"/\'/g;
    my $key=$i;
    $key =~ s/\.license$//;

    my $cnt = 1;
    my $keynum = $key;
    for my $str (split /\r\r/, $value)
    {
        print $plistfh <<"EOD";
                <dict>
                        <key>Type</key>
                        <string>PSGroupSpecifier</string>
                        <key>Title</key>
                        <string>$keynum</string>
                </dict>
EOD

        print $outfh "\"$keynum\" = \"$str\";\n";
        $keynum = $key.(++$cnt);
    }
}

print $plistfh <<'EOD';
        </array>
</dict>
</plist>
EOD
close($outfh);
close($plistfh);
```

Run a perl script:

`perl <scriptname.pl>`

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2015/05/24/adding-a-settings-bundle/)
