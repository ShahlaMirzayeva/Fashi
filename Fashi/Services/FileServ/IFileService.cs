namespace Fashi.Services.FileServ
{
    public interface IFileService
    {
        Task<string > UploadFileAsync(IFormFile file, string folderPath);
        void DeleteImage(string imagePath);

    }
}
