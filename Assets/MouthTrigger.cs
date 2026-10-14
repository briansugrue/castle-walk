using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Detects when an EdibleObject enters this trigger zone and calls Eat() on it
public class MouthTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)   // Checks if the entering object is edible and consumes it if so
    {
        EdibleObject edible = other.GetComponent<EdibleObject>();

        if (edible != null)
        {
            edible.Eat();
        }
    }
}
