using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using DG.Tweening;
using Facebook.Unity.Example;

public class RayKodlari : MonoBehaviour
{
    [SerializeField] GameObject _paraAlani, _geciciKonum,_paraToplayici;
    [SerializeField] LayerMask _layerMask,_soketLayerMask,_mergeLayerMask,_paraAlaniLayer;
    private GameObject _yakalananTurret;
    private Transform _turretinYakalandigiKonum;
    private int _sayac,_sayac2;
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
                Debug.Log("GETMOUSEBUTTON IFI");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo,float.MaxValue,_layerMask))
                {
                    _yakalananTurret.transform.position = new Vector3(hitInfo.point.x, 2, hitInfo.point.z);


                }
                if (Physics.Raycast(ray, out RaycastHit hitParaAlani, float.MaxValue, _paraAlaniLayer))
                {
                    Debug.Log("PARAALANINI BULDU IFI");
                    if (hitParaAlani.transform.gameObject == _paraAlani)
                    {
                        Debug.Log("PARA TOPLUYOR IFI");
                        _paraToplayici.transform.position = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
                        //parayı yok et + fx instantiate et

                    }
                    else
                    {

                    }
                }
                if (Physics.Raycast(ray, out RaycastHit hitSoketInfo, float.MaxValue, _soketLayerMask))
                {
                    Debug.Log("SOKET BBULDUM");
                    _sayac2 = 0;
                    for (int i = 0; i < _yakalananTurret.transform.GetChild(0).transform.childCount; i++)
                    {
                        if (_yakalananTurret.transform.GetChild(0).GetChild(i).GetComponent<SoketKontrolEtme>()._objeYerlestirilebilir)
                        {
                            _sayac2++;
                        }

                    }
                    if (_sayac2 == _yakalananTurret.transform.GetChild(0).transform.childCount)
                    {
                        _yakalananTurret.transform.GetChild(0).GetChild(0).GetComponent<SoketKontrolEtme>()._serbestAlanObjesi.SetActive(true);
                        _yakalananTurret.transform.GetChild(0).GetChild(0).GetComponent<SoketKontrolEtme>()._yasakliAlanObjesi.SetActive(false);
                    }
                    else
                    {
                        _yakalananTurret.transform.GetChild(0).GetChild(0).GetComponent<SoketKontrolEtme>()._serbestAlanObjesi.SetActive(false);
                        _yakalananTurret.transform.GetChild(0).GetChild(0).GetComponent<SoketKontrolEtme>()._yasakliAlanObjesi.SetActive(true);
                    }
                }
                else
                {
                    _yakalananTurret.transform.GetChild(0).GetChild(0).GetComponent<SoketKontrolEtme>()._serbestAlanObjesi.SetActive(false);
                    _yakalananTurret.transform.GetChild(0).GetChild(0).GetComponent<SoketKontrolEtme>()._yasakliAlanObjesi.SetActive(false);
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                _paraToplayici.transform.position = new Vector3(6,0,6);
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitSoketInfo, float.MaxValue, _soketLayerMask))
                {
                    _sayac = 0;
                    //hitSoketInfo.transform.GetComponent<YapbozAlaniDoluluk>()._soketDoluluk
                    for (int i = 0; i < _yakalananTurret.transform.GetChild(0).transform.childCount; i++)
                    {

                        if (_yakalananTurret.transform.GetChild(0).GetChild(i).GetComponent<SoketKontrolEtme>()._objeYerlestirilebilir)
                        {
                            _sayac++;
                        }

                    }
                    if (_sayac == _yakalananTurret.transform.GetChild(0).transform.childCount)
                    {

                        _turretinYakalandigiKonum.transform.position = new Vector3(hitSoketInfo.transform.position.x, 0, hitSoketInfo.transform.position.z);
                    }
                }
                if (Physics.Raycast(ray, out RaycastHit hitMergeInfo, float.MaxValue, _mergeLayerMask))
                {
                    if (_yakalananTurret.transform.GetComponent<TurretMergeKontrol>()._objeYerlestirilebilir)
                    {
                        _yakalananTurret.transform.GetComponent<TurretMergeKontrol>()._mergeEdilebilir = true;
                        _yakalananTurret.transform.GetComponent<TurretMergeKontrol>()._mergeTahtasinda = true;
                        if (_yakalananTurret.transform.GetComponent<TurretMergeKontrol>()._turretNum==2)
                        {
                            _turretinYakalandigiKonum.transform.position = new Vector3(hitMergeInfo.transform.position.x + .5f, 0, hitMergeInfo.transform.position.z);
                        }
                        else
                        {
                            _turretinYakalandigiKonum.transform.position = new Vector3(hitMergeInfo.transform.position.x, 0, hitMergeInfo.transform.position.z);
                        }
                    }
                }



                _yakalananTurret.transform.DOMove(_turretinYakalandigiKonum.position, 0.5f);
                _yakalananTurret = _geciciKonum;

            }
        }
    }
}
