using Nick;
using SMU.Utilities;
using System.Collections;
using System.IO;
using System.IO.Compression;
using UnityEngine;

namespace Loader.Data
{
    class CustomCharacter
    {
        public string id;
        public string name;
        public string author;

        public string filePath;

        public string charPath;
        public string skinPath;
        public string skinId;

        public string smallPortraitPath;
        private Sprite _smallPortrait;
        public Sprite SmallPortrait => _smallPortrait ??= LoadSpriteFromZip(smallPortraitPath);

        public string mediumPortraitPath;
        private Sprite _mediumPortrait;
        public Sprite MediumPortrait => _mediumPortrait ??= LoadSpriteFromZip(mediumPortraitPath);

        public string largePortraitPath;
        private Sprite _largePortrait;
        public Sprite LargePortrait => _largePortrait ??= LoadSpriteFromZip(largePortraitPath);

        public string cssBackgroundPath;
        private Sprite _cssBackground;
        public Sprite CssBackground => _cssBackground ??= LoadSpriteFromZip(cssBackgroundPath);

        public string playerSlotBackgroundPath;
        private Sprite _playerSlotBackground;
        public Sprite PlayerSlotBackground => _playerSlotBackground ??= LoadSpriteFromZip(playerSlotBackgroundPath);

        public string vsBackgroundPath;
        private Sprite _vsBackground;
        public Sprite VsBackground => _vsBackground ??= LoadSpriteFromZip(vsBackgroundPath);

        public GameAgent agent;
        public bool loading = false;
        public string zipPath;
        public CharacterMetaData meta;
        public AssetBundle bundle;

        private CharactersUIMetaData.CharacterUIElements _UIElements;
        public CharactersUIMetaData.CharacterUIElements UIElements
        {
            get
            {
                _UIElements ??= new CharactersUIMetaData.CharacterUIElements()
                {
                    ID = id,
                    CharacterLarge = LargePortrait,
                    CharacterMedium = MediumPortrait,
                    CharacterSmall = SmallPortrait,
                    CharacterSlotBackground = CssBackground,
                    PlayerSlotBackground = PlayerSlotBackground,
                    VSBackground = VsBackground
                };
                return _UIElements;
            }
        }

        Sprite LoadSpriteFromZip(string path)
        {
            using var zip = ZipFile.OpenRead(zipPath);
            var stream = new BufferedStream(zip.GetEntry(path).Open());
            byte[] bytes;
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                bytes = ms.ToArray();
            }

            var sprite = ImageHelper.LoadSpriteRaw(bytes);
            sprite.texture.wrapMode = TextureWrapMode.Clamp;

            return (sprite);
        }

        public void LoadAssetBundle()
        {
            if (bundle == null && !loading)
                SharedCoroutineStarter.StartCoroutine(LoadAssetBundleCoroutine());
        }

        IEnumerator LoadAssetBundleCoroutine()
        {
            Plugin.LogInfo($"Loading Assetbundle for {name}...");
            loading = true;
            using (var zip = ZipFile.OpenRead(zipPath))
            {
                var stream = new MemoryStream();
                zip.GetEntry(filePath).Open().CopyTo(stream);
                var request = AssetBundle.LoadFromStreamAsync(stream);

                while (!request.isDone) yield return null;

                bundle = request.assetBundle;

                var idScenesDict = GameObject.FindObjectOfType<AgentLoading>().idScenes.IdDict;
                idScenesDict.Add(id, charPath);
                idScenesDict.Add(skinId, skinPath);
            }
            Plugin.LogInfo($"{name} loaded!");
            loading = false;
        }
    }
}
