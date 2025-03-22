using UnityEngine;

public class OpenCollection : MonoBehaviour
{
    public GameObject Collection;
    public void OpenCollectionMenu() {
        Collection.SetActive(true);
    }

    public void CloseCollectionMenu() {
        Collection.SetActive(false);
    }
}
