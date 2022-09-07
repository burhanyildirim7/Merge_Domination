using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayKodlari : MonoBehaviour
{
    [SerializeField] GameObject ParaAlani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isContinue)
        {

            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray,out RaycastHit hitInfo))
                {

                    if (hitInfo.transform.gameObject== ParaAlani)
                    {



                    }
                }
            }
        }
    }
}
