using LightBDDExample.Resources.Utils;

namespace LightBDDExample.PageObjects
{
    public abstract class SeleniumHqPageMainObjects : CoreObjects
    {
        #region Fields
        private const string seleniumHqUrl = "http://www.seleniumhq.org/";
        #endregion

        #region Protected void functions
        public void GoToSeleniumHq( )
        {
            GotoSite( this.driver, seleniumHqUrl );
            CustomWaits.UntilUrlContains( this.driver, seleniumHqUrl );
        }
        #endregion
    }
}
