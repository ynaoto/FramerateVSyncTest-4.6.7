# FramerateVSyncTest-4.6.7
FramerateVSyncTest for Unity 4.6.7

## ツール

### mac:
* macOS 10.14.6 (Mojave)
* Xcode 9.4.1

### Windows (Parallels):
* Unity 4.6.7p2 (4.6.7f1 が最新だが、事情により p2 を用いた)

## 目的

Unity 4.6.7 におけるフレームレート設定周りの挙動を確認するため。

## ノート

Unity 4.6.7 は、APFS でフォーマットされたファイルシステム上で正常に動作しない不具合がある (Unity 5.5 で解消)。そのため、Unity プロジェクトの構築とビルドは、Windows 上で行い、生成された Xcode プロジェクトを mac 上で Xcode で開く。

Unity 4.6.7 で生成した Xcode プロジェクトは、Xcode 10 以降と互換性が無い。
