using BepInEx;
using Loader.Data;
using Newtonsoft.Json;
using Nick;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Loader.Core
{
    static class CharacterManager
    {
        private static readonly string baseFolder = Path.Combine(Paths.BepInExRootPath, "Custom Characters");

        public static Dictionary<string, CustomCharacter> characters = new Dictionary<string, CustomCharacter>();
        static readonly List<string> allowedFileTypes = new List<string> { ".zip", ".nickchar" };

        internal static void Init()
        {
            foreach (var file in Directory.GetFiles(baseFolder).Where(x => allowedFileTypes.Contains(Path.GetExtension(x).ToLower())))
            {
                using var archive = ZipFile.OpenRead(file);
                var jsonFile = archive.Entries.Where(x => x.Name.ToLower() == "package.json").FirstOrDefault();

                if (jsonFile != null)
                {
                    var stream = new StreamReader(jsonFile.Open(), Encoding.Default);
                    var jsonString = stream.ReadToEnd();
                    var character = JsonConvert.DeserializeObject<CustomCharacter>(jsonString);
                    character.zipPath = file;
                    if (characters.ContainsKey(character.id))
                        Plugin.LogWarning($"Character with ID '{character.id}' already exists. Skipping!");
                    else
                        characters.Add(character.id, character);
                }
            }

            PrepareCharacterMetadatas();
        }

        static void PrepareCharacterMetadatas()
        {
            var gameMeta = Resources.FindObjectsOfTypeAll<GameMetaData>().FirstOrDefault();
            var charMeta = gameMeta.characterMetas.ToList();

            foreach(var character in characters.Values)
            {
                var meta = ScriptableObject.CreateInstance<CharacterMetaData>();

                meta.hide = false;
                meta.id = character.id;
                meta.locName = character.name;
                meta.showId = character.id;
                meta.isDLC = false;
                meta.skins = new CharacterMetaData.CharacterSkinMetaData[]
                {
                    new CharacterMetaData.CharacterSkinMetaData()
                    {
                        id = character.skinId,
                        locNames = new string[]
                        {
                            character.name
                        },
                        resPortraits = new string[]
                        {
                            string.Empty
                        },
                        resMediumPortraits = new string[]
                        {
                            string.Empty
                        },
                        resMiniPortraits = new string[]
                        {
                            string.Empty
                        },
                        unlockSkin = string.Empty,
                        unlockedByUnlockIds = new string[]
                        {
                            string.Empty
                        }
                    }
                };
                meta.charNameAnnouncerId = null;
                meta.unlockedByUnlockIds = null;

                character.meta = meta;

                charMeta.Add(meta);
            }
            gameMeta.characterMetas = charMeta.ToArray();
        }
    }
}
