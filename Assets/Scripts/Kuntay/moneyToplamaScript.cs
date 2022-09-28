using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class moneyToplamaScript : MonoBehaviour
{
    [SerializeField] GameObject _paraBlastFX,_paraTextCanvas,_ucusHedefObjesi,_parentObject;
    private bool _teksefer;
    private GameObject _tempCanvas;
    private float _sayac;
    void Start()
    {
        _teksefer = true;
    }

   /* private void Update()
    {
        if (GameController.instance.isContinue)
        {
            _sayac += Time.deltaTime;
            if (_sayac> PlayerPrefs.GetFloat("EnemySpawnRate"))
            {
                _sayac = 0;
                if (transform.parent==null)
                {
                    if (_parentObject.transform.parent.GetComponent<EnemySpawnerScript>()._moneyList.Count < 800)
                    {
                        _parentObject.transform.parent.GetComponent<EnemySpawnerScript>()._otoCollectMoneyList.Add(transform.gameObject);
                    }

                }
            }

        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "toplayici" && _teksefer)
        {
            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
            transform.GetComponent<AudioSource>().Play();
            _teksefer = false;
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") + (int)(PlayerPrefs.GetFloat("Income")*GameObject.Find("KATSAYI_PARENT").GetComponent<KatsayiHesaplama>()._toplamCarpan));
            UIController.instance.SetGamePlayScoreText();
            _paraTextCanvas.SetActive(true);
            _paraTextCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "$"+((int)(PlayerPrefs.GetFloat("Income") * GameObject.Find("KATSAYI_PARENT").GetComponent<KatsayiHesaplama>()._toplamCarpan)).ToString();
            _paraTextCanvas.transform.DOLocalMove(_ucusHedefObjesi.transform.localPosition,.5f);
            Instantiate(_paraBlastFX,null).transform.position=transform.position;
            transform.DOScale(500,.3f);
            transform.DOJump(transform.position,1,1,.5f);
            Invoke("paraGeriDonme", .55f);
            //Destroy(gameObject,.55f);
        }
    }

    private void paraGeriDonme()
    {
        transform.parent = _parentObject.transform;
        transform.parent.parent.GetComponent<EnemySpawnerScript>()._moneyList.Add(transform.gameObject);
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }

    public void OtoToplanma()
    {
        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
        transform.GetComponent<AudioSource>().Play();
        _teksefer = false;
        PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") + (int)(PlayerPrefs.GetFloat("Income") * GameObject.Find("KATSAYI_PARENT").GetComponent<KatsayiHesaplama>()._toplamCarpan));
        UIController.instance.SetGamePlayScoreText();
        _paraTextCanvas.SetActive(true);
        _paraTextCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "$" + ((int)(PlayerPrefs.GetFloat("Income") * GameObject.Find("KATSAYI_PARENT").GetComponent<KatsayiHesaplama>()._toplamCarpan)).ToString();
        _paraTextCanvas.transform.DOLocalMove(_ucusHedefObjesi.transform.localPosition, .5f);
        Instantiate(_paraBlastFX, null).transform.position = transform.position;
        transform.DOScale(500, .3f);
        transform.DOJump(transform.position, 1, 1, .5f);
        Invoke("paraGeriDonme", .55f);

    }
}
