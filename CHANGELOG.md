# Changelog

All notable changes to this project will be documented in this file.

## [0.1.0] - 2026-03-15

### Added
- Initial SDK release
- OvationSDK singleton with DontDestroyOnLoad persistence
- OvationConfig ScriptableObject for drag-and-drop configuration
- Automatic anonymous player identity management via PlayerPrefs
- Achievement operations: list, get by slug, issue to player
- Player achievement history with auto-pagination
- Slot and equipment operations: list standard slots, equip/unequip assets
- Asset details fetching (read-only)
- Asset image downloading with disk-based LRU cache
- Offline queue for achievement issuance with retry and idempotency
- Dual API pattern: callback and async/await for all operations
- C# events: OnAchievementEarned, OnError, OnQueuedAchievementSynced
- Editor tools: custom config inspector, setup wizard
- link.xml for IL2CPP compatibility
- Unit tests for model deserialization
- Basic integration sample
