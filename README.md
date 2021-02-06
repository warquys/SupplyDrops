# SupplyDrops
Help from the skies!

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

## Features
* Determine if the NTF Helicopter and CI Car bring in supply
* Determine how often supplies happen
* Determine what the supply is (you can even use custom Weapons like with the MoreTools Plugin)

## Installation
1. [Install Synapse](https://github.com/SynapseSL/Synapse/wiki#hosting-guides)
2. Place the SupplyDrops.dll file that you can download [here](https://github.com/TheVoidNebula/SupplyDrops/releases) in your plugin directory
3. Restart/Start your server.

## Showcase
![Chaos Insurgency Car](/assets/ci.png)
![NTF Chopper](/assets/ntfchopper.png)
![Supply](/assets/supply.png)

## Config
Name  | Type | Default | Description
------------ | ------------ | ------------- | ------------ 
`IsEnabled` | Boolean | true | Is this plugin enabled?
`MinPlayersForSupply` | Int | 4 | Minimum players for supply drops to happen
`IsOnlyHelicopter` | Boolean | true | Do you want that supplies only spawn via NTF Helicopter or do you want that the CI Car also can bring supplies?
`CiCarChance` | Int | 50 | The percentage that the CI Car brings in the supplies instead of the NTF Helicopter (requieres isOnlyHelicopter to be set to false)
`Items` | List | 14, 0, 0, 0, 1, 1, 1 #  1, 1, 1 | iD is basicly the item id (look up in the Synapse resources to find item ids; you can also use custom ids for custom items) durability if you use weapons you can set the ammo (if not just let it stay at 0) sight, barrel, other are only useful for weapons (you can set the attachments for weapons; if not just the value 0), X, Y, Z values are for the size of the weapon
`SupplyIntervall` | Float | 300 | The intervall in which the supply drops happen (in seconds)
`DoBroadcast` | Boolean | 300 | Should the players be notified via a Broadcast that a Supplydrop is happening?
`BroadcastDuration` | uInt | 15 | How long should the broadcast be?
`DoCassieAnnouncement` | Boolean | true | Should C.A.S.S.I.E announce the supply drop?
`BroadcastMessageCI` | String | A Supply drop has arrived via CI Car | What should the Broadcast be when the CI Car brings in supplies?
`BroadcastMessageMTF` | String | A Supply drop has arrived via NTF Helicopter | What should the Broadcast be when the NTF Helicopter brings in supplies?
`CassieAnnouncement` | String | Supply has enter the facility | What should the C.A.S.S.I.E announcement be?

## Config.yml
```yml
[SupplyDrops]
{
isEnabled: true
minPlayersForSupply: 4
isOnlyHelicopter: true
ciCarChance: 50
items:
- iD: 14
  durabillity: 0
  sight: 0
  barrel: 0
  other: 0
  xSize: 1
  ySize: 1
  zSize: 1
- iD: 14
  durabillity: 0
  sight: 0
  barrel: 0
  other: 0
  xSize: 1
  ySize: 1
  zSize: 1
- iD: 12
  durabillity: 0
  sight: 0
  barrel: 0
  other: 0
  xSize: 1
  ySize: 1
  zSize: 1
supplyIntervall: 300
doBroadcast: true
broadcastDuration: 15
doCassieAnnouncement: true
broadcastMessageCI: <b>A Supply drop has arrived via <color=#2EB800>CI Car</color></b>
broadcastMessageMTF: <b>A Supply drop has arrived via <color=#1F22C7>NTF Helicopter</color>!</b>
cassieAnnouncement: Supply has entered the facility
}
```
