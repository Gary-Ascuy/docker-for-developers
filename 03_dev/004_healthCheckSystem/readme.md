# Docker Health Check

In this chapter we will learn how works the Health Check in Docker.

## Steps

- Test a basic Nginx Container - Fail Case
- Test a basic Nginx Container - Normal Case
- Create a service with leack

### Test a basic Nginx Container - Fail Case

```sh
$ docker run -d \
    --health-cmd "exit 1" \
    --health-start-period 20s \
    --health-interval 10s \
    --health-retries 3 \
    --name live \
    nginx:alpine
```

```sh
$ docker ps
```

Get Health Status
```sh
$ docker inspect --format '{{ .State.Health.Status }}' live
```

Remove Container
```sh
$ docker rm -f live
```

### Test a basic Nginx Container - Normal Case

Dockerfile
```
FROM nginx:alpine
LABEL maintainer="Gary Ascuy <gary.ascuy@gmail.com>"

HEALTHCHECK --start-period=1m --interval=5m --timeout=3s \
  CMD curl -f http://localhost/ || exit 1
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
```

```sh
$ docker build -t nginx-health-check .
```

Run the container
```sh
$ docker run -d -p 80:80 nginx-health-check
```

Get Health Status
```sh
$ docker inspect --format '{{ .State.Health.Status }}' live
```

### Create a service with leack

Using NodeJS let's code

##### Tips
- https://docs.docker.com/engine/reference/builder/#healthcheck
