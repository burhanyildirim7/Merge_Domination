using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class KafaKontrol : MonoBehaviour
{
    [SerializeField] List<GameObject> _namluList = new List<GameObject>();

    public GameObject _target;

    [SerializeField]private List<GameObject> _targetList = new List<GameObject>();

    private bool _locked;

    private float _fireRate,_timer,_timer2;
    private int _namlusayac;
    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
        _timer2 = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.isContinue)
        {
            for (int i = 0; i < _targetList.Count; i++)
            {
                if (_targetList[i]==null)
                {
                    _targetList.Remove(_targetList[i]);
                }
            }
            if (_locked==false)
            {
                if (_targetList.Count>0)
                {
                    for (int i = 0; i < _targetList.Count; i++)
                    {
                        if (_targetList[i].transform.GetComponent<StickmanAnimation>()._secildi == false)
                        {
                            if (_targetList[i].transform.GetComponent<StickmanAnimation>()._isboss)
                            {
                                _target = _targetList[i].gameObject;
                                _locked = true;
                                _timer = 0;
                            }
                            else
                            {
                                _targetList[i].transform.GetComponent<StickmanAnimation>()._secildi = true;
                                _target = _targetList[i].gameObject;
                                _locked = true;
                                _timer = 0;
                            }
                            break;
                        }
                    }

                }
            }
            else
            {

                _timer += Time.deltaTime;
                _timer2 += Time.deltaTime;
                _fireRate= PlayerPrefs.GetFloat("FireRate");
                if (_target.transform.GetComponent<StickmanAnimation>()._canBari.value>0)
                {
                    transform.LookAt(_target.transform.position);
                    if (_timer>1)
                    {
                        if (_timer2>0.2f)
                        {
                            _timer2 = 0;
                            Atesleme();
                            _namlusayac++;
                        }
                        if (_namlusayac==_namluList.Count)
                        {
                            _timer = 0;
                        }
                    }
                }
                else
                {
                    _locked = false;
                    _targetList.Remove(_target);
                }
            }

        }
    }

    private void Atesleme()
    {


        if (_namlusayac==_namluList.Count)
        {
            _namlusayac = 0;
        }
        _namluList[_namlusayac].transform.GetChild(0).transform.GetComponent<NamluKontrol>().FireProjectile();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="enemy")
        {
            _targetList.Add(other.gameObject.transform.parent.gameObject);
        }
    }

}
