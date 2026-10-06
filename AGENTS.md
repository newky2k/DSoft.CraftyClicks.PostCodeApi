# AGENTS.md

This file provides guidance to AI coding agents (Claude Code, Codex, Copilot and others) when working with code in this repository.

## Branching

- `development` is the working branch. **Every feature and bug fix goes to `development`**: branch from it and open pull requests into it. Never commit or open a pull request directly against `main`.
- `main` is the release branch. Every push to `main` runs `release.yml`, which publishes the package to nuget.org and creates a GitHub release, so only merge `development` into `main` when a release is intended, and only when asked to release.

## Overview

DSoft.Fetchify.Api.Client is a .NET client library for the Fetchify (formerly CraftyClicks) JSON APIs, published as the `DSoft.Fetchify.Api.Client` NuGet package. It currently implements the UK Postcode Lookup API (basic and rapid modes, with geocoding), with a factory for creating providers and `IServiceCollection` registration that uses `IHttpClientFactory`.

## Build & Test

The solution uses the `.slnx` format (the old `.sln` was removed):

```bash
dotnet restore DSoft.Fetchify.Api.Client.slnx
dotnet build DSoft.Fetchify.Api.Client.slnx -c Release
dotnet test UnitTests/UnitTests.csproj -c Release
```

- The library targets `netstandard2.0;net472;net8.0;net9.0`. `UnitTests` (MSTest) and `TestHarness` (console sample) target `net9.0`, so running the tests needs the .NET 9 runtime as well as the SDK.
- CI is GitHub Actions (`.github/workflows/`): `ci.yml` builds Release and runs the tests for pull requests into `main` or `development` and publishes nothing; `release.yml` runs on every push to `main` (changes only to Markdown or workflow files are skipped; run it by hand to test a workflow change), builds Release as `1.2.<yyMM>.<run number>` plus `RELEASE_SUFFIX` (empty for a stable version, set it to `-prerelease` in the workflow to publish a prerelease), runs the tests, uploads the package as the `drop` artifact, pushes it to nuget.org with Trusted Publishing (OIDC, `NUGET_USER` secret, `nuget` environment), then tags the commit `v<version>` and creates a GitHub release with the package attached.
- Assemblies are strong-named/signed (`DSoft.snk`); `Release` builds enable SourceLink (from the SDK) and pack the PDBs into the package. `GeneratePackageOnBuild` is on, so a Release build produces the `.nupkg` under `DSoft.Fetchify.Api.Client/bin/Release`.

## Shared build configuration

`Directory.Build.props` (root) centralizes signing, license, SourceLink and `NoWarn` for all projects. The `.csproj` only sets package id, description, release notes and TFMs. No project sets a version: the release workflow injects `/p:Version`, `/p:AssemblyVersion` and `/p:FileVersion`, so a local build produces a `1.0.0` package.

## Architecture

- `IPostCodeLookupProvider` / `PostCodeLookupProvider` — the UK postcode lookup client; the caller passes the API key and `AddressMode` (basic or rapid) per query. The internal `PostCodeLookupProviderOptions` only holds the endpoint URLs.
- `FetchifyProviderFactory` — creates providers without DI, over a shared static `HttpClient`.
- `Extensions/ServiceCollectionExtensions.cs` — `AddFetchifyProviders()` lives in the `Microsoft.Extensions.DependencyInjection` namespace so it surfaces on `IServiceCollection` without extra usings.
- `Models/Response/*` — the JSON response types (`System.Text.Json`); `Models/QueryResult.cs` and `Models/Address.cs` are the normalised results returned to callers.

## Conventions

- Target `development` for all changes; `main` is only ever updated by merging `development` for a release (see Branching).
- Do not add `Version`/`AssemblyVersion`/`FileVersion` to the `.csproj`; the version comes from `.github/workflows/release.yml`. Bump the `1.2` prefix there.
- Release notes live in `PackageReleaseNotes` in the `.csproj`.
- New public APIs need XML doc comments (`GenerateDocumentationFile` is on).
