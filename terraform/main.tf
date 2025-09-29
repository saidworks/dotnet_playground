locals {
  # Ensure names are globally unique where required (e.g., web app name)
  # You can adjust the suffix strategy as needed
  rg_name        = "${var.prefix}-rg"
  plan_name      = "${var.prefix}-asp"
  webapp_name    = "${var.prefix}-szfunction"
}

resource "azurerm_resource_group" "rg" {
  name     = local.rg_name
  location = var.location
  tags     = var.tags
}

resource "azurerm_service_plan" "plan" {
  name                = local.plan_name
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  os_type             = "Linux"
  sku_name            = var.app_service_sku
  tags                = var.tags
}

resource "azurerm_linux_web_app" "app" {
  name                = local.webapp_name
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  service_plan_id     = azurerm_service_plan.plan.id
  https_only          = true
  tags                = var.tags

  site_config {
    always_on = true

    application_stack {
      dotnet_version = "9.0"
    }
  }

  app_settings = merge(
    {
      WEBSITE_RUN_FROM_PACKAGE = "1"
      # Add any default settings required by your app here
    },
    var.app_settings
  )
}
