# DWR Tracker

Auto tracker for the [Dragon Warrior Randomizer](https://github.com/mcgrew/dwrandomizer)

![DWR Tracker screenshot](https://github.com/tonylukasavage/DWR-Tracker/raw/master/dwr-tracker.PNG)

## Requirements

* Windows
* [fceux 2.2.3](http://fceux.com/web/home.html)
	* May work on earlier versions, but it's untested

## Usage

This project is in an **alpha** state. You need to use the tracker via the following steps.

1. Open you emulator 
2. Launch the Dragon Warrior Randomizer seed you wish to play
3. Double-click the "DWR Tracker.exe" file. It will auto-connect to the emulator instance that you have open.

## Known Issues

* There's no way yet to manually connect to an emulator, which is why the emulator needs to be open with DWR already started before you can launch the tracker.
* The map discovery will reset if you turn off the emulator and start the game again. Resets from within the emulator are fine, but actually closing the emulator will not preserve map discovery.

## TODO 

The priority of the following work will likely be dictated by requests.

* Add names to key locations on overworld map (towns and caves)
* Add chest and search spot tracker
* Add general notes section
* Mesen support
	* I started this, but I'm no Cheat Engine pointer path genius. I'll likely need a little help here for this to get completed.


