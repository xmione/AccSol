
docker stop accsol
docker commit accsol solomiosisante/accsol:blazor-1.0
docker tag accsol:1.0 solomiosisante/accsol:blazor-1.0
docker push solomiosisante/accsol:blazor-1.0

docker stop accsol.api
docker commit accsol.api solomiosisante/accsol:api-1.0
docker tag accsol.api:1.0 solomiosisante/accsol:api-1.0
docker push solomiosisante/accsol:api-1.0

docker stop sqlserver
#docker rmi solomiosisante/accsol:sqlserver-1.0
docker commit sqlserver accsol:sqlserver-1.0
docker tag accsol:sqlserver-1.0 solomiosisante/accsol:sqlserver-1.0
docker push solomiosisante/accsol:sqlserver-1.0