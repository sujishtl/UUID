# UUID
A sample ASP NET Core 5 API using docker-compose that takes one string input of any number of integers separated by single whitespace. The function then outputs the longest increasing subsequence (increased by any number) present in that sequence. If more than 1 sequence exists with the longest length, it will output the earliest one. 

---Work in progress--- 
First copy with all testcases based on the requirement

<h3>Running the project</h3>

<b>Locally via dotnet command line tool</b>

  cd src

  nuget restore

  dotnet run
  

<h3>Running tests</h3>

<b>Locally via dotnet command line tool</b>

  cd src
  
  dotnet test
  
<b>In a docker container via docker-compose</b>

  cd src
  
  docker-compose run test
  
  or 
  
  docker-compose up test
