using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaretRenkDegistirme : MonoBehaviour
{
    [SerializeField] Material _anaRenk, _griRenk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue)
        {
            if (GameObject.Find("SOKETLER_PARENT").transform.GetComponent<AnaSoketKontrol>()._SYSTEMCONTROL)
            {
                transform.GetComponent<Renderer>().material = _anaRenk;
            }
            else
            {
                transform.GetComponent<Renderer>().material = _griRenk;
            }
        }
    }
}
