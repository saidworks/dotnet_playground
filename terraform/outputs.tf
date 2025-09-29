output "resource_group_name" {
  description = "Name of the resource group."
  value       = azurerm_resource_group.rg.name
}

output "app_service_plan_id" {
  description = "ID of the App Service plan."
  value       = azurerm_service_plan.plan.id
}

output "web_app_name" {
  description = "Name of the created Linux Web App."
  value       = azurerm_linux_web_app.app.name
}

output "web_app_url" {
  description = "Primary URL of the Linux Web App."
  value       = "https://${azurerm_linux_web_app.app.default_hostname}"
}