namespace Domain.Interfaces;

public interface IGenomeStorage
{
    Task<string?> SaveDnaFile(Stream dnaStream);
    Task<bool> DeleteDnaFile(string fileId);
}

