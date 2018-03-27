Vehicle Service
This service is designed to perform sample CRUD operation on Vehicles.

URL: http://localhost:60664/api/v1/

Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

Clone/Download the code into a folder.
Find and Edit the line of Applicationhost.config file present in root directory ~\VehicleService\.vs\config to below line.
   <add name="ExtensionlessUrl-Integrated-4.0" path="*." verb="GET,HEAD,POST,DEBUG,PUT,DELETE" type="System.Web.Handlers.TransferRequestHandler" preCondition="integratedMode,runtimeVersionv4.0" responseBufferLimit="0" />
Please run the Vehicles Services Project using Visual Studio.

This service implemented the following routes:
GET vehicles
GET vehicles/{id}
POST vehicles
PUT vehicles
DELETEvehicles/{id}

Prerequisites:
Software needed to run the Program
Visual Studio 2017


Running the tests
Please use test project to run all tests.

Versioning
v1 of API is used for current functionalities with CRUD operations.
v2 of API is designed to extend filtering.

Authors
Srinivas Jakkamsetty - Initial work

License
Open Project

Acknowledgments
