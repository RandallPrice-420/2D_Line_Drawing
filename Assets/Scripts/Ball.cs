using UnityEngine;


public class Ball : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        // Destroy the GameObject when it becomes invisible.
        Destroy(gameObject);

    }   // OnBecameInvisible()


    private void Update()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 500)
        {
            Destroy(gameObject);
        }

    }   // Update()


}   // class Ball
