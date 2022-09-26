using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurretMergeKontrol : MonoBehaviour
{
    [SerializeField] GameObject _nextTurret,_mergeTahtaSorgulayici;
    [SerializeField] public int _turretNum;
    public bool _mergeEdilebilir, _objeYerde;
    private GameObject _mergeTahtası,_geciciTurret;
    // Start is called before the first frame update
    void Start()
    {
        _mergeEdilebilir = true;
        _objeYerde = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "merge")
        {
            _mergeTahtası = other.gameObject;
            _objeYerde = true;

        }
        else if (other.tag == "soket")
        {
            _objeYerde = true;
        }
        else if (other.tag=="turret")
        {
            if (_turretNum != 128) //   MAX TURRET MERGE LEVELİ
            {

            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "merge")
        {
            _objeYerde = false;
            if (other.transform.GetComponent<mergeAlaniDoluluk>()._doluluk == true)
            {
                other.transform.GetComponent<mergeAlaniDoluluk>()._doluluk = false;
            }
            else
            {

            }
        }
        if (other.tag=="soket")
        {
            _objeYerde = false;
        }
    }

}
