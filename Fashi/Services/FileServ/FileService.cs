namespace Fashi.Services.FileServ
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)=> _env = env;

        public void DeleteImage(string imagePath)
        {
            if(string.IsNullOrEmpty(imagePath)) return;
            string fullPath=Path.Combine(_env.WebRootPath,imagePath.TrimStart('/'));
            if (File.Exists(fullPath)) ;
            File.Delete(fullPath);

        }

        public async Task<string> UploadFileAsync(IFormFile file, string folderPath)
        {
            string folder= Path.Combine(_env.WebRootPath,"images",folderPath);
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

       string fileName=Guid.NewGuid()+Path.GetExtension(file.FileName);
            string filePath=Path.Combine(folder,fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                 await file.CopyToAsync(stream);
            }
           
            return "/images/"+folderPath+"/"+fileName; 
        }
    }
}
