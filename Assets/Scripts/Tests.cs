using UnityEngine;
using System.Collections;

public class Tests : MonoBehaviour {

    public PlayerManager player;

    int i = 1;

    public void CyclePlayerCharacter() 
    {    
        switch (i % 3) {
            case 0:
                player.SetCharacter("Soldier");
                break;
            case 1:
                player.SetCharacter("Business");
                break;
            case 2: 
                player.SetCharacter("Nurse");
                break;
            default:
                break;
        }
        i++;
    }

    public void SetPlayerAccuracy(float value)
    {
        PlayerManager.Script.accuracy = value;
    }
}
