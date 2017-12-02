# Docker Networking

In this lab, you will learn how manage networks and IPs and all stuff related with the network in docker.

## Steps

- Manage networks in docker
- Create a container with custom network
- Use Host network
- Assign IP and run with Custom network
- Link containers

### Manage networks in docker

Show networks
```sh
$ docker network ls
```

Inspect a network
```sh
$ docker network inspect bridge
```

### Use Host network

```sh
$ docker run --network=host -it --rm nginx:alpine
```

##### Tips
- It actualy does not works in MacOS
- https://forums.docker.com/t/should-docker-run-net-host-work/14215/13

### Create a container with custom network

```sh
$ docker network create home
```

```sh
$ docker network inspect home
```

### Assign IP and run with Custom network

```sh
$ docker run --network=home --ip=172.21.10.10 -it --rm nginx:alpine sh
```

```sh
$ docker run --network=home --ip=172.21.11.11 -it --rm nginx:alpine sh
```

```sh
$ ping 172.21.10.10
```

### Link containers

```sh
$ docker run -d --name server nginx:alpine
```

```sh
$ docker run -it --rm \
  --link server \
  nginx:alpine sh
```

```sh
$ docker run  -it --rm \
    --link server:server.docker.local \
    nginx:alpine sh
```

```sh
$ docker run  -it --rm \
    --link server:server.docker.local \
    byrnedo/alpine-curl curl server.docker.local
```

##### Tips
- Parameters --link=CONTAINER-NAME:ALIAS
- Use secured container connectivity (in isolation via --icc=false)
