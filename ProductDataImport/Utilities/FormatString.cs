namespace ProductDataImport.Utilities
{
    /// <summary>
    /// Utility for format image url
    /// </summary>
    public static class FormatString
    {
        /// <summary>
        /// Formats image url as per given extension
        /// </summary>
        /// <param name="fileExtension">File extension</param>
        /// <returns>Url string</returns>
        public static string FormatImgUrl(string fileExtension)
        {
            //Format the url for Image icon
            return string.Format("img/{0}.png", fileExtension.Substring(1, 3));

        }
    }
}
