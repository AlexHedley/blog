---
title: MapKit
# lead:
tags:
  - iOS
  - objc
  - MapKit
author: AlexHedley
# description:
published: 2018-02-03
image: /posts/images/maps_ios-128x128_2x.png
imageattribution: https://www.apple.com/uk/maps/
---

So I've been learning [MapKit](https://developer.apple.com/maps/) this week.

- [Developer](https://developer.apple.com/reference/mapkit)

It's been a fun new framework to look into.

Create an Annotation so you can have custom properties.

```objectivec
@interface Annotation : NSObject<MKAnnotation>
```

Add a category to it so you have a way of telling what it is.

This could be an enum.

In the Delegate method

```objectivec
- (MKAnnotationView *)mapView:(MKMapView *)theMapView viewForAnnotation:(id <MKAnnotation>)annotation
```

You can use the category to set up some properties like a button and the pin colour.

I'm wondering if the "reuseIdentifier" should be unique here too?

You've added a button, now how to call it?

You could add a target and action

```objectivec
[rightButton addTarget:## action:## forControlEvents:UIControlEventTouchUpInside];
```

but instead you can use the "calloutAccessoryControlTapped" delegate method.

```objectivec
- (void)mapView:(MKMapView *)mapView annotationView:(MKAnnotationView *)view calloutAccessoryControlTapped:(UIControl *)control
```

As this isn't a  "MKAnnotation" like "viewForAnnotation" but an "MKAnnotationView" we need to get the annotation from the passed view.

```objectivec
if ([view.annotation isKindOfClass:[OotAnnotation class]]) { ... }
```

Then call pfs,

Then in the "prepareForSegue" you need to get the Annotation when you click on a Pin button, this can be cast from the Sender

```objectivec
if ([view.annotation isKindOfClass:[OotAnnotation class]]) { ... }
```

```objectivec
Annotation \*annotation = (Annotation *)[(MKAnnotationView *)sender annotation];
```

You could then pass your custom Location details via the ViewController. (See code)

---

Searching for locations to add to the map:

MKLocalSearchRequest

---

Adding a route, need to investigate this more.

MKPolyline

---

All Code

[gist 6ac1c60428f6e13692f7f3f11d931f0e]

<?# Gist 6ac1c60428f6e13692f7f3f11d931f0e /?>

`Annotation.h`

```objectivec
#import <UIKit/UIKit.h>
#import <Foundation/Foundation.h>
#import <MapKit/MapKit.h>
#import "Location.h"

@interface OotAnnotation : NSObject<MKAnnotation> {
    CLLocationCoordinate2D  coordinate;
    NSString *title;
    NSString *subtitle;
    NSInteger categoryID;
}

@property (nonatomic, assign) CLLocationCoordinate2D coordinate;
@property (nonatomic, copy) NSString *title;
@property (nonatomic, copy) NSString *subtitle;
@property NSInteger categoryID;
@property (nonatomic, strong) Location *locationDetails;

typedef NS_ENUM(NSInteger, Category) {
    PinCategoryPlace,
    PinCategoryUser,
    PinCategoryPub,
    PinCategoryNightclub,
    PinCategoryFood
};

@end
```

`Annotation.m`

```objectivec
#import "Annotation.h"

@implementation OotAnnotation

@end
```

`Location.h`

```objectivec
#import <Foundation/Foundation.h>

@interface Location : NSObject

@property (nonatomic, strong) NSString *locationName;
@property double locationRating;
@property NSInteger locationNumOfReviews;
@property (nonatomic, strong) NSString *locationDetails;
@property (nonatomic, strong) NSString *locationImageUrl;
@property (nonatomic, strong) NSString *locationEmail;
@property (nonatomic, strong) NSString *locationPhone;
@property (nonatomic, strong) NSString *locationRouteDetails;
@property (nonatomic, strong) NSString *locationNotes;
@property (nonatomic, strong) NSString *locationDeal;

- (id)initWithName:(NSString *)name rating:(double)rating numOfReviews:(NSInteger)numOfReviews details:(NSString *)details imageUrl:(NSString *)imageUrl email:(NSString *)email phone:(NSString *)phone routeDetails:(NSString *)routeDetails notes:(NSString *)notes deal:(NSString *)deal;

+ (id)locationWithName:(NSString *)name rating:(double)rating numOfReviews:(NSInteger)numOfReviews details:(NSString *)details imageUrl:(NSString *)imageUrl email:(NSString *)email phone:(NSString *)phone routeDetails:(NSString *)routeDetails notes:(NSString *)notes deal:(NSString *)deal;

@end
```

`Location.m`

```objectivec
#import "Location.h"

@implementation Location

- (id)initWithName:(NSString *)name rating:(double)rating numOfReviews:(NSInteger)numOfReviews details:(NSString *)details imageUrl:(NSString *)imageUrl email:(NSString *)email phone:(NSString *)phone routeDetails:(NSString *)routeDetails notes:(NSString *)notes deal:(NSString *)deal {
    self = [super init];

    if (self) {
        self.locationName = name;
        self.locationRating = rating;
        self.locationNumOfReviews = numOfReviews;
        self.locationDetails = details;
        self.locationImageUrl = imageUrl;
        self.locationEmail = email;
        self.locationPhone = phone;
        self.locationRouteDetails = routeDetails;
        self.locationNotes = notes;
        self.locationDeal = deal;
    }
    return self;
}

+ (id)locationWithName:(NSString *)name rating:(double)rating numOfReviews:(NSInteger)numOfReviews details:(NSString *)details imageUrl:(NSString *)imageUrl email:(NSString *)email phone:(NSString *)phone routeDetails:(NSString *)routeDetails notes:(NSString *)notes deal:(NSString *)deal {
    return [[self alloc] initWithName:name rating:rating numOfReviews:numOfReviews details:details imageUrl:imageUrl email:email phone:phone routeDetails:routeDetails notes:notes deal:deal];
}

@end
```

`MapViewController.h`

```objectivec
#import <UIKit/UIKit.h>
#import <MapKit/MapKit.h>
#import <MapKit/MKAnnotation.h>
#import <AddressBook/AddressBook.h>
#import <Contacts/Contacts.h>

@interface MapViewController : UIViewController <MKMapViewDelegate,  CLLocationManagerDelegate>

@property (nonatomic, strong) IBOutlet MKMapView *mapView;
@property (nonatomic, retain) CLLocationManager *locationManager;

@property (nonatomic, retain) MKPolyline *routeLine;
@property (nonatomic, retain) MKPolylineView *routeLineView;

@end
```

`MapViewController.m`

```objectivec
#import "MapViewController.h"
#import "Annotation.h"
#import "LocationViewController.h"

@interface MapViewController ()

@end

@implementation MapViewController

#pragma mark - View Methods

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    self.mapView.delegate = self;

    self.locationManager = [[CLLocationManager alloc] init];
    self.locationManager.delegate = self;
    #ifdef __IPHONE_8_0
    if(IS_OS_8_OR_LATER) {
        // Use one or the other, not both. Depending on what you put in info.plist
        [self.locationManager requestWhenInUseAuthorization];
        [self.locationManager requestAlwaysAuthorization];
    }
    #endif
    [self.locationManager startUpdatingLocation];

    _mapView.showsUserLocation = YES;
    [_mapView setMapType:MKMapTypeStandard];
    [_mapView setZoomEnabled:YES];
    [_mapView setScrollEnabled:YES];
}

-(void)viewDidAppear:(BOOL)animated {
    [super viewDidAppear:YES];

    self.locationManager.distanceFilter = kCLDistanceFilterNone;
    self.locationManager.desiredAccuracy = kCLLocationAccuracyBest;
    [self.locationManager startUpdatingLocation];
    NSLog(@"%@", [self deviceLocation]);

    //View Area
    MKCoordinateRegion region = { { 0.0, 0.0 }, { 0.0, 0.0 } };
    region.center.latitude = self.locationManager.location.coordinate.latitude;
    region.center.longitude = self.locationManager.location.coordinate.longitude;
    region.span.longitudeDelta = 0.005f;
    region.span.longitudeDelta = 0.005f;
    [_mapView setRegion:region animated:YES];

    //[self addLocation:@"Protirus" subTitle:@"Office" lat:54.969617 lon:-1.618393];
    //[self addLocation:@"Town Wall" subTitle:@"Gastropub" lat:54.9694 lon:-1.6184]; //54.9694° N, 1.6184° W

    Location *locationDetails = [Location locationWithName:@"Town Wall" rating:4.2 numOfReviews:73 details:@"Gastropub" imageUrl:@"TheTownWall" email:@"hayley@thetownwall.com" phone:@"01912323000" routeDetails:@"Town Wall - 5 minutes away - marked" notes:@"Plan to stay for an hour perhaps" deal:@"DEAL - 2 for 1 Drinks"];

    [self addPinWithTitle:@"Protirus" subTitle:@"Office" lat:54.969617 lon:-1.618393 category:PinCategoryPlace locationDetails:nil];
    [self addPinWithTitle:@"Town Wall" subTitle:@"Gastropub" lat:54.9694 lon:-1.6184 category:PinCategoryPub locationDetails:locationDetails];

    CLLocationCoordinate2D coordinateArray[2];
    coordinateArray[0] = CLLocationCoordinate2DMake(54.969617, -1.618393);
    coordinateArray[1] = CLLocationCoordinate2DMake(54.9694, -1.6184);
    [self addRoute:coordinateArray];

    [self addFood];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

#pragma mark - Locations

// http://stackoverflow.com/a/27164326
- (void)addPinWithTitle:(NSString *)title subTitle:(NSString *)subTitle lat:(double)lat lon:(double)lon category:(int)category locationDetails:(OotLocation *)locationDetails {
    CLLocationCoordinate2D coordinates = CLLocationCoordinate2DMake(lat, lon);
    Annotation *annotation = [[Annotation alloc] init];
    annotation.coordinate = coordinates;
    annotation.title = title;
    annotation.subtitle = subTitle;
    annotation.categoryID = category;
    annotation.locationDetails = locationDetails;

    [self.mapView addAnnotation:annotation];
}

// http://stackoverflow.com/a/14951825
- (void)addFood {
    MKLocalSearchRequest *request = [[MKLocalSearchRequest alloc] init];
    request.naturalLanguageQuery = @"Restaurants";
    request.region = self.mapView.region;

    MKLocalSearch *localSearch = [[MKLocalSearch alloc] initWithRequest:request];
    [localSearch startWithCompletionHandler:^(MKLocalSearchResponse *response, NSError *error) {

        NSMutableArray *annotations = [NSMutableArray array];

        [response.mapItems enumerateObjectsUsingBlock:^(MKMapItem *item, NSUInteger idx, BOOL *stop) {
            Annotation *annotation = [[Annotation alloc] init];
            annotation.coordinate = item.placemark.location.coordinate;
            annotation.title = item.name;
            annotation.subtitle = item.placemark.addressDictionary[@"Street"]; //item.placemark.thoroughfare;
                //item.placemark.addressDictionary[CNMutablePostalAddress.street]; // kABPersonAddressStreetKey]; //item.phoneNumber;
            annotation.categoryID = PinCategoryFood;
            annotation.locationDetails = nil;

            [annotations addObject:annotation];
        }];

        [self.mapView addAnnotations:annotations];
    }];
}

// http://stackoverflow.com/a/10598646
- (void)addRoute:(CLLocationCoordinate2D [])coordinateArray {
    self.routeLine = [MKPolyline polylineWithCoordinates:coordinateArray count:2];
    [self.mapView setVisibleMapRect:[self.routeLine boundingMapRect]]; //If you want the route to be visible

    [self.mapView addOverlay:self.routeLine];
}

#pragma mark - Helper Methods

- (NSString *)deviceLocation {
    return [NSString stringWithFormat:@"latitude: %f longitude: %f", self.locationManager.location.coordinate.latitude, self.locationManager.location.coordinate.longitude];
}

#pragma mark - Segue

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    if ([[segue identifier] isEqualToString:@"showLocation"]) {
        //LocationViewController *lvc = (LocationViewController *)[segue destinationViewController];
        UINavigationController *navController = [segue destinationViewController];
        LocationViewController *lvc = (LocationViewController *)([navController viewControllers][0]);

        //http://stackoverflow.com/a/25483130
        Annotation *annotation = (Annotation *)[(MKAnnotationView *)sender annotation];
        lvc.location = annotation.locationDetails;
    }
}

#pragma mark - MapView Delegate

//https://developer.apple.com/library/content/documentation/UserExperience/Conceptual/LocationAwarenessPG/AnnotatingMaps/AnnotatingMaps.html#//apple_ref/doc/uid/TP40009497-CH6-SW1
- (MKAnnotationView *)mapView:(MKMapView *)theMapView viewForAnnotation:(id <MKAnnotation>)annotation {
    // Try to dequeue an existing pin view first (code not shown).

    // If no pin view already exists, create a new one.
    MKPinAnnotationView *customPinView = [[MKPinAnnotationView alloc] initWithAnnotation:annotation reuseIdentifier:@"anything"];
    customPinView.pinColor = MKPinAnnotationColorPurple;
    customPinView.animatesDrop = YES;
    customPinView.canShowCallout = YES;

    // Because this is an iOS app, add the detail disclosure button to display details about the annotation in another view.
    UIButton *rightButton = [UIButton buttonWithType:UIButtonTypeDetailDisclosure];
    //[rightButton addTarget:nil action:nil forControlEvents:UIControlEventTouchUpInside];
    //customPinView.rightCalloutAccessoryView = rightButton;

    NSString* imageName = @"Pin";

    if ([annotation isKindOfClass:[Annotation class]]) {
        long categoryId = [(Annotation *)annotation categoryID];

        switch (categoryId) {
            case PinCategoryUser:
                imageName = @"User";
                //customPinView.pinTintColor = MKPinAnnotationColorRed;
                break;
            case PinCategoryPub:
                imageName = @"Beer";
                customPinView.pinTintColor = [UIColor orangeColor];
                customPinView.rightCalloutAccessoryView = rightButton;
                break;
            case PinCategoryNightclub:
                imageName = @"Nightclub";
                //customPinView.pinTintColor = MKPinAnnotationColorPurple;
                break;
            case PinCategoryFood:
                imageName = @"Food";
                //customPinView.pinTintColor = MKPinAnnotationColorPurple;
                customPinView.pinTintColor = [UIColor redColor];
                break;
            default:
                imageName = @"Pin";
                //customPinView.pinTintColor = MKPinAnnotationColorRed;
                break;
        }
        //if([(OotAnnotation *)annotation categoryID] == PinCategoryUser) {
            // Add a custom image to the left side of the callout.
        //}
    }

    // Add a custom image to the left side of the callout.
    UIImageView *myCustomImage = [[UIImageView alloc] initWithImage:[UIImage imageNamed:imageName]];
    customPinView.leftCalloutAccessoryView = myCustomImage;

    return customPinView;
}

// http://stackoverflow.com/a/6941743
- (void)mapView:(MKMapView *)mapView annotationView:(MKAnnotationView *)view calloutAccessoryControlTapped:(UIControl *)control {
    if ([view.annotation isKindOfClass:[Annotation class]]) {
        [self performSegueWithIdentifier:@"showLocation" sender:view];
    }
}

-(MKOverlayView *)mapView:(MKMapView *)mapView viewForOverlay:(id<MKOverlay>)overlay {
    if(overlay == self.routeLine) {
        if(nil == self.routeLineView) {
            self.routeLineView = [[MKPolylineView alloc] initWithPolyline:self.routeLine];
            self.routeLineView.fillColor = [UIColor yellowColor];
            self.routeLineView.strokeColor = [UIColor yellowColor];
            self.routeLineView.lineWidth = 10;
        }
        return self.routeLineView;
    }
    return nil;
}

@end
```

![Wordpress](../images/wordpress.png "Wordpress") [Original Link](https://alexhedley.wordpress.com/2018/02/03/mapkit/)
