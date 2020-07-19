# VRoidClothesChangeBody
VRoidモデル専用きせかえ機能
がマテリアル圧縮機能で使えなくなってしまったので首から下挿げ替え機能です。

## 使い方
＊注意
UniVRMが必要です　https://github.com/vrm-c/UniVRM

・モデル側
1.ChangeBaseBody.csつける

2.


・マネキン側
1.ChangeBaseBody.csつける

2.空のゲームオブジェクトを作り「VRMSizeFixer」を付けて身長補正誤差を設定します。そのあと対象のマネキン用のVRoidモデルを設定してください。


・動作確認
1.　モデル側のColliderと　QuadのColliderが接触してる間にZキーでテクスチャが変わり着せ替えできます。

戻すときはXキーで上半身　Cキーで下半身　Vキーで靴 がもともとのテクスチャに戻ります。

Editor上で動作確認中にもとのテクスチャに戻さずに終了するとテクスチャが差し替わったままになります。



## ライセンス
MIT license
