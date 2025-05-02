FROM mcr.microsoft.com/dotnet/sdk:9.0-bookworm-slim AS build
WORKDIR /app

COPY . .

# publish
RUN cd FooBar.API/ && dotnet publish -c Release -o ../out

FROM mcr.microsoft.com/dotnet/aspnet:9.0-bookworm-slim AS runtime
WORKDIR /app
COPY --from=build /app/out .

RUN chmod -R o+rwx  ./
RUN useradd -ms /bin/bash docker
USER docker

EXPOSE 6016/tcp
ENV ASPNETCORE_URLS="http://*:6030"

ENTRYPOINT ["dotnet", "FooBar.API.dll"]