using System.Reflection;
using Modding;

namespace PeakingPeekingPeaks;

public class PeakingPeekingPeaks : Mod
{
    public override string GetVersion() => SFCore.Utils.Util.GetVersion(Assembly.GetExecutingAssembly());

    public override void Initialize()
    {
        InitCallbacks();
    }

    private void InitCallbacks()
    {
        ModHooks.LanguageGetHook += OnLanguageGetHook;
    }

    private string OnLanguageGetHook(string key, string sheetTitle, string orig)
    {
        int randomChance = UnityEngine.Random.Range(0, 4);
        string replacementSmall = new string[]
        {
            "peak",
            "peaks",
            "peek",
            "peeks"
        }[randomChance];
        string replacementBig = new string[]
        {
            "Peak",
            "Peaks",
            "Peek",
            "Peeks"
        }[randomChance];
        orig = orig.Replace("peak", replacementSmall);
        orig = orig.Replace("Peak", replacementBig);
        return orig;
    }
}
