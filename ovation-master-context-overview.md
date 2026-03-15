# OVATION — MASTER CONTEXT DOCUMENT
# Paste this at the start of any new conversation to resume work on Ovation.
# This document is maintained alongside the codebase and updated as the project evolves.
# A companion CODEBASE CONTEXT document covers the actual current state of the code.
# When both documents are available, read them together.

---

## WHO YOU ARE TALKING TO

Sam is the CTO of DayZero (ondayzero.com), an accounting SaaS platform competing with QuickBooks. Ovation is Sam's side project. Sam works primarily in Python on AWS backends with PostgreSQL. The Ovation API is built in FastAPI and deployed on AWS ECS Fargate. Sam uses Cursor IDE and Claude Code, works on a Mac with Apple Silicon, and uses GitHub for source control.

---

## WHAT OVATION IS

Ovation is a **universal achievement platform**. Any authority — a game studio, a brand, a social platform, a business — can issue achievements to people. Those achievements are portable: they belong to the person who earned them, travel with them across games and digital spaces, and can carry bound digital assets (badges, icons, titles, sprays, emojis).

The core insight is that achievements are currently siloed. A badge earned in one game means nothing outside that game. A streak on a fitness app disappears when you switch apps. Ovation is the layer that makes earned recognition persistent, portable, and composable — a reputation layer for the internet, starting with games.

**The long-term vision:** Real-world actions generate portable digital clout. Your track record in games, apps, and real life becomes a living passport that follows you everywhere and means something everywhere.

---

## CORE CONCEPTS

**Authority** — any entity that issues achievements. In Phase 1, authorities are game studios. Later they expand to brands, platforms, and businesses. Authorities define what can be earned and what it means.

**Achievement** — a milestone defined by an authority. Has metadata (name, description, rarity, hidden flag) and optionally bound digital assets. Achievements are issued to players via the SDK or API. They use slug-based identifiers (immutable after creation) so game code can reference them safely.

**Asset** — a digital file (image or audio) or text content bound to a specific slot. Each asset belongs to exactly one slot, which determines its type (`image`, `text`, or `audio`) and all validation rules (dimensions, file formats, max size, transparency). Assets are versioned — uploading a new file creates a new version while preserving the old ones. Assets are hosted on Ovation's S3/CDN and travel with the achievement wherever it goes. Using assets is optional — studios can start with metadata-only achievements and add assets later.

**Slot** — a global customization point defined by Ovation (not per-authority). Slots define where and how assets can be displayed in a game. Authorities opt in to which slots their game supports via the dashboard. Each slot carries full specifications: required dimensions, accepted file formats, max file size, transparency rules, and guidance text for both asset creators and game developers implementing the slot.

**Standard Phase 1 Slots:**

| Slot | Type | Dimensions | Max Size | Key Detail |
|------|------|-----------|----------|------------|
| `badge` | image | 512x512 | 256KB | Transparent bg required. Universal — every game can display a badge. |
| `nameplate_title` | text | — | — | Max 24 chars. No file upload — text is the asset. |
| `profile_banner` | image | 1200x400 | 512KB | No transparency (background fill). 3:1 aspect ratio. |
| `avatar_frame` | image | 256x256 (inner 192x192) | 128KB | Transparent center for avatar compositing. 32px border. |
| `player_icon` | image | 256x256 | 128KB | Small icon for gameplay UI (kill feed, scoreboard, minimap). |
| `emoji` | image | 128x128 | 64KB | Transparent bg required. For chat, reactions, quick-comms. |
| `spray` | image | 512x512 | 256KB | Image players place in the game world (decals, tags). |

