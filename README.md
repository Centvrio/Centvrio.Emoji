## Centvrio.Emoji - [Emoji v5.0](http://unicode.org/Public/emoji/5.0/emoji-test.txt) implementation for .NET
[![NuGet](https://img.shields.io/nuget/v/Centvrio.Emoji.svg?style=flat-square)](https://www.nuget.org/packages/Centvrio.Emoji/)
[![NuGet](https://img.shields.io/nuget/dt/Centvrio.Emoji.svg?style=flat-square)](https://www.nuget.org/packages/Centvrio.Emoji/)
[![GitHub license](https://img.shields.io/github/license/Centvrio/Centvrio.Emoji.svg?style=flat-square)](https://github.com/Centvrio/Centvrio.Emoji/blob/master/LICENSE)
[![AppVeyor](https://img.shields.io/appveyor/ci/Centvrio/centvrio-emoji.svg?style=flat-square)](https://ci.appveyor.com/project/Centvrio/centvrio-emoji)
[![AppVeyor tests](https://img.shields.io/appveyor/tests/Centvrio/centvrio-emoji.svg?style=flat-square)](https://ci.appveyor.com/project/Centvrio/centvrio-emoji)

### Get it on NuGet
```powershell
Install-Package Centvrio.Emoji
```

### Documentation
Use single-character emoji
```csharp
string print = $"Grinning face: {FacePositive.Grinning}";
```
**Result:** Grinning face: 😀

Create single-character emoji
```csharp
UnicodeString smile = 0x1F600;
string print = $"Grinning face: {smile}";
```
**Result:** Grinning face: 😀

Create multi-character emoji
```csharp
UnicodeSequence manDarkSkin = Person.Man + ModifierFitzpatrick.Type6;
string print = $"Man dark skin tone emoji: {manDarkSkin}";
```
**Result:** Man dark skin tone emoji: 👨🏿

Create country flag
```csharp
UnicodeSequence ukraine = RegionalIndicator.U + RegionalIndicator.A;
string print = $"Ukraine flag: {ukraine}";
```
**Result:** Ukraine flag: 🇺🇦