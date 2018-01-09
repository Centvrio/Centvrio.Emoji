## Centvrio.Emoji - [Emoji v5.0](http://unicode.org/Public/emoji/5.0/emoji-test.txt) implementation for .NET
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Centvrio.Emoji.svg?style=flat-square)](https://www.nuget.org/packages/Centvrio.Emoji/)
[![NuGet](https://img.shields.io/nuget/dt/Centvrio.Emoji.svg?style=flat-square)](https://www.nuget.org/packages/Centvrio.Emoji/)
[![GitHub license](https://img.shields.io/github/license/Centvrio/Centvrio.Emoji.svg?style=flat-square)](https://github.com/Centvrio/Centvrio.Emoji/blob/master/LICENSE)

### Get it on NuGet
```powershell
Install-Package Centvrio.Emoji -IncludePrerelease
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