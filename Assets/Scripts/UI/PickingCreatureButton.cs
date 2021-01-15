using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingCreatureButton : MonoBehaviour
{
    public string creatureType;

    public void spawnPet()
    {
        PlayerManager.instance.player.GetComponent<PlayerController>().spawnPet(creatureType);
    }
}
