using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurretMergeKontrol : MonoBehaviour
{
    [SerializeField] GameObject _nextTurret;
    [SerializeField] public int _turretNum;
    public bool _objeYerlestirilebilir,_mergeEdilebilir,_mergeTahtasinda;
    private GameObject _mergeTahtası,_geciciTurret;
    // Start is called before the first frame update
    void Start()
    {
        _objeYerlestirilebilir = true;
        _mergeEdilebilir = true;
        _mergeTahtasinda = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "merge")
        {
            if (other.transform.GetComponent<mergeAlaniDoluluk>()._doluluk == false)
            {
                _objeYerlestirilebilir = true;
            }
            else
            {
                _objeYerlestirilebilir = false;

            }

        }

    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("1. BOLGEDE");
        if (other.tag == "merge")
        {
            _mergeTahtası = other.gameObject;
            if (other.transform.GetComponent<mergeAlaniDoluluk>()._doluluk == false)
            {
                other.transform.GetComponent<mergeAlaniDoluluk>()._doluluk = true;
            }
            else
            {

            }
        }
        if (other.tag=="turret")
        {
            Debug.Log("2. BOLGEDE");
            if (_turretNum != 128) //   MAX TURRET MERGE LEVELİ
            {
                Debug.Log("3. BOLGEDE");
                if (other.transform.GetComponent<TurretMergeKontrol>()._mergeTahtasinda)
                {
                    Debug.Log("4. BOLGEDE");
                    if (Input.GetMouseButtonUp(0))
                    {
                        Debug.Log("6. BOLGEDE");
                        if (other.transform.GetComponent<TurretMergeKontrol>()._mergeEdilebilir)
                        {
                            Debug.Log("7. BOLGEDE");
                            if (other.transform.GetComponent<TurretMergeKontrol>()._turretNum == _turretNum)
                            {
                                Debug.Log("8. BOLGEDE");
                                Destroy(other.gameObject);
                                _geciciTurret = Instantiate(_nextTurret, transform.position, Quaternion.identity);
                                _geciciTurret.transform.DOMove(new Vector3(_mergeTahtası.transform.position.x, 0.1f, _mergeTahtası.transform.position.z), 0.1f);
                                Destroy(gameObject,0.2f);
                            }

                        }

                    }

                }
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "merge")
        {
            if (_objeYerlestirilebilir == true)
            {
                _objeYerlestirilebilir = false;
                other.transform.GetComponent<mergeAlaniDoluluk>()._doluluk = false;
            }


            if (other.transform.GetComponent<mergeAlaniDoluluk>()._doluluk == true)
            {
                other.transform.GetComponent<mergeAlaniDoluluk>()._doluluk = false;
            }
            else
            {

            }
            _mergeTahtasinda = false;
            _mergeEdilebilir = false;
        }

    }

}
