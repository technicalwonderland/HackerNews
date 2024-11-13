# HackerNews

## Overview
A simple application for querying Hacker News API

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)

## Setup
Clone the repository to your local machine:
```bash
git clone git@github.com:technicalwonderland/HackerNews.git
cd HackerNews
```
Clean, compile, test and run
```bash
dotnet clean && dotnet build && dotnet test
dotnet run --project ./src/HackerNews.API/HackerNews.API.csproj --launch-profile "https"
```

## Considerations
Assumption:
- Replies to comments are not included into `commentCount`, it's just counting number of `kids`

Things to improve if I had more time:
- Cache single elements by id (now you can query 10 elements then 11, and previous 10 will be fetched)!
- More tests
- Cache getting list of the best stories (cache list of ids)!
- Possibly use ValueTask in hot path
- Use decorator for QueryHandlers to cache any sort of PaginatedEntityQuery
- Add Redis
- Add docker compose
- Add more exception handling in middleware (404 etc.)