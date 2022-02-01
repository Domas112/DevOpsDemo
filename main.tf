provider "azurerm" {
	version = "2.94.0"
	features {}
}

terraform{
	backend "azurerm" {
		resource_group_name  	= "tfblobstorerg"
		storage_account_name 	= "tfstorageblobs"
		container_name 	      	= "tfstate"
		key 	   	      	= "terraform.tfstate"
	}
}

variable "imagebuild" {
	type = string
	description = "Latest Image Build"
}

resource "azurerm_resource_group" "tf_test" {
	name = "tfmainrg"
	location = "UK West"
}

resource "azurerm_container_group" "trcg_test" {
	name				= "devopsdemo"
	location			= azurerm_resource_group.tf_test.location
	resource_group_name = azurerm_resource_group.tf_test.name
	
	ip_address_type = "public"
	dns_name_label = "domas911dod"
	os_type = "Linux"

	container {
		name = "devopsdemo"
		image = "domas911/devopsdemo:${var.imagebuild}"
		cpu = "1"
		memory = "1"
		ports {
			port = 80
			protocol = "TCP"
		}
	}
}

