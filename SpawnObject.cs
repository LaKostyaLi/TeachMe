using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
   
    void Start()
    {
        GameObject obj = Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
