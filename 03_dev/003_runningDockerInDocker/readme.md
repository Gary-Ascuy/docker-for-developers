# Running Docker-in-Docker

In this chapter we will lear how run docker into a docker container.

## Steps

- Run Docker using docker.sock
- Run Docker Container into Docker container that is running into a container

### Run Docker using docker.sock

```sh
$ docker run -it \
    -v /var/run/docker.sock:/var/run/docker.sock \
    docker sh
```

### Run Docker Container into Docker container that is running into a container

```sh
$ docker images
```

```sh
$ docker ps
```

```sh
$ docker run -it \
    -v /var/run/docker.sock:/var/run/docker.sock \
    docker sh
```

```sh
$ docker ps
```

```sh
$ docker run -it \
    -v /var/run/docker.sock:/var/run/docker.sock \
    docker sh
```

```sh
$ docker ps
```

```sh
$ exit
```

##### Tips
- It can usefull for Build Environment
- https://jpetazzo.github.io/2015/09/03/do-not-use-docker-in-docker-for-ci/
