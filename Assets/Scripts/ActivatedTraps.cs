using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedTraps : Trampas
{
    private void OnTriggerEnter(Collider other) {
        activated = true;
    }
}
