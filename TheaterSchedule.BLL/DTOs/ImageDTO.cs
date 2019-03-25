namespace TheaterSchedule.BLL.DTO
{
    public class ImageBase64DTO
    {
        public string ImageFormat { get; set; }
        public string Image { get; set; }
    }

    public class ImageBytesDTO
    {
        public string ImageFormat { get; set; }
        public byte[] Image { get; set; }
    }
}
