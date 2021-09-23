using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[ExecuteInEditMode]
public class ImageFillGradient : MonoBehaviour {
    [SerializeField] private Gradient gradient = null;
    [SerializeField] private Image image = null;

    private void Awake() {
        image = GetComponent<Image>();
    }

    private void Update() {
        image.color = gradient.Evaluate(image.fillAmount);
    }
}