## Create a new Siri intent

### Prerequisites

- Xcode 10
- Xamarin version compatible with Xcode 10
- [Objective Sharpie](https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/binding/objective-sharpie/)

### Important!!! Localization

Not sure if this is a bug or a feature, but in order for custom responses to work on the phone (they do work fine on the Watch), the intent definition file has to be localized with XCode's localization. And when importing it in the project the localization folders have to be imported, not just the single file.

Also, be aware that the the BuildAction for the `Intents.strings` file has to be set to `BundleResource`, while the BuildAction for the `Intents.intentdefinition` file has to be set to `Content.

Reference: https://github.com/xamarin/xamarin-macios/issues/4581
And the solution: https://stackoverflow.com/a/52686556/942420

Also, when adding new Intents we should probably copy the `Intents.strings` file somewhere and merge it with the new one if we don't want to lose changes. That's until Apple gives us another way of doing this.

### Generate intent code

1. Open `Toggl.Daneel.IntentCodeGen/Toggl.Daneel.IntentCodeGen.xcodeproj` using Xcode.
1. Modify the "Intents.intentdefinition" as needed.
1. Build the project.
1. Find the generated `.h` and `.m` for intents by following the instruction in `AppDelegate.m`.
1. Have the files ready for the next step.

### Generate static lib and C# binding code

1. Open `Toggl.Daneel.IntentStaticLib/Toggl.Daneel.IntentStaticLib.xcodeproj` using Xcode.
1. Copy all the files from the previous step to the project.
1. Open the shell, then run

```bash
make
```

This will build the static library and also generate C# code for the binding project. The files we're interested in are:

- `libToggl.Daneel.IntentStaticLib.a` - The fat Cocoa library for i368 & arm64.
- `bo/ApiDefinitions.cs` and `bo/StructsAndEnums.cs` - Generated C# binding code.

### Update the Xamarin binding library

1. Open the main `Toggl.sln` and find `Toggl.Daneel.IntentBinding` project.
2. Replace the content of the code with the generated `ApiDefinitions.cs` and `StructsAndEnums.cs` from the previous step.
3. The files generated by Sharpie need some adjustment before they can be used:

- `StructsAndEnums.cs`
Change all the enum type from `nint` to `long`

```csharp
// public enum StopTimerIntentResponseCode : nint
public enum StopTimerIntentResponseCode : long
```

- `ApiDefinitions.cs`
Remove all the `[Watch (5,0), iOS (12,0)]` attributes as they're not needed for the project. Refer to [Xamarin](https://docs.microsoft.com/en-us/xamarin/ios/platform/introduction-to-ios12/siri-shortcuts)

```csharp
  [Watch (5,0), iOS (12,0)] // Remove this
	[BaseType (typeof(INIntent))]
	interface StopTimerIntent
```

4. The `libToggl.Daneel.IntentStaticLib.a` is symlinked to the static lib, so nothing to do here.

### Update `Toggl.Daneel.SiriExtension`'s `Info.Plist`

1. Ensure the `IntentsSupported` includes all the supported intents

### Done
