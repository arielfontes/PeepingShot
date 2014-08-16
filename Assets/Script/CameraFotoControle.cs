using UnityEngine;
using System.Collections;

public class CameraFotoControle : MonoBehaviour {
	public Camera cameraFoto;
	private bool takeShot = false;

	// teste
	public int resWidth = 840;
	public int resHeight = 620;
		
	void Update() {
		preparaCameraTiraFoto();
	}

	/// <summary>
	/// habilita camera 1pessoa quando rightClick 
	/// for apertado. permitindo tirar foto.
	/// se apertar novamente. sai da 1pessoa. 
	/// </summary>
	private void preparaCameraTiraFoto(){
		if (Input.GetMouseButtonDown(1)){
			takeShot = !takeShot;
		}
		cameraFoto.enabled = takeShot;
		
		if (takeShot && Input.GetMouseButtonDown(0)) {
//			Application.CaptureScreenshot(ScreenShotName());
			StartCoroutine(tiraFoto());
		}
	}

	/// <summary>
	/// retorna caminho onde sera salvo o screenshot e nome.
	/// </summary>
	/// <returns>nome e caminho do arquivo.</returns>
	public static string ScreenShotName() {
		return string.Format("{0}/screenshots/screen_{1}.png", Application.dataPath, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}

	/// <summary>
	/// Metodo captura todos os bytes de um frame
	/// e salva em um arquivo png. 
	/// </summary>
	/// <returns> IEnumerator </returns>
	IEnumerator tiraFoto() {
		yield return new WaitForEndOfFrame();
		if (takeShot) {
			RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
			cameraFoto.targetTexture = rt;
			Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
			cameraFoto.Render();
			RenderTexture.active = rt;
			screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
			cameraFoto.targetTexture = null;
			RenderTexture.active = null;
			Destroy(rt);
			byte[] bytes = screenShot.EncodeToPNG();
			System.IO.File.WriteAllBytes(ScreenShotName(), bytes);
			Debug.Log(string.Format("Took screenshot to: {0}", ScreenShotName()));
		}
	}
	
}
