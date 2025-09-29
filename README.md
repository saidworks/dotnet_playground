# Azure Deployment with GitHub Actions

This repository uses GitHub Actions to build and deploy directly to Azure.

## Prerequisites

### 1. Azure Resources
- Ensure you have an Azure Web App (or other resource) created to deploy to
- Note the name of your resource (app-name)

### 2. Authentication Setup

#### Option A: Using a Service Principal (recommended for most cases)
1. Create a service principal with contributor permissions:
   ```bash
   az ad sp create-for-rbac --name "github-action-sp" --role contributor \
                            --scopes /subscriptions/{subscription-id}/resourceGroups/{resource-group} \
                            --sdk-auth
   ```
2. Copy the entire JSON output

3. In your GitHub repository:
    - Go to Settings > Secrets and variables > Actions
    - Create a new repository secret named `AZURE_CREDENTIALS`
    - Paste the entire JSON output as the value

#### Option B: Using Managed Identity (for GitHub-hosted runners with federated credentials)
1. Create a user-assigned managed identity in Azure
2. Assign it appropriate permissions to your resource group
3. Create federated credentials for GitHub Actions
4. Add the following secrets to your GitHub repository:
    - `AZURE_CLIENT_ID`: The managed identity client ID
    - `AZURE_TENANT_ID`: Your Azure tenant ID
    - `AZURE_SUBSCRIPTION_ID`: Your Azure subscription ID

### 3. GitHub Actions Configuration
- Update the workflow file (.github/workflows/azure-deploy.yml) with:
    - Your specific application name in the `app-name` parameter
    - The appropriate authentication method
    - Any additional deployment parameters specific to your resource type

## Deployment

The deployment workflow will automatically run when:
- Code is pushed to the main branch
- The workflow is manually triggered from the Actions tab

## Troubleshooting

- Check the GitHub Actions logs for detailed error messages
- Verify that your service principal has the correct permissions
- Ensure that your application builds correctly locally before deployment