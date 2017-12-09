# NodeJS App from Dockerfile

In this lab, you will learn how create a image from script app (nodeJS) using a Dockerfile.

## Steps

- Run in development mode
- Build a image from NodeJS app
- Run my first created image

### Run in development mode

Requires NodeJS 9.2 & install dependencies
```sh
$ npm install
```

Start server on http://localhost:3666
```sh
$ npm start
```

### Build a image from static files

```sh
$ docker build -t nodeapp:1.0.0 -t nodeapp:latest .
```

##### Tips
- Use .dockerignore file to filter files on ADD
- Use ENV command to define env variables in the container
- Use RUN to executes command on build
- Copy only required files
- Install dependencies on container
- Install only production dependencies

### Run my first created image

```sh
$ docker run -p 3666:3666 nodeapp:1.0.0
```

##### Tips
- NodeJS - https://nodejs.org/en/
- You can find more about Docker ~ NodeJS here - https://github.com/sahat/hackathon-starter
