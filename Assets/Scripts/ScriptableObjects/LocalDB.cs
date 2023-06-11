using System.Collections;
using System.IO;
using UnityEngine;

	public class LocalDB : MonoBehaviourSingleton<LocalDB>
	{
		#region MyRegion

		internal DB db;
		private readonly string fileName = "gfxscof.sffod";
		private string path;

		[SerializeField] ProgressData progressData;
		#endregion

		#region Unity Lifecycle


		private void Awake()
		{
			base.Awake();
#if UNITY_ANDROID && !UNITY_EDITOR || UNITY_IOS && !UNITY_EDITOR
            path = global::System.IO.Path.Combine(Application.persistentDataPath, fileName);
#else
			path = global::System.IO.Path.Combine(Application.dataPath, fileName);
#endif
			DontDestroyOnLoad(this);
			Load();
		}


#if UNITY_EDITOR
		private void OnApplicationQuit()
		{
			Save();
		}
#endif

#if UNITY_ANDROID && !UNITY_EDITOR || UNITY_IOS && !UNITY_EDITOR
         private void OnApplicationPause(bool isPause)
         {
             if (isPause)
             {
                 Save();
             }
         }
#endif

		#endregion

		#region Methods

		private void Load()
		{
			var json = ReadFromFIle();
			if (string.IsNullOrEmpty(json)) return;
			db = JsonUtility.FromJson<DB>(json); 
		}

		private void Save()
		{
			string json = JsonUtility.ToJson(db);
			WriteToFile(json);
		}

		private void WriteToFile(string json)
		{
			FileStream fileStream = new FileStream(path, FileMode.Create);

			using StreamWriter writer = new StreamWriter(fileStream);
			writer.Write(json);
		}

		private string ReadFromFIle()
		{
			if (File.Exists(path))
			{
				using StreamReader reader = new StreamReader(path);
				string json = reader.ReadToEnd();
				return json;
			}

			File.Create(path);
			InitDefaultDB();
			return null;
		}
		internal bool AddEnergyDecreaseLevel(out string outputString)
		{
			db.data.energyDecreaseLevel++;
			db.data.money -= db.data.energyDecreaseCost;
			db.data.energyDecreaseValue = progressData.energyLose[db.data.energyDecreaseLevel];
			db.data.energyDecreaseCost = progressData.energyLoseCost[db.data.energyDecreaseLevel];
			outputString = $"Steel stomach: {db.data.energyDecreaseLevel} ({db.data.energyDecreaseCost})";
			return db.data.money >= db.data.energyDecreaseCost;
		}

		internal bool AddEnergyIncreaseLevel(out string outputString)
		{
			db.data.energyIncreaseLevel++;
			db.data.money -= db.data.energyIncreaseCost;
			db.data.energyIncreaseValue = progressData.energyGain[db.data.energyIncreaseLevel];
			db.data.energyIncreaseCost = progressData.energyGainCost[db.data.energyIncreaseLevel];
			outputString = $"Food Quality: {db.data.energyIncreaseLevel} ({db.data.energyIncreaseCost})";
			return db.data.money >= db.data.energyIncreaseCost;
		}

		internal bool AddLaunchForceLevel(out string outputString)
		{
			db.data.launchForceLevel++;
			db.data.money -= db.data.launchForceCost;
			db.data.launchForceValue = progressData.launchSpeed[db.data.launchForceLevel];
			db.data.launchForceCost = progressData.launchSpeedCost[db.data.launchForceLevel];
			outputString = $"Launch force: {db.data.launchForceLevel} ({db.data.launchForceCost})";
			return db.data.money >= db.data.launchForceCost;
		}

		internal bool AddRopeLevel(out string outputString)
		{
			db.data.ropeLevel++;
			db.data.money -= db.data.ropeCost;
			db.data.ropeValue = progressData.endPos[db.data.ropeLevel];
			db.data.ropeCost = progressData.endPosCost[db.data.ropeLevel];
			outputString = $"Rope Length: {db.data.ropeLevel} ({db.data.ropeCost})";
			return db.data.money >= db.data.ropeCost;
		}
	private void InitDefaultDB()
		{
			db.data = new UpgradableData();
			db.data.ropeValue = progressData.endPos[0];
			db.data.energyDecreaseValue = progressData.energyLose[0];
			db.data.energyIncreaseValue = progressData.energyGain[0];
			db.data.launchForceValue = progressData.launchSpeed[0];
			db.data.ropeCost = progressData.endPosCost[0];
			db.data.energyIncreaseCost = progressData.energyGainCost[0];
			db.data.energyDecreaseCost = progressData.energyLoseCost[0];
			db.data.launchForceCost = progressData.launchSpeedCost[0];
			db.data.money = progressData.money;
			Debug.Log(db.data.ropeValue);
		}
		#endregion
	}

	#region Wrapper Save Load System

	[System.Serializable]
	public struct DB
	{
		public UpgradableData data;	
	}

#endregion
[System.Serializable]
public class UpgradableData
{
	public int ropeLevel;
	public float ropeValue;
	public int energyIncreaseLevel;
	public float energyIncreaseValue;
	public int energyDecreaseLevel;
	public float energyDecreaseValue;
	public int launchForceLevel;
	public float launchForceValue;
	public int ropeCost;
	public int energyIncreaseCost;
	public int energyDecreaseCost;
	public int launchForceCost;
	public int money;
}