using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite first;
    public Sprite spaceImage;
    public Sprite returnImage;

    void Start ()
    {
       // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
		void Update () {

			if (Input.GetKey(KeyCode.Space)) {
					ChangeStateToHold(spaceImage);
			}
			if (Input.GetKey(KeyCode.Return)) {
					ChangeStateToHold(returnImage);
			}
		}

    // 何かしらのタイミングで呼ばれる
    void ChangeStateToHold(Sprite im)
    {
       // SpriteRenderのspriteを設定済みの他のspriteに変更
       // 例) HoldSpriteに変更
        MainSpriteRenderer.sprite = im;
    }
}
