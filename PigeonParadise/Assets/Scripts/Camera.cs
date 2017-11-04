using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Pigeon;
    public float offset;

    public void LateUpdate()
    {
        transform.position = new Vector3(Pigeon.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
