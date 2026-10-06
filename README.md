# DSoft.Fetchify.Api.Client

Client library for Fetchify (Formerly CraftyClicks) JSON APIs.

`DSoft.Fetchify.Api.Client currently implements providers for the following APIs

- UK Postcode Lookup
  - Basic and Rapid Modes with Geocoding

## Features
 - Factory for creating instances of the providers
 - Dependency injection support with `IHttpClientFactory` support


## Building and releasing

Builds run on GitHub Actions:

* `.github/workflows/ci.yml` validates every pull request into `main` or `development`: it builds Release and runs the tests, and publishes nothing.
* `.github/workflows/release.yml` runs on every push to `main` (or manually from the Actions tab). It builds, tests, pushes the package to nuget.org as `1.2.<yyMM>.<run number>`, then tags the commit and creates a GitHub release with the package attached. Set `RELEASE_SUFFIX` (e.g. `-prerelease`) to publish a prerelease.

Publishing uses [NuGet trusted publishing](https://learn.microsoft.com/nuget/nuget-org/trusted-publishing), so no API key is stored: the nuget.org policy trusts workflow `release.yml` in environment `nuget`, and the `NUGET_USER` secret holds the nuget.org profile name.
