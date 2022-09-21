using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpgrade : MonoBehaviour
{
    [SerializeField] GameObject _UpgradePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradePanelAcma()
    {

        _UpgradePanel.SetActive(true);
    }

}
