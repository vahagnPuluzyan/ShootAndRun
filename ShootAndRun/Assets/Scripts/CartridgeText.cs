using TMPro;
using UnityEngine;

public class CartridgeText : MonoBehaviour
{
    TextMeshProUGUI cartridgeText;

    private void Start()
    {
        cartridgeText = GetComponent<TextMeshProUGUI>();   
    }

    void Update()
    {
        cartridgeText.text = Shooting._instance.cartidges.ToString();
    }
}
