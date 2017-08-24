using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UnityToJsonExporter
{
	[MenuItem("UnityToJson/ExportActiveScene")]
	static void ExportActiveScene() 
	{
		string targetpath = EditorUtility.SaveFilePanel("Save json file to", "", "test", "json");
		if (targetpath.Length != 0)
		{
			FileStream filestream = File.Open(targetpath, FileMode.Create);
			StreamWriter jsonfile = new StreamWriter(filestream);

			Scene scene = SceneManager.GetActiveScene ();
			JSONObject rootobj = JSONObject.obj;

			int root_count = scene.rootCount;
			GameObject[] goArray = scene.GetRootGameObjects ();
			for (int i = 0; i < root_count; ++i) {
				GameObject go = goArray [i];
				ToJsonGameObject.ExportGameObject (rootobj, go);
			}

			jsonfile.Write(rootobj.Print(true));
			jsonfile.Close();
			filestream.Close();
		}
	}
}
