FROM nginx:alpine
LABEL maintainer="Gary Ascuy <gary.ascuy@gmail.com>"

ADD ./wedding /usr/share/nginx/html
WORKDIR /usr/share/nginx/html
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
