using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageUI : MonoBehaviour {

	public Image img;

	public Sprite[] sprites;

	public void SetWarmUpImage(){
		img.sprite = sprites[0];
	}

	public void SetNormalImage(){
		img.sprite = sprites[1];
	}

	public void SetOvertakeGainImage(){
		img.sprite = sprites[2];
	}

	public void SetOvertakeLossImage(){
		img.sprite = sprites[3];
	}

	public void SetDefeatImage(){
		img.sprite = sprites[4];
	}

	public void SetBestWinImage(){
		img.sprite = sprites[5];
	}

	public void SetGoodWinImage(){
		img.sprite = sprites[6];
	}

	public void SetOKWinImage(){
		img.sprite = sprites[7];
	}
	public void SetBadWinImage(){
		img.sprite = sprites[8];
	}
	public void SetWorstWinImage(){
		img.sprite = sprites[9];
	}
}