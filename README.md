# UnityAssetPath
This project provides a structure to represent Unity assets (or folders). You can easily pass around these objects and access filename, path or extension without having to deal with System.IO all the time. Also it takes care of adding the stupid "Assets/" prefix if you are dealing with the AssetDatabase, without you having to put "Assets/" everywhere. Just a little handy thing.

## Usage
There are a few different ways you can use this. For now it supports only files, not directories really, let's see if I get around to do that:

`var path = new UnityAssetPath("Assets/Prefabs/VeryCoolThing.prefab");` <br>
`var path = new UnityAssetPath("Prefabs/VeryCoolThing.prefab");` <br>
`var path = new UnityAssetPath("Prefabs/VeryCoolThing", ".prefab");` <br>

Any of those will work. You can then use

`string ToString(bool includeAssetsPrefix, bool includeExtension)`

to get the path as a string for different use cases.
