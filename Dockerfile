FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build-env
WORKDIR /app

COPY . .
COPY ./Comments.API/Comments.API.csproj ./Comments.API/
COPY ./Comments.Application/Comments.Application.csproj ./Comments.Application/
COPY ./Comments.Domain/Comments.Domain.csproj ./Comments.Domain/
COPY ./Comments.Infrastructure/Comments.Infrastructure.csproj ./Comments.Infrastructure/

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "Comments.API.dll"]