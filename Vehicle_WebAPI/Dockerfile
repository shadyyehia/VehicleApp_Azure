#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 54321

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Vehicle_WebAPI/Vehicle_WebAPI.csproj", "Vehicle_WebAPI/"]
RUN dotnet restore "Vehicle_WebAPI/Vehicle_WebAPI.csproj"
COPY . .
WORKDIR "/src/Vehicle_WebAPI"
RUN dotnet build "Vehicle_WebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Vehicle_WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vehicle_WebAPI.dll"]



# run this command to build the image 
# docker build -t vehicleWebAPI .
# run this command to run the container
# docker run -d -p 54322:54321 --name myapp aspnetapp
# the web api now will be  avilable on port 54322