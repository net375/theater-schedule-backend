namespace TheaterSchedule.BLL.DTO
{
    public class ImageBase64
    {
        public string ImageFormat { get; set; }
        public string Image { get; set; }
    }

    public class ImageBytes
    {
        public string ImageFormat { get; set; }
        public byte[] Image { get; set; }
    }
}
