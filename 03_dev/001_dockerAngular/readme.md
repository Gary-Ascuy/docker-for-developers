# Docker Angular in Development

In this lab, you will learn how use angular cli (command line interface) with Docker.

## Steps

- Build Angular Image for Development
- Create a Angular Porject
- Serve in Development Mode
- Build Angular Project
- Create Image from Angular App
- Run using Sleep & Docker exec

### Build Angular Image for Development

No Execute - It will take some time
```sh
$ cd docker-angular

$ docker build -t angular .
```

##### Tips
- Add all tools that you will need in the image
- Keep your env Clean

### Create a Angular Porject

```sh
$ alias ng='docker run -it --rm -v "$(pwd)":/workspace angular:latest ng'
```

```sh
$ ng new hello-world-angular --skip-install
```

```sh
$ cd hello-world-angular
```

##### Tips
- https://angular.io/guide/quickstart

### Serve in Development Mode

```sh
$ alias ngOpen='docker run -it --rm -v "$(pwd)/../":/workspace angular:latest sh'
```

```sh
$ ngOpen
```

```sh
> yarn install
> ng serve
```

In other terminal
```sh
$ docker exec -it <containerName> sh
```

```sh
$ curl localhost:4200
```

Fix for external access & Open in the host browser http://localhost:4200/
```sh
$ ng serve --host 0.0.0.0 --port 4200 --watch
```

```sh
$ exit
```

### Build Angular Project

```sh
$ alias ngOpen='docker run -it --rm -v "$(pwd)/../":/workspace angular:latest sh'
```

```sh
$ ngOpen
```

Create a build and put the result into ./dist
```sh
> ng build
```

```sh
$ exit
```

### Create Image from Angular App

```
FROM nginx:alpine
LABEL maintainer="Gary Ascuy <gary.ascuy@gmail.com>"

ADD ./dist /usr/share/nginx/html
WORKDIR /usr/share/nginx/html
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
```

```sh
$ docker build -t helloworldangular:1.0.0 .
```

### Run using Sleep & Docker exec

```sh
$ docker run -p 4200:4200 \
    -v "$(pwd)"/workspace:/workspace \
    --name angular \
    angular sleep 666d
```

```sh
$ alias ngExec='docker exec angular sh'
```

```sh
$ ngExec
```

```sh
> ng new testProject
> cd testProject
> ng serve --host 0.0.0.0 --port 4200 --watch
```
