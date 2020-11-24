using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameCharacter))]
public class HealthUI : MonoBehaviour
{
    public GameObject UIprefab;
    public Transform target;

    Transform thisUI;
    Image healthSLider;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;

        foreach(Canvas c in FindObjectsOfType<Canvas>())
        {
            if(c.renderMode == RenderMode.WorldSpace)
            {
                thisUI = Instantiate(UIprefab, c.transform).transform;
                healthSLider = thisUI.GetChild(0).GetComponent<Image>();
                break;
            }
        }

        if (GetComponent<GameCharacter>().characterType.ToLower().Equals("player"))
        {
            GetComponent<PlayerStat>().OnHealthChanged += OnHealthChanged;
        }

        else if (GetComponent<GameCharacter>().characterType.ToLower().Equals("enemy"))
        {
            GetComponent<EnemyStat>().OnHealthChanged += OnHealthChanged;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(thisUI != null)
        {
            thisUI.position = target.position;
            thisUI.forward = -cam.forward;
        }
    }

    void OnHealthChanged(int maxHealth, int currentHealth)
    {
        if(thisUI != null)
        {
            thisUI.gameObject.SetActive(true);
            float healthPercent = currentHealth / (float)maxHealth;
            healthSLider.fillAmount = healthPercent;

            if (currentHealth <= 0)
            {
                Destroy(thisUI.gameObject);
            }
        }
    }
}
