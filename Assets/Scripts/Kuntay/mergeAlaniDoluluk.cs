using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mergeAlaniDoluluk : MonoBehaviour
{
    public bool _doluluk;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="turret")
        {
            if (other.transform.GetComponent<TurretMergeKontrol>()._objeYerde)
            {
                _doluluk = true;
            }
        }
    }
}
