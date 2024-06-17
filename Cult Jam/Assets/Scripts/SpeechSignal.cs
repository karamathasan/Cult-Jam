using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechSignal : MonoBehaviour
{
    Player p;
    [SerializeField]
    float detectionRadius = 1f;
    [SerializeField]
    [TextArea(2,5)]
    string speech;
    private void Start()
    {
        Player p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        this.p = p;
    }
    private void Update()
    {
        if (Vector2.Distance(p.transform.position, transform.position) < detectionRadius)
        {
            p.speech.speak(speech);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
