using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterGroup
{
    [SerializeField]
    private Character characterInGroup;
    [SerializeField]
    private int numberOfCharactersInGroup;
    [SerializeField]
    private int totalHealthAmongCharacters;
    [SerializeField]
    private int currentHealthAmongCharacters;

    public Character CharacterInGroup {
        get => characterInGroup;set => characterInGroup = value;
    }
    public int NumberOfCharactersInGroup {
        get => numberOfCharactersInGroup;
    }
    public int TotalHealthAmongCharacters {
        get => totalHealthAmongCharacters; set => totalHealthAmongCharacters = value;
    }
    public int CurrentHealthAmongCharacters {
        get => currentHealthAmongCharacters; set => currentHealthAmongCharacters = value;
    }

    public void Initialize() {
        Debug.Log(TotalHealthAmongCharacters);
        TotalHealthAmongCharacters = numberOfCharactersInGroup * characterInGroup.Health;
        CurrentHealthAmongCharacters = TotalHealthAmongCharacters;
    }

    public static void CheckCharactersAlive(CharacterGroup group) {
        int currentNumberOfCharacters = 0;
        float currentNumberOfCharactersFloat = 0f;
        currentNumberOfCharactersFloat = (float) group.currentHealthAmongCharacters / (float)group.characterInGroup.Health;
        //if(currentNumberOfCharactersFloat - Mathf.FloorToInt(currentNumberOfCharactersFloat) > 0f) {
            currentNumberOfCharacters = Mathf.CeilToInt(currentNumberOfCharactersFloat);
        group.numberOfCharactersInGroup = currentNumberOfCharacters;
        //}
    }

}
