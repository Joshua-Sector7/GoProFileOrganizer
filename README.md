# GoProFileOrganizer - BETA
quick and dirty tool to grab gopro files and save them to your computer

Grabs files from gopro camera (or any directory) and organizes into:
/video
/photo
/grouping

Within each folder it creates date stamped folders for file organiztion. So for example you recorded video on
1/1/2016 and 1/2/2016 the tool would create this folder structure and move your files:

/video
  /2016_01_01
    your_vid1
  /2016_01_02
    your_vid2
   
The actual file names are also updated so they will be in sequential number order, even for groups.

Main benifit of the tool over just using a script is the GUI and the report it generates in the /log
folder. The file contains a report of all the actions that it took with your files. So for example
if a file already was in the destination it would report it couldn't move the file. This should
only happen if you try and perform a second move action from the same source to the same destination.

This is because one use case of the tool is that if (like me) you have a bunch of folders laying around
your computer which are gopro offloads some of which may be duplicates you accidently made just to be
on the safe side you can run this tool and verify it already has saved the files in the past.
