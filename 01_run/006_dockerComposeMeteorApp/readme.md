# Docker Compose - Meteor App

In this lab, you will learn the basic concepts in docker compose.

## Steps

- Validate and view the Compose file
- Start services: Nginx, Mongo, and Meteor App
- Clean services
- Manage containers: Start/Stop/Restart
- Update all images

### Validate and view the Compose file

```sh
$ nautilus https://docs.docker.com/compose/compose-file/
```

```sh
$ cd 006_dockerComposeMeteorApp
```

```sh
$ docker-compose config
```

### Start services: Nginx, Mongo, and Meteor App

```sh
$ docker-compose up
```

Run sercices in background
```sh
$ docker-compose up -d
```

### Clean services

```sh
$ docker-compose down
```

### Manage containers: Start/Stop/Restart

```sh
$ docker-compose start
```

```sh
$ docker-compose stop
```

```sh
$ docker-compose restart
```

### Update all images

```sh
$ docker-compose pull
```
