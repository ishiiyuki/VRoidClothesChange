# VRoidClothesChange
VRoidモデル専用きせかえ機能

首から下挿げ替え機能はdevelopブランチにあります。

## 使い方
＊注意
UniVRMが必要です　https://github.com/vrm-c/UniVRM

VRoidStudio0.9.0からのMaterial圧縮機能を使ったVRMには対応してません

・モデル側
1.着せ替えたいVRoidStudio製のVRMモデルにColliderとRigidbodyをつける

2.その後BackClothesをアタッチ

・着せ替え判定を取るオブジェクト

1.VRoidStudioで使えるメッシュの上下と靴、アクセサリ毎にスクリプトがあるので対象となるスクリプトをQuadなどににアタッチ

2.スクリプトをつけたQuadなどにColliderを追加してisTriggerをONにする

（上：ChangeClothesTop　下：ChangeClothesBottom　靴：ChangeClothesShoes）

3.着せ替えさせたいテクスチャを紐付けてからそのテクスチャがどの服のメッシュに対応しているのかを設定する


・動作確認
1.　モデル側のColliderと　QuadのColliderが接触してる間にZキーでテクスチャが変わり着せ替えできます。

戻すときはXキーで上半身　Cキーで下半身　Vキーで靴 がもともとのテクスチャに戻ります。

Editor上で動作確認中にもとのテクスチャに戻さずに終了するとテクスチャが差し替わったままになります。



## ライセンス
MIT license


なにかツッコミなどあったら気軽にプルリク投げてください

https://twitter.com/mizuki_izuna
