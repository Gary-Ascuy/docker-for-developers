# Deploy MongoDB

In this lab, you will learn how deploy a Meteor App with their MongoDB using docker containers.

## Steps

- Deploy MongoDB & Config replica set
- Pull Meteor App
- Deploy Meteor App
- Remove services

### Deploy MongoDB & Config replica set

```sh
$ cd 005_deployMeteorApp
```

Start MongoDB Service
```sh
$ docker run -d --restart=always \
    -v "$(pwd)/database/":/data/db \
    --name mongo \
    mongo mongod --smallfiles --nohttpinterface --replSet rs0
```

Configure Mongo as replica set
```sh
$ docker exec -it mongo mongo admin
```

```sh
> rs.initiate()

> db.createUser({"user": "oplogger", "pwd": "master", "roles": [{"role": "read", "db": "local"}]})
```

##### Tips
- Use --smallfiles in MongoDB to have small files
- Use --replSet rs0 to start MongoDB as cluster

### Pull Meteor App

```sh
$ docker pull meteorjs/todos:latest
```

##### Tips
- Use meteorjs/todos:latest is todos example page
- English version http://www.discovermeteor.com/
- [Free] Spanish version http://es.discovermeteor.com/

### Deploy Meteor App

```sh
$ docker run -d -p 80:3000 --restart=always \
    --link mongo:mongodb.docker.local \
    -e MONGO_URL=mongodb://mongodb.docker.local:27017/todos \
    -e MONGO_OPLOG_URL=mongodb://oplogger:master@mongodb.docker.local:27017/local?authSource=admin \
    --name web \
    meteorjs/todos:latest
```

Alternative using env file
```sh
$ docker run -d -p 80:3000 --restart=always \
    --link mongo:mongodb.docker.local \
    --env-file "$(pwd)/config.env" \
    --name web \
    meteorjs/todos:latest
```

##### Tips
- Use --env | -e to set environment variables
- Use --env-file to load variables from file

### Remove services

```sh
$ docker rm -f web mongo
```

##### Tips
- You can stop/start/remove more than one container given the list of names
