using UnityEngine;

public class openBridge : MonoBehaviour
{
    [SerializeField] GameObject bridge;
    [SerializeField] GameObject block;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bridge.SetActive(true);
        block.SetActive(false);
    }
}
