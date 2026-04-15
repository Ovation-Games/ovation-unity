# Contributing to the Ovation Unity SDK

Thanks for your interest in contributing to the Ovation Unity SDK! This document explains how to get involved, what we look for in contributions, and how to submit changes.

## Code of Conduct

This project follows the [Contributor Covenant Code of Conduct](https://www.contributor-covenant.org/version/2/1/code_of_conduct/). By participating, you are expected to uphold this code. Please report unacceptable behavior to sam@ovation.games.

## How to Contribute

### Reporting Bugs

Open a [GitHub Issue](https://github.com/ovation-games/ovation-unity/issues) with:

- Unity version and platform (Windows, macOS, Android, iOS, etc.)
- Steps to reproduce
- Expected vs. actual behavior
- Relevant logs (check the Unity Console for `[Ovation]` prefixed messages)

### Suggesting Features

Open an issue describing the use case and why it would benefit SDK users. For larger ideas, email sam@ovation.games first to discuss before investing time on an implementation.

### Submitting Code

1. **Open an issue first** for anything beyond a trivial fix. This avoids duplicate work and lets us align on approach.
2. **Create a feature branch** from `main` (e.g., `fix/offline-queue-retry`, `feat/custom-toast-themes`).
3. **Make your changes** following the guidelines below.
4. **Open a pull request** against `main` with a clear description of what changed and why.

## What We're Looking For

**Encouraged:**

- Bug fixes
- UI themes and toast customization options
- Documentation improvements
- Test coverage for untested code paths
- Performance improvements

**Discouraged:**

- Changes that add complexity for the end developer integrating the SDK. The core value of Ovation is that integration is fast and simple (`OvationSDK.Unlock("slug")` and you're done). Contributions should preserve that simplicity.
- Adding new package dependencies unless absolutely necessary
- Breaking changes to the public API surface

## Development Setup

### Requirements

- **Unity 2022.3 LTS** (this is the minimum supported version; test against it)
- **Git**
- **.NET 8+** (for integration tests)

### Getting Started

1. Clone the repo:
   ```bash
   git clone https://github.com/ovation-games/ovation-unity.git
   ```
2. Open the project in Unity 2022.3 LTS or add the package to an existing project via the Unity Package Manager (local path).
3. Verify the project compiles without errors.

### Running Tests

**Unit tests** (no API key required):

Open the Unity Test Runner (`Window > General > Test Runner`) and run both Editor and Play Mode tests.

**Integration tests** (requires API key):

```bash
cd Tests/Integration~/
cp test-config.example.json test-config.json
# Add your ovn_test_* API key to test-config.json
dotnet test
```

Integration tests run against the live API without Unity. You'll need a test-mode API key from the [Ovation Authority Portal](https://app.ovation.games).

**All tests must pass before submitting a PR.**

## Coding Guidelines

### Style

- **Namespaces:** Follow the existing structure (`Ovation`, `Ovation.Api`, `Ovation.Models`, etc.)
- **Private fields:** `_camelCase` with underscore prefix
- **Public properties/methods:** `PascalCase`
- **Copyright header** on all new source files:
  ```csharp
  // Copyright (c) 2026 Ovation Games. MIT License. See LICENSE for details.
  ```

### XML Documentation

All public APIs (classes, methods, properties, events) must have XML doc comments. These power IntelliSense tooltips for developers consuming the SDK, and are the primary way game developers discover how the API works.

```csharp
/// <summary>
/// Brief description of what this does.
/// </summary>
/// <param name="slug">The achievement slug to unlock.</param>
/// <returns>The issuance result.</returns>
public async Task<IssueAchievementResult> IssueAchievementAsync(string slug)
```

Internal and private members do not require XML docs.

### Commit Messages

Use [Conventional Commits](https://www.conventionalcommits.org/):

```
feat: add custom color support to achievement toast
fix: offline queue not flushing after reconnect
docs: clarify setup wizard instructions
test: add edge case coverage for asset cache eviction
```

### Unity Compatibility

- Target **Unity 2022.3 LTS** as the minimum supported version.
- Do not use APIs introduced in Unity 2023+ or Unity 6 without `#if` version guards.
- Do not add dependencies on render pipelines (URP/HDRP), ECS, Burst, or other optional Unity packages.

### Design Principles

- **Simplicity first.** The SDK should feel effortless to integrate. If a feature requires the game developer to understand complex setup or configuration, rethink the approach.
- **Offline-resilient.** Assume the player might not have network access. Anything that touches the API should degrade gracefully.
- **Dual API pattern.** Public methods should support both callback and async/await styles where applicable.

## Pull Request Process

1. Ensure all unit and integration tests pass.
2. Update `CHANGELOG.md` under an `[Unreleased]` section if your change is user-facing.
3. Keep PRs focused. One logical change per PR.
4. PRs are reviewed by the maintainer ([@samparks](https://github.com/samparks)). Expect feedback within a few business days.

## Questions?

Email sam@ovation.games or open a GitHub Issue. We're happy to help you get started.

## License

By contributing, you agree that your contributions will be licensed under the [MIT License](LICENSE) that covers this project.
