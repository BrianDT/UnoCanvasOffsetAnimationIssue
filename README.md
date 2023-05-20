# UnoCanvasOffsetAnimationIssue

Reported as Uno issue #12301
https://github.com/unoplatform/uno/issues/12301

Unable to animate the canvas top or left attached properties on WASM, Android, iOS

Expected
In the sample the red ball should animate vertically up the screen 

The sample now shows that if EnableDependentAnimation="true" the WASM and iOS build execute as expected.
Therefore, in summary
Windows OK
Android Fail
iOS OK with workaround
WASM OK with workaround

