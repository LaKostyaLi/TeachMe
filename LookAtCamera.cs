using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Transform camera = Camera.main.transform;
        Vector3 cameraPos = camera.position;
        Vector3 currentPos = transform.position;

        Vector3 direction = (currentPos - cameraPos).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
