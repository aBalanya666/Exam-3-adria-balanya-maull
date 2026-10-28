using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Apple;

public class BallCounter : MonoBehaviour
{
    [SerializeField] TMP_Text counterText;

    readonly HashSet<Rigidbody> captured = new HashSet<Rigidbody>(); 

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;
        if (captured.Add(rb))
        {
            Debug.Log("Balls captured: " + captured.Count);
            counterText.text = "Balls: " + captured.Count;
        }
    }

}
