# Share Image As File

In this lab, you will learn how share a image.

## Steps

- Save Docker Image as File using --output
- Save Docker Image as File
- Remove Docker Images
- Load Docker Image from File using --input
- Load Docker Image from File using Pipe

### Save Docker Image as File using --output

```sh
$ docker save --output helo-world.image helo-world
```

### Save Docker Image as File

```sh
$ docker save helo-world > helo-world-2.image
```

### Remove Docker Images

```sh
$ docker rmi helo-world
```

### Load Docker Image from File using --input

```sh
$ cat helo-world.image | docker load
```

### Load Docker Image from File using Pipe

```sh
$ cat helo-world-2.image | docker load
```

##### Tips
- Compress file to share image
- Use -i | -o as short version
- https://gist.github.com/mathewdgardner/b8b834b9d94da898b5df
- https://docs.docker.com/engine/reference/commandline/save/