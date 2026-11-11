using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour, Iinteractible
{
    public bool isTarget => false;
    public void Interact() 
    {
        if (!collected)
        {
            collected = true;
            StartCoroutine(CoinCollected());
        }
    }

    bool collected;
    private IEnumerator CoinCollected()
    {
        GameObject g = EffectManager.Instance.SpawnTextbox("+ Coin.." , transform.position + Vector3.up * 2);
        g.transform.parent = transform;
        for (float i = 0; i < 3; i += Time.deltaTime)
        {
            transform.position = transform.position + Vector3.up * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }

}
