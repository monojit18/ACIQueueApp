FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS installer-env

COPY . /src/aci-queue-app
RUN cd /src/aci-queue-app && \
    mkdir -p /home/site/wwwroot && \
    dotnet publish *.csproj --output /home/site/wwwroot

# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/dotnet:3.0-appservice
FROM mcr.microsoft.com/azure-functions/dotnet:3.0
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true
ENV AzureWebJobsStorage=DefaultEndpointsProtocol=https;AccountName=srvlswkstorage;AccountKey=QTrV7WSaZFK1UraurcKA1yi5fRmuw89ipTD4nq9+cpEnrsM4e7/ijNl3hCFA6/JsyOR6c1f5ARTq9JJKcDVXaA==;BlobEndpoint=https://srvlswkstorage.blob.core.windows.net/;QueueEndpoint=https://srvlswkstorage.queue.core.windows.net/;TableEndpoint=https://srvlswkstorage.table.core.windows.net/;FileEndpoint=https://srvlswkstorage.file.core.windows.net/;

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]