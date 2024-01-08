::================================================================================================================
:: How to run docker image to create container    
:: Author       : Solomio S. Sisante
:: Date Created : January 8, 2024
::================================================================================================================

:: 1. Remove existing image forcibly    
::    docker rmi -f accsol.api:latest

:: 2. Prune system.
::    docker system prune -f

:: 3. Build docker image custom Dockerfile file with specific path and filename.

::    docker build -t accsol.api -f AccSol.API\Dockerfile .

::    or

::    docker build -t accsol.api -f AccSol.API\testdotnettools.df .

:: 4. Run docker container from docker image.

::    docker run --rm -p 7033:7033 --name=accsol.api --network accsolnet -v C:\Databases:C:\Databases accsol.api

::================================================================================================================
:: Build and Run accsol.api container
::================================================================================================================
::    docker rmi -f accsol.api:latest

::    docker system prune -f

::    docker build -t accsol.api -f AccSol.API\Dockerfile .

::    ::docker run --rm -p 7033:7033 --name=accsol.api --network accsolnet -v C:\Databases:C:\Databases accsol.api
::    docker run --rm -p 7040:7040 --name=accsol.api --network accsolnet accsol.api

::================================================================================================================
:: Build and Run testdotnettools container
::================================================================================================================
    docker rmi -f testdotnettools:latest

    docker system prune -f

    docker build -t testdotnettools -f AccSol.API\testdotnettools.df .

::    ::docker run --rm -p 7033:7033 --name=accsol.api --network accsolnet -v C:\Databases:C:\Databases accsol.api
::    ::docker run --rm -p 7033:7033 --name=accsol.api --network accsolnet -v C:\Databases:C:\Databases accsol.api
    docker run --rm -p 7040:7040 --name=testdotnettools --network accsolnet testdotnettools
