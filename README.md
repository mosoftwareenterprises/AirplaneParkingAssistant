# AirplaneParkingAssistant

Accessible here: https://white-pebble-0279cb103.azurestaticapps.net/



Walk through the solution you have arrived at, of interest, will be any challenges you faced and what lessons you may have learned along the way.



## Problem
As an airplane parking assistant,
So that I can efficiently manage parking slots,
I want to be recommended a parking slot when a new airplane arrives.
And to be able to book the plane into that parking slot.

## Notes
A plane may be parked for a few hours or a few days.
There are 100 slots, but they are not of the same size,
* 25 for Jumbos (A380, B747)
* 50 for Jets (A330, B777)
* 25 for Props (E195)

Only the plane types listed above will arrive at the airport
Smaller planes can park in larger slots, but not the other way around.
If no slot is available, an obvious alert should be raised.
We have yet to select the device or the data storage mechanism that will be used.
Consider how airlines might pre-book slots in a future iteration of this product.


## Justification for Language and Framework

C# and dotnet 5. I am most familiar with, and is multi-platform and very fast.
Blazor because I am familiar with it and enjoy learning it.
Blazor Static Web App so I can standup a prototype very fast, and with no cost.
WebAssembly versus client server makes no difference to Blazor, so it can use a full data store later by moving it to the Server with minor code changes.
Will be able to run on any platform, and a lot of devices with dotnet 6 without a browser.



## Initial design:

### Front end:
A drop down with the 5 plane types in them.
A "Recommend location" button
A "Park aircraft at recommendation" button.
A "number of slots available" view for each aircraft type.
An "Error" display section.


### Back end:

100 slots available across 3 different types
ParkingAssistant class.
Park(Aircraft aircraftToPark, ParkingTime timeToParkFor) method (Use an object as we don't know what we need to store, easily extendable)

Aircraft should choose the smallest spot they can fit in that is free.

We should have a class for each type, that owns the spots and controls how many are filled.
bool JumboParker(Aircraft aircraftToPark, ParkingTime timeToParkFor)
{
    If can fit, then park else return false;
}

Have an ordered list of "parkingAttendants" that are progressed through one at a time until the plane is recommended.



### Implementation

Implement front end first. Not tested for now due to time limits.

### Next steps?

```Consider how airlines might pre-book slots in a future iteration of this product.```

We would need to have the parking slots being time sensitive. At present we have no concept of time.

We also need to consider what if a plane is parked while the attendant is deciding.