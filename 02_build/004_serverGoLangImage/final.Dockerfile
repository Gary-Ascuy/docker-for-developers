# Stage 1 - Build Go-Lang App
FROM golang:1.9 as builder
WORKDIR /opt/node/app
COPY src/main.go .
RUN CGO_ENABLED=0 GOOS=linux go build -a -installsuffix cgo -o main .

# Stage 2 - Build using final artifact over alpine
FROM alpine:latest
LABEL maintainer="Gary Ascuy <gary.ascuy@gmail.com>"

RUN apk --no-cache add ca-certificates
WORKDIR /root
COPY --from=builder /opt/node/app/main .

EXPOSE 8666
CMD ./main
