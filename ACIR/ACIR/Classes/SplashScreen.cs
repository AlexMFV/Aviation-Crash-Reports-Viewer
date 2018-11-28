using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACIR
{
    public static class SplashScreen
    {
        static LoadingScreen sf = null;

        public static void ShowSplashScreen()
        {
            if (sf == null)
            {
                sf = new LoadingScreen();
                sf.ShowSplashScreen();
            }
        }

        public static void CloseSplashScreen()
        {
            if (sf != null)
            {
                sf.CloseSplashScreen();
                sf = null;
            }
        }
    }
}
