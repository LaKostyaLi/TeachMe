using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed=5;
    [SerializeField] private GameObject _first;
    [SerializeField] private GameObject _second;
    private Vector3 _target;
    public Transform _povorot;

    void Start()
    {
        _target = _first.transform.position;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, (Time.deltaTime * _speed));

        if(transform.position ==_first.transform.position)
        {
            transform.position = _first.transform.position + new Vector3(0, 2, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);


            //Vector3 direction = _povorot.transform.position - transform.position;
            //Quaternion rotation = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, (Time.deltaTime * _speed));


            _target = _second.transform.position;
        }
        else
        {
           // transform.position = _first.transform.position;
        }
    }
}
