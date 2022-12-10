using Amazon.S3;
using Amazon.S3.Model;

public static class S3Service
{
    private static IAmazonS3 Client;
    private static string BucketName;
    private static string ObjectName;
    static S3Service()
    {
        Client = new AmazonS3Client("KEY ID", "SESSION SECRET ID", "TEMP SESSION ID", Amazon.RegionEndpoint.USEast1);
        BucketName = "sicei";
        ObjectName = "profile picture";
    }

    public static async Task<string> UploadFileAsync(
           IFormFile File)
    {
        var request = new PutObjectRequest
        {
            BucketName = BucketName,
            Key = File.FileName,
            InputStream = File.OpenReadStream(),
            ContentType = File.ContentType,
        };

        var response = await Client.PutObjectAsync(request);
        if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            Console.WriteLine($"Successfully uploaded {ObjectName} to {BucketName}.");
            return string.Format("http://{0}.s3.amazonaws.com/{1}", BucketName, File.FileName); ;
        }
        Console.WriteLine($"Could not upload {ObjectName} to {BucketName}.");
        throw new Exception("Filed upload file");
    }
}