using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using DG.Tweening;
using Facebook.Unity.Example;

public class RayKodlari : MonoBehaviour
{
    [SerializeField] GameObject _paraAlani, _geciciKonum,_paraToplayici;
    [SerializeField] LayerMask _gorundlayerMask,_soketLayerMask,_mergeLayerMask,_paraAlaniLayer,_turretYakalaLayer;
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
                if (Physics.Raycast(ray,out RaycastHit hitInfo, float.MaxValue, _turretYakalaLayer))
                {
                    if (hitInfo.transform.gameObject.tag =="turret")
                    {
                        _turretinYakalandigiKonum.transform.position = new Vector3(hitInfo.transform.position.x,.25f, hitInfo.transform.position.z);
                        _yakalananTurret = hitInfo.transform.gameObject;
                    }
                    else
                    {

                    }
                }
            }
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo,float.MaxValue,_gorundlayerMask))
                {
                    _yakalananTurret.transform.position = new Vector3(hitInfo.point.x, 2, hitInfo.point.z);
                }
                if (Physics.Raycast(ray, out RaycastHit hitParaAlani, float.MaxValue, _paraAlaniLayer))
                {
                    if (hitParaAlani.transform.gameObject == _paraAlani)
                    {
                        _paraToplayici.transform.position = new Vector3(hitInfo.point.x, 0, hitInfo.point.z);
                    }
                    else
                    {

                    }
                }
                if (Physics.Raycast(ray, out RaycastHit hitSoketInfo, float.MaxValue, _soketLayerMask))
                {
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
                else if (Physics.Raycast(ray, out RaycastHit hitMergeSoketInfo, float.MaxValue, _mergeLayerMask))
                {

                    if (_yakalananTurret.transform.GetChild(0).GetChild(0).GetComponent<SoketKontrolEtme>()._objeYerlestirilebilir)
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
                    for (int i = 0; i < _yakalananTurret.transform.GetChild(0).transform.childCount; i++)
                    {
                        if (_yakalananTurret.transform.GetChild(0).GetChild(i).GetComponent<SoketKontrolEtme>()._objeYerlestirilebilir)
                        {
                            _sayac++;
                        }
                    }
                    if (_sayac == _yakalananTurret.transform.GetChild(0).transform.childCount)
                    {
                        _turretinYakalandigiKonum.transform.position = new Vector3(hitSoketInfo.transform.position.x, 0.25f, hitSoketInfo.transform.position.z);
                    }
                }
                else if (Physics.Raycast(ray, out RaycastHit hitMergeInfo, float.MaxValue, _mergeLayerMask))
                {
                    if (_yakalananTurret.transform.GetChild(0).GetChild(0).GetComponent<SoketKontrolEtme>()._objeYerlestirilebilir)
                    {
                        _yakalananTurret.transform.GetComponent<TurretMergeKontrol>()._mergeEdilebilir = true;
                        if (_yakalananTurret.transform.GetComponent<TurretMergeKontrol>()._turretNum==2)
                        {
                            _turretinYakalandigiKonum.transform.position = new Vector3(hitMergeInfo.transform.position.x + .5f, 0, hitMergeInfo.transform.position.z);
                            hitMergeInfo.transform.GetComponent<mergeAlaniDoluluk>()._doluluk = true;
                        }
                        else
                        {
                            _turretinYakalandigiKonum.transform.position = new Vector3(hitMergeInfo.transform.position.x, .25f, hitMergeInfo.transform.position.z);
                            hitMergeInfo.transform.GetComponent<mergeAlaniDoluluk>()._doluluk = true;
                        }
                    }
                }
                else
                {

                }
                _yakalananTurret.transform.DOMove(_turretinYakalandigiKonum.position, 0.5f);
                _yakalananTurret = _geciciKonum;
            }
        }
    }
}
