FROM node:8-alpine
LABEL maintainer="Gary Ascuy <gary.ascuy@gmail.com>"

ENV YARN_CACHE_FOLDER=/workspace/cache
RUN yarn global add @angular/cli && \
    apk add --update curl ca-certificates && \
    ng set --global packageManager=yarn
WORKDIR /workspace
EXPOSE 4200

CMD sleep 666d
