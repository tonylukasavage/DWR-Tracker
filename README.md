# DWR Tracker

## TODO

* cave maps
* DL calculator

0xB35B start of 2 byte next level table

## game state 

related to music
$FB == 0x78 means battle (does fairy flute interrupt? DL music?)
0x5A cave or hauksness
0x50 battle starting swirl music
0x78 battle music & when you play fairy flute
0x7D tantegel
0x96 overworld
* fairy flute keeps value at 0x78


03:CF44 is prior to setting $E0 to an enemy id via $3C
03:CDFF seems to be the enemy check

# $9A (overlays)

* 3 = enemy appears in battle
* 4 = idle / walking / have selected a battle command (no overlay?)
* 5 = stats entering screen when idle
* 7 <-> 6 <-> 5 = battle loading / deloading

## potential setup

1. check for $99 = 3 (in battle)
2. check for $99 is greater than 4 (exit battle   



$9E4B is the start of enemy data, each set is 0xF long


0053FC00 - mov al, [eax+edx]

03374FC8