# Go Lang App from Dockerfile

In this lab, you will learn how create a image from compiled app (Go Lang) using a Dockerfile.

## Steps

- Run & Build in development mode
- Build a image from Go Lang App as Script
- Run my first created image
- Build a image from Go Lang App as Compiled
- Build a image from Go Lang App Using Multistage

### Run & Build in development mode

Requires Go Lang 1.9 & Start server on http://localhost:8666
```sh
$ go run main.go
```

Build Go-Lang App
```sh
$ go build main.go
```

```sh
$ ./main
```

### Build a image from Go Lang App

```sh
$ docker build -t golangapp:1.0.0 -t golangapp:latest .
```

##### Tips
- It run go lang as script

### Run my first created image

```sh
$ docker run -d -p 8666:8666 golangapp:1.0.0
```

##### Tips
- Go Lang - https://golang.org/
- Go Lang Server - https://golang.org/doc/articles/wiki/


### Build a image from Go Lang App as Compiled

```sh
$ docker build --file compiled.Dockerfile -t golangapp:1.0.0-compiled .
```

```sh
$ docker run -d -p 8666:8666 golangapp:1.0.0-compiled
```

##### Tips
- It compiles the Go Lang App and use the binary

### Build a image from Go Lang App Using Multistage

```sh
$ docker build --file final.Dockerfile -t golangapp:1.0.0-final .
```

```sh
$ docker run -d -p 8666:8666 golangapp:1.0.0-final
```

##### Tips
- It compiles the Go Lang App and use the binary over empty apline
- Use scratch for console app when it is possible