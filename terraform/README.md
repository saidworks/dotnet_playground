# Terraform IaC for SZFunction App Service

This directory contains a minimal Terraform configuration to provision an Azure App Service (Linux) for running the SZFunction .NET 9 application. It creates:

- Resource Group
- App Service Plan (Linux)
- Linux Web App configured for .NET 9

You can customize names via a small set of variables.


## Prerequisites
- Terraform >= 1.6
- Azure CLI (logged in with `az login` and the correct subscription selected)
- Sufficient permissions to create the listed resources in the target subscription


## Remote State with Azure Storage (Recommended)
Using remote state allows collaboration and locking. These steps create a storage account and container for storing Terraform state.

1) Choose values and export for convenience (replace placeholders):

```powershell
# PowerShell
$SubscriptionId = "<YOUR_SUBSCRIPTION_ID>"
$BackendRg      = "rg-tfstate"
$BackendLoc     = "eastus"
$StorageName    = "sttfstate<unique>"  # must be globally unique, 3-24 lowercase letters and numbers
$ContainerName  = "tfstate"

az account set --subscription $SubscriptionId
```

2) Create the backend resources:

```powershell
az group create -n $BackendRg -l $BackendLoc
az storage account create -g $BackendRg -n $StorageName -l $BackendLoc --sku Standard_LRS --encryption-services blob
az storage container create --account-name $StorageName --name $ContainerName
```

3) Configure the Terraform backend.

Option A — Inline backend block (edit providers.tf):

```hcl
terraform {
  backend "azurerm" {
    resource_group_name  = "rg-tfstate"
    storage_account_name = "sttfstate<unique>"
    container_name       = "tfstate"
    key                  = "szfunction/terraform.tfstate"
  }
}
```

Option B — Use -backend-config flags (keep providers.tf backend commented):

```powershell
terraform init `
  -backend-config="resource_group_name=$BackendRg" `
  -backend-config="storage_account_name=$StorageName" `
  -backend-config="container_name=$ContainerName" `
  -backend-config="key=szfunction/terraform.tfstate"
```

Notes:
- If your storage account requires Azure AD auth, you may need to set `ARM_USE_AZUREAD=true` in your environment for the AzureRM backend (Terraform 1.9+).
- Ensure you keep the state secure and back it up according to your policies.


## How to Use This Configuration

1) Initialize providers and (optionally) the backend:

```powershell
cd terraform
terraform init
```

2) Set variables. Create a file `terraform.tfvars` (or pass `-var` flags):

```hcl
prefix   = "szf-demo"   # used in names: szf-demo-rg, szf-demo-asp, szf-demo-szfunction
location = "eastus"
# app_service_sku = "B1"  # default
# tags = { env = "dev" }
```

3) Plan and apply:

```powershell
terraform plan -out plan.tfplan
terraform apply plan.tfplan
```

4) Outputs:
- `web_app_url` shows the default hostname (e.g., https://szf-demo-szfunction.azurewebsites.net)


## Variables
- `prefix` (required): short string used to build resource names. Must meet Azure naming rules.
- `location` (default: eastus): Azure region.
- `app_service_sku` (default: B1): App Service plan SKU.
- `tags` (map): Tags applied to all resources.
- `app_settings` (map): Extra App Settings for the Web App.


## Notes on Deployment of App Code
This Terraform config provisions infrastructure only. Deploy your built SZFunction artifacts using your existing GitHub Actions/Azure DevOps pipeline to the created Web App.
