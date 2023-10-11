# P3App

 The Unity side of our P3 pinball game

## Branch structure

The [`main`](https://github.com/Pinball-Club-Meridian-High-School/P3App/tree/main) branch represents a stable release of the project.

Development is split into 2 branches, [`Unity5.6.7`](https://github.com/Pinball-Club-Meridian-High-School/P3App/tree/Unity5.6.7) and [`Unity2017.4.40`](https://github.com/Pinball-Club-Meridian-High-School/P3App/tree/Unity2017.4.40). Multimorphic — the company who develops the P3 — requires the App to be built in Unity 5.6.7 to make a permanent build. Unfortunately, Unity 5 is [not compatible with MacOS](https://forum.unity.com/threads/installing-unity-on-macos-catalina.689089/#post-4681994), which is used by most of our students. To work around this, development mainly happens on the `Unity2017.4.40` branch, as Unity 2017 does work on Mac. Changes are then merged into `Unity5.6.7` and backported to Unity 5. Official releases on the `main` branch should use Unity 5.

You can install the relevant Unity versions (`5.6.7` and `2017.4.40`) from https://unity.com/releases/editor/archive.
