using UnityEngine;
using System.Collections;

public class CameraFotoControle : MonoBehaviour {
	public Camera cameraFoto;
	private bool takeShot = false;

	// teste
	public int resWidth = 840;
	public int resHeight = 620;
		
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
//			Application.CaptureScreenshot(ScreenShotName());
			tiraFoto2();
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

	// teste outro screenshot
	void tiraFoto2() {
		takeShot |= Input.GetKeyDown("k");
		if (takeShot) {
			RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
			cameraFoto.targetTexture = rt;
			Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
			cameraFoto.Render();
			RenderTexture.active = rt;
			screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
			cameraFoto.targetTexture = null;
			RenderTexture.active = null; // JC: added to avoid errors
			Destroy(rt);
			byte[] bytes = screenShot.EncodeToPNG();
			string filename = ScreenShotName2(resWidth, resHeight);
			System.IO.File.WriteAllBytes(filename, bytes);
			Debug.Log(string.Format("Took screenshot to: {0}", filename));
			takeShot = false;
		}
	}

	public static string ScreenShotName2(int width, int height) {
		return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png",
		                     Application.dataPath,
		                     width, height,
		                     System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}
	
}
