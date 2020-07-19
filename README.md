# VRoidClothesChangeBody
VRoidモデル専用きせかえ機能
がマテリアル圧縮機能で使えなくなってしまったので首から下挿げ替え機能です。

## 使い方
＊注意
UniVRMが必要です　https://github.com/vrm-c/UniVRM

・モデル側
1.ChangeBaseBody.csつける

2.自分に当たり判定をつける


・マネキン側
1.ChangeBaseBody.csつける　当たり判定もつける

2.空のゲームオブジェクトを作り「VRMSizeFixer」を付けて身長補正誤差を設定します。そのあと対象のマネキン用のVRoidモデルを設定してください。


・動作確認
1.　マネキンの当たり判定と接触中にZキーで身体が挿げ替えされます

戻すときはXキーで元の身体にもどります



## ライセンス
MIT license
