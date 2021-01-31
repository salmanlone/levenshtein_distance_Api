# levenshtein_distance_Api


## Description

This API is developed for assignment purpose to consume with front-end application.

## Instructions
- Download code
- Restore nbuget packages
- Build using VS 2019
- Run API which will open browser by itself
- Defaut UI is swagger

## Swagger
Swagger is integrated with this API so when running the project it will open swagger UI by default.

## Endpoint
- compute

## Endpoint params
- First input
- Second input
- Security Key

## Security Key
```
0f44443b-bb32-4d37-9f27-082cec554b6a
```
Security key is also provided in appSettings.json file.

## Return
```
{
FirstInput :string,
SecondInput :string,
Distance :int,
Matrix :int[,]
}
```

## Testing
Unit test project is also included. For running the test cases, go to test project and run tests in Test Explorer.
