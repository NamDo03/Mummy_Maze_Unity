using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public GameObject prefabToShow;  // Gắn Prefab vào đây trong Inspector
    private GameObject instantiatedPrefab;

    void OnMouseUpAsButton()
    {
        if (prefabToShow != null && instantiatedPrefab == null)
        {
            Vector3 position = new Vector3(3, 3.33f, 0);
            Quaternion rotation = Quaternion.identity;
            instantiatedPrefab = Instantiate(prefabToShow, position, rotation);
        }
    }
}
