using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsHandler : MonoBehaviour
{
    [HideInInspector]
    public int points = 0;
    public GameObject uiTextObject;
    private TextMeshProUGUI uiText;

    public void Start()
    {
        uiText = uiTextObject.GetComponent<TextMeshProUGUI>();
        if(uiText == null)
        {
            Debug.LogWarning("Score UI is null. Score will not be counted");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meteor") && uiText != null)
        {
            points++;
            uiText.text = points.ToString();
        }
    }
}
