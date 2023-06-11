using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    private UpgradeSwitcherUI upgradeSwitcher;

    private void Start()
    {
        upgradeSwitcher = GetComponent<UpgradeSwitcherUI>();
    }
    public void OnUpgrade()
    {
        bool success;
        string outputString;
        UpgradeMode upgradeMode = UpgradeSwitcherUI.upgradeMode;
        if (upgradeMode == UpgradeMode.RopeLength)
        {
            success = LocalDB.Instance.AddRopeLevel(out outputString);
        }
        else if(upgradeMode == UpgradeMode.EnergyIncrease)
        {
            success = LocalDB.Instance.AddEnergyIncreaseLevel(out outputString);
        }
        else if (upgradeMode == UpgradeMode.EnergyDecrease)
        {
            success = LocalDB.Instance.AddEnergyDecreaseLevel(out outputString);
        }
        else
        {
            success = LocalDB.Instance.AddLaunchForceLevel(out outputString);
        }
        upgradeSwitcher.OnUpgrade(success, outputString);
    }
}
