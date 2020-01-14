# FramerateVSyncTest-4.6.7
FramerateVSyncTest for Unity 4.6.7

## 目的

Unity 4.6.7 におけるフレームレート設定周りの挙動を確認するため。

## 結果

Unity 2017 で同じプロジェクトをビルドした場合、
```
Application.targetFrameRate = 0
QualitySetting.vSyncCount = 0
```
の場合、30fps。

しかし、Unity 4.6.7 の場合、同じ設定で 60fps になる。

## ノート

Unity 4.6.7 は、APFS でフォーマットされたファイルシステム上で正常に動作しない (Unity 4.6.7 の当時、APFS はなかったので仕方がない。Unity 5.5.5p2 で解消 https://forum.unity.com/threads/unity-and-macos-10-13-high-sierra.474527/ )。
そのため、Unity プロジェクトの構築とビルドは、Windows 上で行い、生成された Xcode プロジェクトを mac 上で Xcode で開く。

Unity 4.6.7 で生成した Xcode プロジェクトは、stdテンプレートを使うので、Xcode 10 以降ではコンパイルできない。Xcode 9 以前を使う必要がある。

Unity 上では、arm64 対応のため、IL2CPP 設定でビルドする。
iPhone XS 以降は、アーキテクチャが arm64e になっている。Xcode 9 は、このアーキテクチャをサポートしないので、直接実行することはできないが、arm64 IPA を生成してイてインストールすることはできる。

加えて、以下の二箇所も Xcode 上で要変更。

### Build Settings
BITCODE → NO

### Libraries/libil2cpp/include/il2cpp-config.h
以下のように編集 (__declspec を使わないようにする)
```
#if IL2CPP_COMPILER_MSVC || IL2CPP_TARGET_DARWIN || defined(__ARMCC_VERSION)
//#define NORETURN __declspec(noreturn)
#define NORETURN
#else
#define NORETURN
#endif
```

## ツールバージョン

### mac:
* macOS 10.14.6 (Mojave)
* Xcode 9.4.1

### Windows (Parallels):
* Unity 4.6.7p2 (4.6.7f1 が最新だが、本検証で確かめたかったプロジェクトは p2 を用いていたので、これを使った)

## 測定 (iPhone 11 Pro / iOS 13.3)

### Unity 4.6.7p2

* Application.targetFrameRate =  -1, QualitySetting.vSyncCount = 0 : 60fps
* Application.targetFrameRate =   0, QualitySetting.vSyncCount = 0 : 60fps
* Application.targetFrameRate =  20, QualitySetting.vSyncCount = 0 : 20fps
* Application.targetFrameRate =  30, QualitySetting.vSyncCount = 0 : 30fps
* Application.targetFrameRate =  60, QualitySetting.vSyncCount = 0 : 60fps
* Application.targetFrameRate = 100, QualitySetting.vSyncCount = 0 : 60fps

* Application.targetFrameRate =  -1, QualitySetting.vSyncCount = 1 : 60fps
* Application.targetFrameRate =   0, QualitySetting.vSyncCount = 1 : 60fps
* Application.targetFrameRate =  20, QualitySetting.vSyncCount = 1 : 20fps
* Application.targetFrameRate =  30, QualitySetting.vSyncCount = 1 : 30fps
* Application.targetFrameRate =  60, QualitySetting.vSyncCount = 1 : 60fps
* Application.targetFrameRate = 100, QualitySetting.vSyncCount = 1 : 60fps

* Application.targetFrameRate =  -1, QualitySetting.vSyncCount = 2 : 60fps
* Application.targetFrameRate =   0, QualitySetting.vSyncCount = 2 : 60fps
* Application.targetFrameRate =  20, QualitySetting.vSyncCount = 2 : 20fps
* Application.targetFrameRate =  30, QualitySetting.vSyncCount = 2 : 30fps
* Application.targetFrameRate =  60, QualitySetting.vSyncCount = 2 : 60fps
* Application.targetFrameRate = 100, QualitySetting.vSyncCount = 2 : 60fps

* QualitySetting.vSyncCount = 3 : 設定できない

* QualitySetting.vSyncCount = 4 : 設定できない

### Unity 2017.4.20f2

* Application.targetFrameRate =  -1, QualitySetting.vSyncCount = 0 : 30fps
* Application.targetFrameRate =   0, QualitySetting.vSyncCount = 0 : 30fps
* Application.targetFrameRate =  20, QualitySetting.vSyncCount = 0 : 20fps
* Application.targetFrameRate =  30, QualitySetting.vSyncCount = 0 : 30fps
* Application.targetFrameRate =  60, QualitySetting.vSyncCount = 0 : 60fps
* Application.targetFrameRate = 100, QualitySetting.vSyncCount = 0 : 60fps

* Application.targetFrameRate =  -1, QualitySetting.vSyncCount = 1 : 30fps
* Application.targetFrameRate =   0, QualitySetting.vSyncCount = 1 : 30fps
* Application.targetFrameRate =  20, QualitySetting.vSyncCount = 1 : 20fps
* Application.targetFrameRate =  30, QualitySetting.vSyncCount = 1 : 30fps
* Application.targetFrameRate =  60, QualitySetting.vSyncCount = 1 : 60fps
* Application.targetFrameRate = 100, QualitySetting.vSyncCount = 1 : 60fps

* Application.targetFrameRate =  -1, QualitySetting.vSyncCount = 2 : 30fps
* Application.targetFrameRate =   0, QualitySetting.vSyncCount = 2 : 30fps
* Application.targetFrameRate =  20, QualitySetting.vSyncCount = 2 : 20fps
* Application.targetFrameRate =  30, QualitySetting.vSyncCount = 2 : 30fps
* Application.targetFrameRate =  60, QualitySetting.vSyncCount = 2 : 60fps
* Application.targetFrameRate = 100, QualitySetting.vSyncCount = 2 : 60fps

* Application.targetFrameRate =  -1, QualitySetting.vSyncCount = 3 : 30fps
* Application.targetFrameRate =   0, QualitySetting.vSyncCount = 3 : 30fps
* Application.targetFrameRate =  20, QualitySetting.vSyncCount = 3 : 20fps
* Application.targetFrameRate =  30, QualitySetting.vSyncCount = 3 : 30fps
* Application.targetFrameRate =  60, QualitySetting.vSyncCount = 3 : 60fps
* Application.targetFrameRate = 100, QualitySetting.vSyncCount = 3 : 60fps

* Application.targetFrameRate =  -1, QualitySetting.vSyncCount = 4 : 30fps
* Application.targetFrameRate =   0, QualitySetting.vSyncCount = 4 : 30fps
* Application.targetFrameRate =  20, QualitySetting.vSyncCount = 4 : 20fps
* Application.targetFrameRate =  30, QualitySetting.vSyncCount = 4 : 30fps
* Application.targetFrameRate =  60, QualitySetting.vSyncCount = 4 : 60fps
* Application.targetFrameRate = 100, QualitySetting.vSyncCount = 4 : 60fps
