# DoNotDirectShow
A program that opens a invisible window with the preview from your capture device using DirectShow
## Tested Capture Devices
* Startech USB3HDCap: working
* $10 crapture cards: working
* Avermedia Live Gamer Portable(C875): not working(but it does with AVerMedia Stream Engine)
## Bugs
* No Audio support(will be worked on in the future) so now you would need to have audio as Line in on your PC(or use a another capture card)
* When exiting/stopping the capture card it sometimes fails to do so and thus the program still uses some RAM
* High memory usage, not sure if this is because of the way i coded it or that the DirectShow library does this on it's own
