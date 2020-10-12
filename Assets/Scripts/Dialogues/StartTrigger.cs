using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    public Dialogue start;
    public Collider2D cd;

    public void OnTriggerEnter2D(Collider2D cd)
    {
        FindObjectOfType<DialogueManager>().StartStart(start);
    }
}
