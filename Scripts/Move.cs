using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float _speed = 1f;
    private int _step;
    public Button _button;
    public Text _text;
    public float alphaValue;
    public GameObject _button2;
    

    Color _color;

    [ContextMenu("Set Alpha")]
    public void ShowBut()
    {
        _button.image.CrossFadeAlpha(alphaValue,0.5f,false);
        _text.CrossFadeAlpha(alphaValue, 0.5f, false);

        StartCoroutine(Coroutine());
    }
    IEnumerator Coroutine()
    {
        int _step = 0;

        yield return new WaitForSeconds(1f);
        while (_step == 0)
        {
            transform.Translate(Vector3.forward * 2f * Time.deltaTime);
            yield return null;
            if (transform.position.z > 3)
                _step = 1;
        }

        yield return new WaitForSeconds(0.5f);
        while (_step == 1)
        {
            transform.Translate(Vector3.up * 2f * Time.deltaTime);
            yield return null;
            if (transform.position.y > 2)
                _step = 2;

            if (transform.rotation.eulerAngles.y < 180)
                transform.Rotate(0, 2, 0);
        }
       
        while (_step == 2)
        {
            transform.Translate(Vector3.down * 2f * Time.deltaTime);
            yield return null;
            if (transform.position.y <= 0)
                _step = 3;
        }

        yield return new WaitForSeconds(0.5f);
        while (_step == 3)
        {
            transform.Translate(Vector3.forward * 3f * Time.deltaTime);
            yield return null;
            if (transform.position.z <= 0)
                _step = 4;
        }
        //появление кнопки из альфы
        while (_step == 4)
        {
            yield return null;

            ShowFinal();
        }
    }
    public void ShowFinal()
    {
        _button2.SetActive(true);
    }
}
