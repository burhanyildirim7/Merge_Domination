using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BuyButtonScript : MonoBehaviour
{
    [SerializeField] GameObject _level1Turret,_mergeAlaniParent;
    [SerializeField] Text _turretBedel;


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
    void Update()
    {
        
    }


    public void BuyButtonActive()
    {


        PlayerPrefs.SetInt("TurretBedel",PlayerPrefs.GetInt("TurretBedel")+100);
        _turretBedel.text = "$"+ (PlayerPrefs.GetInt("TurretBedel") + 100);
    }


}
