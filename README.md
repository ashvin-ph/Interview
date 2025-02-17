# Introduction
This project contains a web API that that uses Youtube API to return certain results.

### Video details
`GET: /api/videos/{videoId}`  
Returns id, title, description and publish date and time about a video. For example a video with id `vvdcaQMM9J8`. 

### Search Videos *

`POST: /api/videos/search?q=query`  
Looks up popular videos and returns their id, title, description and publish date and time as a list.   
\* currently not implemented

## Assignment
Before the assignment, you will receive an API key. 
To keep this assignment simple, you will hard-code API key into `appsettings.Development.json`. 

#### Problem solving
Looking up video details doesn't work. It returns an error (status 500).
1. Why is it happening?
2. How to solve it?
3. Demo  

#### Adding new feature
Implement search videos action
1. Implement the action
2. Demo
