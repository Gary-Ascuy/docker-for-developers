FROM node:9.2-alpine
LABEL maintainer="Gary Ascuy <gary.ascuy@gmail.com>"

ENV NODE_ENV=production
ADD ./src /opt/node/app
WORKDIR /opt/node/app
RUN npm install

EXPOSE 3666
CMD node app.js
