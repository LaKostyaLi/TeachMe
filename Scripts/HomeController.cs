using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    public static event Action<HomeModeTypes> OnStartAction;
    void StartMove()
    {

        OnStartAction?.Invoke(HomeModeTypes.InUpdate);
    }

}
