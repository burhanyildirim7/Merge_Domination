using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int _hiz;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.instance.isContinue)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _hiz);
        }
    }

}
