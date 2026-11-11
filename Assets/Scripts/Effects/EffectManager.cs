using System;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance {
    get{ return instance; }
    }
    private static EffectManager instance;


    [SerializeField] GameObject textBox;

    private void Start()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }
    public GameObject SpawnTextbox(string says, Vector3 position)
    {
        GameObject g = Instantiate(textBox);
        TextboxEr t = g.GetComponent<TextboxEr>();
        t.Make(says, position);
        return g;
        
    }
}
