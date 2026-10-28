using UnityEngine;

public class CoinObserved : MonoBehaviour
{

    public event System.Action<Transform> OnCoinStopped;

    Rigidbody rb;
    bool notified;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 50f;

        Vector3 randomForce = new Vector3(
            Random.Range(-2f, 2f),
            Random.Range(4f, 8f),
            Random.Range(-2f, 5f));

        Vector3 randomTorque = new Vector3(
            Random.Range(-5f, 5f),
            Random.Range(-5f, 5f),
            Random.Range(-5f, 5f));

        rb.AddForce(randomForce, ForceMode.Impulse);
        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (!notified && rb.IsSleeping())
        {
            notified = true;
            OnCoinStopped?.Invoke(transform);
        }
    }
}