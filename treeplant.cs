using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeplant : MonoBehaviour
{
    public GameObject Treeplant;

    public void PlantTree( Vector3 pos) {
        pos = pos + new Vector3 (0,2,0);
        Instantiate (Treeplant, pos, Quaternion.identity);
    }
}
