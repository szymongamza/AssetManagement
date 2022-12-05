![example workflow](https://github.com/szymongamza/InventoryUniversity/actions/workflows/dotnet.yml/badge.svg)

This project is for asset management in university. Knowing where is which machine or research equipment, have access to important information about it, when it was purchased and when maintenance is needed.

It is build on .NET 6


# Used technology:
- [x] Docker
- [x] Entity Framework
- [x] Swagger
- [x] Ocelot API Gateway
- [x] xUnit
- [x] MailKit
- [x] AutoMapper

# Propably I will use also
- [ ] Quartz
- [ ] Blazor / MVC
- [ ] MAUI .NET

# Actual schedule (may change while coding):
- [x] Building API
- [x] Building controller unit tests
- [x] Room API
- [x] Room controller unit tests
- [x] Product API
- [x] Product controller unit tests
- [x] API Gateway
- [x] Init Docker Compose
- [x] Maintenance API for history of maintenances
- [x] Maintenance controller unit tests
- [x] EmailSender microservice with RabbitMQ subscription
- [ ] Scheduler microservice to check everyday (Quartz?) if email should be sent(API call db?). If so, It will prepare email and send it to EmailSender via RabbitMQ.
- [ ] Add Person/User model, for emails and for future Authentication
- [ ] Real SQL Database - Drop InMemory aproach. 
- [ ] Configure Docker for only through API Gateway connections
- [ ] Web UI for managment of app and infrastructure.
- [ ] Web QR code generator base on product GUID (call printing from web?)
- [ ] Mobile App that scan QR codes and make request to API
