using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BuyButtonScript : MonoBehaviour
{
    [SerializeField] GameObject _level1Turret,_mergeAlaniParent,_turretOlusturmaNoktasi;
    [SerializeField] Text _turretBedel;

    private float _timer=0,_sayac;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("TurretBedelBaslangic")==0)
        {
            _turretBedel.text = "$100";
            PlayerPrefs.SetInt("TurretBedelBaslangic", 1);
        }
        else
        {
            _turretBedel.text = "$" + (PlayerPrefs.GetInt("TurretBedel") + 100);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.isContinue)
        {
            _timer = _timer + Time.deltaTime;
            if (_timer>.1f)
            {
                _timer = 0;
                
                if (PlayerPrefs.GetInt("MergeAlaniDolulukAdeti") == 3)
                {
                    transform.GetComponent<Button>().interactable = false;

                }
                else
                {
                    transform.GetComponent<Button>().interactable = true;

                }
            }
        }
    }


    public void BuyButtonActive()
    {
        for (int i = 0; i < _mergeAlaniParent.transform.childCount; i++)
        {
            if (_mergeAlaniParent.transform.GetChild(i).GetComponent<mergeAlaniDoluluk>()._doluluk == false)
            {
                _mergeAlaniParent.transform.GetChild(i).transform.GetComponent<mergeAlaniDoluluk>()._doluluk = true;
                GameObject _newTurret = Instantiate(_level1Turret, _turretOlusturmaNoktasi.transform.position, Quaternion.identity);
                _newTurret.transform.parent = null;
                _newTurret.transform.localPosition = _turretOlusturmaNoktasi.transform.position ;
                _newTurret.transform.DOJump(new Vector3(_mergeAlaniParent.transform.GetChild(i).transform.position.x,0, _mergeAlaniParent.transform.GetChild(i).transform.position.z), 2, 1, .5f);
                PlayerPrefs.SetInt("MergeAlaniDolulukAdeti", PlayerPrefs.GetInt("MergeAlaniDolulukAdeti")+1);
                break;
            }
        }
        PlayerPrefs.SetInt("TurretBedel",PlayerPrefs.GetInt("TurretBedel")+100);
        _turretBedel.text = "$"+ (PlayerPrefs.GetInt("TurretBedel") + 100);
    }


}