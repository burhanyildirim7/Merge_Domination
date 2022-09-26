using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject _enemyObject,_bossObject;
    [SerializeField] List<GameObject> _spawnPointsList = new List<GameObject>();

    private float _sayac1,_sayac2;
    private int _randomSayi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.isContinue)
        {
            if (GameObject.Find("SOKETLER_PARENT").transform.GetComponent<AnaSoketKontrol>()._SYSTEMCONTROL)
            {
                _sayac1 += Time.deltaTime;

                if (_sayac1 > PlayerPrefs.GetFloat("EnemySpawnRate"))
                {
                    _sayac1 = 0;
                    _sayac2++;

                    if (_sayac2 < 20)
                    {
                        _randomSayi = Random.Range(0, _spawnPointsList.Count);
                        Instantiate(_enemyObject, null).transform.position = _spawnPointsList[_randomSayi].transform.position;
                    }
                    else
                    {
                        _sayac2 = 0;
                        Instantiate(_bossObject, null).transform.position = _spawnPointsList[_randomSayi].transform.position;
                    }
                }
            }
            else
            {

            }
        }
    }
}
