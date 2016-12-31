namespace CScan
{
    internal struct Config
    {
        public bool EnableFiles;
        public bool EnableJson;

        public Config(bool EnableFiles = false, bool EnableJson = false)
        {
            this.EnableFiles = EnableFiles;
            this.EnableJson = EnableJson;
        }
    }
}