using System.Collections;
using TMPro;
using UnityEngine;

public class TextboxEr : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    public void Make(string s, Vector3 p)
    {
        transform.position = p;
        text.text = s;
        StartCoroutine(DestroyIn(5));
    }
    private IEnumerator DestroyIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
