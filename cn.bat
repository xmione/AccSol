docker network rm accsolnet
:: docker network create -d nat moneymenet --subnet=172.25.0.0/16
:: docker -c win network create -d transparent moneymenet --subnet=172.25.0.0/16 --gateway 172.25.0.1 -o com.docker.network.windowsshim.dnsservers="172.25.0.7"
docker network create -d nat accsolnet