FROM node:lts-alpine

# install simple http server for serving static content
RUN npm install -g http-server

# make the current vehicle app folder the current working directory
WORKDIR /app

# copy both 'package.json' and 'package-lock.json' (if available)
COPY package*.json ./

# install project dependencies leaving out dev dependencies
RUN npm install --production

# copy project files and folders to the current working directory (i.e app) 
COPY . .

# build app for production with minification
RUN npm run build

EXPOSE 9999
CMD [ "http-server", "dist" ]


# to build the image use this command
# docker build -t vuejs-cookbook/dockerize-vuejs-app .
# to run the image, map the internal port to the external port 8080
# docker run -it -p 8080:9999 --rm --name dockerize-vuejs-app-1 vuejs-cookbook/dockerize-vuejs-app
# launch the application using localhost:8080