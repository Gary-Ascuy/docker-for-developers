# Runtime constraints on resources

## Steps

- Limit Memory
- CPU

### Limit Memory

```sh
$ docker run -it --memory 300M  ubuntu bash
```

```sh
$ docker run -it --memory 300M --memory-reservation 200M ubuntu bash
```

### Limit CPU

Share CPU 50%
```sh
$ docker run -it --cpu-period=50000 --cpu-quota=25000 ubuntu bash
```

Assign CPU
```sh
$ docker run -it --cpuset-cpus="0" ubuntu bash
```

##### Tips
- https://docs.docker.com/engine/reference/run/#runtime-constraints-on-resources