**Ovation Identity / Passport** — a player's portable record of everything they've earned across all games and authorities. Not visible to players in Phase 1 (it's being built silently). Becomes the core product in Phase 2 when the player-facing app launches.

---

## HOW THE SDK WORKS

### The Developer Experience

Ovation is designed to be simple to start and powerful as you grow. A studio can go from zero to issuing their first achievement in under an hour, without changing their game's architecture. As they get more comfortable, they can unlock asset binding, slot configuration, server-side verification, and custom UI.

**The minimal integration looks like this:**

1. The studio registers as an authority on the Ovation portal and gets an API key.
2. They drop the Ovation Unity SDK package into their project.
3. They initialize the SDK with their API key (fetched from their own backend — never embedded in the game binary).
4. They call a single method wherever an achievement should fire:
   ```
   Ovation.Unlock("first-blood");
   ```
5. That's it. The achievement is issued, recorded, and attached to the player's anonymous Ovation identity.

**As they go deeper, they can:**
- Bind digital assets to achievements (badges, icons, titles, sprays)
- Enable standard slots their game supports so players can equip earned assets
- Use server-confirmed issuance for anti-cheat (the studio's backend calls the Ovation API directly, not the client)
- Override the default Ovation UI with their own prefabs
- Listen to SDK events (`OnAchievementUnlocked`, `OnAssetReady`, etc.) to build custom reactions
- Display a player's full Trophy Case — achievements earned across all Ovation-connected games

### Player Identity in Phase 1

In Phase 1, the SDK generates an anonymous device-scoped Ovation ID for each player. No login required. No player-facing UI unless the studio opts in. Achievements are quietly accumulated against this anonymous identity. When Phase 2 launches and players can create Ovation accounts, they can claim their anonymous history and it all carries over.

### Offline Support

The SDK queues achievements locally when there's no internet connection and syncs them when connectivity is restored. No achievements are lost.

### API Key Security

The studio's API key is never embedded in the game binary. Studios fetch it from their own backend at runtime. This is a requirement, not a recommendation — it's enforced in the SDK design.

---

## VALUE PROPOSITIONS BY PARTY

### Indie Game Studios (Phase 1)

**The problem they have:** Building an achievement system from scratch takes weeks — database, UI, logic, persistence. Most indie studios either skip it entirely or build something basic that only lives inside their game and means nothing outside it.

**What Ovation gives them:**
- A complete, production-grade achievement system in under an hour
- Free. No cost to integrate in Phase 1.
- Works with their existing game without architectural changes
- Optional asset system: they can ship metadata-only achievements now and add visual assets whenever they're ready
- Cross-game portability built in — their achievements mean something beyond their game, which is a selling point they can market to players
- Default UI included — toast notifications, save-to-Ovation prompts, Trophy Case panel — all overridable if they want custom look and feel
- As the Ovation network grows, their game's achievements become part of a larger ecosystem that players are already invested in

**The pitch:** Stop building achievement infrastructure. Ship faster. Your players' progress means something beyond your game.

### Players / Gamers (Phase 1 — built silently on their behalf)

Players don't know Ovation exists in Phase 1, but something real is being built for them. Every achievement they earn in an Ovation-connected game is quietly recorded to a portable identity. They're accumulating a record of their gaming history across every game in the network, without knowing it.

When Phase 2 launches, players will be able to claim that history. Everything they earned before the app existed will be there waiting for them. The promise to players is retroactive — they get credit for the past, not just going forward.

**The problem being solved for them:** Gaming accomplishments are ephemeral and siloed. Hours invested in a game produce nothing portable. Ovation is building the layer that makes that investment matter beyond the game it was earned in.

### Larger Studios (Phase 3)

**What changes:** Scale, asset quality, and compositing. Larger studios bring 3D assets, more complex slot configurations (weapon skins, character skins, loading screens, audio), and a player base that already has Ovation identities. The integration is the same SDK; the asset pipeline gets richer. Studios at this scale also get analytics, more granular achievement configuration, and a network effect benefit — their players are already Ovation users who care about their passport.

### Real-World Brands (Phase 4)

**The problem they have:** Loyalty programs are tired. Points are boring. Brands want to reach younger audiences where they actually spend time — in games and digital spaces — and they want to do it in a way that feels native, not like an ad.

**What Ovation gives them:** The ability to issue achievements for real-world actions that show up in games. Buy a Taco Bell combo, unlock a rare spray you can tag in three different games. The brand gets a distribution channel that reaches players where they play. The player gets something they actually want. The studio gets a brand partner whose assets enrich their game.

**Why this works:** Because Ovation already has the player identities, the asset pipeline, and the studio relationships. Brands don't need to build any of that. They plug into a network that already exists.

### Social Platforms (Phase 4)

Social platforms become part of Ovation in two ways — as **display surfaces** and as **authorities**.

**As display surfaces (Clout Surfaces):** Platforms like X, Instagram, and Discord become places where players flex their Ovation achievements. A player's passport can be surfaced on their profile, in their bio, in posts. The platform gets richer profile content; the player gets a new way to show who they are.

**As credibility surfaces:** Platforms like Strava, Airbnb, and GitHub don't traffic in clout — they traffic in trust. A Strava achievement showing 500 marathons completed, surfaced on an Airbnb host profile, means something. Ovation provides the standard; the platform provides the context.

**As authorities:** Platforms can also issue their own achievements. GitHub could issue an achievement for hitting 10,000 stars on a repo. Strava could issue one for a sub-3-hour marathon. Those achievements join the player's passport alongside their gaming history.

---

## PRODUCT PHASES (SUMMARY)

**Phase 1 — Free SDK, indie game studios, invisible to players.** Build the network. Get achievements flowing. Plant the anonymous identity seeds that become player passports in Phase 2.

**Phase 2 — Player-facing mobile app, Ovation Identity/Passport.** Players can now see and claim their history. Cross-game achievement feed, trophy case, profile. Anonymous Phase 1 identities get claimed and unified.

**Phase 3 — Larger studios, 3D assets, achievement compositing.** Richer asset pipeline, more complex slot systems (weapon skins, character skins, loading screens, audio slots), studio analytics dashboard. The network has enough players that larger studios want in.

**Phase 4 — Real-world brands + Social Layer.** Brands issue achievements for real-world actions. Social platforms become display surfaces and authorities. Ovation becomes something bigger than games.

**Phase 5 — Monetization.** Enterprise tier for large studios and brands. Authority marketplace where players can discover new games and experiences through achievement collections.

**Phase 6 — Scale.**

---

## PHASE 1 GTM STRATEGY

- **Timeline:** 3–6 months, zero budget, founder-led
- **Launch:** Simultaneous Hacker News Show HN + r/gamedev post. Steam importer is the hero feature.
- **Target metrics:** 75 studios and 20 shipped games at 6 months, 75K achievements issued
- **Highest-ROI channel:** Game jams (Ludum Dare etc.) — captive audience of developers building games on a deadline who need exactly what Ovation provides
- **Other channels:** Direct outreach (10 DMs/day), Discord communities, YouTube tutorials, building-in-public on X, GDC/PAX Dev
- **Month 3:** Studio referral program
- **Not doing in Phase 1:** Paid ads, press outreach, Product Hunt (saving for when there's a studio army behind the launch)

---

## OPEN QUESTIONS

Unresolved design decisions that need answers before or during Phase 2:

1. **Account claim flow:** When an anonymous Phase 1 player creates an Ovation account in Phase 2, does the anonymous ID become an alias of the real account, or is it deprecated? How does the SDK notify the game that a claim happened?
2. **Asset version locking:** When an authority updates an asset, do players who already earned it get the new version automatically, or can they opt to keep what they earned?
3. **Cross-authority player reads:** If one authority wants to read a player's achievements from another authority, what is the security and permission model?
4. **Player ID enumeration:** The current player ID scheme may be enumerable. Needs a review before public API exposure.
5. **Console SDK packaging:** PlayStation, Xbox, and Switch each require separate packaging. Not part of Phase 1. Separate future effort.
6. **Phase 2 identity handoff:** The full UX and technical design for the anonymous-to-authenticated identity transition has not been designed yet.

---

## WHAT HAS BEEN BUILT (SUMMARY)

The Ovation platform is fully built and deployed to the dev environment. This includes:

- **API backend** — full REST API (FastAPI, Python 3.12) with all core endpoints: authorities, achievements, players, assets, slots, webhooks, user auth, portal, admin
- **Authority portal** — customer-facing Next.js web app (dev.app.ovation.games) where studios register, manage achievements, upload assets, configure slots, invite team members
- **Admin dashboard** — internal Next.js web app (dev.admin.ovation.games) for platform-wide management (Sam only, Google OAuth)
- **Database** — PostgreSQL 15 with 18 tables, complete schema, and migrations running automatically on deploy
- **Asset system** — slot-based assets with full specifications (dimensions, formats, file size limits, transparency rules, guidance text). 7 standard Phase 1 slots seeded. Assets are versioned and stored in S3.
- **Team management** — multi-user authorities with role-based access (owner, admin, member, viewer) and email invitations
- **Webhooks** — real-time event delivery with HMAC signing, retry logic, and health monitoring
- **AWS infrastructure** — ECS Fargate (3 services: API, admin, portal), ALB with host-based routing, RDS, S3, Secrets Manager, all managed via Terraform
- **CI/CD** — GitHub Actions with OIDC auth: pushing to `dev` auto-deploys; PR checks run tests and builds
- **Documentation** — `docs/` directory covering architecture, API, database, infrastructure, deployment, and testing

The prod environment infrastructure is written but not yet deployed. It will be applied when ready for launch.

The Unity SDK has a complete spec but has not been built yet.

---

## WHAT TO BUILD NEXT

In rough priority order:

1. **Unity SDK** — spec is complete, implementation not started
2. **Phase 1 launch** — Hacker News + r/gamedev, Steam importer as hero feature
3. **Prod deployment** — apply prod infrastructure, configure secrets, enable prod CI/CD when ready for launch
