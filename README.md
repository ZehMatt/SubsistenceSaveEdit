# SubsistenceSaveEdit
![SubsistenceSaveEdit](https://share.epic-domain.com/SubsistenceSaveEdit_2018-05-23_06-28-45.jpg)

Save game editing tool for the game Subsistence.

# Why 
The game currently offers no sandbox feature so the only way to test everything is by playing it for hundred of hours. This gives you the ability
to get any item you want and any amount of it. 

# Usage
Simply load the most recent savegame via "Load" since that is most likely the current active savegame file the game will use. Once loaded it should show all properties the save contains, you want to look into "SerializedWorldData" since every object and its data is in there from the world.

Selecting it will show every saved property for the world. To edit your player you would want to look for something like
```"Name":"coldmap1.TheWorld:PersistentLevel.ColdPlayerPawn_...``` 

I highly recommend to copy the text and use a JSON Formatter like https://jsonformatter.curiousconcept.com/ to make it easier to edit the data.

Once you are done editing, press "Save" and overwrite the loaded save.

# WARNING
Always create a backup of your save files, it is currently not doing that automatically.
