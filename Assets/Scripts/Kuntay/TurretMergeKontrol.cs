using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurretMergeKontrol : MonoBehaviour
{
    [SerializeField] GameObject _nextTurret;
    [SerializeField] public int _turretNum;
    public bool _mergeEdilebilir, _objeYerde;
    private GameObject _mergeTahtası,_geciciTurret;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (_objeYerde)
        {
            Debug.Log("OBJE YERDE");
        }
        else
        {
            Debug.Log("OBJE YERDE DEGİL");

            if (_turretNum == 64)
            {
                Debug.Log("ELIMDEKİ OBEJENIN NUMARASI: "+64);

            }
            else
            {
                Debug.Log("ELIMDEKİ OBEJENIN NUMARASI: " + _turretNum);

                if (other.tag == "turret")
                {
                    Debug.Log("ELIMDEKİ OBJE TURRET GÖRDÜ ");

                    if (_turretNum== other.gameObject.transform.GetComponent<TurretMergeKontrol>()._turretNum)
                    {
                        Debug.Log("ELIMDEKİ OBJENIN NUMARASI İLE GÖRÜNEN TURRET NO AYNI ");

                        _geciciTurret = Instantiate(_nextTurret, null);
                        _geciciTurret.transform.position = other.gameObject.transform.GetComponent<TurretMergeKontrol>().transform.position;
                        _geciciTurret.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        _geciciTurret.transform.DOScale(1,0.2f);
                        Destroy(other.gameObject);
                        Destroy(gameObject);

                    }
                    else
                    {

                    }
                }
            }
        }*/
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "merge")
        {
            _mergeTahtası = other.gameObject;

        }
        else if (other.tag == "soket")
        {
            _mergeEdilebilir = false;
        }
        else if (other.tag=="turret")
        {
            if (_turretNum == 64) //   MAX TURRET MERGE LEVELİ
            {
                _mergeEdilebilir = false;
            }
        }

        if (_objeYerde)
        {
            Debug.Log("OBJE YERDE");
        }
        else
        {
            Debug.Log("OBJE YERDE DEGİL");

            if (_turretNum == 64)
            {
                Debug.Log("ELIMDEKİ OBEJENIN NUMARASI: " + 64);

            }
            else
            {
                Debug.Log("ELIMDEKİ OBEJENIN NUMARASI: " + _turretNum);

                if (other.tag == "turret")
                {
                    Debug.Log("ELIMDEKİ OBJE TURRET GÖRDÜ ");

                    if (_turretNum == other.gameObject.transform.GetComponent<TurretMergeKontrol>()._turretNum)
                    {
                        if (Input.GetMouseButtonUp(0))
                        {
                            Debug.Log("ELIMDEKİ OBJENIN NUMARASI İLE GÖRÜNEN TURRET NO AYNI ");

                            _geciciTurret = Instantiate(_nextTurret, null);
                            _geciciTurret.transform.position = other.gameObject.transform.GetComponent<TurretMergeKontrol>().transform.position;
                            _geciciTurret.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                            _geciciTurret.transform.DOScale(1, 0.2f);
                            GameObject.Find("RAY_CONTROLLER").transform.GetComponent<RayKodlari>()._yakalananTurret= GameObject.Find("RAY_CONTROLLER").transform.GetComponent<RayKodlari>()._geciciKonum;
                            Destroy(other.gameObject);
                            Destroy(gameObject);

                        }

                    }
                    else
                    {

                    }
                }
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
