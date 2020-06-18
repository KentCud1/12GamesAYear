using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////////////////////////////////////////////Maps Notes/////////////////////////////////////////////////////////
/// maps have tiles that belong to either faction in the level.
/// Each tile can hold soldiers of their faction.
/// Each turn, the faction whose turn it is, can use the points they have for that turn to "hire" more units.
/// In the same turn, they can send parties of units to engage the enemy territory.
/// When units engage enemy faction, a skirmish is started.
/// Clicking the tiles of your faction will open a menu for hiring units, or movi