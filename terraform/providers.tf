terraform {

  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 4.0"
    }
  }
    backend "azurerm" {
      resource_group_name  = "rg-devops"
      storage_account_name = "sztfstate2025"
      container_name       = "szinfra"
      key                  = "szfunction/terraform.tfstate"
    }
}

provider "azurerm" {
  subscription_id = "732ae626-931f-4283-96e2-e2ae0d6de45a"
  features {}
}