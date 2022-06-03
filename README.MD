
A simple code to start using the Azure Table Storage using .net6.

# How to use
Execute the terraform script in order to create the table storage in your Azure account:

    terraform plan
    terraform apply
Set the connectionString variable with one of the connection string available in the created Storage Account.

    dotnet run

After testing, do not forget to destroy your testing environment on Azure running:

    terraform destroy

# References
https://code-maze.com/azure-table-storage-aspnetcore/
https://docs.microsoft.com/en-us/azure/storage/tables/table-storage-overview
https://devblogs.microsoft.com/azure-sdk/announcing-the-new-azure-data-tables-libraries/

# terraform

https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/storage_table
https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/storage_table_entity