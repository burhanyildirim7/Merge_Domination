using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKapatAc : MonoBehaviour
{
    [SerializeField] GameObject _opened, _closed,_temaSoundObject,_mainCamera;
    [SerializeField] int _prefIsmi;

    void Start()
    {
        if (PlayerPrefs.GetInt("" + _prefIsmi) == 0)
        {
            _opened.SetActive(true);
            _closed.SetActive(false);
            if (_prefIsmi == 1)
            {
                _temaSoundObject.SetActive(true);
            }
            else
            {
                _mainCamera.transform.GetComponent<AudioListener>().enabled = true;

            }
        }
        else
        {
            _opened.SetActive(false);
            _closed.SetActive(true);
            if (_prefIsmi == 1)
            {
                _temaSoundObject.SetActive(false);
            }
            else
            {
                _mainCamera.transform.GetComponent<AudioListener>().enabled = false;
            }
        }
    }

    public void FlipState()
    {
        if (PlayerPrefs.GetInt(""+ _prefIsmi)==0)
        {
            PlayerPrefs.SetInt("" + _prefIsmi, 1);
            _opened.SetActive(false);
            _closed.SetActive(true);
            if (_prefIsmi==1)
            {
                _temaSoundObject.SetActive(false);
            }
            else
            {
                _mainCamera.transform.GetComponent<AudioListener>().enabled =false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("" + _prefIsmi, 0);
            _opened.SetActive(true);
            _closed.SetActive(false);
            if (_prefIsmi == 1)
            {
                _temaSoundObject.SetActive(true);
            }
            else
            {
                _mainCamera.transform.GetComponent<AudioListener>().enabled = true;

            }
        }
    }

}
