using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoketKontrolEtme : MonoBehaviour
{
    [SerializeField] public GameObject _serbestAlanObjesi, _yasakliAlanObjesi;

    public bool _objeYerlestirilebilir;
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
        if (other.tag=="soket")
        {
            if (other.transform.GetComponent<YapbozAlaniDoluluk>()._soketDoluluk==false)
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
        if (other.tag == "soket")
        {

            if (other.transform.GetComponent<YapbozAlaniDoluluk>()._soketDoluluk == false)
            {
                other.transform.GetComponent<YapbozAlaniDoluluk>()._soketDoluluk = true;
            }
            else
            {
              
            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "soket")
        {
            if (_objeYerlestirilebilir==true)
            {
                _objeYerlestirilebilir = false;
            }


            if (other.transform.GetComponent<YapbozAlaniDoluluk>()._soketDoluluk == true)
            {
                other.transform.GetComponent<YapbozAlaniDoluluk>()._soketDoluluk = false;
            }
            else
            {

            }


        }
    }

}
