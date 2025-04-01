# Odata POC

# Connection string name: otipdbconn
# When deploy to Azure make sure to add connection string configuration with name: otipdbconn

# Enable Entity Framework
# Right click ODataApi project in visual studio to open terminal
# execute
# dotnet tool install --global dotnet-ef
# To create EF model in Model folder 
# dotnet ef dbcontext scaffold "Name=ConnectionStrings:otipdbconn" Microsoft.EntityFrameworkCore.SqlServer -o Models -c OtipDbContext --use-database-names
# The option --use-database-names retains the exact column names in the table. If used the column named Customer.customer_id will result in Customer.customer_id. Omitting the option will result in Customer.CustomerId property generated in the EF model.

# Query example
# GET https://localhost:7150/odata/$metadata
# GET https://localhost:7150/odata/Customer
# GET https://localhost:7150/odata/order
# GET https://localhost:7150/odata/Customer?$filter=id eq 1 or Id eq 3&$orderby=name desc
# GET https://localhost:7150/odata/Customer?$filter=id eq 1 or id eq 3&$orderby=name desc&$expand=orders
# GET https://localhost:7150/odata/getordersbycustomer(customerId=2)
