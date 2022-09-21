using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeScript : MonoBehaviour
{
    [SerializeField] Text _fireRateText, _incomeText,_fireRateBedel,_incomeBedel;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("FireRate",1);
        PlayerPrefs.SetFloat("Income", 10);
        if (PlayerPrefs.GetInt("UpgradeIlkSefer")==0)
        {
            PlayerPrefs.SetInt("FireRateLevel", 1);
            PlayerPrefs.SetInt("IncomeLevel", 1);

            PlayerPrefs.SetInt("FireRateBedel", PlayerPrefs.GetInt("FireRateBedel") + 100);
            PlayerPrefs.SetInt("IncomeBedel", PlayerPrefs.GetInt("IncomeBedel") + 100);

            PlayerPrefs.SetInt("UpgradeIlkSefer", 1);
        }
        else
        {
            _fireRateText.text = PlayerPrefs.GetInt("FireRateLevel").ToString();
            _incomeText.text = PlayerPrefs.GetInt("IncomeLevel").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("totalScore") < PlayerPrefs.GetInt("FireRateBedel"))
        {
            _fireRateText.transform.parent.transform.GetComponent<Button>().interactable = false;

        }
        if (PlayerPrefs.GetInt("totalScore") < PlayerPrefs.GetInt("IncomeBedel"))
        {
            _incomeText.transform.parent.transform.GetComponent<Button>().interactable = false;

        }
    }

    public void FireRateUpgrade()
    {

        PlayerPrefs.SetFloat("FireRate", PlayerPrefs.GetFloat("FireRate")*.95f);
        PlayerPrefs.SetInt("FireRateLevel", PlayerPrefs.GetInt("FireRateLevel")+1);
        _fireRateText.text = "LEVEL"+PlayerPrefs.GetInt("FireRateLevel").ToString();

        PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") - PlayerPrefs.GetInt("FireRateBedel"));
        UIController.instance.SetGamePlayScoreText();

        PlayerPrefs.SetInt("FireRateBedel", PlayerPrefs.GetInt("FireRateBedel") + 100);
        _fireRateBedel.text = "$" + (PlayerPrefs.GetInt("FireRateBedel"));
    }

    public void IncomeUpgrade()
    {
        PlayerPrefs.SetFloat("Income", PlayerPrefs.GetFloat("Income") * 1.1f);
        PlayerPrefs.SetInt("IncomeLevel", PlayerPrefs.GetInt("IncomeLevel")+1);
        _incomeText.text = "LEVEL" + PlayerPrefs.GetInt("IncomeLevel").ToString();

        PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") - PlayerPrefs.GetInt("IncomeBedel"));
        UIController.instance.SetGamePlayScoreText();

        PlayerPrefs.SetInt("IncomeBedel", PlayerPrefs.GetInt("IncomeBedel") + 100);
        _incomeBedel.text = "$" + (PlayerPrefs.GetInt("IncomeBedel"));
    }
    public void CloseWindowButton()
    {

        transform.gameObject.SetActive(false);

    }
}
