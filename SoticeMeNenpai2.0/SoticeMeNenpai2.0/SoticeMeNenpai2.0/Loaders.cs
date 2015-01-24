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
    public enum fileType
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
        
        void load();
    }

    public class MasterLoader
    {
        List<LoadObject> Objects;
        TextureLoader Textures;
        SongLoader Songs;
        SoundEffectLoader SoundFX;
        SpriteFontLoader SpriteFonts;
        public MasterLoader(){
            Objects = new List<LoadObject>();
        }

        public MasterLoader(List<LoadObject> list)
        {
            Objects = list;
        }

        public void Add(LoadObject Object)
        {
            Objects.Add(Object);
        }

        public void Add(List<LoadObject> Objs)
        {
            foreach (LoadObject obj in Objs)
            {
                Objects.Add(obj);
            }
        }

        public void Add(String InternalName, String FileName, fileType FileType)
        {
            LoadObject temp;
            temp.FileName = FileName;
            temp.FileType = FileType;
            temp.InternalName = InternalName;
            Objects.Add(temp);
        }

        public void load()
        {
            foreach (LoadObject obj in Objects)
            {
                switch (obj.FileType)
                {
                    case fileType.Texture2D:
                        Textures.Add(obj);
                        break;
                    case fileType.Song:
                        Songs.Add(obj);
                        break;
                    case fileType.SoundEffect:
                        SoundFX.Add(obj);
                        break;
                    case fileType.SpriteFont:
                        SpriteFonts.Add(obj);
                        break;
                    default:
                        //Skip, we dont have a loader for it
                        break;
                }
            }
            Textures.load();
            Songs.load();
            SoundFX.load();
            SpriteFonts.load();
        }

        public void unload()
        {
            Textures.unload();
            Songs.unload();
            SoundFX.unload();
            SpriteFonts.unload();
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

        public void Add(LoadObject texture)
        {
            LoadedTextures.Add(texture.InternalName, Texture2DManager.Load<Texture2D>(texture.FileName));
        }

        public void Add(List<LoadObject> TexturesList)
        {
            foreach (LoadObject texture in TexturesList)
            {
                LoadedTextures.Add(texture.InternalName, Texture2DManager.Load<Texture2D>(texture.FileName));
            }
        }

        public void Add(String InternalName, String FileName)
        {
            LoadedTextures.Add(InternalName, Texture2DManager.Load<Texture2D>(FileName));
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

        public void Add(LoadObject soundEffect)
        {
            LoadedSoundEffects.Add(soundEffect.InternalName, SoundEffectManager.Load<SoundEffect>(soundEffect.FileName));
        }

        public void Add(String InternalName, String FileName)
        {
            LoadedSoundEffects.Add(InternalName, SoundEffectManager.Load<SoundEffect>(FileName));
        }

        public void Add(List<LoadObject> SoundEffectsList)
        {
            foreach (LoadObject sfx in SoundEffectsList)
            {
                LoadedSoundEffects.Add(sfx.InternalName, SoundEffectManager.Load<SoundEffect>(sfx.FileName));
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
        Dictionary<String, Song> LoadedSongs;
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
                LoadedSongs.Add(song.InternalName, SongManager.Load<Song>(song.FileName));
            }
        }

        public void Add(LoadObject song)
        {
            LoadedSongs.Add(song.InternalName, SongManager.Load<Song>(song.FileName));
        }

        public void Add(String InternalName, String FileName)
        {
            LoadedSongs.Add(InternalName, SongManager.Load<Song>(FileName));
        }
        public void Add(List<LoadObject> SoundEffectsList)
        {
            foreach (LoadObject song in SoundEffectsList)
            {
                LoadedSongs.Add(song.InternalName, SongManager.Load<Song>(song.FileName));
            }
        }

        public void unload()
        {
            SongManager.Unload();
            LoadedSongs.Clear();
        }

        public Song this[String key]
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

        public void Add(LoadObject spriteFont)
        {
            LoadedSpriteFonts.Add(spriteFont.InternalName, SpriteFontManager.Load<SpriteFont>(spriteFont.FileName));
        }

        public void Add(String InternalName, String FileName)
        {
            LoadedSpriteFonts.Add(InternalName, SpriteFontManager.Load<SpriteFont>(FileName));
        }

        public void Add(List<LoadObject> SpriteFontList)
        {
            foreach (LoadObject sfx in SpriteFontList)
            {
                LoadedSpriteFonts.Add(sfx.InternalName, SpriteFontManager.Load<SpriteFont>(sfx.FileName));
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
