using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
   
    void Start()
    {
        StartCoroutine(instObj());
    }

    IEnumerator instObj()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject obj = Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
    }
}
