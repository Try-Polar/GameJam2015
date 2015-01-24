using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SoticeMeNenpai
{
    enum fileType
    {
        Texture2D,Song,SoundEffect,SpriteFont
    }

    public struct LoadObject
    {
        public String FileName;
        public String InternalName;
        public fileType FileType;
    }

    public interface ILoader
    {
        
        public void load();
    }

    public class MasterLoader
    {
        List<LoadObject> Objects;
        TextureLoader Textures;
        public MasterLoader(){
            Objects = new List<LoadObject>();
        }

        public MasterLoader(List<LoadObject> list)
        {
            Objects = list;
        }
    }

    public class TextureLoader : Microsoft.Xna.Framework.Game, ILoader
    {
        List<LoadObject> TexturesList;
        Dictionary<String, Texture2D> LoadedTextures;
        ContentManager Texture2DManager;

        public TextureLoader()
        {
            Texture2DManager = new ContentManager(Services,"Textures");
        }

        public TextureLoader(String RootDirectory)
        {
            Texture2DManager = new ContentManager(Services, RootDirectory);
        }

        public void load()
        {
            foreach (LoadObject texture in TexturesList)
            {
                LoadedTextures.Add(texture.InternalName, Texture2DManager.Load<Texture2D>(texture.FileName));
            }
        }

        public void unload()
        {
            Texture2DManager.Unload();
            LoadedTextures.Clear();
        }

        public Texture2D this[String key]
        {
            get { return LoadedTextures[key]; }
        }
    }

    public class SoundEffectLoader : Microsoft.Xna.Framework.Game, ILoader
    {
        List<LoadObject> SoundEffectsList;
        Dictionary<String, SoundEffect> LoadedSoundEffects;
        ContentManager SoundEffectManager;

        public SoundEffectLoader()
        {
            SoundEffectManager = new ContentManager(Services, "SoundEffects");
        }

        public SoundEffectLoader(String RootDirectory)
        {
            SoundEffectManager = new ContentManager(Services, RootDirectory);
        }

        public void load()
        {
            foreach (LoadObject SoundEffectt in SoundEffectsList)
            {
                LoadedSoundEffects.Add(SoundEffectt.InternalName, SoundEffectManager.Load<SoundEffect>(SoundEffectt.FileName));
            }
        }

        public void unload()
        {
            SoundEffectManager.Unload();
            LoadedSoundEffects.Clear();
        }

        public SoundEffect this[String key]
        {
            get { return LoadedSoundEffects[key]; }
        }
    }

    public class SongLoader : Microsoft.Xna.Framework.Game, ILoader
    {
        List<LoadObject> SongList;
        Dictionary<String, Texture2D> LoadedSongs;
        ContentManager SongManager;

        public SongLoader()
        {
            SongManager = new ContentManager(Services, "Song");
        }

        public SongLoader(String RootDirectory)
        {
            SongManager = new ContentManager(Services, RootDirectory);
        }

        public void load()
        {
            foreach (LoadObject song in SongList)
            {
                LoadedSongs.Add(song.InternalName, SongManager.Load<Texture2D>(song.FileName));
            }
        }

        public void unload()
        {
            SongManager.Unload();
            LoadedSongs.Clear();
        }

        public Texture2D this[String key]
        {
            get { return LoadedSongs[key]; }
        }
    }

    public class SpriteFontLoader : Microsoft.Xna.Framework.Game, ILoader
    {
        List<LoadObject> SpriteFontsList;
        Dictionary<String, SpriteFont> LoadedSpriteFonts;
        ContentManager SpriteFontManager;

        public SpriteFontLoader()
        {
            SpriteFontManager = new ContentManager(Services, "SpriteFonts");
        }

        public SpriteFontLoader(String RootDirectory)
        {
            SpriteFontManager = new ContentManager(Services, RootDirectory);
        }

        public void load()
        {
            foreach (LoadObject SpriteFontt in SpriteFontsList)
            {
                LoadedSpriteFonts.Add(SpriteFontt.InternalName, SpriteFontManager.Load<SpriteFont>(SpriteFontt.FileName));
            }
        }

        public void unload()
        {
            SpriteFontManager.Unload();
            LoadedSpriteFonts.Clear();
        }

        public SpriteFont this[String key]
        {
            get { return LoadedSpriteFonts[key]; }
        }
    }

    
}
