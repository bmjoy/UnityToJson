using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToJsonGameObject {

	public static void ExportGameObject (JSONObject parentJsonObj, GameObject go)
	{
		JSONObject jsonGo = JSONObject.obj;
		parentJsonObj.AddField ("gameobject", jsonGo);

		jsonGo.AddField("name", go.name);

		JSONObject scaleobj = ToJsonCommon.ToJsonObjectVector3 (go.transform.localScale);
		JSONObject rotateobj = ToJsonCommon.ToJsonObjectQuaternion (go.transform.localRotation);
		JSONObject translateobj = ToJsonCommon.ToJsonObjectVector3 (go.transform.localPosition);
		jsonGo.AddField ("scale", scaleobj);
		jsonGo.AddField ("rotate", rotateobj);
		jsonGo.AddField ("translate", translateobj);
	}

	static void ExportCamera(JSONObject jsonobj, GameObject go)
	{
	}

	static void Export(JSONObject jsonobj, Transform transform)
	{
	}
}
