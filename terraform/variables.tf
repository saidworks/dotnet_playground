variable "prefix" {
  description = "Prefix used for naming Azure resources (must be 2-20 alphanumeric characters)."
  type        = string
}

variable "location" {
  description = "Azure region for all resources."
  type        = string
  default     = "eastus"
}

variable "app_service_sku" {
  description = "App Service Plan SKU (e.g., F1, B1, P1v3)."
  type        = string
  default     = "B1"
}

variable "tags" {
  description = "Tags to apply to all resources."
  type        = map(string)
  default     = {
    project = "SZFunction"
    iac     = "terraform"
  }
}

variable "app_settings" {
  description = "Additional application settings to add to the Web App."
  type        = map(string)
  default     = {}
}
