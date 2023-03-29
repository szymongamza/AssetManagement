![example workflow](https://github.com/szymongamza/InventoryUniversity/actions/workflows/dotnet.yml/badge.svg)

This project is for asset management in university. Knowing where is which machine or research equipment, have access to important information about it, when it was purchased and when maintenance is needed.

It is build on .NET 7
# Used Archictecture: Clean Architecture
It's simplified clean architecture as it is small project.

# Used technology:
:heavy_check_mark: Entity Framework  
:heavy_check_mark: Swagger  
:heavy_check_mark: AutoMapper  
:heavy_check_mark: MVC  
:heavy_check_mark: Bootstrap-Multiselect  

# Will be used:
:x: Docker  
:x: Quartz  
:x: xUnit  
:x: MailKit  

# Actual schedule (may change while coding):
:heavy_check_mark: Craete Domain  
:heavy_check_mark: Create Infrastructure  
:heavy_check_mark: Create Database  
:heavy_check_mark: Create GenericRepository  
:heavy_check_mark: Create Faculty Controller  
:heavy_check_mark: Create Department Controller  
:heavy_check_mark: Create Building Controller  
:x: Create Room Controller  
:x: Create Manufacturer Controller  
:x: Create Asset Controller  
:x: Create Maintenance Controller  
:x: Web UI for managment of app and infrastructure  
:x: EmailSender service  
:x: Scheduler service to check everyday (Quartz?) if email should be sent(API call db?). If so, It will prepare email and send it to EmailSender  
:x: Real SQL Database - Drop Sqlite aproach  
:x: Web QR code generator base on product GUID (call printing from web?)  
:x: Mobile App that scan QR codes and make request to API  
:x: Add Person/User model, for emails and for future Authentication  
