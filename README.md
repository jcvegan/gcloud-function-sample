# .Net Core 3.1 Google Cloud Function

The purpose of this project is to show how to develop and deploy a Google Cloud Function using .Net Core 3.1 for development and Terraform for deploying.

This project is using the template provided by Google.
For installing the template, open your terminal and execute the following command:

```bash
dotnet new -i Google.Cloud.Functions.Templates
```

## Requirements

Before you start, make sure you meet these requirements:

- Having installed the `gcloud` command tool.
- Having installed the `terraform` coomand tool.
- On Google Cloud having an empty project.

## Running the sample

Follow these steps:

1. Checkout this repository.
2. Rename the file `terraform.tfvars.sample` to `terraform.tfvars`.
3. Update the values on the file `terraform.tfvars`: `project_name`, `project_region`, `project_zone`.
4. Login to your google account running the command `gcloud auth application-default login`
5. Run the command `terraform init`
6. Run the command `terraform plan` and review the plan execution.
7. Run the command `terraform apply` and then type `yes` when the console request the confirmation.