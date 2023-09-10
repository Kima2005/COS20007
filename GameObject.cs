using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace test
{
    public class GameObject
    {


        public Sprite _sprite;

        public Bitmap _img;

        public AnimationScript _scr;

        public SplashKitSDK.Timer _timer;

        public float X_sp { get => SplashKit.SpriteX(_sprite); set => SplashKit.SpriteSetX(_sprite, value); }

        public float Y_sp { get => SplashKit.SpriteY(_sprite); set => SplashKit.SpriteSetY(_sprite, value); }

        public GameObject()
        {
         
        }

        private static int resourceBundleLoadCount = 0;
        private const int maxResourceBundleLoadCount = 3;

        public GameObject(string bitmapname, string anim_name, string filename, string bundle_name, string bundle_file)
        {

            if (resourceBundleLoadCount < maxResourceBundleLoadCount)
            {
                if (!SplashKit.HasResourceBundle(bundle_name))
                {
                    SplashKit.LoadResourceBundle(bundle_name, bundle_file);
                    resourceBundleLoadCount++;
                }
            }
            _img = SplashKit.BitmapNamed(bitmapname);
        
            _scr = SplashKit.LoadAnimationScript(anim_name, filename);
    
            _sprite = SplashKit.CreateSprite(_img, _scr);
          
        }
        public void Draw()
        {
            SplashKit.DrawSprite(_sprite);
        }

        public void Update()
        {
            SplashKit.UpdateSpriteAnimation(_sprite);
        }
    }
}
