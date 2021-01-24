using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDistance : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(target.position, transform.position));   
    }
}
