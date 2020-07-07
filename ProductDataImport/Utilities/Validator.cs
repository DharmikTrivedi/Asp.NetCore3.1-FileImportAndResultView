namespace ProductDataImport.Utilities
{
    /// <summary>
    /// Utility to validate file type
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Evaluates weather the format is correct or not
        /// </summary>
        /// <param name="fileExtension">File extension</param>
        /// <returns>True or False</returns>
        public static bool IsValidFIle(string fileExtension)
        {
            //checks and returns given condition value
            return fileExtension == ".csv" || fileExtension == ".flf" || fileExtension == ".tsv" ? true : false;

        }
    }
}
