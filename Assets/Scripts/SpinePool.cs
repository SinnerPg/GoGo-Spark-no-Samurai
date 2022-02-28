using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinePool : MonoBehaviour
{
    public static SpinePool spinePoolInstance;

    [SerializeField]
    private GameObject pooledSpine;
    private bool notEnoughSpines = true;

    private List<GameObject> spines;

    void Awake() {
        spinePoolInstance = this;
    }
    void Start()
    {
        spines = new List<GameObject>();
    }

    public GameObject GetSpine()
    {
        if(spines.Count > 0)
        {
            for(int i = 0; i < spines.Count; i++)
            {
                if(!spines[i].activeInHierarchy)
                {
                    return spines[i];
                }
            }
        }

        if(notEnoughSpines)
        {
            GameObject spine = Instantiate(pooledSpine);
            spine.SetActive(false);
            spines.Add(spine);
            return spine;
        }

        return null;
    }
}
