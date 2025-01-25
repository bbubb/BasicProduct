# BasicProduct API

## Overview
BasicProduct API is a simple product management API built with ASP.NET Core. It allows you to create, read, update, and delete products.

## Setup Instructions
1. Clone the repository:
	git clone https://github.com/bbubb/BasicProduct.git

2. Navigate to the project directory:
	cd BasicProduct

3. Build the project:
	dotnet build   

4. Run the project:
	dotnet run
	
## API Endpoints
### Get All Products
- **URL**: `/api/products`
- **Method**: `GET`
- **Response**: `200 OK` with a list of products

### Get Product by GUID
- **URL**: `/api/products/{guid}`
- **Method**: `GET`
- **Response**: `200 OK` with the product details or `404 Not Found` if the product does not exist

### Create Product
- **URL**: `/api/products`
- **Method**: `POST`
- **Request Body**: `ProductCreateRequestDto`
- **Response**: `201 Created` with the created product details

### Update Product
- **URL**: `/api/products/{guid}`
- **Method**: `PUT`
- **Request Body**: `ProductUpdateRequestDto`
- **Response**: `200 OK` with the updated product details or `404 Not Found` if the product does not exist

### Delete Product
- **URL**: `/api/products/{guid}`
- **Method**: `DELETE`
- **Response**: `204 No Content` or `404 Not Found` if the product does not exist


