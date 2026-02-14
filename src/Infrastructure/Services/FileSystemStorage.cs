using System.Buffers;
using Domain.Interfaces;

namespace Infrastructure.Services;

public class FileSystemStorage : IGenomeStorage
{
    private readonly IDnaValidator _validator;
    private readonly string _basePath = Environment.GetEnvironmentVariable("BASE_PATH")
        ?? throw new InvalidOperationException("BASE_PATH not configured.");

    public FileSystemStorage(IDnaValidator validator)
    {
        _validator = validator;
    }


    public async Task<string?> SaveDnaFile(Stream dnaStream)
    {
        Directory.CreateDirectory(_basePath);

        string fileId = $"{Guid.NewGuid()}.dna";
        string fullPath = Path.Combine(_basePath, fileId);

        byte[] buffer = ArrayPool<byte>.Shared.Rent(64 * 1024);
        int bytesRead;

        await using FileStream outputStream = new(
            fullPath,
            FileMode.CreateNew,
            FileAccess.Write,
            FileShare.None,
            bufferSize: 64 * 1024,
            useAsync: true
        );

        try
        {
            while ((bytesRead = await dnaStream.ReadAsync(buffer)) > 0)
            {
                if (!_validator.ValidateChunk(buffer, bytesRead))
                {
                    await outputStream.DisposeAsync();
                    await DeleteDnaFile(fileId);
                    return null;
                } 

                await outputStream.WriteAsync(buffer.AsMemory(0, bytesRead));
            }

            return fileId;
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    public Task<bool> DeleteDnaFile(string fileId)
    {
        string fullPath = Path.Combine(_basePath, fileId);

        if (!File.Exists(fullPath))
            return Task.FromResult(false);

        File.Delete(fullPath);
        return Task.FromResult(true);
    }
}