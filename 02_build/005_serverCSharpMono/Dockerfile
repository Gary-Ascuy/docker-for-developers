# Stage 1 - Build C# Nancy App
FROM mono:5.4 as builder

COPY src/ /opt/node/app
WORKDIR /opt/node/app/nancy

RUN nuget restore packages/packages.config -PackagesDirectory packages
RUN cp packages/Nancy.1.4.4/lib/net40/Nancy.dll bin/Nancy.dll
RUN cp packages/Nancy.Hosting.Self.1.4.1/lib/net40/Nancy.Hosting.Self.dll bin/Nancy.Hosting.Self.dll
RUN mcs /reference:bin/Nancy.dll /reference:bin/Nancy.Hosting.Self.dll HomeModule.cs -out:bin/App.exe

# Stage 2 - Build using final artifact over alpine
FROM mono:5.4-slim
LABEL maintainer="Gary Ascuy <gary.ascuy@gmail.com>"

WORKDIR /root
COPY --from=builder /opt/node/app/nancy/bin .

EXPOSE 12345
CMD mono App.exe
