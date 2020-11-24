using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorHit : MonoBehaviour
{
    public string destination;

    void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.GetComponent<GameCharacter>().characterType.ToLower().Equals("player"))
        {
            SceneManager.LoadScene(destination);
        }
    }
}
