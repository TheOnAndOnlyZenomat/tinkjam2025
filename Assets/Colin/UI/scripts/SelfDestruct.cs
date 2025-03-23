using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelfDestruct : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf() {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
