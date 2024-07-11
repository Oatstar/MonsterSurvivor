using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float sweepingSwordInterval = 2f;
    float timer = 0f;
    [SerializeField] GameObject sweepingSword;
    private Quaternion startRotation;

    private void Start()
    {
        sweepingSword.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= sweepingSwordInterval)
        {
            timer = 0;
            SweepingSwordAttack();
        }
    }

    void SweepingSwordAttack()
    {
        sweepingSword.transform.rotation = startRotation;
        sweepingSword.SetActive(true);
        Invoke("HideSword", 1f);
    }

    void HideSword()
    {
        sweepingSword.SetActive(false);
    }
}
