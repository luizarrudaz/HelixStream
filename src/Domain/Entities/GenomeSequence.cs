using Domain.Enums;
using Domain.Exceptions;

namespace HelixStream.Domain.Entities;

public class GenomeSequence
{
    public Guid Id { get; private set; }

    // The file content follows IUPAC standards: A, T, C, G and N (Unknown).
    public string FilePath { get; private set; }

    public string Label { get; private set; }

    public DateTime UploadedAt { get; private set; }

    public SequenceStatus Status { get; private set; }
    
    public GenomeSequence(Guid id, string filePath, string label)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new InvalidDnaException("File path cannot be empty.");

        Id = id;
        FilePath = filePath;
        Label = label;
        UploadedAt = DateTime.UtcNow;
        Status = SequenceStatus.Pending;
    }

    public void StartAnalysis()
    {
        if (Status != SequenceStatus.Pending)
            throw new InvalidDnaOperationException("Only pending sequences can be analyzed.");
            
        Status = SequenceStatus.InAnalysis;
    }

    public void MarkAsCompleted()
    {
        Status = SequenceStatus.Completed;
    }

    public void MarkAsFailed()
    {
        Status = SequenceStatus.Failed;
    }
}