terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
      version = "2.91.0"
    }
  }
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "example" {
  name     = "StorageTableTestVega01"
  location = "East US"
}

resource "azurerm_storage_account" "example" {
  name                     = "tablestoragevega01"
  resource_group_name      = azurerm_resource_group.example.name
  location                 = azurerm_resource_group.example.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_table" "example" {
  name                 = "progresstable"
  storage_account_name = azurerm_storage_account.example.name
}