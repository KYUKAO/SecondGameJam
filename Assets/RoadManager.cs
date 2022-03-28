using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject RoadPrefab;
   public  Transform targetPoint;
    public GameObject currentRoad;
    GameObject nextRoad;
    public float TriggerValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRoad.GetComponent<RoadControl>().triggerPoint.position.y < TriggerValue)
        {
            nextRoad=Instantiate(RoadPrefab, targetPoint.position, this.transform.rotation);
            currentRoad = nextRoad;
        }
    }
}
