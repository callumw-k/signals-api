## API with SQL Backend.
I recently found an app that releases crypto "signals" (buy and sell targets for different coins) that seemed relatively profitable. However, I wanted a way to automate the trading of these signals.
With the application limited to mobile devices and having no API endpoint, I built an API using C#, connected to an MSSQL database. 
I then use Tasker to read the notifications as they're published and then post the data to the API endpoint.
A python script runs inside a docker container, retrieves the data from the endpoint every minute and executes trades via the Binance (a crypto exchange) API.

## Todos
- [ ] Add a "retrieve ten" endpoint that will only retrieve the last ten signals from the database
- [ ] Build a Node.js version of the API (for experience)
