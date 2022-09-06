# SupplyDrops
Help from the skies!

[Original Plugin](https://github.com/TheVoidNebula/SupplyDrops)

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)[![forthebadge](https://forthebadge.com/images/badges/makes-people-smile.svg)](https://forthebadge.com)

## What is this plugin?
_**Supplydrops**_ allows for a planned equipment drop from the **NTF Chopper / CI Car**. With that you can give humans a chance in the late game, when all of the items on the map are already being used.

## Features
* NTF Chopper? CI Car, which of them will bring the loot?
* Plan the Intervall on when Supplydrops happen
* Create your own Supply Types! (Like Medical Items, Ammo, Weapons!)
* Decide how high the chance for each item is
* Custom Item Support!

## Supported Languages 
* English
* German
* French (By `nath256#8390`)

## How to add new Languages
You have to either dm me on Discord, then I can explain it to you or you just create a pull request. (My Discord Account: `TheVoidNebula#5090`)

## Installation
1. [Install Synapse](https://github.com/SynapseSL/Synapse/wiki#hosting-guides)
2. Place the SupplyDrops.dll file that you can download [here](https://github.com/TheVoidNebula/SupplyDrops/releases) in your plugin directory
3. Restart/Start your server.

## Showcase
![A Supply Drop](/assets/SupplyDrop.png)
![Supply](/assets/supply.png)

## Item IDs

<details>
<summary>Ammunition</summary>

| Name | ID |
| --- | --- |
| Ammo12gauge | 19 |
| Ammo44cal | 27 |
| Ammo556x45 | 22 |
| Ammo762x39 | 28 |
| Ammo9x19 | 29 |
 
</details>

<details>
<summary>Weapons</summary>

| Name | ID |
| --- | --- |
| GunCOM18 | 13 |
| GunE11SR | 20 |
| GunCrossvec | 21 |
| GunFSP9 | 23 |
| GunLogicer |24 |
| GunRevolver | 39 |
| GunShotgun | 41 |
| GunAK | 40 |
| --- | |  
| MicroHID | 13 |
| GrenadeFlash | 26 |
| GrenadeHE | 25 |

</details>

<details>
<summary>Keycards</summary>

| Name | ID |
| --- | --- |
| KeycardO5 | 11 |
| KeycardFacilityManager | 9 |
| KeycardZoneManager | 3 |
| KeycardResearchCoordinator | 2 |
| KeycardContainmentEngineer | 6 |
| KeycardScientist | 1 |
| KeycardJanitor | 0 |
| KeycardNTFCommander | 8 |
| KeycardNTFLieutenant | 7 |
| KeycardNTFOfficer | 5 |
| KeycardGuard | 4 |
| KeycardChaosInsurgency | 10 |
 
</details>

<details>
<summary>Armors</summary>

| Name | ID |
| --- | --- |
| ArmorLight | 36 |
| ArmorCombat | 37 |
| ArmorHeavy | 38 |
 
</details>

<details>
<summary>Items</summary>

| Name | ID |
| --- | --- |
| Radio | 12 |
| Flashlight | 15 |
| Coin | 35 |
| --- | | 
| Medkit | 14 |
| Adrenaline | 33 |
| Painkillers | 34 |
| --- | | 
| SCP018 | 31 |
| SCP207 | 18 |
| SCP268 | 32 |
| SCP500 | 17 |

</details>

## Config
Name  | Type | Default | Description
------------ | ------------ | ------------- | ------------ 
`IsEnabled` | Boolean | true | Is this plugin enabled?
`MinPlayersForSupply` | Int | 4 | Minimum players for supply drops to happen
`IsOnlyHelicopter` | Boolean | true | Do you want that supplies only spawn via NTF Helicopter or do you want that the CI Car also can bring supplies?
`CiCarChance` | Int | 50 | The percentage that the CI Car brings in the supplies instead of the NTF Helicopter (requieres isOnlyHelicopter to be set to false)
`SupplyIntervall` | Float | 300 | The intervall in which the supply drops happen (in seconds)
`DoBroadcast` | Boolean | 300 | Should the players be notified via a Broadcast that a Supplydrop is happening?
`DoCassieAnnouncement` | Boolean | true | Should C.A.S.S.I.E announce the supply drop?
`CassieAnnouncement` | String | Supply has enter the facility | What should the C.A.S.S.I.E announcement be?

## Config.syml
```yml
[SupplyDrops]
{
# Decide what loot will spawn via the Supplydrops?
supplyDrops:
- supplyTypeName: <color=#00FF12>Medicial Items</color>
  supplyItems:
  - chance: 100
    amount: 4
    item:
      iD: 14
      durabillity: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
  - chance: 75
    amount: 4
    item:
      iD: 33
      durabillity: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
  - chance: 50
    amount: 2
    item:
      iD: 17
      durabillity: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
- supplyTypeName: <color=#140BFF>Weapons</color>
  supplyItems:
  - chance: 100
    amount: 1
    item:
      iD: 39
      durabillity: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
  - chance: 100
    amount: 2
    item:
      iD: 41
      durabillity: 0
      weaponAttachments: 0
      xSize: 1
      ySize: 1
      zSize: 1
# Should this Plugin be enabled?
isEnabled: true
# How many Players need to be on the server to start the supply timer cloak?
minPlayersForSupply: 4
# Should Supplydrops only arrive via the MTF Chopper?
isOnlyHelicopter: true
# If you have IsOnlyHelicopter on false, how high is the chance Supplydrops arrive via the CI car?
ciCarChance: 50
# What should the intervall be in what Supplydrops arrive (in seconds)
supplyIntervall: 300
# Where should Items from the MTF Chopper spawn?
mTFSpawnLocation:
  x: 180
  y: 993
  z: -58
# Where should Items from the CI Car spawn?
cISpawnLocation:
  x: 5
  y: 998
  z: -58
# Should there be a Broadcast when supply arrives?
doBroadcast: true
# Should there be a C.A.S.S.I.E Announcement when supply arrives?
doCassieAnnouncement: true
# What should the C.A.S.S.I.E Announcement be?
cassieAnnouncement: Supply has entered the facility
}
```
