#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine-arm64v8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine-arm64v8 AS publish
WORKDIR /app
COPY . .
RUN dotnet publish "./Exam.Calculator.WebApi/Exam.Calculator.WebApi.csproj" -c release -o /app/publish -r linux-musl-arm64 --self-contained false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exam.Calculator.WebApi.dll"]