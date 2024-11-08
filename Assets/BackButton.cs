using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    void OnMouseUpAsButton()
    {
        Destroy(transform.parent.gameObject);
    }
}
