using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWithUpdate : MonoBehaviour
{
    [SerializeField] private CanvasGroup startPanel;
    [SerializeField] private CanvasGroup endPanel;
    [SerializeField] private Transform _transform;

    private HomeModeTypes _currentState;

    private float _timer;
    private const float delayTime = 0.5f;
    private const float showHideUiDuration=0.5f;
    private const float moveSpeed = 3f;
    private static Vector3 targetPos = new Vector3(0, 0, 3);
    private static Vector3 jumpPos = new Vector3(0, 3, 0);
    void Start()
    {
        HomeController.OnStartAction += StartAction;
    }

    private void StartAction(HomeModeTypes modeTypes) //
    {
        if (modeTypes != HomeModeTypes.InUpdate)
            return;

        _currentState = HomeModeTypes.HideUi;
    }

    private void Update()
    {
        var dt = Time.deltaTime;

        switch (_currentState)
        {
            case HomeModeTypes.None:
                break;
            case HomeModeTypes.HideUi:

                if(_timer<showHideUiDuration)
                {
                    _timer += dt;
                    startPanel.alpha = 1 - (_timer * 2);
                }
                else
                {
                    _timer = 0;
                    _currentState = HomeModeTypes.WaitToMove;
                }
                break;

            case HomeModeTypes.WaitToMove:
                if(_timer <delayTime)
                {
                    _timer += dt;
                }
                else
                {
                    _timer = 0;
                    _currentState = HomeModeTypes.MoveToPoint;
                }
                break;

            case HomeModeTypes.MoveToPoint:
                if (_transform.position != targetPos)
                {
                    _transform.position = Vector3.MoveTowards(_transform.position, targetPos, moveSpeed * dt);
                }
                else
                {
                    _currentState = HomeModeTypes.WaitForJump;
                }
                break;

            case HomeModeTypes.WaitForJump:
                if (_timer < delayTime)
                {
                    _timer += dt;
                }
                else
                {
                    _timer = 0;
                    _currentState = HomeModeTypes.JumpUp;
                }
                break;

            case HomeModeTypes.JumpUp:
                if (_transform.position != jumpPos)
                {
                    _transform.position = Vector3.MoveTowards(_transform.position, jumpPos, moveSpeed * dt);
                }
                else
                {
                    _currentState = HomeModeTypes.JumpDown;
                }
                break;

            case HomeModeTypes.JumpDown:
                if (_transform.position != jumpPos)
                {
                    _transform.position = Vector3.MoveTowards(_transform.position, targetPos, moveSpeed * dt);
                }
                else
                {
                    _currentState = HomeModeTypes.WaitForMoveBack;
                }
                break;

            case HomeModeTypes.WaitForMoveBack:
                if (_timer < delayTime)
                {
                    _timer += dt;
                }
                else
                {
                    _timer = 0;
                    _currentState = HomeModeTypes.MoveBack;
                }
                break;

            case HomeModeTypes.MoveBack:
                if (_transform.position != Vector3.zero)
                {
                    _transform.position = Vector3.MoveTowards(_transform.position, Vector3.zero, moveSpeed * dt);
                }
                else
                {
                    _currentState = HomeModeTypes.JumpDown;
                }
                break;

            case HomeModeTypes.WaitTiShowUi:
                if (_timer < delayTime)
                {
                    _timer += dt;
                }
                else
                {
                    _timer = 0;
                    _currentState = HomeModeTypes.ShowUi;
                }
                break;

            case HomeModeTypes.ShowUi:
                if (_timer < showHideUiDuration)
                {
                    _timer += dt;
                    startPanel.alpha = _timer * 2f;
                }
                else
                {
                    _timer = 0;
                    _currentState = HomeModeTypes.None;
                }
                break;

        }
    }
}
