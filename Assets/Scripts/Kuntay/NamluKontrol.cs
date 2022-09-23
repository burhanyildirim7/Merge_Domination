using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamluKontrol : MonoBehaviour
{
    [SerializeField] GameObject _projectile,_fireFX;

    private GameObject _tempMermi,_tempfireFX;

    public void FireProjectile()
    {
        _tempMermi = Instantiate(_projectile,transform);
        _tempfireFX = Instantiate(_fireFX, transform);
    }
}
