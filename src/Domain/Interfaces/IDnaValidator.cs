namespace Domain.Interfaces;

public interface IDnaValidator
{
    bool ValidateChunk(byte[] buffer, int length);
}
