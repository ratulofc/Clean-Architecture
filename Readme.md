To Create Migration on this project use [ dotnet ef migrations add "InitialCreate" --startup-project ../Ecommerce.Api ]
To Update Database use [ dotnet ef database update --startup-project ../Ecommerce.Api ]

how to use appsettings and appsettings.json seperetly??????????????????????? 35:40 chapter3 46:40(advance swagger start)
54:55 log start, error handeling start krte hobe....


{
  "Logging": {
    "LogLevel": {
      "Default": "Trace",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConStr": "server = RATUL\\RATUL; database = ratulDB; trusted_connection = true; TrustServerCertificate = True; Encrypt = False"
  },
  "AllowedHosts": "*"
}
