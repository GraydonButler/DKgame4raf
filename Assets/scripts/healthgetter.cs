using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthgetter : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeHealth(string health)
    {
        text.text = health;

    }
}
