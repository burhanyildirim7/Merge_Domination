using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamluKontrol : MonoBehaviour
{
    [SerializeField] GameObject _projectile;

    private GameObject _tempMermi;

    public void FireProjectile()
    {
        _tempMermi = Instantiate(_projectile,transform);
    }
}
