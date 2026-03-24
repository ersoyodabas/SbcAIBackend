namespace Sbc.SERVICE
{
    /// <summary>
    /// Standard service response object.
    /// </summary>
    public class ReturnObject
    {
        public bool result { get; set; }
        public string message { get; set; } = string.Empty;
        public object? data { get; set; }
    }
}