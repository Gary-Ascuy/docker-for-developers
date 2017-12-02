# Deploy MongoDB

In this lab, you will learn how deploy MongoDB using docker containers.

## Steps

- Deploy MongoDB without password
- MongoDB for MeteorApp
- Deploy MongoDB with Password
- All learned in One

### Deploy MongoDB without password

```sh
$ cd 003_deployMongoDB
```

Start MongoDB Service
```sh
$ docker run -p 27017:27017 \
    -v "$(pwd)/database":/data/db \
    --name database \
    mongo
```

Execute some queries
```sh
$ docker exec -it database bash
```

Mongo Client - Help
```sh
> mongo --help
```

In the console execute the following commands
```sh
> mongo localhost:27017
```

In mongo console execute the following commands
```sh
> use productionDatabase
```

Insert post into
```sh
> db.posts.insert({"title": "Docker", "content": "Test Post", date: new Date()})

> db.posts.insert({"title": "Nintendo", "content": "Nintendo revises its annual profit outlook as supply shortages plaguing Switch console begin to ease", date: new Date()})

> db.posts.insert({"title": "Apple", "content": "Apple's first Vice President of inclusion and diversity, Denise Young Smith to leave by year end", date: new Date()})
```

list all posts
```sh
> db.posts.find().pretty()
```

##### Tips
- Use RoboMongo to excecute queries in most easy way
- Use 'pretty' method to show in better document in better way e.g.db.posts.find().pretty()
- Type 'exit' to leave the mongo terminal

### MongoDB for MeteorApp

```sh
$ docker run -d -p 27017:27017 --restart=always \
    -v "$(pwd)/mongodb":/data/db \
    --name mongodb \
    mongo mongod --smallfiles --nohttpinterface --replSet rs0
```

```sh
$ docker exec -it mongodb mongo
```

Configure MongoDB as replica
```sh
> use admin

> rs.initiate()

> db.createUser({"user": "oplogger", "pwd": "master", "roles": [{"role": "read", "db": "local"}]})
```

Stop & Remove Mongo service
```sh
$ docker rm -f mongodb
```

##### Tips
- Use --restart=always to have the service allways running.

### Deploy MongoDB with Password
```sh
$ docker run -d -p 27666:27017 --restart=always \
	-v "$(pwd)/mongoProd":/data/db \
	--name mongoProd mongo mongod \
	--auth
```

Create MongoDB super admin user
```sh
$ docker exec -it mongoProd mongo admin
```

```sh
> db.createUser({"user": "superAdmin", "pwd": "666", "roles": [{"role": "userAdminAnyDatabase", "db": "admin" }]});
```

Create MongoDB data access user
```sh
$ docker run -it --rm \
	--link mongoProd:mongo.docker.local \
	mongo mongo mongo.docker.local:27017 -u superAdmin -p 666 \
	--authenticationDatabase admin
```

Create Mongo user
```sh
> db.createUser({"user": "admin", "pwd": "666", "roles": [{"role": "root", "db": "admin"}]});
```

```sh
$ docker run -it --rm \
	--link mongoProd:mongo.docker.local \
	mongo mongo mongo.docker.local:27017/production -u admin -p 666 \
	--authenticationDatabase admin
```

```sh
> db.getName()
```

Remove MongoDB service
```sh
$ docker rm -f mongoProd
```

##### Tips
- Use this setting for staging or production.
- Use --link to link containers

### Summary

Start MongoDB Service
```sh
$ docker run -p 27017:27017 \
	-v "$(pwd)/database":/data/db \
	--name database \
	mongo
```

Remove MongoDB Service
```sh
$ docker rm -f database
```

##### Tips
- Use database without password for development only
- Here you can find more details https://docs.docker.com/engine/userguide/networking
