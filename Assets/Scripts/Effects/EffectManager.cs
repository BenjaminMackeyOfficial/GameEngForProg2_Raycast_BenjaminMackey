using System;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public EffectManager Instance {
    get{ return instance; }
    }
    private EffectManager instance;


    [SerializeField] GameObject textBox;

    private void Start()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }
    public GameObject SpawnTextbox(string says, Vector3 position)
    {
        return Instantiate(textBox);
    }
}
