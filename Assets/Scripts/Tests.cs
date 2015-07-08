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

    public void SwarmZombies()
    {
        var zombiePrefab = Resources.Load("Prefabs/Enemies/Zombie");

        for (int i = 1; i < 100; i++)
        {
            var x = Random.Range(10, 20) * (Random.Range(0,2) * 2 - 1);
            var y = Random.Range(10, 20) * (Random.Range(0,2) * 2 - 1);

            Instantiate(zombiePrefab, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
