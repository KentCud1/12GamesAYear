using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TeamHireableGroups : MonoBehaviour
{
    [SerializeField]
    public List<TeamHireablesList> teamHireablesLists;
    public bool debugDictionary;

    public static TeamHireableGroups instance;

    private Dictionary<TeamTypes, List<CharacterGroup>> teamHireablesDictionary;

    public Dictionary<TeamTypes, List<CharacterGroup>> TeamHireablesDictionary { get => teamHireablesDictionary; }

    private void Start() {
        if(instance = null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
        if (debugDictionary) {
            DebugDictionary();
        }
    }

    private void DebugDictionary() {
        teamHireablesDictionary = new Dictionary<TeamTypes, List<CharacterGroup>>();
        for (int i = 0; i < teamHireablesLists.Count; i++) {
            if (teamHireablesDictionary.ContainsKey(teamHireablesLists[i].teamTypes)) {
                Debug.LogError("Team type already exists. Did you mean to have two lists for this type?");
                continue;
            }
            teamHireablesDictionary.Add(teamHireablesLists[i].teamTypes, teamHireablesLists[i].hireableCharacterGroups);
        }
        TeamTypes[] teamLists = new TeamTypes[teamHireablesDictionary.Count];
        teamHireablesDictionary.Keys.CopyTo(teamLists, 0);
        for (int i = 0; i < teamHireablesDictionary.Count; i++) {
            string listMessage = "Groups: ";
            int listCount = teamHireablesDictionary[teamLists[i]].Count;
            for (int j = 0; j < listCount; j++) {
                listMessage += teamHireablesDictionary[teamLists[i]][j] != null ? (teamHireablesDictionary[teamLists[i]][j].CharacterInGroup != null ? teamHireablesDictionary[teamLists[i]][j].CharacterInGroup.name : "None") + "\n" : "None\n";
            }
            Debug.Log("Team type: " + teamLists[i] + "\n Number of Groups: " + teamHireablesDictionary[teamLists[i]].Count + listMessage);
        }
    }
}
[System.Serializable]
public struct TeamHireablesList {
    public TeamTypes teamTypes;
    [SerializeField]
    public List<CharacterGroup> hireableCharacterGroups;
}
