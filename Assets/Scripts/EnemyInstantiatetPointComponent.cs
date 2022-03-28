using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiatetPointComponent : MonoBehaviour
{
    float instantiateTriggerValue;
    public Transform InstantiateLine;
    public GameObject Enemy;
    public bool canInstantiate = true;
    public EnemyControl.EnemyType currentEnemyType;
    void Start()
    {
        instantiateTriggerValue = InstantiateLine.position.y;
    }

    void Update()
    {
        if (!canInstantiate) return;
        if((this.transform.position.y) < instantiateTriggerValue)
        {
            GameObject enemy = Instantiate(Enemy, this.transform.position, this.transform.rotation);
            enemy.GetComponent<EnemyControl>().currentEnemyType = currentEnemyType;
            canInstantiate = false;
        }
    }
}
