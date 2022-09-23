using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class AnaSoketKontrol : MonoBehaviour
{
    [SerializeField] GameObject _AnaSoket;
    [SerializeField] Animator _GeneratorAnimator;
    public bool _SYSTEMCONTROL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.isContinue)
        {

            if (_AnaSoket.transform.GetComponent<YapbozAlaniDoluluk>()._soketDoluluk)
            {
                _SYSTEMCONTROL = true;
                _GeneratorAnimator.SetBool("Run", true);
            }
            else
            {
                _SYSTEMCONTROL = false;
                _GeneratorAnimator.SetBool("Run",false);
            }

        }
    }
}
