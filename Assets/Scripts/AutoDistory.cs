using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDistory : MonoBehaviour
{
    public float exitTime = 1;
    void Start()
    {
        Destroy(this.gameObject, exitTime);
    }

}
