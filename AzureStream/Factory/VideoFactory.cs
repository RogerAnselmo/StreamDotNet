namespace AzureStream.Factory
{
    public static class VideoFactory
    {
        public static string GetVideo(string name)
        {
            switch (name)
            {
                case "earth":
                    return "https://anthonygiretti.blob.core.windows.net/videos/earth.mp4";

                case "nature1":
                    return "https://anthonygiretti.blob.core.windows.net/videos/nature1.mp4";

                case "nature2":
                default:
                    return "https://anthonygiretti.blob.core.windows.net/videos/nature2.mp4";
            }
        }
    }
}
