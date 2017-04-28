using LightBDDExample.Resources.Utils;

namespace LightBDDExample.PageObjects
{
    public abstract class AndersHejlsbergWikiObjects : CoreObjects
    {

        #region Fields
        private const string andersHejlsbergWikiUrl = "https://en.wikipedia.org/wiki/Anders_Hejlsberg";
        #endregion

        public void GoToAndersHejlsbergWikiPage( )
        {
            GotoSite( this.driver, andersHejlsbergWikiUrl );
            CustomWaits.UntilUrlContains( this.driver, andersHejlsbergWikiUrl );
        }

    }
}
