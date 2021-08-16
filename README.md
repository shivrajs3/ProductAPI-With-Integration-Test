

To set up the project:

* Open project in VS.
* Restore nuget packages and rebuild.
* Run the project.


Refactor product API project using with following changes -
1. Configured Swagger UI to make requests-
  * Run the project.- once up just append /swagger it will open swagger UI eg. http://localhost:58123/swagger/ui/index#/Products
2. Used Entity Framework to connect with database and perform all CRUD operations
3. Used dependency injection using Unity
4. Created dto and model separately and used Automapper for mapping those models
5. Added TDD unit test cases for Controller and ProductServices
   * Go to menu Test -> Text Explorer and run test cases
6. Read connection string from Web. config file using dbcontext.


We could integrate below things -

1. Apply Authentication and Authorization using JWT token
2. We can handle application logging using Ilogger 
3. We can add middleware to handle all errors
4. We can add BDD api automation testing framework to cover all e2e and functional test.


## Instructions


There should be these endpoints:

1. `GET /products` - gets all products.
2. `GET /products?name={name}` - finds all products matching the specified name.
3. `GET /products/{id}` - gets the project that matches the specified ID - ID is a GUID.
4. `POST /products` - creates a new product.
5. `PUT /products/{id}` - updates a product.
6. `DELETE /products/{id}` - deletes a product and its options.
7. `GET /products/{id}/options` - finds all options for a specified product.
8. `GET /products/{id}/options/{optionId}` - finds the specified product option for the specified product.
9. `POST /products/{id}/options` - adds a new product option to the specified product.
10. `PUT /products/{id}/options/{optionId}` - updates the specified product option.
11. `DELETE /products/{id}/options/{optionId}` - deletes the specified product option.

All models are specified in the `/Models` folder, but should conform to:

**Product:**
```
{
  "Id": "01234567-89ab-cdef-0123-456789abcdef",
  "Name": "Product name",
  "Description": "Product description",
  "Price": 123.45,
  "DeliveryPrice": 12.34
}
```

**Products:**
```
{
  "Items": [
    {
      // product
    },
    {
      // product
    }
  ]
}
```

**Product Option:**
```
{
  "Id": "01234567-89ab-cdef-0123-456789abcdef",
  "Name": "Product name",
  "Description": "Product description"
}
```

**Product Options:**
```
{
  "Items": [
    {
      // product option
    },
    {
      // product option
    }
  ]
}
```
