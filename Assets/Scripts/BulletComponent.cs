using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyItself", 0.5f);
    }
    void DestroyItself()
    {
        Destroy(this.gameObject);
    }
}
