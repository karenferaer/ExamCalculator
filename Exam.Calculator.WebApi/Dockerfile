FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Exam.Calculator.WebApi/Exam.Calculator.WebApi.csproj", "Exam.Calculator.WebApi/"]
COPY ["Exam.Calculator.Services/Exam.Calculator.Services.csproj", "Exam.Calculator.Services/"]
RUN dotnet restore "Exam.Calculator.WebApi/Exam.Calculator.WebApi.csproj"
COPY . .
WORKDIR "/src/Exam.Calculator.WebApi"
RUN dotnet build "Exam.Calculator.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_14.x | bash \
    && apt-get install nodejs -yq
RUN dotnet publish "Exam.Calculator.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exam.Calculator.WebApi.dll"]
