using Amazon.S3;
using Amazon.S3.Model;

public static class S3Service
{
    private static IAmazonS3 Client;
    private static string BucketName;
    private static string ObjectName;
    static S3Service()
    {
        Client = new AmazonS3Client("ASIAVJ47HDML7E3TQJFQ", "ji5t0p87avPoTGpyEwnyvcm07EwbwHlm/ZCkkdP3", "FwoGZXIvYXdzEGUaDFk2NadqcQRlbCkVbCLLAVyuRFyCqUA2XkAn19aI5kVDFIMWToMAJgqL8VFCA7Qmbm1xxJUI0+LDIhUYwHfnmcgaVfr4ulvS44ge22w8v9EO5K1c+OQ9EVdRFlsF960MwPTZ99vMQX3erw8byxInotWP/+NgtZ/t7n7ZrgDr8hSJ5ovSZKjencScXj9y/+lGdAhaVEAlggsDPiXXNbUy1mAHp9AvUnDiuzOnogxjAA4R27k+ZYZzt2kjEcj5+uXEsHBqdKWQrmDIUpXiMIgc9cDxJKUViBRLlUYRKP2705wGMi2MUzBaGQJ1uWY6l/G+zgrOy2oKqoUyh9SwkaBmLiRrMSuKfvR8kKEhpQ3G0F0=", Amazon.RegionEndpoint.USEast1);
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