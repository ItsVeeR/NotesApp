#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["NotesApp.NotesAPI/NotesApp.NotesAPI.csproj", "NotesApp.NotesAPI/"]
RUN dotnet restore "NotesApp.NotesAPI/NotesApp.NotesAPI.csproj"
COPY . .
WORKDIR "/src/NotesApp.NotesAPI"
RUN dotnet build "NotesApp.NotesAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotesApp.NotesAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotesApp.NotesAPI.dll"]