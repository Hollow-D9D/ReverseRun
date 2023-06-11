using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum UpgradeMode
{
    RopeLength,
    EnergyIncrease,
    EnergyDecrease,
    LaunchForce
}

public class UpgradeSwitcherUI : MonoBehaviour
{
    public static UpgradeMode upgradeMode { get; private set; } = UpgradeMode.RopeLength;
    [SerializeField] Image footerColor;
    [SerializeField] Image headerColor;
    [SerializeField] Image ActionButtonColor;
    [SerializeField] TextMeshProUGUI captionText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] Button upgradeButton;
    [SerializeField] Money money;
    private Color button1Color;
    private Color button2Color;
    private Color button3Color;
    private Color button4Color;
    private string captionString;

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#78E08FC7", out button1Color);
        ColorUtility.TryParseHtmlString("#E55039C7", out button2Color);
        ColorUtility.TryParseHtmlString("#60A3BCC7", out button3Color);
        ColorUtility.TryParseHtmlString("#F6B93BC7", out button4Color);

        OnButton1Click();
    }
    public void OnButton1Click()
    {
        footerColor.color = button1Color;
        headerColor.color = button1Color;
        
        ActionButtonColor.color = button1Color;
        upgradeMode = UpgradeMode.RopeLength;
        
        captionText.color = button1Color;
        descriptionText.color = button1Color;

        captionString = $"Rope Length: {LocalDB.Instance.db.data.ropeLevel} ({LocalDB.Instance.db.data.ropeCost})";
        captionText.text = captionString;
        descriptionText.text = "Increases the length of the rope";

        upgradeButton.interactable = LocalDB.Instance.db.data.ropeCost <= LocalDB.Instance.db.data.money;
    }
    public void OnButton2Click()
    {
        footerColor.color = button2Color;
        headerColor.color = button2Color;

        captionText.color = button2Color;
        descriptionText.color = button2Color;

        ActionButtonColor.color = button2Color;
        upgradeMode = UpgradeMode.EnergyIncrease;

        captionString = $"Food Quality: {LocalDB.Instance.db.data.energyIncreaseLevel} ({LocalDB.Instance.db.data.energyIncreaseCost})";
        captionText.text = captionString;
        descriptionText.text = "Increases the amount of energy given by food";

        upgradeButton.interactable = LocalDB.Instance.db.data.energyIncreaseCost <= LocalDB.Instance.db.data.money;
    }
    public void OnButton3Click()
    {
        footerColor.color = button3Color;
        headerColor.color = button3Color;

        captionText.color = button3Color;
        descriptionText.color = button3Color;


        ActionButtonColor.color = button3Color;
        upgradeMode = UpgradeMode.EnergyDecrease;

        captionString = $"Steel stomach: {LocalDB.Instance.db.data.energyDecreaseLevel} ({LocalDB.Instance.db.data.energyDecreaseCost})";
        captionText.text = captionString;
        descriptionText.text = "Rotten food will take less energy";
        
        upgradeButton.interactable = LocalDB.Instance.db.data.energyDecreaseCost <= LocalDB.Instance.db.data.money;
    }
    public void OnButton4Click()
    {
        footerColor.color = button4Color;
        headerColor.color = button4Color;

        captionText.color = button4Color;
        descriptionText.color = button4Color;

        ActionButtonColor.color = button4Color;
        upgradeMode = UpgradeMode.LaunchForce;

        captionString = $"Launch force: {LocalDB.Instance.db.data.launchForceLevel} ({LocalDB.Instance.db.data.launchForceCost})";
        captionText.text = captionString;
        descriptionText.text = "Tick rope is a gamechanger";

        upgradeButton.interactable = LocalDB.Instance.db.data.launchForceCost <= LocalDB.Instance.db.data.money;
    }

    public void OnUpgrade(bool canUpgrade, string outputString)
    {
        upgradeButton.interactable = canUpgrade;
        captionText.text = outputString;
        money.updateMoney();
    }
}
