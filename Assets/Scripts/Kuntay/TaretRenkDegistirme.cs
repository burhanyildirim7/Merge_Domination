using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretRenkDegistirme : MonoBehaviour
{
    [SerializeField] Material _anaRenk, _griRenk;
    [SerializeField] GameObject _conncetionParent;
    public List<GameObject> _temasEdilenObjeler = new List<GameObject>();
    public bool _isMergeAlani,_CONNECTION,_WORKING;

    private float _sayac,_sayac2, _sayac3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue)
        {
            _sayac += Time.deltaTime;
            if ((GameObject.Find("SOKETLER_PARENT").transform.GetComponent<AnaSoketKontrol>()._SYSTEMCONTROL && _WORKING) || _isMergeAlani)
            {
                transform.GetComponent<Renderer>().material = _anaRenk;
            }
            else
            {
                transform.GetComponent<Renderer>().material = _griRenk;
            }
            if (_sayac>0.01f)
            {
                _sayac = 0;
                _sayac2 = 0;
                _sayac3 = 0;
                for (int i = 0; i < _conncetionParent.transform.childCount; i++)
                {
                    if (_conncetionParent.transform.GetChild(i).transform.GetComponent<ConnectionControl>()._generatorTemas)
                    {
                        Debug.Log("GENERATORE TEMAS EDİYOR");

                        break;
                    }
                    _sayac2++;

                    Debug.Log("SAYAC2: "+ _sayac2);
                }
                if (_sayac2== _conncetionParent.transform.childCount)
                {
                    Debug.Log("GENERATORE TEMAS EDEN YOK");

                    for (int i = 0; i < _temasEdilenObjeler.Count; i++)
                    {
                        if (_temasEdilenObjeler[i].transform.GetComponent<TaretRenkDegistirme>()._WORKING)
                        {
                            Debug.Log("WORKINGI AKTIF ETTIM");

                            transform.GetComponent<TaretRenkDegistirme>()._WORKING = true;
                            break;
                        }
                        _sayac3++;

                    }
                    if (_sayac3== _temasEdilenObjeler.Count)
                    {
                        Debug.Log("WORKINGI AKTIF EDEMEDIM");

                        transform.GetComponent<TaretRenkDegistirme>()._WORKING = false;
                    }
                }


            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="merge")
        {
            _isMergeAlani = true;
        }
        else
        {
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "merge")
        {
            _isMergeAlani = true;
        }
        else
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "merge")
        {
            _isMergeAlani = false;
        }
        else
        {

        }
    }

}
