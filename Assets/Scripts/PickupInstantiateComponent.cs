using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInstantiateComponent : MonoBehaviour
{
    public Transform InstantiateLine;
    float instantiateTriggerValue;
    public GameObject PickUp;
    public Sprite A;
    public Sprite B;
    public Sprite C;
    bool canInstantiate = true;
    void Start()
    {
        instantiateTriggerValue = InstantiateLine.position.y;

    }


    void Update()
    {
        if (!canInstantiate) return;
        if ((this.transform.position.y) < instantiateTriggerValue)
        {
            GameObject pickup = Instantiate(PickUp, this.transform.position, this.transform.rotation);
            switch(RoadManager.currentLevelState)
            { 
                case(1):
                    pickup.GetComponent<SpriteRenderer>().sprite = A;
                break;
                case (2):
                    pickup.GetComponent<SpriteRenderer>().sprite = B;
                    break;
                case (3):
                    pickup.GetComponent<SpriteRenderer>().sprite = C;
                    break;
            }
            canInstantiate = false;
        }
    }
}
