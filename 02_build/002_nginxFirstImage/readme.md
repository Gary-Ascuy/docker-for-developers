# My First Image From Dockerfile

In this lab, you will learn how create a image from static files using a Dockerfile.

## Steps

- Build a image from static files
- Run my first created image

### Build a image from static files

```sh
$ docker build -t wedding:1.0.0 -t wedding:latest .
```

##### Tips
- You can use more than one tag
- By default it search Dockerfile in the current directory
- Use -f | --file to spesify other name of the Dockerfile
- First time takes more time since there is no cache for layers

### Run my first created image

```sh
$ docker run -p 80:80 wedding:1.0.0
```
