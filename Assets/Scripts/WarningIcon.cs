using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WarningIcon : MonoBehaviour {

    [SerializeField] private float hideAndShowCount=4f;
    private Image icon;
    private void Start() {
        icon = GetComponent<Image>();
        icon.enabled = false;
    }

    public IEnumerator Show() {
        icon.enabled = true;
        for(int i=0;i< hideAndShowCount;i++) {
            icon.fillAmount = 0;
            yield return new WaitForSeconds(.2f);
            icon.fillAmount = 1;
            yield return new WaitForSeconds(.2f);
        }
        icon.enabled=false;
    }
}
