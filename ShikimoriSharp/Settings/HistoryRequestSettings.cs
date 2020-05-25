namespace ShikimoriSharp.Settings
{
    /// <summary>
    ///     So the point of this class is to fix the "target_type" in <see cref="HistoryRequestSettings" />
    /// </summary>
    public class HistoryRequestSettings : BasicSettings
    {
        public string target_id;
        public string target_type;
    }
}