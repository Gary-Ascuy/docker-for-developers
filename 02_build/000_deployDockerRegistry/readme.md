# Deploy Docker Registry

In this lab, you will learn how deploy a registry into the local env.

## Steps

- Configure Docker Env
- Deploy Registry
- Use local registry

### Configure Docker Env

```sh
$ vi /etc/docker/docker
```

```sh
# add this line
DOCKER_OPTS="--insecure-registry 127.0.0.1:5000"
```

```sh
$ service docker restart
```

### Deploy Registry

```sh
$ docker run -d -p 5000:5000 \
    -v "$(pwd)/data":/var/lib/registry \
    --name registry \
    registry
```

### Use local registry

```sh
$ docker pull hello-world
```

```sh
$ docker tag hello-world 127.0.0.1:5000/hello-world
```

```sh
$ docker push 127.0.0.1:5000/hello-world
```

##### Tips
- Deploy Registry - http://training.play-with-docker.com/linux-registry-part1/
- Security - http://training.play-with-docker.com/linux-registry-part2/
