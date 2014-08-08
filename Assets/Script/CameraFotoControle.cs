using UnityEngine;
using System.Collections;

public class CameraFotoControle : MonoBehaviour {
	public Camera cameraFoto;
	private bool takeShot = false;
		
	void Update() {
		tiraFoto();
	}

	/// <summary>
	/// habilita camera 1pessoa quando rightClick 
	/// for apertado. permitindo tirar foto.
	/// se apertar novamente. sai da 1pessoa. 
	/// </summary>
	private void tiraFoto(){
		if (Input.GetMouseButtonDown(1)){
			takeShot = !takeShot;
		}
		cameraFoto.enabled = takeShot;
		
		if (takeShot && Input.GetMouseButtonDown(0)) {
			Application.CaptureScreenshot(ScreenShotName());
			Debug.Log(string.Format("Took screenshot"));
		}
	}

	/// <summary>
	/// retorna caminho onde sera salvo o screenshot e nome.
	/// </summary>
	/// <returns>The shot name.</returns>
	public static string ScreenShotName() {
		return string.Format("{0}/screenshots/screen_{1}.png", Application.dataPath, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}
	
}
