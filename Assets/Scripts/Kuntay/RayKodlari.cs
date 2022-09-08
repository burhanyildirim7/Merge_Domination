using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using DG.Tweening;

public class RayKodlari : MonoBehaviour
{
    [SerializeField] GameObject _paraAlani, _geciciKonum;
    [SerializeField] LayerMask _layerMask;
    private GameObject _yakalananTurret;
    private Transform _turretinYakalandigiKonum;
    // Start is called before the first frame update
    void Start()
    {
        _yakalananTurret = _geciciKonum;
        _turretinYakalandigiKonum = _geciciKonum.transform;
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


                    if (hitInfo.transform.gameObject.tag =="turret")
                    {
                            _turretinYakalandigiKonum.transform.position = hitInfo.transform.position;
                            _yakalananTurret = hitInfo.transform.gameObject;
                            Debug.Log("turret yakaladım");
                    }
                    else
                    {

                    }
                }
            }
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo,float.MaxValue,_layerMask))
                {
                    _yakalananTurret.transform.position = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);


                }
                if (Physics.Raycast(ray, out RaycastHit hitParaAlani))
                {
                    if (hitParaAlani.transform.gameObject == _paraAlani)
                    {

                        //parayı yok et + fx instantiate et

                    }
                    else
                    {

                    }
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                _yakalananTurret.transform.DOMove(_turretinYakalandigiKonum.position,0.5f);
                Debug.Log("baslangıc konumu: "+_turretinYakalandigiKonum.transform.position);
                _yakalananTurret = _geciciKonum;
            }
        }
    }
}
