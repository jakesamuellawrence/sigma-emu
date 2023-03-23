# User manual 
The deployed version of the app can be found at https://sigma-emu.surge.sh/

## Layout
Once open, you should be presented with the main page, which contains three main areas:
 - The toolbar along the top, which contains the actions that must be done in order to compile a Sigma16 file
 - The sidebar which gives controls for stopping and starting the emulator, a view of the emulated registers, and a view of the emulated memory.
 - The main display, which initially shows a small dialog box, and will later show source code or a assembly listing

## Running a program
In order to run a Sigma16 program, take the following steps:
 - First either open a new Sigma16 program from a file, by selecting the open button in the toolbar, or create a new file by pressing new in the toolbar. It should now be shown in the main display
 - Make sure the program has no syntax errors (shown by red underlines) as it will not be able to assemble if it does. An empty file also will not assemble.
 - Press the Assemble button in the toolbar. the main display should now show a listing with machine code for each line
 - The Load button should now be available in the toolbar. Press it and the machine code will be loaded into the memory display.
 - The buttons under the "control" section of the sidebar should now be available. Either press the play button to run the program automatically, or the step button in order to run it line by line

## Resetting the program
To reset the program, first click the round-arrow reset button in the processor controls. This will reset the memory back to 0. Because the program has been unloaded, the controls will once again be locked and the Load button must be pressed to re-load the program. Alternatively, the Load button can be pressed on it's own as this also resets the memory first.

## Changing the memory or registers
Note that all values in both the registers and memory are text-boxes, and you can enter any hex value into it you want, even while a program is mid-execution. Try it out and see how you can break your Sigma16 programs by doing so.
