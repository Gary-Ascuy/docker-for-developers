FROM node:9.2-alpine
LABEL maintainer="Gary Ascuy <gary.ascuy@gmail.com>"

WORKDIR /code
RUN npm install -g nodemon
COPY ./src /code
RUN npm install && npm ls

EXPOSE 3666
CMD npm start
