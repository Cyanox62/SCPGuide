# SCPGuide

Allows users to request prewritten info documents on features or plugins the server has.

# Installation

**[Smod2](https://github.com/Grover-c13/Smod2) must be installed for this to work.**

Place the "SCPGuide.dll" file in your sm_plugins folder.

# Usage
 
 When the server is started up with the plugin installed, it will create a directory at `[CONFIG_DIRECTORY]/SCP Secret Laboratory/SCPGuide`. 
 Create text files in here with the name of the file being the info name and the contents of the file being what will be output.
 
# Configs
| Config         | Type | Default | Description
| :-------------: | :----: | :----: | :------ |
| scpg_message_split_size | Integer | 8 | If a message contains more than this number of lines it will be split into several messages.
 
# Commands

### Admin commands
| Command         | Description
| :-------------: | :------: |
| SCPGRELOAD / SCPGR | Reloads the info folder. |

### Client commands
| Command         | Description
| :-------------: | :------: |
| info | Lists all available infos. |
| info [infoname] | View the given info. |
