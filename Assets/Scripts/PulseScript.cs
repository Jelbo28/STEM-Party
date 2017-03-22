using UnityEngine;
using System.Collections;

public class PulseScript : MonoBehaviour
{
    void Update()
    {
        iTween.ScaleTo(this.gameObject, new Vector3(0.5f, 0.5f, 0f), 1f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Aram is amazing.");

            Pulse();

        }
    }
    public void Pulse()
    {

            iTween.ScaleFrom(this.gameObject, new Vector3(1f, 1f, 0f), 1.5f);
        }
}
