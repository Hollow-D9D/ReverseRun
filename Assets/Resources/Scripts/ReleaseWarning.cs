using System.Collections;
using TMPro;
using UnityEngine;

public class ReleaseWarning : MonoBehaviour {

    [SerializeField] private int hideAndShowCount = 6;
    [Range(0,1), SerializeField] private float hideAndShowInterval;
    [SerializeField]private TextMeshProUGUI text;
    private void Start() {
        text = GetComponent<TextMeshProUGUI>();
        text.enabled = false;
    }

    public IEnumerator Show() {
        for(int i = 0;i < hideAndShowCount;i++) {
            ShowText(true);
            yield return new WaitForSeconds(hideAndShowInterval);
            ShowText(false);
            yield return new WaitForSeconds(hideAndShowInterval);
        }
    }
    public void ShowText(bool show) {
        text.enabled = show;
    }

}
