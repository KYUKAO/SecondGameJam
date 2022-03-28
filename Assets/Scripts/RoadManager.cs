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
    public static int currentLevelState;
    int previousLevelState;
    public List<GameObject> levels;

    public GameObject Player;
    public GameObject NewPlayer;
    void Start()
    {
        currentLevelState = 1;
        previousLevelState = currentLevelState;
        instantiateTriggerValue = InstantiateLine.position.y;
        NewPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRoad.GetComponent<RoadControl>().triggerPoint.position.y < instantiateTriggerValue)
        {
            nextRoad=Instantiate(RoadPrefab, targetPoint.position, this.transform.rotation);
            currentRoad = nextRoad;
        }
        if (previousLevelState != currentLevelState)
        {
            levels[previousLevelState-1].SetActive(false);
            levels[currentLevelState-1].SetActive(true);
            previousLevelState = currentLevelState;
        }
        if (currentLevelState == 3)
        {
            Vector3 playerPosition = Player.transform.position;
            Player.SetActive(false);
            NewPlayer.SetActive(true);
            NewPlayer.transform.position = playerPosition;
        }
        
    }
  
}
