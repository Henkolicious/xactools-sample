# Sample API

- Base URL: `http://localhost:6030` or change it to fit your needs
- Documentation: `<baseUrl>/`  or `<baseurl>/openapi/scalar` or `<baseUrl>/swagger`
- Health check endpoint: `<baseUrl>/health`

### Requirements

Dotnet SDK `9.0.203` (*currently the latest version*), can be found here: https://get.dot.net

or with docker

Docker from `src/`
1. `docker build -t <your-tag> .`
2. `docker run <your-tag> -p 6030:6030`