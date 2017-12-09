FROM golang:1.9
LABEL maintainer="Gary Ascuy <gary.ascuy@gmail.com>"

ADD ./src/main.go /opt/node/app/main.go
WORKDIR /opt/node/app
RUN go build main.go

EXPOSE 8666
CMD ./main
