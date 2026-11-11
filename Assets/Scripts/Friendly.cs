using System.Collections;
using UnityEngine;

public class Friendly : MonoBehaviour, Iinteractible
{
    public bool isTarget => false;
    public void Interact()
    {
        if (!speaking)
        {
            speaking = true;
            StartCoroutine(CoinCollected());
        }
    }

    bool speaking;
    private IEnumerator CoinCollected()
    {
        GameObject g = EffectManager.Instance.SpawnTextbox("Hello!", transform.position + Vector3.up * 2);
        g.transform.parent = transform;
        yield return new WaitForSecondsRealtime(6);
    }
}
