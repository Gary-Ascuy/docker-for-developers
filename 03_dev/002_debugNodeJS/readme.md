# Debug NodeJS App

Here you will leard how debug NodeJS App and configure VS Code to debug using container.

## Steps

- Open Visual Studio Code from Terminal
- Docker Compose - Files for debug
- Debug using Chrome Inspector
- Configure NodeJS Debug for VS Code

### Open Visual Studio Code from Terminal

```sh
$ code .
```

```sh
$ code fileName.js
```

### Docker Compose - Files for debug

Dockerfile
```
FROM node:9.2-alpine
LABEL maintainer="Gary Ascuy <gary.ascuy@gmail.com>"

WORKDIR /code
RUN npm install -g nodemon
COPY ./src /code
RUN npm install && npm ls

EXPOSE 3666
CMD npm start
```

docker-compose.yml
```sh
version: "3"

services:
  web:
    build: .
    command: nodemon --nolazy --inspect=0.0.0.0:9229 src/app.js
    volumes:
      - .:/code
    ports:
      - "3666:3666"
      - "9229:9229"
```

### Debug using Chrome Inspector

Build and Open
```sh
$ docker-compose up
```

Open Chrome and Type the following in URL section:

```
chrome://inspect
```

Target
```
DevTools >> Devices >> Remote Target >> Target
```

Available Debug Processes
```
app.js file:///code/src/app.js
```

Click on inspect
```
inspect
```

It shows the Google Chrome Inspector, lets play with it

### Configure NodeJS Debug for VS Code

Replace the command in docker-compose.yml with following line:
```
command: nodemon --nolazy --inspect-brk=0.0.0.0:9229 src/app.js
```

Configure Debug in VS Code
```
Menu >> Debug >> Open Configurations
```

```
Debug Tab >> Gear (Open launch.js)
```

Pick "Node JS" from the list and It creates a file into ".vscode/launch.json"
```
{
  // Use IntelliSense to learn about possible Node.js debug attributes.
  // Hover to view descriptions of existing attributes.
  // For more information, visit: https://go.microsoft.com/fwlink/?linkid=830387
  "version": "0.2.0",
  "configurations": [
    {
      "type": "node",
      "request": "launch",
      "name": "Launch Program",
      "program": "${file}"
    }
  ]
}
```

Replace the content with following content
```
{
  "version": "0.2.0",
  "configurations": [
    {
      "type": "node",
      "request": "attach",
      "name": "Docker NodeJS Debug",
      "protocol": "inspector",
      "port": 9229,
      "address": "localhost",
      "restart": true,
      "sourceMaps": false,
      "localRoot": "${workspaceRoot}",
      "remoteRoot": "/code"
    }
  ]
}
```

Then just put break points and lets debug

##### Tips
- NodeJS Debug - https://www.youtube.com/watch?v=kqLRCoClfko
- Play with Docker - http://training.play-with-docker.com/dev-stage2/
- https://youtu.be/y9IYnEDSVEc?list=PLkA60AVN3hh8_lyxE2jjGaGyr0UoqIv4K
- https://code.visualstudio.com/docs/nodejs/nodejs-debugging
- http://training.play-with-docker.com/nodejs-live-debugging/
