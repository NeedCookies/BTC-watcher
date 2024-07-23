FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.csproj ./
# Восстанавливаем зависимости
RUN dotnet restore

COPY . ./
# Собираем приложение
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Устанавливаем cron
RUN apt-get update && apt-get install -y cron

COPY crontab /etc/cron.d/crontab

# Даем разрешения для cron
RUN chmod 0644 /etc/cron.d/crontab

CMD ["sh", "-c", "cron && dotnet NBitcoinTest.dll && tail -f /dev/null"]