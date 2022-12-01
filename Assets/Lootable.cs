using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [SerializeField] protected Transform parentToDestroy;
    private void Start()
    {
        if (!parentToDestroy)
        {
            parentToDestroy = GetComponentInParent<Transform>();
            if (!parentToDestroy)
            {
                Destroy(this);
            }
        }
    }
}
