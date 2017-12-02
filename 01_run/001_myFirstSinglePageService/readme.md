# My First Single Page Service

In this lab, you will learn basic usage of containers, some commands that allow you create destroy and monitoring containers.

## Steps

- Find a image ~ Docker Hub
- Create and Run a nginx container
- Review the container
- Stop the container
- Kill the container
- Clean & Useful commands
- Monitoring & Status
- All learned in One

### Find a image ~ Docker Hub

```sh
$ nautilus https://hub.docker.com/ || chrome https://hub.docker.com/ || echo "Open Google Chrome Manually"
```

```sh
$ docker pull alpine
```

```sh
$ docker pull byrnedo/alpine-curl
```

##### Tips
- Docker Hub / Docker Store - Official public site for images
- Use official images
- Use small images (for linux based on alpine)

### Create and Run a nginx container

```sh
$ docker run -p 80:80 nginx:alpine
```

##### Tips
- Ctrl + C to stop the process
- Docker puts a creative name for no named containers
- Use --name <name> to put container name, It needs to be unique

### Review the container

```sh
$ docker ps
```

```sh
$ docker ps -a
```

### Stop the container

```sh
$ docker stop <containerName>
```

```sh
$ docker rm <containerName>
```

##### Tips
- You can use the Container ID or Container Name to reference one container
- Stoped containers are in the disk

### Kill the container

```sh
$ docker rm -f <containerName>
```

##### Tips
- Containers need to be stoped before remove
- Use --force | -f flag to force stop on remove
- Use --rm on run to automatically remove the container on stop

### Clean & Useful commands

List active container IDs
```sh
$ docker ps -q
```

List all containers
```sh
$ docker ps -qa
```

Stop all containers
```sh
$ docker stop $(docker ps -q -a)
```

Remove all containers
```sh
$ docker rm $(docker ps -q -a)
```

##### Tips
- Clean useless containers
- stop/rm works with more than one container

### Monitoring & Status

```sh
$ docker top <containerName>
```

```sh
$ docker stats
```

### Summary

Start Home Service in background
```sh
$ docker run -p 80:80 \
	--detach --name home \
	nginx:alpine
```

```sh
$ docker logs -f home
```

Stop/Start/Restart Home Service
```sh
$ docker stop home
$ docker start home
$ docker restart home
```

Remove Home Service
```sh
$ docker rm -f home
```

##### Tips
- Use "docker container run" as "docker run"
- Use --name to define the container name
- Use --detach | -d to run in background
- Use linux escape end line '\' to have understandable commands
- Use Play With Docker to have practice env
