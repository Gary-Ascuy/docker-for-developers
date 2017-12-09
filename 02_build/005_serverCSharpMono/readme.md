# C# .Net Core App from Dockerfile

In this lab, you will learn how create a image from compiled app (C# Mono) using a Dockerfile.

## Steps

- Compile & Run development mode - Manual Build
- NancyFX - Manual Build
- Image from NancyFX code

### Compile & Run development mode - Manual Build

Open interactive mono terminal
```sh
$ docker run -w /src -v "$(pwd)/src":/src -it --rm mono:5.4 bash
```

Compile
```sh
> mcs console/app.cs
```

Run
```sh
> mono console/app.exe
```

Run
```sh
> msbuild /help
```

Nuget
```sh
> nuget
```

### Compile & Run development mode - Manual Build

Open interactive terminal
```sh
$ docker run -it \
    -w /src -v "$(pwd)/src":/src \
    -p 12345:12345 \
    mono:5.4 bash
```

```sh
$ cd nancy
```

Restore packages
```sh
$ nuget restore packages/packages.config -PackagesDirectory packages
```

Copy dependencies
```
$ cp packages/Nancy.1.4.4/lib/net40/Nancy.dll bin/Nancy.dll

$ cp packages/Nancy.Hosting.Self.1.4.1/lib/net40/Nancy.Hosting.Self.dll bin/Nancy.Hosting.Self.dll
```

Compile
```sh
$ mcs /reference:bin/Nancy.dll /reference:bin/Nancy.Hosting.Self.dll \
    HomeModule.cs -out:bin/App.exe
```

Run
```sh
$ mono bin/App.exe
```

### Image from NancyFX code

```sh
$ docker build -t nancyapp:1.0.0 .
```

```sh
$ docker run -p 12345:12345 nancyapp:latest
```

##### Tips
- Mono - http://www.mono-project.com/
- For Windows - https://docs.docker.com/engine/examples/dotnetcore/
- Nancy - http://nancyfx.org/
- Nancy ~ Get Started - http://getting-started.md/guides/4-dotnet-nancy
- http://volkanpaksoy.com/archive/2015/11/11/building-a-simple-http-server-with-nancy/