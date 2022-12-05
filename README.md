![example workflow](https://github.com/szymongamza/InventoryUniversity/actions/workflows/dotnet.yml/badge.svg)

This project is for asset management in university. Knowing where is which machine or research equipment, have access to important information about it, when it was purchased and when maintenance is needed.

It is build on .NET 6

# Used technology:
:heavy_check_mark: Docker  
:heavy_check_mark: Entity Framework  
:heavy_check_mark: Swagger  
:heavy_check_mark: Ocelot API Gateway  
:heavy_check_mark: xUnit  
:heavy_check_mark: MailKit  
:heavy_check_mark: AutoMapper

# Propably I will use also
:x: Quartz  
:x: Blazor / MVC  
:x: MAUI .NET

# Actual schedule (may change while coding):
:heavy_check_mark: Building API  
:heavy_check_mark: Building controller unit tests  
:heavy_check_mark: Room API  
:heavy_check_mark: Room controller unit tests  
:heavy_check_mark: Product API  
:heavy_check_mark: Product controller unit tests  
:heavy_check_mark: API Gateway  
:heavy_check_mark: Init Docker Compose  
:heavy_check_mark: Maintenance API for history of maintenances  
:heavy_check_mark: Maintenance controller unit tests  
:heavy_check_mark: EmailSender microservice with RabbitMQ subscription  
:x: Scheduler microservice to check everyday (Quartz?) if email should be sent(API call db?). If so, It will prepare email and send it to EmailSender via RabbitMQ  
:x: Add Person/User model, for emails and for future Authentication  
:x: Real SQL Database - Drop InMemory aproach  
:x: Configure Docker for only through API Gateway connections  
:x: Web UI for managment of app and infrastructure  
:x: Web QR code generator base on product GUID (call printing from web?)  
:x: Mobile App that scan QR codes and make request to API  
