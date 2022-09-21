using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using DG.Tweening;

public class StickmanAnimation : MonoBehaviour
{
    Animator _stickmanAnimator;

    [SerializeField] Slider _canBari2,_canBari5;
    [SerializeField] GameObject _moneyObject;
    [SerializeField] List<GameObject> _moneyPoint = new List<GameObject>();
    private GameObject _tempMoney;
    public bool _isboss,_dur;
    private int _hiz;
    public Slider _canBari;

    public bool _secildi; // kullanmayacağım ama belki kullanırız diye var. boss geldiginde sadece tek taret kilitlenmesine sebep olur görüntü güzel olmaz. 

    // Start is called before the first frame update
    void Start()
    {
        _stickmanAnimator = transform.GetComponent<Animator>();
        //if (PlayerPrefs.GetInt("enemySayac") == 5)
            if (_isboss)
            {
            _isboss = true;
            transform.localScale = new Vector3(2,2,2);
            _canBari5.gameObject.transform.parent.gameObject.SetActive(true);
            _canBari2.gameObject.transform.parent.gameObject.SetActive(false);
            _canBari = _canBari5;
            _stickmanAnimator.SetBool("run", false);
            _stickmanAnimator.SetBool("slowRun", true);
            _stickmanAnimator.SetBool("injuredRun", false);
            _stickmanAnimator.SetBool("die", false);
            _stickmanAnimator.SetBool("attack", false);
            _moneyPoint[0].transform.parent.transform.localScale = new Vector3(.5f,.5f,.5f);
            _hiz = 1;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            _canBari5.gameObject.transform.parent.gameObject.SetActive(false);
            _canBari2.gameObject.transform.parent.gameObject.SetActive(true);
            _canBari = _canBari2;
            //int _random = Random.Range(0,2);

            _stickmanAnimator.SetBool("run", true);
            _stickmanAnimator.SetBool("slowRun", false);
            _stickmanAnimator.SetBool("injuredRun", false);
            _stickmanAnimator.SetBool("die", false);
            _stickmanAnimator.SetBool("attack", false);

            _hiz = 2;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.isContinue)
        {
            if (_dur)
            {
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * _hiz);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="warZone")
        {
            transform.GetChild(transform.childCount-1).gameObject.SetActive(true);
        }
        if (other.tag== "projectile")
        {
            Destroy(other.gameObject);
            if (_canBari.value>0f)
            {
                _canBari.value = _canBari.value - 1;
            }

            if (_isboss)
            {
                if (_canBari.value == 4)
                {
                    _stickmanAnimator.SetBool("run", false);
                    _stickmanAnimator.SetBool("slowRun", false);
                    _stickmanAnimator.SetBool("injuredRun", true);
                    _stickmanAnimator.SetBool("die", false);
                    _stickmanAnimator.SetBool("attack", false);

                }

            }
            else
            {
                if (_canBari.value == 1)
                {
                    _stickmanAnimator.SetBool("run", false);
                    _stickmanAnimator.SetBool("slowRun", false);
                    _stickmanAnimator.SetBool("injuredRun", true);
                    _stickmanAnimator.SetBool("die", false);
                    _stickmanAnimator.SetBool("attack", false);

                }

            }


            if (_canBari.value<=0)
            {
                _stickmanAnimator.SetBool("run",false);
                _stickmanAnimator.SetBool("slowRun", false);
                _stickmanAnimator.SetBool("injuredRun", false);
                _stickmanAnimator.SetBool("die", true);
                _stickmanAnimator.SetBool("attack", false);
                _dur = true;
                transform.GetComponent<BoxCollider>().enabled = false;
                if (_isboss)
                {
                    for (int i = 0; i < _moneyPoint.Count; i++)
                    {
                        _tempMoney = Instantiate(_moneyObject, transform);
                        _tempMoney.transform.parent = null;
                        _tempMoney.transform.DOLocalJump(_moneyPoint[i].transform.position, 1, 1, .5f);
                        //_tempMoney.transform.DOLocalJump(_moneyPoint[i].transform.position, 1, 1, .5f).OnComplete(() => _tempMoney.transform.parent = null);
                    }
                }
                else
                {
                    _tempMoney = Instantiate(_moneyObject, transform);
                    _tempMoney.transform.parent = null;
                    _tempMoney.transform.localScale = new Vector3(350,350,350);
                    _tempMoney.transform.DOLocalJump(_moneyPoint[0].transform.position,1,1,.5f);
                }
                Destroy(gameObject, 3f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="warZone")
        {
            _stickmanAnimator.SetBool("run", false);
            _stickmanAnimator.SetBool("slowRun", false);
            _stickmanAnimator.SetBool("injuredRun", false);
            _stickmanAnimator.SetBool("die", false);
            _stickmanAnimator.SetBool("attack", true);
            _dur = true;
        }
    }

}
