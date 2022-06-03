
A simple code to start using the Azure Table Storage using .net6.

# How to use
Execute the terraform script in order to create the table storage in your Azure account:

    terraform plan
    terraform apply
Set the connectionString variable with one of the connection string available in the created Storage Account.

    dotnet run

After testing, do not forget to destroy your testing environment on Azure running:

    terraform destroy


# I don't have an Azure Account
If you don't have an Azure account, you can test using the [Azurite Emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio). In this case you don't have to use the terraform script.
# References
https://code-maze.com/azure-table-storage-aspnetcore/

https://docs.microsoft.com/en-us/azure/storage/tables/table-storage-overview

https://devblogs.microsoft.com/azure-sdk/announcing-the-new-azure-data-tables-libraries/

https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/storage_table

https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/storage_table_entity