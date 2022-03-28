using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject RoadPrefab;
   public  Transform targetPoint;
    public GameObject currentRoad;
    GameObject nextRoad;
     float instantiateTriggerValue;
    public Transform InstantiateLine;
    public Transform DestroyLine;
    void Start()
    {
        instantiateTriggerValue = InstantiateLine.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRoad.GetComponent<RoadControl>().triggerPoint.position.y < instantiateTriggerValue)
        {
            nextRoad=Instantiate(RoadPrefab, targetPoint.position, this.transform.rotation);
            currentRoad = nextRoad;
        }
    }
  
}
