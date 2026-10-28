using UnityEngine;

public class LihgtObserved : MonoBehaviour
{
    [SerializeField] CoinObserved coin;
    Light lightComp;

    void Awake()
    {
        lightComp = GetComponent<Light>();
    }

    void OnEnable()
    {
        coin.OnCoinStopped += HandleCoinStopped;
    }

    void OnDisable()
    {
        coin.OnCoinStopped -= HandleCoinStopped;
    }

    void HandleCoinStopped (Transform coinTransform)
    {
        float upResult = Vector3.Dot(coinTransform.up, Vector3.up);
        lightComp.color = upResult > 0 ? Color.green : Color.red;
    }
}
