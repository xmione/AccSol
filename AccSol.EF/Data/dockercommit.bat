rem ###################################################################
rem # Do this just for the first time
rem ###################################################################
rem # Steps
 
rem # 1. Stop the existing container you want to save to a new tar file
docker stop sqlserver

rem # 2. Commit existing container to a new image
docker commit sqlserver sqlserver

rem # 3. Save image to a new tar file.
docker save -o sqlserver.tar sqlserver

rem ###################################################################
rem # Do this for the succeeding times
rem ###################################################################
rem # Steps
rem <#

rem # 1. Stop the existing container you want to save to a new tar file
rem docker stop sqlserver

rem # 2. Commit existing container to a new image
rem docker commit sqlserver sqlserver

rem # 3. Save image to a new tar file.
rem docker save -o sqlserver.tar sqlserver

rem # Load saved image from sqlserver.tar file
rem docker load --input sqlserver.tar

rem #> 