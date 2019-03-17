//.NET Framework 2.0以降のみ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;



public class battery : MonoBehaviour {
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite high;
    public Sprite middle;
    public Sprite low;
		public Sprite charge;

    struct SYSTEM_POWER_STATUS
    {
        public byte ACLineStatus;
        public byte BatteryFlag;
        public byte BatteryLifePercent;
        public byte Reserved1;
        public int BatteryLifeTime;
        public int BatteryFullLifeTime;
    }

		SYSTEM_POWER_STATUS sps = new SYSTEM_POWER_STATUS();
    void Start () {
       // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		}
		void Update () {

			if ((sps.BatteryFlag & 1) == 1)
			{
				ChangeStateToHold(high);
			}
			if ((sps.BatteryFlag & 2) == 2)
			{
				ChangeStateToHold(middle);
			}
			if ((sps.BatteryFlag & 4) == 4)
			{
				ChangeStateToHold(low);
			}
			if ((sps.BatteryFlag & 8) == 8)
			{
				ChangeStateToHold(charge);
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
