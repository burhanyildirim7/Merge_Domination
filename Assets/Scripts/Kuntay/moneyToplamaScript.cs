using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class moneyToplamaScript : MonoBehaviour
{
    [SerializeField] GameObject _paraBlastFX,_paraTextCanvas,_ucusHedefObjesi;
    private bool _teksefer;
    private GameObject _tempCanvas;
    // Start is called before the first frame update
    void Start()
    {
        _teksefer = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== "toplayici" && _teksefer)
        {
            _teksefer = false;
            PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") + (int)(PlayerPrefs.GetFloat("Income")*GameObject.Find("KATSAYI_PARENT").GetComponent<KatsayiHesaplama>()._toplamCarpan));
            UIController.instance.SetGamePlayScoreText();
            _paraTextCanvas.SetActive(true);
            _paraTextCanvas.transform.GetChild(0).transform.GetComponent<Text>().text = "$"+((int)(PlayerPrefs.GetFloat("Income") * GameObject.Find("KATSAYI_PARENT").GetComponent<KatsayiHesaplama>()._toplamCarpan)).ToString();
            _paraTextCanvas.transform.DOLocalMove(_ucusHedefObjesi.transform.localPosition,.5f);
            Instantiate(_paraBlastFX,null).transform.position=transform.position;
            transform.DOScale(500,.3f);
            transform.DOJump(transform.position,1,1,.5f);
            Destroy(gameObject,.5f);
        }
    }
}
