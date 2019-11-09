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

EXPOSE 8080:8080
CMD [ "http-server", "dist" ]


# To run both the web client and the web API
# docker-compose --no-ansi up -d  --force-recreate --remove-orphans
# now check the client app on http://localhost:8080


# OR run the web client  image only as following:



# to build the image use this command
# docker build -t Vehicle_ClientApp/dist .
# to run the image, map the internal port to the external port 8080
# docker run -it -p 8080 --rm --name Vehiclecontainer Vehicle_ClientApp/dist
# launch the application using localhost:8080