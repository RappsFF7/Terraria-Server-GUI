#### Downloading
***

To get the application, go to the releases section. Decide on the release you want, and download the .zip file with the program name (TerrariaServerGUI_<Version>.zip).

#### About
***

This application is written in .net framework 4 (which is only logical since the server is also in .net framework 4)

#### Releases
***

##### _Alpha 1.5_

Added command line startup option (-start <config filename>)
1.5.1 - Fixes an issue with the application crashing on startup if Steam isn't installed

##### _Alpha 1.4_

Added new settings (expert mode, noupnp, steam, steam lobby)

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
