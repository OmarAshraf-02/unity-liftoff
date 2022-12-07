using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){return;} /* we make sure our period is not less then epsilon rather than comparing it to zero as floats can vary on a microscopic level 
                                            so it's not recommended to compare to zero equality always compare with epsilon when dealing with floats */
        
        float cycles = Time.time / period;  // continually growing over time       
        const float tau = Mathf.PI * 2;  // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // oscillates between -1 and 1

        movementFactor = (rawSinWave + 1f) / 2f; //recalculated to make the oscillation range 0 to 1 so its cleaner

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
