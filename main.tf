locals {
  environment = terraform.workspace
  project     = var.project_name["${terraform.workspace}"]
}

provider "google" {
  project = local.project
  region  = var.project_region
  zone    = var.project_zone
}

resource "google_project_service" "main_project_cloud_functions" {
  project = local.project
  service = "cloudfunctions.googleapis.com"
}

resource "google_project_service" "main_project_cloud_build" {
  project = local.project
  service = "cloudbuild.googleapis.com"
}

resource "google_pubsub_topic" "main_pubsub" {
  name = "test-${local.environment}-pubsub"
  message_storage_policy {
    allowed_persistence_regions = [var.project_region]
  }
  depends_on = [
    google_project_service.main_project_cloud_functions
  ]
}

resource "google_storage_bucket" "function_bucket" {
  name     = "function-test-${local.environment}"
  location = var.project_region
}

data "archive_file" "source" {
  type        = "zip"
  source_dir  = "scripts/src/Samples.Functions.EventBased"
  output_path = "/tmp/function.zip"
}

resource "google_storage_bucket_object" "source_zip" {
  source       = data.archive_file.source.output_path
  content_type = "application/zip"
  bucket       = google_storage_bucket.function_bucket.name

  name = "src-${data.archive_file.source.output_md5}.zip"

  depends_on = [
    google_storage_bucket.function_bucket,
    data.archive_file.source
  ]
}

resource "google_cloudfunctions_function" "main_function" {
  name                  = "the-test-function-${local.environment}"
  runtime               = "dotnet3"
  available_memory_mb   = 512
  source_archive_bucket = google_storage_bucket.function_bucket.name
  source_archive_object = google_storage_bucket_object.source_zip.name
  entry_point = "Samples.Functions.EventBased.Function"
  event_trigger {
    event_type = "google.pubsub.topic.publish"
    resource   = google_pubsub_topic.main_pubsub.name
  }
  depends_on = [
    google_storage_bucket.function_bucket, # declared in `storage.tf`
    google_storage_bucket_object.source_zip,
    google_project_service.main_project_cloud_functions,
    google_project_service.main_project_cloud_build
  ]
}

resource "google_cloudfunctions_function_iam_member" "invoker" {
  project        = google_cloudfunctions_function.main_function.project
  region         = google_cloudfunctions_function.main_function.region
  cloud_function = google_cloudfunctions_function.main_function.name

  role   = "roles/cloudfunctions.invoker"
  member = "allUsers"
}