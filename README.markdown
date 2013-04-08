#### Downloading
***

Thanks to GitHub removing the download section, it has become neccessary to add compiled/binary files (finished product) to the code repository. This is highly frowned upon, but the only solution without an external download source. The latest stable release will be in the "release" folder (full path: <root>\TerrariaServerCSGUI\bin\Release\) which can be found by downloading the latest code (you can use the "zip" download option). 

#### About
***

This application is written in .net framework 4 client profile (which is only logical since the game and server are in .net framework 4). I am using an express edition of Visual Studios 2012 (Visual Studios 2010 can go die in a fire) which is what the solution file is saved as.

#### Issues
***

Something is preventing me from comitting a .htm file, so the help menu will not work :/

#### Releases
***

##### _Alpha 1.3_

Added ability for custom config file names (this appeared to be active, but the program ignored any user entered values).
Changed long text fields to align as far left as possible when loading a config file (so the end of the field is visible without scrolling the text, which is typically the file name)
Fixed world size option when creating a new world (it never saved your selection).
Fixed issues with multiple config file saving and loading.

##### _Alpha 1.2_

Added logging (but not all logging options are available), timestamps, debug menu (in case the GUI does not properly interpret the server output and change it's state for starting and stopping of the server), shortcut to config file folder

##### _Alpha 1.1_

Added autosaving and now save the config file as a txt (to make it more apparent users can edit it by hand if neccessary).

##### _Alpha 1.0_

This server is now wrapped in a fully functioning GUI that allows command line access once the server has started. The GUI allows saving and selecting of multiple config files. There is not a ton of error checking so you can likely crash the server by trying odd things.

#### License
***

This project is released under the GPLv3 license.
