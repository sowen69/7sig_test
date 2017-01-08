# Sigma Seven Coding Test Question One

## Option One

Run a watcher process on the GIS server that runs when the package files are accessed.
Gather the required parameters from the connected client.
Create a touch file using the following naming convention - [COMPUTER NAME]-[USERNAME].txt
If an existing touch file exists with the same name, delete it first
The creation date time stamp for the file then represents the last client access.
When "Generate Report" is run output a list of all files in the touch file directory. 
Save this file overwriting the existing file. (optionally save the existing file with a timestamp then write the new file)

## Option Two

Modify the "Update Datasets" application to write a touch file on the server when the packages have been downloded and decommpressed.
Proceed as Option One


## Pros/Cons

Option One would require a worker process on the server that could have a detrimental effect on performance.
If multiple clients update at the same time file locks/timestamps may be affected
It is non-transactional: The process may terminate before the client has downloaded the packages but the touch file still written

Option Two is simpler to impliment and dosen't effect server performance.
It is non-transactional: The process may terminate before the client has uploaded the touch file.
 